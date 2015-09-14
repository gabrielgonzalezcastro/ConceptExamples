(function (ng) {

    function directiveFactory() {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {

                elm.bind('keypress', function(e) {
                    var allowedChars = new RegExp("^[0-9]+$");
                    var str = String.fromCharCode(e.which || e.charCode || e.keyCode), matches = [];
                    if (allowedChars.test(str))
                        return true;

                    e.preventDefault();
                    return false;
                });

            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcOnlyNumbers', [directiveFactory]);

})(angular);