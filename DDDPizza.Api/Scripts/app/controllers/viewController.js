(function (module) {

    var injectParams = ['orderRepository'];
    var viewController = function (orderRepository) {

        var model = this;
        model.orders = [];

        function getOrders() {
            orderRepository.getOrders().then(function (data) {
                model.orders = data;
            });
        }

        getOrders();


    };

    viewController.$inject = injectParams;

    module.controller("viewController", viewController);

}(angular.module("dddPizza")));