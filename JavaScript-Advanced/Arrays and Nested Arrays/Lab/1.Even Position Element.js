function solve(arr = []) {
  let evenPosition = [];
  for (let i = 0; i < arr.length; i++) {
    if (i % 2 == 0) {
      evenPosition.push(arr[i]);
    }
  }
  console.log(evenPosition.join(" "));
}
solve(["20", "30", "40", "50", "60"]);
