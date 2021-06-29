using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyExe
{
    public class Functions : Dictionary<string, Function>
    {
        private static Functions defaultFunctions;

        private Context _context;

        public static Functions Defaults
        {
            get
            {
                if (defaultFunctions == null)
                {
                    defaultFunctions = new Functions();
                    defaultFunctions.InitDefaults();
                }
                return defaultFunctions;
            }
        }

        public Functions()
        {

        }

        public Functions(Context context)
        {
            _context = context;
        }

        public void InitDefaults()
        {


            this.Add("about", new StaticFunction("About", delegate(object[] ps) { return "@TinyExe - a Tiny Expression Evaluator v1.0 by Herre Kuijpers - Copyright © 2011 under the CPOL license. Adjusted and enhanced by Tsaukpaetra (2016)."; }, 0, 0, "Returns some about-me text for the interpreter."));
            this.Add("vardump", new StaticFunction("vardump", delegate(object[] ps)
            {
                string result = "Variables in scope:";
                foreach (KeyValuePair<string, object> entry in _context.CurrentScope)
                {
                    if (ps.Contains(entry.Key) || ps.Length == 0)
                        result += "\r\n" + entry.Key + ": " + entry.Value;
                }
                if (_context.CurrentScope.Count == 0)
                    result = "None";
                return result
                ;
            }, 0, int.MaxValue, "Dumps a list of all variables currently in scope."));
            this.Add("help", new StaticFunction("Help", Help, 0, 1, "Displays available functions. Passing True gives only Default functions, False gives only User-Defined (or application-Defined) functions, and a string will return specific details about a particular function."));

            // high precision functions
            this.Add("abs", new StaticFunction("Abs", delegate(object[] ps) {
                double result;
                if(double.TryParse(ps[0].ToString(), out result))
                    return Math.Abs(result);
                //Failed, give back nothing
                return null;
            }, 1, 1, "Returns the absolute value of Arg0, else null if not a number."));
            this.Add("ceiling", new StaticFunction("Ceiling", delegate(object[] ps) { 
                double result;
                if(double.TryParse(ps[0].ToString(), out result))
                    return Math.Ceiling(result);
                //Failed, give back nothing
                return null; 
            }, 1, 1, "Returns the Cleiling value of Arg0."));
            this.Add("floor", new StaticFunction("Floor", delegate(object[] ps) { 
                double result;
                if(double.TryParse(ps[0].ToString(), out result))
                    return Math.Floor(result);
                //Failed, give back nothing
                return null; 
            }, 1, 1, "Returns the Floor value of Arg0."));
            this.Add("exp", new StaticFunction("Exp", delegate(object[] ps) { return Math.Exp(Convert.ToDouble(ps[0])); }, 1, 1, "Returns e to the nth power."));
            this.Add("int", new StaticFunction("int", delegate(object[] ps) { return (int)Math.Floor(Convert.ToDouble(ps[0])); }, 1, 1, "Return the Integer value."));
            this.Add("fact", new StaticFunction("Fact", Fact, 1, 1, "Returns the factorial of a number.")); // factorials 1*2*3*4...
            this.Add("pow", new StaticFunction("Pow", delegate(object[] ps) { return Math.Pow(Convert.ToDouble(ps[0]), Convert.ToDouble(ps[1])); }, 2, 2, "Returns [0]^[1]"));
            this.Add("round", new StaticFunction("Round", delegate(object[] ps) { return Math.Round(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("log", new StaticFunction("Log", Log, 1, 2, "Returns log of [0] to base [1]. If [1] isn't specified, assumes base 10")); // log allows 1 or 2 parameters
            this.Add("ln", new StaticFunction("Ln", delegate(object[] ps) { return Math.Log(Convert.ToDouble(ps[0])); }, 1, 1, "Returns the natural log of [0]"));
            this.Add("sign", new StaticFunction("Sign", delegate(object[] ps) { return Math.Sign(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("sqr", new StaticFunction("Sqr", delegate(object[] ps) { return Convert.ToDouble(ps[0]) * Convert.ToDouble(ps[0]); }, 1, 1));
            this.Add("sqrt", new StaticFunction("Sqrt", delegate(object[] ps) { return Math.Sqrt(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("trunc", new StaticFunction("Trunc", delegate(object[] ps) { return Math.Truncate(Convert.ToDouble(ps[0])); }, 1, 1));

            //Trig
            /*
            this.Add("acos", new StaticFunction("Acos", delegate(object[] ps) { return Math.Acos(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("asin", new StaticFunction("Asin", delegate(object[] ps) { return Math.Asin(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("atan", new StaticFunction("Atan", delegate(object[] ps) { return Math.Atan(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("atan2", new StaticFunction("Atan2", delegate(object[] ps) { return Math.Atan2(Convert.ToDouble(ps[0]), Convert.ToDouble(ps[1])); }, 2, 2));
            this.Add("cos", new StaticFunction("Cos", delegate(object[] ps) { return Math.Cos(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("cosh", new StaticFunction("Cosh", delegate(object[] ps) { return Math.Cosh(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("sin", new StaticFunction("Sin", delegate(object[] ps) { return Math.Sin(Convert.ToDouble(ps[0])); }, 1, 1));
            this.Add("sinh", new StaticFunction("Sinh", delegate(object[] ps) { return Math.Sinh(Convert.ToDouble(ps[0])); }, 1, 1));
            */
            // array functions
            this.Add("avg", new StaticFunction("Avg", Avg, 1, int.MaxValue, "Returns the average over a list of numeric values"));
            this.Add("stdev", new StaticFunction("StDev", StDev, 1, int.MaxValue, "Returns the statistical standard deviation over a list of numeric values"));
            this.Add("var", new StaticFunction("Var", Var, 1, int.MaxValue, "Returns the statistical variance over a list of numeric values"));
            this.Add("max", new StaticFunction("Max", Max, 1, int.MaxValue, "Returns the max over a list of numeric values"));
            this.Add("median", new StaticFunction("Median", Median, 1, int.MaxValue, "Returns the median over a list of numeric values"));
            this.Add("min", new StaticFunction("Min", Min, 1, int.MaxValue, "Returns the min over a list of numeric values"));

            //boolean functions
            this.Add("not", new StaticFunction("Not", delegate(object[] ps) { return !Convert.ToBoolean(ps[0]); }, 1, 1, "Inverts a boolean statement"));
            //this.Add("if", new StaticFunction("If", delegate(object[] ps) { return Convert.ToBoolean(ps[0]) ? ps[1] : ps[2]; }, 3, 3));
            this.Add("if", new LazyStaticFunction("If", delegate (Lazy<object>[] ps) { return Convert.ToBoolean(ps[0].Value) ? ps[1].Value : ps[2].Value; }, 3, 3, "Evaluates the truthy-ness of the first parameter and executes the second or third expression depending on the result."));


            this.Add("and", new LazyStaticFunction("And", delegate(Lazy<object>[] ps)
            {
                bool result = true;
                foreach (Lazy<object> item in ps)
                {
                    bool tempBool = false;
                    if (!Boolean.TryParse(item.Value.ToString(), out tempBool))
                        //If the parameter isn't a boolean, fail and return null
                        return null;
                    result = result && tempBool;
                    //Check if we can break early
                    if (!result)
                        break;
                }
                return result;
            }, 1, int.MaxValue,"Performs a Boolean AND function across all passed parameters. If a parameter can't be interpreted as Boolean, returns null."));
            this.Add("or", new LazyStaticFunction("Or", delegate(Lazy<object>[] ps)
            {
                bool result = false;
                foreach (Lazy<object> item in ps)
                {
                    bool tempBool = false;
                    if (!Boolean.TryParse(item.Value.ToString(), out tempBool))
                        //If the parameter isn't a boolean, fail and return null
                        return null;
                    result = result || tempBool;
                    //Check if we can break early
                    if (result)
                        break;
                }
                return result;
            }, 1, int.MaxValue, "Performs a Boolean OR function across all passed parameters. If a parameter can't be interpreted as Boolean, returns null."));

            // string functions
            this.Add("left", new StaticFunction("Left", delegate(object[] ps)
            {

                int len = 0;
                string theString = ps[0].ToString();
                //Get the desired length
                if (!int.TryParse(ps[1].ToString(), out len))
                    return null;
                
                //Check for out-of-bounds length, and adjust
                if (Math.Abs(len) > theString.Length)
                    len = theString.Length;

                //If len is negative, take the length from the end
                if (len < 0)
                    len = theString.Length + len;

                return theString.Substring(0, len);
            }, 2, 2, "Takes the left-most Arg1 characters from Arg0. If a negative number is specified, takes the left characters to the end of the string minus the length specified."));

            this.Add("right", new StaticFunction("Right", delegate(object[] ps)
            {
                int len = 0;
                string theString = ps[0].ToString();
                //Get the desired length
                if (!int.TryParse(ps[1].ToString(), out len))
                    return null;

                //Check for out-of-bounds length, and adjust
                if (Math.Abs(len) > theString.Length)
                    len = theString.Length;

                //If len is negative, take the length from the beginning?
                if (len < 0)
                    len = theString.Length + len;

                return theString.Substring(theString.Length-len, len);

                //int len = Convert.ToInt32(ps[1]) < ps[0].ToString().Length ? Convert.ToInt32(ps[1]) : ps[0].ToString().Length;
                //return ps[0].ToString().Substring(ps[0].ToString().Length - len, len);
            }, 2, 2, "Returns the right-most Arg1 characters of Arg0."));

            this.Add("mid", new StaticFunction("Mid", delegate (object[] ps)
            {
                int idx = Convert.ToInt32(ps[1]) < ps[0].ToString().Length ? Convert.ToInt32(ps[1]) : ps[0].ToString().Length;
                int len = Convert.ToInt32(ps[2]) < ps[0].ToString().Length - idx ? Convert.ToInt32(ps[2]) : ps[0].ToString().Length - idx;
                return ps[0].ToString().Substring(idx, len);
            }, 3, 3, "Returns the substring of Arg0, starting at Arg1 (zero-indexed) and giving up to Arg2 characters."));
            this.Add("replace", new StaticFunction("Replace", delegate (object[] ps)
            {
                return ps[0].ToString().Replace(ps[1].ToString(), ps[2].ToString()); ;
            }, 3, 3, "Returns the string of Arg0, replacing Arg1 with Arg2."));

            this.Add("hex", new StaticFunction("Hex", delegate(object[] ps) {
                Int32 arg = 0;
                Int32.TryParse(ps[0].ToString(), out arg);
                return String.Format("0x{0:X}", arg); 
            }, 1, 1, "Return the hex-value of Arg0"));
            this.Add("format", new StaticFunction("Format", delegate(object[] ps) {
                return string.Format("{0:" + ps[0].ToString() + "}", ps[1]);
            }, 2, 2, "Format Arg1 according to format-string Arg0."));
            this.Add("len", new StaticFunction("Len", delegate(object[] ps) {
                if (ps[0] == null)
                    return -1.0;
                string result = ps[0].ToString();
                if (result == null)
                    return -1.0;
                return Convert.ToDouble(result.Length);
            }, 1, 1, "Returns the length of the argument (as a string)"));
            this.Add("lower", new StaticFunction("Lower", delegate(object[] ps) { return ps[0].ToString().ToLowerInvariant(); }, 1, 1, "Returns Arg0, all characters converted to their lowercase equivalent (if possible)."));
            this.Add("upper", new StaticFunction("Upper", delegate(object[] ps) { return ps[0].ToString().ToUpperInvariant(); }, 1, 1, "Returns Arg0, all characters converted to their uppercase equivalent (if possible)."));
            this.Add("val", new StaticFunction("Val", delegate(object[] ps) { return Convert.ToDouble(ps[0]); }, 1, 1, "Tries to convert Arg0 to a Double."));
            this.Add("unset", new StaticFunction("UnSet", delegate(object[] ps)
            {
                string key = ps[0].ToString();
                //We want this to affect the current scope above us (Unnecessary with the shouldPushPopScope set to false)
                //_context.PopScope();
                if (_context.CurrentScope.ContainsKey(key))
                    _context.CurrentScope.Remove(key);
                //_context.PushScope(_context.CurrentScope);
                return null;
            }, 1, 1, "Deletes a variable from the current scope.", false));
            //Move this to GUI
            //this.Add("clear", new ClearFunction());

        }

        /// <summary>
        /// calculates the average over a list of numeric values
        /// </summary>
        /// <param name="ps">list of numeric values</param>
        /// <returns>the average value</returns>
        private static object Avg(object[] ps)
        {
            double total = 0;
            foreach (object o in ps)
                total += Convert.ToDouble(o);

            return total / ps.Length;
        }

        /// <summary>
        /// calculates the median over a list of numeric values
        /// </summary>
        /// <param name="ps">list of numeric values</param>
        /// <returns>the median value</returns>
        private static object Median(object[] ps)
        {
            object[] ordered = ps.OrderBy(o => Convert.ToDouble(o)).ToArray();

            if (ordered.Length % 2 == 1)
                return ordered[ordered.Length / 2];
            else
                return (Convert.ToDouble(ordered[ordered.Length / 2]) + Convert.ToDouble(ordered[ordered.Length / 2 - 1])) / 2;
        }

        /// <summary>
        /// calculates the statistical variance over a list of numeric values
        /// </summary>
        /// <param name="ps">list of numeric values</param>
        /// <returns>the variance</returns>
        private static object Var(object[] ps)
        {
            double avg = Convert.ToDouble(Avg(ps));
            double total = 0;
            foreach (object o in ps)
                total += (Convert.ToDouble(o) - avg) * (Convert.ToDouble(o) - avg);

            return total / (ps.Length - 1);
        }

        /// <summary>
        /// calculates the statistical standard deviation over a list of numeric values
        /// </summary>
        /// <param name="ps">list of numeric values</param>
        /// <returns>the standard deviation</returns>
        private static object StDev(object[] ps)
        {
            double var = Convert.ToDouble(Var(ps));
            return Math.Sqrt(var);
        }

        /// <summary>
        /// generic Log implementation, allows 1 or 2 parameters
        /// </summary>
        /// <param name="ps">numeric values</param>
        /// <returns>Log of the value</returns>
        private static object Log(object[] ps)
        {
            if (ps.Length == 1)
                return Math.Log10(Convert.ToDouble(ps[0]));

            if (ps.Length == 2)
                return Math.Log(Convert.ToDouble(ps[0]), Convert.ToDouble(ps[1]));

            return null;
        }

        private static object Fact(object[] ps)
        {
            double total = 1;

            for (int i = Convert.ToInt32(ps[0]); i > 1; i--)
                total *= i;

            return total;
        }

        private static object Max(object[] ps)
        {
            double max = double.MinValue;

            foreach (object o in ps)
            {
                double val = Convert.ToDouble(o);
                if (val > max)
                    max = val;
            }
            return max;
        }

        private static object Min(object[] ps)
        {
            double min = double.MaxValue;

            foreach (object o in ps)
            {
                double val = Convert.ToDouble(o);
                if (val < min)
                    min = val;
            }
            return min;
        }

        private object Help(object[] ps)
        {
            StringBuilder help = new StringBuilder();
            if (ps.Count() > 0)
            {
                if (typeof(string) == ps[0].GetType())
                {
                    string funcName = ((string)ps[0]).ToLowerInvariant();
                    bool foundFunction = false;
                    //They must have passed in the name of a function,lets try to find it!
                    foreach (KeyValuePair<string, Function> item in this.Where(x => x.Key.ToLowerInvariant() == funcName))
                    {
                        foundFunction = true;
                        //Hash out the info for this function
                        help.Append(item.Value.Name).Append(" Can accept ");

                        //Check if we have a difference between number of parameters allowed
                        if (item.Value.MinParameters != item.Value.MaxParameters)
                        {
                            help.Append("between ")
                                .Append(item.Value.MinParameters)
                                .Append(" and ")
                                .Append(item.Value.MaxParameters)
                                .Append(" Parameters. ");
                        }
                        else
                        {
                            help.Append(item.Value.MaxParameters)
                                .Append(" Parameters. ");
                        }

                        //If we have help text, display that too
                        if (item.Value.HelpText.Length > 0)
                            help.Append(item.Value.HelpText);
                    }
                    if (!foundFunction)
                        help.Append("Function not found.");
                }
                else if (typeof(bool) == ps[0].GetType())
                {


                    help.AppendLine("Tiny Expression Evaluator can evaluate expression containing the following " + ((bool)ps[0] ? "Default" : "User-defined") + " functions:");


                    //If the user specified true, display a list of the default functions
                    if ((bool)ps[0] == true)
                    {
                        foreach (string key in Functions.Defaults.Keys.OrderBy(s => s).ToArray())
                        {
                            help.Append(Functions.Defaults[key].Name + " ");
                        }
                    }
                    else
                    {
                        //Programmatically added functions except Default ones
                        foreach (KeyValuePair<string, Function> item in
                            (from a in this
                             join b in Functions.Defaults
                             on a.Key equals b.Key
                             into defaults
                             from ud in defaults.DefaultIfEmpty()
                             where ud.Key == null
                             orderby a.Key
                             select a

                            )
                            )
                        {
                            help.Append(item.Key + " ");
                        }
                    }

                }
                else
                {
                    help.Append("Invalid parameter given. Try Help(\"Help\")");
                }


            }
            else
            {
                help.AppendLine("Tiny Expression Evaluator can evaluate expression containing the following functions:");
                //Programmatically added functions
                foreach (KeyValuePair<string, Function> item in this.OrderBy(s => s.Key))
                    help.Append(item.Key + " ");
            }

            return help.ToString();
        }

        DynamicFunction if2()
        {
            ParseNode nd;
            //nd.

            //DynamicFunction result = new DynamicFunction();

            return null;
        }
    }

}
