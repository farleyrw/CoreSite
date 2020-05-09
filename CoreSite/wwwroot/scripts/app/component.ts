import { Component, OnInit } from '@angular/core';

import { AppService } from './service';

@Component({
	selector: 'guh',
	templateUrl: '/templates/view1.html'
})
export class AppComponent implements OnInit {
	constructor(
		private service: AppService
	) { }

	settings : string = 'default';

	ngOnInit(): void {
		this.service.getStuff().then(response => {
			this.settings = response.json();
		});
	}
}