$(function () {

    //#region ClassDefinition


    function Customer(name, company) {

        this.name = name;
        this.company = company;
    }

    //creation of the static member. It can be call only using the Class
    Customer.mailServer = "mail.google.com";

    //#endregion ClassDefinition


    //Program

    var cust = new Customer("Gabriel", "MyCompany");
    //var svr = cust.mailServer; // Nope
    //We have to use the Class itself not the instance because the member is static
    alert(Customer.mailServer);


});