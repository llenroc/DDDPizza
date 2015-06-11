(function (module) {

    var injectParams = ['inventoryRepository'];
    var homeController = function (inventoryRepository) {

        var model = this;

        model.breads = [];

        model.init = function () {

            inventoryRepository.getInventory().then(function (data) {
                model.breads = data.breads;
                model.sauces = data.sauces;
                model.cheeses = data.cheeses;
                model.sizes = data.sizes;
                model.toppings = data.toppings;
            });

         

        };

    };

    homeController.$inject = injectParams;

    module.controller("homeController", homeController);

}(angular.module("dddPizza")));