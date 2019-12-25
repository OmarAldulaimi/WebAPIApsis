import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {BowlingData} from './bowlingData';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  private bowlingData : BowlingData;
  private Roll_One : number = 0;
  private Roll_Two : number = 0;
  private Roll_Three : number = 0;
  private show : boolean;
  

  constructor(private http: HttpClient) { }

  onNewGame($event){  

    return this.http.post('https://localhost:44393' + '/api/AddGame/', "")
      .subscribe(

        (response: BowlingData) =>
        {
         
          this.bowlingData = response;
          this.show = false;
          console.log(response);
        },
        err => {
          console.log(err);
        }
      );
      
  }

  onAddRoll($event2){   

    return this.http.post('http://localhost:62345/' + '/api/AddFrame?id=' + this.bowlingData.Id , {RollOne: this.Roll_One, RollTwo : this.Roll_Two, RollThree : this.Roll_Three})
      .subscribe(

        (response: BowlingData) =>
        {
          if(this.bowlingData.Rolls.length == 9){
            this.show = true;
          }
          
          this.bowlingData = response;
          console.log(response);
        
        },
        err => {
          console.log(err);
        }
      );
      
  }

  ngOnInit() {
  }

}
