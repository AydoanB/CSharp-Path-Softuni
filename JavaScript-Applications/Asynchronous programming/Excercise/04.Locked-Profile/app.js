async function lockedProfile(e) {

    const mainElement = document.getElementById("main");
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;
    const response = await fetch(url);
    const profilesData = await response.json();
    const itterable = Object.values(profilesData);
    for (const person of itterable) {
        //Create elements and put the info 

        const divElement = createDomElement("div", { class: "profile" });
        const photoElement = createDomElement("img", { src: "./iconProfile2.png", class: "userIcon" });
        const labelLockElement = createDomElement("label", {}, "Lock");
        //implement logic for checked
        const radioLock = createDomElement("input", { type: "radio", name: "user1Locked", value: "lock" });
        const labelUnlockElement = createDomElement("label", {}, "Unlock");
        //implement logic for checked
        const radioUnlock = createDomElement("input", { type: "radio", name: "user1Locked", value: "unlock", checked: true });
        
        const labelUsernameElement = createDomElement("label", {}, "Username");
        const usernameInputElement = createDomElement("input", { type: "text", name: "user1Username", value: "", disabled: true, readonly: true });
        //Append visible fields to the div
        divElement.append(photoElement);
        divElement.append(labelLockElement);
        divElement.append(radioLock);
        divElement.append(labelUnlockElement);
        divElement.append(radioUnlock);
        divElement.append(labelUsernameElement);
        divElement.append(usernameInputElement);


        //Create hiden fields
        //Apend hidden fields to div

        //Apend full profile to main element
        mainElement.append(divElement);
    }
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