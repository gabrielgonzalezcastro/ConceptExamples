'use strict';

eventsApp.directive('eventThumbnail', function () {
    return {
        restrict: 'E',
        templateUrl: '/ang-views/directives/eventThumbnail.html',
        replace: true, //this is for replace the tag of the directive (event-thumbnail) for the template, if we don't set this the tag  event-thumbnail appear on the html
        scope: { //create a isolate scope
            event: "=event" //declaring a event property in the isolate scope that is going to receive the value 
            //from a attribute in the directive called event.

            //I can declare my attribute like myEvent, so in the html I have to use it like my-event
        }

    }
});
