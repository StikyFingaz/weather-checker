// Set the correct URL for the API
export function setApiUrl(localUrl: string) {
  const environments = {
    development: "http://localhost:5023/",
    // development: "https://backend.dktshumen.com/api",
    // development: "https://nuxt.dktshumen.com/api",
    // production: "http://localhost:8000/api",
    // production: "https://backend.dktshumen.com/api",
    production: "https://nuxt.dktshumen.com/api",
  };

  const apiUrl = environments[process.env.NODE_ENV] || environments.production;

  return `${apiUrl}${localUrl}`;
}
