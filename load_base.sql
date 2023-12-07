USE [BDCHNORIS]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6d1227d8-d89c-49a9-bce3-0d55a7c37e0e', N'ADMIN', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7593d3ff-6bf1-418b-a198-55f1f5fe100b', N'COLABORADOR', N'COLABORADOR', NULL)
GO
SET IDENTITY_INSERT [dbo].[Area] ON 
GO
INSERT [dbo].[Area] ([Id], [Nome]) VALUES (1, N'Geral')
GO
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Formulario] ON 
GO
INSERT [dbo].[Formulario] ([Id], [IdArea], [Nome]) VALUES (1, 1, N'Formulário Noris')
GO
SET IDENTITY_INSERT [dbo].[Formulario] OFF
GO
SET IDENTITY_INSERT [dbo].[ChamadoPrioridade] ON 
GO
INSERT [dbo].[ChamadoPrioridade] ([Id], [Ativo], [Prioridade], [SlaAtendimentoHoras], [SlaRecebimentoHoras], [DtReg], [UsReg]) VALUES (1, 1, 0, 4, 1, CAST(N'2023-03-01T19:52:48.9300000' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoPrioridade] ([Id], [Ativo], [Prioridade], [SlaAtendimentoHoras], [SlaRecebimentoHoras], [DtReg], [UsReg]) VALUES (2, 1, 1, 4, 1, CAST(N'2023-03-01T19:53:02.9466667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoPrioridade] ([Id], [Ativo], [Prioridade], [SlaAtendimentoHoras], [SlaRecebimentoHoras], [DtReg], [UsReg]) VALUES (3, 1, 2, 4, 1, CAST(N'2023-03-01T19:53:08.4800000' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoPrioridade] ([Id], [Ativo], [Prioridade], [SlaAtendimentoHoras], [SlaRecebimentoHoras], [DtReg], [UsReg]) VALUES (4, 1, 3, 4, 1, CAST(N'2023-03-01T19:53:16.2566667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoPrioridade] ([Id], [Ativo], [Prioridade], [SlaAtendimentoHoras], [SlaRecebimentoHoras], [DtReg], [UsReg]) VALUES (5, 1, 4, 4, 1, CAST(N'2023-03-01T19:53:21.0133333' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ChamadoPrioridade] OFF
GO
SET IDENTITY_INSERT [dbo].[ChamadoTime] ON 
GO
INSERT [dbo].[ChamadoTime] ([Id], [Email], [NomeDoTime], [Responsavel], [DtReg], [UsReg]) VALUES (1, N'felipe.marcos@nemak.com', N'Manutenção', N'ex-fmarcos', CAST(N'2023-02-28T11:45:21.5033333' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTime] ([Id], [Email], [NomeDoTime], [Responsavel], [DtReg], [UsReg]) VALUES (2, N'eder.goncalves@nemak.com', N'TA', N'EGONCALVES', CAST(N'2023-02-28T11:45:21.5033333' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTime] ([Id], [Email], [NomeDoTime], [Responsavel], [DtReg], [UsReg]) VALUES (3, N'philippe.henrique@nemak.com', N'TI', N'ex-phenrique01', CAST(N'2023-02-28T11:45:21.5033333' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTime] ([Id], [Email], [NomeDoTime], [Responsavel], [DtReg], [UsReg]) VALUES (4, N'felipe.marcos@nemak.com', N'Desenvolvimento', N'ex-fmarcos', CAST(N'2023-02-28T11:46:17.0366667' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ChamadoTime] OFF
GO
SET IDENTITY_INSERT [dbo].[ChamadoClassificacao] ON 
GO
INSERT [dbo].[ChamadoClassificacao] ([Id], [Classificacao], [IdChamadoClassPai], [IdChamadoTime], [DtReg], [UsReg]) VALUES (1, N'Incidente', NULL, 1, CAST(N'2023-02-28T11:46:17.0366667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoClassificacao] ([Id], [Classificacao], [IdChamadoClassPai], [IdChamadoTime], [DtReg], [UsReg]) VALUES (2, N'Dúvida', NULL, 2, CAST(N'2023-02-28T11:46:17.0366667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoClassificacao] ([Id], [Classificacao], [IdChamadoClassPai], [IdChamadoTime], [DtReg], [UsReg]) VALUES (3, N'Requisição', NULL, 4, CAST(N'2023-02-28T11:46:17.0366667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoClassificacao] ([Id], [Classificacao], [IdChamadoClassPai], [IdChamadoTime], [DtReg], [UsReg]) VALUES (4, N'Sugestões ou reclamações', NULL, 2, CAST(N'2023-02-28T11:46:17.0366667' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ChamadoClassificacao] OFF
GO
SET IDENTITY_INSERT [dbo].[ChamadoTipo] ON 
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (11, 1, N'Parada de máquina', 2, 0, N'EX-FMARCOS', CAST(N'2023-03-01T19:59:26.1533333' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (12, 1, N'Duvida', 3, 1, N'EX-FMARCOS', CAST(N'2023-03-01T20:00:54.5466667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (13, 1, N'Novo relatório', 4, 2, N'EX-FMARCOS', CAST(N'2023-03-01T20:01:41.6433333' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (14, 1, N'Modificação de relatório', 4, 3, N'EX-FMARCOS', CAST(N'2023-03-01T20:01:59.3666667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (15, 1, N'Erro em relatório', 2, 4, N'EX-FMARCOS', CAST(N'2023-03-01T20:02:49.2066667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipo] ([Id], [Ativo], [ChamadoTipo], [IdChamadoClassificacao], [Ordem], [UsPrimeiroCombate], [DtReg], [UsReg]) VALUES (16, 1, N'Sugestões e reclamações', 2, 5, N'EX-FMARCOS', CAST(N'2023-03-01T20:03:27.3733333' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ChamadoTipo] OFF
GO
SET IDENTITY_INSERT [dbo].[FormularioQuestao] ON 
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (1, 1, NULL, 1, N'Em que podemos ajudar?', N'Chamados Noris')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (2, 1, NULL, 3, N'Qual área?', N'Informações da máquina')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (3, 1, NULL, 3, N'Selecione a máquina', N'HPDC')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (4, 1, NULL, 4, N'Faça uma breve descrição', N'Máquina')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (5, 1, NULL, 2, N'Para qual área de solicitação?', N'Requisição')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (6, 1, NULL, 3, N'Descreva o que você precisa?', N'Relatório - Descrição')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (7, 1, NULL, 2, N'Escreva sua sugestão', N'Sugestão')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (8, 1, NULL, 2, N'Descreva sua reclamação', N'Reclamação')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (9, 1, NULL, 2, N'Descreva a sua dúvida', N'Dúvida')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (10, 1, NULL, 2, N'Onde é o problema?', N'Estou com um problema')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (11, 1, NULL, 2, N'Link do relatório', N'Relatórios')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (12, 1, NULL, 3, N'Faça uma breve descrição', N'Algo mais a adicionar?')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (13, 1, NULL, 3, N'Selecione a máquina', N'Carrossel')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (14, 1, NULL, 3, N'Selecione a máquina', N'Core Shop')
GO
INSERT [dbo].[FormularioQuestao] ([Id], [IdFormulario], [IdProximaQuestao], [Ordem], [TextoComplementar], [Titulo]) VALUES (15, 1, NULL, 3, N'Selecione a máquina', N'Machining')
GO
SET IDENTITY_INSERT [dbo].[FormularioQuestao] OFF
GO
SET IDENTITY_INSERT [dbo].[FormularioComponente] ON 
GO
INSERT [dbo].[FormularioComponente] ([Id], [IdTipo], [Label]) VALUES (1, 1, N'radiobutton')
GO
INSERT [dbo].[FormularioComponente] ([Id], [IdTipo], [Label]) VALUES (2, 2, N'textbox')
GO
INSERT [dbo].[FormularioComponente] ([Id], [IdTipo], [Label]) VALUES (3, 3, N'dropdown')
GO
INSERT [dbo].[FormularioComponente] ([Id], [IdTipo], [Label]) VALUES (4, 4, N'textarea')
GO
SET IDENTITY_INSERT [dbo].[FormularioComponente] OFF
GO
SET IDENTITY_INSERT [dbo].[FormularioOpcao] ON 
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (1, 1, 10, 1, N'Estou com problemas (relatório, máquina ou acesso)')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (2, 1, 9, 1, N'Estou com dúvidas')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (3, 1, 5, 1, N'Preciso realizar uma solicitação')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (4, 1, 7, 1, N'Quero apresentar sugestões')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (5, 1, 6, 10, N'Relatórios')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (6, 1, 2, 10, N'Máquina')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (7, 1, 12, 10, N'Acesso')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (9, 2, NULL, 11, N'Link')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (10, 4, NULL, 12, N'Descrição')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (11, 1, 13, 2, N'Carrossel')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (12, 1, 3, 2, N'HPDC')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (13, 1, 14, 2, N'Core Shop')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (14, 3, 4, 3, N'Selecione a maquina')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (17, 4, NULL, 4, N'Descrição')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (18, 1, 11, 5, N'Acesso ')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (19, 1, 12, 5, N'Funcionalidades ')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (20, 1, 6, 5, N'Relatórios')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (21, 4, 11, 6, N'Descreva o que precisa')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (22, 4, NULL, 7, N'Descreva sua sugestão')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (23, 4, NULL, 8, N'Descreva sua reclamação')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (24, 4, NULL, 9, N'Descreva sua dúvida')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (25, 1, 15, 2, N'Machining')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (26, 3, 4, 13, N'Selecione a maquina')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (27, 3, 4, 14, N'Selecione a maquina')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (28, 3, 4, 15, N'Selecione a maquina')
GO
INSERT [dbo].[FormularioOpcao] ([Id], [IdComponente], [IdProximaQuestao], [IdQuestao], [Texto]) VALUES (29, 1, 12, 10, N'Incidente generalizado')
GO
SET IDENTITY_INSERT [dbo].[FormularioOpcao] OFF
GO
SET IDENTITY_INSERT [dbo].[FormularioOpcaoDicionario] ON 
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (2, N'4', 14, N'0')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (3, N'4', 26, N'0')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (4, N'4', 27, N'0')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (5, N'4', 28, N'0')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (6, N'5', 2, N'3')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (7, N'5', 1, N'2')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (8, N'5', 3, N'4')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (9, N'5', 4, N'5')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (10, N'2', 1, N'3')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (11, N'2', 6, N'5')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (12, N'2', 2, N'1')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (13, N'2', 3, N'2')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (14, N'2', 4, N'3')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (15, N'1', 1, N'11')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (16, N'1', 2, N'12')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (17, N'1', 4, N'16')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (18, N'1', 20, N'13')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (19, N'1', 20, N'14')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (20, N'1', 5, N'15')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (21, N'3', 12, N'HPDC')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (22, N'3', 11, N'Carrosel')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (23, N'3', 13, N'Core Shop')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (24, N'3', 25, N'Machining')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (26, N'3', 5, N'Relatorios')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (27, N'3', 6, N'Maquina')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (28, N'3', 7, N'Acesso')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (29, N'3', 1, N'Incidente')
GO
INSERT [dbo].[FormularioOpcaoDicionario] ([Id], [Chave], [IdFormularioOpcao], [Valor]) VALUES (30, N'3', 25, N'Usinagem')
GO
SET IDENTITY_INSERT [dbo].[FormularioOpcaoDicionario] OFF
GO
CREATE OR ALTER view [dbo].[Linha] as
Select Linennumber = 1, Bezeichnung = 'Carrossel' union all
Select Linennumber = 2, Bezeichnung = 'HPDC'      union all
Select Linennumber = 3, Bezeichnung = 'Core Shop' union all
Select Linennumber = 4, Bezeichnung = 'Machining' 
GO
CREATE OR ALTER view [dbo].[Maquina] as
Select Id = 151, Liniennummer = 2, Bezeichnung = 'Buhler 1500 - 01' union all
Select Id = 152, Liniennummer = 2, Bezeichnung = 'Buhler 1500 - 02' union all
Select Id = 153, Liniennummer = 2, Bezeichnung = 'Buhler 1500 - 03' union all
Select Id = 154, Liniennummer = 2, Bezeichnung = 'Buhler 1500 - 04' union all
Select Id = 155, Liniennummer = 2, Bezeichnung = 'Buhler 1500 - 05' union all
Select Id = 156, Liniennummer = 2, Bezeichnung = 'IDRA 1500 - 06' union all
Select Id = 181, Liniennummer = 2, Bezeichnung = 'Buhler 1800 - 13' union all
Select Id = 182, Liniennummer = 2, Bezeichnung = 'Buhler 1800 - 12' union all
Select Id = 201, Liniennummer = 2, Bezeichnung = 'IDRA 2000 - 16' union all
Select Id = 202, Liniennummer = 2, Bezeichnung = 'IDRA 2000 - 15' union all
Select Id = 203, Liniennummer = 2, Bezeichnung = 'IDRA 2000 - 14' union all
Select Id = 231, Liniennummer = 2, Bezeichnung = 'Buhler 2300 - 17' union all
Select Id = 232, Liniennummer = 2, Bezeichnung = 'Buhler 2300 - 11' union all
Select Id = 233, Liniennummer = 2, Bezeichnung = 'Buhler 2300 -  10' union all
Select Id = 251, Liniennummer = 2, Bezeichnung = 'Italpresse 2500 - 01' union all
Select Id = 252, Liniennummer = 2, Bezeichnung = 'Italpresse 2500 - 02' union all
Select Id = 253, Liniennummer = 2, Bezeichnung = 'Italpresse 2500 - 03' union all
Select Id = 271, Liniennummer = 2, Bezeichnung = 'IDRA 2700 - 04' union all
Select Id = 272, Liniennummer = 2, Bezeichnung = 'IDRA 2700 - 05' union all
Select Id = 273, Liniennummer = 2, Bezeichnung = 'IDRA 2700 - 06' union all
Select Id = 301, Liniennummer = 2, Bezeichnung = 'Prensa Bloco 01' union all
Select Id = 302, Liniennummer = 2, Bezeichnung = 'Prensa Bloco 02' union all
Select Id = 303, Liniennummer = 2, Bezeichnung = 'Prensa Bloco 03' union all
Select Id = 304, Liniennummer = 2, Bezeichnung = 'Prensa Bloco 04' union all
Select Id = 402, Liniennummer = 1, Bezeichnung = 'Ilha 02' union all
Select Id = 403, Liniennummer = 1, Bezeichnung = 'Ilha 03' union all
Select Id = 405, Liniennummer = 1, Bezeichnung = 'Rotacast 01' union all
Select Id = 406, Liniennummer = 1, Bezeichnung = 'Serra Rotacast 01' union all
Select Id = 407, Liniennummer = 1, Bezeichnung = 'Fresa Rotacast 01' union all
Select Id = 408, Liniennummer = 1, Bezeichnung = 'Disp.Integridade Macho Rotacast 01' union all
Select Id = 410, Liniennummer = 1, Bezeichnung = 'Cabine de Limpeza - Carrossel 10' union all
Select Id = 411, Liniennummer = 1, Bezeichnung = 'Cabine de Limpeza do Carrossel 11' union all
Select Id = 502, Liniennummer = 1, Bezeichnung = 'Carrossel 02' union all
Select Id = 504, Liniennummer = 1, Bezeichnung = 'Carrossel 04' union all
Select Id = 505, Liniennummer = 1, Bezeichnung = 'Carrossel 05' union all
Select Id = 506, Liniennummer = 1, Bezeichnung = 'Carrossel 06' union all
Select Id = 509, Liniennummer = 1, Bezeichnung = 'Carrossel 07' union all
Select Id = 510, Liniennummer = 1, Bezeichnung = 'Carrossel 10' union all
Select Id = 511, Liniennummer = 1, Bezeichnung = 'Carrossel 11' union all
Select Id = 512, Liniennummer = 1, Bezeichnung = 'Carrossel 12' union all
Select Id = 513, Liniennummer = 1, Bezeichnung = 'Carrossel 13' union all
Select Id = 514, Liniennummer = 1, Bezeichnung = 'Carrossel 08' union all
Select Id = 515, Liniennummer = 1, Bezeichnung = 'Carrossel 09' union all
Select Id = 516, Liniennummer = 1, Bezeichnung = 'Hammer C-13' union all
Select Id = 517, Liniennummer = 1, Bezeichnung = 'Swing Master C-13' union all
Select Id = 518, Liniennummer = 1, Bezeichnung = 'Fresa C-13' union all
Select Id = 519, Liniennummer = 1, Bezeichnung = 'Serra C-13' union all
Select Id = 520, Liniennummer = 1, Bezeichnung = 'Disp.Integridade Macho C-13' union all
Select Id = 521, Liniennummer = 3, Bezeichnung = 'Sopradora H-25-01' union all
Select Id = 524, Liniennummer = 3, Bezeichnung = 'Sopradora H-25-04' union all
Select Id = 525, Liniennummer = 3, Bezeichnung = 'Sopradora H-25-05' union all
Select Id = 526, Liniennummer = 3, Bezeichnung = 'Sopradora H-25-06' union all
Select Id = 528, Liniennummer = 3, Bezeichnung = 'Sopradora SHT-01' union all
Select Id = 550, Liniennummer = 3, Bezeichnung = 'FORNO SOLUBILIZAÇÃO' union all
Select Id = 551, Liniennummer = 3, Bezeichnung = 'FORNO ENVELHECIMENTO' union all
Select Id = 552, Liniennummer = 3, Bezeichnung = 'FORNO SOLUBILIZAÇAO' union all
Select Id = 602, Liniennummer = 3, Bezeichnung = 'Sopradora 6-BV-02' union all
Select Id = 603, Liniennummer = 3, Bezeichnung = 'Sopradora 6-BV-03' union all
Select Id = 605, Liniennummer = 3, Bezeichnung = 'Sopradora 6-BV-05' union all
Select Id = 606, Liniennummer = 3, Bezeichnung = 'Sopradora 6-BV-06' union all
Select Id = 650, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-20' union all
Select Id = 651, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-01' union all
Select Id = 652, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-02' union all
Select Id = 653, Liniennummer = 3, Bezeichnung = 'Sopradora SPC65-03' union all
Select Id = 654, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-04' union all
Select Id = 655, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-05' union all
Select Id = 656, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-06' union all
Select Id = 659, Liniennummer = 3, Bezeichnung = 'Sopradora SPC65-09' union all
Select Id = 660, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-10' union all
Select Id = 661, Liniennummer = 3, Bezeichnung = 'Sopradora SPC-65-11' union all
Select Id = 671, Liniennummer = 3, Bezeichnung = 'Sopradora OMR-GF-1' union all
Select Id = 672, Liniennummer = 3, Bezeichnung = 'Sopradora OMR-GF-2' union all
Select Id = 673, Liniennummer = 3, Bezeichnung = 'Sopradora OMR-GF-3' union all
Select Id = 675, Liniennummer = 3, Bezeichnung = 'Sopradora 1824-01' union all
Select Id = 676, Liniennummer = 3, Bezeichnung = 'Sopradora 1824-02' union all
Select Id = 681, Liniennummer = 3, Bezeichnung = 'Sopradora H-16-01' union all
Select Id = 682, Liniennummer = 3, Bezeichnung = 'Sopradora H-16-02' union all
Select Id = 683, Liniennummer = 3, Bezeichnung = 'Sopradora H-16-03' union all
Select Id = 684, Liniennummer = 3, Bezeichnung = 'Sopradora H-16-04' union all
Select Id = 811, Liniennummer = 3, Bezeichnung = 'Sopradora 18-BCD-1' union all
Select Id = 812, Liniennummer = 3, Bezeichnung = 'Sopradora 18-BCD-2' union all
Select Id = 1000, Liniennummer = 4, Bezeichnung = 'GM-GP12 - Estação de Controle' union all
Select Id = 2000, Liniennummer = 4, Bezeichnung = 'Estação de Controle Bloco Kappa' union all
Select Id = 3000, Liniennummer = 4, Bezeichnung = 'Estação de Controle Cabeçote Kappa' union all
Select Id = 7000, Liniennummer = 4, Bezeichnung = '7000 - Heller - Usinagem Cab.VW' union all
Select Id = 7006, Liniennummer = 4, Bezeichnung = '7006 - Heller - Usinagem Bloco VW' union all
Select Id = 7007, Liniennummer = 4, Bezeichnung = '7007 - Heller - Usinagem Bloco VW' union all
Select Id = 7008, Liniennummer = 4, Bezeichnung = '7008 - Heller - Usinagem Bloco VW' union all
Select Id = 7009, Liniennummer = 4, Bezeichnung = '7009 - Heller - Usinagem Bloco VW' union all
Select Id = 7010, Liniennummer = 4, Bezeichnung = '7010 - Heller - Usinagem Bloco VW' union all
Select Id = 7011, Liniennummer = 4, Bezeichnung = '7011 - Heller   - Usinagem Bloco VW' union all
Select Id = 7012, Liniennummer = 4, Bezeichnung = '7012 - Heller H2000' union all
Select Id = 7013, Liniennummer = 4, Bezeichnung = '7013 - TongTai - 1 - Usinagem Bloco VW' union all
Select Id = 7014, Liniennummer = 4, Bezeichnung = '7014 - TongTai - 2 - Usinagem Bloco VW' union all
Select Id = 7015, Liniennummer = 4, Bezeichnung = '7015 - Grob - Usinagem Bloco VW' union all
Select Id = 7016, Liniennummer = 4, Bezeichnung = '7016 - Grob - Usinagem Bloco VW' union all
Select Id = 7017, Liniennummer = 4, Bezeichnung = '7017 - Grob - Usinagem Bloco VW' union all
Select Id = 7030, Liniennummer = 4, Bezeichnung = '7030 - TH Cab. VW ' union all
Select Id = 7031, Liniennummer = 4, Bezeichnung = '7031 - TH Bloco VW' union all
Select Id = 7032, Liniennummer = 4, Bezeichnung = '7032 - TH Bloco VW ' union all
Select Id = 7033, Liniennummer = 4, Bezeichnung = '7033 - Estanq. Bloco VW ' union all
Select Id = 7034, Liniennummer = 4, Bezeichnung = '7034 - Estanq. Cab. VW' union all
Select Id = 7035, Liniennummer = 4, Bezeichnung = '7035 - Estanq. Bloco VW' union all
Select Id = 7036, Liniennummer = 4, Bezeichnung = '7036 - Lavadora Cab. VW' union all
Select Id = 7037, Liniennummer = 4, Bezeichnung = '7037 - Lavadora Bloco VW ' union all
Select Id = 7038, Liniennummer = 4, Bezeichnung = '7038 - Lavadora Bloco VW' union all
Select Id = 7100, Liniennummer = 4, Bezeichnung = '7100 - CNC B. SGE' union all
Select Id = 7101, Liniennummer = 4, Bezeichnung = '7101 - CNC B. SGE' union all
Select Id = 7105, Liniennummer = 4, Bezeichnung = '7105 - Lavadora B. SGE' union all
Select Id = 7106, Liniennummer = 4, Bezeichnung = '7106 - Estanqueidade B. SGE' union all
Select Id = 7111, Liniennummer = 4, Bezeichnung = 'Estação de Gravação de Código DMC' union all
Select Id = 7114, Liniennummer = 4, Bezeichnung = '7114 - Gage Line Bloco SGE' union all
Select Id = 7116, Liniennummer = 4, Bezeichnung = '7116 - Estanqueidade Cabeçote - Kappa' union all
Select Id = 7117, Liniennummer = 4, Bezeichnung = '7117 - Teste Girard Marposs – Kappa' union all
Select Id = 7118, Liniennummer = 4, Bezeichnung = '7118 - Estanqueidade Bloco Kappa' union all
Select Id = 7120, Liniennummer = 4, Bezeichnung = '7120 - CNC 1 Bed Plate ' union all
Select Id = 7121, Liniennummer = 4, Bezeichnung = '7121 - CNC 2 Bed Plate' union all
Select Id = 7122, Liniennummer = 4, Bezeichnung = '7122 - CNC 3 Bed Plate' union all
Select Id = 7125, Liniennummer = 4, Bezeichnung = '7125 - Lavadora Bed Plate' union all
Select Id = 7126, Liniennummer = 4, Bezeichnung = '7126 - Estanqueidade Bed Plate' union all
Select Id = 7131, Liniennummer = 4, Bezeichnung = 'GAGE IN LINE POLLUX 06166' union all
Select Id = 7160, Liniennummer = 4, Bezeichnung = '7160 - CNC 1 Cab. GM SGE' union all
Select Id = 7161, Liniennummer = 4, Bezeichnung = '7161 - CNC 2 Cab. GM SGE' union all
Select Id = 7170, Liniennummer = 4, Bezeichnung = '7170 - Lavadora Tecnofirma Cab. SGE' union all
Select Id = 7171, Liniennummer = 4, Bezeichnung = '7171 - Estanqueidade SWB Cab. SGE' union all
Select Id = 7173, Liniennummer = 4, Bezeichnung = '7173 - Gage Line Engeteam Cab. SGE' union all
Select Id = 7174, Liniennummer = 4, Bezeichnung = 'Estação de Gravação de Código DMC ' union all
Select Id = 7200, Liniennummer = 4, Bezeichnung = '7200 - Lavadora Air-Blow BR10 ' union all
Select Id = 7202, Liniennummer = 4, Bezeichnung = '7202 - Teste Estanqueidade BR10' union all
Select Id = 7250, Liniennummer = 4, Bezeichnung = '7250 - Heller - Usinagem Bloco VW' union all
Select Id = 7251, Liniennummer = 4, Bezeichnung = '7251 - GROB - Usinagem Bloco VW' union all
Select Id = 7252, Liniennummer = 4, Bezeichnung = '7252 - Heller - Usinagem Bloco VW' union all
Select Id = 7300, Liniennummer = 4, Bezeichnung = '7300 - MAG01 - Usinagem Bloco CSS' union all
Select Id = 7301, Liniennummer = 4, Bezeichnung = '7301 - MAG02 - Usinagem Bloco CSS' union all
Select Id = 7302, Liniennummer = 4, Bezeichnung = '7302 - MAG03 - Usinagem Bloco CSS' union all
Select Id = 7303, Liniennummer = 4, Bezeichnung = '7303 - MAG04 - Usinagem Bloco CSS' union all
Select Id = 7305, Liniennummer = 4, Bezeichnung = '7305 - TECNOFIRMA - Lavadora Bloco CSS' union all
Select Id = 7306, Liniennummer = 4, Bezeichnung = '7306 - Teste Estanqueidade - 1 - Bloco CSS' union all
Select Id = 7307, Liniennummer = 4, Bezeichnung = '7307 - Teste Estanqueidade - 2 - Bloco CSS' union all
Select Id = 7308, Liniennummer = 4, Bezeichnung = '7308 - Gage Line - Bloco CSS' union all
Select Id = 7315, Liniennummer = 4, Bezeichnung = '7315 - Controle de Camara - Cab. CSS' union all
Select Id = 7320, Liniennummer = 4, Bezeichnung = '7320 - MAG01 - Usinagem Cab. CSS' union all
Select Id = 7321, Liniennummer = 4, Bezeichnung = '7321 - MAG02  - Usinagem Cab. CSS' union all
Select Id = 7322, Liniennummer = 4, Bezeichnung = '7322 - MAG03  - Usinagem Cab. CSS' union all
Select Id = 7323, Liniennummer = 4, Bezeichnung = '7323 - MAG04  - Usinagem Cab. CSS' union all
Select Id = 7325, Liniennummer = 4, Bezeichnung = '7325 - TECNOFIRMA - Lavadora Cab. CSS' union all
Select Id = 7326, Liniennummer = 4, Bezeichnung = '7326 - Teste Estanqueidade - 1 - Cab. CSS' union all
Select Id = 7327, Liniennummer = 4, Bezeichnung = '7327 - Teste Estanqueidade - 2 - Cab. CSS' union all
Select Id = 7328, Liniennummer = 4, Bezeichnung = '7328 - Gage Line - Cab. CSS' union all
Select Id = 7610, Liniennummer = 4, Bezeichnung = '7610 - Heller ' union all
Select Id = 7611, Liniennummer = 4, Bezeichnung = '7611 - Heller ' union all
Select Id = 7612, Liniennummer = 4, Bezeichnung = '7612 - Heller ' union all
Select Id = 7613, Liniennummer = 4, Bezeichnung = '7613 - Heller' union all
Select Id = 7614, Liniennummer = 4, Bezeichnung = '7614 - Heller ' union all
Select Id = 7615, Liniennummer = 4, Bezeichnung = '7615 - Heller' union all
Select Id = 7616, Liniennummer = 4, Bezeichnung = '7616 - Heller ' union all
Select Id = 7617, Liniennummer = 4, Bezeichnung = '7617 - Heller ' union all
Select Id = 7618, Liniennummer = 4, Bezeichnung = '7618 - Heller ' union all
Select Id = 7619, Liniennummer = 4, Bezeichnung = '7619 - Heller' union all
Select Id = 7620, Liniennummer = 4, Bezeichnung = '7620 - Heller - BR10' union all
Select Id = 7621, Liniennummer = 4, Bezeichnung = '7621 - Heller - BR10' union all
Select Id = 7622, Liniennummer = 4, Bezeichnung = '7622 - Heller - BR10' union all
Select Id = 7623, Liniennummer = 4, Bezeichnung = '7623 - Heller - BR10' union all
Select Id = 7624, Liniennummer = 4, Bezeichnung = '7624 - Heller ' union all
Select Id = 7630, Liniennummer = 4, Bezeichnung = '7630 - Estanqueidade Mecalix' union all
Select Id = 7644, Liniennummer = 4, Bezeichnung = '7644 - Heller ' union all
Select Id = 7645, Liniennummer = 4, Bezeichnung = '7645 - Heller ' union all
Select Id = 7646, Liniennummer = 4, Bezeichnung = '7646 - Heller' union all
Select Id = 7647, Liniennummer = 4, Bezeichnung = '7647 - Heller ' union all
Select Id = 7648, Liniennummer = 4, Bezeichnung = '7648 - Heller' union all
Select Id = 7657, Liniennummer = 4, Bezeichnung = '7657 - Estanqueidade ' union all
Select Id = 7658, Liniennummer = 4, Bezeichnung = '7658 - Estanqueidade ' union all
Select Id = 7672, Liniennummer = 4, Bezeichnung = '7672 - Estanqueidade ' union all
Select Id = 7680, Liniennummer = 4, Bezeichnung = '7680 - Estanqueidade' union all
Select Id = 7681, Liniennummer = 4, Bezeichnung = '7681 - Estanqueidade ' union all
Select Id = 7686, Liniennummer = 4, Bezeichnung = '7686 - Estanqueidade Sup. Shift' union all
Select Id = 7687, Liniennummer = 4, Bezeichnung = '7687 - Estanqueidade Caixa Shift' union all
Select Id = 7688, Liniennummer = 4, Bezeichnung = '7688 - Estanqueidade Sup. E-Torq ' union all
Select Id = 7700, Liniennummer = 4, Bezeichnung = '7700 - Fresa' union all
Select Id = 7701, Liniennummer = 1, Bezeichnung = '7701 - Serra Orland 1 ' union all
Select Id = 7702, Liniennummer = 1, Bezeichnung = '7702 - Serra Orland 2 ' union all
Select Id = 7703, Liniennummer = 1, Bezeichnung = '7703 - Serra Orland 3' union all
Select Id = 7704, Liniennummer = 4, Bezeichnung = '7704 - Transfer Berard III ' union all
Select Id = 7705, Liniennummer = 4, Bezeichnung = '7705 - Promet III' union all
Select Id = 7710, Liniennummer = 4, Bezeichnung = 'Estanqueidade Suporte GSE' union all
Select Id = 7711, Liniennummer = 4, Bezeichnung = 'Estanqueidade Suporte GSE '
GO
SET IDENTITY_INSERT [dbo].[ChamadoTipoEmailAviso] ON 
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (6, 1, N'eder.goncalves@nemak.com', N'eder goncalves', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (7, 1, N'romario.lopes02@nemak.com', N'romario lopes02', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (8, 1, N'sergio.souza@nemak.com', N'sergio souza', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (9, 1, N'raphael.pereira@nemak.com', N'raphael pereira', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (10, 1, N'philippe.henrique@nemak.com', N'philippe henrique', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (11, 1, N'marcelo.barbosa@nemak.com', N'marcelo barbosa', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (12, 1, N'dionisio.carvalho@nemak.com', N'dionisio carvalho', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (13, 1, N'samuel.sa@nemak.com', N'samuel sa', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (14, 1, N'marilia.palhares@nemak.com', N'marilia palhares', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (15, 1, N'lucas.santos@nemak.com', N'lucas santos', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (16, 1, N'aline.frezzolino@nemak.com', N'aline frezzolino', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (17, 1, N'marcus.abreu@nemak.com', N'marcus abreu', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (18, 1, N'claudio.kiel@nemak.com', N'claudio kiel', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (19, 1, N'wendel.silveira@nemak.com', N'wendel silveira', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (20, 1, N'aender.fagundes@nemak.com', N'aender fagundes', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
INSERT [dbo].[ChamadoTipoEmailAviso] ([Id], [Ativo], [Email], [NomeResponsavel], [IdChamadoTipo], [DtReg], [UsReg]) VALUES (21, 1, N'carlos.frade@nemak.com', N'carlos frade', 11, CAST(N'2023-03-23T17:26:42.7266667' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[ChamadoTipoEmailAviso] OFF
GO
