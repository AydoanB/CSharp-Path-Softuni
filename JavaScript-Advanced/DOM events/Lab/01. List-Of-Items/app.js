function addItem() {
   let itemsElement = document.getElementById("items");
   let inputElement = document.getElementById("newItemText").value;

   let newItemElement = document.createElement("li");
   newItemElement.textContent = inputElement;
   let hyperlink = document.createElement("a");
   hyperlink.setAttribute("href", "#");
   hyperlink.innerHTML = "      [Delete]";
   hyperlink.addEventListener("click", function (e) {
      let parentElement = document.getElementById("items");
      parentElement.removeChild(newItemElement);
   })

   newItemElement.appendChild(hyperlink)
   itemsElement.appendChild(newItemElement);

   document.getElementById("newItemText").value = "";

}