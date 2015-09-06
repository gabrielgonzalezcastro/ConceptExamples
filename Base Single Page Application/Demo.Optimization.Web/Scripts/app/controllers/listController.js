(function () {
    
    var listController = function ($scope, bookService) {

        bookService.getAll().then(function (books) {
            $scope.books = books;
        });

        $scope.removeBook = function (book) {
            bookService.remove(book);
        };
    };

    angular.module('BookApp').controller('listController', ['$scope', 'bookService', listController]);
})();