(function (ng) {

    //PascalCase filter / format a string with pascal case notation splitting thewords and lower casing the words first
    function filterFactory($filter) {

        return function (input) {
            switch (input) {
                case "Submitted":
                    return "Pending Approval";
                case "StpRejected":
                    return "Stp Rejected";
                default:
                    return input;
            }
        };

    } //end filter

    angular.module('BookApp').filter('status', ['$filter', filterFactory]);

})(angular);