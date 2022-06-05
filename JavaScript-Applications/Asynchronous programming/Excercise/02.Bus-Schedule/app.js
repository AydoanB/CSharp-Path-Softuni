function solve() {
    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");
    const labelElement = document.querySelector(".info");
    let nextId = "depot";

    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${nextId}`;
        const response = await fetch(url);
        const stop = await response.json();
        nextId = stop.next;
        console.log(stop);

        labelElement.textContent = `Next stop ${stop.name}`;
        console.log(stop);
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    async function arrive() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${nextId}`;
        const response = await fetch(url);
        const stop = await response.json();
        nextId = stop.next;
        labelElement.textContent = `Arriving at ${stop.name}`;


        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();