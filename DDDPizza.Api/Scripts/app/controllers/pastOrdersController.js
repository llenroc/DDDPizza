(function (module) {

    var injectParams = ['orderRepository'];
    var pastOrdersController = function (orderRepository) {

        var model = this;
        model.orders = [];

        function getOrders() {
            orderRepository.getPastOrders().then(function (data) {
                model.orders = data;
            });
        }

        getOrders();


    };

    pastOrdersController.$inject = injectParams;

    module.controller("pastOrdersController", pastOrdersController);

}(angular.module("dddPizza")));