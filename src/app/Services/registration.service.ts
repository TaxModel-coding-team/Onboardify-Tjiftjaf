import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  public popup: Subject<string> = new Subject<string>();

  constructor() { }
}
