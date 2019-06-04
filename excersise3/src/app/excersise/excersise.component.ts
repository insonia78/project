import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-excersise',
  templateUrl: './excersise.component.html',
  styleUrls: ['./excersise.component.css']
})
export class ExcersiseComponent implements OnInit {
  status = true;
  text = " Secret password ";
  textArray = [];
  constructor() { }

  ngOnInit() {
  }
  onButtonClick(){
    this.status = !this.status;
    this.text = "Secret password " + this.status; 
    this.textArray.push(this.text);    
  }
  onTextField()
  {
      
  }
}
