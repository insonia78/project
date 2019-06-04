import { EventEmitter, Component, OnInit, ViewChild, ElementRef, Output } from '@angular/core';
import { Ingredient } from 'src/app/shared/ingredient.module';
import { ShoppingService } from '../shopping.service';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @ViewChild('nameInput') nameInputRef:ElementRef;
  @ViewChild('amountInput') amountInputRef:ElementRef;
  constructor(private slService:ShoppingService) { }

  ngOnInit() {
    
  }
  onAddItem(){
    const ingName = this.nameInputRef.nativeElement.value;
    const ingAmount = this.amountInputRef.nativeElement.value;
    const newIngredient = new Ingredient(ingName,ingAmount);
    this.slService.addIngrdedient(newIngredient);
    
  }
}