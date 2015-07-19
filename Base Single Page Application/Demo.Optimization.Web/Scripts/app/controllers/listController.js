angular.module("books")
    .controller("BookListCtrl", ['$scope', 'BookService', function($scope, BookService) {
        $scope.books = BookService.getAll();

        $scope.removeBook = function(book) {
            BookService.remove(book);
        };
    }]);