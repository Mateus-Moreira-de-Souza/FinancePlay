💸 FinancePlay – Sistema de Gestão Financeira Gamificada

O FinancePlay é uma plataforma completa de gestão financeira pessoal com gamificação integrada, que ajuda o usuário a entender, controlar e melhorar seus hábitos financeiros de forma interativa, inteligente e motivadora.

🎯 Objetivo do Sistema

O FinancePlay tem como propósito:

Ajudar o usuário a entender seus hábitos financeiros

Controlar gastos e incentivar a economia

Aplicar gamificação com vidas e conquistas

Analisar extratos bancários de forma automática

Gerar recomendações e insights personalizados

Promover ranking entre usuários com base em desempenho financeiro

🧱 Arquitetura Técnica
Tecnologia	Versão	Função
.NET	8.0	Plataforma principal
ASP.NET Core Web API	RESTful	Backend estruturado em camadas
MySQL	8.x	Banco de dados relacional
JWT Authentication	Ativo	Autenticação e segurança
Swagger UI	Ativo	Documentação e testes de API

Padrões de Projeto Implementados:

Repository Pattern

Strategy Pattern

Factory Method

Observer Pattern

Singleton Pattern

🧩 Estrutura de Pastas
FinancePlay.API/
│
├── Controllers/
├── Services/
├── Repositories/
│   ├── Interfaces/
│   └── Implementations/
├── Patterns/
│   ├── Strategy/
│   ├── Factory/
│   ├── Observer/
│   └── Singleton/
├── Models/
├── DTOs/
├── Data/
└── Helpers/

🚀 Levantamento de Requisitos ( 20 )

Cadastro de Usuário – criação de contas de forma segura via API.

Autenticação JWT – login protegido e emissão de tokens.

Listagem e gerenciamento de usuários – endpoints para visualização e controle.

Exclusão de Conta – remoção segura de dados do usuário.

Upload de Extratos Bancários (CSV) – leitura e importação automáticas.

Processamento Inteligente de Transações – criação dinâmica de registros.

Categorização Automática por CNPJ – identificação automática de categorias via Strategy Pattern.

Categorização Padrão de Gastos – fallback inteligente para transações genéricas.

Gamificação Integrada – sistema de vidas que reage ao comportamento financeiro.

Conquistas Automáticas – desbloqueio de conquistas baseado em eventos de economia.

Ranking de Usuários – classificação por desempenho financeiro e metas atingidas.

Geração de Insights Personalizados – análise automática de hábitos e alertas de melhoria.

Recomendações de Economia – sugestões práticas com base no histórico do usuário.

Histórico Mensal de Gastos – visão detalhada de evolução e consumo ao longo do tempo.

Exportação de Relatórios (CSV/JSON) – geração de relatórios personalizados para download.

Consulta de Transações – busca rápida e filtrada por data, valor e categoria.

Cálculo Automático da Meta de Economia – monitoramento do progresso mensal.

Sistema de Vidas Dinâmico – perda e ganho de vidas conforme metas e gastos.

Painel via Swagger UI – interface visual completa para teste e validação das rotas.

Integração com MySQL via Entity Framework Core – persistência de dados segura e eficiente.

🧠 Gamificação
Evento	Efeito no Usuário
Gasto acima do recomendado	-1 vida
Meta mensal atingida	+5 vidas
30 dias sem ultrapassar limite	+1 conquista
Ranking calculado por	% de economia sobre a renda mensal
🔒 Segurança

Autenticação JWT em todos os endpoints.

Camada Repository isolando a persistência de dados.

Validação e tratamento de erros centralizados.

Swagger UI com autenticação integrada para testes seguros.

🧠 Padrões GoF Utilizados
Padrão	Aplicação	Função
Singleton	DbConnectionFactory	Evita múltiplas conexões concorrentes
Strategy	Categorização de gastos	Permite trocar lógicas de categorização dinamicamente
Factory Method	Processamento de extrato	Criação de objetos Transacao durante importação
Observer	Gamificação e conquistas	Reage automaticamente a eventos de gasto
Repository Pattern	Camada de acesso a dados	Garante baixo acoplamento e manutenção simples
📈 Fluxo Arquitetural
Controller → Service → Repository → DbContext


Cada camada cumpre uma função clara:

Controllers → Interação com o usuário/API

Services → Regras de negócio

Repositories → Acesso e manipulação de dados

DbContext (EF Core) → Persistência no MySQL

🔧 Como Executar
dotnet restore
dotnet build
dotnet run


Acesse o Swagger UI:

http://localhost:5000/swagger
