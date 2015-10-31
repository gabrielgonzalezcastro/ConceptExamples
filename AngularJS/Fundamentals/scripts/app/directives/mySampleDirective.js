'use strict';

eventsApp.directive('mySampleDirective', function ($compile) {
    return {
        restrict: 'E', // the directive is going to be declare as a E(ELEMENT), by default this property is A(Attribute).
                        // the other values are C(class) or M(comment)
        template: "<input type='text' ng-model='sampleData' /> {{sampleData}}<br/>",
        scope: { //if I don't declare the 'scope' properties the directive inheritance the parent directive (the scope of the controller)

        }
    };
});