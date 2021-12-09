import { Component, OnInit } from '@angular/core';
import { Achievement } from '../Models/achievement';
import { Badge } from '../Models/badge';

@Component({
  selector: 'app-badges',
  templateUrl: './badges.component.html',
  styleUrls: ['./badges.component.css']
})
export class BadgesComponent implements OnInit {


  public badges: Array<Badge> = [
    { icon: 'cup', name: 'cup', seen: false },
    { icon: 'controller', name: 'controller', seen: false },
    { icon: 'hand-thumbs-up', name: 'hand-thumbs-up', seen: false },
    { icon: 'ticket-perferated', name: 'ticket-perferated', seen: false },
    { icon: 'sun-fill', name: 'sun-fill', seen: false },
    { icon: 'alarm', name: 'alarm', seen: false },
    { icon: 'at', name: 'at', seen: false },
    { icon: 'badge-4k', name: 'badge-4k', seen: false },
    { icon: 'bandaid', name: 'bandaid', seen: false },
    { icon: 'bicycle', name: 'bicycle', seen: false },
    { icon: 'ticket-perferated', name: 'ticket-perferated', seen: false },
    { icon: 'sun-fill', name: 'sun-fill', seen: false },
    { icon: 'alarm', name: 'alarm', seen: false },
    { icon: 'at', name: 'at', seen: false },
    { icon: 'badge-4k', name: 'badge-4k', seen: false },
    { icon: 'bandaid', name: 'bandaid', seen: false },
    { icon: 'bicycle', name: 'bicycle', seen: false },
    { icon: 'cup', name: 'cup', seen: false },
    { icon: 'controller', name: 'controller', seen: false },
    { icon: 'hand-thumbs-up', name: 'hand-thumbs-up', seen: false },
    { icon: 'ticket-perferated', name: 'ticket-perferated', seen: false },
    { icon: 'sun-fill', name: 'sun-fill', seen: false },
    { icon: 'alarm', name: 'alarm', seen: false },
    { icon: 'at', name: 'at', seen: false },
    { icon: 'badge-4k', name: 'badge-4k', seen: false },
    { icon: 'bandaid', name: 'bandaid', seen: false },
    { icon: 'bicycle', name: 'bicycle', seen: false },
    { icon: 'ticket-perferated', name: 'ticket-perferated', seen: false },
    { icon: 'sun-fill', name: 'sun-fill', seen: false },
    { icon: 'alarm', name: 'alarm', seen: false },
    { icon: 'at', name: 'at', seen: false },
    { icon: 'badge-4k', name: 'badge-4k', seen: false },
    { icon: 'bandaid', name: 'bandaid', seen: false },
    { icon: 'apple', name: 'apple', seen: false },
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

}
