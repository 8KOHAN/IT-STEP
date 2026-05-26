class HtmlElement {
    constructor(tagName, selfClosing = false, text = "") {
        this.tagName = tagName;
        this.selfClosing = selfClosing;
        this.text = text;

        this.attributes = [];
        this.styles = [];
        this.children = [];
    }

    pushAttribute(name, value) {
        this.attributes.push({
            name,
            value
        });
    }

    pushStyle(property, value) {
        this.styles.push({
        property,
        value
    });
    }

    appendChild(element) {
        this.children.push(element);
    }

    prependChild(element) {
        this.children.unshift(element);
    }

    getHtml() {
        let attrs = "";

        for (let attr of this.attributes) {
            attrs += ` ${attr.name}="${attr.value}"`;
        }

        if (this.styles.length > 0) {

            let stylesString =
                this.styles
                .map(
                    style =>
                    `${style.property}:${style.value};`
                ).join("");

            attrs += ` style="${stylesString}"`;
        }

        if (this.selfClosing) {
            return `<${this.tagName}${attrs}/>`;
        }

        let html =
            `<${this.tagName}${attrs}>`;

        html += this.text;

        for (let child of this.children) {
            html += child.getHtml();
        }

        html += `</${this.tagName}>`;

        return html;
    }
}

let wrapper = new HtmlElement("div");

wrapper.pushAttribute("id", "wrapper");
wrapper.pushStyle("display", "flex");

let p = new HtmlElement(
    "p",
    false,
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
);

p.pushStyle("width", "300px");
p.pushStyle("text-align", "justify");

let img = new HtmlElement(
    "img",
    true
);

img.pushAttribute(
    "src",
    "https://content-cdn.tribuna.uz/20260302/634e256dcfca3bac82fd12e0715eaedfe0f403dbae4d03d64c9c36db1ac77417-1200-675.webp"
);

img.pushStyle("margin-left", "20px");
img.pushStyle("width", "150px");

wrapper.appendChild(p);
wrapper.appendChild(img);

document.write(
    wrapper.getHtml()
);
