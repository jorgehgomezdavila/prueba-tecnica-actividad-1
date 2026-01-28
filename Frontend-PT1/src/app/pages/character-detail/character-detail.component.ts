import { Component, inject, signal } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { RickMortyService, Character } from "../../services/rick-morty.service";

@Component({
  selector: "app-character-detail",
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: "./character-detail.component.html",
  styleUrls: ["./character-detail.component.css"],
})
export class CharacterDetailComponent {
  private route = inject(ActivatedRoute);
  private api = inject(RickMortyService);

  character = signal<Character | null>(null);

  constructor() {
    const id = this.route.snapshot.paramMap.get("id");
    if (id) {
      this.api.getById(+id).subscribe((data) => this.character.set(data));
    }
  }

  translate(value: string): string {
    const dict: any = {
      Alive: "Vivo",
      Dead: "Muerto",
      unknown: "Desconocido",
      Human: "Humano",
      Alien: "Alienígena",
      Male: "Masculino",
      Female: "Femenino",
      Genderless: "Sin Género",
    };
    return dict[value] || value;
  }

  getEpisodeNumber(url: string): string {
    return url.split("/").pop() || "?";
  }
}
