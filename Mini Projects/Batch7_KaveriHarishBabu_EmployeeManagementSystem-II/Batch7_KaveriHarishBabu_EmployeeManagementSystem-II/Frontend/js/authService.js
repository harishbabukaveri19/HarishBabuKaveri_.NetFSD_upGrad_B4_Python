// js/authService.js
const authService = (() => {
    // SECURITY REQUIREMENT: Token stored in-memory only. Not in localStorage!
    let _session = null; 

    const login = async (username, password) => {
        try {
            const response = await fetch(`${API_BASE_URL}/auth/login`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username, password })
            });

            if (!response.ok) return false;

            const data = await response.json();
            if (data.success) {
                _session = {
                    username: data.username,
                    role: data.role,
                    token: data.token
                };
                return true;
            }
            return false;
        } catch (error) {
            console.error("Login failed due to network error:", error);
            return false;
        }
    };

    const signup = async (username, password) => {
        try {
            const response = await fetch(`${API_BASE_URL}/auth/register`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username, password })
            });

            // 409 Conflict handles our duplicate username checks
            if (response.status === 409) {
                const errorData = await response.json();
                return { success: false, message: errorData.message };
            }

            if (response.ok) {
                return { success: true };
            }

            return { success: false, message: "Registration failed." };
        } catch (error) {
            console.error("Signup failed due to network error:", error);
            return { success: false, message: "Network error occurred." };
        }
    };

    const logout = () => {
        _session = null; // Clears the token
        window.location.reload();
    };

    const isLoggedIn = () => _session !== null;
    const getCurrentUser = () => _session ? _session.username : null;
    const isAdmin = () => _session ? _session.role === 'Admin' : false;
    const getToken = () => _session ? _session.token : null;

    return { login, signup, logout, isLoggedIn, getCurrentUser, isAdmin, getToken };
})();

if (typeof module !== 'undefined') module.exports = authService;