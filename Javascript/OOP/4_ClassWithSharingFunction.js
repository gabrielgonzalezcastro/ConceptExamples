$(function () {

    //#region ClassDefinition


    function Customer(name, company) {

        this.name = name;
        this.company = company;
    }

    //With protoype I can share the member to all the instances. it is no more a static member
    Customer.prototype.mailServer = "mail.google.com";

    //With protoype I can share the function to all the instances. it is no more a static member
    Customer.prototype.sendEmail = function (msg) {
        //I can use a member define in the object. "This" keyword hace referencia al objeto que es dueno de la function
        //en este caso la clase Customer.
        var svr = this.mailServer;
        alert("email sent via server: " + svr + " with the message: " + msg);
    };

    //#endregion ClassDefinition


    ///////////////////////Program

    var cust = new Customer("Gabriel", "MyCompany");
    //now the method and the member it is share with all the instances
    alert(cust.mailServer);
    cust.sendEmail("Hello World");


});