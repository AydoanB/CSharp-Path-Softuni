function solve(matrix = []) {
    let RowSums = matrix.map(r => r.reduce((a, b) => a + b));
    let ColSums = matrix.reduce((a, b) => a.map((x, i) => x + b[i]));
    const firstRow = RowSums[0];
    const firstCol = ColSums[0];
    let result = false;

    if (RowSums.every(a => a == firstRow) && ColSums.every(a => a == firstCol) && RowSums.every(a => a == firstCol) && ColSums.every(a => a == firstRow)) {
        result = true;
    }

    console.log(result);

}
solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
)
solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
)
solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
)