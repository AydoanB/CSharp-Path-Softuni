function population(inputArr = []) {
    const obj = {};

    for (const input of inputArr) {
        let tokens = input.split(' <-> ');

        let name = tokens[0];
        let population = Number(tokens[1]);

        if (obj[name] == undefined) {
            obj[name] = population;
        }
        else {
            obj[name] += population;
        }
    }
    for (const name in obj) {
        console.log(`${name} : ${obj[name]}`);
    }
}
population(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

);