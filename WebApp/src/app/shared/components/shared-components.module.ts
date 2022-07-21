import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SideBarComponent } from './side-bar/side-bar.component';
import { TableComponent } from './table/table.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
const COMPONENTS = [
    SideBarComponent,
    TableComponent,
]
const MAT_MODULE = [
    MatToolbarModule,
    MatIconModule,
    MatListModule
]
const APP_MODULE = [
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
]
@NgModule({
    declarations: [
        ...COMPONENTS
    ],
    imports: [
        CommonModule,
        FormsModule,
        ...APP_MODULE,
        ...MAT_MODULE
    ],
    exports: [
        ...COMPONENTS,
        ...APP_MODULE,
        ...MAT_MODULE
    ]
})
export class SharedComponentsModule { }
