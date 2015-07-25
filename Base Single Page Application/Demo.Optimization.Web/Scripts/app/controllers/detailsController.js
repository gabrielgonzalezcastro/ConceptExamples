(function () {
    //Controller Creation
    var detailsController = function ($scope, $routeParams, bookService) {
        var bookId = $routeParams.id;
        $scope.book = bookService.get(bookId);
    };

    angular.module('BookApp').controller('detailsController', ['$scope', '$routeParams', 'bookService', detailsController]);
})();