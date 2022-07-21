import { HomeModule } from './screens/master/home.module';
import { HomeComponent } from './screens/master/home.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { SignInComponent } from './screens/sign-in/sign-in.component';
import { LoginComponent } from './screens/login/login.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { SideBarComponent } from './shared/components/side-bar/side-bar.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from 'ngx-toastr';
@NgModule({
    declarations: [
        AppComponent,
        SignInComponent,
        LoginComponent,
        NavBarComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HomeModule,
        BrowserAnimationsModule,
        StoreModule.forRoot({}, {}),
        EffectsModule.forRoot([]),
        ToastrModule.forRoot({
            positionClass: 'toast-bottom-right',
            easeTime: 500
        }),
        NgxSpinnerModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
