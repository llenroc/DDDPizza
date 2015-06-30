(function (module) {

    var injectParams = ['$state', 'inventoryRepository',
                            'orderRepository', 'pizza', 'order',
                                'localStorage', 'toastr'];
    var orderController = function ($state, inventoryRepository,
                            orderRepository, pizza, order, localStorage, toastr) {

        var model = this;

        model.userkey = 'orderToken';
        model.pizza = pizza;
        model.resetPizza = angular.copy(model.pizza);
        model.order = order;
        model.breads = [];
        model.services = [];
        model.tempOrder = {};

        model.init = function () {

            model.pizza = model.resetPizza;
            inventoryRepository.getInventory().then(function (data) {
                model.breads = data.breads;
                model.sauces = data.sauces;
                model.cheeses = data.cheeses;
                model.sizes = data.sizes;
                model.toppings = data.toppings;
            });

            orderRepository.getServiceOptions().then(function (data) {
                model.services = data;
            });

            if (localStorage.get(model.userkey) == null) {
                localStorage.add(model.userkey, model.order);
            }
            model.tempOrder = localStorage.get(model.userkey);
        };

        model.getOrderSubTotal = function() {
            var total = 0;
            for (var i = 0; i < model.tempOrder.pizzas.length; i++) {
                var pizza = model.tempOrder.pizzas[i];
                total += pizza.total;
            }
            model.tempOrder.subtotal = total;
            return total;
        };

        model.getOrderTotal = function () {
            if (model.tempOrder.serviceCharge != null)
            {
                model.tempOrder.total =
                        parseFloat(model.tempOrder.subtotal) +
                            parseFloat(model.tempOrder.serviceCharge);
            }
            else
            {
                model.tempOrder.total = parseFloat(model.tempOrder.subtotal);
            }
            return model.tempOrder.total;
        };

        model.updateServiceCharge = function () {
            if (model.tempOrder.serviceType === 'Delivery')
            {
                model.tempOrder.serviceCharge = parseFloat(2);
            }
            else
            {
                model.tempOrder.serviceCharge = parseFloat(0);
            }
        };

        model.updateTotal = function () {
            model.pizza.total = 0;
            if (!isNaN(model.pizza.size.price))
            {
                model.pizza.total = parseFloat(model.pizza.size.price);
            }
            model.pizza.topping.forEach(function (data) {
                if (data === null)
                {
                    return;
                }
                if (!isNaN(data.price) && data.price != null)
                {
                    model.pizza.total += parseFloat(data.price);
                }
            });

        };

        model.copyPizza = function (pizza) {
            var obj = localStorage.get(model.userkey);
            obj.pizzas.push(pizza);
            localStorage.add(model.userkey, obj);
            toastr.success('Successful!', 'Pizza was copied!');
            model.init();
        };

        model.removePizza = function (idx) {
            var obj = localStorage.get(model.userkey);
            obj.pizzas.splice(idx, 1);
            localStorage.add(model.userkey, obj);
            toastr.success('Successful!', 'Pizza was removed!');
            model.init();
        };

        model.submitPizza = function () {

            var obj = localStorage.get(model.userkey);
            obj.pizzas.push(model.pizza);
            console.log(model.pizza);
            localStorage.add(model.userkey, obj);
            toastr.success('Successful!', 'Pizza was added to Order!');
            model.init();
        };

        model.submitFinalOrder = function () {

            orderRepository.placeOrder(model.tempOrder).then(function (data) {
                toastr.success('Successful!', 'Order has been placed on the queue!');
                localStorage.clear();
                $state.go('current', {}, {reload: true});
            }).catch(function (error) {
                toastr.error('Error!', error);
            });

        };

    };

    orderController.$inject = injectParams;

    module.controller('orderController', orderController);

}(angular.module('dddPizza')));
