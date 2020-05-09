
import { Component } from '@angular/core';

//export class q {
//	es6: string;

//	constructor() {
//		this.es6 = 'guh';
//	}
//}

@Component({
	selector: 'HelloWorld',
	template: '<h1>Page Says: {{text}}</h1>'
})

export class AppComponent { text = 'Hello, World'; }