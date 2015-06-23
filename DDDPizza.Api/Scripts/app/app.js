(function () {
    "use strict";

    var serviceTypeFn = function () {
        //TODO: ERIC Write a unit test
        return function (value) {

            if (value === "TakeOut") {
                return "Take Out";
            } else if (value === "InRestaurant") {
                return "Dining In";
            } else if (value === "Delivery") {
                return "Delivery";
            }
            return "Unspecified";
        };
    };

    var pizzaDetailsFn = function () {
        return function (pizza) {
            //TODO: ERIC Write a unit test
            var returnString = '';
            returnString += pizza.size.name + ", ";
            returnString += pizza.bread.name + ", ";
            returnString += pizza.sauce.name + ", ";
            returnString += pizza.cheese.name + ", ";

            if (pizza.topping.length > 0) {
                pizza.topping.forEach(function (top) {
                    if (top !== null) {
                        returnString += top.name + ", ";
                    }
                });
            }
            return returnString.substring(0, returnString.length - 2);
        };
    };

    var toaster = function (toastrConfig) {
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
    };

    toaster.$inject = ["toastrConfig"];

    var disableScope = function ($compileProvider) {
        $compileProvider.debugInfoEnabled(false);
    };

    disableScope.$inject = ["$compileProvider"];

    var routes = function ($urlRouterProvider, $stateProvider, $locationProvider) {
        $stateProvider.state('current', {
             url: '/',
             templateUrl: '/Scripts/app/views/current.html'
         }).state('past', {
            url: '/past',
            templateUrl: '/Scripts/app/views/past.html'
         }).state('order', {
             url: '/order',
             templateUrl: '/Scripts/app/views/order.html'
         });
        $urlRouterProvider.otherwise('/');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    };

    routes.$inject = ["$urlRouterProvider", "$stateProvider", "$locationProvider"];

    angular.module("dddPizza", ["ngAnimate", "ngSanitize", "ui.router", "toastr", "ui.bootstrap"])
        .config(routes)
        .config(toaster)
        .config(disableScope)
        .filter("pizzadetails", pizzaDetailsFn)
        .filter("servicetype", serviceTypeFn);

}());