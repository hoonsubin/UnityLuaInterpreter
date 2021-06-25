using UnityEngine;
using MoonSharp.Interpreter;

public class RunLuaScript : MonoBehaviour
{
    public TextAsset scriptToRun;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log(MoonSharpFactorial());
    }

    double MoonSharpFactorial()
    {
        if (scriptToRun == null)
        {
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
            Debug.Log("runnig from " + scriptToRun.name);
            // should return 120 = 5 * 4 * 3 * 2
            DynValue res = Script.RunString(scriptToRun.text);
            return res.Number;
        }

    }
}
