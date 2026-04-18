// js/dashboardService.js
const dashboardService = (() => {
    // We just ask the server for the pre-calculated summary!
    const getSummary = async () => {
        return await storageService.getDashboardSummary();
    };

    return { getSummary };
})();

if (typeof module !== 'undefined') module.exports = dashboardService;