import { Component } from '@angular/core';
import { SeriesService } from '../services/SeriesService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private seriesService: SeriesService, private router: Router) { }

  search(searchTerm: string) {
    this.seriesService.GetSearch(searchTerm).subscribe(data => {
      if (data.response == "True") {
        let id = data.Search[0].imdbId;
        this.router.navigate(['Series', id]);
      } else {
        alert("Search term, " + searchTerm + ", did not yield and results.");
      }
    });
  }
}
