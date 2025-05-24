# 📝 Task Manager

Este projeto é responsável por gerenciar as tarefas do dia a dia, permitindo o cadastro, visualização e acompanhamento do status de cada atividade.

---

## ⚙️ Configuração do Projeto Localmente

Siga os passos abaixo para configurar o ambiente de desenvolvimento local:

### 1. Clone o repositório

```bash
git clone https://github.com/VictorGFsouza/TaskManager.git
cd TaskManager
```

### 2. Restaure os pacotes NuGet:
```bash
dotnet restore
```

### 3. Configure o arquivo de ambiente:
Edite o arquivo appsettings.Development.json com suas configurações locais, especialmente a ConnectionStrings.
Exemplo: 
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=True;MultipleActiveResultSets=True"
  },
}
```

### 4. Rode o script no banco(usei SQL Server):
```bash
CREATE DATABASE TaskManagerDB;

USE TaskManagerDB;

CREATE TABLE [dbo].[Task] (
  [Id] INT IDENTITY(1,1) NOT NULL,
  [Title] NVARCHAR(100) NOT NULL,
  [Description] NVARCHAR(MAX) NULL,
  [CreateDate] DATETIME NOT NULL,
  [FinishDate] DATETIME NULL,
  [Status] INT NOT NULL,
  CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
  (
    [Id] ASC
  ) WITH (
    PAD_INDEX = OFF, 
    STATISTICS_NORECOMPUTE = OFF, 
    IGNORE_DUP_KEY = OFF, 
    ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON, 
    OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
  ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

```

### 6. Rode o projeto:
```bash
   dotnet run
```

### 7. O projeto estará disponivel:
   https://localhost:7131
