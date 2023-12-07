import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AbrirChamadoComponent } from './abrir-chamado.component';

const routes: Routes = [
  {
    path: '',
    component: AbrirChamadoComponent,
    data: {
      title: $localize`Abrir Chamado`
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AbrirChamadoRoutingModule {
}
