# Prompts

Sammlung der verwendeten Claude-Prompts im Projekt City Explorer.

## Übersicht

| Nr. | Datum | Uhrzeit | Thema | Ergebnis |
|-----|-------|---------|-------|----------|
| 1 | 2026-10-20 | – | Beispieldaten places.json | 50 Orte in Berlin unter example-data/places.json erstellt |
| 2 | 2026-10-20 | – | MongoDB-Modellklassen | Place und Address im Ordner backend/Model erstellt |

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
