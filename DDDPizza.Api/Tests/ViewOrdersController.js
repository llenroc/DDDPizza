"use strict";

describe("viewController", function () {

    //basic mock lookup service which returns empty arrays
    var mockOrderRepository = {
        getOrders: function () {
            return [
               
            ];
        }
    };

    var scope, model, controller;

   

    it("should be true", function () {
        expect(true).toBe(true);
    });

    it("should be false", function () {
        expect(false).toBe(false);
    });


   
});