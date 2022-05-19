function getArticleGenerator(articles) {
    let contentElement = document.getElementById("content");

    return () => {
        articles.forEach(() => {
            let articleElement = document.createElement("article");
            articleElement.textContent = articles.shift();
            contentElement.appendChild(articleElement);
        })
    }
}
