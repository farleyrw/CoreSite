"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
//export class q {
//	es6: string;
//	constructor() {
//		this.es6 = 'guh';
//	}
//}
let AppComponent = class AppComponent {
    //export class q {
    //	es6: string;
    //	constructor() {
    //		this.es6 = 'guh';
    //	}
    //}
    constructor() {
        this.text = 'Hello, Angular World';
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'HelloWorld',
        template: '<h1>Page Says: {{text}}</h1>'
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map