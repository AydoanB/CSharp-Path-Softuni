function solve(m) {
    let equalCounter = Number();
    const map = new Map();
    let count = 0;
    for (let row = 1; row < m.length - 1; row++) {
        for (let col = 1; col < m[row].length - 1; col++) {
            let current = m[row][col];
            if (current == m[row - 1][col - 1] || current == m[row - 1][col] || current == m[row - 1][col + 1] || current == [row][col - 1] || current == m[row][col + 1] || current == m[row + 1][col - 1] || current == m[row + 1][col] || current == m[row + 1][col + 1]) {

                map.set(current, count++);
            }
        }
    }
    console.log(map.size);
}

solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
);

solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
)