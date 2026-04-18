/** @jest-environment jsdom */
const dashboardService = require('../js/dashboardService');

// Mock the global storageService dependency since we don't have the real DB here
global.storageService = {
    getDashboardSummary: jest.fn()
};

describe('Dashboard Service', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should call storageService.getDashboardSummary and return data', async () => {
        // Arrange: Fake the response from the .NET API
        const fakeSummary = { total: 10, active: 8, inactive: 2, departments: 3 };
        global.storageService.getDashboardSummary.mockResolvedValue(fakeSummary);

        // Act
        const result = await dashboardService.getSummary();

        // Assert
        expect(global.storageService.getDashboardSummary).toHaveBeenCalledTimes(1);
        expect(result).toEqual(fakeSummary);
    });
});