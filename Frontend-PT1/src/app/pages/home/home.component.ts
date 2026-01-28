import { Component, inject, signal } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RickMortyService, Character } from "../../services/rick-morty.service";
import { CharacterCardComponent } from "../../components/character-card/character-card.component";

@Component({
  selector: "app-home",
  standalone: true,
  imports: [CommonModule, FormsModule, CharacterCardComponent],
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent {
  private api = inject(RickMortyService);

  characters = signal<Character[]>([]);
  loading = signal(false);
  page = signal(1);
  totalPages = signal(0);

  filters = {
    name: "",
    status: "",
    species: "",
    type: "",
    gender: "",
  };

  constructor() {
    this.loadData();
  }

  loadData() {
    this.loading.set(true);
    // Pequeño delay para suavidad visual
    setTimeout(() => {
      this.api.getCharacters(this.page(), this.filters).subscribe({
        next: (res) => {
          this.characters.set(res.results);
          this.totalPages.set(res.info.pages);
          this.loading.set(false);
        },
        error: () => {
          this.characters.set([]);
          this.loading.set(false);
        },
      });
    }, 200);
  }

  applyFilters() {
    this.page.set(1);
    this.loadData();
  }

  clearFilters() {
    this.filters = { name: "", status: "", species: "", type: "", gender: "" };
    this.applyFilters();
  }

  changePage(delta: number) {
    const newPage = this.page() + delta;
    if (newPage >= 1 && newPage <= this.totalPages()) {
      this.page.set(newPage);
      this.loadData();
      window.scrollTo({ top: 0, behavior: "smooth" });
    }
  }
}
