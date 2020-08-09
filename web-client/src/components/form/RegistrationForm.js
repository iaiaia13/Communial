import React from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { USERS_API_URL } from "../../constants";
import { authHeader } from "../../helpers/authHeader";

class RegistrationForm extends React.Component {
  state = {
    id: 0,
    name: "",
    document: "",
    email: "",
    phone: "",
  };

  componentDidMount() {
    if (this.props.user) {
      const { id, name, document, email, phone } = this.props.user;
      this.setState({ id, name, document, email, phone });
    }
  }

  onChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitNew = (e) => {
    e.preventDefault();
    const requestOptions = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": authHeader(),
      },
      body: JSON.stringify({
        name: this.state.name,
        document: this.state.document,
        email: this.state.email,
        phone: this.state.phone,
      }),
    };
    fetch(`${USERS_API_URL}`, requestOptions)
      .then((res) => res.json())
      .then((user) => {
        this.props.addUserToState(user);
        this.props.toggle();
      })
      .catch((err) => console.log(err));
  };

  submitEdit = (e) => {
    const requestOptions = {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        "Authorization": authHeader(),
      },
      body: JSON.stringify({
        name: this.state.name,
        document: this.state.document,
        email: this.state.email,
        phone: this.state.phone,
      }),
    };
    e.preventDefault();
    fetch(`${USERS_API_URL}/${this.state.id}`, requestOptions)
      .then(() => {
        this.props.toggle();
        this.props.updateUserIntoState(this.state.id);
      })
      .catch((err) => console.log(err));
  };

  render() {
    return (
      <Form onSubmit={this.props.user ? this.submitEdit : this.submitNew}>
        <FormGroup>
          <Label for="name">Name:</Label>
          <Input
            type="text"
            name="name"
            onChange={this.onChange}
            value={this.state.name === "" ? "" : this.state.name}
          />
        </FormGroup>
        <FormGroup>
          <Label for="document">Document:</Label>
          <Input
            type="text"
            name="document"
            onChange={this.onChange}
            value={this.state.document === null ? "" : this.state.document}
          />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email:</Label>
          <Input
            type="email"
            name="email"
            onChange={this.onChange}
            value={this.state.email === null ? "" : this.state.email}
          />
        </FormGroup>
        <FormGroup>
          <Label for="phone">Phone:</Label>
          <Input
            type="text"
            name="phone"
            onChange={this.onChange}
            value={this.state.phone === null ? "" : this.state.phone}
            placeholder="+1 999-999-9999"
          />
        </FormGroup>
        <Button>Send</Button>
      </Form>
    );
  }
}

export default RegistrationForm;
