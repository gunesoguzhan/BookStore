const posts = [
    { id: 1, name: "Post 1" },
    { id: 2, name: "Post 2" },
    { id: 3, name: "Post 3" }
];

const getPosts = async (bool) => {
    return new Promise((resolve, reject) => {
        if (bool)
            resolve(posts);
        else
            reject("Post cannot get");
    })
}

const addPost = async (post) => {
    return new Promise((resolve, reject) => {
        if (post)
            resolve(posts.push(post));
        else
            reject("Post cannot added.");
    })
}

var process = async () => {
    try {
        await addPost({ id: 4, name: "Post 4" })
        var posts = await getPosts(true);
        console.log(posts);
    } catch (err) {
        console.log(err);
    }
}

process();