import {Hero} from "./hero";

export interface Team {
  teamId: string;
  name: string;
  purpose: string;
  powerPoints: number
  heroes: Hero[];
}
