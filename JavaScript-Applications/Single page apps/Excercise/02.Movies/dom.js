
export function createDomElement(tagName, attributes = {}, ...items) {
    let element = document.createElement(tagName);
  
    for ([attributeKey, attributeValue] of  Object.entries(attributes)) {
      if (attributeKey === "listeners") {
        for ([eventName, handler] of  Object.entries(attributeValue)) {
          element.addEventListener(eventName, handler);
        }
      } else if(attributeValue) {
        element.setAttribute(attributeKey, attributeValue)
      }
    }
  
    if (items.length > 0) {
      let docFrag = document.createDocumentFragment();
      for (childEl of items) {
        if(typeof childEl === "string") {
          let div = document.createElement("div");
          div.innerHTML = childEl;
          while (div.childNodes.length > 0) {
            docFrag.appendChild(div.childNodes[0]);
          }
        } else if(childEl) {
          docFrag.appendChild(childEl);
        }
      }
  
      element.appendChild(docFrag);
    }
  
    return element;
  }