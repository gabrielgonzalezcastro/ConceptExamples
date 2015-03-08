
//RequireJS is a JavaScript file and module loader. It is optimized for in-browser use,
//but it can be used in other JavaScript environments, like Rhino and Node. 
//Using a modular script loader like RequireJS will improve the speed and quality of your code.


//The main script has to use the "require" keyword to add its dependencies
require(["classes/Order"], //required scripts (Order)
    function (Order) { //get Required objects in Order file

        //This function is called when classes/Order.js is loaded.
        //If Order.js calls define(), then this function is not fired until
        //util's dependencies have loaded, and the util argument will hold
        //the module value for "classes/Order".

    var o = new Order(1, "A Customer");
    alert(o.id);
    alert(o.customer.name);

});