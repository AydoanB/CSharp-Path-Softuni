let unitsObj = {
    "cm": 1,
    "mm": 10,
    "m": 10,
}

class Figure {
    constructor(unit = "cm") {
        this.units = unit;
    }
    get area() {
        return null;
    }
    changeUnits(value) {
        this.units == value;
    }
    toString() {
        return `Figures units: ${this.units}`
    }
}
class Circle extends Figure {
    constructor(radius, unit) {
        super(unit);
        this.radius = radius;
    }
    get area() {
        if (this.units == "cm") {
            return (Math.PI * this.radius ** 2);
        }
        else if (this.units == "mm") {
            return (Math.PI * this.radius ** 2) * 100;
        }
        else if (this.units == "m") {
            return (Math.PI * this.radius ** 2) / 100;
        }
    }
    toString() {
        return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`
    }
}
class Rectangle extends Figure {
    constructor(width, height, unit) {
        super(unit);
        this.width = width;
        this.height = height;
    }
    get area() {
        if (this.units == "cm") {
            return (this.width * this.height);
        }
        else if (this.units == "mm") {
            this.width *= 1;
            this.height *= 1;
            return (this.width * this.height);
        }
        else if (this.units == "m") {
            return (this.width * this.height) / 100;
        }
    }
    toString() {
        return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`
    }
}
// let c = new Circle(5);
// console.log(c.area); // 78.53981633974483
// console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

// r.changeUnits('cm');
// console.log(r.area); // 12
// console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

// c.changeUnits('mm');
// console.log(c.area); // 7853.981633974483
// console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
