const API_KEY = "ca582291";

const searchBtn = document.getElementById("search-btn");
const movieTitle = document.getElementById("movie-title");
const movieType = document.getElementById("movie-type");

const moviesContainer = document.getElementById("movies");
const paginationContainer = document.getElementById("pagination");
const detailsContainer = document.getElementById("details");

let currentSearch = "";
let currentType = "";

searchBtn.addEventListener("click", () => {
    currentSearch = movieTitle.value.trim();
    currentType = movieType.value;

    if (!currentSearch) {
        moviesContainer.innerHTML = "<h2>Please enter movie name</h2>";
        paginationContainer.innerHTML = "";
        detailsContainer.innerHTML = "";
        return;
    }

    searchMovies(1);
});

async function searchMovies(page) {
    try {
        let url =
            `https://www.omdbapi.com/?apikey=${API_KEY}&s=${currentSearch}&page=${page}`;

        if (currentType) {
            url += `&type=${currentType}`;
        }

        const response = await fetch(url);
        const data = await response.json();

        moviesContainer.innerHTML = "";
        paginationContainer.innerHTML = "";
        detailsContainer.innerHTML = "";

        if (data.Response === "False") {
            moviesContainer.innerHTML = "<h2>Movie not found!</h2>";
            return;
        }

        renderMovies(data.Search);
        createPagination(data.totalResults);
    } catch (error) {
        moviesContainer.innerHTML = "<h2>Something went wrong</h2>";
        console.log(error);
    }
}

function renderMovies(movies) {
    movies.forEach(movie => {
        const div = document.createElement("div");
        div.classList.add("movie");

        div.innerHTML = `
            <div>
                <h3>${movie.Title}</h3>
                <p>${movie.Year}</p>
            </div>

            <button onclick="showDetails('${movie.imdbID}')">
                Details
            </button>
        `;

        moviesContainer.appendChild(div);
    });
}

function createPagination(totalResults) {
    const pages = Math.ceil(Number(totalResults) / 10);

    for (let i = 1; i <= pages; i++) {
        const btn = document.createElement("button");

        btn.classList.add("pagination-btn");
        btn.textContent = i;

        btn.addEventListener("click", () => {
            searchMovies(i);
        });

        paginationContainer.appendChild(btn);
    }
}

async function showDetails(id) {
    try {
        const response = await fetch(
            `https://www.omdbapi.com/?apikey=${API_KEY}&i=${id}&plot=full`
        );

        const data = await response.json();

        detailsContainer.innerHTML = `
            <h2>${data.Title}</h2>
            <img src="${data.Poster}" alt="${data.Title}">
            <p><b>Year:</b> ${data.Year}</p>
            <p><b>Genre:</b> ${data.Genre}</p>
            <p><b>Director:</b> ${data.Director}</p>
            <p><b>Actors:</b> ${data.Actors}</p>
            <p><b>Plot:</b> ${data.Plot}</p>
        `;

    } catch (error) {
        detailsContainer.innerHTML = "<h2>Failed to load details</h2>";
        console.log(error);
    }
}
