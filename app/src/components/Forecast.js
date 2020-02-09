import React from "react";
let data;

const Forecast = props => {
	if (!props.forecastList){
		return null;
	} else {
		 data = props.forecastList.map((el) => {
			if (!el){
				return null
			} else {
			return(
				<div className="weather-container">
					<p className="weather-data weather-data-day" >{ el.dayOfWeek}</p>
					<p className="weather-data">{ el.main.temp }</p>
					<p className="weather-data"> { el.weather[0].description }</p>
					<img src={el.weather[0].icon} className="weather-data_img" alt="Forecast"/>
				</div>	
			);
			}
		});
	};
	

return (
	<div className="weather__info">
		{ data }
	</div>
);
	}

export default Forecast;