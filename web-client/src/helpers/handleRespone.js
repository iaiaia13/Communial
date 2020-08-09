import { authenticationService } from "../services/authService";

function handleResponse(response) {
  var data = response.json();
  if (!response.ok) {
    if ([401, 403].indexOf(response.status) !== -1) {
      // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
      authenticationService.logout();
      window.location.reload(true);
    }
    var error = (data && data.message) || response.statusText;
    return Promise.reject(error);
  } else {
    return data;
  }
}

export default handleResponse;
