function solve(list = []) {
    list.sort((f, s) => f.localeCompare(s));

    for (let i = 0; i < list.length; i++) {
        console.log(i+1 + '.' + list[i]);
    }
}
solve(["John", "Bob", "Christina", "Ema"])