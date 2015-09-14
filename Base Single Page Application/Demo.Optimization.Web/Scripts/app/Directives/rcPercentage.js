(function (ng) {

    function directiveFactory(Numbers) {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {
				
				var decimals = attrs.rcPercentage ? parseInt(attrs.rcPercentage) : 3;
				
				ctrl.$formatters.push(function(input){
					return Numbers.formatNumber(input,decimals);
				});
             
				ctrl.$parsers.push(function(input){
					return Numbers.parseDecimal(ctrl, input, decimals, 3);
				});

            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcPercentage', ['Numbers', directiveFactory]);

})(angular);