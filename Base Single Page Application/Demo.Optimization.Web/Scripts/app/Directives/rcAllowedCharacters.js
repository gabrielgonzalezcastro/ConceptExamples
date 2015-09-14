(function(ng) {

    function directiveFactory() {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function(scope, elm, attrs, ctrl) {

                //keypress
                elm.bind('keypress', function(e) {
                    var allowedChars = new RegExp("^[a-zA-Z0-9\-/?:().,+]+$");
                    var str = String.fromCharCode(e.which || e.charCode || e.keyCode), matches = [];

                    if (allowedChars.test(str)) {
                        return true;
                    }
                    e.preventDefault();
                    return false;
                });

                //keyup
                elm.bind('keyup', function(e) {
                    var allowedChars2 = new RegExp("^[a-zA-Z0-9\-/?:().,+]+$");
                    if (allowedChars2.test(elm.val())) {
                        return true;
                    }

                    elm.val("");
                    $scope.$apply(function() {
                        scope.ngModel = null;
                        ctrl[0].$setValidity('rcMaxLength', true);
                    });
                    e.preventDefault();

                    return false;
                });

            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcAllowedCharacters', [directiveFactory]);

})(angular);