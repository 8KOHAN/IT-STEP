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

class HtmlBlock {

    constructor(rootElement){
        this.styles=[];
        this.rootElement=rootElement;
    }

    addCssClass(cssClass){
        this.styles.push(cssClass);
    }

    getCode(){

        let result="<style>";

        for(let style of this.styles){
            result+=style.getCss();
        }

        result+="</style>";

        result+=this.rootElement.getHtml();

        return result;
    }
}

let wrapperCss = new CssClass("wrapper");

wrapperCss.setStyle("display","flex");
wrapperCss.setStyle("justify-content","center");
wrapperCss.setStyle("margin","30px");

let cardCss=new CssClass("card");

cardCss.setStyle("width","300px");
cardCss.setStyle("border","1px solid gray");
cardCss.setStyle("padding","15px");
cardCss.setStyle("border-radius","10px");

let imgCss=new CssClass("image");

imgCss.setStyle("width","100%");

let titleCss=new CssClass("title");

titleCss.setStyle("color","navy");

let linkCss=new CssClass("link");

linkCss.setStyle("color","red");
linkCss.setStyle("text-decoration","none");


let wrapper = new HtmlElement("div");
wrapper.pushAttribute("class","wrapper");

let card = new HtmlElement("div");
card.pushAttribute("class","card");

let img=new HtmlElement("img",true);
img.pushAttribute(
"src",
"https://avatars.githubusercontent.com/u/208480605?v=4"
);
img.pushAttribute(
    "class",
    "image"
);

let title=new HtmlElement(
    "h3",
    false,
    "What is Lorem Ipsum?"
);
title.pushAttribute(
    "class",
    "title"
);

let text=new HtmlElement(
    "p",
    false,
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
);

let link=new HtmlElement(
    "a",
    false,
    "Read more"
);
link.pushAttribute(
    "href",
    "#"
);
link.pushAttribute(
    "class",
    "link"
);

card.appendChild(img);
card.appendChild(title);
card.appendChild(text);
card.appendChild(link);

wrapper.appendChild(card);

let block=
new HtmlBlock(wrapper);

block.addCssClass(wrapperCss);
block.addCssClass(cardCss);
block.addCssClass(imgCss);
block.addCssClass(titleCss);
block.addCssClass(linkCss);
document.write(
    block.getCode()
);
