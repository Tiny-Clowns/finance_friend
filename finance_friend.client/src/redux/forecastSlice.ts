import { createSlice } from '@reduxjs/toolkit';
import { Forecast } from '../api/weatherForecastApi';

const initialState: Forecast[] = [];

const forecastSlice = createSlice({
  name: 'forecast',
  initialState,
  reducers: {
    refresh: (state, action) => {
      return action.payload;
    },
  },
});

export const { refresh } = forecastSlice.actions;
export default forecastSlice.reducer;
