export function showYears() {
    const body = document.querySelector("body");
    const yearsElement = document.getElementById("years");
    
    body.replaceChildren();
    body.append(yearsElement);

}

