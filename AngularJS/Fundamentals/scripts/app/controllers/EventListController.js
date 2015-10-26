'use strict';

eventsApp.controller('EventListController',
    function EventListController($scope, $location, eventDataService) {
        eventDataService.getAllEvents().then(function(data) {
            $scope.events = data;
        });

        $scope.redirect = function(event) {
            $location.path('/eventDetail/' + event.id);
        };
    }
);

