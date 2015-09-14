(function (ng) {

	//Domain filter - Remove the domain part from a domain\user string
    function filterFactory($filter) {
		
		return function(input, symbol){
			if(symbol == undefined){
				symbol = "";
			}
			
			return $filter('currency')(input,symbol);
		};
      
    } //end filter

    angular.module('BookApp').filter('money', ['$filter', filterFactory]);

})(angular);