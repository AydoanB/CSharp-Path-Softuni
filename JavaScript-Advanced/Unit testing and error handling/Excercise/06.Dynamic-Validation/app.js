function validate() {
    let emailReg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    let inputElement = document.getElementById("email");
    inputElement.addEventListener("change", () => {
        if (!emailReg.test(inputElement.value)) {
            inputElement.classList.add("error");
        }
        else{
            inputElement.classList.remove("error");

        }
    })
}