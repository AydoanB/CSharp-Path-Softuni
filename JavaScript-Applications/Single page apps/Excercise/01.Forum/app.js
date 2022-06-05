window.addEventListener("load", loadTopics);
const url = "http://localhost:3030/jsonstore/collections/myboard/posts";

async function loadTopics() {
    const topicElement = document.getElementsByClassName("topic-container")[0];

    const buttonPost = document.getElementsByClassName("public")[0];
    buttonPost.addEventListener("click", addTopic);
    const buttonCancel = document.getElementsByClassName("cancel")[0];
    buttonCancel.addEventListener("click", (e) => {
        e.preventDefault();
        clearField();
    })



    const resp = await fetch(url);
    const data = await resp.json();
    const iterrable = Object.values(data);

    for (const post of iterrable) {
        const postDiv = createDomElement("div", { id: post._id });
        postDiv.style.cursor = "pointer";
        postDiv.addEventListener("click", (event) => {
            const postId = event.currentTarget.id;
            location="theme-content.html"
        })
        const postTitle = createDomElement("h2", {}, post.topic);
        postDiv.appendChild(postTitle);
        const dateElement = createDomElement("p", {}, `Date: ${Date()}`);
        postDiv.appendChild(dateElement);
        const usernameElement = createDomElement("p", {}, `Username: ${post.username}`);
        usernameElement.style.textAlign = "center";
        postDiv.appendChild(usernameElement);
        topicElement.append(postDiv);
    }
}

async function addTopic(event) {
    event.preventDefault();
    const formElement = document.querySelector("form");

    const formData = new FormData(formElement);
    const topic = formData.get("topicName");
    const username = formData.get("username");
    const post = formData.get("postText");
    if (topic == "" || username == "" || post == "") {
        return alert("Fields cannot be empty!");
    }
    await fetch(url, {
        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ topic, username, post })
    })
    clearField();
}
function clearField() {
    document.getElementById("topicName").value = "";
    document.getElementById("username").value = "";
    document.getElementById("postText").value = "";
}
function createDomElement(tagName, attributes = {}, ...items) {
    let element = document.createElement(tagName);

    for ([attributeKey, attributeValue] of Object.entries(attributes)) {
        if (attributeKey === "listeners") {
            for ([eventName, handler] of Object.entries(attributeValue)) {
                element.addEventListener(eventName, handler);
            }
        } else if (attributeValue) {
            element.setAttribute(attributeKey, attributeValue)
        }
    }

    if (items.length > 0) {
        let docFrag = document.createDocumentFragment();
        for (childEl of items) {
            if (typeof childEl === "string") {
                let div = document.createElement("div");
                div.innerHTML = childEl;
                while (div.childNodes.length > 0) {
                    docFrag.appendChild(div.childNodes[0]);
                }
            } else if (childEl) {
                docFrag.appendChild(childEl);
            }
        }

        element.appendChild(docFrag);
    }

    return element;
}