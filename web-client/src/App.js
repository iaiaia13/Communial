import React, { Component, Fragment } from "react";
import HomePage from "./pages/HomePage";
import { Route, Switch } from "react-router-dom";
import { ListOffice } from "./components/office/ListOffice";
import { Navigation } from "./components/nav/Navigation";
import { Container } from "./components/Container";
import HomeSearch from "./components/homesearch/HomeSearch";
import { useForm } from "react-hook-form";

import OfficeContextProvider from "./app/context/officeContext";

export default function App() {
  // Prevent page reload, clear input, set URL and push history on submit
  // handleSubmit = (e, history, searchInput) => {
  //   e.preventDefault();
  //   e.currentTarget.reset();
  //   let url = `/search/${searchInput}`;
  //   history.push(url);
  // };

  return (
    <OfficeContextProvider>
      <Fragment>
        <Navigation />
        <Route
          render={props => (
            <HomeSearch
            // handleSubmit={this.handleSubmit}
            // history={props.history}
            />
          )}
        />
        <Route exact path="/" component={HomePage} />
        <Switch>
          <Route
            path="/communal"
            render={() => <ListOffice searchTerm="beach" />}
          />
          <Route
            path="/search/:searchInput"
            render={props => (
              <ListOffice searchTerm={props.match.params.searchInput} />
            )}
          />
        </Switch>
      </Fragment>
    </OfficeContextProvider>
  );
}
