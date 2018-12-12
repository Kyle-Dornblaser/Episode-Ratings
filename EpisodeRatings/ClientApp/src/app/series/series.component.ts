import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SeriesService } from '../services/SeriesService';

@Component({
  selector: 'app-series',
  templateUrl: './series.component.html',
  styleUrls: ['./series.component.css']
})
export class SeriesComponent implements OnInit {

  id: string;
  title: string;
  type = 'line';
  data = {
    labels: [],
    datasets: [
      {
        label: "Episode Ratings",
        data: [],
        backgroundColor: "rgba(17,20,108,0.2)",
        borderColor: "rgba(17,20,108,1)"
      }
    ]
  };
  options = {
    responsive: true,
    maintainAspectRatio: false
  };
  isBusy: boolean = true;

  constructor(private route: ActivatedRoute, private seriesService: SeriesService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.refresh();
    });
  }

  refresh() {
    this.seriesService.GetSeasons(this.id).subscribe(data => {
      console.log(data);
      this.data.datasets[0].data = Array.prototype.concat.apply([], data.map(x => x.episodes.map(y => this.ratingToNumber(y.imdbRating))));
      this.data.labels = Array.prototype.concat.apply([], data.map(x => x.episodes.map(y => "S:" + x.Season + "E:" + y.Episode)));
      this.title = data[0].title;
      this.isBusy = false;
    });

  }

  ratingToNumber(rating: string) {
    let numberRating = +rating;
    if (Number.isNaN(numberRating))
      return null;
    else
      return numberRating;
  }
}
