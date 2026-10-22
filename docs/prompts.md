# Prompts

Sammlung der verwendeten Claude-Prompts im Projekt City Explorer.

## Übersicht

| Nr. | Datum | Uhrzeit | Thema | Ergebnis |
|-----|-------|---------|-------|----------|
| 1 | 2026-10-20 | – | Beispieldaten places.json | 50 Orte in Berlin unter example-data/places.json erstellt |
| 2 | 2026-10-20 | – | MongoDB-Modellklassen | Place und Address im Ordner backend/Model erstellt |
| 3 | 2026-10-20 | 15:38 | Fehlende Uhrzeit in prompts.md | Ursache erklärt, Eintrag mit echter Uhrzeit ergänzt |
| 4 | 2026-10-20 | 15:50 | README: dotnet restore | Abschnitt „Pakete wiederherstellen“ in README.md ergänzt |
| 5 | 2026-10-21 | 12:04 | Fehler in MongoDbService | Syntaxfehler in Zeile 10 erklärt (keine Codeänderung) |
| 6 | 2026-10-21 | 12:06 | MongoDbService korrigiert | Zeile 10 zur Property `public IMongoDatabase Database { get; }` korrigiert |
| 7 | 2026-10-21 | 17:48 | .NET-Version aktualisieren | Nutzer hat bestätigt, bei .NET 10 zu bleiben, da .NET 11 derzeit nur als Preview verfügbar ist. |
| 8 | 2026-10-22 | 11:51 | PlaceDTO Vorschlag | Vorschlag für ein MongoDB-unabhängiges PlaceDto (kein Code, nur Konzept) |
| 9 | 2026-10-22 | 11:55 | PlaceDto umsetzen | PlaceDto angelegt, Mapping im PlaceService, Controller liefert PlaceDto |
| 10 | 2026-10-22 | 12:00 | PlaceDto in Ordner Dto | PlaceDto nach Dto/ verschoben, Namespace CityExplorer.Api.Dto, Usings ergänzt |
| 11 | 2026-10-22 | 12:10 | Controller ergänzen | PlacesController um GetById, Category, Nearby und Create erweitert |
| 12 | 2026-10-22 | 12:20 | Frontend erstellen | Frontend (HTML/CSS/JS) unter frontend/ angelegt, CORS im Backend aktiviert |

## Vorlage für neue Einträge

```markdown
## <Nr>. <Thema>

**Datum:** <JJJJ-MM-TT>, <HH:MM> Uhr

**Ziel:** <Was soll erreicht werden?>

**Prompt:**

(Prompt-Text im Codeblock)

**Ergebnis:** <Was wurde geändert oder erstellt?>
```

## 1. Beispieldaten places.json

**Datum:** 2026-10-20, – Uhr

**Ziel:** 50 plausible Beispieldatensätze für Orte im Ordner example-data erzeugen.

**Prompt:**

```
erzeuge im ordner example-data eine datei places.json mit plausiblen daten in dieser form: (Beispiel Volkspark Friedrichshain) – 50 Datensätze
```

**Ergebnis:** `example-data/places.json` mit 50 Berliner Orten (Parks, Museen, Märkte, Gastronomie u. a.) als JSON-Array erstellt.

## 2. MongoDB-Modellklassen

**Datum:** 2026-10-20, – Uhr

**Ziel:** Passende Modellklassen für MongoDB im Ordner Model erzeugen.

**Prompt:**

```
generiere mir im ordner Model die passenden Modelklassen für MongoDB
```

**Ergebnis:** `backend/Model/Places.cs` (Klasse `Place` mit GeoJSON-Point, Tags, Rating, optionalen `properties`) und `backend/Model/Address.cs` (Klasse `Address`) erstellt.

## 3. Fehlende Uhrzeit in prompts.md

**Datum:** 2026-10-20, 15:38 Uhr

**Ziel:** Klären, warum in den Einträgen keine Uhrzeit steht, und diesen Prompt mit echter Uhrzeit eintragen.

**Prompt:**

```
Warum gibt es keine Uhrzeit in der Prompts-MD?
```

```
ja
```

**Ergebnis:** Ursache erklärt (Uhrzeit wurde nicht abgefragt, nur Platzhalter gesetzt). Eintrag 3 mit per `Get-Date` ermittelter Uhrzeit ergänzt; Einträge 1 und 2 bleiben ohne Uhrzeit, da diese unbekannt ist.

## 4. README: dotnet restore

**Datum:** 2026-10-20, 15:50 Uhr

**Ziel:** Die README um die Information zu `dotnet restore` ergänzen.

**Prompt:**

```
Ergänze die readme.md um die wichtigen INformation:dotnet restore lädt die NuGet-Pakete herunter, die dein Projekt laut .csproj benötigt.
```

**Ergebnis:** In `README.md` den Abschnitt „Pakete wiederherstellen“ mit Erklärung und Befehl `dotnet restore` ergänzt.

## 5. Fehler in MongoDbService

**Datum:** 2026-10-21, 12:04 Uhr

**Ziel:** Herausfinden, was in `MongoDbService` nicht stimmt.

**Prompt:**

```
was stimmt nicht MongoDbService?
```

**Ergebnis:** Zeile 10 mischt Feld- und Property-Syntax und ist ungültig; Lösungsvorschlag erklärt, Code nicht geändert.

## 6. MongoDbService korrigiert

**Datum:** 2026-10-21, 12:06 Uhr

**Ziel:** Den Syntaxfehler in `MongoDbService` beheben.

**Prompt:**

```
passe es an
```

**Ergebnis:** In `MongoDbService.cs` Zeile 10 durch die Property `public IMongoDatabase Database { get; }` ersetzt.

## 7. .NET-Version aktualisieren

**Datum:** 2026-10-21, 17:48 Uhr

**Ziel:** Das Projekt auf eine neuere .NET-Version aktualisieren.

**Prompt:**

```
Upgrade to a newer version of .NET
```

**Ergebnis:** Das Backend bleibt auf `net10.0`. Der Nutzer hat das Upgrade abgelehnt, da `net11.0` derzeit nur als Preview-Version und nicht für Produktion empfohlen ist.

## 8. PlaceDTO Vorschlag

**Datum:** 2026-10-22, 11:51 Uhr

**Ziel:** Vorschlag für ein PlaceDTO, damit die API unabhängig von MongoDB-Typen wird (noch kein Code).

**Prompt:**

```
generiere ein PlaceDTO , um unabhängig von MongoDB-Typen zu sein. erstmal nur vorschlag, kein code
```

**Ergebnis:** Vorschlag mit `PlaceDto` (Id, Name, Category, Latitude, Longitude, Address, Tags, Rating), manuellem Mapping im `PlaceService` und angepasstem Controller. Keine Codeänderung.

## 9. PlaceDto umsetzen

**Datum:** 2026-10-22, 11:55 Uhr

**Ziel:** Den Vorschlag für das PlaceDto umsetzen.

**Prompt:**

```
umsetzen
```

**Ergebnis:** `Model/PlaceDto.cs` neu angelegt (flache Adresse, Latitude/Longitude). `PlaceService` mappt per `ToDto` und gibt `List<PlaceDto>` zurück, `PlacesController` angepasst. Nicht gebaut oder getestet.

## 10. PlaceDto in Ordner Dto

**Datum:** 2026-10-22, 12:00 Uhr

**Ziel:** `PlaceDto` in einen eigenen Ordner `Dto` verschieben.

**Prompt:**

```
bitte move to Ordner Dto
```

**Ergebnis:** `PlaceDto.cs` von `Model/` nach `Dto/` verschoben, Namespace auf `CityExplorer.Api.Dto` geändert, `using` in `PlaceService` und `PlacesController` ergänzt. Nicht gebaut oder getestet.

## 11. Controller ergänzen

**Datum:** 2026-10-22, 12:10 Uhr

**Ziel:** Den `PlacesController` um die fehlenden Methoden des `PlaceService` ergänzen.

**Prompt:**

```
ergänze den Controller um die fehlenden Methoden.
```

**Ergebnis:** `PlacesController` um `GET places/{id}`, `GET places/category/{category}`, `GET places/nearby` und `POST places` erweitert. Nicht gebaut oder getestet.

## 12. Frontend erstellen

**Datum:** 2026-10-22, 12:20 Uhr

**Ziel:** Ein einfaches Frontend im Ordner `frontend` erzeugen.

**Prompt:**

```
generiere unter dem Ordner frontend ein Frontend.
```

**Ergebnis:** `frontend/index.html`, `style.css` und `app.js` (reines HTML/CSS/JavaScript) erstellt: Orteliste als Karten, Textsuche, Kategorie-Filter, Umkreissuche mit Standort-Button. In `Program.cs` CORS aktiviert, damit das Frontend die API aufrufen kann. Nicht gebaut oder getestet.

## 13. Frontend im .NET-Server ausliefern

**Datum:** 2026-10-22, 12:30 Uhr

**Ziel:** Das Frontend soll im gleichen .NET-HTTP-Server laufen wie die API.

**Prompt:**

```
das frontend soll im gleichen .net http server laufen
```

**Ergebnis:** In `Program.cs` wird der Ordner `frontend` per `PhysicalFileProvider` mit `UseDefaultFiles` und `UseStaticFiles` ausgeliefert. `API_URL` in `app.js` auf den relativen Pfad `/places` geändert. Aufruf über `http://localhost:5180`. Nicht gebaut oder getestet.

## 14. Frontend mit Karte (OpenStreetMap + Leaflet)

**Datum:** 2026-10-22, 12:45 Uhr

**Ziel:** Das Frontend um eine Karte mit OpenStreetMap und Leaflet erweitern.

**Prompt:**

```
bitte frontend mit karte, openstreetmap + leaflet
```

**Ergebnis:** Leaflet 1.9.4 per CDN (unpkg) in `index.html` eingebunden, Kartencontainer über der Orteliste. `app.js`: OSM-Kacheln, ein Marker mit Popup pro gefundenem Ort (Karte passt den Ausschnitt an), Klick auf eine Karte zoomt zum Ort, Klick auf die Karte setzt die Position für die Umkreissuche. Der alte „Auf Karte anzeigen“-Link entfällt. `style.css` ergänzt. Nicht gebaut oder getestet.
