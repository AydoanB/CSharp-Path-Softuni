function encodeAndDecodeMessages() {
    const buttons = Array.from(document.querySelectorAll("button"));

    buttons[0].addEventListener("click", (e) => {
        let textAreaElements = [...document.querySelectorAll("textarea")];
        let textElement = textAreaElements[0].value;
        let outputElement = textAreaElements[1];
        let encodedText = '';
        Array.from(textElement).forEach(e => {
            encodedText += String.fromCharCode(e.charCodeAt(0) + 1);
        })
        textAreaElements[0].value = "";
        outputElement.value=encodedText;
    })
    buttons[1].addEventListener("click", (e) => {
        let textAreaElements = [...document.querySelectorAll("textarea")];
        let textElement = textAreaElements[1].value;
        let outputElement = textAreaElements[0];
        let encodedText = '';
        Array.from(textElement).forEach(e => {
            encodedText += String.fromCharCode(e.charCodeAt(0) - 1);
        })
        outputElement.value=encodedText;
    })
}