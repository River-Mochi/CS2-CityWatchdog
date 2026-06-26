// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocalePT_BR.cs
// Purpose: English (en-US) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePT_BR(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Ações" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinheiro e marcos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visualizador de informações na cidade" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificações Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "CONFIGURAÇÕES DE INÍCIO DE NOVA CIDADE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter save ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICOS" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra ou oculta as instruções abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Alternâncias de visualização>\n" +
                    "1. Botão [i]: oculta/mostra TODAS as dicas do jogo — edifícios, cidadãos, ferramentas e ícones do menu inferior.\n" +
                    "2. Nomes de ruas: oculta/mostra os nomes das ruas. Atalho: \\.\n" +
                    "3. Nomes de distritos: oculta/mostra nomes de distritos sem alterar limites.\n" +
                    "4. Setas de rua: força setas de mão única (também oculta nomes de ruas).\n" +
                    "5. Ícone da barra CWD: mostra/oculta dicas do painel City Watchdog.\n" +
                    "\n" +
                    "<Alertas de notificação>\n" +
                    "1. Clique no botão City Watchdog no canto superior esquerdo, ou pressione Shift+N, para abrir o painel.\n" +
                    "2. Botão de ordenação crescente/decrescente.\n" +
                    "3. Toggle All liga/desliga tudo rapidamente, ou expanda uma seção para alterar itens específicos.\n" +
                    "4. Mostra ou oculta apenas ícones; não corrige o problema da cidade.\n" +
                    "\n" +
                    "<Ajuda de dinheiro>\n" +
                    "1. Adicionar ou subtrair dinheiro: use <Valor do atalho de dinheiro> com as teclas padrão [ e ].\n" +
                    "2. Dinheiro automático adiciona dinheiro quando a cidade fica abaixo do limite definido.\n" +
                    "3. Converter save de Dinheiro ilimitado serve apenas para cidades iniciadas com Dinheiro ilimitado e é <irreversível>.\n" +
                    "\n" +
                    "<Dicas do menu inferior>\n" +
                    "Money View adiciona tendências de dinheiro e população na barra e detalhes ao passar o mouse.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Defina Dinheiro inicial e marcos em Dinheiro e marcos > CONFIGURAÇÕES DE INÍCIO DE NOVA CIDADE antes de carregar ou iniciar uma cidade."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de notificação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[TOGGLE ALL]> no jogo.\n" +
                    "Mostra ou oculta instantaneamente todos os ícones listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/Ocultar todos os ícones de notificação" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de notificações> na cidade.\n" +
                    "Funciona igual ao botão no canto superior esquerdo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/Fechar painel de notificações" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar só com botões" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Quando ligado [ ✓ ], o botão no canto superior esquerdo abre o City Watchdog na visualização menor só com botões.\n" +
                    "Use a seta da barra de título ou o botão de contagem de linhas para abrir o painel completo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes de ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar ou mostrar instantaneamente os nomes de ruas vanilla.\n" +
                    "Igual ao ícone de nomes de ruas na barra do City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/Mostrar nomes de ruas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desativar todos os tooltips ao passar o mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Atalho> para ocultar ou mostrar TODOS os tooltips do jogo — prédios, cidadãos, ferramentas e ícones do menu inferior.\n" +
                    "<Os popups de dinheiro/população do City Watchdog continuam ativos>; eles são controlados pelo Money View.\n" +
                    "Igual ao ícone [i] no painel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/Mostrar todos os tooltips do jogo" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar ToolTips de dinheiro + população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recomendado>\n" +
                    "Menu inferior: mostra valores de tendência junto às setas de dinheiro e população do jogo.\n" +
                    "Recurso leve de hover <somente exibição>;\n" +
                    "economiza tempo e pode ser melhor que abrir o painel de informações do jogo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência do Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Escolha se as tendências mostram valores por hora ou por mês para dinheiro e população.\n" +
                    "Mensal usa receita menos despesas do orçamento e projeção de população de 24 horas." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo do tooltip de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolha quanto detalhe aparece no tooltip de dinheiro.\n" +
                    "Compact = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\n" +
                    "<Compact> encurta valores grandes (15.21M em vez de 15,212,318).\n" +
                    "<Full data> mostra valores longos e campos Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho da fonte do dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números do Money View.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre Dinheiro na parte inferior.\n" +
                    "Pedido por jogadores que têm dificuldade com tooltips pequenos."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho da fonte da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números da população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre População na parte inferior."
                },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Notificações Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra um pequeno HUD na cidade com as contagens de notificação mais importantes.\n" +
                    "Use como uma barra rápida de alertas sem abrir o painel completo do City Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Predefinição recomendada" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Aplica uma configuração recomendada do Mini HUD:\n" +
                    "alertas mais ativos, 5 ícones, vertical, arrastável, esconder zeros e estilo vidro.\n" +
                    "A predefinição vertical arrastável começa perto do canto superior direito." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Escolha quais linhas de notificação o Mini HUD usa.\n" +
                    "Alertas mais ativos mostra as maiores contagens atuais.\n" +
                    "Favoritos mostra apenas linhas marcadas com estrela no painel City Watchdog." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas mais ativos" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Número de ícones Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Escolha quantos ícones de notificação o Mini HUD pode mostrar de uma vez." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientação Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Escolha se os ícones do Mini HUD ficam em linha ou coluna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posição Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Escolha onde o Mini HUD aparece.\n" +
                    "Arrastável permite mover na interface da cidade." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Topo centro" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Topo direita" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastável" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas zerados" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Quando ativado [ ✓ ], o Mini HUD oculta linhas de notificação com contagem 0." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Estilo vidro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)),
                    "Adiciona um fundo suave tipo vidro atrás do Mini HUD para melhorar a leitura." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial de uma nova cidade com <dinheiro limitado>, ou da primeira cidade carregada,\n" +
                    "e depois volta para Game Default após aplicar.\n" +
                    "Fica cinza se uma cidade já estiver carregada.\n" +
                    "Configure antes de iniciar/carregar uma cidade. Depois use <Valor do atalho de dinheiro> ou <Dinheiro automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ative <antes de carregar ou iniciar uma cidade> para liberar o milestone escolhido logo após o carregamento.\n" +
                    "Não pode ser ligado com uma cidade carregada, mas pode ser desligado se ficou ativo por engano.\n" +
                    "Se esqueceu, reinicie o jogo e escolha o milestone antes de entrar na cidade.\n" +
                    "City Watchdog não pode desfazer milestones já salvos; use um salvamento anterior se necessário." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolha o milestone para liberar no próximo carregamento da cidade.\n" +
                    "Só pode ser ajustado fora de uma cidade carregada e depois de ativar [Seletor de milestone] [ ✓ ]." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use este valor com os atalhos Adicionar Dinheiro e Subtrair Dinheiro.\n" +
                    "<Padrão do mod = 40,000>\n" +
                    "Não faz nada sem usar o atalho na cidade.\n" +
                    "Para dinheiro automático, ative a opção Dinheiro automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Atalho para <Adicionar dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Atalho para <Subtrair dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Adicionar dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativado [ ✓ ], City Watchdog verifica o saldo enquanto uma cidade está carregada.\n" +
                    "- Se o saldo ficar <abaixo do limite>,\n" +
                    "  adiciona o valor automático escolhido.\n" +
                    "- Recomendo usar dinheiro manual com os atalhos (<[> ou <]>) quando precisar, mas esta opção existe."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se o dinheiro automático estiver ativado e o saldo cair abaixo deste valor,\n" +
                    "adiciona o valor automático escolhido." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor automático de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado cada vez que o automático dispara.\n" +
                    "Escolha um valor alto o suficiente para passar com segurança do limite." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de Dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça primeiro um backup da cidade>.\n" +
                    "Converte uma cidade iniciada com Dinheiro ilimitado para uma cidade normal com orçamento regular.\n" +
                    "Ativar isto libera o botão <[Converter salvamento de Dinheiro ilimitado]> quando a cidade carregada for do tipo <Dinheiro ilimitado>.\n" +
                    "City Watchdog não pode desfazer esta conversão.\n" +
                    "Se suas cidades são normais, não precisa disso." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com essa cidade carregada, converte o salvamento para orçamento limitado normal.\n" +
                    "O botão fica <desativado/cinza> a menos que a cidade carregada seja do tipo <Dinheiro ilimitado>\n" +
                    "e <Conversor de Dinheiro ilimitado> esteja ON [ ✓ ].\n" +
                    "Faça backup e use por sua conta; City Watchdog não pode desfazer." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Faça backup PRIMEIRO; City Watchdog não pode desfazer.\n" +
                    "Tem certeza?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página do autor no Paradox Mods." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Relatório debug no log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Não é necessário para jogar normalmente.>\n" +
                    "Para testes e verificações pós-patch: grava um relatório em <Logs/CityWatchdog.log>\n" +
                    "comparando as notificações reais do jogo com os ícones controlados pelo Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> se existir.\n" +
                    "Se o arquivo não existir, abre a pasta Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
