function addItem() {
    let menu=document.getElementById("menu");
    let textElement=document.getElementById("newItemText").value;
    let valueElement=document.getElementById("newItemValue").value;

    let optionElement=document.createElement("option");
    optionElement.value=valueElement;
    optionElement.innerHTML=textElement;

    menu.appendChild(optionElement);
    document.getElementById("newItemText").value="";
    document.getElementById("newItemValue").value="";
}