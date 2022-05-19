function focused() {
    let textElements = Array.from(document.querySelectorAll("input"));
    textElements.forEach((el) => {
        el.addEventListener("focus", onfocus);
        el.addEventListener("blur", onblur);
    })
    function onfocus(e) {
        e.target.parentNode.classList.add("focused");
    }

    function onblur(e) {
        e.target.parentNode.classList.remove("focused");
    }


}