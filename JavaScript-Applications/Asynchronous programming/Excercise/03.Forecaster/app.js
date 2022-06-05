async function attachEvents() {
    let weatherTypes = {
        Sunny: "&#x2600",
        "Partly sunny": "&#x26C5",
        Overcast: "&#x2601",
        Rain: "&#x2614",
        Degrees: "&#176"
    }
    const inputElement = document.getElementById("location");
    const forecastElement = document.getElementById("forecast");
    const currentForecastElement = document.getElementById("current");
    const upcomingForecastElement = document.getElementById("upcoming");

    const inputButton = document.getElementById("submit");
    inputButton.addEventListener("click", validator)

    async function validator(e) {
        e.preventDefault();
        forecastElement.style.display = "contents";
        const firstUrl = `http://localhost:3030/jsonstore/forecaster/today/${inputElement.value}`;
        const firstResponse = await fetch(firstUrl);
        const firstlocation = await firstResponse.json();
        const locationName = firstlocation.name;

        [type, high, low] = Object.values(firstlocation.forecast);
        let currentWeather = currentWeatherFunc(type, high, low, locationName);
        currentForecastElement.append(currentWeather);

        const secondUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${inputElement.value}`;
        const secondResponse = await fetch(secondUrl);
        const secondData = await secondResponse.json();

        //let [condition, w, h] =secondData.forecast[0];

        let itterable = Object.values(secondData.forecast);
        for (const day of itterable) {
            console.log(day);
            let upcomingForecast = upcomingWeatherFunc(day.low, day.high, day.condition);
            upcomingForecastElement.append(upcomingForecast);
        }
        let divUpcoming = createDomElement("span", { class: "forecast-info" });

        const labelElement = createDomElement("div", { class: "label" }, "Three-day forecast");

        upcomingForecastElement.append(labelElement);
        upcomingForecastElement.append(divUpcoming);


    }

    function createDomElement(tagName, attributes = {}, ...items) {
        let element = document.createElement(tagName);

        for ([attributeKey, attributeValue] of Object.entries(attributes)) {
            if (attributeKey === "listeners") {
                for ([eventName, handler] of Object.entries(attributeValue)) {
                    element.addEventListener(eventName, handler);
                }
            } else if (attributeValue) {
                element.setAttribute(attributeKey, attributeValue)
            }
        }

        if (items.length > 0) {
            let docFrag = document.createDocumentFragment();
            for (childEl of items) {
                if (typeof childEl === "string") {
                    let div = document.createElement("div");
                    div.innerHTML = childEl;
                    while (div.childNodes.length > 0) {
                        docFrag.appendChild(div.childNodes[0]);
                    }
                } else if (childEl) {
                    docFrag.appendChild(childEl);
                }
            }

            element.appendChild(docFrag);
        }

        return element;
    }

    function currentWeatherFunc(wType, highW, lowW, locationNamee) {

        let div = createDomElement("div", { class: "forecasts" });
        let condSymbolElement = createDomElement("span", { class: "forecast-type" }, `${weatherTypes[wType]}`);
        let spanGeneral = createDomElement("span", { class: 'condition' });

        let spanCityElement = createDomElement("span", { class: "forecast-data" }, locationNamee);

        let tempElement = createDomElement("span", { class: "forecast-data" }, `${lowW}${weatherTypes.Degrees}/${highW}${weatherTypes.Degrees}`);

        let typeElement = createDomElement("span", { class: "forecast-data" }, `${wType}`);

        spanGeneral.append(spanCityElement);
        spanGeneral.append(tempElement);
        spanGeneral.append(typeElement);


        div.append(condSymbolElement);
        div.append(spanGeneral);


        return div;
    }
    function upcomingWeatherFunc(dayLow, dayHigh, dayType) {
        const generalSpan = createDomElement("span", { class: "Upcoming" },);

        const symbolSpan = createDomElement("span", { class: "symbol" }, weatherTypes[dayType]);
        const tempSpan = createDomElement("span", { class: "forecast-temp" }, `${dayLow}${weatherTypes.Degrees}/${dayHigh}${weatherTypes.Degrees}`);
        const typeSpan = createDomElement("span", { class: "forecast-type" }, `${dayType}`);

        generalSpan.append(symbolSpan)
        generalSpan.append(tempSpan)
        generalSpan.append(typeSpan);

        return generalSpan;


    }

}

attachEvents();