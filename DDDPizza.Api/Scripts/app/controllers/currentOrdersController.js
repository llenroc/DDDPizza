(function (module) {

    var injectParams = ['orderRepository'];
    var currentOrdersController = function (orderRepository) {

        var model = this;
        model.orders = [];

        function getOrders() {
            orderRepository.getOrders().then(function (data) {
                model.orders = data;
            });
        }

        getOrders();


    };

    currentOrdersController.$inject = injectParams;

    module.controller("currentOrdersController", currentOrdersController);

}(angular.module("dddPizza")));