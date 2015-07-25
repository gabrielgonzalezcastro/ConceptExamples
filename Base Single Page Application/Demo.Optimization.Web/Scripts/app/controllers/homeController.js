(function () {
    //Controller Creation
    var homeController = function ($scope) {
        $scope.numberInStock = 8;
        $scope.numberOfAuthors = 4;
    };

    angular.module('BookApp').controller('homeController', ['$scope', homeController]);
})();