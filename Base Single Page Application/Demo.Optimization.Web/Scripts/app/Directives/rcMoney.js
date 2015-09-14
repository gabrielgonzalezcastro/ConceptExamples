(function (ng) {

    function directiveFactory(Numbers, moneyFilter) {

        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, elm, attrs, ctrl) {
				
				var allowedDecimals = attrs.rcNoDecimals ? parseInt(attrs.rcNoDecimals) : 2;
				
				ctrl.$parsers.push(function(input){
					if(!input)
						return input;
					var val = accounting.unformat(input);
					
					//check if it's a valid number
					if(!Numbers.isNumber(input.replace(/,/g,""))){
						ctrl.$setValidity('rcMoney', false);
					}
					else{
						ctrl.$setValidity('rcMoney', true);
					}
					
					return val;					
				});
				
				ctrl.$formatters.push(function(input){
					if(!input) return input;
					return accounting.formatNumber(input, allowedDecimals);
				});
				
				//events bindings
				elm.on('blur', function(){
					if(ctrl.$viewValue != null){
						
						if(ctrl.$viewValue.toString().indexOf(",") > 1){
							ctrl.$viewValue = ctrl.$viewValue.replace(new RegExp(",",'g'),"");
						}
						
						var result = moneyFilter(ctrl.$viewValue);
						ctrl.$viewValue = result;
						ctrl.$render();
					}
				});
				
				elm.on('focus',function(){
					
					if(ctrl.$modelValue != null){
						
						if(ctrl.$modelValue.toString().indexOf(",") > 1){
							ctrl.$modelValue = ctrl.$modelValue.replace(new RegExp(",",'g'),"");							
						}
						
						var result = Numbers.parseMoney(ctrl, ctrl.$modelValue);
						ctrl.$viewValue = result;
						ctrl.$render();
					}
				});
				
			
            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcMoney', ['Numbers', 'moneyFilter', directiveFactory]);

})(angular);