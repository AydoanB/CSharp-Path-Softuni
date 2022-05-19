function solve(arr = []) {
    let result = [];

    const splitedRow0 = arr[0].split('|');

    const town = splitedRow0[1].trim();
    const latitude = splitedRow0[2].trim();
    const longitude = splitedRow0[3].trim();

    for (let i = 1; i < arr.length; i++) {
        const obj = {};
        const splitted = arr[i].split('|');

        obj[town] = splitted[1].trim();
        obj[latitude] = Number(Number(splitted[2].trim()).toFixed(2));
        obj[longitude] = Number(Number(splitted[3].trim()).toFixed(2));
        result.push(obj);
    }
    console.log(JSON.stringify(result));
}
solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);