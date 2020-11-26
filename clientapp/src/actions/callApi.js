export function callApi(apiData) {
  if (apiData.config.body) {
    apiData.config.body = JSON.stringify(apiData.config.body);
  }
  if (apiData.config.headers) {
    apiData.config.headers["Content-type"] = "application/json";
  } else {
    apiData.config.headers = {
      "Content-type": "application/json",
    };
  }

  return fetch(apiData.url, apiData.config)
    .then((response) => {
      if (!response.ok) {
        return {
          error: true,
          apiError: true,
        };
      }
      return response.json();
    })
    .catch(() => {
      return {
        error: true,
      };
    })
    .then((responseData) => {
      return responseData;
    });
}
