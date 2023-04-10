import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Settings } from './settings.types';

@Injectable()
export class SettingsService {
  //private settings: Settings;
  private settings: any;

  constructor() {
    this.settings = environment;
  }

  get get(): any {
    return this.settings;
  }
}
