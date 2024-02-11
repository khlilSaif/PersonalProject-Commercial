import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, first } from 'rxjs';
import { LoginRequest } from '../Models/login-request';
import { User } from '../Models/user';
import { EnvironmentConstants } from '../Models/environment-constants';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';


export interface IAuthticationService{

}

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
    private userSubject: BehaviorSubject<User | null>;
    public user: Observable<User | null>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
        this.user = this.userSubject.asObservable();
    }

    public get userValue() {
      return this.userSubject.value;
    }

    login(loginRequest: LoginRequest){
       return this.http.post<User>(`${EnvironmentConstants.environment}/users/authenticate`,loginRequest).pipe(
            map(user => {
              localStorage.setItem('user', JSON.stringify(user));
              this.userSubject.next(user);
              return user;
            }));
    }

}
