import { Component, OnInit, Input } from '@angular/core';
import { Recepie } from '../recepie.model';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-recepie-detail',
  templateUrl: './recepie-detail.component.html',
  styleUrls: ['./recepie-detail.component.css']
})
export class RecepieDetailComponent implements OnInit {
  @Input() recipe:Recepie;
  id:number;
  constructor(private recipeService: RecipeService,
              private route:ActivatedRoute) {}

  ngOnInit() {
    this.route.params
    .subscribe(
      (params: Params) =>{
         this.id = +params['id'];
         this.recipe = this.recipeService.getRecipe(this.id);
      });
  }
  onAddToShoppingList(){
    this.recipeService.addIngredeintsToShoppingList(this.recipe.ingredients)
  }
}
