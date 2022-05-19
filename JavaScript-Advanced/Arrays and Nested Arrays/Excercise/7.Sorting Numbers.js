function solve(input = []) {
    let length = input.length;
    let n = input.length;
    // Sorting the array elements
    input.sort((a,b)=>a-b);

    // To store modified array
    let tempArr = new Array(n);

    // Adding numbers from sorted array 
    // to new array accordingly
    let ArrIndex = 0;

    // Traverse from begin and end simultaneously
    for (let i = 0, j = n - 1; i <= n / 2
        || j > n / 2; i++, j--) {

        if (ArrIndex < n) {
            tempArr[ArrIndex] = input[i];
            ArrIndex++;
        }

        if (ArrIndex < n) {
            tempArr[ArrIndex] = input[j];
            ArrIndex++;
        }
    }

    // Modifying original array
    for (let i = 0; i < n; i++)
        input[i] = tempArr[i];

    return input;
}
console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]))