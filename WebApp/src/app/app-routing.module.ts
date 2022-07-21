import { SignInComponent } from './screens/sign-in/sign-in.component';
import { HomeComponent } from './screens/master/home.component';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './screens/login/login.component';

const routes: Routes = [
    { path: '', redirectTo: 'admin', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'sign-in', component: SignInComponent },
    {
        path: 'admin',
        component: HomeComponent,
        data: {
            name: "Home",
        },
        children: [
            { path: '', loadChildren: () => import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule) },
            { path: 'product', loadChildren: () => import('./modules/product/product.module').then(m => m.ProductModule) },
            { path: 'category', loadChildren: () => import('./modules/category/category.module').then(m => m.CategoryModule) },
            { path: 'order', loadChildren: () => import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule) }
        ]
    }

]
@NgModule({
    imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
