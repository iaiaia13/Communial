export function authHeader() {
  // return authorization header with basic auth credentials
  let authData = JSON.parse(localStorage.getItem("authData"));
  if (authData) {
    return "Bearer " + authData.token ;
  } else {
    return {};
  }
}
