/**
 * 
 * @param {array} input 
 */
function solver(input) {
    let output = [];
    for (const command of input) {
        const splittedCommand = command.split(" ");
        const type = splittedCommand[0];
        const value = splittedCommand[1];
        if (type == "add") {
            output.push(value);
        }
        else if (type == "remove") {
            output.shift(value);
        }
        else if (type == "print") {
            console.log(output.join(','));
        }
    }
}
solver(['add hello', 'add again', 'remove hello', 'add again', 'print']);
// solver(['add pesho', 'add george', 'add peter', 'remove peter','print']);