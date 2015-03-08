(function(ns) {

    //Define the new object and add it  to the namespace
    ns.Order = function(id, custName) {
        this.id = id;
        this.customer = new ns.Customer(custName);
    };

}(window.GonzalezNamespace = window.GonzalezNamespace || {}));
//pass the namespace to the function call GonzalezNamespace if it is created, if not it is create
