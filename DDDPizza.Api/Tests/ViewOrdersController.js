"use strict";

describe("pizzaController", function () {

    var scope, controller;
    beforeEach(module("dddPizza"));

    beforeEach(inject(function ($controller) {
        scope = {};
        controller = $controller("pizzaController", {});
    }));

    it("has a working controller", function () {
        expect(controller.value).toBeDefined();
    });

    it("has correct initial values", function () {
        expect(controller.pizzas).toBeDefined();

    });



   
}); 