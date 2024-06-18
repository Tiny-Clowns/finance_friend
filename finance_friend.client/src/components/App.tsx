import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './Login';
import Register from './Register'; 
import { Provider } from 'react-redux';
import store from '../redux/store';

const App: React.FC = () => {
    return (
        <Provider store={store}>
            <Router>
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    {/* Add other routes as needed */}
                </Routes>
            </Router>
        </Provider>
    );
};

export default App;