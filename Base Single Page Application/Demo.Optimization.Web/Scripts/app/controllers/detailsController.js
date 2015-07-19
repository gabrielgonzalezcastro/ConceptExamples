angular.module("books")
    .controller("BookDetailsCtrl", ['$scope', '$routeParams', 'BookService', function ($scope, $routeParams, BookService) {
        var bookId = $routeParams.id;
        $scope.book = BookService.get(bookId);
    }]);