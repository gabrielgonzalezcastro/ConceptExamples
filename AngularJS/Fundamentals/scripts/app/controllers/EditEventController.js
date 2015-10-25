'use strict';

eventsApp.controller('EditEventController',
    function EditEventController($scope, eventDataService) {

        $scope.saveEvent = function (event, newEventForm) {
            console.log(newEventForm);
            if (newEventForm.$valid) {
                eventDataService.save(event).then(function(data) {
                    console.log(data);
                });
            }
        };

        $scope.cancelEdit = function () {
            window.location = "/ang-views/EventDetails.html";
        }
    }
);