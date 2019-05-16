import { Component, OnInit, Input } from '@angular/core';
import { Recepie } from '../recepie.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recepie-detail',
  templateUrl: './recepie-detail.component.html',
  styleUrls: ['./recepie-detail.component.css']
})
export class RecepieDetailComponent implements OnInit {
  @Input() recipe:Recepie;
  constructor(private recipeService: RecipeService) {}

  ngOnInit() {
  }
  onAddToShoppingList(){
    this.recipeService.addIngredeintsToShoppingList(this.recipe.ingredients)
  }
}
