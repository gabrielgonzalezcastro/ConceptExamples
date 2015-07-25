(function () {
    
    var listController = function ($scope, bookService) {

        $scope.books = bookService.getAll();

        $scope.removeBook = function (book) {
            bookService.remove(book);
        };
    };

    angular.module('BookApp').controller('listController', ['$scope', 'bookService', listController]);
})();