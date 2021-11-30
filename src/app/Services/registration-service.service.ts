import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationServiceService {
  public popup: Subject<any> = new Subject<any>();

  constructor() { }
}
