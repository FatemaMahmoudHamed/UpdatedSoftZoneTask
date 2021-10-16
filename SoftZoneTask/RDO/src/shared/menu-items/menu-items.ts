import { Injectable } from '@angular/core';

export interface BadgeItem {
  type: string;
  value: string;
}

export interface Saperator {
  name: string;
  type?: string;
}

export interface SubChildren {
  state: string;
  name: string;
  type?: string;
}

export interface ChildrenItems {
  state: string;
  name: string;
  type?: string;
  child?: SubChildren[];
  badge?: BadgeItem[];
}

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
  badge?: BadgeItem[];
  saperator?: Saperator[];
  children?: ChildrenItems[];
}

const MENUITEMS = [
  {
    state: 'home',
    name: 'الرئيسية',
    type: 'link',
    icon: 'home',
  },
  
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
