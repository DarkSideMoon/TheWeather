import React from "react";

import Titles from "./components/Titles";
import Form from "./components/Form";
import Weather from "./components/Weather";
import Forecast from "./components/Forecast";

class App extends React.Component {
  state = {
    city: undefined,
    visibility: undefined,
    dateTime: undefined,
    temp: undefined,
    pressure: undefined,
    humidity: undefined,
    description: undefined,
    icon: undefined,

    forecastList: undefined,


    error: undefined
  }
  
  getWeather = async (e) => {
    e.preventDefault();
    const city = e.target.elements.city.value;
    const language = e.target.elements.language.value;
    const unit = e.target.elements.unit.value;
    const api = "http://localhost:80"

    const apiCallForecast = await fetch(`${api}/Forecast?city=${city}&language=${language}&unit=${unit}`);    
    const dataForecast = await apiCallForecast.json();

    const apiCallWeather = await fetch(`${api}/Weather?city=${city}&language=${language}&unit=${unit}`);    
    const data = await apiCallWeather.json();

    if (apiCallWeather.status === 200) {
      this.setState({
        city: data.name,
        visibility: data.visibility,
        dateTime: data.dateTime,
        temp: data.main.temperature,
        pressure: data.main.pressure,
        humidity: data.main.humidity,
        description: data.state[0].description,
        icon: data.state[0].icon,
        forecastList: dataForecast,
        error: ""
      });
    } else {
      if(city === '' && language === '' && unit === '') {
        this.setState({
          city: undefined,
          visibility: undefined,
          dateTime: undefined,
          temp: undefined,
          pressure: undefined,
          humidity: undefined,
          description: undefined,
          icon: undefined,
          forecastList: undefined,
          error: "Please enter the values."
        });
      }

      if (apiCallWeather.status === 404) {
        this.setState({
          city: undefined,
          visibility: undefined,
          dateTime: undefined,
          temp: undefined,
          pressure: undefined,
          humidity: undefined,
          description: undefined,
          icon: undefined,
          forecastList: undefined,
          error: `Weather for ${city} not found!`
        });
      }
    }
  }
  render() {
    return (
      <div>
        <div className="wrapper">
          <div className="main">
            <div className="">
              <div className="row">
                <div className="col-xs-4 title-container">
                  <Titles />
                </div>
                <div className="col-xs-8 form-container">
                  <Form getWeather={this.getWeather} />
                  
                  <div className="col-xs-6">
                    <Weather
                      temperature={this.state.temp} 
                      humidity={this.state.humidity}
                      city={this.state.city}
                      dateTime={this.state.dateTime}
                      description={this.state.description}
                      error={this.state.error}
                      pressure={this.state.pressure}
                      icon={this.state.icon}
                    />
                  </div>
                  <div className="col-xs-6">
                    <Forecast
                      forecastList = { this.state.forecastList }
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
};

export default App;