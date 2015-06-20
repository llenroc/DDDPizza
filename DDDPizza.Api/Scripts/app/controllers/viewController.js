(function (module) {

    var injectParams = ['orderRepository'];
    var viewController = function (orderRepository) {

        var model = this;
        model.orders = [];
        model.init = function () {

            orderRepository.getOrders().then(function (data) {
                model.orders = data; 
            });

        };

      
    };

    viewController.$inject = injectParams;

    module.controller("viewController", viewController);

}(angular.module("dddPizza")));