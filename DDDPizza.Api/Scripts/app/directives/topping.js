(function (module) {

   
    var link = function ($compile) {
        return function (scope, element, attributes, form) {

            var htmlBuilder = "";
            for (var i = 0; i < attributes.list; i++) {
                htmlBuilder += '<p><input ng-model="test' + i + '" type="text" placeholder="Sup!" /><span ng-bind="test' + i + '"></span> </p>';
            }

            console.log(element);
            var $newTopping = $(element).append(htmlBuilder);

            $compile(htmlBuilder)(scope);  //compile the input
           
        };
    };

    var toppings = function ($compile) {

        return {
            restrict: "AE",
            require: "^form",
            scope: { lists: "=" },
            template: '<input  type="text" placeholder="Sup!" />',
            link: link($compile)

        };



    };

    module.directive("toppings", toppings);

}(angular.module("dddPizza")));
