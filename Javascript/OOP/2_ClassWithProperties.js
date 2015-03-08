$(function () {

    //#region ClassDefinition

    function Customer(name) {

        var _name = name;
        //Creation of the property
        Object.defineProperty(this, "name", {
            get: function() { return _name;},
            set: function(value) { _name = value;}
        });
    }

    //#endregion ClassDefinition

    //Program

    var cust = new Customer("Gabriel");
    alert(cust.name);
    cust.name = "Pedro";
    alert(cust.name);

});