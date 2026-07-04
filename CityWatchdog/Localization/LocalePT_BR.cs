// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocalePT_BR.cs
// Purpose: Portuguese Brazil (pt-BR) for City Watchdog Options UI menu.

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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinheiro-Marcos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info na cidade" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Notificações Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "CONFIGURAÇÕES DE CIDADE NOVA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter save ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra ou oculta as instruções abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Controles visuais>\n" +
                    "1. Botão [i]: mostra/oculta TODAS as dicas do jogo.\n" +
                    "2. Botão nomes das ruas: mostra/oculta nomes. Atalho: \\.\n" +
                    "3. Botão distritos: mostra/oculta nomes sem mudar limites.\n" +
                    "4. Botão setas: força setas de mão única (também oculta nomes das ruas).\n" +
                    "5. Ícone CWD: mostra/oculta dicas do painel City Watchdog.\n\n" +
                    "<Alertas>\n" +
                    "1. Clique em City Watchdog no canto superior esquerdo ou use Shift+N.\n" +
                    "2. Botão de ordenação: crescente/decrescente.\n" +
                    "3. Toggle All liga/desliga tudo, ou abra uma seção para escolher.\n" +
                    "4. Só oculta ícones; não corrige o problema da cidade.\n\n" +
                    "<Ajuda de dinheiro>\n" +
                    "1. Adicionar ou remover dinheiro: use as teclas [ e ].\n" +
                    "2. Dinheiro automático adiciona dinheiro abaixo do limite escolhido.\n" +
                    "3. Converter Save de Dinheiro Ilimitado é só para essas cidades e é <irreversível>.\n\n" +
                    "<Dicas do menu inferior>\n" +
                    "Money View adiciona tendências de dinheiro/população e detalhes ao passar o mouse.\n\n" +
                    "<Marco personalizado>\n" +
                    "Defina dinheiro inicial e marco antes de carregar ou iniciar uma cidade."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[TOGGLE ALL]> no jogo.\n" +
                    "Mostra ou oculta na hora todos os ícones listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos os ícones de alerta" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de alertas> na cidade.\n" +
                    "Igual a clicar no ícone do canto superior esquerdo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de alertas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar só com botões" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Quando ativo [ ✓ ], City Watchdog abre primeiro na visão pequena só com botões.\n" +
                    "Use a seta do título ou o botão de contagem para abrir o painel completo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar nomes de ruas vanilla.\n" +
                    "Igual ao ícone de nomes de ruas no City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nomes das ruas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desativar todas as dicas ao passar o mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar TODAS as dicas do jogo.\n" +
                    "<Popups de dinheiro/população do City Watchdog ficam ativos>; são controlados pelo Money View.\n" +
                    "Igual ao ícone [i] no painel City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar dicas do jogo" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar dicas de dinheiro + população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recomendado>\n" +
                    "Menu inferior: mostra tendências nas setas de dinheiro e população.\n" +
                    "Recurso leve ao passar o mouse <só visual>;\n" +
                    "Evita abrir o painel de informações do jogo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência do Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Escolha tendências por hora ou por mês no menu inferior.\n" +
                    "Mensal usa renda menos despesas e projeção de população de 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mês)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolha quanto detalhe aparece na dica de dinheiro.\n" +
                    "Compacto = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos /mês e /h.\n" +
                    "<Compacto> encurta números grandes (15.21M em vez de 15,212,318).\n" +
                    "<Dados completos> mostra valores longos e totais." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho da fonte de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números do Money View.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre Dinheiro na parte inferior.\n" +
                    "Para jogadores que acham as dicas pequenas demais."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho da fonte de população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números de população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre População na parte inferior."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra um HUD pequeno com contagens importantes.\n" +
                    "Use como faixa rápida sem abrir o painel completo.\n" +
                    "Clicar em um ícone pula para um problema correspondente.\n" +
                    "Clique de novo para alternar entre pontos e voltar ao primeiro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Conjunto inicial recomendado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Aplica uma configuração recomendada do Mini HUD:\n" +
                    "Favoritos, 5 ícones, horizontal, topo central, 100%, painel escuro.\n" +
                    "Alertas com zero continuam visíveis.\n" +
                    "Adicione/remova favoritos **Estrela azul** no painel expandido.\n" +
                    "Favoritos iniciais **Estrela azul** vêm com **[Recomendado]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Escolha quais linhas o Mini HUD usa.\n" +
                    "**Alertas ativos** mostra as maiores contagens atuais.\n" +
                    "**Favoritos** inclui linhas marcadas com **Estrela azul**.\n" +
                    "Você pode escolher quantos favoritos quiser,\n" +
                    "mas o Mini HUD mostra só as 5 ou 10 maiores contagens dessa lista." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas ativos" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Quantidade de ícones Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Escolha quantos ícones o Mini HUD pode mostrar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Tamanho do Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Escala ícones e números do Mini HUD.\n" +
                    "90% = compacto. 100% = padrão. Até 130% para ver melhor." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientação do Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Escolha linha ou coluna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posição do Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Escolha onde o Mini HUD aparece.\n" +
                    "Arrastável permite mover na interface da cidade." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Topo central" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Topo direito" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastável" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Estilo do Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Escolha o fundo do Mini HUD.\n" +
                    "Vidro vai de claro a branco nublado; não fica mais escuro.\n" +
                    "Use painel escuro para um HUD vanilla mais escuro." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Painel escuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Painel vidro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacidade do Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajusta a transparência do fundo.\n" +
                    "Menor = mais transparente. Maior = mais sólido.\n" +
                    "Vidro fica mais branco/nublado. Escuro fica mais sólido/escuro." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas zero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Quando ativo [ ✓ ], o Mini HUD oculta linhas com contagem 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial de uma nova cidade com <dinheiro limitado>,\n" +
                    "depois volta ao padrão do jogo.\n" +
                    "Fica cinza se uma cidade já estiver carregada.\n" +
                    "Defina antes de carregar/iniciar. Depois use <Valor do atalho de dinheiro> ou <Dinheiro automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ative <antes de carregar ou iniciar> para liberar um marco ao carregar.\n" +
                    "- Não pode ser ligado com cidade carregada, mas pode ser desligado.\n" +
                    "- Se esqueceu, reinicie o jogo e escolha antes de entrar na cidade.\n" +
                    "- O mod não desfaz marcos já salvos; use um save anterior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolha o marco para liberar no próximo carregamento.\n" +
                    "Ajustável <só fora de cidade carregada> e com [Seletor de marco] ativo [ ✓ ].\n" +
                    "Se a cidade já está nesse marco ou além, nada acontece.\n" +
                    "Só muda se o marco escolhido for maior."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use este valor com os atalhos Adicionar e Subtrair dinheiro.\n" +
                    "<Padrão do mod = 40.000>\n" +
                    "Não faz nada sem usar o atalho na cidade.\n" +
                    "Para automação, ative Dinheiro automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Atalho para <Adicionar dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Atalho para <Subtrair dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativo [ ✓ ], City Watchdog verifica o saldo da cidade.\n" +
                    "- Se o saldo estiver <abaixo do limite>, \n" +
                    "  adiciona o valor escolhido.\n" +
                    "- Recomendo usar dinheiro manual com atalho (<[> ou <]>) quando precisar" +
                    "  em vez da automação; mas a opção existe."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se ativo e o saldo cair abaixo deste valor,\n" +
                    "adiciona o valor escolhido." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado a cada acionamento automático.\n" +
                    "Escolha o bastante para ficar acima do limite." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça backup PRIMEIRO>.\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado para cidade normal.\n" +
                    "Libera o botão <[Converter save de Dinheiro ilimitado]> se a cidade carregada for <Dinheiro ilimitado>.\n" +
                    "City Watchdog não pode desfazer esta conversão.\n" +
                    "Se suas cidades são normais, ignore isto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte o save para orçamento normal.\n" +
                    "Botão fica <desativado/cinza> salvo se a cidade for <Dinheiro ilimitado>\n" +
                    "e <Conversor de dinheiro ilimitado> estiver ATIVO [ ✓ ].\n" +
                    "Faça backup e use por sua conta; City Watchdog não desfaz." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Salve backup PRIMEIRO; City Watchdog não desfaz.\n" +
                    "Tem certeza?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página Paradox Mods do autor." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Relatório debug no log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Não é necessário para jogar normalmente.>\n" +
                    "Para testes e patches: grava um relatório em <Logs/CityWatchdog.log>\n" +
                    "comparando notificações do jogo com os ícones controlados pelo Watchdog." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> se existir.\n" +
                    "Se não existir, abre a pasta Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
