'use strict';

var eventsApp = angular.module('eventsApp', ['ngRoute', 'ngResource', 'ngCookies'])
 .config(function ($routeProvider, $locationProvider) {
     $routeProvider.when('/',
        {
            templateUrl: 'ang-views/EventList.html',
            controller: 'EventListController'
        });

     $routeProvider.when('/newEvent',
         {
             templateUrl: 'ang-views/NewEvent.html',
             controller: 'EditEventController'
         });
     $routeProvider.when('/cacheSample',
         {
             templateUrl: 'ang-views/CacheSample.html',
             controller: 'CacheSampleController'
         });
     $routeProvider.when('/compileSample',
         {
             templateUrl: 'ang-views/CompileSample.html',
             controller: 'CompileSampleController'
         });
     $routeProvider.when('/cookieSample',
         {
             templateUrl: 'ang-views/CookieStoreSample.html',
             controller: 'CookieStoreSampleController'
         });
     $routeProvider.when('/editProfile',
        {
            templateUrl: 'ang-views/EditProfile.html',
            controller: 'EditProfileController'
        });
     $routeProvider.when('/filterSample',
        {
            templateUrl: 'ang-views/FilterSample.html',
            controller: 'FilterSampleController'
        });
     $routeProvider.when('/localeSample',
        {
            templateUrl: 'ang-views/LocaleSample.html',
            controller: 'LocaleSampleController'
        });
     $routeProvider.when('/timeoutSample',
       {
           templateUrl: 'ang-views/TimeoutSample.html',
           controller: 'TimeoutSampleController'
       });

     $routeProvider.when('/directiveSample',
       {
           templateUrl: 'ang-views/SampleDirective.html',
           controller: 'SampleDirectiveController'
       });
     $routeProvider.when('/directiveControllerSample',
      {
          templateUrl: 'ang-views/DirectiveControllersSample.html'
      });
     $routeProvider.when('/directiveCompileSample',
     {
         templateUrl: 'ang-views/DirectiveCompileSample.html'
     });

     $routeProvider.when('/eventDetail/:eventId',
         {
             templateUrl: '/ang-views/EventDetails.html',
             controller: 'EventController'
             //resolve: {
             //    event: function ($q, $route, eventData) {
             //        var deferred = $q.defer();
             //        eventData.getEvent($route.current.pathParams.eventId)
             //            .then(function (event) { deferred.resolve(event); });
             //        return deferred.promise;
             //    }
             //}
         });
     $routeProvider.otherwise({ redirectTo: '/' });
     //$locationProvider.html5Mode(true); //with this statement we don't have to use the # symbol in the routes(url).
 });
