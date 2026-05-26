class CssClass {
    constructor(className) {
        this.className = className;
        this.styles = [];
    }

    setStyle(property, value) {
        this.styles.push({
            property,
            value
        });
    }

    removeStyle(property) {
        this.styles = this.styles.filter(
            style => style.property !== property
        );
    }

    getCss() {

        let css = "." + this.className + "{";

        for(let style of this.styles){
            css += `${style.property}:${style.value};`;
        }

        css += "}";

        return css;
    }
}

let card = new CssClass("card");

card.setStyle("width","300px");
card.setStyle("padding","15px");
card.setStyle("border","1px solid gray");

console.log(card.getCss());

card.removeStyle("border");

console.log(card.getCss());
