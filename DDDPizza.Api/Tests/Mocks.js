

//Three mocked orders
function getMockOrders() {

    return [
        {
            "id": "c4791023-37a9-450c-8c77-0c86f93f7efb",
            "name": "ANDRE",
            "dateTimeStamp": "2015-06-20T08:13:45.151Z",
            "serviceType": "TakeOut",
            "subTotal": 13.97,
            "serviceCharge": 0.50,
            "total": 14.47,
            "pizzas": [
                {
                    "total": 13.97,
                    "bread": {
                        "id": "2ee986fb-a0e7-40e8-94ff-4d21e1dd3b3e",
                        "type": 0,
                        "name": "Thin"
                    },
                    "sauce": {
                        "id": "6b092b6b-5176-404e-9918-a6d3e493d9a2",
                        "type": 2,
                        "name": "Pesto"
                    },
                    "cheese": {
                        "id": "c274feef-3ae6-4d54-b770-ce73b456ea21",
                        "type": 1,
                        "name": "Mozzarella"
                    },
                    "size": {
                        "price": "10.99",
                        "id": "408e6ea3-bc46-4265-9e56-8308c624f268",
                        "type": 4,
                        "name": "Small"
                    },
                    "topping": [
                        {
                            "price": "0.99",
                            "id": "67c443ce-97e2-4e1c-9b00-d775bc36b376",
                            "type": 3,
                            "name": "Mushrooms"
                        },
                        {
                            "price": "1.99",
                            "id": "59f6d847-3ece-4829-9155-06de7573b54a",
                            "type": 3,
                            "name": "Bacon"
                        }
                    ]
                }
            ]
        },
        {
            "id": "73f31c15-63cf-4437-b0cd-daa556901d45",
            "name": "Mally",
            "dateTimeStamp": "2015-06-20T08:03:29.697Z",
            "serviceType": "Delivery",
            "subTotal": 13.97,
            "serviceCharge": 2.00,
            "total": 15.97,
            "pizzas": [
                {
                    "total": 13.97,
                    "bread": {
                        "id": "2ee986fb-a0e7-40e8-94ff-4d21e1dd3b3e",
                        "type": 0,
                        "name": "Thin"
                    },
                    "sauce": {
                        "id": "6b092b6b-5176-404e-9918-a6d3e493d9a2",
                        "type": 2,
                        "name": "Pesto"
                    },
                    "cheese": {
                        "id": "c274feef-3ae6-4d54-b770-ce73b456ea21",
                        "type": 1,
                        "name": "Mozzarella"
                    },
                    "size": {
                        "price": "10.99",
                        "id": "408e6ea3-bc46-4265-9e56-8308c624f268",
                        "type": 4,
                        "name": "Small"
                    },
                    "topping": [
                        {
                            "price": "0.99",
                            "id": "67c443ce-97e2-4e1c-9b00-d775bc36b376",
                            "type": 3,
                            "name": "Mushrooms"
                        },
                        {
                            "price": "1.99",
                            "id": "59f6d847-3ece-4829-9155-06de7573b54a",
                            "type": 3,
                            "name": "Bacon"
                        }
                    ]
                }
            ]
        },
        {
            "id": "976ac5d2-2fa9-4523-adda-e1ce0a3cb433",
            "name": "Nicers",
            "dateTimeStamp": "2015-06-20T08:01:03.824Z",
            "serviceType": "InRestaurant",
            "subTotal": 31.95,
            "serviceCharge": 0.00,
            "total": 31.95,
            "pizzas": [
                {
                    "total": 17.98,
                    "bread": {
                        "id": "3952422f-a9ed-4790-8b42-9c316f773697",
                        "type": 0,
                        "name": "Deep Dish"
                    },
                    "sauce": {
                        "id": "ed11fa4b-3bba-4d3b-9a55-e39ee2f48ccc",
                        "type": 2,
                        "name": "Tomato"
                    },
                    "cheese": {
                        "id": "c274feef-3ae6-4d54-b770-ce73b456ea21",
                        "type": 1,
                        "name": "Mozzarella"
                    },
                    "size": {
                        "price": "16.99",
                        "id": "bf3672bd-8afa-43f6-8687-3199d3d799b5",
                        "type": 4,
                        "name": "Extra Large"
                    },
                    "topping": [
                        {
                            "price": "0.99",
                            "id": "ce17da9d-b992-4b2f-ad9d-f89442a6aa1c",
                            "type": 3,
                            "name": "Pineapple"
                        }
                    ]
                },
                {
                    "total": 13.97,
                    "bread": {
                        "id": "2ee986fb-a0e7-40e8-94ff-4d21e1dd3b3e",
                        "type": 0,
                        "name": "Thin"
                    },
                    "sauce": {
                        "id": "6b092b6b-5176-404e-9918-a6d3e493d9a2",
                        "type": 2,
                        "name": "Pesto"
                    },
                    "cheese": {
                        "id": "c274feef-3ae6-4d54-b770-ce73b456ea21",
                        "type": 1,
                        "name": "Mozzarella"
                    },
                    "size": {
                        "price": "10.99",
                        "id": "408e6ea3-bc46-4265-9e56-8308c624f268",
                        "type": 4,
                        "name": "Small"
                    },
                    "topping": [
                        {
                            "price": "0.99",
                            "id": "67c443ce-97e2-4e1c-9b00-d775bc36b376",
                            "type": 3,
                            "name": "Mushrooms"
                        },
                        {
                            "price": "1.99",
                            "id": "59f6d847-3ece-4829-9155-06de7573b54a",
                            "type": 3,
                            "name": "Bacon"
                        }
                    ]
                }
            ]
        }
    ];
}