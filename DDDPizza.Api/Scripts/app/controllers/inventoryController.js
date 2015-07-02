(function (module) {

    var injectParams = ['inventoryRepository', '$stateParams'];

    var inventoryController = function (inventoryRepository, $stateParams) {

        var model = this;
        model.title = $stateParams.id.toUpperCase();
        model.hasPrice = false;
        model.items = [];

        model.init = function() {
            inventoryRepository.getInventoryByType($stateParams.id).then(function(data) {
                model.items = data;
                if (data[0].price > 0) {
                    model.hasPrice = true;
                }
            });
        };

    };

    inventoryController.$inject = injectParams;

    module.controller('inventoryController', inventoryController);

}(angular.module('dddPizza')));
