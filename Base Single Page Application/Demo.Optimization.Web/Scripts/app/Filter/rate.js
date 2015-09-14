(function (ng) {

    function filterFactory($filter) {

        return function (input) {
            return input == 0 ? "0.000000" : $filter('number')(input, 6);
        };

    } //end filter

    angular.module('BookApp').filter('rate', ['$filter', filterFactory]);

})(angular);