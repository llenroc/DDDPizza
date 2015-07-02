(function (module) {

    var injectParams = ['httpRepository', '$q'];

    var inventoryRepository = function (httpRepository, $q) {

        var getInventory = function () {
            var def = $q.defer();
            httpRepository.getData('/api/inventory').then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };

        var getInventoryByType = function (type) {
            var def = $q.defer();
            httpRepository.getData('/api/inventory/' + type).then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };

        return {
            getInventory: getInventory,
            getInventoryByType: getInventoryByType
        };
    };

    inventoryRepository.$inject = injectParams;

    module.service('inventoryRepository', inventoryRepository);

}(angular.module('dddPizza')));
