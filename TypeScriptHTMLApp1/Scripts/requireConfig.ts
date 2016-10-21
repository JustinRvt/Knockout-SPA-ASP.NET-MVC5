require.config({
  baseUrl: "",
  paths: {
    "jQuery": "Scripts/jquery-3.1.1",
    "knockout": "Scripts/knockout-3.4.0.debug",
    "text": "Scripts/text"
  },
  shim: {
    "jQuery": {
      exports: "$"
    }
  }
});
require(["Scripts/App/main"]};