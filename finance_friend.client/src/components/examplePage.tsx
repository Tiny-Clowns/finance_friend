import { Box, Divider, Stack, Typography } from '@mui/material';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { useEffect, useMemo } from 'react';
import { refresh } from '../redux/forecastSlice';
import { populateWeatherData } from '../api/weatherForecastApi';
import { useAppDispatch, useAppSelector } from '../redux/hooks';

import reactSvg from '../assets/react.svg';
import viteSvg from '../assets/vite.svg';

export default function ExamplePage() {
  const forecasts = useAppSelector((state) => state.forecast);
  const dispatch = useAppDispatch();

  useEffect(() => {
    void (async () => {
      dispatch(refresh(await populateWeatherData()));
    })();
  }, [dispatch]);

  const columns: GridColDef[] = useMemo(() => {
    return [
      {
        field: 'date',
        headerName: 'Date',
        type: 'string',
        width: 150,
      },
      {
        field: 'temperatureC',
        headerName: 'Temperature C',
        type: 'number',
        width: 150,
      },
      {
        field: 'temperatureF',
        headerName: 'Temperature F',
        type: 'number',
        width: 150,
      },
      {
        field: 'summary',
        headerName: 'Summary',
        type: 'string',
        width: 150,
      },
    ];
  }, []);

  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100vh',
        width: '100%',
      }}
    >
      <Stack
        spacing={2}
        sx={{
          alignItems: 'center',
        }}
      >
        <Box sx={{ display: 'flex', flexDirection: 'row' }}>
          <img src={reactSvg} height={'100px'} width={'100px'} />
          <Divider orientation="vertical" flexItem sx={{ my: 3, mx: 5 }} />
          <img src={viteSvg} height={'100px'} width={'100px'} />
        </Box>
        <Typography variant="h1">Weather forecast</Typography>
        <Typography variant="body1">
          This component demonstrates fetching data from the server.
        </Typography>
        <DataGrid
          rows={forecasts}
          columns={columns}
          getRowId={(row) => row.date}
          loading={!forecasts}
        />
      </Stack>
    </Box>
  );
}
