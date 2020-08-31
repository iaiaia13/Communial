import React, { Component } from "react";
import GGLogin from 'react-google-login';
import {
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Collapse,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from "reactstrap";
import {GOOGLE_AUTH_CALLBACK_URL} from "../constants/index";

class AppHeader extends Component {
  state = {
    isOpen: false,
  };

  toggle = this.toggle.bind(this);
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen,
    });
  }

  render() {
    const responseGoogle = (response) => {
      console.log(response);
      if (!response.tokenId) {
        console.error("Unable to get tokenId from Google", response)
        return;
      }
      const tokenBlob = new Blob([JSON.stringify({ token: response.tokenId }, null, 2)], { type: 'application/json' });
      const options = {
        method: 'POST',
        body: tokenBlob,
        cache: 'default'
      };
      fetch(GOOGLE_AUTH_CALLBACK_URL, options)
        .then(r => {
          r.json().then(user => {
            localStorage.setItem("authData", JSON.stringify(user));

            const pathname = "/";
            this.props.history.push(pathname);
          });
        })
  }

    const isAuth = this.props.authData == null ? false : true;
    let loglink = "";
    let regLink = "";
    let name = "";
    if (!isAuth) {
      loglink = <DropdownItem href="/login">Login</DropdownItem>;
      regLink = <DropdownItem href="/register">Register</DropdownItem>;
      name = "Options";
    } else {
      loglink = <DropdownItem onClick={this.props.logout}>Logout</DropdownItem>;
      name = this.props.authData.id;
    }

    return (
      <Navbar color="dark" dark expand="md" fixed="top">
        <NavbarBrand href="/">
          <img
            src="https://cdn.rd.gt/assets/images/global/redgate-logo--white.svg?v=1"
            width="128"
            className="d-inline-block align-top"
            alt=""
          />
        </NavbarBrand>
        <NavbarToggler onClick={this.toggle} />
        <Collapse isOpen={this.state.isOpen} navbar>
          <Nav className="ml-auto" navbar>
            <NavItem>
              <NavLink href="/">Home</NavLink>
            </NavItem>
            <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret>
                {name}
              </DropdownToggle>
              <DropdownMenu right>
                {loglink} {regLink}
              </DropdownMenu>
              {isAuth === false ?
                (<GGLogin
                  clientId="228526429111-pt7cu7oe0aa1n6egc1f3pu9ihebbughj.apps.googleusercontent.com"
                  buttonText="Continue with Google"
                  onSuccess={responseGoogle}
                  onFailure={responseGoogle}
                  cookiePolicy={'single_host_origin'}
                />) : (
                  <div></div>
                )
              }
            </UncontrolledDropdown>
          </Nav>
        </Collapse>
      </Navbar>
    );
  }
}
export default AppHeader;
