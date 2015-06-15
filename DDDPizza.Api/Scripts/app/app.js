(function() {
    'use strict';
    var app = angular.module('dddPizza', ['ngAnimate', 'ngSanitize', 'ui.router', 'toastr']);

    app.config(function ($urlRouterProvider, $stateProvider, $locationProvider) {

        $stateProvider
        .state('view', {
            url: '/',
            templateUrl: '/Scripts/app/views/view.html'
        })
        .state('add', {
            url: '/add',
            templateUrl: '/Scripts/app/views/home.html'
        });
        $urlRouterProvider.otherwise('/');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    });

    app.config(function (toastrConfig) {
        angular.extend(toastrConfig, {
            allowHtml: false,
            autoDismiss: false,
            closeButton: false,
            closeHtml: '<button>&times;</button>',
            containerId: 'toast-container',
            extendedTimeOut: 1000,
            iconClasses: {
                error: 'toast-error',
                info: 'toast-info',
                success: 'toast-success',
                warning: 'toast-warning'
            },
            maxOpened: 0,
            messageClass: 'toast-message',
            newestOnTop: true,
            onHidden: null,
            onShown: null,
            positionClass: 'toast-bottom-right',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            progressBar: false,
            tapToDismiss: true,
            target: 'body',
            templates: {
                toast: 'directives/toast/toast.html',
                progressbar: 'directives/progressbar/progressbar.html'
            },
            timeOut: 5000,
            titleClass: 'toast-title',
            toastClass: 'toast'
        });
    });


    app.filter('pizzadetails', function () {


        return function (pizza) {

            var returnString = '';
            returnString += pizza.size.name + ", ";
            returnString += pizza.bread.name + ", ";
            returnString += pizza.sauce.name + ", ";
            returnString += pizza.cheese.name + ", ";

            if (pizza.topping.length > 0) {
                pizza.topping.forEach(function (top) {
                    if(top != null)
                        returnString += top.name + ", ";
                });
            }
            return returnString.substring(0, returnString.length - 2);

        }
        
    });

}());