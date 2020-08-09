import React, { Component, Fragment } from "react";
import { Button, Modal, ModalHeader, ModalBody } from "reactstrap";
import RegistrationForm from "./RegistrationForm";

class RegistrationModal extends Component {
  state = {
    modal: false,
  };

  toggle = () => {
    this.setState((previous) => ({
      modal: !previous.modal,
    }));
  };

  render() {
    const isNew = this.props.isNew;
    const isAuth = this.props.authData ? true : false;

    let title = "Edit User";
    let button = "";

    if (isAuth) {
      if (isNew) {
        title = "Add User";
        button = (
          <Button
            color="success"
            onClick={this.toggle}
            style={{ minWidth: "200px" }}
          >
            Add
          </Button>
        );
      } else {
        button = (
          <Button color="warning" onClick={this.toggle}>
            Edit
          </Button>
        );
      }
    }

    return (
      <Fragment>
        {button}
        <Modal
          isOpen={this.state.modal}
          toggle={this.toggle}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle}>{title}</ModalHeader>
          <ModalBody>
            <RegistrationForm
              addUserToState={this.props.addUserToState}
              updateUserIntoState={this.props.updateUserIntoState}
              toggle={this.toggle}
              user={this.props.user}
            />
          </ModalBody>
        </Modal>
      </Fragment>
    );
  }
}

export default RegistrationModal;
