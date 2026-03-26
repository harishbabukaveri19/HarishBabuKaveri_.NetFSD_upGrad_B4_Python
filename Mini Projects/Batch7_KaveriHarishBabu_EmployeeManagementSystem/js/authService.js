// authService.js - Handles user authentication, session management, and related logic
const authService = {
    login: (username, password) => {
        const admins = storageService.getAdmins();

        // Convert both to lowercase just for the check, so HarishBabu matches harishbabu
        const foundAdmin = admins.find(a => a.username.toLowerCase() === username.toLowerCase() && a.password === password);

        if (foundAdmin) {
            sessionStorage.setItem('isAuth', 'true');
            // Save the exact, original casing to the session so the UI can display it!
            sessionStorage.setItem('currentUser', foundAdmin.username);
            return true;
        }
        return false;
    },

    signup: (username, password) => {
        const admins = storageService.getAdmins();

        // Check for duplicates ignoring case
        const exists = admins.some(a => a.username.toLowerCase() === username.toLowerCase());

        if (exists) {
            return { success: false, message: 'Username already exists.' };
        }

        // Save the exact casing the user typed
        storageService.addAdmin(username, password);
        return { success: true };
    },
    logout: () => {
        sessionStorage.removeItem('isAuth');
        sessionStorage.removeItem('username');
    },
    isLoggedIn: () => sessionStorage.getItem('isAuth') === 'true',
    getCurrentUser: () => {
        // Make sure it matches the exact key we saved during login!
        return sessionStorage.getItem('currentUser'); 
    },
};

if (typeof module !== 'undefined') module.exports = authService;