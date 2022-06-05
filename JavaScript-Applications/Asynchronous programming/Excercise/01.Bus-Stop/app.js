async function getInfo() {
    const bus = document.getElementById("stopId").value;
    const stopNameElement = document.getElementById("stopName");
    const busesElement = document.getElementById("buses");

    const resp = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${bus}`);
    const data = await resp.json();
    let iterrating = Object.entries(data.buses);
    stopNameElement.textContent = data.name;

    for (const buses of iterrating) {
        const liElement = document.createElement("li");
        liElement.innerHTML = `Bus ${buses[0]} arrives in ${buses[1]} minutes`;
        liElement.style.textAlign = "left";
        busesElement.append(liElement);
    }
}