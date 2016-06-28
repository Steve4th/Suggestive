/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    less = require("gulp-less"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/app.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.minCss, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src('./Styles/*.less')
        .pipe(less())
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("bootswatch:css", function() {
    return gulp.src('./Styles/bootswatch_superhero.css')
        .pipe(concat(paths.webroot + "css/bootswatch.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("publish:angular", function() {
    return gulp.src(['./node_modules/angular/angular.min.js', './node_modules/angular/angular.min.js.map',
                       './node_modules/angular-route/angular-route.min.js', './node_modules/angular-route/angular-route.min.js.map'])
        .pipe(gulp.dest(paths.webroot + "lib/"));
});

gulp.task("publish", ["min:js", "min:css", "bootswatch:css", "publish:angular"]);
