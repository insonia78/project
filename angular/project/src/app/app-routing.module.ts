import { NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { RecepiesComponent } from './recepies/recepies.component';
import {ShoppingListComponent} from './shopping-list/shopping-list.component';
const appRoutes:Routes = [
    {path:'', redirectTo:'recipes'},
    {path: 'recipes', component:RecepiesComponent},
    {path:'shopping-list',component:ShoppingListComponent}
]
@NgModule({
  imports:[RouterModule.forRoot(appRoutes)],
  exports:[RouterModule]
})
export class AppRoutingModule {

}