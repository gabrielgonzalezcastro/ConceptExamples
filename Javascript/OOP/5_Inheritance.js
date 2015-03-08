$(function () {

    //#region ClassDefinition

    //Class Animal
    function Animal(foodType) {

        this.foodType = foodType;

        this.feed = function() {
            alert("Fed the animal: " + this.foodType);
        };
    }

    //Class Cow
    function Cow(color) {
        this.color = color;
    }

    //#endregion ClassDefinition


    ///////////////PROGRAM////////////

    //Inheritance Magic!!!
    Cow.prototype = new Animal("Hay");

    var c = new Cow("White");
    c.feed();
    var test = c instanceof Animal; //true
    var test2 = c instanceof Cow; //true


});