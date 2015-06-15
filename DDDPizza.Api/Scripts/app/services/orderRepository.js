(function (module) {

    var injectParams = ['httpRepository', '$q'];

    var orderRepository = function (httpRepository, $q) {

        var getOrders = function () {
            var def = $q.defer();
            httpRepository.getData("/api/orders").then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };




        return {
            getOrders: getOrders
        }
    };

    orderRepository.$inject = injectParams;

    module.service("orderRepository", orderRepository);

}(angular.module("dddPizza")))