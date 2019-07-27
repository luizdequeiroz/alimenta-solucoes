import React, { Component } from 'react';
import { Popover } from 'reactstrap';

class Input extends Component {

    render() {

        const { input, type, placeholder, meta: { touched, error, warning }, list } = this.props;
        const inputProps = { type, placeholder, list };

        input.id = input.name;

        const theInput = type === "textarea" ? <textarea className="form-control" {...input} {...inputProps}></textarea> : <input className="form-control" {...input} {...inputProps} />;

        return (
            <div className="form-group">
                {theInput}
                {<Popover placement="right" target={input.id} isOpen={touched && error}>
                    <div style={{ padding: 10 }}>
                        <span className="h6 text-danger">{error || warning}</span>
                    </div>
                </Popover>}
            </div>
        );
    }
}

export default Input;