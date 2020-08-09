import React, { Component } from "react";
import { Table, Button } from "reactstrap";
import RegistrationModal from "./form/RegistrationModal";
import { USERS_API_URL } from "../constants";
import { authHeader } from "../helpers/authHeader";

class DataTable extends Component {
  deleteItem = (id) => {
    let confirmDeletion = window.confirm("Do you really wish to delete it?");
    if (confirmDeletion) {
      const requestOptions = {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
          Authorization: authHeader(),
        },
      };

      fetch(`${USERS_API_URL}/${id}`, requestOptions)
        .then((res) => {
          this.props.deleteItemFromState(id);
        })
        .catch((err) => console.log(err));
    }
  };

  render() {
    const items = this.props.items;
    const isAuth = this.props.authData ? true : false;
    return (
      <Table striped responsive> 
        <thead className="thead-dark">
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Document</th>
            <th>Phone</th>
            <th style={{ textAlign: "center" }}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {!items || items.length <= 0 ? (
            <tr>
              <td colSpan="6" align="center">
                <b>No Users yet</b>
              </td>
            </tr>
          ) : (
            items.map((item) => (
              <tr key={item.id}>
                <td>{item.name}</td>
                <td>{item.email}</td>
                <td>{item.document}</td>
                <td>{item.phone}</td>
                <td align="center">
                  <div>
                    <RegistrationModal
                      isNew={false}
                      user={item}
                      updateUserIntoState={this.props.updateState}
                      authData={this.props.authData}
                    />
                    &nbsp;&nbsp;&nbsp;
                    {isAuth ? (
                      <Button
                        color="danger"
                        onClick={() => this.deleteItem(item.id)}
                      >
                        Delete
                      </Button>
                    ) : (
                      <div></div>
                    )}
                  </div>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </Table>
    );
  }
}

export default DataTable;
