var gulp = require("gulp");
var concat = require("gulp-concat");
var uglify = require("gulp-uglify");
var del = require("del");
var watch = require("gulp-watch");

var config = {
    //Include all js files but exclude any min.js files
    //src: ['app/**/*.js', '!app/**/*.min.js'],
    src: ["Scripts/app/app.js",
            "Scripts/app/controllers/*.js",
            "Scripts/app/services/*.js",
            "Scripts/app/directives/*.js",
            "!Scripts/app/app.min.js"]
}

// Synchronously delete the output file(s)
gulp.task("clean", function () {
    del.sync(["Scripts/app/app.min.js"]);
});

// Combine and minify all files from the app folder
gulp.task("scripts", ["clean"], function () {

    return gulp.src(config.src)
      .pipe(uglify())
      .pipe(concat("app.min.js"))
      .pipe(gulp.dest("Scripts/app/"));
});

gulp.task("watch", function () {
    return gulp.watch(config.src, ["scripts"]);
});

//Set a default tasks
gulp.task("default", ["scripts"], function () { });