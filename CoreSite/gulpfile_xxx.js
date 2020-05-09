/// <binding AfterBuild='clean:libs, copy:libs' />

var gulp = require('gulp');
var clean = require('gulp-clean');
var flatten = require('gulp-flatten');
var pump = require('pump');
var packages = require('./package.json');
	//async = require('async'),
	//ts = require('gulp-typescript'),
	//uglify = require('gulp-uglify'),

var webroot = './wwwroot/';

var paths = {
	lib: {
		src: 'node_modules',
		dest: webroot + 'lib/'
	},
	app: {
		dest: webroot + 'scripts'
	}
};

// Clean libs from wwwroot.
gulp.task('clean:libs', function () {
	return gulp.src([paths.lib.dest])
		.pipe(clean());
});

// Copy libs to wwwroot.
gulp.task('copy:libs', function () {
	var packageNames = Object.keys(packages.dependencies);

	var packageFiles = packageNames
		.map(function (package) {
			return package + '/**/*.{js,css}';
		});
	
	// TODO: Maybe dist folder else the pattern above?
	// TODO: only clean when package folder is missing

	return gulp.src(packageFiles, { cwd: 'node_modules/**' })
		//.pipe(flatten({ includeParents: 1 }))
		.pipe(gulp.dest(paths.lib.dest));
});

gulp.task('copy:app', function () {
	var paths = {
		scripts: ['scripts/**/*']//['scripts/**/ *.js', 'scripts/**/ *.ts', 'scripts/**/ *.map'],
	};

	return gulp.src(paths.scripts)
		.pipe(gulp.dest('wwwroot/scripts'));

	//gulp.src(paths.dependencies).pipe(gulp.dest('wwwroot/lib'));
});
