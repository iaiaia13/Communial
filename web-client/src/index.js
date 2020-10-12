import React from "react";
import ReactDOM from "react-dom";
import { createBrowserHistory } from 'history';
import "bootstrap/dist/css/bootstrap.min.css";
import './assets/vendor/font-awesome/css/font-awesome.min.css'
import "./assets/css/main.css"

import App from "./App.js";
import * as serviceWorker from "./serviceWorker";
import { BrowserRouter } from "react-router-dom";
import ScrollToTop from './layout/ScrollToTop';

export const history = createBrowserHistory();

ReactDOM.render(
   <BrowserRouter history={history}>
   {/* // <ScrollToTop> */}
      <App />
    {/* </ScrollTokTop> */}
  </BrowserRouter>
 ,
  document.getElementById('root')
);
// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA

serviceWorker.unregister();
