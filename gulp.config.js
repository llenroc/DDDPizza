module.exports = function(){

    var config = {
    
        alljs:["DDDPizza.Api/Scripts/app/app.js",
            "DDDPizza.Api/Scripts/app/controllers/*.js",
            "DDDPizza.Api/Scripts/app/services/*.js",
            "DDDPizza.Api/Scripts/app/directives/*.js",
            "!DDDPizza.Api/Scripts/app/app.min.js"],
        
        allcss:[
          "DDDPizza.Api/Content/Site.css"
        ]
    
    };
    
    return config;
};