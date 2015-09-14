(function (ng) {

	//Domain filter - Remove the domain part from a domain\user string
    function filterFactory($filter) {
		
		function domainFilter(input){
			if(input != null && input.indexOf('\\') > 1){
				return input.split("\\")[1];				
			}
			else{
				return input;
			}
		}
		
		return domainFilter;
      
    } //end filter

    angular.module('BookApp').filter('domain', ['$filter', filterFactory]);

})(angular);