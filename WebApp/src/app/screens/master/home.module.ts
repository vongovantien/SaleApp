import { HomeComponent } from './../master/home.component';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedComponentsModule } from 'src/app/shared/components/shared-components.module';

@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        SharedComponentsModule
    ],
    exports: [
        RouterModule
    ]
})
export class HomeModule { }
