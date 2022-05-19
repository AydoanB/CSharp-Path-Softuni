function solve(m) {
    let pD = Number();
    let sD = Number();

    for (let row = 0; row < m.length; row++) {
        for (let col = 0; col < m[row].length; col++) {
            if (row == col) {
                pD += m[row][col];
            }
            //if ((i + j) == (n - 1))
            if ((row + col) == (m.length - 1)) {
                sD += m[row][col];
            }
        }
    }
    console.log(pD, sD);

}

solve([[20, 40],
[10, 60]]
);
solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]

);