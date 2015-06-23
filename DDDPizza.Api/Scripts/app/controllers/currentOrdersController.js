(function (module) {

    var injectParams = ['orderRepository'];
    var currentOrdersController = function (orderRepository) {

        var model = this;
        model.orders = [];
        model.timeRemaining = function calculateTimeRemaining(start, end) {
            var startDate = new Date(start);
            var endDate = new Date(end);
            var diff = endDate.getTime() - startDate.getTime();
            var diff2 = endDate.getTime() - new Date().getTime();
            diff = diff2 / diff;
            diff = Math.floor((diff) * 100);
            return diff;
        }

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