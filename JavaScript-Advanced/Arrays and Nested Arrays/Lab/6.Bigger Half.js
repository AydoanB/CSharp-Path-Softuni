function biggerHalf(num = []) {
    num.sort((a, b) => a - b).splice(0, num.length / 2).join(', ');

    return num;
}
console.log(biggerHalf([4, 7, 2, 5]));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]))