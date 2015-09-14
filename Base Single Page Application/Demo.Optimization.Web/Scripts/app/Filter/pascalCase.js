(function (ng) {

    //PascalCase filter / format a string with pascal case notation splitting thewords and lower casing the words first
    function filterFactory($filter) {

        return function (input) {
            if (!input) return null;

            var result = "";
            var words = input.split(/(?=[A-Z])/);
            angular.forEach(words, function(word) {
                if (result.length == 0) {
                    result = result.concat(" ", word);
                } else {
                    result = result.concat(" ", word.toLowerCase());
                }
            });

            return result;
        };

    } //end filter

    angular.module('BookApp').filter('pascalCase', ['$filter', filterFactory]);

})(angular);