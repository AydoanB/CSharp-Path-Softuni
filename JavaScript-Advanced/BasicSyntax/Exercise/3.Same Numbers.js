function same(num) {
    let toStr = num.toString();
    let result;
    let sum = 0;
    for (let i = 0; i < toStr.length; i++) {
        if (toStr[0] != toStr[i]) {
            result = false;
            sum += Number(toStr[i]);
        } else {
            result = true;
            sum += Number(toStr[i]);
        }

    }
    console.log(result);
    console.log(sum);

}

