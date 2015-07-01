var gulp = require("gulp");
var del = require("del");
var args = require("yargs").argv;
var $ = require("gulp-load-plugins")({lazy:true});
var config = require("./gulp.config")();

gulp.task("clean-js", function () {
    del.sync(["DDDPizza.Api/Scripts/app/app.min.js"]);
});

gulp.task("clean-css", function () {
    del.sync(["DDDPizza.Api/Content/site.min.css"]);
});

// Combine and minify all files from the app folder
gulp.task("scripts", ["clean-js"], function () {

    return gulp.src(config.alljs)
      .pipe($.plumber())
      .pipe($.jscs())
      .pipe($.jshint())
      .pipe($.jshint.reporter('jshint-stylish',{verbore:true}))
      .pipe($.if(args.verbose,$.print()))
      .pipe($.uglify())
      .pipe($.concat("app.min.js"))
      .pipe(gulp.dest("DDDPizza.Api/Scripts/app/"));
});

gulp.task("styles", ["clean-css"], function () {

    return gulp.src(config.allcss)
      .pipe($.plumber())
      .pipe($.if(args.verbose,$.print()))
      .pipe($.uglifycss())
      .pipe($.concat("site.min.css"))
      .pipe(gulp.dest("DDDPizza.Api/Content/"));
});


gulp.task("watch", function () {
    return gulp.watch(config.src, ["scripts","styles"]);
});

gulp.task("wiredep", function() {
    var options = config.getWiredepDefaultOptions();
    var wiredep = require("wiredep").stream;
    return gulp
            .src(config.index)
            .pipe(wiredep(options))
            .pipe(gulp.dest(config.indexRoot));
});


//Set a default tasks
gulp.task("default", ["scripts","styles"], function () { });