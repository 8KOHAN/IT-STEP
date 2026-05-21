function add_like(){
    const btn = document.getElementById("btn-like");
    let counter = btn.textContent;
    counter = counter.match(/\d+/)[0];
    counter++;
    btn.textContent = "LIKE " + String(counter);
}
