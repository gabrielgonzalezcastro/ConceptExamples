'use strict';

eventsApp.controller('EventController',
    function EventController($scope, eventDataService, $routeParams) {

        $scope.myStyle = { color: 'red' };
        $scope.myClass = "blue";
        $scope.sortOrder = 'creatorName';

        eventDataService.getEvent($routeParams.eventId).then(function (data) {
            $scope.event = data;
        });
       
        $scope.upVoteSession = function (session) {
            session.upVoteCount++;
        };

        $scope.downVoteSession = function (session) {
            session.upVoteCount--;
        };
    }
);