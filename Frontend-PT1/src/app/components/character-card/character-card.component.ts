import { Component, Input } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterLink } from "@angular/router";
import { Character } from "../../services/rick-morty.service";

@Component({
  selector: "app-character-card",
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: "./character-card.component.html",
  styleUrls: ["./character-card.component.css"],
})
export class CharacterCardComponent {
  @Input({ required: true }) character!: Character;
}
