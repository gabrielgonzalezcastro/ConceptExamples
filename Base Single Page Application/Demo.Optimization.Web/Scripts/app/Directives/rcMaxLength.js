(function (ng) {

    function directiveFactory() {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {

                var validate = function(viewValue) {

                    var len = attrs.rcMaxLength;

                    if (!viewValue || !len) {
                        ctrl[0].$setValidity('rcMaxLength', true);
                    } else {

                        var valid = (viewValue && viewValue.length <= len ? 'valid' : undefined);

                        if (valid) {
                            ctrl[0].$setValidity('rcMaxLength', true);
                            return viewValue;
                        } else {
                            ctrl[0].$setValidity('rcMaxLength', false);
                            return viewValue;
                        }
                    }
                };

                ctrl[0].$parsers.unshift(validate);

                attrs.$observe('rcMaxLength', function(len) {
                    return validate(ctrl.viewValue);
                });


            } //end link

        }; //end return

    }; //end directive

    angular.module('BookApp').directive('rcMaxLength', [directiveFactory]);

})(angular);