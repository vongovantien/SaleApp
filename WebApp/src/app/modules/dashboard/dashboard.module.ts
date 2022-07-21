import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { RouterModule, Routes } from '@angular/router';

const routing: Routes = [
    {
        path: '', data: { name: "" }, children: [
            {
                path: '', component: DashboardComponent
            }
        ]
    },
];

@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routing),
    ]
})
export class DashboardModule { }
