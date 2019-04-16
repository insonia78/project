import { Component, OnInit } from '@angular/core';
import { Recepie } from './recepie.model';

@Component({
  selector: 'app-recepies',
  templateUrl: './recepies.component.html',
  styleUrls: ['./recepies.component.css']
})
export class RecepiesComponent implements OnInit {
  recepies: Recepie[] = [
    new Recepie("A test Recipe","This is simply a test",
    "https://www.google.com/search?q=recipe+image&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjOsbvyzMjhAhUphuAKHeTyD3sQ_AUIDigB&biw=1366&bih=657#imgrc=tNnlXB7yxlqILM:")
  ]

  
  constructor() { }

  ngOnInit() {
  }

}
