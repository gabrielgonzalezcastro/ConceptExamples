
//Extending the Array Object to add it a new function called "calculateCount"
Array.prototype.calculateCount = function() {
    return this.length;
};


//////PROGRAM////
var a = ["1", "2"];
var count = a.calculateCount();
alert(count);
