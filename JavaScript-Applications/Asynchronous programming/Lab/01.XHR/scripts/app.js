function loadRepos() {
   fetch("https://api.github.com/users/testnakov/repos")
      .then(resp => {
         return resp.json()
      })
      .then(data => {
         console.log(data.responseText)
      })
      .catch(error => error.message)
}