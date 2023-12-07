import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PainelAreaComponent } from './painel-area.component';

const routes: Routes = [
  {
    path: '',
    component: PainelAreaComponent,
    data: {
      title: $localize`Painel por Área`
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class PainelAreaRoutingModule { }
