function solve(num = []) {
    const sum = Number(num.pop()) + Number(num.shift());

    return sum;
}
console.log(solve(['20', '30', '40']));