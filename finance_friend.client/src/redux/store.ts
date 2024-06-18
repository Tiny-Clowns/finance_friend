import { createStore } from 'redux';

// Define the state type
interface AuthState {
    isLoggedIn: boolean;
}

// Define the initial state
const initialState: AuthState = {
    isLoggedIn: false
};

// Define action types
const LOGIN = 'LOGIN';
const LOGOUT = 'LOGOUT';

interface LoginAction {
    type: typeof LOGIN;
}

interface LogoutAction {
    type: typeof LOGOUT;
}

type AuthActionTypes = LoginAction | LogoutAction;

// Reducer
function authReducer(state = initialState, action: AuthActionTypes): AuthState {
    switch (action.type) {
        case LOGIN:
            return { ...state, isLoggedIn: true };
        case LOGOUT:
            return { ...state, isLoggedIn: false };
        default:
            return state;
    }
}

// Create store
const store = createStore(authReducer);

export default store;