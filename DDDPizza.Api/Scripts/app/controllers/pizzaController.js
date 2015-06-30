(function (module) {

    var pizzaController = function () {

        var model = this;
        model.pizzas = [];
        model.value = 0;
        model.maxValue = 3;
    };

    module.controller('pizzaController', pizzaController);

}(angular.module('dddPizza')));
