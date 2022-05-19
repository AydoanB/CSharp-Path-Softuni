function solver() {
    let result = {};
    for (const argument of arguments) {
        let currentArgumentType = typeof argument;
        if (!result[currentArgumentType]) {
            result[currentArgumentType] = 0;
        }
        result[currentArgumentType]++;

        console.log(`${currentArgumentType}: ${argument}`);
    }
    let toArr = Object.entries(result);
    toArr.sort((a, b) => b[1] - a[1]);
    for (const result of toArr) {
        console.log(`${result[0]} = ${result[1]}`);
    }
}


solver('cat', 42, function () { console.log('Hello world!'); })