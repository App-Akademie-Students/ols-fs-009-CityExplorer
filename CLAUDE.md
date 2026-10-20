# CLAUDE.md

## Projekt

City Explorer

Eine kleine Fullstack-Anwendung mit:

- C#
- ASP.NET Core
- MongoDB
- HTML / CSS / JavaScript 

## Ziel

Benutzer sollen Orte in einer Stadt suchen können.

Ein Ort kann unter anderem enthalten:

- Name
- Kategorie
- geografische Position
- Adresse
- Tags
- Bewertung
- zusätzliche Eigenschaften

MongoDB wird verwendet, um die Orte als Dokumente zu speichern und geografische Abfragen durchzuführen.

## Arbeitsweise

- Die Implementierung soll einfach und gut nachvollziehbar bleiben.
- Änderungen möglichst klein und schrittweise durchführen.
- Keine unnötigen Frameworks oder Abstraktionen einführen.
- Den offiziellen MongoDB C# Driver verwenden.
- Kein Entity Framework verwenden.
- Größere Architekturentscheidungen vor der Umsetzung kurz erklären.
- Tests nur erstellen, wenn ausdrücklich angefordert.
- Tests nur ausführen, wenn ausdrücklich angefordert.
- Keine fachfremden oder unnötigen Änderungen durchführen.
- Die Datei `docs/prompts.md` bei jedem neuen Prompt aktualisieren (Eintrag mit Datum, Uhrzeit, Ziel, Prompt und Ergebnis, Vorlage siehe Datei).