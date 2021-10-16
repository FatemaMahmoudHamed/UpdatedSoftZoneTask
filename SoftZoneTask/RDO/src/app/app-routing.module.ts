import { Routes } from '@angular/router';
import { FullComponent } from './layouts/full/full.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: '',
        loadChildren: () =>
          import('./feature/feature-modules.module').then(
            (m) => m.FeatureModulesModule
          ),
      },
    ],
  }
];
