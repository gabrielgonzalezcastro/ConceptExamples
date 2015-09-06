
(function (ng, window) {
    var app = angular.module('BookApp', ['restangular', 'ngRoute', 'ui.bootstrap', 'ngSanitize', 'app.bootstrap']);

    app.config([
        'RestangularProvider', '$routeProvider', 'restangularBootstrapperProvider',
        function(restangularProvider, $routeProvider, restangularBootstrapperProvider) {

            restangularBootstrapperProvider.configure(restangularProvider);

            angular.forEach(window.appConfig.angularRoutes, function (route)
            {
                $routeProvider.when(route.url, {
                    templateUrl: route.template + window.appConfig.applicationVersion,
                    controller: route.controller
                });
            });

            $routeProvider.otherwise({ redirectTo: window.appConfig.defaultPath });
        }]);

    app.run([
        '$rootScope', '$sanitize', function($rootScope, $sanitize) {
            window.appConfig.rootScope = $rootScope;
            window.appConfig.sanitize = $sanitize;
        }
    ]);

})(angular, window);






