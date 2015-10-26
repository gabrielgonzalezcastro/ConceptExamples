'use strict';

eventsApp.factory('cacheService', function ($cacheFactory) {
    return $cacheFactory('myCache', { capacity: 3 });
})