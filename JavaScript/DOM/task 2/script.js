const images = [
    "https://picsum.photos/id/1015/500/300",
    "https://picsum.photos/id/1025/500/300",
    "https://picsum.photos/id/1035/500/300",
    "https://picsum.photos/id/1045/500/300"
];

let currentIndex = 0;

const image = document.getElementById("galleryImage");
const prevBtn = document.getElementById("prevBtn");
const nextBtn = document.getElementById("nextBtn");

function updateGallery() {
    image.src = images[currentIndex];

    prevBtn.disabled = currentIndex === 0;
    nextBtn.disabled = currentIndex === images.length - 1;
}

prevBtn.addEventListener("click", () => {
    currentIndex--;
    updateGallery();
});

nextBtn.addEventListener("click", () => {
    currentIndex++;
    updateGallery();
});

updateGallery();
