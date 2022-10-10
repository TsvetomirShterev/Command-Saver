import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { platform } from 'src/app/utils/models/platform';
import { command } from 'src/app/utils/models/command';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PlatformService {
  constructor(private httpClient: HttpClient) {}
}
