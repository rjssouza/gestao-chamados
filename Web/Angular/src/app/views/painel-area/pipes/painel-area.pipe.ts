import { Pipe, PipeTransform } from '@angular/core';
import { ListarChamadoAreaViewModel } from 'src/app/models/painel-area/listar-chamado-area';


@Pipe({
  name: 'filterPainelArea'
})
export class PainelAreaPipe implements PipeTransform {

  transform(list: ListarChamadoAreaViewModel[], activeArea: string) {
    if(!activeArea) return list;

    return list.filter((item: ListarChamadoAreaViewModel) => item.area == activeArea)?.slice(0, 10);
  }

}
