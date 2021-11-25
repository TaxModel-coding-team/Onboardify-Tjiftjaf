import { Component, OnInit } from '@angular/core';
import { Directive } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  public active(buttonvalue: string): void{
      console.log(buttonvalue);
  }
  
  ngOnInit(): void {
  }

}
