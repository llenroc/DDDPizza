(function (module) {

    var pizza = function () {
        return {
            bread: "",
            sauce: "",
            cheese: "",
            size: "",
            topping: [],
            total: 0
    };
    };

    module.factory("pizza", pizza);

}(angular.module("dddPizza")));


