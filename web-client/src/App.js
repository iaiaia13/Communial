import React, { Component, Fragment } from "react";
import { Router, Route } from "react-router-dom";
import { history } from "./helpers/history";
import AppFooter from "./components/AppFooter";
import HomePage from "./components/HomePage";
import LoginPage from "./components/login/LoginPage";
import { authenticationService } from "./services/authService";

class App extends Component {
  logout() {
    authenticationService.logout();
    history.push("/");
    window.location.reload();
  }
  render() {
    return (
      <Fragment>
        <Router forceRefresh={true} history={history}>
          <Route
            exact
            path="/"
            render={(props) => <HomePage {...props} logout={this.logout} />}
          />
          <Route
            exact
            path="/login"
            render={(props) => (
              <LoginPage {...props} isNew={false} />
            )}
          />
          <Route
            exact
            path="/register"
            render={(props) => (
              <LoginPage {...props} isNew={true} />
            )}
          />
        </Router>
        <AppFooter />
      </Fragment>
    );
  }
}
export default App;
