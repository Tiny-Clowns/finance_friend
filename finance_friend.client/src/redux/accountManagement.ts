export const LOGIN = 'LOGIN';
export const LOGOUT = 'LOGOUT';
export const REGISTER = 'REGISTER';

export const login = (username, password) => ({
    type: LOGIN,
    payload: { username, password },
});

export const logout = () => ({
    type: LOGOUT,
});

export const register = (username, password) => ({
    type: REGISTER,
    payload: { username, password },
});