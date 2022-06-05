function attachEvents() {
    document.getElementById("btnCreate").addEventListener("click", postContact);
    document.getElementById("btnLoad").addEventListener("click", loadContacts);
}
async function postContact(event) {
    event.preventDefault();
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const person = document.getElementById("person").value;
    const phone = document.getElementById("phone").value;

    await fetch(url, {
        method: "post",
        headers: {
            "Content-Type": "application-json"
        },
        body: JSON.stringify({ person, phone })
    });


}
async function loadContacts(event) {
    event.preventDefault();
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const phonebookElement = document.getElementById("phonebook");

    const response = await fetch(url);
    const data = await response.json();
    const contacts = Object.values(data);
    for (const contact of contacts) {
        const liElement = document.createElement("li");
        liElement.append(`${contact.person}: ${contact.phone}`);
        liElement.setAttribute("id", contact._id);
        const buttonDelete = document.createElement("button");
        buttonDelete.textContent = "Delete";
        //finish delete function
        buttonDelete.addEventListener("click", async () => {
            await fetch(`http://localhost:3030/jsonstore/phonebook/${liElement.id}`, {
                method: "delete"
            });
            phonebookElement.removeChild(liElement);
            phonebookElement.removeChild(buttonDelete);
        });
        phonebookElement.append(liElement);
        phonebookElement.append(buttonDelete);
    }

}

attachEvents();