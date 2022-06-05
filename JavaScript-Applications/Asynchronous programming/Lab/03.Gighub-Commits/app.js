function loadCommits() {
    let username = document.getElementById("username");
    let repo = document.getElementById("repo");
    let commits = document.getElementById("commits");

    // async function makeRequest() {
    //     try {
    //         const resp = await fetch(`https://api.github.com/repos/${username.value}/${repo.value}/commits`);
    //         if (resp.ok == false) {
    //             throw new Error(`${resp.status} ${resp.statusText}`);
    //         }
    //         const data = await resp.json();
    //         console.log(data);
    //     } catch (error) {
    //         console.log(error);
    //     }
    // }
    fetch(`https://api.github.com/repos/${username.value}/${repo.value}/commits`)
        .then(response => {
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`);
            }
            return response.json()
        })
        .then(responseHandler)
        .catch(error => commits.append(error));

    function responseHandler(data) {

        for (const repo of data) {

            let liElement = document.createElement("li");
            liElement.innerHTML = `${repo.commit.author.name}: ${repo.commit.message}`;
            commits.append(liElement);
        }
    }
    
}