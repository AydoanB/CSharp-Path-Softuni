class List {
    constructor() {
        this.numbers = [];

        this.size = 0;

    }
    add(element) {
        this.numbers.push(element);

        this.numbers.sort((a, b) => a - b);

        this.size++;
    }
    remove(index) {
        if (this.numbers.length < index || index < 0) {
            throw new Error("Invalid");
        }
        this.size--;

        this.numbers.splice(index, 1);
        this.numbers.sort((a, b) => a - b);

    }
    get(index) {
        if (this.numbers.length < index || index < 0) {
            throw new Error("Invalid");
        }
        return this.numbers[index];
    }
}
// let list = new List();
// list.add(5);
// list.add(6);
// list.add(7);

// console.log(list.get(1));
// list.remove(1);
// console.log(list.size);
// console.log(list.get(1));

var myList = new List();
for (let i = 0; i < 5; i++) {
    myList.add(i);
}
console.log(myList.numbers);
console.log(myList.size);
myList.remove(0);
console.log(myList.size);
console.log(myList.numbers);

