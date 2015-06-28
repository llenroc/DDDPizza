"use strict";

describe("pizzaController", function () {

    var scope, controller;
    /*
    beforeEach(module("dddPizza"));

    beforeEach(inject(function ($controller) {
        scope = {};
        controller = $controller("pizzaController", {});
    }));
    */
    beforeEach(function () {
        bard.appModule("dddPizza");
        bard.inject('$controller', '$rootScope');
        controller = $controller("pizzaController");
    });

    it("has a working controller", function () {
        expect(controller.value).toBeDefined();
    });

    it("has correct initial values", function () {
        $rootScope.$apply();
        expect(controller.pizzas).toBeDefined();
        expect(controller.pizzas).toBeTruthy();
        expect(controller.pizzas).toBeLessThan(1);
    });

});