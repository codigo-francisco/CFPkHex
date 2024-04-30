import { Generation } from "../../types/core/generation-types";

export interface PokemonModel {
    name: string;
    generation: Generation;
    sprite: string;
}

export function createEmptyPokemonModel(): PokemonModel {
    return {
        generation: 'empty',
        name: '',
        sprite: ''
    }
}