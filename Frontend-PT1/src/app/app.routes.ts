import { Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { CharacterDetailComponent } from "./pages/character-detail/character-detail.component";

export const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "character/:id", component: CharacterDetailComponent },
  { path: "**", redirectTo: "" },
];
