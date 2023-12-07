using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using Core.Utils;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class AdicionarAnexoChamadoUseCase : UseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoAnexoEntity> _chamadoAnexoRepository;
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoComentariosEntity> _comentarioRepository;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public AdicionarAnexoChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _chamadoAnexoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoAnexoEntity>>();
            _comentarioRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoComentariosEntity>>();
        }

        /// <summary>
        /// Adicionar anexo(s) ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Anexo para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(AdicionarAnexoChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado != null)
            {
                var userName = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName;
                var nomeArquivos = new List<string>();
                modeloEntrada.AnexoChamadoArquivoViewModel?.ToList()?.ForEach(arquivo =>
                {
                    var anexo = new ChamadoAnexoEntity
                    {
                        Anexo = arquivo.Anexo,
                        IdChamado = modeloEntrada.IdChamado,
                        NomeArquivo = arquivo.NomeArquivo.MinifyString(50),
                        TipoArquivo = (!string.IsNullOrEmpty(arquivo.TipoArquivo?.Trim()) ? arquivo.TipoArquivo : Path.GetExtension(arquivo.NomeArquivo)).ToLower(),
                        UsAnexo = userName,
                        DtReg = DateTime.Now
                    };
                    nomeArquivos.Add($"-> {arquivo.NomeArquivo}");
                    _chamadoAnexoRepository.Insert(anexo);
                });

                var comentario = new ChamadoComentariosEntity
                {
                    Comentario = $"Arquivo adicionado:{Environment.NewLine}{string.Join(Environment.NewLine, nomeArquivos)}",
                    IdChamado = chamado.Id,
                    DtReg = DateTime.Now,
                    UsComentario = userName
                };
                _comentarioRepository.Insert(comentario);

                result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = chamado.Id });
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(AdicionarAnexoChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdChamado <= 0)
                AddError("AnexoChamadoUseCase", "Chamado para associação inválido");
            if (modeloEntrada.AnexoChamadoArquivoViewModel == null || !modeloEntrada.AnexoChamadoArquivoViewModel.Any())
            {
                AddError("AnexoChamadoUseCase", "Nenhum anexo informado");
            }
            for (int i = 0; i < modeloEntrada.AnexoChamadoArquivoViewModel?.Length; i++)
            {
                var anexo = modeloEntrada.AnexoChamadoArquivoViewModel[i];
                if (string.IsNullOrEmpty(anexo.NomeArquivo?.Trim()))
                    AddError("AnexoChamadoUseCase", $"Arquivo na posição {i + 1} não contém um nome válido");
                if (string.IsNullOrEmpty(anexo.Anexo?.Trim()))
                    AddError("AnexoChamadoUseCase", $"Arquivo na posição {i + 1} não foi informado corretamente");
            }
            IsValid();
        }
    }
}