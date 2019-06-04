import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Recepie } from '../recepie.model';
import { RecipeService} from "../recipe.service";
@Component({
  selector: 'app-recepie-list',
  templateUrl: './recepie-list.component.html',
  styleUrls: ['./recepie-list.component.css']
})
export class RecepieListComponent implements OnInit {  
  @Output() recipeWasSelected = new EventEmitter<Recepie>();
  recepies: Recepie[]

  constructor(private recipeService: RecipeService) { }

  ngOnInit() {
    this.recepies = this.recipeService.getRecipes();
  }
  onRecipeSelected(recipe:Recepie){  
    this.recipeWasSelected.emit(recipe);        
  } 
}
