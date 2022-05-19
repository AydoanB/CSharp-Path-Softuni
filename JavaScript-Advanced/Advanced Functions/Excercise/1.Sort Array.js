function sort(input, order) {
    if (order == "asc") {
        input.sort((a, b) => a - b);
    }
    else if (order == "desc") {
        input.sort((a, b) => b-a);
    }
    return input;
}
sort([14, 7, 17, 6, 8], 'asc');
sort([14, 7, 17, 6, 8], 'desc');