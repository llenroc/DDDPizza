(function (module) {


    var dynamicdropdownlist = function () {

        return {
            restrict: "AE",
            require: "^form",     
            bindToController: { amount: "@", passPizza: "=", updateAmount: "&" },
            templateUrl: '/Scripts/app/directives/templates/dynamicDDL.html',
            controllerAs: "vm",
            scope: true,
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
                    vm.passPizza.topping.splice(-1, 1);
                    vm.updateAmount();
                };

                vm.range = function (count) {
                    var ratings = [];
                    for (var i = 0; i < count; i++) {
                        ratings.push(i);
                    }
                    return ratings;
                }

            }]
        };



    };

    module.directive("dynamicdropdownlist", dynamicdropdownlist);

}(angular.module("dddPizza")));
