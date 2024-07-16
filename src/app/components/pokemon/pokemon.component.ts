import { Component } from '@angular/core';
import { PokemonService } from '../../services/pokemon.service';
import { Pokemon } from '../../models/pokemon.model';
import { Router } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { error } from 'console';

@Component({
  selector: 'app-pokemon',
  standalone: true,
  imports: [NgIf, NgFor, FormsModule, ReactiveFormsModule],
  templateUrl: './pokemon.component.html',
  styleUrl: './pokemon.component.css'
})
export class PokemonComponent {

  pokemons : Pokemon[];
  sortBy: string;
  sortDirection: string;
  errorMessage : string;

  constructor (private pokemonService : PokemonService, private router : Router)
  {
    this.pokemons = [];
    this.sortBy = "";
    this.sortDirection = "desc" //default from requirement
    this.errorMessage = "";
  }

  getAllPokemons() : void
  {
    this.pokemonService.getAllPokemons(this.sortBy, this.sortDirection).subscribe({
      next: (pokemon : Pokemon[]) =>
        {
          this.pokemons = pokemon,
          this.errorMessage = ""
        },
      error: (error) => {
        console.log (error.error);
        this.errorMessage = error.error;
      },
      complete: () => {
        // define on request complete logic
        // 'complete' is not the same as 'finalize'!!
        // this logic will not be executed if error is fired
      }
    })
  }
}
