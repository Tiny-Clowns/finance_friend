import { createAsyncThunk } from '@reduxjs/toolkit';


export const registerUser = createAsyncThunk(
    'auth/register',
    async (userData, thunkAPI) => {
        try {
            const response = await fetch('/api/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userData),
            });
            const data = await response.json();
            if (response.ok) {
                return data;
            } else {
                return thunkAPI.rejectWithValue(data);
            }
        } catch (error) {
            return thunkAPI.rejectWithValue(error.message);
        }
    }
);