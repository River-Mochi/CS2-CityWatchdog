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

    using Game.UI.Editor;

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePT_PT(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Vigia da cidade)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Ações" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Dinheiro-Marcos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Info na cidade" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Alertas Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "INÍCIO DE NOVA CIDADE" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter gravação ilimitada" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra ou oculta as instruções abaixo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Usa o ícone da pata no canto superior esquerdo, ou Shift+N, para abrir o painel.\n" +
                    "<Controlos visuais>\n" +
                    "1. Ícone do título: mostra/oculta dicas do City Watchdog.\n" +
                    "\n" +
                    "2. Botão **[i]**: oculta/mostra <TODAS> as dicas do jogo: edifícios, cidadãos, ferramentas, menu inferior.\n" +
                    "3. Botão estradas: oculta/mostra os nomes das ruas. Atalho: \\.\n" +
                    "4. Botão distritos: oculta/mostra os nomes dos distritos.\n" +
                    "5. Botão setas: força setas de sentido único ON/OFF (também oculta os nomes das ruas).\n" +
                    "\n" +
                    "<Alertas>\n" +
                    "1. Ordenar alterna A→Z, Z→A, só ativos.\n" +
                    "2. <[0/62]> = ícones ON/total. Clica para expandir/recolher todas as linhas.\n" +
                    "3a. [Alternar tudo] desliga/liga todos os ícones de alerta instantaneamente.\n" +
                    "3b. Só oculta ícones; não corrige o problema inerente.\n" +
                    "\n" +
                    "<Dica de dinheiro>\n" +
                    "1. Adicionar / subtrair dinheiro: usa as teclas padrão <[ ou ]> para <Valor do atalho de dinheiro>.\n" +
                    "2. Dinheiro automático adiciona dinheiro quando a cidade cai abaixo do limite escolhido.\n" +
                    "3. Converter gravação de Dinheiro ilimitado é só para essas cidades e é <irreversível>.\n" +
                    "\n" +
                    "<Dicas do menu inferior>\n" +
                    "Vista de dinheiro adiciona detalhes como a tendência do saldo ou da variação populacional ao passar o rato sobre o dinheiro ou a população.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Dinheiro-Marcos > INÍCIO DE NOVA CIDADE define o capital inicial e/ou os marcos antes de carregar/iniciar." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de alerta" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[Alternar tudo]> no jogo.\n" +
                    "Mostra ou oculta instantaneamente todos os ícones de alerta listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos os ícones de alerta" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de alertas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de alertas> na cidade.\n" +
                    "Idêntico a clicar no ícone do canto superior esquerdo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de alertas" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Iniciar apenas com botões" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Quando ativo [ ✓ ], o City Watchdog abre primeiro na vista reduzida apenas com botões.\n" +
                    "Utilize a seta do título ou o contador para abrir o painel completo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar os nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar os nomes de ruas do jogo base.\n" +
                    "Idêntico ao ícone de ruas no City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar os nomes das ruas" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Desativar todas as dicas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Atalho> para ocultar/mostrar TODAS as dicas do jogo: edifícios, cidadãos, ferramentas e ícones inferiores.\n" +
                    "<Popups de dinheiro/população do City Watchdog continuam ativos>; eles são do Vista de dinheiro.\n" +
                    "Idêntico ao ícone [i] no painel do City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ocultar/mostrar dicas do jogo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Tendências do saldo + população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Recomendado>\n" +
                    "Menu inferior: mostra tendências nas setas de <dinheiro e população>.\n" +
                    "Funcionalidade 'light' revelada ao passar o rato por cima <apenas visual>;\n" +
                    "poupa tempo e pode ser melhor do que abrir o painel de info do jogo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência da vista de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Escolhe valores por hora ou por mês no menu inferior.\n" +
                    "Mensal usa receitas menos despesas e uma projeção da população para 24 h." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolha os detalhes a aparecer na dica de dinheiro.\n" +
                    "Compacto = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\n" +
                    "<Compacto> abrevia números grandes (15.21M em vez de 15,212,318).\n" +
                    "<Dados completos> mostra valores longos e totais." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho do texto de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da vista de dinheiro.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão da mod = 120%>\n" +
                    "Passa o rato sobre o Dinheiro na parte inferior.\n" +
                    "Para jogadores que acham as dicas pequenas demais." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho do texto da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão da mod = 120%>\n" +
                    "Passa o rato sobre a População na parte inferior." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Mostra um HUD pequeno com contagens importantes de alerta.\n" +
                    "Usa como tira rápida sem abrir o painel completo.\n" +
                    "Clicar em um ícone salta para um problema correspondente.\n" +
                    "Clica de novo para alternar entre os pontos e voltar ao primeiro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Clique: início rápido" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Aplica um <início rápido> para o mini painel:\n" +
                    "Inclui um **conjunto inicial de estrelas azuis**.\n" +
                    "Um alerta com **estrela azul** pode aparecer no mini painel se estiver no top 5 ou 10 por contagem total.\n" +
                    "Adiciona/remove **estrelas azuis** no painel Watchdog expandido.\n" +
                    "O conjunto inclui: Favoritos, 5 ícones, vertical, arrastável, tamanho 100 %, painel escuro, ícones com contagem a 0 ocultos."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Modo mini painel" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Escolhe que linhas de alerta o mini painel usa.\n" +
                    "**Top ativos** mostra as maiores contagens atuais.\n" +
                    "**Favoritos** usa linhas com **estrela azul** no painel principal do City Watchdog.\n" +
                    "Podes escolher todos os favoritos que quiseres,\n" +
                    "mas o mini painel mostra só o top 5 ou top 10 dessa lista de **estrelas azuis**."
                  },               
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Alertas mais ativos" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoritos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Quantidade de ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Escolhe quantos ícones o Mini HUD pode mostrar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Tamanho dos ícones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Redimensiona os ícones e números do Mini HUD.\n" +
                    "90% = compacto. 100% = padrão. Até 130% para melhor visualização." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Orientação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Escolhe linha ou coluna." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Horizontal" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Vertical" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Posição do HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Escolhe onde o Mini HUD aparece.\n" +
                    "Arrastável permite mover na interface da cidade." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Topo centrado" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Topo direito" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Arrastável" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Estilo escuro ou vidro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Escolhe o fundo do Mini HUD.\n" +
                    "Vidro varia entre transparente e branco nublado; não fica mais escuro.\n" +
                    "Usa Escuro para um HUD mais escuro ao estilo do jogo." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Painel escuro" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Painel de vidro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Opacidade do fundo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Ajusta a transparência do fundo do Mini HUD.\n" +
                    "Menor = mais transparente. Maior = mais sólido.\n" +
                    "Vidro fica mais branco. Escuro fica mais sólido/escuro." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ocultar alertas a 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Quando ativo [ ✓ ], o Mini HUD oculta linhas com contagem a 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Capital inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial de uma nova cidade com <dinheiro limitado> ou da primeira cidade carregada,\n" +
                    "depois volta ao padrão do jogo.\n" +
                    "Fica cinzento se uma cidade já estiver carregada.\n" +
                    "Define antes de carregar/iniciar. Depois usa <Valor do atalho de dinheiro> ou <Dinheiro automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ativa <antes de carregar ou iniciar> para desbloquear um marco ao carregar.\n" +
                    "- Não pode ligar com a cidade carregada, mas pode desligar.\n" +
                    "- Se te esqueceste e carregaste uma cidade, reinicia o jogo e escolhe antes de entrar na cidade.\n" +
                    "- A mod não desfaz marcos já salvos; use um save anterior." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolhe o marco para desbloquear no próximo carregamento.\n" +
                    "Ajustável <só fora de cidade carregada> e com [Seletor de marco] ativo [ ✓ ].\n" +
                    "Se a cidade já atingiu ou ultrapassou esse marco, nada se altera.\n" +
                    "Só muda se o marco escolhido for maior." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa este valor com os atalhos Adicionar e Subtrair dinheiro.\n" +
                    "<Padrão da mod = 40.000>\n" +
                    "Não tem efeito se não usares o atalho na cidade.\n" +
                    "Para automação, ativa o Dinheiro automático." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atalho para <Adicionar dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atalho para <Subtrair dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativo [ ✓ ], City Watchdog verifica o saldo da cidade.\n" +
                    "- Se o saldo estiver <abaixo do limite>,\n" +
                    "  adiciona o valor escolhido.\n" +
                    "- Recomenda-se usar dinheiro manual com o atalho (<[> ou <]>) quando precisares\n" +
                    "  em vez da automação; mas a opção existe." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se ativo e o saldo cair abaixo deste valor,\n" +
                    "adiciona o valor escolhido." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado a cada acionamento automático.\n" +
                    "Escolha o bastante para ficar acima do limite." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Recomenda-se que efectues um backup da cidade PRIMEIRO>.\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado para cidade normal.\n" +
                    "Ativar desbloqueia <[Converter gravação de Dinheiro ilimitado]> se a cidade carregada for de <Dinheiro ilimitado>.\n" +
                    "O City Watchdog não pode desfazer esta conversão.\n" +
                    "Se as tuas cidades são normais, ignora isto." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte a gravação para orçamento normal limitado.\n" +
                    "Botão fica <desativado/cinzento> excepto se a cidade for de <Dinheiro ilimitado>\n" +
                    "e o <Conversor de dinheiro ilimitado> estiver ON [ ✓ ].\n" +
                    "Faz backup e usa por tua conta e risco; o City Watchdog não desfaz." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Guarda um backup PRIMEIRO; o City Watchdog não desfaz.\n" +
                    "Tens a certeza?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome da mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido desta mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual da mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página Paradox Mods do autor." },
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
