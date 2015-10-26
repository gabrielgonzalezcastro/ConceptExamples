'use strict';

eventsApp.controller('LocaleSampleController',
    function LocaleSampleController($scope, $locale) {
        console.log($locale);
        $scope.myDate = Date.now();

        //$locale service provides localization rules for various Angular components
        $scope.myFormat = $locale.DATETIME_FORMATS.fullDate;

    }
);
