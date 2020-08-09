import React, { Fragment } from "react";
import {
  Button,
  Form,
  FormGroup,
  Input,
  Label,
  Col,
  Container,
  Row,
} from "reactstrap";

import { authenticationService } from "../../services/authService";
import AppHeader from "../AppHeader";

class LoginPage extends React.Component {
  state = {
    email: "",
    username: "",
    password: "",
  };

  onChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitLogin = (e) => {
    e.preventDefault();

    authenticationService
      .login(this.state.email, this.state.password)
      .then((authData) => {
        const { from } = this.props.location.state || {
          from: { pathname: "/" },
        };
        this.props.history.push(from);
      });
  };

  submitRegister = (e) => {
    e.preventDefault();

    authenticationService
      .register(this.state.email, this.state.username, this.state.password)
      .then((authData) => {
        const { from } = this.props.location.state || {
          from: { pathname: "/" },
        };
        this.props.history.push(from);
      });
  };

  render() {
    const isNew = this.props.isNew;
    let UserName = "";
    let title = "Login Page";
    if (isNew) {
      title = "Register Page";
      UserName = (
        <FormGroup>
          <Label for="username">UserName:</Label>
          <Input
            type="text"
            name="username"
            onChange={this.onChange}
            value={this.state.username === "" ? "" : this.state.username}
          />
        </FormGroup>
      );
    }

    return (
      <Fragment>
        <AppHeader authData={this.props.authData} />
        <Container style={{ paddingTop: "100px" }}>
          <Row>
            <Col>
              <h3>{title}</h3>
            </Col>
          </Row>
          &nbsp;&nbsp;&nbsp;
          <Row>
            <Form onSubmit={isNew ? this.submitRegister : this.submitLogin}>
              <FormGroup>
                <Label for="email">Email:</Label>
                <Input
                  type="email"
                  name="email"
                  onChange={this.onChange}
                  value={this.state.email === "" ? "" : this.state.email}
                />
              </FormGroup>
              {UserName}
              <FormGroup>
                <Label for="password">Password:</Label>
                <Input
                  type="password"
                  name="password"
                  onChange={this.onChange}
                  value={
                    this.state.password === null ? "" : this.state.password
                  }
                />
              </FormGroup>
              <Button>Send</Button>
            </Form>
          </Row>
        </Container>
      </Fragment>
    );
  }
}

export default LoginPage;
