import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DetalheChamadoComponent } from './detalhe-chamado.component';

const routes: Routes = [
  {
    path: '',
    component: DetalheChamadoComponent,
    data: {
      title: $localize`Detalhes do Chamado`,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DetalheChamadoRoutingModule {}
