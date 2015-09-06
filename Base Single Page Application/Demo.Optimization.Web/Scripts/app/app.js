﻿
(function (ng,window, appConfig) {
    var app = angular.module('BookApp', ['ngRoute', 'restangular']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider
             .when("/Home", { controller: 'homeController', templateUrl: '/AngularViews/Dashboard.html' })
             .when("/Books", { controller: 'listController', templateUrl: '/AngularViews/List.html' })
             .when("/BookDetails/:id", { controller: 'detailsController', templateUrl: '/AngularViews/Details.html' })
             .when("/BookCreate", { controller: 'createController', templateUrl: '/AngularViews/Create.html' })
             .otherwise({ redirectTo: '/Home' });

    }]);

})(angular, window, window.appConfig);






