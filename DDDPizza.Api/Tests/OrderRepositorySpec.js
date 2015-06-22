"use strict";

describe("orderRepository", function () {

    beforeEach(function () {
        bard.appModule("dddPizza");
        bard.inject('orderRepository', 'httpRepository', '$q', '$httpBackend', '$rootScope');
    });

    it("has a working order repository", function () {
        
        expect(orderRepository).toBeDefined();
        $httpBackend.when('GET', '/api/orders').respond(200, []);
        orderRepository.getOrders().then(function (data) {
            expect(data).toBeDefined();
        });
        $httpBackend.flush();
        //$rootScope.$apply();
    });


});