import {Team} from "./team";
import {Superpower} from "./superpower";

export interface Hero {
  heroId: string;
  name: string;
  superpowers: Superpower[]
  teamId: string;
  team: Team;
}
