function rotation(arr = [], amount) {

    for (let i = 0; i < amount; i++) {
        arr.unshift(arr.pop());
    }

    console.log(arr.join(' '));
}
rotation(['1',
    '2',
    '3',
    '4'],
    1
)
rotation(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
)