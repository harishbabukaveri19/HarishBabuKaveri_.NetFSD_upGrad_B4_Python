// app.js - Main application logic, event handling, and UI interactions
$(document).ready(() => {

    // --- State Management (Tracks API Parameters) ---
    let _state = {
        page: 1,
        pageSize: typeof PAGE_SIZE !== 'undefined' ? PAGE_SIZE : 10,
        search: '',
        dept: '',
        status: '',
        sortBy: 'id',
        sortDir: 'asc'
    };

    let searchTimeout;

    // --- Routing & Initialization ---
    const checkAuthAndRoute = async () => {
        if (authService.isLoggedIn()) {
            $('#main-nav').removeClass('d-none');
            $('#login-view, #signup-view').addClass('d-none');

            // --- UI Updates for Authenticated User ---
            let user = authService.getCurrentUser() || 'User';
            // Format "admin" to "Admin"
            user = user.charAt(0).toUpperCase() + user.slice(1);
            
            // Check the role and create a visual badge
            const roleBadge = authService.isAdmin() 
                ? '<span class="badge bg-danger ms-2" style="font-size:0.8rem; vertical-align: middle;">ADMIN</span>' 
                : '<span class="badge bg-danger ms-2" style="font-size:0.8rem; vertical-align: middle;">VIEWER</span>';
            
            // Inject the username AND the badge into the HTML
            $('#nav-username').html(`${user} ${roleBadge}`);

            // Apply role restrictions to write buttons
            uiService.applyRoleUI();

            // Populate department dropdown
            uiService.populateDepartmentDropdown(employeeService.getUniqueDepartments());

            // Load initial data
            showView('dashboard');
            await refreshDashboard();
            await loadEmployees();
        } else {
            $('#main-nav').addClass('d-none');
            $('.view-section').addClass('d-none');
            $('#login-view').removeClass('d-none');
        }
    };

    const showView = (viewName) => {
        window.scrollTo(0, 0);
        $('.view-section').addClass('d-none');
        $(`#${viewName}-view`).removeClass('d-none');
        $('.nav-link').removeClass('active');
        $(`#nav-${viewName}`).addClass('active');
    };

    // --- Data Loading ---
    const refreshDashboard = async () => {
        try {
            const summary = await dashboardService.getSummary();
            uiService.renderDashboardCards(summary);
            uiService.renderDepartmentBreakdown(summary.departmentBreakdown);
            uiService.renderRecentEmployees(summary.recentEmployees);
        } catch (error) {
            console.error("Dashboard error:", error);
        }
    };

    const loadEmployees = async () => {
        try {
            const result = await employeeService.getEmployees(
                _state.search, _state.dept, _state.status, 
                _state.sortBy, _state.sortDir, 
                _state.page, _state.pageSize
            );
            uiService.renderEmployeeTable(result);
        } catch (error) {
            console.error("Failed to load employees:", error);
            uiService.showToast("Failed to load employee list.", "danger");
        }
    };

    // --- Authentication Events ---
    $('#login-form').submit(async (e) => {
        e.preventDefault();
        const username = $('#login-username').val().trim();
        const password = $('#login-password').val();

        // AWAIT the real API call
        const success = await authService.login(username, password);
        
        if (success) {
            $('#login-error').addClass('d-none');
            await checkAuthAndRoute();
            uiService.showToast('Login successful!');
        } else {
            $('#login-error').removeClass('d-none');
        }
    });

    $('#signup-form').submit(async (e) => {
        e.preventDefault();
        const u = $('#signup-username').val().trim();
        const p = $('#signup-password').val();
        const c = $('#signup-confirm').val();

        let errors = validationService.validateAuthForm(u, p, c);
        
        if (!errors) {
            const res = await authService.signup(u, p);
            if (res.success) {
                uiService.showToast('Signup successful. Please login.');
                $('#signup-view').addClass('d-none');
                $('#login-view').removeClass('d-none');
                uiService.clearForm('signup-form');
            } else {
                // Map server 409 errors to UI
                errors = validationService.mapServerErrors(res.message);
            }
        }
        uiService.showInlineErrors(errors);
    });

    $('#logout-btn').click(() => {
        authService.logout();
        checkAuthAndRoute();
        uiService.clearForm('login-form');
    });

    $('#link-to-signup').click((e) => { e.preventDefault(); $('#login-view').addClass('d-none'); $('#signup-view').removeClass('d-none'); });
    $('#link-to-login').click((e) => { e.preventDefault(); $('#signup-view').addClass('d-none'); $('#login-view').removeClass('d-none'); });

    // --- Navigation Events ---
    $('#nav-dashboard').click(async (e) => { e.preventDefault(); showView('dashboard'); await refreshDashboard(); });
    $('#nav-employees').click(async (e) => { e.preventDefault(); showView('employees'); await loadEmployees(); });
    $('.navbar-brand').click(async (e) => { e.preventDefault(); showView('dashboard'); await refreshDashboard(); });

    // --- Table Filtering & Sorting Events ---
    $('#search-input').on('input', function() {
        clearTimeout(searchTimeout);
        _state.search = $(this).val();
        _state.page = 1; 
        searchTimeout = setTimeout(loadEmployees, 350); // Debounce
    });

    $('#filter-dept').change(function() {
        _state.dept = $(this).val();
        _state.page = 1;
        loadEmployees();
    });

    $('input[name="statusFilter"]').change(function() {
        _state.status = $(this).val();
        _state.page = 1;
        loadEmployees();
    });

    $('.sortable').click(function () {
        const field = $(this).data('sort');
        if (_state.sortBy === field) {
            _state.sortDir = _state.sortDir === 'asc' ? 'desc' : 'asc';
        } else {
            _state.sortBy = field;
            _state.sortDir = 'asc';
        }

        $('.sortable i').removeClass('bi-arrow-up bi-arrow-down').addClass('bi-arrow-down-up text-muted');
        const icon = $(this).find('i');
        icon.removeClass('bi-arrow-down-up text-muted').addClass(_state.sortDir === 'asc' ? 'bi-arrow-up text-primary' : 'bi-arrow-down text-primary');

        loadEmployees();
    });

    // Pagination Event Delegation
    $('#pagination-bar').on('click', '.page-link', function(e) {
        e.preventDefault();
        const targetPage = $(this).data('page');
        if (targetPage && !$(this).parent().hasClass('disabled')) {
            _state.page = parseInt(targetPage);
            loadEmployees();
        }
    });

    // --- CRUD Events ---
    $('#nav-add-btn, #page-add-btn').click(() => uiService.showModal('add'));

    $('#save-employee-btn').click(async () => {
        const id = $('#emp-id').val();
        const isEdit = !!id;

        const data = {
            firstName: $('#emp-firstName').val(),
            lastName: $('#emp-lastName').val(),
            email: $('#emp-email').val(),
            phone: $('#emp-phone').val(),
            department: $('#emp-department').val(),
            designation: $('#emp-designation').val(),
            salary: Number($('#emp-salary').val()),
            joinDate: $('#emp-joinDate').val(),
            gender: $('#emp-gender').val(),
            status: $('#emp-status').val()
        };

        let errors = validationService.validateEmployeeForm(data, isEdit, id ? parseInt(id) : null);
        
        if (!errors) {
            try {
                if (isEdit) {
                    await employeeService.update(parseInt(id), data);
                    uiService.showToast('Employee updated successfully');
                } else {
                    await employeeService.add(data);
                    uiService.showToast('Employee added successfully');
                    _state.page = 1; // Go to page 1 to see the new record
                }
                uiService.closeModal('employeeModal');
                await refreshDashboard();
                await loadEmployees();
            } catch (error) {
                // Catch API 409 errors (duplicate email)
                errors = validationService.mapServerErrors(error.message);
            }
        }
        uiService.showInlineErrors(errors);
    });

    // Action button delegation
    $('#employee-table-body').on('click', '.btn-view', async function () {
        const id = $(this).data('id');
        const emp = await employeeService.getById(id);
        if(emp) uiService.showModal('view', emp);
    });

    $('#employee-table-body').on('click', '.btn-edit', async function () {
        const id = $(this).data('id');
        const emp = await employeeService.getById(id);
        if(emp) uiService.showModal('edit', emp);
    });

    $('#employee-table-body').on('click', '.btn-delete', async function () {
        const id = $(this).data('id');
        const emp = await employeeService.getById(id);
        if(emp) uiService.showModal('delete', emp);
    });

    $('#confirm-delete-btn').click(async function () {
        const id = $(this).data('id');
        try {
            await employeeService.remove(id);
            uiService.closeModal('deleteModal');
            uiService.showToast('Employee deleted successfully', 'danger');
            
            // If we delete the last item on page 2, go back to page 1
            const tbody = $('#employee-table-body tr');
            if (tbody.length === 1 && _state.page > 1) {
                _state.page--;
            }

            await refreshDashboard();
            await loadEmployees();
        } catch (error) {
            uiService.showToast('Failed to delete employee.', 'danger');
        }
    });

    // Boot App
    checkAuthAndRoute();
});

// Fix for modal accessibility
document.querySelectorAll('.modal').forEach(modal => {
    modal.addEventListener('hide.bs.modal', function () {
        if (document.activeElement) document.activeElement.blur(); 
    });
});

/* Mobile Navbar Handlers */
$(document).ready(function () {
    $('#nav-dashboard, #nav-employees, #nav-add-btn').on('click', function () {
        const mobileMenu = document.getElementById('navbarNav');
        if (mobileMenu && mobileMenu.classList.contains('show')) bootstrap.Collapse.getInstance(mobileMenu)?.hide();
    });
    $(window).on('touchmove wheel', function () {
        const mobileMenu = document.getElementById('navbarNav');
        if (mobileMenu && mobileMenu.classList.contains('show')) bootstrap.Collapse.getInstance(mobileMenu)?.hide();
    });
    $(document).on('click', function (event) {
        const mobileMenu = document.getElementById('navbarNav');
        if (!$(event.target).closest('.navbar').length && mobileMenu && mobileMenu.classList.contains('show')) {
            bootstrap.Collapse.getInstance(mobileMenu)?.hide();
        }
    });
});

/* Password Toggles */
$(document).ready(function() {
    $(document).on('click', '#toggleLoginPassword', function() {
        const passwordInput = $('#login-password');
        if (passwordInput.attr('type') === 'password') {
            passwordInput.attr('type', 'text');
            $(this).removeClass('bi-eye-slash text-muted').addClass('bi-eye text-primary');
        } else {
            passwordInput.attr('type', 'password');
            $(this).removeClass('bi-eye text-primary').addClass('bi-eye-slash text-muted');
        }
    });
    $(document).on('click', '.toggle-signup-pwd', function() {
        const passwordInput = $(this).siblings('input');
        if (passwordInput.attr('type') === 'password') {
            passwordInput.attr('type', 'text'); 
            $(this).removeClass('bi-eye-slash text-muted').addClass('bi-eye text-primary');
        } else {
            passwordInput.attr('type', 'password'); 
            $(this).removeClass('bi-eye text-primary').addClass('bi-eye-slash text-muted');
        }
    });
});