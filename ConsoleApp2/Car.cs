namespace ClassExercise
{
    public class Car
    {
        //readonly, comes only from the constructor and should not and must not be changed afterwards.
        readonly float _maxFuelQuantity;
        readonly float _consumption;

        //(private) class variables to work with.
        int _mileage;
        float _fillLevel;
        bool _readyToDrive;

        /// <summary>
        /// Default constructor. Creates a new car.
        /// </summary>
        public Car()
        {
        }

        /// <summary>
        /// Creates a new car with given tank volume (with full tank) and given consumption.
        /// </summary>
        /// <param name="maxFuelQuantity">Amount of fuel to be initially filled into the car.</param>
        /// <param name="consumption">Consumption of the car per 10km</param>
        public Car(int maxFuelQuantity, int consumption)
        {
            //new car -> 0 km.
            _mileage = 0;
            _maxFuelQuantity = maxFuelQuantity;

            //assumption: tank full when creating the car.
            _fillLevel = _maxFuelQuantity;
            _consumption = consumption;

            //the car is only ready to drive if fuel consumption and max fuel quantity are set to values >0.
            _readyToDrive = maxFuelQuantity > 0 && consumption > 0;
        }

        /// <summary>
        /// Driving. Does everything it takes to make a car drive.
        /// </summary>
        /// <param name="distance">Distance to be driven.</param>
        public void Drive(int distance)
        {
            Console.WriteLine($"Das Auto soll {distance} km fahren.");

            //initial check. can the car drive at all (tank not empty etc.)?
            if (!_readyToDrive)
            {
                Console.WriteLine("Auto ist nicht fahrbereit!");
                return;
            }

            //local variable to remember how many km of the distance have already been driven.
            int drivenKm = 0;

            //loop which travels the distance. interval 1km.
            while (drivenKm < distance)
            {
                //How many kilometers have we driven in terms of distance?
                drivenKm++;

                //total km level increase
                _mileage++;

                //every 10km the amount of fuel is reduced by the consumption of the car (and a few tests are performed).
                if (drivenKm % 10 == 0)
                {
                    _fillLevel -= _consumption;

                    //in case negative tank volumes should occur ...
                    if (_fillLevel < 0) _fillLevel = 0;

                    //when there is only 1/6 of the maximum amount of fuel left in the tank, a warning should be issued
                    if (_fillLevel <= _maxFuelQuantity / 6 && _fillLevel > 0)
                    {
                        Console.WriteLine($"ACHTUNG! Nicht mehr viel Sprit im Tank! ({_fillLevel} liter)");
                    }

                    //if the tank is empty, you can no longer drive.
                    if (_fillLevel <= 0)
                    {
                        _readyToDrive = false;
                        Console.WriteLine($"Sprit leer nach {drivenKm} km.");
                        break;
                    }
                }

                //automatic status report every 150km.
                if (_mileage % 150 == 0)
                {
                    //call method Status with the named parameter to better show why true is passed to the method.
                    Status(automatic: true);
                }

                //at more than 1500km the engine is broken. The car is then no longer ready to drive.
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
        /// Creates a status report
        /// </summary>
        public void Status(bool automatic = false)
        {
            //simple status report. can probably be extended?
            Console.WriteLine($"{(automatic ? "Automatischer " : "")}Statusbericht: Das Auto hat einen Kilometerstand von {_mileage} km und es sind {_fillLevel} liter im Tank. Es ist{(_readyToDrive ? "" : " nicht mehr")} fahrbereit.");
        }

        /// <summary>
        /// Fills up the car. 
        /// </summary>
        public void Refuel()
        {
            Console.WriteLine($"Es werden {_maxFuelQuantity - _fillLevel}l getankt.");

            //For simplicity, the fuel quantity is set to the maximum possible quantity.
            _fillLevel = _maxFuelQuantity;

            Console.WriteLine($"Es sind jetzt wieder {_fillLevel} liter im Tank.");

            //the car is ready to drive when there is fuel in the tank.
            _readyToDrive = _fillLevel > 0;
        }

        /// <summary>
        /// Replaces the engine of the car. New engine = mileage 0.
        /// </summary>
        public void ReplaceEngine()
        {
            Console.WriteLine("Neuer Motor wird eingebaut. Der Kilometerstand wird daher zurueckgesetzt.");

            //new engine -> the car is ready to drive again. the mileage of the new engine is 0km.
            _readyToDrive = true;
            _mileage = 0;
        }
    }
}