"use strict";

describe("viewController", function () {

    var controller, mockOrderData;

    beforeEach(function () {
        bard.appModule("dddPizza");
        bard.inject('$controller', '$q', '$rootScope', 'orderRepository');
        sinon.stub(orderRepository, 'getOrders').returns($q.when(getMockOrders()));
        controller = $controller("currentOrdersController");
        spyOn(orderRepository, 'getOrders');
    });

    it("has a working controller", function () {
        $rootScope.$apply();
        expect(controller).toBeDefined();
        expect(controller.orders.length).toBeGreaterThan(0);
    });

    it("should have length equal to the mocks", function () {
        $rootScope.$apply();
        expect(controller).toBeDefined();
        expect(controller.orders.length).toEqual(getMockOrders().length);
        //expect(orderRepository.getOrders).toHaveBeenCalled();
    });



});