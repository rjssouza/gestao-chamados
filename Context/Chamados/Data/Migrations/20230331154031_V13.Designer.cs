﻿// <auto-generated />
using System;
using Chamados.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chamados.Data.Migrations
{
    [DbContext(typeof(ChamadosDbContext))]
    [Migration("20230331154031_V13")]
    partial class V13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChamadoEntityChamadoTagEntity", b =>
                {
                    b.Property<int>("ChamadoTagId")
                        .HasColumnType("int");

                    b.Property<int>("ChamadosEntityId")
                        .HasColumnType("int");

                    b.HasKey("ChamadoTagId", "ChamadosEntityId");

                    b.HasIndex("ChamadosEntityId");

                    b.ToTable("ChamadosTagRelationship", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.AreaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Chamado.ProgressoChamadoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamado")
                        .HasColumnType("int");

                    b.Property<double>("Percentual")
                        .HasColumnType("float");

                    b.Property<string>("UsAtendente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamado");

                    b.ToTable("PercentualAtendimento", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoAnexoArquivoEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamado")
                        .HasColumnType("int");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsAnexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToSqlQuery("select Id, NomeArquivo, TipoArquivo, IdChamado, DtReg, UsReg, UsAnexo  from ChamadoAnexo as ChamadoAnexoArquivoEntity");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoAnexoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Anexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamado")
                        .HasColumnType("int");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsAnexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamado");

                    b.ToTable("ChamadoAnexo", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoClassificacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdChamadoClassPai")
                        .HasColumnType("int");

                    b.Property<int>("IdChamadoTime")
                        .HasColumnType("int");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamadoClassPai");

                    b.HasIndex("IdChamadoTime");

                    b.ToTable("ChamadoClassificacao", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoComentariosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamado")
                        .HasColumnType("int");

                    b.Property<string>("UsComentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamado");

                    b.ToTable("ChamadoComentarios", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Atendimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamadoClassificacao")
                        .HasColumnType("int");

                    b.Property<int>("IdChamadoPai")
                        .HasColumnType("int");

                    b.Property<int>("IdChamadoPrioridade")
                        .HasColumnType("int");

                    b.Property<int?>("IdChamadoTime")
                        .HasColumnType("int");

                    b.Property<int>("IdChamadoTipo")
                        .HasColumnType("int");

                    b.Property<int>("IdFormularioResposta")
                        .HasColumnType("int");

                    b.Property<int?>("IdNorisMaquina")
                        .HasColumnType("int");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.Property<string>("UsSolicitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsSolicitanteNomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdChamadoClassificacao");

                    b.HasIndex("IdChamadoPrioridade");

                    b.HasIndex("IdChamadoTime");

                    b.HasIndex("IdChamadoTipo");

                    b.ToTable("Chamado", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoHistoricoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("De")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamado")
                        .HasColumnType("int");

                    b.Property<string>("Para")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsHistorico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamado");

                    b.ToTable("ChamadoHistorico", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoPrioridadeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<int>("SlaAtendimentoHoras")
                        .HasColumnType("int");

                    b.Property<int>("SlaRecebimentoHoras")
                        .HasColumnType("int");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChamadoPrioridade", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChamadoTag", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTimeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDoTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChamadoTime", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTipoEmailAvisoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdChamadoTipo")
                        .HasColumnType("int");

                    b.Property<string>("NomeResponsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamadoTipo");

                    b.ToTable("ChamadoTipoEmailAviso", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTipoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("ChamadoTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChamadoClassificacao")
                        .HasColumnType("int");

                    b.Property<int?>("Ordem")
                        .HasColumnType("int");

                    b.Property<string>("UsPrimeiroCombate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdChamadoClassificacao");

                    b.ToTable("ChamadoTipo", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.ToTable("Formulario", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdFormulario")
                        .HasColumnType("int");

                    b.Property<int?>("IdProximaQuestao")
                        .HasColumnType("int");

                    b.Property<int>("Ordem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("TextoComplementar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFormulario");

                    b.ToTable("FormularioQuestao", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtReg")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdChamado")
                        .HasColumnType("int");

                    b.Property<int>("IdFormulario")
                        .HasColumnType("int");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.Property<string>("UsSolicitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdChamado")
                        .IsUnique()
                        .HasFilter("[IdChamado] IS NOT NULL");

                    b.HasIndex("IdFormulario");

                    b.ToTable("FormularioResposta", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaOpcaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFormularioResposta")
                        .HasColumnType("int");

                    b.Property<int>("IdOpcao")
                        .HasColumnType("int");

                    b.Property<int>("IdQuestao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFormularioResposta");

                    b.HasIndex("IdOpcao");

                    b.HasIndex("IdQuestao");

                    b.ToTable("FormularioRespostaOpcao", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioComponenteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormularioComponente", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoDicionarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFormularioOpcao")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFormularioOpcao");

                    b.ToTable("FormularioOpcaoDicionario", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdComponente")
                        .HasColumnType("int");

                    b.Property<int?>("IdProximaQuestao")
                        .HasColumnType("int");

                    b.Property<int>("IdQuestao")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdComponente");

                    b.HasIndex("IdProximaQuestao");

                    b.HasIndex("IdQuestao");

                    b.ToTable("FormularioOpcao", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.MaquinaEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Liniennummer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("Maquina", (string)null);
                });

            modelBuilder.Entity("Chamados.Domain.Entity.UsuariosChamadosEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("UsReg")
                        .HasColumnType("int");

                    b.Property<string>("UsSolicitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsSolicitanteNomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToSqlQuery("select cast(ROW_NUMBER() OVER(ORDER BY UsSolicitante ASC) as int) as Id, UsuariosChamadosEntity.* from (select distinct UsReg, UsSolicitante, UsSolicitanteNomeCompleto from chamado) as UsuariosChamadosEntity");
                });

            modelBuilder.Entity("ChamadoEntityChamadoTagEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoTagEntity", null)
                        .WithMany()
                        .HasForeignKey("ChamadoTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", null)
                        .WithMany()
                        .HasForeignKey("ChamadosEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Chamado.ProgressoChamadoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", "Chamado")
                        .WithMany("PercentualAtendimentos")
                        .HasForeignKey("IdChamado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chamado");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoAnexoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", "ChamadoEntity")
                        .WithMany("Anexos")
                        .HasForeignKey("IdChamado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChamadoEntity");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoClassificacaoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoClassificacaoEntity", "ChamadoPai")
                        .WithMany("ChamadoFilho")
                        .HasForeignKey("IdChamadoClassPai");

                    b.HasOne("Chamados.Domain.Entity.ChamadoTimeEntity", "ChamadoTime")
                        .WithMany("ChamadoClassificacao")
                        .HasForeignKey("IdChamadoTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChamadoPai");

                    b.Navigation("ChamadoTime");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoComentariosEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", "ChamadoEntity")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdChamado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChamadoEntity");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoClassificacaoEntity", "ChamadoClassificacaoEntity")
                        .WithMany("ChamadosLista")
                        .HasForeignKey("IdChamadoClassificacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.ChamadoPrioridadeEntity", "ChamadoPrioridade")
                        .WithMany("ChamadosLista")
                        .HasForeignKey("IdChamadoPrioridade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.ChamadoTimeEntity", "ChamadoTime")
                        .WithMany("Chamados")
                        .HasForeignKey("IdChamadoTime")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Chamados.Domain.Entity.ChamadoTipoEntity", "ChamadoTipo")
                        .WithMany("Chamados")
                        .HasForeignKey("IdChamadoTipo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChamadoClassificacaoEntity");

                    b.Navigation("ChamadoPrioridade");

                    b.Navigation("ChamadoTime");

                    b.Navigation("ChamadoTipo");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoHistoricoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", "ChamadoEntity")
                        .WithMany("ChamadoHistoricoLista")
                        .HasForeignKey("IdChamado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChamadoEntity");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTipoEmailAvisoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoTipoEntity", "ChamadoTipo")
                        .WithMany("ChamadoTipoEmailAvisos")
                        .HasForeignKey("IdChamadoTipo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChamadoTipo");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTipoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoClassificacaoEntity", "ChamadoClassificacao")
                        .WithMany("ChamadoTipo")
                        .HasForeignKey("IdChamadoClassificacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChamadoClassificacao");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.AreaEntity", "Area")
                        .WithMany("Formularios")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioEntity", "Formulario")
                        .WithMany("Questoes")
                        .HasForeignKey("IdFormulario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.ChamadoEntity", "Chamado")
                        .WithOne("FormularioResposta")
                        .HasForeignKey("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaEntity", "IdChamado");

                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioEntity", "Formulario")
                        .WithMany("Respostas")
                        .HasForeignKey("IdFormulario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chamado");

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaOpcaoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaEntity", "FormularioResposta")
                        .WithMany("Respostas")
                        .HasForeignKey("IdFormularioResposta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoEntity", "Opcao")
                        .WithMany("Respostas")
                        .HasForeignKey("IdOpcao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", "Questao")
                        .WithMany("Respostas")
                        .HasForeignKey("IdQuestao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FormularioResposta");

                    b.Navigation("Opcao");

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoDicionarioEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoEntity", "Opcao")
                        .WithMany("Dicionario")
                        .HasForeignKey("IdFormularioOpcao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opcao");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoEntity", b =>
                {
                    b.HasOne("Chamados.Domain.Entity.Formulario.Opcao.FormularioComponenteEntity", "Componente")
                        .WithMany("Opcoes")
                        .HasForeignKey("IdComponente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", "ProximaQuestao")
                        .WithMany("OpcoesAnteriores")
                        .HasForeignKey("IdProximaQuestao");

                    b.HasOne("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", "Questao")
                        .WithMany("Opcoes")
                        .HasForeignKey("IdQuestao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Componente");

                    b.Navigation("ProximaQuestao");

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.AreaEntity", b =>
                {
                    b.Navigation("Formularios");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoClassificacaoEntity", b =>
                {
                    b.Navigation("ChamadoFilho");

                    b.Navigation("ChamadoTipo");

                    b.Navigation("ChamadosLista");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoEntity", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("ChamadoHistoricoLista");

                    b.Navigation("Comentarios");

                    b.Navigation("FormularioResposta");

                    b.Navigation("PercentualAtendimentos");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoPrioridadeEntity", b =>
                {
                    b.Navigation("ChamadosLista");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTimeEntity", b =>
                {
                    b.Navigation("ChamadoClassificacao");

                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.ChamadoTipoEntity", b =>
                {
                    b.Navigation("ChamadoTipoEmailAvisos");

                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioEntity", b =>
                {
                    b.Navigation("Questoes");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioQuestaoEntity", b =>
                {
                    b.Navigation("Opcoes");

                    b.Navigation("OpcoesAnteriores");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.FormularioResposta.FormularioRespostaEntity", b =>
                {
                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioComponenteEntity", b =>
                {
                    b.Navigation("Opcoes");
                });

            modelBuilder.Entity("Chamados.Domain.Entity.Formulario.Opcao.FormularioOpcaoEntity", b =>
                {
                    b.Navigation("Dicionario");

                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
