function solution() {
    let word = "";
    let append = (str) => {
        word += str;
    }
    let removeStart = (n) => {
        word=word.slice(n);
    }
    let removeEnd = (n) => {
        word=word.slice(0, -n);
    }
    let print = () => console.log(word);
    return { append, removeStart, removeEnd, print };
}
let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
