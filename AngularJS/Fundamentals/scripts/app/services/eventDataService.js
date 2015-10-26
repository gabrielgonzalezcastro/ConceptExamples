eventsApp.factory('eventDataService', function ($resource, $q) {
    var resource = $resource('/api/data/:id', { id: '@id' });
    return {
        getEvent: function (eventId) {
            var deferred = $q.defer();
            resource.get({ id: eventId },
                function (event) {
                    deferred.resolve(event);
                },
                function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        save: function (event) {
            resource = $resource('/api/data/:event', { event: '@event' });
            var deferred = $q.defer();
            event.id = 999;
            resource.save(event,
                function (response) { deferred.resolve(response); },
                function (response) { deferred.reject(response); }
            );
            return deferred.promise;
        },
        getAllEvents: function () {
            var deferred = $q.defer();
            resource.query(
                function (event) {
                    deferred.resolve(event);
                },
                function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
    };
});
