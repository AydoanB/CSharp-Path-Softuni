function lastKNumbersSequence(n, k) {
  let result = [1];

  for (let i = 1; i < n; i++) {
    let startIndex = Math.max(0, i - k);
    let currentElement = result
      .slice(startIndex, startIndex + k)
      .reduce((acc, el) => acc + el, 0);
    result.push(currentElement);
  }

  return result.join(" ");
}
lastKNumbersSequence(6, 3)