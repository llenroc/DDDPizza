(function (module) {

    var injectParams = ['httpRepository', '$q'];

    var inventoryRepository = function (httpRepository, $q) {

        var getInventory = function () {
            var def = $q.defer();
            httpRepository.getData("/api/inventory").then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };



        var placeOrder = function (order) {
            var def = $q.defer();
            httpRepository.postData("/api/order", order).then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };


        return {
            getInventory: getInventory,
            placeOrder: placeOrder
        }
    };

    inventoryRepository.$inject = injectParams;

    module.service("inventoryRepository", inventoryRepository);

}(angular.module("dddPizza")))