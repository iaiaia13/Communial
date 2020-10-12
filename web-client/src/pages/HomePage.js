import React, { Component, Fragment } from "react";
import { Navigation } from "../components/nav/Navigation";
import HomeSearch  from "../components/homesearch/HomeSearch";
import { About } from '../components/About'
import { Achievement } from "../components/Achievement";
import { ListOffice } from "../components/office/ListOffice";

class HomePage extends Component {

  render() {
    return (
      <Fragment>
        <ListOffice />
        <About />
        <Achievement />
      </Fragment>
    );
  }
}

export default HomePage;
