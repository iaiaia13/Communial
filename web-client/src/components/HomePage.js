import React, { Component, Fragment } from "react";
import { Col, Container, Row } from "reactstrap";

import DataTable from "./DataTable";
import RegistrationModal from "./form/RegistrationModal";
import { USERS_API_URL, GET_IMAGES } from "../constants";
import AppHeader from "../components/AppHeader";
import { authenticationService } from "../services/authService";

class HomePage extends Component {
  state = {
    items: [],
    authData:{},
    imgdata: String
  };

  componentDidMount() {
    this.getItens();
    this.setState({
      authData: JSON.parse(localStorage.getItem("authData")),
    });
    this.getImages();
  }

  getItens = () => {
    fetch(`${USERS_API_URL}`)
      .then((res) => res.json())
      .then((items) => this.setState({ items: items }))
      .catch((err) => console.log(err));
  };

  addUserToState = (user) => {
    this.setState((previous) => ({
      items: [...previous.items, user],
    }));
  };

  updateState = (id) => {
    this.getItens();
  };

  deleteItemFromState = (id) => {
    const updated = this.state.items.filter((item) => item.id !== id);
    this.setState({ items: updated });
  };

  getImages = () => {

    fetch(GET_IMAGES)
      .then((res) => res.json())
      .then((res) => {
        this.setState({ imgdata: res })})
      .catch((err) => console.log(err)  );
  };

  render() {
    return (
      <Fragment>
        <AppHeader authData={this.state.authData} logout={this.props.logout}/>

        <Container style={{ paddingTop: "100px" }}>
          <Row>
            <Col>
              <h3>My First React + ASP.NET CRUD React</h3>
            </Col>
          </Row>
          &nbsp;&nbsp;&nbsp;
          <Row>
            <Col>
              <RegistrationModal
                isNew={true}
                addUserToState={this.addUserToState}
                authData={this.state.authData}
              />
            </Col>
          </Row>
          &nbsp;&nbsp;&nbsp;
          <Row style={{ overflowY: "scroll", height: "500px" }}>
          <img src={`data:image/jpeg;base64,${this.state.imgdata}`} alt='QR code'></img> 

            {/* <Col>
              <DataTable
                items={this.state.items}
                updateState={this.updateState}
                deleteItemFromState={this.deleteItemFromState}
                authData={this.state.authData}
              />
            </Col> */}
          </Row>
        </Container>
      </Fragment>
    );
  }
}

export default HomePage;
