function solve() {
    const containerElements = document.getElementById("container").children;

    let movieList = document.querySelector('#movies ul');

    containerElements[3].addEventListener("click", (e) => {
        e.preventDefault();
        let liElement = document.createElement("li");

        let nameElement = document.createElement("span");
        nameElement.textContent = containerElements[0].value;
        liElement.appendChild(nameElement);

        let hallElement = document.createElement("strong");
        hallElement.textContent = `Hall: ${containerElements[1].value}`;
        liElement.appendChild(hallElement);

        let divElement = document.createElement("div");

        let priceElement = document.createElement("strong");
        priceElement.textContent = Number(containerElements[2].value).toFixed(2)

        let inputElement = document.createElement("input");
        inputElement.placeholder = "Tickets Sold";

        let buttonArchive = document.createElement("button");
        buttonArchive.textContent = "Archive";
        buttonArchive.addEventListener("click", archiver);
        divElement.appendChild(priceElement);
        divElement.appendChild(inputElement);
        divElement.appendChild(buttonArchive);


        liElement.appendChild(divElement);

        movieList.appendChild(liElement);

        containerElements[0].value = '';
        containerElements[1].value = '';
        containerElements[2].value = '';


    })
    let clearButton = document.querySelector("#archive button");
    clearButton.addEventListener("click", (e) => {
        clearButton.parentElement.children[1].remove();
    })

}
function archiver(e) {
    let liElement = e.target.parentElement.parentElement.children;

    let movieName = liElement[0].textContent;
    let price = liElement[2].firstChild.textContent;
    let ticketsSoldElement = e.target.previousSibling.value;
    let archiveElement = document.getElementById("archive").children[1];
    if (ticketsSoldElement != "") {
        let name = document.createElement("span");
        name.textContent = movieName;
        let strongElement = document.createElement("strong");
        strongElement.textContent = `Total amount:${Number(price * ticketsSoldElement).toFixed(2)}`;
        let button = document.createElement("button");
        button.textContent = "Delete";
        button
        let newLiElement = document.createElement("li");

        newLiElement.appendChild(name);
        newLiElement.appendChild(strongElement);
        newLiElement.appendChild(button);
        archiveElement.appendChild(newLiElement);

        button.addEventListener("click", (e) => {
            e.target.parentElement.remove();
        });
        e.target.parentElement.parentElement.remove();
    }

}