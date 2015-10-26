'use strict';

eventsApp.controller('CookieStoreSampleController',
    function CookieStoreSampleController($scope, $cookies) {
        $scope.event = { id: 1, name: "My Event" };

        $scope.saveEventToCookie = function (event) {
            $cookies.put('event', JSON.stringify(event));
        };

        $scope.getEventFromCookie = function () {
            console.log(JSON.parse($cookies.get('event')));
        };

        $scope.removeEventCookie = function () {
            $cookies.remove('event');
        };


    }
);
