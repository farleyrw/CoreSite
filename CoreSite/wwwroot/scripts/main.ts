import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/module';

platformBrowserDynamic().bootstrapModule(AppModule);

// This replaces ng-app from angular 1.x