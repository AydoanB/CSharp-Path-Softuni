export async function login() {
    const section = document.getElementById("form-login");
    const form = section.querySelector("form");

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        console.log(form);
    })
}