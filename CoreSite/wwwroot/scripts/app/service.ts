import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class AppService {
	constructor(
		private http: Http
	) { }

	getStuff(): Promise<any> {
		return this.http.get('/home/settings')
			.toPromise();
	}
}