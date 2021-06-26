using UnityEngine;
using MoonSharp.Interpreter;

namespace UnityLuaInterpreter
{
    public class RunLuaScript : MonoBehaviour
    {
        public TextAsset ScriptToRun;

        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log(MoonSharpFactorial());
        }

        private double MoonSharpFactorial()
        {
            if (ScriptToRun == null)
            {
                // run from raw string
                string script = @"
			-- defines a factorial function
			function fact (n)
				if (n == 0) then
					return 1
				else
					return n*fact(n - 1)
				end
			end

			return fact(5)";
                // should return 120 = 5 * 4 * 3 * 2
                DynValue res = Script.RunString(script);
                return res.Number;
            }
            else
            {
                Debug.Log("runnig from " + ScriptToRun.name + " lua script");

                // run from script
                Script script = new Script();

                // load script to memory
                script.DoString(ScriptToRun.text);

                // call the `fact` function with the custom argument
                DynValue res = script.Call(script.Globals["fact"], 4);
                // return the number value of the result
                return res.Number;
            }

        }
    }
}

