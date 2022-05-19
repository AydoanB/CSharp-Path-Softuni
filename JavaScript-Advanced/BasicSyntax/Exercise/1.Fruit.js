function fruit(a, b, c) {
  let ToKg = (b / 1000).toFixed(2);
  let pricePerKg = (b * c) / 1000;

  console.log(
    `I need $${pricePerKg.toFixed(2)} to buy ${ToKg} kilograms ${a}.`
  );
}

fruit("orange", 2500, 1.8);
