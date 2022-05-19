function attachGradientEvents() {
    const gradient = document.getElementById("gradient");
    const output=document.getElementById("result");
    gradient.addEventListener("mousemove", function (e) {
        const box = e.target;
        const offset = Math.floor(e.offsetX / box.clientWidth * 100);
        
        output.textContent = `${offset}%`;
    });

}