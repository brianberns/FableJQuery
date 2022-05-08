# Using JQuery from Fable

This is a simple app that demonstrates how to use JQuery from a Fable application. The [Fable documentation](https://fable.io/docs/communicate/js-from-fable.html) on calling Javascript from Fable misses one very important detail: JQuery must be imported from its `src` sub-folder rather than from `dist`, which is the default. To accomplish this, the following property must be set in `webpack.config.js`:

```javascript
resolve: {
    alias: {
        jquery: "jquery/src/jquery"
    }
}
```