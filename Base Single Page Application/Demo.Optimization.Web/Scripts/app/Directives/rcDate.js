(function (ng) {

    function directiveFactory() {

		var format = 'dd/mm/yy';
		
		//Set as readonly if the attribute is specified
		$.datepicker.setDefaults({
			beforeShow: function(i){
				f($(i).attr('readonly')){
					return false;
				}
			}
		});
		
		//convert from 2013-12-31 T00:00:00 to 31/12/2013-12-31
		var fromUtcToUI = function(val){
			
			var parts = val.split('T');
			var dateParts = parts[0].split('-');
			
			var day = dateParts[2];
			var month = dateParts[1];
			var year = dateParts[0];
			
			if(!day || !month || !year) return;
			
			return day + '/' + month + '/' + year;
		};
		
		//convert from 31/12/2013 to 2013-12-31
		var fromUIToUtc = function(val){
			
			var parts = val.split('/');
			var day = parts[0];
			var month = parts[1];
			var year = parts[2];
			
			if(!day || !month || !year) return;
			
			return year + '-' + month + '-' + day;
		};
		
	
        return {
            restrict: 'A',
            require: ['ngModel'],
            scope: {
                ngModel: '='
            },
            link: function (scope, el, attrs, ctrl) {
				
				$(el).datepicker({
					dateFormat: format,
					constraintInput: true,
					changeYear: true,
					onSelect : function(dateText){
						scope.$apply(function(){
							ctrl.$setViewValue(dateText);
						});
					}
				});
				
				var inputGroup = $(el).closest('.input-group-sm');
				if(inputGroup.length > 0){
					inputGroup.find('.input-group-addon').on('click',function(){
						$(el).datepicker("show");
					});
				}
				
				ctrl.$parsers.push(function(value){
					if(value == undefined || value == "") return;
					
					return fromUIToUtc(value);
				});
				
				ctrl.$formatters.push(function(value){
					if(value == undefined) return;
					
					return fromUtcToUI(value);
				});
			
            } //end link

        }; //end return

    } //end directive

    angular.module('BookApp').directive('rcDate', [directiveFactory]);

})(angular);