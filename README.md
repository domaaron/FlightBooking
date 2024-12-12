# FlightBooking :airplane:
> FlightBooking is a database for managing flight bookings. It allows passengers to create multiple bookings for different flights. Created bookings are submitted and validated before they are approved.
>
>FlightBooking ist eine Datenbank zur Verwaltung von Flugbuchungen. Sie ermöglicht es Passagieren, mehrere Buchungen für verschiedene Flüge zu erstellen.

FlightBooking was developed in C# .NET Core as part of the Programming and Software Engineering module.

## Aufgabenstellung
**Mindestanforderungen:**
- Mindestens 8 Modelklassen, wobei zwischen mindestens 2 Modelklassen eine Vererbung mit einem Discriminator implementiert sein muss.
- Umsetzung von Value Objects und von Properties für die Fremdschlüsselfelder.
- Zwei Modelkassen sind jeweils ein Aggregate mit einer Readonly Collection und einem Backing Field.
- Auf dem Aggregate sind eine Methode zum Hinzufügen von Instanzen einer anderen Modelklasse und eine Methode zum Umwandeln eines Objektes innerhalb der Vererbungskette implementiert (siehe Methoden TryHandIn() und ReviewHandIn() von der Übung RichDomainModels als Beispiele).
- Es sind weitere 5 Methoden bzw. Properties mit einer entsprechenden Funktionalität implementiert (siehe Methoden GetActiveTasks() bzw. CalculateAveragePoints() von der Übung RichDomainModels als Beispiele).
- Das Erstellen der Datenbank entsprechend den Modelkassen ist als Testfall implementiert.
Für jede Methode ist ein eigener Success Test in einem XUnit Testprojekt umgesetzt.
    
**Erweiterungsmöglichkeiten für eine bessere Beurteilung:**
- Umsetzung von beidseitigen Naviations.
- Zusätzliche Modelkassen bzw. Methoden mit entsprechenden Funktionalitäten sind implementiert.
- Die Datenbank wird mit den in den Modelklassen enthaltenen Datentypdefinitionen erstellt und mit passenden Testdaten befüllt.
- GUID Werte werden als Alternate Keys verwendet.
- Umsetzung von Lazy Loading.
- Zusätzliche XUnit Testfälle sind implementiert.

## PlantUML-Modell
![plantUML_model](https://user-images.githubusercontent.com/119418922/214629572-5b2bc688-19bc-4811-9915-452dceb91ab0.png)

## Entity-Relationship-Modell
![ER_modell](https://user-images.githubusercontent.com/119418922/214035652-fe162da6-6621-480f-9d22-9fede467e9ae.PNG)

