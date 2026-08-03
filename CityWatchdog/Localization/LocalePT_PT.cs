// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocalePT_PT.cs
// Purpose: Portuguese Portugal (pt-PT) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocalePT_PT(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Vigia da cidade)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "Ações" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "Nova cidade" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "Sobre" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "Info na cidade" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "Alertas Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "INÍCIO DE NOVA CIDADE" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Converter gravação ilimitada" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Mostra ou oculta as instruções abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Usa o ícone da pata no canto superior esquerdo, ou Shift+N, para abrir o painel.\n" +
                    "<Controlos visuais>\n" +
                    "1. Ícone do título: mostra/oculta dicas do City Watchdog.\n" +
                    "\n" +
                    "2. Botão **[i]**: oculta/mostra <TODAS> as dicas do jogo: edifícios, cidadãos, ferramentas, menu inferior.\n" +
                    "3. Botão estradas: oculta/mostra os nomes das ruas. Atalho: \\.\n" +
                    "4. Botão distritos: oculta/mostra os nomes dos distritos.\n" +
                    "5. Botão setas: mostra/oculta setas de sentido único (também oculta os nomes das ruas).\n" +
                    "\n" +
                    "<Alertas>\n" +
                    "1. Ordenar alterna A→Z, Z→A, só ativos.\n" +
                    "2. <[0/62]> = ícones visíveis/total. Clica para expandir/recolher todas as linhas.\n" +
                    "3a. [Mostrar ícones] desliga/liga imediatamente todos os ícones de alertas de problemas.\n" +
                    "3b. Predefinições [1 | 2]: clica para carregar; mantém premido 1 segundo para guardar as caixas atuais.\n" +
                    "3c. Ocultar um ícone não corrige o problema da cidade.\n" +
                    "\n" +
                    "<Ajuda>\n" +
                    "1. Adicionar / subtrair dinheiro: usa as teclas padrão <[ ou ]> para <Valor do atalho de dinheiro>.\n" +
                    "2. Dinheiro automático adiciona dinheiro quando a cidade cai abaixo do limite escolhido.\n" +
                    "3. Converter gravação de Dinheiro ilimitado é só para essas cidades e é <irreversível>.\n" +
                    "\n" +
                    "<Dicas do menu inferior>\n" +
                    "Vista de dinheiro adiciona detalhes como a tendência do saldo ou da variação populacional ao passar o rato sobre o dinheiro ou a população.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Nova cidade define o capital inicial ou os marcos antes de carregar ou iniciar uma cidade."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Alternar ícones de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[MOSTRAR ÍCONES]> no jogo.\n" +
                    "Mostra ou oculta imediatamente todos os ícones de alertas de problemas."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Mostrar/ocultar de imediato os ícones de problemas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de alertas> na cidade.\n" +
                    "Idêntico a clicar no ícone do canto superior esquerdo."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Abrir/fechar painel de alertas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Iniciar apenas com botões" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Quando ativo [ ✓ ], o City Watchdog abre primeiro na vista reduzida apenas com botões.\n" +
                    "Utiliza a seta do título ou o contador para abrir o painel completo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar os nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar os nomes de ruas do jogo base.\n" +
                    "Idêntico ao ícone de ruas no City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Ocultar/mostrar os nomes das ruas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Desativar todas as dicas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar TODAS as dicas do jogo: edifícios, cidadãos, ferramentas e ícones inferiores.\n" +
                    "<As janelas de dinheiro/população do City Watchdog continuam ativas>; são controladas pela opção Vista de dinheiro acima.\n" +
                    "Idêntico ao ícone [i] no painel do City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Ocultar/mostrar dicas do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Interface do jogo maior" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Quando ativado [ ✓ ], <toda a interface do jogo> fica maior — painéis do jogo e dos mods.\n" +
                    "Usa a opção do jogo <Escala da interface> sem o parâmetro <--developerMode>.\n" +
                    "Esta caixa [x] fica sincronizada com o botão de escala na barra de título do City Watchdog.\n" +
                    "Só para o texto: Opções > Interface > <Escala do texto>.\n" +
                    "Fica ativo até o desativares, mesmo que removas o City Watchdog.\n" +
                    "- Desativa antes de desinstalar para voltar ao tamanho normal.\n" +
                    "- Ou inicia uma vez com <--developerMode> e desativa Opções > Interface > Escala da interface (dev)."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Opacidade do painel principal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Ajusta a transparência do fundo do painel principal de notificações.\n" +
                    "Valores menores são mais transparentes. Valores maiores deixam o fundo mais escuro e sólido."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Tendências do saldo + população" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Recomendado>\n" +
                    "Menu inferior: mostra tendências nas setas de <dinheiro e população>.\n" +
                    "Funcionalidade leve revelada ao passar o rato por cima <apenas visual>;\n" +
                    "poupa tempo e pode ser melhor do que abrir o painel de informação do jogo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Frequência da vista de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Escolhe valores por hora ou por mês no menu inferior.\n" +
                    "Mensal usa receitas menos despesas e uma projeção da população para 24 h."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Escolhe os detalhes a aparecer na dica de dinheiro.\n" +
                    "Compacto = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\n" +
                    "<Compacto> abrevia números grandes (15.21M em vez de 15,212,318).\n" +
                    "<Dados completos> mostra valores longos e totais."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Tamanho do texto de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da vista de dinheiro.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão da mod = 120%>\n" +
                    "Passa o rato sobre o Dinheiro na parte inferior.\n" +
                    "Para jogadores que acham as dicas pequenas demais."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Tamanho do texto da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão da mod = 120%>\n" +
                    "Passa o rato sobre a População na parte inferior."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Mostra um HUD pequeno com contagens importantes de alerta.\n" +
                    "Usa como tira rápida sem abrir o painel completo.\n" +
                    "Clicar num ícone salta para um problema correspondente.\n" +
                    "Clica de novo para alternar entre os problemas até voltar ao primeiro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Clica: início rápido" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Aplica um <início rápido> ao Mini HUD:\n" +
                    "Inclui um **conjunto inicial de estrelas azuis favoritas**.\n" +
                    "No modo Favoritos, o Mini HUD mostra as 5 ou 10 maiores contagens atuais da tua lista de **estrelas azuis**.\n" +
                    "Adiciona/remove **estrelas azuis** no painel City Watchdog.\n" +
                    "Define: Favoritos, 5 ícones, horizontal, arrastável, 100 %, painel escuro e oculta contagens 0.\n" +
                    "Executa Início rápido novamente quando quiseres repor estas definições."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Modo mini painel" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Escolhe que linhas de alerta o mini painel usa.\n" +
                    "**Mais ativos** mostra as maiores contagens atuais.\n" +
                    "**Favoritos** usa linhas com **estrela azul** no painel principal do City Watchdog.\n" +
                    "Podes escolher todos os favoritos que quiseres,\n" +
                    "mas o mini painel mostra só as 5 ou 10 maiores contagens dessa lista de **estrelas azuis**."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas mais ativos" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Quantidade de ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Escolhe quantos ícones o Mini HUD pode mostrar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Tamanho dos ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Redimensiona os ícones e números do Mini HUD.\n" +
                    "90% = compacto. 100% = padrão. Até 130% para melhor visualização."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientação" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Escolhe linha ou coluna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Posição do HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Escolhe onde o Mini HUD aparece.\n" +
                    "Arrastável permite movê-lo na interface da cidade."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Topo centrado" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Topo direito" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastável" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Estilo escuro ou vidro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Escolhe o fundo do Mini HUD.\n" +
                    "Vidro varia entre transparente e branco nublado; não fica mais escuro.\n" +
                    "Usa Escuro para um HUD mais escuro ao estilo do jogo."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Painel escuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Painel de vidro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Opacidade do fundo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Ajusta a transparência do fundo do Mini HUD.\n" +
                    "Menor = mais transparente. Maior = mais sólido.\n" +
                    "Vidro fica mais branco. Escuro fica mais sólido/escuro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Ocultar alertas a 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Quando ativo [ ✓ ], o Mini HUD oculta linhas com contagem a 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Capital inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Define o saldo da próxima cidade com <dinheiro limitado> carregada — nova ou existente.\n" +
                    "Depois de se aplicar uma vez, volta ao padrão do jogo.\n" +
                    "Fica cinzento quando já existe uma cidade carregada.\n" +
                    "Define antes de carregar ou iniciar a cidade. Depois usa <Valor do atalho de dinheiro> se precisares."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Ativa <antes de carregar ou iniciar> para desbloquear um marco ao carregar.\n" +
                    "- Não pode ligar com a cidade carregada, mas pode desligar.\n" +
                    "- Se te esqueceste e carregaste uma cidade, reinicia o jogo e escolhe antes de entrar na cidade.\n" +
                    "- A mod não desfaz marcos já guardados; usa uma gravação anterior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Escolhe o marco para desbloquear no próximo carregamento.\n" +
                    "Ajustável <só fora de cidade carregada> e com [Seletor de marco] ativo [ ✓ ].\n" +
                    "Se a cidade já atingiu ou ultrapassou esse marco, nada se altera.\n" +
                    "Só muda se o marco escolhido for maior."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Usa este valor com os atalhos Adicionar e Subtrair dinheiro.\n" +
                    "<Padrão da mod = 40.000>\n" +
                    "Não tem efeito se não usares o atalho na cidade.\n" +
                    "Para automação, ativa o Dinheiro automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Atalho para <Adicionar dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Atalho para <Subtrair dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Quando ativo [ ✓ ], City Watchdog verifica o saldo da cidade.\n" +
                    "- Se o saldo estiver <abaixo do limite>, adiciona o suficiente para atingir o limite.\n" +
                    "- Adiciona sempre pelo menos o Valor de dinheiro automático escolhido.\n" +
                    "- Para uso ocasional, recomendam-se os atalhos manuais (<[> ou <]>)."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Se Dinheiro automático estiver ativo e o saldo cair abaixo deste valor,\n" +
                    "é adicionado dinheiro até a cidade atingir pelo menos este limite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Valor mínimo adicionado sempre que Dinheiro automático é acionado.\n" +
                    "Se for necessário mais para atingir o limite, City Watchdog adiciona o valor maior."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faz primeiro uma cópia de segurança da cidade>.\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado para cidade normal.\n" +
                    "Ativar desbloqueia <[Converter gravação de Dinheiro ilimitado]> se a cidade carregada for de <Dinheiro ilimitado>.\n" +
                    "O City Watchdog não pode desfazer esta conversão.\n" +
                    "Se as tuas cidades são normais, ignora isto."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte a gravação para orçamento normal limitado.\n" +
                    "O botão fica <desativado/cinzento> exceto se a cidade for de <Dinheiro ilimitado>\n" +
                    "e o <Conversor de dinheiro ilimitado> estiver ATIVO [ ✓ ].\n" +
                    "Faz uma cópia de segurança e usa por tua conta e risco; o City Watchdog não desfaz."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Guarda uma cópia de segurança PRIMEIRO; o City Watchdog não desfaz.\n" +
                    "Tens a certeza?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nome da mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Nome exibido desta mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Versão atual da mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Abre a página Paradox Mods do autor." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Relatório de diagnóstico" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Não é necessário para jogar normalmente.>\n" +
                    "Para testes e verificações após atualizações do jogo: grava um relatório em <Logs/CityWatchdog.log>\n" +
                    "comparando notificações do jogo com os ícones controlados pelo Watchdog."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Abrir registo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> se existir.\n" +
                    "Se não existir, abre a pasta Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
