function showText() {
    const text = document.getElementById("text").value;
    const color = document.getElementById("color").value;
    const size = document.getElementById("size").value;
    const bold = document.getElementById("bold").checked;
    const italic = document.getElementById("italic").checked;

    const output = document.getElementById("output");

    output.textContent = text;
    output.style.color = color;
    output.style.fontSize = size + "px";
    output.style.fontWeight = bold ? "bold" : "normal";
    output.style.fontStyle = italic ? "italic" : "normal";
}
