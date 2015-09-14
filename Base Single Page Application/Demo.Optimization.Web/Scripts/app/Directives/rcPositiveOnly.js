(function (ng) {

    function directiveFactory() {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {

                elm.bind("keydown keypress", function(event) {
                    if (event.which === 45) { //minus key
                        event.preventDefault();
                    }
                });

            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcPositiveOnly', [directiveFactory]);

})(angular);