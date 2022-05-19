function solve(input) {
    //input.join(', ', ' ');
    const regex = /\w+/gm;
    let result = input.match(regex);


    console.log(result.join(', ').toUpperCase())
}

solve('Hi, how are you?')