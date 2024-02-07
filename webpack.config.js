var path = require("path");

module.exports = {
    mode: "development",
    entry: "./src/App.fs.js",
    output: {
        path: path.join(__dirname, "./public"),
        filename: "bundle.js",
    },
    devServer: {
        static: "./public",
        port: 8080
    },
    resolve: {
        alias: {
            jquery: "jquery/src/jquery"   // important - can't import jQuery from dist folder
        }
    },
    module: {
    }
}
