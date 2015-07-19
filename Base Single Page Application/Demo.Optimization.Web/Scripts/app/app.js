angular.module('books', [])
    .config(function($routeProvider) {
        $routeProvider
            .when("/Home", { templateUrl: '/Home/Dashboard' })
            .when("/Books", { templateUrl: '/Home/List' })
            .when("/BookDetails/:id", { templateUrl: '/Home/Details' })
            .when("/BookCreate", { templateUrl: '/Home/Create' })
            .otherwise({ redirectTo: '/Home' });
    });






