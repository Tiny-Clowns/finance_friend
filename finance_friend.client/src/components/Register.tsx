// src/Register.js
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import './Register.css';
// import your action creator to handle form submission if needed
//import { registerUser } from '../actions/authActions';

const Register = () => {
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

    const handleSubmit = (e) => {
        e.preventDefault();
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
                        type="password"
                        name="password"
                        placeholder="Password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                    <button type="submit" className="register-button">Register</button>
                </form>
            </div>
        </div>
    );
};

export default Register;