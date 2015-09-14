(function (ng) {

    function directiveFactory(Numbers) {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {
				
				ctrl.$formatters.push(function(input){
					var result = Numbers.formatNumber(input, 6);
					return result;
				});
				
				ctrl.$parsers.push(function(input){
					var result = Numbers.parseDecimal(ctrl, input, 6, 2);
					return result;
				});
             

            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcRate', ['Numbers', directiveFactory]);

})(angular);