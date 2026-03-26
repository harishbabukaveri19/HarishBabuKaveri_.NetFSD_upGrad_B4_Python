// app.js - Main application logic, event handling, and UI interactions
$(document).ready(() => {

    // State
    let currentSort = { field: 'id', direction: 'asc' };

    // --- Routing & Initialization ---
    const checkAuthAndRoute = () => {
        if (authService.isLoggedIn()) {
            $('#main-nav').removeClass('d-none');
            $('#login-view, #signup-view').addClass('d-none');

            // --- SAFELY UPDATE AND FORMAT THE USERNAME ---
            const user = authService.getCurrentUser() || 'Admin';

            // 1. Add a space between lowercase and uppercase letters (HarishBabu -> Harish Babu)
            let formattedUser = user.replace(/([a-z])([A-Z])/g, '$1 $2');

            // 2. Capitalize the very first letter just to be safe
            formattedUser = formattedUser.charAt(0).toUpperCase() + formattedUser.slice(1);

            $('#nav-username').text(formattedUser);
            // ----------------------------------------------

            showView('dashboard');
            refreshAppContent();
        } else {
            $('#main-nav').addClass('d-none');
            $('.view-section').addClass('d-none');
            $('#login-view').removeClass('d-none');
        }
    };

    const showView = (viewName) => {
        window.scrollTo(0, 0); // Scroll to top on view change
        $('.view-section').addClass('d-none');
        $(`#${viewName}-view`).removeClass('d-none');
        $('.nav-link').removeClass('active');
        $(`#nav-${viewName}`).addClass('active');
    };

    const refreshAppContent = () => {
        // Refresh Dashboard Cards
        uiService.renderDashboardCards(dashboardService.getSummary());
        uiService.renderDepartmentBreakdown(dashboardService.getDepartmentBreakdown());
        uiService.renderRecentEmployees(dashboardService.getRecentEmployees());

        // Refresh Employee Table logic
        uiService.populateDepartmentDropdown(employeeService.getUniqueDepartments());
        triggerFilterSortUpdate();
    };

    const triggerFilterSortUpdate = () => {
        const query = $('#search-input').val();
        const dept = $('#filter-dept').val();
        const status = $('input[name="statusFilter"]:checked').val();

        let filtered = employeeService.applyFilters(query, dept, status);
        let sorted = employeeService.sortBy(filtered, currentSort.field, currentSort.direction);

        uiService.renderEmployeeTable(sorted);
    };

    // --- Authentication Events ---
    $('#login-form').submit((e) => {
        e.preventDefault();
        // Add .toLowerCase().trim() to standardize the input
        const username = $('#login-username').val().toLowerCase().trim();
        const password = $('#login-password').val();

        if (authService.login(username, password)) {
            $('#login-error').addClass('d-none');
            checkAuthAndRoute();
            uiService.showToast('Login successful!');
        } else {
            $('#login-error').removeClass('d-none');
        }
    });

    $('#signup-form').submit((e) => {
        e.preventDefault();
        // Remove .toLowerCase() here so it saves your exact capital letters!
        const u = $('#signup-username').val().trim();
        const p = $('#signup-password').val();
        const c = $('#signup-confirm').val();

        const errors = validationService.validateAuthForm(u, p, c);
        // ... rest of the code stays exactly the same
        uiService.showInlineErrors(errors);

        if (!errors) {
            const res = authService.signup(u, p);
            if (res.success) {
                uiService.showToast('Signup successful. Please login.');
                $('#signup-view').addClass('d-none');
                $('#login-view').removeClass('d-none');
            } else {
                $('#err-signup-username').text(res.message).closest('.mb-3').find('input').addClass('is-invalid');
            }
        }
    });

    $('#logout-btn').click(() => {
        authService.logout();
        checkAuthAndRoute();
        uiService.clearForm('login-form');
    });

    $('#link-to-signup').click((e) => { e.preventDefault(); $('#login-view').addClass('d-none'); $('#signup-view').removeClass('d-none'); });
    $('#link-to-login').click((e) => { e.preventDefault(); $('#signup-view').addClass('d-none'); $('#login-view').removeClass('d-none'); });

    // --- Navigation Events ---
    $('#nav-dashboard').click((e) => { e.preventDefault(); showView('dashboard'); });
    $('#nav-employees').click((e) => { e.preventDefault(); showView('employees'); });
    $('.navbar-brand').click((e) => { e.preventDefault(); showView('dashboard'); });

    // --- Table Filtering & Sorting Events ---
    $('#search-input').on('input', triggerFilterSortUpdate);
    $('#filter-dept').change(triggerFilterSortUpdate);
    $('input[name="statusFilter"]').change(triggerFilterSortUpdate);

    $('.sortable').click(function () {
        const field = $(this).data('sort');
        if (currentSort.field === field) {
            currentSort.direction = currentSort.direction === 'asc' ? 'desc' : 'asc';
        } else {
            currentSort.field = field;
            currentSort.direction = 'asc';
        }

        // Update UI icons
        $('.sortable i').removeClass('bi-arrow-up bi-arrow-down').addClass('bi-arrow-down-up text-muted');
        const icon = $(this).find('i');
        icon.removeClass('bi-arrow-down-up text-muted').addClass(currentSort.direction === 'asc' ? 'bi-arrow-up text-primary' : 'bi-arrow-down text-primary');

        triggerFilterSortUpdate();
    });

    // --- CRUD Events ---
    $('#nav-add-btn').click(() => uiService.showModal('add'));

    $('#save-employee-btn').click(() => {
        // Collect data
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

        // Validate
        const errors = validationService.validateEmployeeForm(data, isEdit, id ? parseInt(id) : null);
        uiService.showInlineErrors(errors);

        if (!errors) {
            if (isEdit) {
                employeeService.update(parseInt(id), data);
                uiService.showToast('Employee updated successfully');
            } else {
                employeeService.add(data);
                uiService.showToast('Employee added successfully');
            }
            uiService.closeModal('employeeModal');
            refreshAppContent(); // triggers UI re-renders
        }
    });

    // Event Delegation for action buttons (since table rows are dynamic)
    $('#employee-table-body').on('click', '.btn-view', function () {
        const id = $(this).data('id');
        uiService.showModal('view', employeeService.getById(id));
    });

    $('#employee-table-body').on('click', '.btn-edit', function () {
        const id = $(this).data('id');
        uiService.showModal('edit', employeeService.getById(id));
    });

    $('#employee-table-body').on('click', '.btn-delete', function () {
        const id = $(this).data('id');
        uiService.showModal('delete', employeeService.getById(id));
    });

    $('#confirm-delete-btn').click(function () {
        const id = $(this).data('id');
        employeeService.remove(id);
        uiService.closeModal('deleteModal');
        uiService.showToast('Employee deleted successfully', 'danger');
        refreshAppContent();
    });

    // --- Boot App ---
    checkAuthAndRoute();
});

// Fix for the aria-hidden accessibility warning on all modals
document.querySelectorAll('.modal').forEach(modal => {
    modal.addEventListener('hide.bs.modal', function () {
        if (document.activeElement) {
            document.activeElement.blur(); // This removes the focus from the clicked button
        }
    });
});

/* =========================================
   MOBILE NAVBAR AUTO-CLOSE & SCROLL-CLOSE
   ========================================= */
$(document).ready(function () {
    // 1. Close when clicking a navigation link or button
    $('#nav-dashboard, #nav-employees, #nav-add-btn').on('click', function () {
        const mobileMenu = document.getElementById('navbarNav');
        if (mobileMenu && mobileMenu.classList.contains('show')) {
            const bsCollapse = bootstrap.Collapse.getInstance(mobileMenu);
            if (bsCollapse) {
                bsCollapse.hide();
            }
        }
    });

    // 2. Close automatically when the user physically swipes or uses a mouse wheel
    $(window).on('touchmove wheel', function () {
        const mobileMenu = document.getElementById('navbarNav');
        if (mobileMenu && mobileMenu.classList.contains('show')) {
            const bsCollapse = bootstrap.Collapse.getInstance(mobileMenu);
            if (bsCollapse) {
                bsCollapse.hide();
            }
        }
    });

    // 3. NEW: Close when clicking ANYWHERE outside the open menu
    $(document).on('click', function (event) {
        const mobileMenu = document.getElementById('navbarNav');
        // If the click was NOT inside the navbar itself...
        if (!$(event.target).closest('.navbar').length) {
            // ...and the menu is currently open...
            if (mobileMenu && mobileMenu.classList.contains('show')) {
                // ...slide it shut!
                const bsCollapse = bootstrap.Collapse.getInstance(mobileMenu);
                if (bsCollapse) {
                    bsCollapse.hide();
                }
            }
        }
    });
});


/* =========================================
   PASSWORD VISIBILITY TOGGLES
   ========================================= */
$(document).ready(function() {
    // Login Password Toggle
    $(document).on('click', '#toggleLoginPassword', function() {
        const passwordInput = $('#login-password');
        
        if (passwordInput.attr('type') === 'password') {
            passwordInput.attr('type', 'text'); // Show
            $(this).removeClass('bi-eye-slash text-muted').addClass('bi-eye text-primary');
        } else {
            passwordInput.attr('type', 'password'); // Hide
            $(this).removeClass('bi-eye text-primary').addClass('bi-eye-slash text-muted');
        }
    });

    // Signup Passwords Toggle (If you added them to the signup page too)
    $(document).on('click', '.toggle-signup-pwd', function() {
        // Find the input field right next to the clicked icon
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