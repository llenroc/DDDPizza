var gulp = require("gulp");
var concat = require("gulp-concat");
var uglify = require("gulp-uglify");
var uglifycss = require("gulp-uglifycss");
var del = require("del");
var watch = require("gulp-watch");
var config = require("./gulp.config")();



// Synchronously delete the output file(s)
gulp.task("clean-js", function () {
    del.sync(["DDDPizza.Api/Scripts/app/app.min.js"]);
});

gulp.task("clean-css", function () {
    del.sync(["DDDPizza.Api/Content/site.min.css"]);
});

// Combine and minify all files from the app folder
gulp.task("scripts", ["clean-js"], function () {

    return gulp.src(config.alljs)
      .pipe(uglify())
      .pipe(concat("app.min.js"))
      .pipe(gulp.dest("DDDPizza.Api/Scripts/app/"));
});

gulp.task("styles", ["clean-css"], function () {

    return gulp.src(config.allcss)
      .pipe(uglifycss())
      .pipe(concat("site.min.css"))
      .pipe(gulp.dest("DDDPizza.Api/Content/"));
});


gulp.task("watch", function () {
    return gulp.watch(config.src, ["scripts","styles"]);
});

//Set a default tasks
gulp.task("default", ["scripts","styles"], function () { });