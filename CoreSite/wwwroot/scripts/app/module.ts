import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppService } from './service';
import { AppComponent } from './component';
import { SomethingComponent } from './something';

@NgModule({
	imports: [
		BrowserModule,
		HttpModule,
		NgbModule.forRoot()
	],
	declarations: [AppComponent, SomethingComponent ],
	bootstrap: [AppComponent],
	providers: [AppService]
})
export class AppModule { }