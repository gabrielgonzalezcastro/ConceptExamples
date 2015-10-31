'use strict';

eventsApp.directive('collapsible', function () {
    return {
        restrict: 'E',
        replace: true,
        template: '<div><h4 class="well-title" ng-click="toggleVisibility()">{{title}}</h4><div ng-show="visible" ng-transclude></div> </div>',
        //whereever that the ng-transcude is declare, the content inside the directive is going to be showed in this case in the div
        controller: function ($scope) {
            $scope.visible = true;

            $scope.toggleVisibility = function () {
                $scope.visible = !$scope.visible;
            }

        },
        transclude: true, // indicate that the directive is going to use transclusion.
        //Transclusion is used to show the content(html) beetwen a directive tag. Example:
        //<mydirective ng-transclude>
        //    <p>content</p>
        //<mydirective/>
        scope: {
            title: '@'
        }
    }
});
