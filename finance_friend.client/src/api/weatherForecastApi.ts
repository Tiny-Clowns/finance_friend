export async function populateWeatherData() {
  const response = await fetch('weatherforecast');
  return (await response.json()) as Forecast[];
}

export interface Forecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
