import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import './Register.css';


const Register = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        username: '',
        email: '',
        password: '',
    });

    const dispatch = useDispatch();

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleLogin = () => {
        console.log('Navigate to login page');
        navigate('/');
    };
    function passwordsMatch(): boolean {
        return (document.getElementById('password') as HTMLInputElement).value === (document.getElementById('confirm-password') as HTMLInputElement).value;
    }

    const handleSubmit = (e) => {
        e.preventDefault();


        if (passwordsMatch()) {
            console.log("equal password");
        }
        else {
            console.log("not equal password");
        }

        // Dispatch your register action here
        // dispatch(registerUser(formData));
        console.log(formData); // For now, just log the form data
    };

    return (
        <div className="register-container">
            <div className="register-form">
                <h2>Register</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="username"
                        placeholder="Username"
                        value={formData.username}
                        onChange={handleChange}
                        required
                    />
                    <input
                        type="email"
                        name="email"
                        placeholder="Email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                    <input
                        id="password"
                        type="password"
                        name="password"
                        placeholder="Password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                    <input
                        id="confirm-password"
                        type="password"
                        name="confirm-password"
                        placeholder="Confirm Password"
                        required
                    />
                    <button className="green-button" type="submit">Register</button>
                    <div className="button-gap"></div>
                    <button className="red-button" onClick={handleLogin}>Login</button>
                </form>
            </div>
        </div>
    );
};

export default Register;