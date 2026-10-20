# Prompts

Sammlung der verwendeten Claude-Prompts im Projekt City Explorer.

## Übersicht

| Nr. | Datum | Uhrzeit | Thema | Ergebnis |
|-----|-------|---------|-------|----------|
| 1 | 2026-10-20 | – | Beispieldaten places.json | 50 Orte in Berlin unter example-data/places.json erstellt |
| 2 | 2026-10-20 | – | MongoDB-Modellklassen | Place und Address im Ordner backend/Model erstellt |
| 3 | 2026-10-20 | 15:38 | Fehlende Uhrzeit in prompts.md | Ursache erklärt, Eintrag mit echter Uhrzeit ergänzt |
| 4 | 2026-10-20 | 15:50 | README: dotnet restore | Abschnitt „Pakete wiederherstellen“ in README.md ergänzt |

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
