import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { GatoDTO } from '../modelos/gatoDTO';

@Injectable({
    providedIn: 'root'
})
export class GatoService {
    private baseURL: string;
    constructor(private http: HttpClient) {
        this.baseURL = 'http://localhost:44369/api/Gato';
    }

    ObtenerGatos(): Observable<string> {
        let url: string = `${this.baseURL}/ObtenerGatos`;
        return this.http.get<string>(url)
    }

    ObtenerGato(id:number): Observable<string> {
        let url: string = `${this.baseURL}/ObtenerGato/` + id;
        return this.http.get<string>(url)
    }

    CrearGato(objGato: GatoDTO) {
        let url: string = `${this.baseURL}/CrearGato`;

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
              'Accept': 'application/json'
            })
        };

        return this.http.post<string>(url, objGato, httpOptions);
    }

    ActualizarGato(objGato: GatoDTO) {
        let url: string = `${this.baseURL}/ActualizarGato`;

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
              'Accept': 'application/json'
            })
        };

        return this.http.put<string>(url, objGato, httpOptions);
    }

    EliminarGato(id: number) {
        let url:string = `${this.baseURL}/EliminarGato/` + id;

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
              'Accept': 'application/json'
            })
        };

        return this.http.delete(url, httpOptions);
    }
}