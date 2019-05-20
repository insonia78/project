import { Component, OnInit, Input } from '@angular/core';
import { Recepie } from '../../recepie.model';
import { RecipeService } from '../../recipe.service';
@Component({
  selector: 'app-recepie-item',
  templateUrl: './recepie-item.component.html',
  styleUrls: ['./recepie-item.component.css']
})
export class RecepieItemComponent implements OnInit {
  @Input() recipe: Recepie;
  
  
  ngOnInit() {
  }
  
}
