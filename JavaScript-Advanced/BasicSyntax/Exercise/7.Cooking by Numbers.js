function actions(operations) {
    let n = Number(operations[0]);

    for (let i = 1; i < operations.length; i++) {
        if (operations[i] == 'chop') {
            n /= 2;
            return n;
        } else if (operations[i] == 'dice') {
            n = Math.sqrt(n);
            return n;
        } else if (operations[i] == 'spice') {
            n += 1;
            return n;
        } else if (operations[i] == 'bake') {
            n *= 3;
            return n;
        } else if (operations[i] == 'fillet') {
            n = n - 0.20 * n;
            return n;
        }
    }
}

actions(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
console.log();
actions([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);