// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocalePT_PT.cs
// Purpose: European Portuguese (pt-PT) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Acções" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atalhos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuração" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Vitualizador de informações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Marco" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversão de gravação" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atalhos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNÓSTICO" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "DIAGNÓSTICO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "UTILIZAÇÃO" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Mostra valores numéricos de tendência ao lado das setas vanilla de dinheiro e população na barra inferior.\nÉ uma exibição leve ao passar o rato na barra, <somente vitual>;\nnão altera o dinheiro nem a população da cidade." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência do Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Escolha se o texto de tendência da barra inferior mostra valores por hora ou mensais para dinheiro e população.\nMensal usa a renda do orçamento menos as despesas para dinheiro, e uma projeção de 24 horas para população." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensal (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Escolha quantos detalhes aparecem na dica de dinheiro ao passar o rato.\nCompacto = padrão na primeira instalação.\n<Mini> mostra apenas 2 valores líquidos para /mo e /h.\n<Compacto> encurta valores grandes (15.21M em vez de 15,212,318).\n<Dados completos> mostra valores longos e campos Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho da fonte do dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Ajusta o <tamanho da fonte> dos números da dica do Money View.\nPadrão do jogo = 100%\n<Padrão do mod = 120%>\nPasse o rato sobre Dinheiro na parte inferior da tela.\nPedido por jogadores que têm dificuldade para ver dicas menores no jogo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho da fonte da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Ajusta o <tamanho da fonte> dos números da dica de população.\nPadrão do jogo = 100%\n<Padrão do mod = 120%>\nPasse o rato sobre População na parte inferior da tela." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use este valor com os atalhos Adicionar dinheiro e Subtrair dinheiro.\n<Padrão do mod = 40,000>\nIsso não faz nada a menos que tu use o atalho para adicionar/subtrair dinheiro (na cidade).\nPara dinheiro automático, ative a opção Adicionar dinheiro automaticamente." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atalho para <Adicionar dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atalho para <Subtrair dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Adicionar dinheiro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Quando ativado [ ✓ ], City Watchdog verifica o saldo da cidade enquanto uma cidade está carregada.\n- Se o saldo estiver <abaixo do limite>, \n  adiciona o valor automático selecionado.\n- Recomenda-se usar dinheiro manual com o atalho (<[> ou <]>) quando necessário em vez desta opção automática, mas ela está disponível se tu quiser." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite de dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Se Adicionar dinheiro automaticamente estiver ativado e o saldo da cidade cair abaixo deste valor,\nadiciona o valor automático selecionado." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor de dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor adicionado cada vez que Adicionar dinheiro automaticamente é acionado.\nEscolha um valor alto o suficiente para trazer a cidade com segurança acima do limite." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Define o saldo inicial para uma nova cidade com <dinheiro limitado> ou para a primeira cidade carregada,\ndepois volta para o padrão do jogo após aplicar.\nFica cinza se uma cidade já estiver carregada.\nDefina antes de iniciar/carregar uma cidade → aplica uma vez → depois use <Valor do atalho de dinheiro> ou <Adicionar dinheiro automaticamente>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Predefinição do jogo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Atalho> para a mesma ação do botão de ícone <[TOGGLE ALL]> no painel do jogo.\nMostra ou oculta instantaneamente todos os ícones de notificação da cidade listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/Ocultar instantaneamente todos os ícones de notificação" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Atalho> para abrir ou fechar o\n<painel de notificações> na cidade.\nFunciona igual a clicar no ícone superior esquerdo para abrir o painel completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Ocultar/mostrar nomes das ruas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Desativa as dicas do jogo ao passar o rato — tanto as que seguem o cursor sobre edifícios/cidadãos/ferramentas quanto os pequenos pop-ups nos botões da interface do jogo (nomes da barra superior, botões vanilla etc.).\n<Os pop-ups próprios de dinheiro/população do City Watchdog continuam ativados>; eles são controlados pela opção Money View acima.\nIgual a clicar no ícone [i] no painel City Watchdog dentro da cidade." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Ative antes de carregar ou iniciar uma cidade para desbloquear o marco escolhido imediatamente após a cidade carregar.\nNão pode ser ativado enquanto uma cidade está carregada, mas pode ser desativado se ficou ligado por engano.\nCity Watchdog não pode desfazer mudanças de marco já salvas na cidade; use um gravação anterior se necessário." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Escolha o nível de marco para desbloquear no próximo carregamento da cidade.\nSó pode ser ajustado fora de uma cidade carregada, e somente depois que [Seletor de marco] estiver ativado [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Faça primeiro um backup da cidade>.\nConverte uma cidade iniciada com Dinheiro ilimitado em uma cidade normal com desafios regulares de dinheiro.\nAtivar isso libera o botão <[Converter gravação de Dinheiro ilimitado]> quando a cidade carregada é do tipo <Dinheiro ilimitado>.\nCity Watchdog não pode desfazer esta conversão.\nSe tu tem cidades normais, não se preocupe; isso não é necessário." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Para cidades iniciadas com <Dinheiro ilimitado>.\nEnquanto essa cidade está carregada, converte o gravação para orçamento normal com dinheiro limitado para que a cidade tenha desafios regulares de dinheiro novamente.\nO botão fica <desativado/cinza> a menos que a cidade carregada seja do tipo <Dinheiro ilimitado>\ne <Conversor de dinheiro ilimitado> esteja ON [ ✓ ].\nFaça um backup e use por tua conta e risco; City Watchdog não pode desfazer esta conversão." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\nSalve um backup PRIMEIRO; City Watchdog não pode desfazer isso.\nTem certeza?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido deste mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página do autor no Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Relatório de depuração no log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Não é necessário para jogo normal.>\nPara testadores e verificações após patch do jogo: grava um relatório <Logs/CityWatchdog.log>\ncomparando os prefabs de notificação ativos do jogo com os ícones de notificação que o Watchdog controla atualmente." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abrir registo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Painel de notificações>\n1. Clique no botão City Watchdog (canto superior esquerdo), ou pressione Shift+N, para abrir o painel.\n2. Ordene ASC/DESC.\n3. Use Toggle All para desligar/ligar tudo rapidamente, ou expanda uma seção para alterar itens específicos.\n4. Mostra ou oculta apenas ícones; não corrige o problema da cidade.\n\n<Ajuda de dinheiro>\n1. Adicionar ou subtrair dinheiro: use o <Valor do atalho de dinheiro> padrão [ ou ].\n2. Adicionar dinheiro automaticamente observa o orçamento enquanto uma cidade está carregada e adiciona dinheiro abaixo do limite.\n3. Money View adiciona valores numéricos à barra de dinheiro e população e dicas ao passar o rato.\n4. Converter gravação de Dinheiro ilimitado é apenas para cidades iniciadas com Dinheiro ilimitado e é <irreversível>.\n\n<Marco personalizado>\nDefina Dinheiro inicial e selecione Marcos no menu Opções antes de carregar ou iniciar uma cidade." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
