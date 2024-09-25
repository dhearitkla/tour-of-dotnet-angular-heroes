import {Hero} from "./hero";

export interface Superpower {
  superpowerId: string;
  name: string;
  grade: number;
  classification: number;
  heroes: Hero[];
  new: boolean;
}
