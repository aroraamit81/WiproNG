import { Injectable } from '@angular/core';
import { Training } from './classes';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class TrainingService {
  apiUrl:string = 'http://localhost:56933/api/training';
  constructor(private httpClient: HttpClient) {
  }

  getTrainings(): Observable<Training[]> {
    return this.httpClient.get<Training[]>(this.apiUrl)

  }


  addTraining(training: Training): Observable<Training> {
    return this.httpClient.post<Training>(this.apiUrl, training, {
      
    });
  }


}
