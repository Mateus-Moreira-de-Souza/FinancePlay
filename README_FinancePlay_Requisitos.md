
# ✅ FinancePlay - Checklist de Requisitos (Backend)

Este documento acompanha o progresso de implementação do backend do projeto **FinancePlay**, conforme o levantamento de requisitos definido por Mateus Moreira de Souza.

## 📋 Requisitos Cumpridos

- [x] Cadastro de usuário com CPF e senha hasheados (segurança de dados sensíveis)
- [x] Login com geração de token JWT
- [x] Autenticação e proteção de rotas com `[Authorize]`
- [x] Vinculação de usuários autenticados às entidades (extratos, transações)
- [x] Cadastro de extratos contendo: tipo de arquivo, nome original, período e hash do arquivo
- [x] Validação de extrato via hash para evitar duplicações
- [x] Listagem de extratos pertencentes ao usuário autenticado
- [x] Cadastro de transações financeiras com CNPJ, categoria, subcategoria e essencialidade
- [x] Validação de transações com base em extratos do próprio usuário
- [x] Listagem de transações por usuário autenticado
- [x] Integração com Swagger (documentação + testes com autenticação JWT)

## 🟡 Funcionalidades em Construção (levantamento previsto)

- [ ] Análise de CNPJ por tabela externa e classificação automática por CNAE
- [ ] Aplicação de regras financeiras personalizadas (ganho/perda de vidas)
- [ ] Controle de pontuação e vidas por desempenho financeiro
- [ ] Sistema de metas financeiras mensais (personalizáveis)
- [ ] Sistema de conquistas com desbloqueio automático (gamificação)
- [ ] Geração de dashboard com resumo financeiro mensal (gastos, categorias, etc.)
- [ ] Ranking mensal e geral com base nas metas e desempenho dos usuários

---

📫 Desenvolvido por: **Mateus Moreira de Souza**  
Email: mateus27mdes@gmail.com
