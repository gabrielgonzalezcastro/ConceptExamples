$(function() {
    
    //#region ClassDefinition

    //Creation of the Customer Class (classes in js has the first letter as capital)
    function Customer(name, company) {

        //public
        this.name = name;
        this.company = company;

        //private
        var mailServer = "mail.google.com";

        this.sendEmail = function(email) {
            alert("email sent via server " + mailServer + "with the content: " + email);
        };
    }

    //#endregion ClassDefinition


    //Program

    var cust = new Customer("Gabriel", "MyCompany");
    cust.sendEmail("Hello World!");


});