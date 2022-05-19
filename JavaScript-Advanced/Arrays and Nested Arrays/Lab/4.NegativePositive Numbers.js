function solve(arr = []) {
    const result = []
    for (const num of arr) {
        if (num >= 0) {
            result.push(num);
        }
        else {
            result.unshift(num);
        }
    }
    return result.join('\n');
}