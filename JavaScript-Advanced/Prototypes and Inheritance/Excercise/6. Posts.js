function solution() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }
        toString() {
            return `${this.title}: ${this.title}\nContent: ${this.content}\n`;
        }
    }
    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }
        addComment(comment) {
            this.comments.push(comment)
        }

        toString() {
            if (this.comments.length > 0) {
                return super.toString() + `Rating: ${this.likes - this.dislikes}\nComments:\n${this.comments.map((comm) => ` * ${comm}`).join("\n")}`;
            }
            else {
                return super.toString() + `Rating: ${this.likes - this.dislikes}`;
            }
        }
    }
    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }
        view() {
            this.views++;
            return this;
        }
        toString() {
            return super.toString() + `Views: ${this.views} `;
        }
    }

    return { Post, SocialMediaPost, BlogPost };
}
const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());
let bp = new classes.BlogPost("Blog Post", "Blog post content", 1);
bp.view();
bp.view();
console.log(bp.toString());
// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
