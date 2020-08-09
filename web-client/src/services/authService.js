import { LOGIN_API_URL, REGIS_API_URL } from "../constants";

import handleResponse from "../helpers/handleRespone";

export const authenticationService = {
  login,
  register,
  logout
};

function login(email, password) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  };
  return fetch(`${LOGIN_API_URL}`, requestOptions)
    .then(handleResponse)
    //.then((res) => res.json())
    .then((authData) => {
      if (authData) {
        // store user details and basic auth credentials in local storage
        // to keep user logged in between page refreshes
        localStorage.setItem("authData", JSON.stringify(authData));
      }

      return authData;
    });
}

function register(email, username, password) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, username, password }),
  };
  return fetch(`${REGIS_API_URL}`, requestOptions)
    .then(handleResponse)
    //.then((res) => res.json())
    .then((authData) => {
      if (authData) {
        // store user details and basic auth credentials in local storage
        // to keep user logged in between page refreshes
        localStorage.setItem("authData", JSON.stringify(authData));
      }

      return authData;
    });
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("authData");
}

