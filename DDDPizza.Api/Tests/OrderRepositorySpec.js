"use strict";

describe("orderRepository", function () {

    var controller;

    beforeEach(function () {
        bard.appModule("dddPizza");
        bard.inject('orderRepository', 'httpRepository', '$q', '$httpBackend', '$rootScope');
        //controller = $controller("orderRepository");
    });

    it("has a working order repository", function () {
        
        expect(orderRepository).toBeDefined();
        $httpBackend.when('GET', '/api/orders').respond(200, []);
        orderRepository.getOrders().then(function (data) {
            console.log(data);
            expect(data).toBeDefined();
        });
        $httpBackend.flush();
        //$rootScope.$apply();
    });


});