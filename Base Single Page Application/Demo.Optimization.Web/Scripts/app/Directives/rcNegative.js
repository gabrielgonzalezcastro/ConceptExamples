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
					return Numbers.formatNumber(input, 6);
				});
				
				ctrl.$parsers.push(function(input){
					if(input == '-')
						input = '-0';
					
					return Numbers.parseNegative(ctrl, input, 6, 2);
				});
			
            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcNegative', ['Numbers', directiveFactory]);

})(angular);