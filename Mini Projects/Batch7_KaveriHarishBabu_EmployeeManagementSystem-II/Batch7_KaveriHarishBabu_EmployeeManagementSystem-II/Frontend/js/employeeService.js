// js/employeeService.js
const employeeService = (() => {
    
    // We pass all the table state (search, sort, page) directly to the API
    const getEmployees = async (search, dept, status, sortBy, sortDir, page, pageSize) => {
        return await storageService.getEmployees(search, dept, status, sortBy, sortDir, page, pageSize);
    };

    const getById = async (id) => {
        return await storageService.getById(id);
    };

    const add = async (employee) => {
        return await storageService.add(employee);
    };

    const update = async (id, employee) => {
        return await storageService.update(id, employee);
    };

    const remove = async (id) => {
        return await storageService.remove(id);
    };

    // The API doesn't provide a unique departments endpoint, so we hardcode the known list 
    // for the dropdown, or you could extract this from a dedicated lookup API later.
    const getUniqueDepartments = () => {
        return ["Engineering", "Marketing", "HR", "Finance", "Operations"];
    };

    return { getEmployees, getById, add, update, remove, getUniqueDepartments };
})();

if (typeof module !== 'undefined') module.exports = employeeService;