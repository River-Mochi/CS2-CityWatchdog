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

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocalePT_BR(CwdSettings setting)
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
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "INÍCIO DE CIDADE NOVA" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Converter salvamento ilimitado" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "DIAGNÓSTICO" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Mostra ou oculta as instruções abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Use o ícone de pata no canto superior esquerdo, ou Shift+N, para abrir o painel.\n" +
                    "<Controles visuais>\n" +
                    "1. Ícone do título: mostra/oculta dicas do City Watchdog.\n" +
                    "\n" +
                    "2. Botão **[i]**: oculta/mostra <TODAS> as dicas do jogo: prédios, cidadãos, ferramentas, menu inferior.\n" +
                    "3. Botão ruas: oculta/mostra nomes das ruas. Atalho: \\.\n" +
                    "4. Botão distritos: oculta/mostra nomes dos distritos.\n" +
                    "5. Botão setas: mostra/oculta setas de mão única (também oculta nomes das ruas).\n" +
                    "\n" +
                    "<Alertas>\n" +
                    "1. Ordenar alterna A→Z, Z→A, só ativos.\n" +
                    "2. <[0/62]> = ícones visíveis/total. Clique para expandir/recolher todas as linhas.\n" +
                    "3a. [Mostrar ícones] desliga/liga na hora todos os ícones de alertas de problemas.\n" +
                    "3b. Predefinições [1 | 2]: clique para carregar; segure por 1 segundo para salvar as caixas atuais.\n" +
                    "3c. Ocultar um ícone não corrige o problema da cidade.\n" +
                    "\n" +
                    "<Ajuda>\n" +
                    "1. Adicionar / subtrair dinheiro: use as teclas padrão <[ ou ]> para <Valor do atalho de dinheiro>.\n" +
                    "2. Dinheiro automático adiciona dinheiro quando a cidade cai abaixo do limite escolhido.\n" +
                    "3. Converter salvamento de Dinheiro ilimitado é só para essas cidades e é <irreversível>.\n" +
                    "\n" +
                    "<Dicas do menu inferior>\n" +
                    "Visão de dinheiro adiciona detalhes das tendências ao passar o mouse em dinheiro ou população.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Nova cidade define dinheiro inicial ou marcos antes de carregar ou iniciar uma cidade."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Alternar ícones de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[MOSTRAR ÍCONES]> no jogo.\n" +
                    "Mostra ou oculta na hora todos os ícones de alertas de problemas."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Mostrar/ocultar na hora os ícones de problemas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de alertas> na cidade.\n" +
                    "Igual a clicar no ícone do canto superior esquerdo."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Abrir/fechar painel de alertas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Iniciar só com botões" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Quando ativo [ ✓ ], City Watchdog abre primeiro na visão pequena só com botões.\n" +
                    "Use a seta do título ou o contador para abrir o painel completo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar nomes de ruas do jogo base.\n" +
                    "Igual ao ícone de ruas no City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Ocultar/mostrar nomes das ruas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Desativar todas as dicas" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar TODAS as dicas do jogo: prédios, cidadãos, ferramentas e ícones do menu inferior.\n" +
                    "<As janelas de dinheiro/população do City Watchdog continuam ativas>; elas são controladas pela opção Visão de dinheiro acima.\n" +
                    "Igual ao ícone [i] no painel City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Ocultar/mostrar dicas do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Interface do jogo maior" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Quando ativado [ ✓ ], <toda a interface do jogo> fica maior — painéis do jogo e dos mods.\n" +
                    "Usa a opção do jogo <Escala da interface> sem o parâmetro <--developerMode>.\n" +
                    "Esta caixa [x] fica sincronizada com o botão de escala na barra de título do City Watchdog.\n" +
                    "Só para o texto: Opções > Interface > <Escala do texto>.\n" +
                    "Continua ativo até você desligar, mesmo se remover o City Watchdog.\n" +
                    "- Desative antes de desinstalar para voltar ao tamanho normal.\n" +
                    "- Ou inicie uma vez com <--developerMode> e desative Opções > Interface > Escala da interface (dev)."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Opacidade do painel principal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Ajusta a transparência do fundo do painel principal de notificações.\n" +
                    "Valores menores são mais transparentes. Valores maiores deixam o fundo mais escuro e sólido."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Tendências de dinheiro + população" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Recomendado>\n" +
                    "Menu inferior: mostra tendências nas setas de <dinheiro e população>.\n" +
                    "Recurso leve ativado ao passar o mouse sobre os valores <só visual>;\n" +
                    "economiza tempo e pode ser melhor que abrir o painel de informações do jogo."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Frequência da Visão de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Escolha valores por hora ou por mês no menu inferior.\n" +
                    "Mensal usa renda menos despesas e projeção de população de 24 h."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Escolha quanto detalhe aparece na dica de dinheiro.\n" +
                    "Compacto = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\n" +
                    "<Compacto> encurta números grandes (15.21M em vez de 15,212,318).\n" +
                    "<Dados completos> mostra valores longos e totais."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Tamanho do texto de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da Visão de dinheiro.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre Dinheiro na parte inferior.\n" +
                    "Para jogadores que acham as dicas pequenas demais."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Tamanho do texto de população" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números de população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre População na parte inferior."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Mostra um HUD pequeno com contagens importantes de alerta.\n" +
                    "Use como faixa rápida sem abrir o painel completo.\n" +
                    "Clicar em um ícone pula para o problema correspondente.\n" +
                    "Clique de novo para alternar entre problemas até voltar ao primeiro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Clique: início rápido" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Aplica um <início rápido> ao Mini HUD:\n" +
                    "Inclui um **conjunto inicial de estrelas azuis favoritas**.\n" +
                    "No modo Favoritos, o Mini HUD mostra as 5 ou 10 maiores contagens atuais da sua lista de **estrelas azuis**.\n" +
                    "Adicione/remova **estrelas azuis** no painel City Watchdog.\n" +
                    "Define: Favoritos, 5 ícones, horizontal, arrastável, 100 %, painel escuro e oculta contagens 0.\n" +
                    "Execute Início rápido de novo quando quiser restaurar essas configurações."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Modo mini painel" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Escolha quais linhas de alerta o mini painel usa.\n" +
                    "**Mais ativos** mostra as maiores contagens atuais.\n" +
                    "**Favoritos** usa linhas marcadas com **estrela azul** no painel principal City Watchdog.\n" +
                    "Você pode escolher quantos favoritos quiser,\n" +
                    "mas o mini painel mostra só as 5 ou 10 maiores contagens dessa lista de **estrelas azuis**."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas mais ativos" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Quantidade de ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Escolha quantos ícones o Mini HUD pode mostrar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Tamanho dos ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Escala ícones e números do Mini HUD.\n" +
                    "90% = compacto. 100% = padrão. Até 130% para ver melhor."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Orientação" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Escolha linha ou coluna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Posição do HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Escolha onde o Mini HUD aparece.\n" +
                    "Arrastável permite mover na interface da cidade."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Topo central" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Topo direito" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastável" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Estilo escuro ou vidro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Escolha o fundo do Mini HUD.\n" +
                    "Vidro vai de claro a branco nublado; não fica mais escuro.\n" +
                    "Use Escuro para um HUD mais escuro estilo jogo."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Painel escuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Painel vidro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Opacidade do fundo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Ajusta a transparência do fundo do Mini HUD.\n" +
                    "Menor = mais transparente. Maior = mais sólido.\n" +
                    "Vidro fica mais branco. Escuro fica mais sólido/escuro."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Ocultar alertas 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Quando ativo [ ✓ ], o Mini HUD oculta linhas com contagem 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Define o saldo da próxima cidade com <dinheiro limitado> que for carregada — nova ou existente.\n" +
                    "Depois de aplicar uma vez, volta ao padrão do jogo.\n" +
                    "Fica cinza quando uma cidade já está carregada.\n" +
                    "Defina antes de carregar ou iniciar a cidade. Depois use <Valor do atalho de dinheiro> se precisar."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Ative <antes de carregar ou iniciar> para liberar um marco ao carregar.\n" +
                    "- Não pode ligar com cidade carregada, mas pode desligar.\n" +
                    "- Se esqueceu, reinicie o jogo e escolha antes de entrar na cidade.\n" +
                    "- O mod não desfaz marcos já salvos; use um salvamento anterior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Escolha o marco para liberar no próximo carregamento.\n" +
                    "Ajustável <só fora de cidade carregada> e com [Seletor de marco] ativo [ ✓ ].\n" +
                    "Se a cidade já está nesse marco ou além, nada acontece.\n" +
                    "Só muda se o marco escolhido for maior."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Use este valor com os atalhos Adicionar e Subtrair dinheiro.\n" +
                    "<Padrão do mod = 40.000>\n" +
                    "Não faz nada sem usar o atalho na cidade.\n" +
                    "Para automação, ative Dinheiro automático."
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
                    "- Se o saldo estiver <abaixo do limite>, adiciona o bastante para alcançar o limite.\n" +
                    "- Sempre adiciona pelo menos o Valor de dinheiro automático escolhido.\n" +
                    "- Para uso ocasional, recomendamos os atalhos manuais (<[> ou <]>)."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Se Dinheiro automático estiver ativo e o saldo cair abaixo deste valor,\n" +
                    "dinheiro será adicionado até a cidade alcançar pelo menos este limite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Valor mínimo adicionado sempre que Dinheiro automático é acionado.\n" +
                    "Se for preciso mais para alcançar o limite, City Watchdog adiciona o valor maior."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça uma cópia de segurança da cidade PRIMEIRO>.\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado para cidade normal.\n" +
                    "Ativar libera <[Converter salvamento de Dinheiro ilimitado]> se a cidade carregada for <Dinheiro ilimitado>.\n" +
                    "City Watchdog não pode desfazer esta conversão.\n" +
                    "Se suas cidades são normais, ignore isto."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte o salvamento para orçamento normal limitado.\n" +
                    "O botão fica <desativado/cinza> salvo se a cidade for de <Dinheiro ilimitado>\n" +
                    "e <Conversor de dinheiro ilimitado> estiver ATIVO [ ✓ ].\n" +
                    "Faça uma cópia de segurança e use por sua conta; City Watchdog não desfaz."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Salve uma cópia de segurança PRIMEIRO; City Watchdog não desfaz.\n" +
                    "Tem certeza?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Nome exibido deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Versão atual do mod." },

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

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Abrir registro" },
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
