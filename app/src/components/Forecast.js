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
					<p className="weather-data">{ el.main.temperature }</p>
					<p className="weather-data"> { el.state[0].description }</p>
					<img src={el.state[0].icon} className="weather-data_img" alt="Forecast"/>
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