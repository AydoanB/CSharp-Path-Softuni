/**
 * 
 * @param {array} input 
 */
function solver(input) {
    let result = [];
    input.forEach(el => {
        el = el.split(" ");
        let carObj = {};
        const command = el[0];
        if (command == "create") {
            carObj.name = el[1];
            if (el[2] == "inherit") {
                for (const [key, value] in carObj.el[3]) {
                    Object.create(carObj.el[1])
                }
            }

        }
        else if (command == "set") {
            const name = el[1];
            const keyEL = el[2];
            const value = el[3];
            carObj[name] = {
                [keyEL]: value,
            }
        }
        else if (command == "print") {
            const name = el[1];
            for (const key in carObj.name) {
                result.push(`${key}:${carObj[name][key]}`);
                console.log(result.join(","));
            }
        }
        console.log(carObj);
    })


}
// function solver(input) {
//     const data = {}

//     const instr = {
//         create: (name1, inherits, name2) =>
//             (data[name1] = inherits ? Object.create(data[name2]) : {}),
//         set: (name, key, value) => (data[name][key] = value),
//         print: (name) => {
//             const entry = [];
//             for (const key in data[name]) {
//                 entry.push(`${key}:${data[name][key]}`)
//             }
//             console.log(entry.join(","));
//         },
//     }

//     input.forEach(x => {
//         const [c, n, k, v] = x.split(" ")

//         instr[c](n, k, v)
//     })
// }

solver(['create c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']

);