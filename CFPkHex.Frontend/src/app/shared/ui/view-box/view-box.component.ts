import { Component, Input } from '@angular/core';
import { ViewBoxConfig } from '../../models/boxes/view-box-config';
import { createEmptyPokemonModel } from '../../models/core/pokemon-model';

@Component({
  selector: 'app-view-box',
  standalone: true,
  imports: [],
  templateUrl: './view-box.component.html',
  styleUrl: './view-box.component.scss'
})
export class ViewBoxComponent {
  @Input() viewBoxConfig!: ViewBoxConfig;

  ngOnInit() {
    const pokemons = this.viewBoxConfig.pokemons;
    const numberOfPokemon = this.viewBoxConfig.numberOfPokemon;

    if (pokemons.length < numberOfPokemon) {
      const restantes = numberOfPokemon - pokemons.length;
      const emptyModel = createEmptyPokemonModel();
      this.viewBoxConfig.pokemons.push(... Array(restantes).fill(emptyModel));
    }
  }
}
