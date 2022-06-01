import { Component, OnInit } from '@angular/core';
import {document} from "ngx-bootstrap/utils";
const confetti = require('canvas-confetti');

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {
  ngOnInit(): void {

  }

  ClickToConfetti() {
    const myConfetti = confetti.create(null, { resize: true });
      myConfetti({
        particleCount: 200,
        spread: 360,
        scalar: 0.8,
        startVelocity: 10,
        ticks: 100,
        origin: {
          x: Math.random(),
          // since they fall down, start a bit higher than random
          y: Math.random() - 0.2
        }
      });
    }
}
