import { Component, Input } from '@angular/core';
import { BoxModel } from '../../models/core/box-model';
import { ViewBoxConfig } from '../../models/boxes/view-box-config';
import { PokemonsFirstGeneration } from '../../static-data/pokemon-first-generation';
import { ViewBoxComponent } from '../view-box/view-box.component';

@Component({
  selector: 'app-list-box',
  standalone: true,
  imports: [ViewBoxComponent],
  templateUrl: './list-box.component.html',
  styleUrl: './list-box.component.scss'
})
export class ListBoxComponent {
  @Input() boxes!: BoxModel[];

  viewBoxConfig: ViewBoxConfig = {
    cols: 4,
    rowHeight: "4:1",
    numberOfPokemon: 20,
    pokemons: PokemonsFirstGeneration
  }
}
