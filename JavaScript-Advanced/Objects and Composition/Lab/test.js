function print() {
    console.log(`${this.name} is printing`);
}
function scan() {
    console.log(`${this.name} is scanning`);
}
function copy() {
    console.log(`${this.name} is copying`);
}

const printer = {
    name: 'AcmePrint',
    print,
    scan,
}

const { print: printerFunc } = printer;
const { ...rest } = printer;
console.log(...printer);
const scanner = {
    name: 'AcmeScan',
    print,
    scan,
}
scanner.type = () => { `Typing ${scanner.name}` };
const copier = {
    name: 'AcmeCopy',
    print,
    scan,
    copy,
}



