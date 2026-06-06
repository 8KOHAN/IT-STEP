function addColor(){

    let color = document.getElementById("newColor").value;

    let div = document.createElement("div");
    div.className = "color";
    div.style.background = color;

    document.getElementById("palette").appendChild(div);
}
