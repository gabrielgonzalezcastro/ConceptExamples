(function (ns) {

    //Just define the code and  add it  to the namespace.
    ns.Customer = function (name) {
        this.name = name;
    };

}(window.GonzalezNamespace = window.GonzalezNamespace || {})); //pass the namespace to the function call GonzalezNamespace if it is created, if not it is create
