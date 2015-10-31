'use strict';

eventsApp.controller('EventController',
    function EventController($scope, eventDataService, $routeParams, $route) {

        $scope.myStyle = { color: 'red' };
        $scope.myClass = "blue";
        $scope.sortOrder = 'creatorName';

        eventDataService.getEvent($routeParams.eventId).then(function (data) {
            $scope.event = data;
        });

        $scope.reloadPage = function (parameters) {
            //$route is used for deep-linking URLs to controllers and views (HTML partials). 
            //It watches $location.url() and tries to map the path to an existing route definition.
            $route.reload(); //reload without refresh the page
        };
       
        $scope.upVoteSession = function (session) {
            session.upVoteCount++;
        };

        $scope.downVoteSession = function (session) {
            session.upVoteCount--;
        };
    }
);