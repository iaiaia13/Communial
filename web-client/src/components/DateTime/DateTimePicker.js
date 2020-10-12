import React from "react";
import DateTime from 'react-datetime';
import "react-datetime/css/react-datetime.css";

const DateTimePicker = (props) => {
    return (
            <DateTime
                // className="form-control col-6"
                //placeholder="From..."
                name={props.name}
                ref={props.register}
            />
    )
}

export default DateTimePicker;
