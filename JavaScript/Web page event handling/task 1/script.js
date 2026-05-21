const cells = document.querySelectorAll("td, th");

cells.forEach(function(cell){
    cell.addEventListener("mouseover", function(){
        this.style.backgroundColor = "orange";
    });
    cell.addEventListener("mouseout", function(){
        this.style.backgroundColor = "";
    });
})
