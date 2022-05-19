(function solve() {
    Array.prototype.last = function () {
        return this[this.prototype.length - 1];
    }
    Array.prototype.skip = function (n) {
        // n = Number(n);
        // return Array.prototype.slice(0, n);
        let result = [];
        for (let i = n; i < this.length; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.take = function (n) {
        n = Number(n);
        return Array.prototype.splice(0, n);
    }

    Array.prototype.sum = function () {
        return Array.prototype.reduce((acc, curr) => acc + curr);
    }
    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();

let arr = [1, 2, 3, 4];
console.log(arr.sum());
