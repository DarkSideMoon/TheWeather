import React from "react";

const Weather = props => (
	<div className="weather__info">
	 {	
	 	props.city && props.dateTime && <p className="weather__key"> Location: 
	 		<span className="weather__value"> { props.city }, { props.dateTime }</span>
	 	</p> 
	 }
	 { 	
	 	props.temperature && <p className="weather__key"> Temperature: 
	 		<span className="weather__value"> { props.temperature }	</span>
	 	</p> 
	 }
	 { 	
	 	props.humidity && <p className="weather__key"> Humidity: 
	 		<span className="weather__value"> { props.humidity } </span>
	 	</p> 
	 }
	 { 	
	 	props.pressure && <p className="weather__key"> Pressure: 
	 		<span className="weather__value"> { props.pressure } </span>
	 </p> 
	 }
	 { 	
	 	props.description && props.icon && <p className="weather__key"> Conditions: 
	 		<span className="weather__value"> { props.description } </span>
			 <img src={props.icon} alt="weather" />
	 </p> 
	 }
	 { 
	 	props.error && <p className="weather__error">{ props.error }</p>  
	 }
	</div>
);

export default Weather;