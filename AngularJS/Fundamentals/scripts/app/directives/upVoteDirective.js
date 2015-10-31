'use strict';

eventsApp.directive('upvote', function () {
    return {
        restrict: 'E',
        templateUrl: '/ang-views/directives/upvote.html',
        replace: true,
        scope: { //declaring a isolate scope for this directive
            upvote: "&",  //declaring a 'upvote' property in the isolate scope, '&' means that is going to receive a function 
                             //from a attribute in the directive called 'upvote'. This function is going to be execute in the parent scope(in this case in the controller )
            downvote: "&", // same as upvote
            count: "=" //the directive is going to have a attribute called 'count', and here I am receiving the value

            //@ symbol means that we expect in the attribute a string. if we use for example @ for count we should pass {{session.upVoteCount}}
        }

    }
});
