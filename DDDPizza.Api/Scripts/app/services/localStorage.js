(function (module) {

    var injectParams = ["$window"];

    var localStorage = function ($window) {

        var store = $window.localStorage;

        var add = function (key, value) {
            value = angular.toJson(value);
            store.setItem(key, value);
        };

        var get = function (key) {
            var value = store.getItem(key);
            if (value) {
                value = angular.fromJson(value);
            }
            return value;
        };

        var remove = function (key) {
            store.removeItem(key);
        };

        var clear = function() {
            store.clear();
        };

        return {
            add: add,
            get: get,
            remove: remove,
            clear: clear
        };
    };
    localStorage.$inject = injectParams;
    module.factory("localStorage", localStorage);

}(angular.module("dddPizza")));