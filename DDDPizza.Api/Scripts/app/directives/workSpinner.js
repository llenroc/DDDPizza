﻿(function (module) {

    var workSpinner = ['requestCounter', function (requestCounter) {
        return {
            restrict: 'EAC',
            transclude: true,
            scope: {},
            template: '<ng-transclude ng-show="requestCount"></ng-transclude>',
            link: function (scope) {

                scope.$watch(function () {
                    return requestCounter.getRequestCount();
                }, function (requestCount) {
                    scope.requestCount = requestCount;
                });

            }
        };
    }];

    module.directive('workSpinner', workSpinner);
}(angular.module('dddPizza')));
