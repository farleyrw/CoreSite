import { Component } from '@angular/core';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'something',
	templateUrl: '/templates/view2.html'
})
export class SomethingComponent {
	constructor(
		private modalService: NgbModal
	) { }

	theThing: string = 'something';

	open(content) {
		this.modalService.open(content);
	}
}