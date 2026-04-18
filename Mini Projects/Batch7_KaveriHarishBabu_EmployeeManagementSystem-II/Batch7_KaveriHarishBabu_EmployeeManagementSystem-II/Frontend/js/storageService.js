// js/storageService.js
const storageService = (() => {
    
    // Helper to attach JWT token to every API request
    const _headers = (withAuth = true) => {
        const headers = { "Content-Type": "application/json" };
        if (withAuth) {
            const token = authService.getToken();
            if (token) headers["Authorization"] = `Bearer ${token}`;
        }
        return headers;
    };

    const getEmployees = async (search, dept, status, sortBy, sortDir, page = 1, pageSize = PAGE_SIZE) => {
        // Build the query string dynamically
        const params = new URLSearchParams();
        if (search) params.append('search', search);
        if (dept) params.append('department', dept);
        if (status) params.append('status', status);
        if (sortBy) params.append('sortBy', sortBy);
        if (sortDir) params.append('sortDir', sortDir);
        params.append('page', page);
        params.append('pageSize', pageSize);

        const response = await fetch(`${API_BASE_URL}/employees?${params.toString()}`, {
            headers: _headers()
        });
        
        if (!response.ok) throw new Error("Failed to fetch employees");
        return await response.json(); // Returns the PagedResult DTO
    };

    const getById = async (id) => {
        const response = await fetch(`${API_BASE_URL}/employees/${id}`, { 
            headers: _headers() 
        });
        if (!response.ok) return null;
        return await response.json();
    };

    const add = async (employee) => {
        const response = await fetch(`${API_BASE_URL}/employees`, {
            method: 'POST',
            headers: _headers(),
            body: JSON.stringify(employee)
        });
        
        if (response.status === 409) {
            const error = await response.json();
            throw new Error(error.message); // e.g., "Email already exists"
        }
        if (!response.ok) throw new Error("Failed to add employee");
        
        return await response.json();
    };

    const update = async (id, employee) => {
        const response = await fetch(`${API_BASE_URL}/employees/${id}`, {
            method: 'PUT',
            headers: _headers(),
            body: JSON.stringify(employee)
        });

        if (response.status === 409) {
            const error = await response.json();
            throw new Error(error.message);
        }
        if (!response.ok) throw new Error("Failed to update employee");

        return await response.json();
    };

    const remove = async (id) => {
        const response = await fetch(`${API_BASE_URL}/employees/${id}`, {
            method: 'DELETE',
            headers: _headers()
        });
        return response.ok;
    };

    const getDashboardSummary = async () => {
        const response = await fetch(`${API_BASE_URL}/employees/dashboard`, { 
            headers: _headers() 
        });
        if (!response.ok) throw new Error("Failed to fetch dashboard summary");
        return await response.json();
    };

    return { getEmployees, getById, add, update, remove, getDashboardSummary };
})();

if (typeof module !== 'undefined') module.exports = storageService;