
module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine', 'mocha', 'chai', 'sinon', 'chai-sinon'],


    // list of files / patterns to load in the browser
    files: [
        'DDDPizza.Api/Scripts/lib/angular/angular.js',
        'DDDPizza.Api/Scripts/lib/angular-resource/angular-resource.js',
        'DDDPizza.Api/Scripts/lib/angular-animate/angular-animate.js',
        'DDDPizza.Api/Scripts/lib/angular-sanitize/angular-sanitize.js',
        'DDDPizza.Api/Scripts/lib/angular-ui-router/release/angular-ui-router.js',
        'DDDPizza.Api/Scripts/lib/angular-toastr/dist/angular-toastr.js',
        'DDDPizza.Api/Scripts/lib/angular-bootstrap/ui-bootstrap-tpls.js',   
        'DDDPizza.Api/Scripts/lib/angular-filter/dist/angular-filter.js',
        'DDDPizza.Api/Scripts/lib/angular-mocks/angular-mocks.js',
        'DDDPizza.Api/Scripts/lib/sinon/lib/sinon.js',
        'DDDPizza.Api/Scripts/lib/bardjs/dist/bard.js',
        'DDDPizza.Api/Scripts/app/app.min.js',
        'DDDPizza.Api/Tests/mocks.js',
        'DDDPizza.Api/Tests/*.js'
    ],

    plugins : [
      'karma-chrome-launcher',
        'karma-phantomjs-launcher',
        'karma-coverage',
        'karma-sinon',
        'karma-mocha',
        'karma-chai',
        'karma-chai-sinon',
        'karma-jasmine'
    ],

    // list of files to exclude
    exclude: [
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['Chrome'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: false
  });
};
