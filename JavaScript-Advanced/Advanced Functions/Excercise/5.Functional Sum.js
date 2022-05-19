function a(n) {
    return function b(m) {
        return function c(k) {
            return Number(n + m + k);
        }
    }
}
console.log(a(1)(6)(-3));