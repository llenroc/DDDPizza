module.exports = function(){

    var client = "DDDPizza.Api/";
    var clientApp = client + "Scripts/app/";
    var clientLib = client + "Scripts/lib/";
    var clientCss = client + "Content/";
    var indexRoot = client + "Views/Shared/";
    
    var config = {
    
        client: client,
        
        alljs:[
            clientApp + "app.js",
            clientApp + "controllers/*.js",
            clientApp + "services/*.js",
            clientApp + "directives/*.js",
            "!" + clientApp + "app.min.js"],
        
        indexRoot: indexRoot,
        index: indexRoot + "_Layout.cshtml",
  
        
        allcss:[
            clientCss + "Site.css"
        ],
        
        bower: {
            json: require("./bower.json"),
            directory: clientLib,
            ignorePath: "../..",
            modernizr: "/Scripts/lib/modernizr/modernizr.js"
        }
    
    };
    
    config.getWiredepDefaultOptions = function(){
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
            exclude: [config.bower.modernizr]
        };
        return options;
    };
    
    return config;
};