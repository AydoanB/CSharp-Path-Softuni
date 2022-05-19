function calculator() {
    let numberOneElement;
    let numberTwoElement;
    let resultElement;

    let sumButton = document.getElementById("sumButton");
    let subtractButton = document.getElementById("subtractButton");




    function init(selector1, selector2, resultSelector)
    {
        numberOneElement = document.querySelector(selector1);
        numberTwoElement = document.querySelector(selector2);
        resultElement = document.querySelector(resultSelector);
    }
    function add() {
        let num1 = Number(numberOneElement.value);
        let num2 = Number(numberTwoElement.value);
        let result = num1 + num2;
        resultElement.value = result;
    }
    function substract() {
        let num1 = Number(numberOneElement.value);
        let num2 = Number(numberTwoElement.value);
        let result = num1 - num2;
        resultElement.value = result;
    }
    return { init, add, substract };

}
const calculate = calculator (); 
calculate.init('#num1', '#num2', '#result');



