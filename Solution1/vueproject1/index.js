const cors_proxy = require('cors-anywhere');

const host = process.env.HOST || '0.0.0.0';

// Listen on a specific port via the PORT environment variable
const port = process.env.PORT || 5247;

cors_proxy
    .createServer({
        originWhitelist: [], // Allow all origins
    })
    .listen(port, host, function () {
        console.log('Running CORS Anywhere on ' + host + ':' + port);
    });