import React from "react";

const Form = props => (
	<form onSubmit={props.getWeather}>
		<input type="text" name="city" placeholder="City..."/>
		<input type="text" name="language" placeholder="Language..."/>
		<input type="text" name="unit" placeholder="Unit..."/>
		<button>Get Weather</button>
	</form>
);

export default Form;