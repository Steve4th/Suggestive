/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    less = require("gulp-less"),
    uglify = require("gulp-uglify"),
    ngAnnotate = require("gulp-ng-annotate");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "app/**/*.js";
paths.minJs = paths.webroot + "app/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "app/app.min.js";
paths.concatJs = paths.webroot + "app/app.dev.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

paths.appJs = [paths.js, "!" + paths.minJs, "!" +  paths.concatJs];

gulp.task("clean:js", function (cb) {
    rimraf([paths.concatJsDest, paths.concatJs], cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.minCss, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src(paths.appJs, { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("dev:js" , function() {
    return gulp.src(paths.appJs, { base: "." })
        .pipe(concat(paths.concatJs))
        .pipe(ngAnnotate())
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

gulp.task("publish", ["dev:js", "min:js", "min:css", "bootswatch:css", "publish:angular"]);

gulp.task("watch", function() {
    return gulp
        .watch(paths.appJs, ['dev:js'])
        .on('change', function (event) {
            console.log('File: ' + event.path + ' was ' + event.type);
        })
});