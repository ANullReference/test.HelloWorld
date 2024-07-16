import { Injectable } from '@angular/core';
import { Pokemon } from '../models/pokemon.model';
import { catchError, Observable, of } from 'rxjs';
import {HttpClient} from "@angular/common/http";
import { response } from 'express';
import { error } from 'console';


@Injectable({
  providedIn: 'root'
})
export class PokemonService {


  baseUrl : string = "http://localhost:5251";
  httpClient : HttpClient;
  sortBy: string;
  sortDirection: string;

  constructor (private http: HttpClient)
  {
    this.httpClient = http;
    this.sortBy = "";
    this.sortDirection = "desc" //default from requirement
  }

  ///using observable makes allows it to periodically fetch.....need to look into this one.
  getAllPokemons  (sortBy : string, sortDirection : string) : Observable<Pokemon[]>
  {

    let url = this.baseUrl + "/pokemon/tournaments/statistics?sortBy=" + sortBy;

    if (sortDirection !== "")
    {
      url = url + "&sortDirection=" + sortDirection;
    }

    console.log(url);

    return this.httpClient.get<Pokemon[]>(url);

    // return this.httpClient.get<Pokemon[]>(url)
    //     .pipe(
    //       catchError((error: Error) => {
    //         return of(error.message)
    //       })
    //     )


  }
}
