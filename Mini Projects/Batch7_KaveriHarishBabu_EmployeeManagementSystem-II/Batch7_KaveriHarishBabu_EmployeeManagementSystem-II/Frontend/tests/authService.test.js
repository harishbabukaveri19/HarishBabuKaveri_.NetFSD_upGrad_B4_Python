const authService = require('../js/authService'); // Adjust path if necessary

// Mock global variables used by the service
global.API_BASE_URL = 'https://localhost:7176/api';
global.fetch = jest.fn();

describe('Auth Service', () => {
    beforeEach(() => {
        // Clear mocks and reset session before every test
        jest.clearAllMocks();
        authService.logout();
    });

    describe('login()', () => {
        it('should return true and set session on successful login', async () => {
            // Arrange: Fake a successful API response
            const mockResponse = { success: true, username: 'admin', role: 'Admin', token: 'fake-jwt-token' };
            global.fetch.mockResolvedValue({
                ok: true,
                json: jest.fn().mockResolvedValue(mockResponse)
            });

            // Act
            const result = await authService.login('admin', 'password123');

            // Assert
            expect(result).toBe(true);
            expect(authService.isLoggedIn()).toBe(true);
            expect(authService.getCurrentUser()).toBe('admin');
            expect(authService.isAdmin()).toBe(true);
            expect(authService.getToken()).toBe('fake-jwt-token');
        });

        it('should return false on failed login', async () => {
            // Arrange: Fake a 401 Unauthorized
            global.fetch.mockResolvedValue({ ok: false });

            // Act
            const result = await authService.login('wrong', 'pass');

            // Assert
            expect(result).toBe(false);
            expect(authService.isLoggedIn()).toBe(false);
        });
    });

    describe('signup()', () => {
        it('should return success on valid signup', async () => {
            global.fetch.mockResolvedValue({ ok: true, status: 200 });

            const result = await authService.signup('newuser', 'pass123');
            expect(result.success).toBe(true);
        });

        it('should return conflict message on 409 status', async () => {
            global.fetch.mockResolvedValue({
                ok: false,
                status: 409,
                json: jest.fn().mockResolvedValue({ message: "Username already exists" })
            });

            const result = await authService.signup('existing', 'pass');
            expect(result.success).toBe(false);
            expect(result.message).toBe("Username already exists");
        });
    });

    describe('logout()', () => {
        it('should clear the session', async () => {
            // Login first to set session
            global.fetch.mockResolvedValue({ ok: true, json: jest.fn().mockResolvedValue({ success: true }) });
            await authService.login('user', 'pass');
            
            // Now logout
            authService.logout();

            expect(authService.isLoggedIn()).toBe(false);
            expect(authService.getCurrentUser()).toBeNull();
            expect(authService.getToken()).toBeNull();
        });
    });
});