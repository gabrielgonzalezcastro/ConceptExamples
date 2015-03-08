$(function() {
    var o = new GonzalezNamespace.Order(1, "A Customer");
    alert(o.id);
    alert(o.customer.name);
});