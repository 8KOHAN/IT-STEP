async function fetchUsers() {
    try {

        const username = document.querySelector(".input-username");

        const response = await fetch(`https://api.github.com/users/${username.value}`);

        const container = document.querySelector(".user-info");
        container.innerHTML = "";
        container.hidden = false

        if (!response.ok) {
            username.value = 'NOT FOUND'
            container.hidden = true
            throw new Error(`Error HTTP: ${response.status}`);
        }

        const data = await response.json();
        console.log("user: ", data);


        const img = document.createElement("img");
        img.src = `${data.avatar_url}`;
        img.alt = 'avatar';
        img.className = "img-user-avatar";
        container.appendChild(img);

        const name = document.createElement('p');
        name.textContent = `${data.name}`;
        container.appendChild(name);

        const count_repos = document.createElement('p');
        count_repos.textContent = `Count Repositories: ${data.public_repos}`;
        container.appendChild(count_repos);

        const url = document.createElement('a');
        url.textContent = `https://github.com/${username.value}`;
        url.href = `https://github.com/${username.value}`;
        container.appendChild(url);

    } catch (error) {
        console.error('Error: ', error);
    }
}
