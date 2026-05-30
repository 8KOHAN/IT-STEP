const titles = document.querySelectorAll('.title');

titles.forEach(title => {
    title.addEventListener('click', () => {
        const currentItem = title.parentElement;

        document.querySelectorAll('.item').forEach(item => {
            if (item !== currentItem) {
                item.classList.remove('active');
            }
        });

        currentItem.classList.toggle('active');
    });
});
