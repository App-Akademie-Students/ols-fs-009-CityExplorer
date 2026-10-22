# City Explorer

City Explorer ist eine kleine Fullstack-Anwendung zur Suche nach Orten in einer Stadt.

Die Anwendung verwendet:

- C#
- ASP.NET Core Web API
- .NET
- MongoDB
- HTML / CSS / JavaScript
- Leaflet + OpenStreetMap (Karte)

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

Die URL und der Port werden beim Start in der Konsole ausgegeben. Mit dem Profil `http` läuft die Anwendung auf `http://localhost:5180`:

```powershell
dotnet run --launch-profile http
```

| URL | Inhalt |
| --- | --- |
| `http://localhost:5180/` | Frontend mit Karte |
| `http://localhost:5180/swagger` | Swagger UI zum Testen der REST API (nur in Development) |
| `http://localhost:5180/places` | REST API |

MongoDB muss dabei laufen.

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

Das Frontend (Ordner `frontend`) besteht aus reinem HTML, CSS und JavaScript ohne Build-Schritt.  
Es wird vom ASP.NET-Core-Server als statische Dateien mit ausgeliefert (siehe `Program.cs`) und ruft die REST API relativ unter `/places` auf. Frontend und API laufen also auf demselben Server.

Die Karte nutzt [Leaflet](https://leafletjs.com/) (per CDN geladen) mit Kacheln von [OpenStreetMap](https://www.openstreetmap.org/). Dafür wird eine Internetverbindung benötigt.

### Frontend

- Orte werden als Marker auf der Karte und als Karten in einer Liste angezeigt.
- Textsuche (Name, Tag, Bezirk) und Kategorie-Filter.
- Umkreissuche: Position per Klick auf die Karte, über „Mein Standort“ oder durch Eingabe der Koordinaten festlegen.
- Klick auf einen Ort in der Liste zoomt zum Marker und öffnet das Popup.

### REST API

| Methode | Pfad | Beschreibung |
| --- | --- | --- |
| GET | `/places` | alle Orte |
| GET | `/places/{id}` | ein Ort (404, wenn nicht vorhanden) |
| GET | `/places/category/{category}` | Orte einer Kategorie |
| GET | `/places/nearby?latitude=..&longitude=..&maxDistanceInMeters=..` | Orte im Umkreis (Standard: 1000 m) |
| POST | `/places` | Ort anlegen |

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
GET /places
```

Inzwischen umgesetzt sind außerdem:

- Suche nach Kategorie
- Umkreissuche
- Frontend mit JavaScript und Karte

Noch offen ist unter anderem die Suche nach weiteren Eigenschaften.


## Mit Swagger die RestAPI testen
dotnet add package Swashbuckle.AspNetCore

## C# MongoDB Docs
* https://www.mongodb.com/docs/drivers/csharp/current/crud/query/find/
  
