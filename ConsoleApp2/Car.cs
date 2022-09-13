namespace Klassenaufgabe
{
    public class Car
    {
        //readonly, kommt nur vom konstruktor und soll und darf danach nicht mehr veraendert werden.
        readonly float _maxFuelQuantity;
        readonly float _consumption;

        //(private) klassenvariablen, mit denen gearbeitet wird.
        int _mileage;
        float _fillLevel;
        bool _readyToDrive;

        /// <summary>
        /// Default Konstruktor. Erstellt ein neues Auto.
        /// </summary>
        public Car()
        {
        }

        /// <summary>
        /// Erstellt ein neues Auto mit vorgegebenem Tankvolumen (mit vollem Tank) und vorgegebenem Verbrauch
        /// </summary>
        /// <param name="maxFuelQuantity">Kraftstoffmenge, welche in das Auto initial getankt werden soll.</param>
        /// <param name="consumption">Verbrauch des Autos je 10km</param>
        public Car(int maxFuelQuantity, int consumption)
        {
            //neues auto -> 0 km.
            _mileage = 0;
            _maxFuelQuantity = maxFuelQuantity;

            //annahme: tank voll bei erstellen des autos.
            _fillLevel = _maxFuelQuantity;
            _consumption = consumption;

            //fahrbereit ist das auto nur, wenn verbrauch und maxKraftstoffmenge auf werte >0 gesetzt sind.
            _readyToDrive = maxFuelQuantity > 0 && consumption > 0;
        }

        /// <summary>
        /// Fahren. Macht alles was es braucht, damit ein Auto faehrt.
        /// </summary>
        /// <param name="distance">Distanz, welche gefahren werden soll.</param>
        public void Drive(int distance)
        {
            Console.WriteLine($"Das Auto soll {distance} km fahren.");

            //initiale pruefung. kann das auto ueberhaupt fahren (tank nicht leer etc?)
            if (!_readyToDrive)
            {
                Console.WriteLine("Auto ist nicht fahrbereit!");
                return;
            }

            //lokale variable zum merken, wie viel km der distanz schon gefahren wurden.
            int drivenKm = 0;

            //schleife, welche die distanz farhrt. intervall wie vorgegeben
            while (drivenKm < distance)
            {
                //wie viele km sind wir von der distanz schon gefahren?
                drivenKm++;

                //gesamt-km stand erhoehen
                _mileage++;

                //alle 10km wird die Kraftstoffmenge um den Verbrauch des Autos reduziert (unt ein paar tests durchgefuehrt)
                if (_mileage % 10 == 0)
                {
                    _fillLevel -= _consumption;

                    //falls mal negative tankvolumen auftreten sollten ...
                    if (_fillLevel < 0) _fillLevel = 0;

                    //wenn nur noch 1/6 der maximalen menge sprit im tank ist, soll eine warnung ausgegeben werden
                    if (_fillLevel <= _maxFuelQuantity / 6 && _fillLevel > 0)
                    {
                        Console.WriteLine($"ACHTUNG! Nicht mehr viel Sprit im Tank! ({_fillLevel} liter)");
                    }

                    //wenn tank leer, dann nix mehr fahren. 
                    if (_fillLevel <= 0)
                    {
                        _readyToDrive = false;
                        Console.WriteLine($"Sprit leer nach {drivenKm} km.");
                        break;
                    }
                }

                //automatischer statusbericht alle 150km.
                if (_mileage % 150 == 0)
                {
                    Console.Write("Automatischer ");
                    Status();
                }

                //bei mehr als 1500km ist der motor kaputt. Das auto ist dann nicht mehr fahrbereit.
                if (_mileage >= 1500)
                {
                    Console.WriteLine("Motor kaputt.");
                    _readyToDrive = false;
                    break;
                }
            }

            Console.WriteLine($"Das Auto ist {drivenKm} km gefahren.");
            Console.WriteLine($"Das Auto hat jetzt einen Kilometerstand von {_mileage} km.");
        }

        /// <summary>
        /// Erstellt einen Statusbericht
        /// </summary>
        public void Status()
        {
            //einfacher statusbericht. kann wohl noch erweitert werden?
            Console.WriteLine($"Statusbericht: Das Auto hat einen Kilometerstand von {_mileage} km und es sind {_fillLevel} liter im Tank. Es ist{(_readyToDrive ? "" : " nicht mehr")} fahrbereit.");
        }

        /// <summary>
        /// Tankt das Auto voll. 
        /// </summary>
        public void Refuel()
        {
            Console.WriteLine($"Es werden {_maxFuelQuantity - _fillLevel}l getankt.");

            //der einfachheit halber wird die kraftstoffmenge auf die maximal moegliche menge gesetzt.
            _fillLevel = _maxFuelQuantity;

            Console.WriteLine($"Es sind jetzt wieder {_fillLevel} liter im Tank.");

            //das auto ist fahrbereit, wenn sprit im tank ist.
            _readyToDrive = _fillLevel > 0;
        }

        /// <summary>
        /// Tauscht den Motor des Autos. Neuer Motor = Kilometerstand 0.
        /// </summary>
        public void TauscheMotor()
        {
            Console.WriteLine("Neuer Motor wird eingebaut. Der Kilometerstand wird daher zurueckgesetzt.");

            //neuer motor -> das auto ist wieder fahrbereit. der kilometerstand des neuen motors betraegt 0km.
            _readyToDrive = true;
            _mileage = 0;
        }
    }
}