import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HamburgerToggleDirective } from './directives/hamburger-toggle.directive';
import { HomeComponent } from './components/home/home.component';
import { PlatformsComponent } from './components/platforms/platforms.component';
import { PlatformCardComponent } from './components/platforms/platform-card/platform-card.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    SideMenuComponent,
    HamburgerToggleDirective,
    HomeComponent,
    PlatformsComponent,
    PlatformCardComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
