(function() {
    'use strict';
    var app = angular.module("dddPizza", ["ui.router"]);

    app.config(function ($urlRouterProvider, $stateProvider, $locationProvider) {

        $stateProvider
        .state('home', {
            url: '/',
            templateUrl: '/Scripts/app/views/home.html'
        });

        $urlRouterProvider.otherwise('/');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    });

}());