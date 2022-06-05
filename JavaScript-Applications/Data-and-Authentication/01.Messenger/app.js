function attachEvents() {
    document.getElementById("submit").addEventListener("click", request);
    document.getElementById("refresh").addEventListener("click", require);
}
async function request(event) {
    event.preventDefault();
    const url = `http://localhost:3030/jsonstore/messenger`;
    const nameElement = document.getElementsByName("author")[0];
    const messageElement = document.getElementsByName("content")[0];

    const messageAuthorObj = {
        author: nameElement.value.trim(),
        content: messageElement.value.trim()
    }

    const response = await fetch(url, {
        method: "post",
        headers: {
            "Content-Type": "application-json"
        },
        body: JSON.stringify(messageAuthorObj)
    })
    nameElement.textContent = "";
    messageElement.textContent = "";

}
async function require(event) {
    event.preventDefault();
    const textAreaElement = document.getElementById("messages");
    textAreaElement.textContent = "";
    const url = `http://localhost:3030/jsonstore/messenger`;

    const response = await fetch(url, {
        method: "get",
        headers: {
            "Content-Type": "application-json"
        }
    })
    const data = await response.json();
    const itterable = Object.values(data);
    for (const message of itterable) {
        textAreaElement.textContent += `${message.author}: ${message.content}\n`;
    }


}
attachEvents();