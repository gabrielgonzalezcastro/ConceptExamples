(function (ng) {

    function directiveFactory() {

        return {
            require: ['ngModel'],
            link: function(scope, element, attrs, modelCtrl) {
                var capitalize = function(inputValue) {
                    if (inputValue === undefined)
                        inputValue = "";

                    var capitalized = inputValue.toUpperCase();

                    if (capitalized !== inputValue) {
                        modelCtrl.$setViewValue(capitalized);
                        modelCtrl.$render();
                    }

                    return capitalized;
                };

                modelCtrl.$parsers.unshift(capitalize);
                capitalize(scope[attrs.ngModel]); //capitalize initial value
            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcCapitalize', [directiveFactory]);
})(angular);