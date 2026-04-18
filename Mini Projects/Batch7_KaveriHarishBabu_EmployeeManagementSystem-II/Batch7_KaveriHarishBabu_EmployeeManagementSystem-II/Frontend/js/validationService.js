// validationService.js - Contains all validation logic for forms, including employee data and authentication
const validationService = {
    validateEmployeeForm: (data, isEdit, currentId) => {
        const errors = {};
        
        if (!data.firstName.trim()) errors.firstName = "First Name is required";
        if (!data.lastName.trim()) errors.lastName = "Last Name is required";
        
        // Email validation (Duplicate check removed because the .NET API handles it now!)
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!data.email.trim()) {
            errors.email = "Email is required";
        } else if (!emailRegex.test(data.email)) {
            errors.email = "Invalid Email format";
        }

        if (!data.phone.trim()) {
            errors.phone = "Phone Number is required";
        } else if (!/^\d{10}$/.test(data.phone)) {
            errors.phone = "Must be a 10-digit number";
        }

        if (!data.department) errors.department = "Select a Department";
        if (!data.designation.trim()) errors.designation = "Designation is required";
        
        if (!data.salary) {
            errors.salary = "Salary is required";
        } else if (Number(data.salary) <= 0) {
            errors.salary = "Must be a positive number";
        }

        // --- Join Date Validation ---
        if (!data.joinDate) {
            errors.joinDate = "Join Date is required";
        } else {
            const selectedDate = new Date(data.joinDate);
            const today = new Date();
            // Reset the time on 'today' so we only compare the calendar days
            today.setHours(24, 0, 0, 0); 

            if (selectedDate > today) {
                errors.joinDate = "Please select a past or present date.";
            }
        }
        if (!data.gender) errors.gender = 'Please select a gender';
        if (!data.status) errors.status = "Select a Status";

        return Object.keys(errors).length > 0 ? errors : null;
    },
    
    validateAuthForm: (username, password, confirmPassword = null) => {
        const errors = {};
        if (!username.trim()) errors.username = "Username required";
        if (!password) errors.password = "Password required";
        else if (password.length < 6) errors.password = "Minimum 6 characters";
        
        if (confirmPassword !== null && password !== confirmPassword) {
            errors.confirm = "Passwords do not match";
        }
        return Object.keys(errors).length > 0 ? errors : null;
    },

    // PROPERLY ADDED INSIDE THE OBJECT
    mapServerErrors: (serverMessage) => {
        let errors = {};
        
        // If the server message mentions Email, trigger the email box
        if (serverMessage.includes("Email:")) {
            errors.email = "This email address is already exist.";
        }
        
        // If the server message mentions Phone, trigger the phone box
        if (serverMessage.includes("Phone:")) {
            errors.phone = "This phone number is already exist.";
        }

        return errors; // Returns both errors if both exist!
    }
};

if (typeof module !== 'undefined') module.exports = validationService;