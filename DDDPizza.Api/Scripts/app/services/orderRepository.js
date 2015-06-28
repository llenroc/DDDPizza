(function (module) {

    var injectParams = ["httpRepository", "$q"];

    var orderRepository = function (httpRepository, $q) {

        var getOrders = function () {
            var def = $q.defer();
            httpRepository.getData("/api/current/orders").then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };

        var getPastOrders = function () {
            var def = $q.defer();
            httpRepository.getData("/api/past/orders").then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };

        var getOrderById = function (id) {
            var def = $q.defer();
            httpRepository.getData("/api/orders/" + id).then(function (data) {
                def.resolve(data);
            }).catch(function (error) {
                def.reject(error);
            });
            return def.promise;
        };

        var getServiceOptions = function () {
            var def = $q.defer();
            httpRepository.getData("/api/services").then(function (data) {
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
            getOrders: getOrders,
            getPastOrders: getPastOrders,
            getOrderById: getOrderById,
            getServiceOptions: getServiceOptions,
            placeOrder: placeOrder
        }
    };

    orderRepository.$inject = injectParams;

    module.service("orderRepository", orderRepository);

}(angular.module("dddPizza")))