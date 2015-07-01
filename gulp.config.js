module.exports = function(){

    var client = "DDDPizza.Api/";
    var clientApp = client + "Scripts/app/";
    var clientLib = client + "Scripts/lib/";
    var clientCss = client + "Content/";
    var indexRoot = client + "Views/Shared/";
    
    var config = {
    
        client: client,
        clientApp: clientApp,
        clientLib: clientLib,
        clientCss: clientCss,
        indexRoot: indexRoot,

        alljs:[
            clientApp + "app.js",
            clientApp + "controllers/*.js",
            clientApp + "services/*.js",
            clientApp + "directives/*.js",
            "!" + clientApp + "app.min.js"],
    
        index: indexRoot + "_Layout.cshtml",
  
        allcss:[
            clientCss + "Site.css"
        ],
        
        bower: {
            json: require("./bower.json"),
            directory: clientLib,
            ignorePath: "../..",
            excludes: [ "/Scripts/lib/modernizr/modernizr.js",
                        "/Scripts/lib/bard*.js",
                        "/Scripts/lib/angular-mocks/angular-mocks.js"]
        }
    
    };
    
    config.getWiredepDefaultOptions = function(){
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
            exclude: config.bower.excludes
        };
        return options;
    };
    
    return config;
};