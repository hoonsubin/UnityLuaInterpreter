using UnityEngine;
using MoonSharp.Interpreter;

namespace ExampleScript
{
    public class Car
    {
        public string Name { get; private set; }
        public float MaxSpeed { get; private set; }

        public Car(string name, float maxSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
        }

        public void RunAtSpeed(float speed)
        {
            if (!IsAboveMaxSpeed(speed))
            {
                Debug.Log($"{Name} is running at speed of {speed}");
            }
            else
            {
                Debug.Log($"{Name} cannot go above the max speed of {MaxSpeed}");
            }
            
        }

        public bool IsAboveMaxSpeed(float speed)
        {
            return speed > MaxSpeed;
        }
    }

    public class HypotehitcalCarComponent : MonoBehaviour
    {
        public TextAsset CarScriptedBehavior;

        private Script _behaviorScript;

        private Car _myCar;

        // Start is called before the first frame update
        private void Start()
        {
            _myCar = new Car("Model Y", 70.5f);

            RegisterScriptGlobals();

        }

        private void Update()
        {
            // press `Space` key to call the script
            if (Input.GetButtonDown("Jump"))
            {
                CallScriptedBehavior();
            }
        }

        private void RegisterScriptGlobals()
        {
            // allow the script to access the `Car` class
            UserData.RegisterType<Car>();

            // run from script
            _behaviorScript = new Script();

            DynValue car = UserData.Create(_myCar);

            // assign the global variable `car` as the instance of `car` defined in this component
            _behaviorScript.Globals.Set("car", car);

        }

        private void CallScriptedBehavior()
        {
            // load script and the function in to memory. Call it if it's not wrapped in a function
            _behaviorScript.DoString(CarScriptedBehavior.text);
        }

    }
}

