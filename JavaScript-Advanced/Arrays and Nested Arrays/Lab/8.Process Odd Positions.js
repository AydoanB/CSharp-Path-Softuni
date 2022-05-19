function solve(num = []) {

    return num.map((v, i) => {
        if (i % 2 == 1) {
            return v * 2;
        }
    }).reverse().join(' ');
}
console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));