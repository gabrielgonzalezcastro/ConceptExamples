angular.module("books")
    .controller("HomeCtrl", ['$scope', function($scope) {
        $scope.numberInStock = 8;
        $scope.numberOfAuthors = 4;
    }]);
