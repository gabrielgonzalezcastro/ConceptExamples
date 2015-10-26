'use strict';

eventsApp.controller('CompileSampleController',
    function CompileSampleController($scope, $compile, $parse) {

        $scope.name = 'Gabriel';
        $scope.markup = '<h3>{{name}}</h3>';


        //$PARSE: Converts Angular expression into a function.
        var fn = $parse('1 + 2');
        console.log(fn());

        var getter = $parse('event.name');

        var context1 = { event: { name: 'AngularJS Boot Camp' } };
        var context2 = { event: { name: 'Code Camp' } };

        console.log(getter(context1));
        console.log(getter(context2));

        console.log(getter(context2, context1));

        var setter = getter.assign;
        setter(context2, 'Code Retreat');

        console.log(context2.event.name);

        ////////////////////////////////////////////////////

        $scope.appendDivToElement = function (markup) {
            //$compile : Compiles an HTML string or DOM into a template and produces a template function, 
            //which can then be used to link scope and the template together.
            $compile(markup)($scope).appendTo(angular.element("#appendHere"));
            return true;
        }
    }
);
