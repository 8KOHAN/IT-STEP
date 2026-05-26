class News {

    constructor(
        title,
        text,
        tags,
        publishDate
    ){
        this.title=title;
        this.text=text;
        this.tags=tags;
        this.publishDate=publishDate;
    }

    getFormattedDate(){

        let now=new Date();

        let diff=
        Math.floor(
            (now-this.publishDate)
            /(1000*60*60*24)
        );

        if(diff===0){
            return "today";
        }

        if(diff<7){
            return `${diff} day ago`;
        }

        return this.publishDate
    }

    print(){
        document.write(`
            <div style="
                border:1px solid gray;
                padding:15px;
                margin:10px">

            <h2>${this.title}</h2>

            <p>${this.text}</p>

            <small>
                ${this.tags.join(", ")}
            </small>

            <br>

            <i>
                ${this.getFormattedDate()}
            </i>

            </div>
        `);
    }
}

let news1 = new News(
    "JavaScript ES2026",
    "added new generics.",
    ["JavaScript","IT"],
    new Date()
);

news1.print();
