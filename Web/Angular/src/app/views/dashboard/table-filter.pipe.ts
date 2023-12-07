import { Pipe, PipeTransform } from '@angular/core';
import { ListarChamadoViewModel } from 'src/app/models/listar/listar-chamado';

@Pipe({
  name: 'tableFilter'
})
export class TableFilterPipe implements PipeTransform {

  transform(list: ListarChamadoViewModel[], userValue: string, statusValue: string, timeValue: string) {

    if(!userValue && !statusValue && !timeValue) return list;

    const filteredUser = userValue? list.filter((item: ListarChamadoViewModel) => item.usSolicitante == userValue) : list;

    const filteredStatus = statusValue? filteredUser.filter((item: ListarChamadoViewModel) => item.status == statusValue) : filteredUser;

    const result = timeValue? filteredStatus.filter((item: ListarChamadoViewModel) => item.time == timeValue) : filteredStatus;

    return result;

  }

}
