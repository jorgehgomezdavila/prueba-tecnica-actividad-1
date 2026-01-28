import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <div class="min-h-screen">
      <header
        class="sticky top-0 z-20 border-b border-slate-200 bg-white/80 backdrop-blur"
      >
        <div
          class="mx-auto flex max-w-7xl items-center justify-between px-6 py-3"
        >
          <div class="flex items-center gap-3">
            <!-- Logo -->
            <div
              class="flex h-10 w-10 items-center justify-center rounded-xl bg-gradient-to-br from-sky-400 to-blue-600 text-white font-bold shadow-md"
            >
              PT
            </div>

            <div class="leading-tight">
              <div class="flex items-center gap-1">
                <span class="text-sm font-semibold text-slate-800">
                  Prueba Tecnica
                </span>
                <span class="text-sm font-semibold text-sky-500">#1</span>
              </div>
            </div>
          </div>

          <div class="flex items-center gap-4">
            <!-- Info Usuario -->
            <div class="hidden sm:flex flex-col text-right leading-tight">
              <span class="text-sm font-semibold text-slate-700">
                Jorge Humberto Gomez De Avila
              </span>
              <span class="text-xs text-slate-400">
                jorgeironhead07.gmail.com
              </span>
            </div>

            <!-- Avatar -->
            <div
              class="flex h-10 w-10 items-center justify-center rounded-full border-2 border-cyan-400 text-cyan-600 font-bold"
            >
              JH
            </div>
          </div>
        </div>
      </header>

      <main class="mx-auto px-4 py-8">
        <router-outlet />
      </main>
    </div>
  `,
})
export class AppComponent {
  year = new Date().getFullYear();
}
