import { Component, OnInit } from '@angular/core';
import { Recepie } from '../recepie.model';
@Component({
  selector: 'app-recepie-list',
  templateUrl: './recepie-list.component.html',
  styleUrls: ['./recepie-list.component.css']
})
export class RecepieListComponent implements OnInit {
  recepies: Recepie[] = [
    new Recepie("A test Recipe","This is simply a test",
    "https://www.google.com/search?tbm=isch&q=recipe+image&chips=q:recipe+image,g_1:secret:mfl3pMSafN4%3D&usg=AI4_-kRIA-QYD5_r6QxYS9VMB1hR78BCMQ&sa=X&ved=0ahUKEwi6yav3zMjhAhVkneAKHd5WDZkQ4lYIOigJ&biw=1366&bih=657&dpr=1#imgrc=kU-EHtFStIVxhM:"),
    new Recepie("A test Recipe","This is simply a test",
    "https://www.google.com/search?tbm=isch&q=recipe+image&chips=q:recipe+image,g_1:secret:mfl3pMSafN4%3D&usg=AI4_-kRIA-QYD5_r6QxYS9VMB1hR78BCMQ&sa=X&ved=0ahUKEwi6yav3zMjhAhVkneAKHd5WDZkQ4lYIOigJ&biw=1366&bih=657&dpr=1#imgrc=kU-EHtFStIVxhM:")
  ]

  constructor() { }

  ngOnInit() {
  }

}
