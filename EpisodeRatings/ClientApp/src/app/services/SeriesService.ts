import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Season } from '../models/Season';
import { SearchResults } from '../models/SearchResults';

@Injectable()
export class SeriesService {
    baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetSeasons(imdbId: string): Observable<Season[]> {
    return this.http.get<Season[]>(this.baseUrl + 'api/Series/' + imdbId + '/Seasons/');
  }

  public GetSearch(searchTerm: string) {
    return this.http.get<SearchResults>(this.baseUrl + 'api/Series/Search?name=' + searchTerm);
  }

}
