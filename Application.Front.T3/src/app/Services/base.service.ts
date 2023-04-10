import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SettingsService } from './settings/settings.service';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  constructor(
    protected http: HttpClient,
    protected settings: SettingsService
  ) {}
}
