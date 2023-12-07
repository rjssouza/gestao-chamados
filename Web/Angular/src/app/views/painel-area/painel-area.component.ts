import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { FiltroAreaViewModel } from '../../models/filtros/filtro-area';
import { ListarChamadoAreaViewModel, Status, Tag, Time, Linha, Maquina, Usuario } from '../../models/painel-area/listar-chamado-area';
import { PainelAreaService } from './../../services/painel-area.service';
import { PainelIncidentesAreaStatus } from '../../models/painel-area/incidentes/painel-incidentes-area-status';
import { PainelSituacoesAreaStatus } from 'src/app/models/painel-area/incidentes/painel-situacoes-area-status';
import { MaquinasImpactadasAreaViewModel } from '../../models/painel-area/totalizadores/maquinas-impactadas-area';
import { MaquinaImpactadaViewModel } from 'src/app/models/painel-area/totalizadores/maquina-impactada-area';

@Component({
  selector: 'app-painel-area',
  templateUrl: './painel-area.component.html',
  styleUrls: ['./painel-area.component.scss']
})
export class PainelAreaComponent implements OnInit, AfterViewInit {

  public chamadoArea!: ListarChamadoAreaViewModel[];
  public PainelSituacoesAreaStatus$!: Observable<PainelSituacoesAreaStatus>;
  public MaquinasImpactadasAreaViewModel$!: Observable<MaquinasImpactadasAreaViewModel>;
  public filteredMaquinasImpactadas!: MaquinaImpactadaViewModel[];

  public slides: any[] = new Array(3).fill({ id: -1, src: '', title: '', subtitle: '' });
  activeItemIndex!: number;
  activeArea: string = "HPDC";


  constructor(
    private painelAreaService: PainelAreaService
  ) {
  }

  ngOnInit(): void {

    this.initCarousel();

    this.painelAreaService.listarChamadosArea().subscribe((result) => {
      this.chamadoArea = result?.chamados || [];
    });

    this.PainelSituacoesAreaStatus$ = this.painelAreaService.listarPainelSituacoesAreaStatus();

    this.MaquinasImpactadasAreaViewModel$ = this.painelAreaService.listarMaquinasImpactadasArea();
  }

  getTotais(PainelSituacoesAreaStatus: PainelSituacoesAreaStatus, area: string, situacao: string): number {
    const situacaoArea = PainelSituacoesAreaStatus.situacoes.find((el: PainelIncidentesAreaStatus) => el.area === area && el.situacao === situacao);
    return situacaoArea?.total ?? 0;
  }

  getMaquinasImpactadas(MaquinasImpactadasAreaViewModel: MaquinasImpactadasAreaViewModel, area: string): MaquinaImpactadaViewModel[] {
    this.filteredMaquinasImpactadas = MaquinasImpactadasAreaViewModel.totalizadorMaquinasImpactadas.filter((el: MaquinaImpactadaViewModel) => el.area === area)?.slice(0, 10);

    return this.filteredMaquinasImpactadas;
  }

  ngAfterViewInit(): void {
  }

  pageLoaded(): boolean {
    return (
      this.chamadoArea != null &&
      this.PainelSituacoesAreaStatus$ != null &&
      this.MaquinasImpactadasAreaViewModel$ != null
    );
  }

  initCarousel(): void {
    this.slides[0] = {
      id: 0,
      src: './assets/images/carousel_area.png',
      title: 'HPDC',
    };
    this.slides[1] = {
      id: 1,
      src: './assets/images/carousel_area.png',
      title: 'SPM',
    }
    this.slides[2] = {
      id: 2,
      src: './assets/images/carousel_area.png',
      title: 'Usinagem',
    }
  }


  onItemChange($event: any): void {
    this.activeItemIndex = $event;
    this.activeArea = this.slides[this.activeItemIndex].title;
  }
}
