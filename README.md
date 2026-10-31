# ToDo – Gestionnaire de tâches ASP.NET Core MVC

![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap-5-7952B3?logo=bootstrap&logoColor=white)

Application web de gestion de tâches (todo list) développée avec **ASP.NET Core MVC (.NET 9)**. Elle permet de créer un compte, de se connecter, puis d'ajouter, modifier et supprimer des tâches avec une date limite et un statut.

Ce projet a été réalisé dans le cadre d'un TP de Génie Informatique. Il met en pratique l'architecture MVC, les ViewModels, les filtres d'action et la gestion de la session.

## Sommaire

- [Fonctionnalités](#fonctionnalités)
- [Stack technique](#stack-technique)
- [Architecture](#architecture)
- [Prérequis](#prérequis)
- [Installation et lancement](#installation-et-lancement)
- [Routes principales](#routes-principales)
- [Structure du projet](#structure-du-projet)
- [Limites connues et pistes d'amélioration](#limites-connues-et-pistes-damélioration)
- [Auteur](#auteur)

## Fonctionnalités

- **Authentification** : inscription, connexion et déconnexion
- **Gestion des tâches (CRUD)** : ajout, liste, modification et suppression
- **Statuts** : `TODO`, `DOING`, `DONE`
- **Champs d'une tâche** : libellé, description, date limite, statut
- **Validation des formulaires** côté client (jQuery Validation) et côté serveur (Data Annotations)
- **Accès protégé** : les pages de tâches sont réservées aux utilisateurs connectés (`AuthFilter`)
- **Journalisation** : chaque action est enregistrée dans un fichier `logs.txt`, créé dans le dossier d'exécution de l'application (`LogActionFilter`)

## Stack technique

| Domaine | Technologie |
|---|---|
| Langage | C# |
| Framework | ASP.NET Core MVC (.NET 9) avec vues Razor |
| Stockage | Session ASP.NET Core (données en mémoire, sérialisées en JSON) |
| Front-end | Bootstrap 5, jQuery, jQuery Validation |
| Outils | Visual Studio / VS Code, Git |

## Architecture

Le projet suit le pattern **MVC** avec une séparation des responsabilités :

- **Models** : entités métier (`Todo`, `User`)
- **ViewModels** : modèles dédiés aux formulaires et aux listes, avec les règles de validation
- **Mappers** : conversion entre Models et ViewModels
- **Controllers** : `AuthController` (inscription et connexion) et `TodosController` (CRUD)
- **Services** : `SessionManagerService` (accès à la session via l'interface `ISessionManagerService`, injectée par DI) et `FileLogger`
- **Filters** : `AuthFilter` (protection des pages) et `LogActionFilter` (journalisation globale)

## Prérequis

- [SDK .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- Git
- Un IDE au choix : Visual Studio 2022 (17.12 ou plus récent), VS Code ou JetBrains Rider

Vérifier l'installation :

```bash
dotnet --version
```

## Installation et lancement

```bash
# 1. Cloner le dépôt
git clone https://github.com/CharafAZIZI/aspnet-todo-app.git
cd aspnet-todo-app

# 2. Lancer l'application
cd ToDo
dotnet run
```

L'application est ensuite accessible sur :

- http://localhost:5299
- https://localhost:7195 (profil `https`, via `dotnet run --launch-profile https`)

Avec Visual Studio, ouvrir `ToDo.sln` puis lancer le projet avec **F5**.

### Première utilisation

1. Ouvrir la page **S'inscrire** et créer un compte.
2. Se connecter avec cet identifiant.
3. Ajouter, modifier ou supprimer des tâches depuis la liste.

## Routes principales

| Route | Description | Accès |
|---|---|---|
| `/Auth/Login` | Page de connexion (page d'accueil par défaut) | Public |
| `/Auth/Register` | Création de compte | Public |
| `/Auth/Logout` | Déconnexion | Public |
| `/Todos` | Liste des tâches | Connecté |
| `/Todos/Add` | Ajout d'une tâche | Connecté |
| `/Todos/Edit/{id}` | Modification d'une tâche | Connecté |
| `/Todos/Delete/{id}` | Suppression d'une tâche | Connecté |

## Structure du projet

```
aspnet-todo-app/
├── ToDo.sln
└── ToDo/
    ├── Controllers/     AuthController, TodosController
    ├── Enums/           State (TODO, DOING, DONE)
    ├── Filters/         AuthFilter, LogActionFilter
    ├── Mappers/         TodoMapper, UserMapper
    ├── Models/          Todo, User, ErrorViewModel
    ├── Services/        SessionManagerService, FileLogger
    ├── ViewModels/      LoginVM, RegisterVM, TodoAddVM, TodoEditVM, TodoListVM
    ├── Views/           Auth, Todos, Shared
    ├── wwwroot/         CSS, JavaScript, bibliothèques front-end
    ├── Program.cs       Configuration et pipeline de l'application
    └── appsettings.json
```

## Limites connues et pistes d'amélioration

Ce projet est un TP à visée pédagogique. Il n'est pas destiné à être déployé en production tel quel.

- **Stockage en session** : les utilisateurs et les tâches sont conservés dans la session. Ils sont perdus à l'expiration de la session ou au redémarrage de l'application.
- **Authentification simplifiée** : les identifiants sont gérés manuellement, sans hachage des mots de passe.
- **Tâches non liées à un utilisateur** : la liste de tâches est propre à la session, pas à un compte.

Pistes d'amélioration :

- [ ] Persistance avec Entity Framework Core et une base SQLite ou SQL Server
- [ ] Authentification avec ASP.NET Core Identity (hachage des mots de passe, `[Authorize]`)
- [ ] Association des tâches à un utilisateur
- [ ] Suppression et déconnexion via des requêtes POST avec protection anti-CSRF
- [ ] Tests unitaires (xUnit)
- [ ] Intégration continue avec GitHub Actions

## Auteur

**Charaf AZIZI** – Étudiant en 5e année de Génie Informatique (EHEIM, Oujda), Full Stack Developer & intégration IA/LLM.

- GitHub : [@CharafAZIZI](https://github.com/CharafAZIZI)
- LinkedIn : [charaf-azizi](https://www.linkedin.com/in/charaf-azizi-4ba398351/)