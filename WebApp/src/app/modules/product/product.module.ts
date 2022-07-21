
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedComponentsModule } from 'src/app/shared/components/shared-components.module';
import { ProductAddNewComponent } from './pages/product-add-new/product-add-new.component';
import { ProductDetailComponent } from './pages/product-detail/product-detail.component';
import { ProductComponent } from './product.component';


const routing: Routes = [
    {
        path: '', data: { name: "" },
        children: [
            {
                path: '', component: ProductComponent
            },
            {
                path: "new", component: ProductAddNewComponent,
                data: { name: "New", }
            },
            {
                path: ":id", component: ProductDetailComponent,
                data: { name: "Detail", }
            },
        ]
    },
]
@NgModule({

    imports: [
        SharedComponentsModule,
        RouterModule.forChild(routing),
    ],
    declarations: [
        ProductComponent,
        ProductAddNewComponent
    ],
    bootstrap: [],
    providers: [],
})
export class ProductModule { }
