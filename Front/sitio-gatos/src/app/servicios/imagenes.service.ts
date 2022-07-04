import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ImagenesService {
    private baseURL: string;
    constructor(private http: HttpClient) {
        this.baseURL = 'http://localhost:44369/api/Imagen';
    }

    ObtenerImagenes(): Observable<string> {
        let url: string = `${this.baseURL}/ObtenerImagenes`;
        return this.http.get<string>(url);
    }

    MarcarImagenFavorito(id: string): Observable<string> {
        let url: string = `${this.baseURL}/MarcarImagenFavorito`;

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
              'Accept': 'application/json'
            })
        };

        return this.http.post<string>(url, JSON.stringify(id), httpOptions);
    }

    ObtenerFavoritos(): Observable<string> {
        let url: string = `${this.baseURL}/ObtenerFavoritos`;
        return this.http.get<string>(url);
    }
}