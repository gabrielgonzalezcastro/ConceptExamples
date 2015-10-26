'use strict';

eventsApp.controller('CacheSampleController',
    function CacheSampleController($scope, cacheService) {
        $scope.addToCache = function (key, value) {
            cacheService.put(key, value);
        };

        $scope.readFromCache = function (key) {
            return cacheService.get(key);
        };

        $scope.getCacheStats = function () {
            return cacheService.info();
        };
    }
);
