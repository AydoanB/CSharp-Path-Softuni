function solve(num) {
    let max = num[0][0];

    for (let i = 0; i < num.length; i++) {
        for (let j = 0; j < num[i].length; j++) {

            if (num[i][j] >= max) {
                max = num[i][j];
            }
        }
    }
    return max;
}
console.log(solve([[20, 50, 10],
[8, 33, 145]]
))
console.log(solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
))