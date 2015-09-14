(function () {

    var appController = function ($scope) {

        $scope.$on('Restangular_HideLoading', function (ev, response) {
            $('#loading').removeClass('shown');
            $('#container-loading').removeClass('shown');
        });

        $scope.$on('Restangular_ShowLoading', function (ev, response) {
            $('#loading').addClass('shown');
            $('#container-loading').addClass('shown');
        });

        $scope.$on('Restangular_ServerError', function (ev, response) {
            $scope.setException(response);
            $('#errorModal').trigger('show');
        });

        $scope.$on('Restangular_TokenExpired', function (ev, response) {
            $scope.setException(response);
            $('#tokenExpiredModal').trigger('show');
            _.delay(function () {
                location.href = '/Home/Login';
            }, 4000);
        });

        $scope.$on('Restangular_BadRequest', function (ev, response) {
            $scope.setException(response);
            $('#badRequestModal').trigger('show');
        });

        $scope.closeErrorModal = function() {
            $('#errorModal').trigger('hide');
        };

        $scope.closeBadRequestModal = function () {
            $('#badRequestModal').trigger('hide');
        };

        $scope.applicationVersion = window.appConfig.applicationVersion;


        $scope.setException = function (response) {
            $scope.appConfig = $scope.appConfig || {};

            if (response.message == 'DB concurrency violation.' || response.message.indexOf('Cannot insert duplicate key row in object') != -1) {
                $scope.appConfig.currentException = {
                    title: 'Database concurrency violation',
                    message: 'The data you are trying to save has already been modified by another user. Try reloading the data first before saving attempt'
                };
            } else {
                $scope.appConfig.currentException = {
                    title: response.title,
                    message: response.message
                };
            }

        };


    };

    angular.module('BookApp').controller('appController', ['$scope', appController]);
})();