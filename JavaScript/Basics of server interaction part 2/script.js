const usersContainer = document.getElementById("users");
const userDetails = document.getElementById("user-details");
const postsContainer = document.getElementById("posts");

let selectedUserId = null;

loadUsers()

async function loadUsers() {

    const response =
        await fetch("https://jsonplaceholder.typicode.com/users");

    const users = await response.json();

    usersContainer.innerHTML = "";

    users.forEach(user => {

        const div = document.createElement("div");
        div.classList.add("user");

        div.textContent = user.name;

        div.addEventListener("click", () => {
            showUserDetails(user.id);
        });

        usersContainer.appendChild(div);
    });
}

async function showUserDetails(id) {

    selectedUserId = id;

    const response =
        await fetch(`https://jsonplaceholder.typicode.com/users/${id}`);

    const user = await response.json();

    userDetails.innerHTML = `
        <h3>${user.name}</h3>
        <p><b>Email:</b> ${user.email}</p>
        <p><b>Phone:</b> ${user.phone}</p>
        <p><b>Website:</b> ${user.website}</p>

        <button onclick="loadPosts()">
            Show posts
        </button>
    `;
}

async function loadPosts() {

    if (!selectedUserId) return;

    const response =
        await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${selectedUserId}`);

    const posts = await response.json();

    postsContainer.innerHTML = "<h3>Posts:</h3>";

    posts.forEach(post => {

        const div = document.createElement("div");
        div.classList.add("post");

        div.innerHTML = `
            <h4>${post.title}</h4>
            <p>${post.body}</p>
        `;

        postsContainer.appendChild(div);
    });
}
