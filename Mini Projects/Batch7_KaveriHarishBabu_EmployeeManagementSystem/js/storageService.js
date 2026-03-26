// storageService.js - Handles all interactions with localStorage for employee data and admin credentials
const storageService = {
    // 1. Helper function to sync current data to localStorage
    saveEmployees: () => {
        localStorage.setItem('ems_employees', JSON.stringify(appData.employees));
    },

    // 2. Helper function to load data when the app starts
    // 2. Helper function to load data when the app starts
    initEmployees: () => {
        const savedData = localStorage.getItem('ems_employees');
        if (savedData) {
            // If we have saved data, overwrite the default array with it
            appData.employees = JSON.parse(savedData);
        } else {
            // If it's the first time, save the default data.js list to localStorage
            storageService.saveEmployees();
        }

        // --- NEW: Instantly lock in the highest ID the second the app loads ---
        const highestInArray = appData.employees.length > 0 ? Math.max(...appData.employees.map(e => parseInt(e.id))) : 0;
        const savedMaxId = parseInt(localStorage.getItem('ems_absolute_max_id')) || 0;
        
        // If the array has a higher ID than the tracker (like on first load), update the tracker!
        if (highestInArray > savedMaxId) {
            localStorage.setItem('ems_absolute_max_id', highestInArray);
        }
    },

    getAll: () => [...appData.employees],
    getById: (id) => appData.employees.find(emp => emp.id === id),
    
    add: (employee) => {
        appData.employees.push(employee);
        storageService.saveEmployees(); // Save to local storage after adding
    },
    
    update: (id, updatedData) => {
        // 1. Find the exact row/index this employee is sitting at in appData
        const index = appData.employees.findIndex(emp => emp.id === id);
        
        // 2. If we found them, update their data in that EXACT same position
        if (index !== -1) {
            appData.employees[index] = { id: id, ...updatedData };
            storageService.saveEmployees(); // Sync the updated array to localStorage
        }
    },
    
    remove: (id) => {
        appData.employees = appData.employees.filter(emp => emp.id !== id);
        storageService.saveEmployees(); // Save to local storage after deleting
    },
    
    nextId: () => {
        // 1. Safely get the current list of employees
        const employees = storageService.getAll();
        
        // 2. Find the highest ID currently sitting in the array
        const highestInArray = employees.length > 0 ? Math.max(...employees.map(e => parseInt(e.id))) : 0;
        
        // 3. Get our permanent tracker from local storage (if it exists)
        const savedMaxId = parseInt(localStorage.getItem('ems_absolute_max_id')) || 0;
        
        // 4. The TRUE highest ID is whichever number is bigger
        const trueMax = Math.max(highestInArray, savedMaxId);
        
        // 5. Add 1 for the new employee
        const newId = trueMax + 1;
        
        // 6. Lock this new highest number into the permanent tracker
        localStorage.setItem('ems_absolute_max_id', newId);
        
        return newId;
    },
    
    // Admin methods remain exactly the same
    getAdmins: () => {
        const savedAdmins = localStorage.getItem('ems_admins');
        return savedAdmins ? JSON.parse(savedAdmins) : [appData.admin];
    },
    addAdmin: (username, password) => {
        const admins = storageService.getAdmins();
        admins.push({ username, password }); 
        localStorage.setItem('ems_admins', JSON.stringify(admins)); 
    }
};

// Initialize the employee data immediately when this file loads
storageService.initEmployees();

if (typeof module !== 'undefined') module.exports = storageService;