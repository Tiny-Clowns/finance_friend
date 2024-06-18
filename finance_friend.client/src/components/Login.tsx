import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { login } from '../redux/actions';
import './Login.css';

const Login: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleUsernameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(e.target.value);
    };

    const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(e.target.value);
    };

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            // Dispatch login action
            await dispatch(login(username, password));

            // If login successful, you can redirect or update state accordingly
            console.log('Login successful! Redirecting...'); // Example log

        } catch (error) {
            console.error('Login error:', error.message);
            // Handle login error (show error message, clear form, etc.)
        }
    };


    const handleRegister = () => {
        // Handle navigation to register page or modal
        console.log('Navigate to register page');
        navigate('/register');
    };

    return (
        <div className="login-container">
            <div className="login-form">
                <h2>Login</h2>
                <form onSubmit={handleLogin}>
                    <input type="text" name="username" placeholder="Username" value={username} onChange={handleUsernameChange} required />
                    <input type="password" name="password" placeholder="Password" value={password} onChange={handlePasswordChange} required />
                    <button type="submit" className="green-button">Login</button>
                </form>
                <div className="button-gap"></div>
                <button className="red-button" onClick={handleRegister}>Register</button>
            </div>
        </div>
    );
};

export default Login;