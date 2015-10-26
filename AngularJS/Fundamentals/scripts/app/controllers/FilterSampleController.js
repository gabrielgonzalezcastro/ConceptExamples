'use strict';

eventsApp.controller('FilterSampleController',
    //we can use the $filter service to instantiate the durations filter or inject the filter directly, like in this case
    function FilterSampleController($scope, durationsFilter) 
    {
        $scope.data = {};

        $scope.data.duration1 = durationsFilter(1);
        $scope.data.duration2 = durationsFilter(2);
        $scope.data.duration3 = durationsFilter(3);
        $scope.data.duration4 = durationsFilter(4);

    }
);