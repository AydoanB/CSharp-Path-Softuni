
function solve(arr, sortCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let result = [];
    arr.forEach((row) => {
        row = row.split("|");
        const destinationName = row[0];
        const price = Number(row[1]);
        const status = row[2];
        let ticket = new Ticket(destinationName, price, status);
        result.push(ticket);
    })
    if (sortCriteria == "destination") {
        return result.sort((a, b) => a.destination.localeCompare(b.destination));
    }
    else if (sortCriteria == "price") {
        return result.sort((a, b) => a - b);
    }
    else if (sortCriteria == "status") {
        return result.sort((a, b) => a.status.localeCompare(b.status));
    }
}
// console.log(solve(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'destination'
// ));
console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));