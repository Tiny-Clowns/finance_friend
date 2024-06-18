export const login = (username: string, password: string) => {
    return async (dispatch: any) => {
        // Example API call using fetch
        try {
            const response = await fetch('your-api-endpoint/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) {
                throw new Error('Login failed');
            }

            // Example handling of response data
            const data = await response.json();

            // Example dispatching of success action
            dispatch({ type: 'LOGIN_SUCCESS', payload: data });

        } catch (error) {
            console.error('Login error:', error.message);
            // Example dispatching of failure action
            dispatch({ type: 'LOGIN_FAILURE', error: error.message });
            throw error;
        }
    };
};
export const logout = () => ({ type: 'LOGOUT' } as const);