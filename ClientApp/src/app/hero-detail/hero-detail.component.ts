import { Component, Input } from '@angular/core';
import {NgIf, UpperCasePipe, Location, NgForOf, SlicePipe, NgClass} from "@angular/common";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { FormsModule } from "@angular/forms";

import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { TeamService } from "../team.service";
import { SuperpowerService } from "../superpower.service";
import { Team } from "../team";
import {Superpower} from "../superpower";
import {forkJoin} from "rxjs";

@Component({
  selector: 'app-hero-detail',
  standalone: true,
  imports: [NgIf, FormsModule, UpperCasePipe, NgForOf, RouterLink, SlicePipe, NgClass],
  templateUrl: './hero-detail.component.html',
  styleUrl: './hero-detail.component.css'
})
export class HeroDetailComponent {
  @Input() hero?: Hero;
  teams?: Team[];
  superpowers?: Superpower[];
  superpowerPicture?: File;
  selectedSuperpowerAdd?: Superpower;

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private teamService: TeamService,
    private superpowerService: SuperpowerService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getHeroAndSuperpowers();
    this.getTeams();
  }

  handleFileInput(event: Event) {
    const target = event.target as HTMLInputElement;
    if (target.files) {
      this.superpowerPicture = target.files.item(0) ?? undefined;
    }
  }

  onSuperpowerChange() {
    if (this.selectedSuperpowerAdd) {
      this.selectedSuperpowerAdd.new = true;
      this.hero?.superpowers.push(this.selectedSuperpowerAdd);
      this.filterSuperpowers();
    }
  }

  deleteSuperpower(superpower: Superpower) {
    this.hero?.superpowers?.splice(this.hero?.superpowers?.indexOf(superpower), 1);
  }

  getHeroAndSuperpowers(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));

    const heroObservable = this.heroService.getHero(id);
    const superpowersObservable = this.superpowerService.getSuperpowers();

    forkJoin([heroObservable, superpowersObservable]).subscribe((result) => {
      const hero = result[0];
      const superpowers = result[1];

      this.hero = hero;
      this.superpowers = superpowers;
      this.filterSuperpowers();
    });
  }

  getTeams(): void {
    this.teamService.getTeams()
      .subscribe(teams => this.teams = teams);
  }

  uploadFileToActivity() {
    if (this.superpowerPicture) {
      this.superpowerService.addSuperpowerPicture(this.superpowerPicture)
        .subscribe(success => alert(success));
    }
  }

  filterSuperpowers() {
    this.superpowers = this.superpowers?.filter(x => !this.hero?.superpowers.filter(y => y.superpowerId === x.superpowerId).length);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.hero) {
      this.heroService.updateHero(this.hero)
        .subscribe(() => this.goBack());
    }
  }
}
