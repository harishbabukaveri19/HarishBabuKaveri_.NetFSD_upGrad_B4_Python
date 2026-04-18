const employeeService = require('../js/employeeService');

// Mock the global storageService dependency
global.storageService = {
    getEmployees: jest.fn(),
    getById: jest.fn(),
    add: jest.fn(),
    update: jest.fn(),
    remove: jest.fn()
};

describe('Employee Service', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('getEmployees() should pass all parameters to storageService', async () => {
        // Arrange
        const fakeResult = { data: [], totalCount: 0 };
        global.storageService.getEmployees.mockResolvedValue(fakeResult);

        // Act
        const result = await employeeService.getEmployees('John', 'HR', 'Active', 'name', 'desc', 2, 15);

        // Assert
        expect(global.storageService.getEmployees).toHaveBeenCalledWith('John', 'HR', 'Active', 'name', 'desc', 2, 15);
        expect(result).toEqual(fakeResult);
    });

    it('getById() should call storageService with correct ID', async () => {
        global.storageService.getById.mockResolvedValue({ id: 5, name: "Test" });
        
        const result = await employeeService.getById(5);
        
        expect(global.storageService.getById).toHaveBeenCalledWith(5);
        expect(result.id).toBe(5);
    });

    it('add() should pass employee object to storageService', async () => {
        const newEmp = { firstName: "Jane", lastName: "Doe" };
        global.storageService.add.mockResolvedValue({ id: 1, ...newEmp });

        const result = await employeeService.add(newEmp);

        expect(global.storageService.add).toHaveBeenCalledWith(newEmp);
        expect(result.id).toBeDefined();
    });

    it('update() should pass ID and object to storageService', async () => {
        const empUpdate = { firstName: "Updated" };
        global.storageService.update.mockResolvedValue(true);

        await employeeService.update(10, empUpdate);

        expect(global.storageService.update).toHaveBeenCalledWith(10, empUpdate);
    });

    it('remove() should pass ID to storageService', async () => {
        global.storageService.remove.mockResolvedValue(true);

        const result = await employeeService.remove(99);

        expect(global.storageService.remove).toHaveBeenCalledWith(99);
        expect(result).toBe(true);
    });

    it('getUniqueDepartments() should return the hardcoded list of departments', () => {
        const depts = employeeService.getUniqueDepartments();
        
        expect(depts.length).toBe(5);
        expect(depts).toContain("Engineering");
        expect(depts).toContain("HR");
    });
});