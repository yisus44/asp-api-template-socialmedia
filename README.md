# A starter template for asp.net web api proyect

An opinionated template to save time in common configuration cases of ASP.NET Web API proyects using the excuse of a social media app.


### Features

- Separation of proyects in presentation (API), domain (App), data access (Infra) and entities (Core)
- Entity Framework with SQL Server configurated.
- Identity configuration for a Web API (JSON based)
- CQRS Pattern with MediatR
- Request validation with Data Annotations
- Generic repository and unit of work .
- 
#### Working with the app
##### Migrations
###### Create a migration

Replace <MigrationName> with the meaningful name of the migration
```console
dotnet ef migrations add <MigrationName> --startup-project API --project Infra
```
###### Apply the migrations to the database

```console
	dotnet ef database update --startup-project API --project Infra
```
## Why?
I built this template mainly because Microsoft Documentation in my opinion is centered way too much in using dotnet with Razor Pages and it forgets about the teams that are used to have client and API in different langauges. This is the case specially with Identity Framework and the Generic Repository Pattern. So this proyect is to help devs to understand and have a reference how they can get together a proyect. Feel free to contribue or discute another things that could be useful to have as reference


### Next things
- Unit and integration tests
- Logging with serilog
- CI/CD Deployments with Github actions
- Secrets managment with Azure key vault
- File managament with Azure Block Blobs
- Redis Caching
- Perfomance testing

