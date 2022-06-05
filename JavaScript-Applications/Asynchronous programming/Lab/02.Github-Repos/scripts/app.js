function loadRepos() {
	let user = document.getElementById("username");

	let list = document.getElementById("repos");

	fetch(`https://api.github.com/asdusers/${user.value}/repos`)
		.then(resp => {
			if (resp.status == 404) {
				throw new Error(`${resp.status} ${resp.statusText}`);
			};
			return resp.json()
		})
		.then(data => {
			[...list.children].forEach(child => list.removeChild(child));
			for (const element of data) {

				let il = document.createElement("li");
				il.innerHTML = `<a href=${element.html_url}> ${element.full_name} </a>`;
				list.append(il);
			}
		})
		.catch(error => {
			[...list.children].forEach(child => list.removeChild(child));
			let li = document.createElement("li");
			console.log(error);
		})
}