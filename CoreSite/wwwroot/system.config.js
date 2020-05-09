
(function () {
	'use strict';

	SystemJS.config({
		// map tells the System loader where to look for things
		map: {
			// angular bundles
			'@angular/core': 'npm:@angular/core/bundles/core.umd.js',
			'@angular/common': 'npm:@angular/common/bundles/common.umd.js',
			'@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
			'@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
			'@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
			'@angular/http': 'npm:@angular/http/bundles/http.umd.js',
			'@angular/router': 'npm:@angular/router/bundles/router.umd.js',
			'@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',

			'@ng-bootstrap/ng-bootstrap': 'npm:@ng-bootstrap/ng-bootstrap/bundles/ng-bootstrap.js',

			'rxjs': 'npm:rxjs',

			"plugin-typescript": "npm:plugin-typescript/lib/plugin.js",
			"typescript": "npm:typescript/lib"
		},
		paths: {
			// paths serve as alias
			'npm:': '/lib/'
		},
		// packages tells the System loader how to load when no filename and/or no extension
		packages: {
			typescript: {
				main: "typescript.js",
				meta: {
					"typescript.js": {
						exports: "ts"
					}
				}
			},
			rxjs: {
				defaultExtension: 'js'
			},
			'/scripts': {
				defaultExtension: 'ts'
			}
		},
		meta: {
			'@ng-bootstrap/ng-bootstrap': {
				esModule: true
			}
		},
		transpiler: "plugin-typescript",
		typescriptOptions: {
			tsconfig: '/scripts/tsconfig.json'
		}
	});
})();