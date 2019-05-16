import {Recepie} from './recepie.model'
import { EventEmitter, Injectable } from '@angular/core';
import { Ingredient } from '../shared/ingredient.module';
import { ShoppingService } from '../shopping-list/shopping.service';
@Injectable()
export class RecipeService{
     recipeSelected = new EventEmitter<Recepie>();
    private recepies: Recepie[] = [
        new Recepie("A test Recipe","This is simply a test",
        "https://www.google.com/search?tbm=isch&q=recipe+image&chips=q:recipe+image,g_1:secret:mfl3pMSafN4%3D&usg=AI4_-kRIA-QYD5_r6QxYS9VMB1hR78BCMQ&sa=X&ved=0ahUKEwi6yav3zMjhAhVkneAKHd5WDZkQ4lYIOigJ&biw=1366&bih=657&dpr=1#imgrc=kU-EHtFStIVxhM:",
        [new Ingredient('Meat',1),
         new Ingredient('French Fries',20) ]),
        new Recepie("Another test Recipe","This is simply a test 2",
        "https://www.google.com/search?tbm=isch&q=recipe+image&chips=q:recipe+image,g_1:secret:mfl3pMSafN4%3D&usg=AI4_-kRIA-QYD5_r6QxYS9VMB1hR78BCMQ&sa=X&ved=0ahUKEwi6yav3zMjhAhVkneAKHd5WDZkQ4lYIOigJ&biw=1366&bih=657&dpr=1#imgrc=kU-EHtFStIVxhM:",
        [
            new Ingredient('Buns',2),
            new Ingredient('Meat',1)
        ])
      ] 
      constructor(private shoppingListService: ShoppingService){}
      getRecipes(){
        return this.recepies.slice();
      }
      addIngredeintsToShoppingList(ingredients: Ingredient[]){
        this.shoppingListService.addIngredients(ingredients);
      }
}