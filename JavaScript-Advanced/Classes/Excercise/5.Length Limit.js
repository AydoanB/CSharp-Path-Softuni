class Stringer {
    constructor(str, length) {
        this.str = str;
        this.length = length;

        this.innerString = str;
        this.innerLength = length;
    }
    decrease(n) {
        if (this.length - n < 0) {
            this.length = 0;
            this.str = "...";
        }
    }
    increase(n) {
        if (n = this.length) {
            this.str = this.innerString;
            this.length = this.innerLength;
        }
        else {
            this.str = this.innerString.slice(0, n);

        }
    }
    toString() {
        return this.str;
    }
}
let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
