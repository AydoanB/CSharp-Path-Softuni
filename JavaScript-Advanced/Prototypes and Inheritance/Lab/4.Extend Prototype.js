
class Person {
    constructor(name, email) {
        this.name = name;
        this.email = email;
    }
    toString() {
        return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
    }
}
function extendProrotype(classToExtend) {
    classToExtend.prototype.species = "Human";
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}
solve(Person);
let p = new Person("asd", "we"); 
console.log(p.species);
console.log(p.toSpeciesString());