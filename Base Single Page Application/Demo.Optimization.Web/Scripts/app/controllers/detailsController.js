(function () {
    //Controller Creation
    var detailsController = function ($scope, $routeParams, bookService) {
        var bookId = $routeParams.id;

        bookService.get(bookId).then(function (book) {
            $scope.book = book;
        });

        
    };

    angular.module('BookApp').controller('detailsController', ['$scope', '$routeParams', 'bookService', detailsController]);
})();