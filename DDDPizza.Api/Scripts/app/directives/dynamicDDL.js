(function (module) {

    var dynamicdropdownlist = function () {

        return {
            restrict: 'AE',
            require: '^form',
            bindToController: true,
            templateUrl: '/Scripts/app/directives/templates/dynamicDDL.html',
            controllerAs: 'vm',
            scope: {amount: '@', passPizza: '=', updateAmount: '&'},
            controller: ['inventoryRepository', function (inventoryRepository) {

                var vm = this;

                inventoryRepository.getInventory().then(function (data) {
                    vm.toppings = data.toppings;
                });

                vm.add = function () {
                    vm.amount++;
                };

                vm.remove = function () {
                    vm.amount--;
                    delete vm.passPizza.topping[vm.amount];
                    vm.updateAmount();
                };

                vm.range = function (count) {
                    var ratings = [];
                    for (var i = 0; i < count; i++) {
                        ratings.push(i);
                    }
                    return ratings;
                };

            }]
        };
    };

    module.directive('dynamicdropdownlist', dynamicdropdownlist);

}(angular.module('dddPizza')));

