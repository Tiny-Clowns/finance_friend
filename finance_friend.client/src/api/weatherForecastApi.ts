export async function populateWeatherData() {
  const response = await fetch('api/weatherforecast');
  if (response.ok) {
    return (await response.json()) as Forecast[];
  }
  return [] as Forecast[];
}

export interface Forecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
