function solve(arr = []) {
    const obj = {};

    arr.forEach((el) => {
        let [town, product, price] = el.split(' | ');;
        price = Number(price);

        if (!obj[product]) {
            obj[product] = {};
        }
        obj[product][town] = price;
    })
    for (const product in obj) {

        let sort = Object.entries(obj[product]).sort((a, b) => a[1] - b[1]);

        console.log(`${product} -> ${sort[0][1]} (${sort[0][0]})`)
    }
}


solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
)