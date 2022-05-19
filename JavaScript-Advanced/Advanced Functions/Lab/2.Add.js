function solution(n) {
    let number = n;
    return function add(m) {
        return number + m
    }
}
let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
