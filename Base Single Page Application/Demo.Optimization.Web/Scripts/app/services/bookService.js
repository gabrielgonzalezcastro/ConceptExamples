(function () {

    var bookService = function () {

        var books = [
            { bookId: 1, title: 'To Kill a Mockingbird', author: { firstName: 'Harper', lastName: 'Lee' }, numberInStock: 2, numberPurchases: 4 },
            { bookId: 2, title: 'The Great Gatsby', author: { firstName: 'Scott', lastName: 'Fitzgerald' }, numberInStock: 2, numberPurchases: 6 }
        ];

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
                return _.findWhere(books, { bookId: parseInt(bookId) });
            },
            getAll: function () {
                return books;
            }
        };
    };

    angular.module('BookApp').service('bookService', bookService);


}());