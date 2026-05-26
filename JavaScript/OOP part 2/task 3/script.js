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

class NewsFeed{
    constructor(){
        this.news=[];
    }

    get count(){
        return this.news.length;
    }

    addNews(newsItem){
        this.news.push(newsItem);
    }

    removeNews(title){
            this.news=
            this.news.filter(
            item=>
            item.title!==title
        );
    }

    sortByDate(){
        this.news.sort(
            (a,b)=>
            b.publishDate-
            a.publishDate
        );
    }

    searchByTag(tag){
        return this.news.filter(
            item=>
            item.tags.includes(tag)
        );
    }

    printAll(){
        this.news.forEach(
            item=>
            item.print()
        );

    }
}

let feed=new NewsFeed();

let n1=new News(
    "News 1",
    "Text of the first news",
    ["sport","football"],
    new Date(2026,4,25)
);

let n2=new News(
    "News 2",
    "Text of the second news",
    ["IT","JavaScript"],
    new Date()
);

let n3=new News(
    "News 3",
    "Text of the third news",
    ["sport"],
    new Date(2026,4,20)
);

feed.addNews(n1);
feed.addNews(n2);
feed.addNews(n3);

console.log(
    "Quantity:",
    feed.count
);

feed.sortByDate();

feed.printAll();

let sportNews=
    feed.searchByTag(
    "sport"
);
console.log(
    sportNews
);

feed.removeNews(
    "News 1"
);
console.log(
    "After removal:"
);
console.log(
    feed.count
);
