(function solve() {
    String.prototype.ensureStart = function (str) {
        for (let i = 0; i < str.length; i++) {
            if (this[i] != str[i]) {

                return str + " " + this;
            }
            return this;
        }
    }
    String.prototype.ensureEnd = function (str) {
        for (let i = this.length - 1; i > str.length; i--) {
            if (this[i] != str[i]) {
                return this + " " + str;
            }
            return this;
        }

    }
    String.prototype.isEmpty = function () {
        return this.length == 0;
    }
    String.prototype.truncate = function (n) {
        const toStr = this.toString();
        if (toStr.length <= n) {
            return toStr;
        }

        if (toStr.length < 4) {
            let str = toStr.substr(0, toStr.length - n);
            str = str + '.'.repeat(n);
            return str;
        } else {
            const splitted = toStr.split(' ');
            if (splitted.length == 1) {
                return toStr.substr(0, n - 3) + '...';
            } else {
                let result = '';
                for (let i = 0; i < splitted.length; i++) {
                    if (result.length + splitted[i].length <= n - 3) {
                        result += ' ' + splitted[i];
                    } else {
                        return result.trim() + '...';
                    }
                }
                return result + '...';
            }
        }


    }
    String.prototype.format = function (str, ...params) {
        let result = str;
        for (let i = 0; i < params.length; i++) {
            result = result.replace(`{${i}}`, params[i]);
        }
        return result;
    }

})();
let str = 'my string';
console.log(str.ensureEnd('in'));
console.log(str.ensureStart('st'));
console.log(str.isEmpty());
console.log(str.format('The {0} {1} fox',
    'quick', 'brown')
);

