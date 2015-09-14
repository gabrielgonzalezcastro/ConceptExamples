(function (ng) {

    function filterFactory($filter) {
		
		return function(input, showTime){
			var format = showTime ? 'dd/MM/yyyy HH:mm:ss' : 'dd/MM/yyyy';
			return $filter('date')(input, format);
		};
      
    } //end filter

    angular.module('BookApp').filter('displaydate', ['$filter', filterFactory]);

})(angular);