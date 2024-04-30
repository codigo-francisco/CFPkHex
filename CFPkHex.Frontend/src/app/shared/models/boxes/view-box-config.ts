import { PokemonModel } from "../core/pokemon-model";

export interface ViewBoxConfig {
    cols: number;
    rowHeight: string;
    numberOfPokemon: number;
    pokemons: PokemonModel[];
}