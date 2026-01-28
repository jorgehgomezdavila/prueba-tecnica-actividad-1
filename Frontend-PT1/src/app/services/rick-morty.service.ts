import { Injectable, inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";

export interface Episode {
  id: number;
  name: string;
  episode: string;
  air_date: string;
}

export interface Character {
  id: number;
  name: string;
  status: string;
  species: string;
  type: string;
  gender: string;
  image: string;
  location: { name: string; url: string };
  origin: { name: string; url: string };
  episodeList: Episode[];
}

export interface ApiResponse {
  info: { pages: number; next: string | null; prev: string | null };
  results: Character[];
}

@Injectable({ providedIn: "root" })
export class RickMortyService {
  private http = inject(HttpClient);
  private apiUrl = "http://localhost:5135/api/characters";

  getCharacters(page: number, filters: any): Observable<ApiResponse> {
    let params = new HttpParams().set("page", page.toString());

    // Mapeamos los filtros (si existen)
    if (filters.name) params = params.set("name", filters.name);
    if (filters.status) params = params.set("status", filters.status);
    if (filters.species) params = params.set("species", filters.species);
    if (filters.type) params = params.set("type", filters.type);
    if (filters.gender) params = params.set("gender", filters.gender);

    return this.http.get<ApiResponse>(this.apiUrl, { params });
  }

  getById(id: number): Observable<Character> {
    return this.http.get<Character>(`${this.apiUrl}/${id}`);
  }
}
