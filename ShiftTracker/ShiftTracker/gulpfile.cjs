/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/
var gulp = require("gulp");
var del = require("del");
var sass = require("gulp-sass")(require("sass"));
var paths = {
    scripts: ["scripts/**/*.js", "scripts/**/*"],
};
gulp.task("clean", function () {
    return del(["wwwroot/scripts/**/*"]);
});
gulp.task("default", function (done) {
    gulp.src(paths.scripts).pipe(gulp.dest("wwwroot/scripts"));
    done();
});

gulp.task('sass', function() {
    return gulp.src("./Content/*.scss")
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css'));
});

/*
 * Watch prefixes
 */
gulp.task('watch', function() {
    gulp.watch('.Content/*.scss', gulp.series('sass'));
});