function create(words) {
   let parentElement=document.getElementById("content");

   words.forEach((word)=>{

      let divElement=document.createElement("div");
      let pElement=document.createElement("p");
      pElement.innerText=word;
      pElement.style.display="none";

     divElement.addEventListener("click",(e)=>{
      e.target.children[0].style.display="";
        })
     divElement.appendChild(pElement);
     parentElement.appendChild(divElement);
     
   })

   
}


   // let parentElement = document.getElementById("content");
   //    parentElement.display="none";
   //    let newDivElement = document.createElement("div");

   //    newDivElement.addEventListener("click", (e) => {
   //       let newPElement = document.createElement("p");
         
   //       newPElement.textContent = word;
   //       newDivElement.appendChild(newPElement);
        
   //       parentElement.append(newDivElement);
   //       e.style.display = "block";