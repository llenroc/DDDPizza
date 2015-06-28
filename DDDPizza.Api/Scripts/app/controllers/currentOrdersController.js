(function (module) {

    var injectParams = ['$timeout', 'orderRepository'];
    var currentOrdersController = function ($timeout,orderRepository) {

        var model = this;
        model.orders = [];
 
        model.timeRemaining = function calculateTimeRemaining(start, end) {
            var startDate = new Date(start);
            var endDate = new Date(end);
            var diff = endDate.getTime() - startDate.getTime();
            var diff2 = endDate.getTime() - new Date().getTime();
            diff = diff2 / diff;
            diff = (100 - Math.floor((diff) * 100));
            return diff;
        }

        function getOrders() {
            orderRepository.getOrders().then(function (data) {
                model.orders = data;
                $timeout(function () {
                    getOrders();
                }, 60000);
            });
        }

        getOrders();


    };

    currentOrdersController.$inject = injectParams;

    module.controller("currentOrdersController", currentOrdersController);

}(angular.module("dddPizza")));