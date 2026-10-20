# City Explorer

City Explorer ist eine kleine Fullstack-Anwendung zur Suche nach Orten in einer Stadt.

Die Anwendung verwendet:

- C#
- ASP.NET Core Web API
- .NET
- MongoDB
- HTML / CSS / JavaScript

## Entwicklungsumgebung

Für die Entwicklung werden in Visual Studio Code folgende Plugins verwendet:

- **C# Dev Kit** (C#-DevKit) von Microsoft  
  Enthält die C#-Erweiterung und bietet unter anderem IntelliSense, Debugging und einen Solution Explorer für .NET-Projekte.
- **MongoDB for VS Code** (MongoDB-Plugin)  
  Ermöglicht die Verbindung zu MongoDB, das Durchsuchen von Datenbanken und Collections sowie das Ausführen von Abfragen direkt in VS Code.

## Projekt erstellen

Das Backend wird als C#-Projekt (ASP.NET Core Web API) mit folgendem Befehl angelegt:

```powershell
dotnet new webapi -n CityExplorer.Api
```

## MongoDB Driver installieren

Der offizielle MongoDB C# Driver wird im Projektordner als NuGet-Paket hinzugefügt:

```powershell
cd backend/CityExplorer.Api
dotnet add package MongoDB.Driver
```

## Pakete wiederherstellen

`dotnet restore` lädt die NuGet-Pakete herunter, die das Projekt laut `.csproj` benötigt:

```powershell
cd backend/CityExplorer.Api
dotnet restore
```

Das ist zum Beispiel nach dem Klonen des Repositories nötig. `dotnet run` führt die Wiederherstellung bei Bedarf automatisch aus.

## Anwendung starten und testen

Das Backend wird im Projektordner mit folgendem Befehl gestartet:

```powershell
cd backend/CityExplorer.Api
dotnet run
```

Die URL und der Port werden beim Start in der Konsole ausgegeben.

## Ziel

Benutzer sollen Orte wie zum Beispiel

- Cafés
- Restaurants
- Parks
- Museen
- Sehenswürdigkeiten
- Bahnhöfe

suchen und filtern können.

Zusätzlich sollen Orte in der Nähe einer geografischen Position gefunden werden können.

## Architektur

```text
Frontend
HTML / CSS / JavaScript
        ↓
      HTTP / REST
        ↓
Backend
C# / ASP.NET Core
        ↓
MongoDB C# Driver
        ↓
MongoDB
```

ASP.NET Core wird dabei ausschließlich für das Backend und die REST API verwendet.  
Das Frontend wird separat mit HTML, CSS und JavaScript umgesetzt.

## MongoDB

Die zentrale Collection heißt:

`places`

Beispiel für ein Dokument:

```json
{
  "name": "Volkspark Friedrichshain",
  "category": "park",
  "location": {
    "type": "Point",
    "coordinates": [13.437, 52.528]
  },
  "address": {
    "district": "Friedrichshain",
    "city": "Berlin"
  },
  "tags": [
    "park",
    "running",
    "playground"
  ],
  "rating": 4.6
}
```

Geografische Positionen werden als GeoJSON gespeichert.

Die Reihenfolge der Koordinaten ist:

```text
[Längengrad, Breitengrad]
```

Für geografische Abfragen wird ein `2dsphere`-Index verwendet.

## Erste Ausbaustufe

Zunächst soll das Backend:

- eine Verbindung zu MongoDB herstellen
- Orte aus der Collection `places` lesen
- Orte über eine REST API bereitstellen

Beispiel:

```http
GET /api/places
```

Später folgen unter anderem:

- Suche nach Kategorie
- Suche nach Eigenschaften
- Umkreissuche
- Frontend mit JavaScript