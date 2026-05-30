const newsArray = [
    { title: "News 1", text: "Text of the first news." },
    { title: "News 2", text: "Text of the second news." },
    { title: "News 3", text: "Text of the third news." },
    { title: "News 4", text: "Text of the fourth news." },
    { title: "News 5", text: "Text of the fifth news." },
    { title: "News 6", text: "Text of the sixth news." },
    { title: "News 7", text: "Text of the seventh news." },
    { title: "News 8", text: "Text of the eighth news." },
    { title: "News 9", text: "Text of the ninth news." },
    { title: "News 10", text: "Text of the tenth news." },
    { title: "News 11", text: "Text of the eleventh news." },
    { title: "News 12", text: "Text of the twelfth news." }
];

const container = document.getElementById("newsContainer");

let currentIndex = 0;
const newsPerLoad = 2;

function loadNews() {

    for (
        let i = 0;
        i < newsPerLoad && currentIndex < newsArray.length;
        i++
    ) {
        const news = document.createElement("div");

        news.className = "news";

        news.innerHTML = `
            <h3>${newsArray[currentIndex].title}</h3>
            <p>${newsArray[currentIndex].text}</p>
        `;

        container.appendChild(news);
        currentIndex++;
    }

    if (
        document.documentElement.scrollHeight <= window.innerHeight &&
        currentIndex < newsArray.length
    ) {
        loadNews();
    }
}

window.addEventListener("scroll", () => {

    if (currentIndex >= newsArray.length) return;

    if (
        window.innerHeight + window.scrollY >=
        document.documentElement.scrollHeight - 10
    ) {
        loadNews();
    }
});

loadNews();
