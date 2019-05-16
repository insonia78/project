import { Component, OnInit } from '@angular/core';
import { increaseElementDepthCount } from '@angular/core/src/render3/state';

@Component({
  selector: 'app-component',
  templateUrl: './component.component.html',
  styleUrls: ['./component.component.css']
})
export class ComponentComponent implements OnInit {
  increment  = 0;
  constructor() { }

  ngOnInit() {
  }
  onIncrementNumber(){
    this.increment =  this.increment + 1;
    return this.increment;
  }
  getBColor(){
    if(this.increment >= 5)
         return "blue";
          
  }
  getColor()
  {
    if(this.increment >= 5)
         return "white";
  }
}
