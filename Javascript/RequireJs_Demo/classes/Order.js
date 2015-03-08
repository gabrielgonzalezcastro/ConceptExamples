
define(["classes/Customer"], //Required Scripts (Customer)
    function(Customer) {
        
        //Order class definition
        function Order(id,custName) {
            this.id = id;
            this.customer = new Customer(custName);
        }

        return Order;
    });