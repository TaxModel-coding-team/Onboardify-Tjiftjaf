import { Injectable } from '@angular/core';
import { Task } from './task';
import { tasks } from './task-list';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor() { }
  
  getTasks(): Task[] {
    return tasks;
  }
}
