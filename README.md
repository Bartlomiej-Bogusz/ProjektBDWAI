# ProjektBDWAI — Instrukcja uruchomienia

Aplikacja ASP.NET Core Razor Pages (.NET 10) z wbudowanym Identity, EF Core i SQL Server.

## Wymagania
- .NET 10 SDK
- Visual Studio 2026 (zalecane) lub VS Code z rozszerzeniami C#
- SQL Server (np. SQL Server Express, LocalDB lub instancja zdalna)
- (Opcjonalnie) narzędzie EF Core CLI: `dotnet-ef`

## Instalacja
1. Sklonuj repozytorium:

git clone https://github.com/Bartlomiej-Bogusz/ProjektBDWAI.git cd ProjektBDWAI

2. Przywróć pakiety:
   - CLI: `dotnet restore`
   - Visual Studio: otwórz projekt — pakiety zostaną przywrócone automatycznie lub użyj __Tools > NuGet Package Manager > Package Manager Console__.

## Konfiguracja
1. Connection string — edytuj `appsettings.json`, ustaw `ConnectionStrings:ProjektBDWAIContextConnection`, np.:

"ConnectionStrings": { "ProjektBDWAIContextConnection": "Server=(localdb)\mssqllocaldb;Database=ProjektBDWAI;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true" }


2. Seeder konta administracyjnego:
   - Aplikacja seeduje role `Admin` i `User` oraz konto admina przy starcie (pliki: `Program.cs`, `Areas/Identity/Data/IdentitySeeder.cs`).
   - Domyślne dane:
     - Email: `admin@admin.pl`
     - Hasło: `Admin123!`
   - Zmień hasło lub usuń domyślne konto w środowisku produkcyjnym.

## Migracje i inicjalizacja bazy
- Zastosuj migracje:
  - Visual Studio: użyj __Package Manager Console__ -> `Update-Database`.

- Tworzenie nowej migracji:

Add-Migration Migracja
Update-Database

## Uruchamianie aplikacji
- Visual Studio: ustaw projekt `ProjektBDWAI` jako startowy i uruchom (__IIS Express__ lub __Debug > Start Debugging__).
- CLI:

dotnet run --project ProjektBDWAI.csproj

- Domyślny adres: `https://localhost:5001` (port może się różnić).

## API / Dokumentacja
- Swagger jest włączony. Po uruchomieniu otwórz `/swagger` (np. `https://localhost:5001/swagger`) by zobaczyć dostępne endpointy API.













