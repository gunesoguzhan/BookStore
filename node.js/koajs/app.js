const koa = require("koa");
const koaRouter = require('@koa/router');

const app = new koa();
const router = new koaRouter();

router.get("/", ctx => {
    ctx.status = 200;
    ctx.body = "<h1>Welcome to Index Page</h1>";
});

router.get("/about", ctx => {
    ctx.status = 200;
    ctx.body = "<h1>Welcome to About Page</h1>";
});

router.get("/contact", ctx => {
    ctx.status = 200;
    ctx.body = "<h1>Welcome to Contact Page</h1>";
});

app.use(router.routes(), router.allowedMethods());

const port = 3000;

app.listen(port, () => {
    console.log(`Port: ${port} listening for requests.`);
});