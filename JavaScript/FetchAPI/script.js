async function fetchUsers() {
    try {
        const response = await fetch('https://dog.ceo/api/breeds/image/random');

        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }

        const data = await response.json();
        console.log("dog: ", data);

        const conteiner = document.querySelector(".foto-dog");
        conteiner.innerHTML = "";

        const img = document.createElement("img");
        img.src = `${data.message}`;
        img.alt = 'dog';
        img.className = "img-dog"
        conteiner.appendChild(img)

    } catch (error) {
        console.error('Error: ', error);
    }
}
