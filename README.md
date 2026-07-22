# SmartEstoque

**Plataforma inteligente de gerenciamento de estoque e vendas com autenticação corporativa Okta.**

SmartEstoque é uma aplicação web moderna desenvolvida em **ASP.NET Core 6.0** que oferece um sistema completo de gestão de inventário, cadastros de produtos, fornecedores e gerenciamento de vendas com rastreamento de remessas. A plataforma integra autenticação segura via **Okta** e utiliza **PostgreSQL** para persistência robusta de dados.

---

## 📋 Sumário

- [Características](#características)
- [Stack Tecnológico](#stack-tecnológico)
- [Arquitetura](#arquitetura)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Executando a Aplicação](#executando-a-aplicação)
- [Módulos e Funcionalidades](#módulos-e-funcionalidades)
- [API e Endpoints](#api-e-endpoints)
- [Segurança](#segurança)
- [Banco de Dados](#banco-de-dados)
- [Tratamento de Erros](#tratamento-de-erros)
- [Contribuindo](#contribuindo)

---

## ✨ Características

- ✅ **Gerenciamento de Estoque**: Cadastro, alteração e desativação de produtos
- ✅ **Gestão de Fornecedores**: Manutenção completa de dados de fornecedores
- ✅ **Classificação de Produtos**: Organização por grupos, tipos e modelos
- ✅ **Controle de Vendas**: Registro e rastreamento de vendas
- ✅ **Gerenciamento de Remessas**: Pedidos, status e ordens de remessa
- ✅ **Autenticação Corporativa**: Integração com Okta para SSO
- ✅ **Logging Centralizado**: Sistema de logs de erros na base de dados
- ✅ **Interface Responsiva**: Suporte a múltiplos dispositivos
- ✅ **Segurança Avançada**: Proteção CSRF, HTTPS redirect, antiforgery tokens

---

## 🛠️ Stack Tecnológico

### Backend
- **Framework**: ASP.NET Core 6.0
- **Linguagem**: C# 10.0
- **Banco de Dados**: PostgreSQL 7.0
- **ORM/Query Builder**: Dapper 2.0.123
- **Autenticação**: Okta ASP.NET Core SDK 4.4.2
- **HTTP Client**: RestSharp 110.2.0

### Frontend
- **Markup**: HTML5
- **Estilos**: CSS3 (6.8% do código)
- **Scripts**: JavaScript (68.8% do código)
- **Engine de Visualização**: Razor Pages (.cshtml)

### Infraestrutura
- **Servidor Web**: Kestrel (integrado no ASP.NET Core)
- **Protocolo**: HTTPS/HTTP
- **Gerenciamento de Projeto**: Visual Studio 2022
- **Versionamento**: Git

---

## 🏗️ Arquitetura

O projeto segue um padrão **camadas de negócio (3-tier architecture)** com separação clara de responsabilidades:

```
┌─────────────────────────────────────────────────────────┐
│                   Presentation Layer                     │
│        Controllers + Razor Views (.cshtml)               │
│  (HomeController, LoginController, CadastroController)  │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│                   Business Logic Layer                   │
│              Business Logic Layer (BLL)                  │
│  (CadastroProdutosBLL, CadastroFornecedorBLL, etc)      │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│                   Data Access Layer                      │
│              Data Access Layer (DAL)                     │
│  (CadastroProdutosDAL, CadastroFornecedorDAL, etc)      │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│                   Utility/Architecture Layer             │
│   DbConnection, Util, AppSettings, Modulos              │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│                   Database Layer                         │
│              PostgreSQL Database                         │
│    (cadlogsis, Products, Vendors, Orders, etc)          │
└─────────────────────────────────────────────────────────┘
```

### Padrões de Design Utilizados

1. **MVC (Model-View-Controller)**: Separação entre apresentação e lógica
2. **Repository Pattern**: Camada DAL encapsula acesso aos dados
3. **Business Logic Pattern**: BLL centraliza regras de negócio
4. **Dependency Injection**: Integração com DI do ASP.NET Core
5. **Transfer Object Pattern**: Uso de modelos (TO, DTO) para transferência de dados

---

## 📁 Estrutura do Projeto

```
smartEstoque/
├── Controllers/                    # Camada de Apresentação - Controladores MVC
│   ├── HomeController.cs          # Dashboard e navegação principal
│   ├── LoginController.cs         # Autenticação e logout (Okta)
│   ├── CadastroProdutosController.cs
│   ├── CadastroFornecedorController.cs
│   ├── CadastroGrupoProdutosController.cs
│   ├── CadastroModeloProdutosController.cs
│   ├── CadastroTipoProdutosController.cs
│   ├── CadastroOrdemRemessaController.cs
│   ├── CadastroStatusOrdemRemessaController.cs
│   └── CadastroVendasController.cs
│
├── Models/                         # Modelos de Apresentação e Configuração
│   ├── AppSettings.cs             # Configurações da aplicação (Okta, URLs)
│   ├── ErrorViewModel.cs          # Modelo para página de erro
│   └── Models/
│       ├── CadastroProdutosModel.cs
│       ├── CadastroFornecedorModel.cs
│       ├── CadastroGrupoProdutosModel.cs
│       ├── CadastroModeloProdutosModel.cs
│       ├── CadastroTipoProdutosModel.cs
│       ├── CadastroOrdemRemessaModel.cs
│       ├── CadastroStatusOrdemRemessaModel.cs
│       └── CadastroVendasModel.cs
│
├── Business/                       # Camada de Negócio - Lógica de Aplicação
│   ├── CadastroProdutos/
│   │   ├── CadastroProdutosBLL.cs  # Business Logic Layer
│   │   ├── CadastroProdutosDAL.cs  # Data Access Layer
│   │   ├── CadastroProdutosDALSQL.cs # Queries SQL
│   │   └── CadastroProdutosTO.cs   # Transfer Object
│   ├── CadastroFornecedor/
│   ├── CadastroGrupoProdutos/
│   ├── CadastroModeloProdutos/
│   ├── CadastroTipoProdutos/
│   ├── CadastroOrdemRemessa/
│   ├── CadastroStatusOrdemRemessa/
│   ├── CadastroVendas/
│   └── teste.cs                    # Arquivo de teste/desenvolvimento
│
├── Class/                          # Camada de Utilitário
│   └── DbConnection.cs             # Gerenciamento de conexões PostgreSQL
│
├── Arquitetura/                    # Camada de Arquitetura
│   └── Classes/
│       ├── Util.cs                 # Utilitários gerais (logging, config)
│       └── Modulos.cs              # Definição de módulos/permissões
│
├── Views/                          # Camada de Apresentação - Razor Views
│   ├── Home/
│   │   ├── Index.cshtml           # Dashboard principal
│   │   └── Privacy.cshtml
│   ├── Paginas/                    # Páginas específicas por módulo
│   │   ├── CadastroProdutos/
│   │   ├── CadastroFornecedor/
│   │   ├── CadastroGrupoProdutos/
│   │   ├── CadastroModeloProdutos/
│   │   ├── CadastroTipoProdutos/
│   │   ├── CadastroOrdemRemessa/
│   │   ├── CadastroStatusOrdemRemessa/
│   │   └── CadastroVendas/
│   ├── Shared/                     # Layouts e componentes compartilhados
│   │   ├── _Layout.cshtml
│   │   └── Error.cshtml
│   ├── _ViewImports.cshtml         # Imports globais
│   └── _ViewStart.cshtml           # Inicialização de views
│
├── wwwroot/                        # Arquivos estáticos (CSS, JS, imagens)
│   ├── css/
│   ├── js/
│   └── images/
│
├── Properties/                     # Propriedades do projeto
│   └── launchSettings.json         # Configurações de execução
│
├── Program.cs                      # Ponto de entrada da aplicação
├── SmartEstoque.csproj             # Arquivo de projeto C#
├── SmartEstoque.sln                # Solução Visual Studio
├── appsettings.json                # Configurações da aplicação
├── appsettings.Development.json    # Configurações de desenvolvimento
└── .gitignore                      # Arquivos ignorados pelo Git
```

### Fluxo de Dados

```
1. Requisição HTTP chega ao Controller
                ↓
2. Controller valida entrada e chama método da BLL
                ↓
3. BLL aplica regras de negócio
                ↓
4. BLL delega acesso aos dados para DAL
                ↓
5. DAL executa queries SQL no PostgreSQL
                ↓
6. Dados retornam pela cadeia (DAL → BLL → Controller)
                ↓
7. Controller passa dados para View
                ↓
8. View renderiza HTML/JavaScript para o cliente
```

---

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

### Software Obrigatório
- **.NET 6.0 SDK**: [Baixar](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- **PostgreSQL 13+**: [Baixar](https://www.postgresql.org/download/)
- **Visual Studio 2022** (recomendado) ou **VS Code**
- **Git**: [Baixar](https://git-scm.com/)

### Conta e Credenciais
- **Conta Okta**: Para autenticação corporativa [Okta](https://www.okta.com/)
  - `OktaDomain`
  - `ClientId`
  - `ClientSecret`

### Variáveis de Ambiente Recomendadas
```bash
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=https://localhost:7220
```

---

## 🔧 Instalação e Configuração

### 1. Clonar o Repositório

```bash
git clone https://github.com/gabrielmontb/smartEstoque.git
cd smartEstoque
```

### 2. Configurar o Banco de Dados PostgreSQL

```bash
# Criar banco de dados
createdb SmartEstoque -U postgres

# Conectar ao banco
psql -U postgres -d SmartEstoque

# Executar script de criação de tabelas (criar arquivo sql)
```

**Script SQL de Inicialização** (`init.sql`):

```sql
-- Tabela de Logs do Sistema
CREATE TABLE IF NOT EXISTS cadlogsis (
    codlog SERIAL PRIMARY KEY,
    desclalog VARCHAR(255),
    desmetlog VARCHAR(255),
    deslog TEXT,
    datcad TIMESTAMP DEFAULT NOW()
);

-- Tabela de Produtos
CREATE TABLE IF NOT EXISTS cadprodutos (
    codprd SERIAL PRIMARY KEY,
    desprd VARCHAR(255) NOT NULL,
    codmodprd INTEGER,
    vlruntprd DECIMAL(10, 2),
    despesprd DECIMAL(10, 2),
    datvncprd DATE,
    datcad TIMESTAMP DEFAULT NOW(),
    status INTEGER DEFAULT 1
);

-- Tabela de Fornecedores
CREATE TABLE IF NOT EXISTS cadfornecedor (
    codfrnprd SERIAL PRIMARY KEY,
    desfrnprd VARCHAR(255),
    telctofrn VARCHAR(20),
    nomrspfrn VARCHAR(255),
    desendfrn VARCHAR(255),
    descidfrn VARCHAR(100),
    desestafrn VARCHAR(2),
    datcad TIMESTAMP DEFAULT NOW(),
    status INTEGER DEFAULT 1
);

-- Índices para melhor performance
CREATE INDEX idx_cadprodutos_desprd ON cadprodutos(desprd);
CREATE INDEX idx_cadfornecedor_desfrnprd ON cadfornecedor(desfrnprd);
CREATE INDEX idx_cadlogsis_datcad ON cadlogsis(datcad);
```

### 3. Configurar Okta

Abra `appsettings.json` e configure suas credenciais Okta:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "OktaDomain": "https://seu-dominio.okta.com",
  "ClientId": "seu-client-id",
  "ClientSecret": "seu-client-secret",
  "CallbackPath": "/Login/Login",
  "URLOktaAPI": "/api/v1/users/#USUARIO/groups",
  "AllowedHosts": "*"
}
```

### 4. Configurar Cadeia de Conexão

Abra `Class/DbConnection.cs` e atualize a string de conexão:

```csharp
public DbConnection()
{
    Connection = new NpgsqlConnection(
        "Server=localhost;Port=5432;Database=SmartEstoque;User id=postgres;Password=sua_senha;"
    );
    Connection.Open();
}
```

### 5. Restaurar Dependências

```bash
dotnet restore
```

---

## ▶️ Executando a Aplicação

### Via Visual Studio 2022

1. Abra `SmartEstoque.sln` no Visual Studio
2. Defina como projeto de inicialização `SmartEstoque`
3. Pressione `F5` ou clique em **Start**
4. A aplicação abrirá em `https://localhost:7220`

### Via Linha de Comando

```bash
# Build da aplicação
dotnet build

# Executar em desenvolvimento
dotnet run

# Executar com watch mode (recompila ao detectar mudanças)
dotnet watch run

# Build e publicação para produção
dotnet publish -c Release -o ./publish
```

### Acessar a Aplicação

- **URL Principal**: `https://localhost:7220`
- **Login**: Será redirecionado para autenticação Okta
- **Dashboard**: `https://localhost:7220/Home/Index`

---

## 🎯 Módulos e Funcionalidades

### 1. **Autenticação e Acesso (LoginController)**
- Login via Okta OpenID Connect
- Logout seguro com limpeza de sessão
- Verificação de identidade
- Gestão de tokens de acesso

### 2. **Gerenciamento de Produtos (CadastroProdutosController)**
- **Operações CRUD**: Criar, ler, atualizar e desativar produtos
- **Campos principais**:
  - Código do Produto (CODPRD)
  - Descrição (DESPRD)
  - Código do Modelo (CODMODPRD)
  - Valor Unitário (VLRUNTPRD)
  - Data de Vencimento (DATVNCPRD)
  - Especificações (DESPESPRD)

### 3. **Gestão de Fornecedores (CadastroFornecedorController)**
- Cadastro de informações de fornecedores
- Campos: Nome, Telefone, Endereço, Cidade, Estado
- Status de atividade

### 4. **Classificação de Produtos**
- **Grupos de Produtos**: Organização por categoria
- **Tipos de Produtos**: Tipologia dos itens
- **Modelos de Produtos**: Variações e especificações

### 5. **Gerenciamento de Vendas (CadastroVendasController)**
- Registro de transações de venda
- Rastreamento de quantidades
- Histórico de vendas

### 6. **Controle de Remessas**
- **Ordens de Remessa**: Criação e gerenciamento de pedidos
- **Status de Remessa**: Acompanhamento do estado (Pedido, Enviado, Entregue, etc.)

### 7. **Dashboard Principal (HomeController)**
- Visão geral dos módulos
- Acesso rápido aos cadastros
- Informações de usuário autenticado

---

## 🔌 API e Endpoints

### Autenticação
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/Login/Login` | Inicia login via Okta |
| POST | `/Login/Logout` | Realiza logout |

### Produtos
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/Home/CadastroProdutos` | Exibe formulário de cadastro |
| POST | `/api/CadastroProdutos/Inserir` | Insere novo produto |
| POST | `/api/CadastroProdutos/Obter` | Obtém lista de produtos |
| POST | `/api/CadastroProdutos/Alterar` | Atualiza produto |
| POST | `/api/CadastroProdutos/Ativar` | Ativa produto |
| POST | `/api/CadastroProdutos/Desativar` | Desativa produto |

### Fornecedores
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/Home/CadastroFornecedor` | Exibe formulário de cadastro |
| POST | `/api/CadastroFornecedor/*` | Operações CRUD |

### Vendas
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/Home/CadastroVendas` | Exibe formulário de vendas |
| POST | `/api/CadastroVendas/*` | Operações de venda |

### Remessas
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/Home/CadastroOrdemRemessa` | Exibe ordens de remessa |
| GET | `/Home/CadastroStatusOrdemRemessa` | Gerencia status |
| POST | `/api/CadastroOrdemRemessa/*` | Operações de remessa |

---

## 🔒 Segurança

### Mecanismos Implementados

1. **Autenticação via Okta**
   - Integração OpenID Connect
   - Suporte a SSO corporativo
   - Escopo de permissões: openid, profile, email

2. **Proteção CSRF**
   ```csharp
   services.AddAntiforgery(options =>
   {
       options.HeaderName = "X-CSRF-TOKEN";
   });
   ```

3. **HTTPS Obrigatório**
   ```csharp
   app.UseHttpsRedirection();
   ```

4. **Sessão Segura**
   ```csharp
   services.AddSession(options =>
   {
       options.IdleTimeout = TimeSpan.FromMinutes(60);
       options.Cookie.HttpOnly = true;
   });
   ```

5. **Headers de Segurança**
   - Referrer-Policy: no-referrer-when-downgrade
   - X-Frame-Options: Sameorigin (implícito)

6. **Autorização por Atributo**
   ```csharp
   [Authorize]
   public class HomeController : Controller
   ```

### Recomendações de Segurança

- ⚠️ **Nunca commitir credenciais**: Use variáveis de ambiente
- 🔑 **Rotação de segredos**: Altere `ClientSecret` periodicamente
- 📊 **Auditoria**: Revise logs em `cadlogsis` regularmente
- 🛡️ **HTTPS em produção**: Configure certificado SSL válido
- 🔐 **Senhas de BD**: Use senha forte para PostgreSQL

---

## 🗄️ Banco de Dados

### Diagrama Entidade-Relacionamento Conceitual

```
┌─────────────────┐       ┌──────────────────┐       ┌─────────────────┐
│  cadprodutos    │   1 ──┤ cadmodprodutos   │ ── 1  │ cadgruprodutos  │
│                 │       │                  │       │                 │
│ • codprd (PK)   │       │ • codmodprd (PK) │       │ • codgrprod (PK)│
│ • desprd        │       │ • desmodprd      │       │ • desgrprod     │
│ • vlruntprd     │       │ • codtipprd      │       │ • status        │
│ • status        │       │ • status         │       └─────────────────┘
└─────────────────┘       └──────────────────┘

┌──────────────────┐       ┌─────────────────┐       ┌──────────────────┐
│ cadfornecedor    │ 1 ──  │ cadprodutos     │ ── 1  │ cadvendasremessa │
│                  │       │                 │       │                  │
│ • codfrnprd (PK) │       │ • codprd (PK)   │       │ • codVenda (PK)  │
│ • desfrnprd      │       │ • desfrnprd (FK)│       │ • datvenda       │
│ • telctofrn      │       │ • status        │       │ • status         │
│ • status         │       └─────────────────┘       └──────────────────┘
└──────────────────┘

┌──────────────────────┐
│    cadlogsis         │  (Auditoria e Logs)
│                      │
│ • codlog (PK)        │
│ • desclalog          │
│ • desmetlog          │
│ • deslog             │
│ • datcad (Timestamp) │
└──────────────────────┘
```

### Queries Principais

**Obter Produtos Ativos:**
```sql
SELECT * FROM cadprodutos WHERE status = 1 ORDER BY desprd;
```

**Listar Fornecedores:**
```sql
SELECT * FROM cadfornecedor WHERE status = 1;
```

**Histórico de Erros:**
```sql
SELECT * FROM cadlogsis ORDER BY datcad DESC LIMIT 100;
```

---

## ⚠️ Tratamento de Erros

### Sistema de Logging Centralizado

A classe `Util.cs` implementa logging estruturado:

```csharp
public static void CriaLogErro(
    Exception ex, 
    string Metodo = "", 
    string classe = "", 
    string Param = "")
{
    // Cria log estruturado no PostgreSQL
    // Tabela: cadlogsis
}
```

### Uso em Business Logic

```csharp
public bool inserirProdutos(CadastroProdutosModel.InserirCadastroProdutos objInserir)
{
    try
    {
        return new CadastroProdutosDAL().inserirProdutos(objInserir);
    }
    catch (Exception ex)
    {
        Util.CriaLogErro(ex, "inserirProdutos", "CadastroProdutosBLL", 
            JsonConvert.SerializeObject(objInserir));
        throw ex;
    }
}
```

### Página de Erro

- **Endpoint**: `/Home/Error`
- **View**: `Views/Home/Error.cshtml`
- **Modelo**: `ErrorViewModel`

---

## 📚 Guia de Desenvolvimento

### Adicionar Novo Módulo

1. **Criar Controller**
   ```csharp
   [Authorize]
   public class CadastroXXXController : Controller
   {
       public IActionResult Index()
       {
           return View("/Views/Paginas/CadastroXXX/Index.cshtml");
       }
   }
   ```

2. **Criar Model**
   ```csharp
   namespace SmartEstoque.Models
   {
       public class CadastroXXXModel
       {
           public int Id { get; set; }
           // Propriedades...
       }
   }
   ```

3. **Criar BLL**
   ```csharp
   public class CadastroXXXBLL
   {
       public bool Inserir(CadastroXXXModel obj)
       {
           try
           {
               return new CadastroXXXDAL().Inserir(obj);
           }
           catch (Exception ex)
           {
               Util.CriaLogErro(ex, nameof(Inserir), nameof(CadastroXXXBLL));
               throw;
           }
       }
   }
   ```

4. **Criar DAL**
   ```csharp
   public class CadastroXXXDAL
   {
       public bool Inserir(CadastroXXXModel obj)
       {
           using var conn = new DbConnection().Connection;
           // Executar INSERT
       }
   }
   ```

5. **Criar View (Razor)**
   ```html
   @page
   @model CadastroXXXModel
   
   <div class="container">
       <h2>Cadastro XXX</h2>
       <!-- Formulário -->
   </div>
   ```

---

## 🧪 Testando a Aplicação

### Testes Manuais com Postman

1. **Obter Token Okta**
   - Authenticate via Okta
   - Copiar `access_token` dos cookies

2. **Testar Endpoint de Produtos**
   ```
   POST /api/CadastroProdutos/Obter
   Authorization: Bearer {access_token}
   Content-Type: application/json
   
   {
       "CODPRD": 0,
       "DESPRD": ""
   }
   ```

### Testes Unitários Recomendados

- Validação de entrada em Models
- Lógica de negócio em BLL
- Queries em DAL
- Tratamento de exceções

---

## 📝 Boas Práticas Implementadas

✅ Separação de responsabilidades (3-tier)  
✅ Injeção de dependência (DI)  
✅ Autenticação centralizada (Okta)  
✅ Logging estruturado  
✅ Proteção contra CSRF  
✅ HTTPS obrigatório  
✅ Nomes de classes seguem padrão (BLL, DAL, TO)  
✅ Uso de async/await para operações assíncronas  
✅ Versionamento com Git  

---

## 🤝 Contribuindo

### Processo de Contribuição

1. Faça fork do repositório
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adicionar MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

### Diretrizes de Código

- Siga a convenção de nomenclatura C# (PascalCase para classes, camelCase para variáveis)
- Adicione comentários para lógica complexa
- Teste manualmente antes de enviar PR
- Atualize documentação se necessário

---

## 📞 Suporte e Contato

**Desenvolvedor**: Gabriel Monteiro de Oliveira  
**Email**: gabrielmontb@github.com  
**Repositório**: https://github.com/gabrielmontb/smartEstoque  
**Issues**: https://github.com/gabrielmontb/smartEstoque/issues

---

## 📄 Licença

Este projeto é fornecido "como está" para fins educacionais e comerciais.

---

## 🔄 Roadmap Futuro

- [ ] API RESTful completa com documentação OpenAPI/Swagger
- [ ] Autenticação com suporte a 2FA
- [ ] Dashboard analytics com gráficos
- [ ] Integração com sistemas de pagamento
- [ ] Mobile app (React Native)
- [ ] Cache distribuído (Redis)
- [ ] Fila de mensagens (RabbitMQ)
- [ ] Containerização (Docker)
- [ ] CI/CD pipeline (GitHub Actions)

---

**Versão**: 1.0.0  
**Última Atualização**: 2026-07-22  
**Status**: Ativo e em Desenvolvimento
