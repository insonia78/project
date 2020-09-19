import { Ingredient } from "../shared/ingredient.module";
import { EventEmitter } from '@angular/core';

export class ShoppingService{
    private ingredients: Ingredient[] = [
        new Ingredient('Apples',5),
        new Ingredient('Tomato',10) 
       ];
    ingredientChanged = new EventEmitter<Ingredient[]>();
    getIngredients(){
        return this.ingredients.slice();
    }    
    addIngrdedient(ingredient:Ingredient)
    {
        this.ingredients.push(ingredient);
        this.ingredientChanged.emit(this.ingredients.slice()); 
    }
    addIngredients(ingredients:Ingredient[]){
        this.ingredients.push(...ingredients);
        this.ingredientChanged.emit(this.ingredients.slice());
    }
}