import { Component, Input, OnInit, AfterViewInit, ElementRef, ViewChildren, QueryList } from '@angular/core';
import {
  UntypedFormControl,
  UntypedFormGroup,
  FormsModule,
} from '@angular/forms';

import { SecureService } from '../../services/security.service';
import { ChamadoService } from '../../services/chamados.service';

import { DashboardService } from '../../services/dashboard.service';
import { FiltroBaseViewModel } from 'src/app/models/filtros/filtro-base';
import {
  ListarChamadoViewModel,
  Status,
  Usuario,
  Time,
} from 'src/app/models/listar/listar-chamado';
import { Totalizador } from 'src/app/models/dashboard/totalizadores/totalizador';
import { Evolutivo } from 'src/app/models/dashboard/evolutivo/evolutivo';
import { IncidentesPorArea } from 'src/app/models/dashboard/incidentes/incidentes-por-area';
import { IncidentesPorAreaStatus } from 'src/app/models/dashboard/incidentes/incidentes-por-area-status';
import { IncidentesPorAreaTipo } from 'src/app/models/dashboard/incidentes/incidentes-por-area-tipo';
import { DashboardViewModel } from 'src/app/models/dashboard/dashboard';
import { environment } from '../../../environments/environment';
import { RegistrarProgressoChamadoViewModel } from 'src/app/models/chamado/registrarProgressoChamadoViewModel';


@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, AfterViewInit {
  public totalizador!: Totalizador;
  public evolutivo!: Evolutivo;
  public ultimosChamados!: ListarChamadoViewModel[];
  public incidentesPorArea!: IncidentesPorArea;
  public incidentesPorAreaStatus!: IncidentesPorAreaStatus;
  public incidentesPorAreaTipo!: IncidentesPorAreaTipo;
  public dashboardViewModel!: DashboardViewModel;
  public listStatus: Status[] = [];
  public listUsers: Usuario[] = [];
  public listTime: Time[] = [];
  public selectedStatus: string = '';
  public selectedUser: string = '';
  public selectedTime: string = '';


  @ViewChildren('radialProgress') radialProgressBars!: QueryList<ElementRef<HTMLDivElement>>;

  chartDoughnutData = {
    labels: ['Com impacto', 'Sem impacto'],
    datasets: [
      {
        backgroundColor: ['#00D8FF', '#DD1B16'],
        data: [80, 10],
      },
    ],
  };

  public trafficRadioGroup = new UntypedFormGroup({
    trafficRadio: new UntypedFormControl('Month'),
  });

  get href(): string {
    return `${environment.basePathSite}/#/detalhe-chamado`;
  }

  constructor(
    private _authService: SecureService,
    private dashboardService: DashboardService,
    private chamadoService: ChamadoService
  ) {
    const filtro: FiltroBaseViewModel = {
      skip: 0,
      take: 100,
    };

    this.radialProgressBars = new QueryList();

    this.dashboardService.listarChamados(filtro).subscribe((result) => {
      this.ultimosChamados = result?.result || [];
      this.listStatus = result?.status || [];
      this.listUsers = result?.usuarios || [];
      this.listTime = result?.times || [];
    });

    this.dashboardService.obterDashboardViewModel().subscribe((resultDashboardViewModel) => {
      this.dashboardViewModel = resultDashboardViewModel;
      if (resultDashboardViewModel.ehAdmin) {
        this.dashboardService.obterTotalizadores().subscribe((resultTotalizadores) => {          
          this.dashboardService.obterEvolutivo().subscribe((resultEvolutivo) => {
            this.dashboardService.obterIncidentes().subscribe((resultIncidentes) => {
              this.dashboardService.obterIncidentesPorAreaStatus().subscribe((resultIncidentesPorAreaStatus) => {          
                this.dashboardService.obterIncidentesPorAreaTipo().subscribe((resultIncidentesPorAreaTipo) => {
                  if (resultIncidentesPorAreaTipo) {
                    this.incidentesPorAreaTipo = resultIncidentesPorAreaTipo;
                  }
                  if (resultIncidentesPorAreaStatus) {
                    this.incidentesPorAreaStatus = resultIncidentesPorAreaStatus;
                  }
                  if (resultEvolutivo) {
                    this.evolutivo = resultEvolutivo;
                  }                  
                  if (resultIncidentes) {
                    this.incidentesPorArea = resultIncidentes;
                  }
                  if (resultTotalizadores) {
                    this.totalizador = resultTotalizadores;
                  }
                });
              });
            });
          });
        });  
      }    
    });     
  }

  ngOnInit(): void {
    this._authService.isAuthenticated().then((isAuthenticated) => {
      if (!isAuthenticated) this._authService.login();
    });
  }

  ngAfterViewInit(): void {

    this.radialProgressBars.changes
      .pipe()
      .subscribe(() => {
        this.radialProgressBars.forEach((progressBar) => {

          const value = (progressBar.nativeElement.getAttribute('aria-valuenow') ?? '0').includes('%')
          ? progressBar.nativeElement.getAttribute('aria-valuenow')
          : `${progressBar.nativeElement.getAttribute('aria-valuenow')}%`;
          progressBar.nativeElement.style.setProperty('--progress', value);
          progressBar.nativeElement.innerHTML = value ?? '0';
          progressBar.nativeElement.setAttribute('aria-valuenow', value ?? '0');
        })
      })
  }

  pageLoaded(): boolean {
    return (
      this.dashboardViewModel != null &&
      this.incidentesPorArea != null &&
      this.incidentesPorAreaStatus != null &&
      this.incidentesPorAreaTipo != null &&
      this.evolutivo != null &&
      this.totalizador != null &&
      this.ultimosChamados != null
    );
  }

  setTrafficPeriod(value: string): void {
    this.trafficRadioGroup.setValue({ trafficRadio: value });
  }

  atualizarProgressBar(event: any) {
    const input = event.currentTarget;
    const progressBar = input.parentNode.querySelector('.radialProgress');
    const valor = `${input.value}%`;

    progressBar.style.setProperty('--progress', valor);
    progressBar.innerHTML = valor;
    progressBar.setAttribute('aria-valuenow', valor);
  }


  registrarRadialProgress(chamado: ListarChamadoViewModel, event: any) {
    const novoPercentual = Number(event.target.value ?? 0);
    const percentualAtual = Number(chamado.percentualAtendimento ?? 0);
    if (novoPercentual < 0 || novoPercentual > 100) {
      alert('Percentual de atendimento precisa estar entre 0 e 100');
      return;
    }
    if (
      confirm(
        `Confirma o registro do progresso\nDE:     ${percentualAtual}%\nPARA: ${novoPercentual}%?`
      )
    ) {
      const registrarProgressoChamadoViewModel =
        new RegistrarProgressoChamadoViewModel(
          `Registro do progresso progresso DE: ${percentualAtual}% PARA: ${novoPercentual}%`,
          Number(chamado.idChamado),
          novoPercentual
        );
      this.chamadoService
        .registrarProgresso(registrarProgressoChamadoViewModel)
        .subscribe(
        // (result) => {
        //   chamado.percentualAtendimento = Number(
        //     chamado.percentualAtendimentoAdicionar
        //   );
        //   chamado.percentualAtendimentoAdicionar = null;
        // },
        // (error) => {
        //   chamado.percentualAtendimentoAdicionar = null;
        // }
      );
    }
    else {
      const input = event.currentTarget;
      const progressBar = input.parentNode.querySelector('.radialProgress');
      const valor = `${chamado.percentualAtendimento}%`;

      progressBar.style.setProperty('--progress', valor);
      progressBar.innerHTML = valor;
      progressBar.setAttribute('aria-valuenow', valor);
      input.value = chamado.percentualAtendimento;
    }
  }

  public visible = false;
  public textoDetalhe = '';
  public modalNumChamado = '';

  toggleLiveDemo(text: string) {
    this.visible = !this.visible;
    this.textoDetalhe = text.substring(text.split('|')[0].length + 1);
    this.modalNumChamado = text.split('|')[0];
  }

  handleLiveDemoChange(event: any) {
    this.visible = event;
  }
}
