(function () {

    var bookService = function (Restangular) {

        var base = Restangular.all("Book");

        return {
            add: function (book) {
                var maxId = _.max(books, function (b) { return b.bookId; }).bookId;
                book.bookId = ++maxId;
                books.push(book);
                toastr.info("New Book: " + book.title);
            },
            remove: function (book) {
                var index = _.indexOf(books, book);
                if (index >= 0) {
                    books.splice(index, 1);
                }
            },
            get: function (bookId) {
                return base.get(bookId + '/detail');
            },
            getAll: function () {
                return base.getList();
            },
            //getById : function(id) {
            //    return Restangular.one('Book', id).get();
            //},
            //getWithLock: function(id) {
            //    return Restangular.one('Book', id).customGET("", { lockBook: true });
            //},
            //reject: function(rejectBook) {
            //    return base.customPOST(rejectBook, "reject");
            //},
            //checkDate: function( date, currency) {
            //    return base.customGET("checkDate", { date: date, currency: currency });
            //}
        };
    };

    angular.module('BookApp').service('bookService', ['Restangular', bookService]);


}());