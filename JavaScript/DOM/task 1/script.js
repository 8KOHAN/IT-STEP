const track = document.querySelector('.track');
const thumb = document.querySelector('.thumb');

let isDragging = false;

thumb.addEventListener('mousedown', () => {
    isDragging = true;
});

document.addEventListener('mouseup', () => {
    isDragging = false;
});

document.addEventListener('mousemove', (e) => {
    if (!isDragging) return;

    const rect = track.getBoundingClientRect();
    let x = e.clientX - rect.left;

    if (x < 0) x = 0;
    if (x > rect.width) x = rect.width;

    thumb.style.left = (x - thumb.offsetWidth / 2) + 'px';
});
