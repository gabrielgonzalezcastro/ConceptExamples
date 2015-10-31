'use strict';

eventsApp.directive('greeting', function () {
        return {
            restrict: 'E',
            replace: true,
            transclude: true,
            template: "<button class='btn' ng-click='sayHello()'>Say Hello</button>",
            controller: function ($scope) { // we can specified a controller a directive in this way,  or create the controller in a separate file and called here by name
                var greetings = ['hello'];
                $scope.sayHello = function () {
                    alert(greetings.join());
                }
                this.addGreeting = function (greeting) {
                    greetings.push(greeting);
                }
            }
        };
    })
    .directive('finnish', function () {
        return {
            restrict: 'A',
            require: '^greeting', // we can share a controller with other directives, with this property 'require' we pass the name of the directive that contain the controller.
                                  //so this directive require the 'greeting' directive in order to work
            link: function (scope, element, attrs, controller) {
                controller.addGreeting('hei'); // this controller, is the controller declare on the 'greeting' directive
            }
        }
    })
    .directive('hindi', function () {
        return {
            restrict: 'A',
            require: '^greeting', // the ^ symbol is used if we have nested directive, so this directive need as a parent the greeting directive.
            // the hindi directive has to be inside a greeting tag in other element(the greeting directive has to have the transclude property in true and in the template the ng-transclude directive. 
            //if we not put this symbol this directive has to be use as a attribute of the greeting tag(directive) in order to work. 
            link: function (scope, element, attrs, controller) {
                controller.addGreeting('नमस्ते');
            }
        }
    });