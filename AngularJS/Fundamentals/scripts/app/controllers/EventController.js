'use strict';

eventsApp.controller('EventController',
    function EventController($scope, eventDataService) {

        $scope.myStyle = { color: 'red' };
        $scope.myClass = "blue";
        $scope.sortOrder = 'creatorName';

        $scope.event = eventDataService.getEvent().then(function(data) {
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