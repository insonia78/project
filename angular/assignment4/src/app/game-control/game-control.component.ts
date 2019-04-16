import { Component, OnInit, EventEmitter,Output } from '@angular/core';
import { timeout } from 'q';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css']
})
export class GameControlComponent implements OnInit {
  @Output() setTimeEmitter = new EventEmitter<number>();
  timeStamp;
  lastNumber = 0;
  buttonDisabled = false; 
  constructor() { }

  ngOnInit() {
  }
  onGetTimeStamp()
  {
    this.timeStamp = setInterval(() => {
      this.setTimeEmitter.emit(this.lastNumber + 1);
      this.lastNumber++;

    },1000);
    this.buttonDisabled = true;
  }
  onStopGame(){
    clearInterval(this.timeStamp);
    this.buttonDisabled = false;
  }
}
