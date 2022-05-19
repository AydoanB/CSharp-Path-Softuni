function solve(arr = []) {
    let result = [];
    arr.sort((a, b) => a - b);
    const [first, second] = arr;
    return first + ' ' + second;
}
console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));