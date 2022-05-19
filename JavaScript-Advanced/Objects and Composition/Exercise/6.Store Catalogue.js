function solve(arr) {
    const obj = {};
    let result = [];
    arr.forEach((row) => {
        let [name, productPrice] = row.split(' : ');
        productPrice = Number(productPrice);
        const index = row[0];
        if (!obj[index]) {
            obj[index] = {};
        }
        obj[index][name] = productPrice;

    })
    let sorted = Object.keys(obj).sort((a, b) => a.localeCompare(b));
    for (const key of sorted) {
        let products = Object.entries(obj[key])
            .sort((a, b) => a[0].localeCompare(b[0]));

        console.log(key);
        products.forEach((product) => {
            console.log(`  ${product[0]}: ${product[1]}`)
        })
    }
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'])