// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License; you may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
// File: src/Localization/LocalePT_BR.cs
// Purpose: Brazilian Portuguese (pt-BR) for City Watchdog Options UI menu.

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
            string title = Mod.ModName + " (Vigilante)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Ações" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atalhos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Visor de informações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Marco" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversão de save" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atalhos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Mostrar detalhes ao passar o mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Mostra valores numéricos de tendência ao lado das setas vanilla de dinheiro e população na barra inferior.\n" +
                    "É uma visualização leve ao passar o mouse na barra <apenas exibição>;\n" +
                    "não altera o dinheiro nem a população da cidade." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência do Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Escolha se o texto de tendência da barra inferior mostra valores por hora ou por mês para dinheiro e população.\n" +
                    "Mensal usa receita do orçamento menos despesas para dinheiro, e uma projeção de 24 horas para população." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo do tooltip de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolha quantos detalhes aparecem no tooltip de dinheiro ao passar o mouse.\n" +
                    "Compacto = padrão na primeira instalação.\n" +
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\n" +
                    "<Compacto> encurta valores grandes (15.21M em vez de 15,212,318).\n" +
                    "<Dados completos> mostra valores longos e campos de Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho da fonte do dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números do tooltip do Money View.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre Dinheiro na parte inferior da tela.\n" +
                    "Pedido por jogadores que têm dificuldade para ver tooltips menores no jogo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho da fonte da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho da fonte> dos números do tooltip de população.\n" +
                    "Padrão do jogo = 100%\n" +
                    "<Padrão do mod = 120%>\n" +
                    "Passe o mouse sobre População na parte inferior da tela." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use este valor com os atalhos Adicionar dinheiro e Subtrair dinheiro.\n" +
                    "<Padrão do mod = 40,000>\n" +
                    "Isso não faz nada a menos que você use o atalho para adicionar/subtrair dinheiro na cidade.\n" +
                    "Para dinheiro automático, ative a opção Adicionar dinheiro automático." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atalho para <Adicionar dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atalho para <Subtrair dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Adicionar dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativado [ ✓ ], o City Watchdog verifica o saldo da cidade enquanto uma cidade está carregada.\n" +
                    "- Se o saldo estiver <abaixo do limite>, \n" +
                    "  adiciona o valor automático selecionado.\n" +
                    "- Recomendo usar dinheiro manual com atalho (<[> ou <]>) quando precisar  em vez desta opção automática, mas ela está aqui se você quiser." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se Adicionar dinheiro automático estiver ativado e o saldo da cidade cair abaixo deste valor,\n" +
                    "adiciona o valor automático selecionado." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado sempre que Adicionar dinheiro automático dispara.\n" +
                    "Escolha um valor alto o suficiente para deixar a cidade com segurança acima do limite." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial para uma nova cidade com <dinheiro limitado> ou para a primeira cidade carregada,\n" +
                    "e depois volta para o Padrão do jogo após aplicar.\n" +
                    "Fica cinza se uma cidade já estiver carregada.\n" +
                    "Defina antes de iniciar/carregar uma cidade → aplica uma vez → depois use <Valor do atalho de dinheiro> ou <Adicionar dinheiro automático>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de notificação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[TOGGLE ALL]> no painel do jogo.\n" +
                    "Mostra ou oculta instantaneamente todos os ícones de notificação da cidade listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos os ícones de notificação agora" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\n" +
                    "<painel de notificações> na cidade.\n" +
                    "Funciona como clicar no ícone do canto superior esquerdo para abrir o painel completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de notificações" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Atalho> para ocultar ou mostrar instantaneamente os rótulos vanilla de nomes de ruas na cidade.\n" +
                    "Igual a clicar no ícone de nome de rua na barra do painel do City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nomes das ruas" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Desativar todos os tooltips do mouse" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Desativa os tooltips do jogo ao passar o mouse — tanto os que seguem o cursor sobre prédios/cidadãos/ferramentas\n" +
                    " quanto os pequenos popups nos botões da UI do jogo (nomes da barra superior, botões vanilla, etc.).\n" +
                    "<Os popups próprios de dinheiro/população do City Watchdog ficam ligados>; eles são controlados pela opção Money View acima.\n" +
                    "Igual a clicar no ícone [i] no painel do City Watchdog dentro da cidade." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ative antes de carregar ou iniciar uma cidade para desbloquear o marco escolhido logo após a cidade carregar.\n" +
                    "Não pode ser ativado enquanto uma cidade está carregada, mas pode ser desativado se ficou ligado por engano.\n" +
                    "O City Watchdog não pode desfazer mudanças de marco já salvas em uma cidade; use um save anterior se precisar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolha o nível de marco para desbloquear no próximo carregamento da cidade.\n" +
                    "Só pode ser ajustado fora de uma cidade carregada, e só depois que [Seletor de marco] estiver ativado [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça primeiro um backup da cidade>.\n" +
                    "Converte uma cidade iniciada com Dinheiro ilimitado para uma cidade normal com desafios de dinheiro regulares.\n" +
                    "Ativar isto libera o botão <[Converter save de Dinheiro ilimitado]> quando a cidade carregada é do tipo <Dinheiro ilimitado>.\n" +
                    "O City Watchdog não pode desfazer esta conversão.\n" +
                    "Se você tem cidades normais, não se preocupe; isto não é necessário." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Enquanto essa cidade estiver carregada, isto converte o save para orçamento normal com dinheiro limitado, para a cidade voltar a ter desafios de dinheiro regulares.\n" +
                    "O botão fica <desativado/cinza> a menos que a cidade carregada seja do tipo <Dinheiro ilimitado>\n" +
                    "e <Conversor de dinheiro ilimitado> esteja ON [ ✓ ].\n" +
                    "Faça um save de backup e use por sua conta e risco; o City Watchdog não pode desfazer esta conversão." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Salve um backup PRIMEIRO; o City Watchdog não pode desfazer isto.\n" +
                    "Tem certeza?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página do autor no Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Relatório de debug no log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Não é necessário para jogar normalmente.>\n" +
                    "Para testers e checagens após patches do jogo: grava um relatório <Logs/CityWatchdog.log>\n" +
                    "comparando os prefabs de notificação ativos do jogo com os ícones de notificação que o Watchdog controla atualmente." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre </Logs/CityWatchdog.log> se existir.\n" +
                    "Se o arquivo de log não existir, abre a pasta Logs/." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra ou oculta as instruções de uso abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Alternâncias de exibição>\n" +
                    "1. Botão [i]: oculta/mostra TODOS os tooltips do jogo ao passar o mouse (prédios, cims, ferramentas).\n" +
                    "2. Botão de nomes das ruas: oculta/mostra rótulos de nomes das ruas. Atalho: \\.\n" +
                    "3. Botão de setas das ruas: força setas de mão única ligadas/desligadas (também oculta nomes das ruas).\n" +
                    "4. Ícone da barra de título do CWD: mostra/oculta tooltips do painel City Watchdog.\n" +
                    "\n" +
                    "<Alertas de notificação>\n" +
                    "1. Clique no botão City Watchdog (canto superior esquerdo), ou pressione Shift+N, para abrir o painel.\n" +
                    "2. Botão de ordenação para crescente/decrescente.\n" +
                    "3. Toggle All para tudo Off/On rápido, ou expanda uma seção para mudar ícones específicos.\n" +
                    "4. Só mostra ou oculta ícones; não corrige o problema da cidade.\n" +
                    "\n" +
                    "<Ajuda com dinheiro>\n" +
                    "1. Adicionar ou subtrair dinheiro: use as teclas padrão do <Valor do atalho de dinheiro> [ e ].\n" +
                    "2. Adicionar dinheiro automático adiciona dinheiro quando a cidade fica abaixo do limite definido.\n" +
                    "3. Converter save de Dinheiro ilimitado é só para cidades iniciadas com Dinheiro ilimitado e é <irreversível>.\n" +
                    "\n" +
                    "<Tooltips do menu inferior>\n" +
                    "Money View adiciona valores de tendência à barra de dinheiro e população e detalhes extras ao passar o mouse.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Defina Dinheiro inicial e selecione Marcos no menu Opções antes de carregar ou iniciar uma cidade." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
