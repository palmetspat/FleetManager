# POSE 5ABIF/5ACIF

## Flottenmanager

Lehrziele

- Einfache Vererbung
- Verwendung abstrakter Klassen 
- Verketten von Konstruktoren
- Überschreiben von Methoden
- Verwenden von generischen Listen
- Sortieren von Listenelementen

### Aufgabenstellung

Implementieren Sie eine einfache Fahrzeugflottenverwaltung. Eine Flotte besteht aus verschiedenen Fahrzeugtypen, darunter Personenfahrzeuge (PassengerVehicle) und Transportfahrzeuge (CargoVehicle). Die Fahrzeugtypen sollten durch Vererbung sauber objektorientiert umgesetzt werden.

Sie benötigen die Klassen Vehicle, PassengerVehicle, CargoVehicle und Fleet.

**Klasse `Vehicle`:**

Diese abstrakte Klasse dient als Basisklasse für `PassengerVehicle` und `CargoVehicle`.

**Private Felder und jeweils readonly Properties:**

- `baseWeight (Double)`: Leergewicht des Fahrzeugs in [kg].
- `vehicleID (String)`: Eindeutige ID des Fahrzeugs.

**Konstruktor:**

Akzeptiert die Werte für `vehicleID` und `baseWeight` und setzt die entsprechenden Felder.

**Gültigkeitsprüfung der vehicleID:**

Die ID besteht aus 10 alphanumerische Zeichen. Der Aufbau ist durch folgende Regeln definniert:

Man multipliziere die erste Ziffer mit eins, die zweite mit zwei, die dritte mit drei und so fort bis zur neunten Ziffer, die mit neun multipliziert wird. Man addiere die Produkte und teile die Summe ganzzahlig mit Rest durch 11. Der Divisionsrest ist die Prüfziffer. Falls der Rest 10 beträgt, ist die Prüfziffer ein "X". 

1. **Beispiel:** ID 349913599[?] 
3·1 + 4·2 + 9·3 + 9·4 + 1·5 + 3·6 + 5·7 + 9·8 + 9·9 = 3 + 8 + 27 + 36 + 5 + 18 + 35 + 72 + 81 = 285 
285:11 = 25 Rest 10 ⇒ Prüfziffer: X 

2. **Beispiel:** ID 344619313[?]
3·1 + 4·2 + 4·3 + 6·4 + 1·5 + 9·6 + 3·7 + 1·8 + 3·9 = 3 + 8 + 12 + 24 + 5 + 54 + 21 + 8 + 27 = 162 
162:11 = 14 Rest 8 ⇒ Prüfziffer: 8 

3. **Beispiel:** ID 074755100[?]
0·1 + 7·2 + 4·3 + 7·4 + 5·5 + 5·6 + 1·7 + 0·8 + 0·9 = 14 + 12 + 28 + 25 + 30 + 7 = 116 
116:11 = 10 Rest 6 ⇒ Prüfziffer: 6 

4. **Beispiel:** ID 157231422[?]
1·1 + 5·2 + 7·3 + 2·4 + 3·5 + 1·6 + 4·7 + 2·8 + 2·9 = 1 + 10 + 21 + 8 + 15 + 6 + 28 + 16 + 18 = 123 
123:11 = 11 Rest 2 ⇒ Prüfziffer: 2

Wenn die übergebene ID ungültig ist, wird vehicleID auf "0000000000" gesetzt. Die Prüfung der Id erfolgt mit der statischen Methode `CheckId(string id)`.

**Methoden:**

- `static bool CheckId(string id)`: Prüft die `id` nach den angegebenen Regeln.
- `abstract double GetRevenue()`: Gibt den Umsatz des Fahrzeugs zurück. Diese Methode wird von den abgeleiteten Klassen implementiert.
- `abstract double GetTotalWeight()`: Gibt das Gesamtgewicht des Fahrzeugs zurück (Leergewicht + Ladung/Passagiere).

**Klasse `PassengerVehicle`:**

Diese Klasse erbt von Vehicle.

**Private Felder und Properties (read/write):**

- `passengerCount (Integer)`: Anzahl der Passagiere im Fahrzeug.
- `ticketPrice (Double)`: Umsatz pro Passagier.

**Konstruktor:**

Akzeptiert Werte für `vehicleID`, `baseWeight` in [kg], `passengerCount` und `ticketPrice`.
Maximal erlaubte Passagieranzahl beträgt 50. Wenn mehr Passagiere hinzugefügt werden, wird der Wert auf 50 korrigiert. Wrid keine Passagieranzahl angegeben, dann wird der Standadwert 20 vergeben.

**Methoden:**

- `override double GetRevenue()`: Gibt den Gesamtumsatz des Fahrzeugs zurück (Passagieranzahl * Ticketpreis).
- `override double GetTotalWeight()`: Gibt das Gesamtgewicht in [kg] zurück (baseWeight + (passengerCount * 70)).
- `override string ToString()`: Gibt die Information des Objektes in folgendem Format zurück (PassengerVehicle ID Gesamtgewicht Gesamtumsatz)

**Hinweis:** Erweitere die dazugehörige Test-Klasse um einen Test im Abschnitt '// Add a useful test to the test'. 

**Klasse `CargoVehicle`:**

Diese Klasse erbt von Vehicle.

**Private Felder und Properties (read/write):**

- `cargoWeight (Double)`: Gewicht der transportierten Fracht (in Tonnen).
- `ratePerTon (Double)`: Umsatz pro Tonne Fracht.

**Konstruktor:**

Akzeptiert Werte für `vehicleID`, `baseWeight` in [kg], `cargoWeight in [t]` und `ratePerTon` in [EUR/t]. Maximale Frachtkapazität beträgt 20 Tonnen. Überschreitungen werden automatisch auf 20 korrigiert.

**Methoden:**

- `override double GetRevenue()`: Gibt den Gesamtumsatz des Fahrzeugs zurück (cargoWeight * ratePerTon).
- `override double GetTotalWeight()`: Gibt das Gesamtgewicht in [kg] zurück (baseWeight + cargoWeight // Achtung: Einheiten).
- `override string ToString()`: Gibt die Information des Objektes in folgendem Format zurück (CargorVehicle ID Gesamtgewicht Gesamtumsatz)

**Hinweis:** Erweitere die dazugehörige Test-Klasse um einen Test im Abschnitt '// Add a useful test to the test'. 

**Klasse `Fleet`:**

Verwalten Sie eine Liste von Fahrzeugen.

**Private Felder:**

- `List<Vehicle> vehicleList`: Eine Liste, die alle Fahrzeuge in der Flotte enthält.
- `double maxFleetWeight`: Das maximale zulässige Gesamtgewicht der Flotte.

Konstruktor:

Akzeptiert den Wert für maxFleetWeight.

**Properties:**

- `IReadOnlyList<Vehicle> Vehicles`: Gibt die Liste der Fahrzeuge zurück.
- `double MaxFleetWeight`: Gibt das maximal zulässige Gesamtgewicht der Flotte zurück.
- `int PassengerVehicleCount`: Gibt die Anzahl der Personenfahrzeuge in der Flotte zurück.

**Methoden:**

- `double GetFleetWeight()`: Berechnet das Gesamtgewicht der Flotte.
- `Vehicle? GetMostProfitableVehicle()`: Gibt das Fahrzeug mit dem höchsten Umsatz zurück oder null, wenn keine Fahrzeuge vorhanden sind.
- `int GetTotalPassengerCount()`: Gibt die Gesamtanzahl der Passagiere in der Flotte zurück.
- `bool AddVehicle(Vehicle newVehicle)`: Fügt ein neues Fahrzeug der Flotte hinzu, sofern das maximale Flottengesamtgewicht nicht überschritten wird.
    - Die Fahrzeuge sollen nach Gesamtgewicht absteigend sortiert werden.
- `bool AddPassengersToVehicle(string vehicleID, int additionalPassengers)`: Fügt Passagiere zu einem bestimmten Personenfahrzeug hinzu, sofern die Passagier- und Gewichtsbeschränkungen eingehalten werden.
- `IReadOnlyList<Vehicle> GetByRevenue()`: Gibt eine Liste von `Vehicle` sortiert nach Gesamtumsatz zurück (erstes Element größter Umsatz). 
- `override string ToString()`: Gibt die Informationen in einer Liste aus (jeder Eintrag eine Zeile)

**Hinweis:** Erweitere die dazugehörige Test-Klasse um einen Test im Abschnitt '// Add a useful test to the test'. 

**Beispiel:**

- Ein Personenfahrzeug mit 30 Passagieren und einem Ticketpreis von 10 Euro erzeugt einen Umsatz von 300 Euro und wiegt 2 Tonnen (Leergewicht) + 30 × 70 kg = 4,1 Tonnen.
- Ein Transportfahrzeug mit 15 Tonnen Fracht und einer Rate von 50 Euro pro Tonne erzeugt einen Umsatz von 750 Euro und wiegt 3 Tonnen (Leergewicht) + 15 Tonnen = 18 Tonnen.

