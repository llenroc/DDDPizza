(function (module) {

    var order = function () {

        return {
            name: "",
            serviceType: "",
            subtotal: 0,
            serviceCharge: 0,
            total:0,
            pizzas: []
        };
    };

    module.factory("order", order);

}(angular.module("dddPizza")));
