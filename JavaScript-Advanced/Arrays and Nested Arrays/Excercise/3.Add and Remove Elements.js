function solve(commands = []) {
    let n = 1;
    const output = [];
    for (const command of commands) {
        if (command == 'add') {
            output.push(n);
            n++;
        }
        else if (command == 'remove') {
            output.pop();
            n++;
        }
    }
    if (output.length == 0) {
        console.log('Empty');
    }
    else {
        console.log(output.join('\n'));
    }
}
solve(['add',
    'add',
    'add',
    'add']

)
solve(['add',
    'add',
    'remove',
    'add',
    'add']
)
solve(['remove',
    'remove',
    'remove']
)