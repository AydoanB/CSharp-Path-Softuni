function obj(order = []) {
    const result = {};

    for (let i = 0; i < order.length; i += 2) {
        result[order[i]] = Number(order[i + 1]);
    };
    return result;
}
console.log(obj(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));