
const url = `http://localhost:3030/jsonstore/collections/students`;
window.addEventListener("load", async () => {
    const resp = await fetch(url);
    const data = await resp.json();
    const peoples = Object.values(data);

    const tableElement = document.querySelector("#results tbody");

    for (const person of peoples) {
        const trElement = document.createElement("tr");

        const thFNAme = document.createElement("th");
        thFNAme.innerHTML = person.firstName;

        const thSNAme = document.createElement("th");
        thSNAme.innerHTML = person.lastName;

        const thFNumber = document.createElement("th");
        thFNumber.innerHTML = person.facultyNumber;

        const thGrade = document.createElement("th");
        thGrade.innerHTML = person.grade;

        trElement.append(thFNAme);
        trElement.append(thSNAme);
        trElement.append(thFNumber);
        trElement.append(thGrade);

        tableElement.append(trElement);

    }

})
document.getElementById("form").addEventListener("submit", async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const firstName = formData.get("firstName");
    const lastName = formData.get("lastName");
    const facultyNumber = formData.get("facultyNumber");
    const grade = formData.get("grade");

    const resp = await fetch(url, {
        method: "post",
        headers: {
            "Content-Type": "application-json"
        },
        body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
    })
    console.log(resp);

})