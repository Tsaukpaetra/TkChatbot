using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyExe
{
    public delegate object FunctionDelegate(object[] parameters);
    public delegate object LazyFunctionDelegate(Lazy<object>[] parameters);

    public abstract class Function
    {

        /// <summary>
        /// define the arguments of the dynamic function
        /// </summary>
        public Variables Arguments { get; protected set; } 

        /// <summary>
        /// name of the function
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// minimum number of allowed parameters (default = 0)
        /// </summary>
        public int MaxParameters { get; protected set; }

        /// <summary>
        /// maximum number of allowed parameters (default = 0)
        /// </summary>
        public int MinParameters { get; protected set; }

        /// <summary>
        /// Optional help text. Default is empty string
        /// </summary>
        public string HelpText { get; protected set; }

        /// <summary>
        /// Optional flag. Default true, if False does not push and pop the scope (i.e. variables allowed to be modified through function)
        /// </summary>
        public bool ShouldPushPopScope { get; protected set; }
        public abstract object Eval(object[] parameters, ParseTreeEvaluator tree);
        public abstract object Eval(Lazy<object>[] parameters, ParseTreeEvaluator tree);
        

    }

    public class DynamicFunction : Function
    {
        /// <summary>
        /// points to the RHS of the assignment of this function
        /// this branch will be evaluated each time this function is executed
        /// </summary>
        private ParseNode Node;

        /// <summary>
        /// the list of parameters must correspond the the required set of Arguments
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override object Eval(object[] parameters, ParseTreeEvaluator tree)
        {
            // create a new scope for the arguments
            Variables pars = Arguments.Clone();
            // now push a copy of the function arguments on the stack
            tree.Context.PushScope(pars);

            // assign the parameters to the current function scope variables            
            int i = 0;
            string[] keys = pars.Keys.ToArray();

            foreach (string key in keys)
                pars[key] = parameters[i++];
            
            // execute the function here
            
            object result = Node.Eval(tree, null);

            // clean up the stack
            tree.Context.PopScope();

            return result;
        }

        /// <summary>
        /// the list of parameters must correspond the the required set of Arguments
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override object Eval(Lazy<object>[] parameters, ParseTreeEvaluator tree)
        {

            // create a new scope for the arguments
            Variables pars = Arguments.Clone();
            // now push a copy of the function arguments on the stack
            tree.Context.PushScope(pars);

            // assign the parameters to the current function scope variables            
            int i = 0;
            string[] keys = pars.Keys.ToArray();

            foreach (string key in keys)
            {
                pars[key] = parameters[i++].Value;
            }
                

            // execute the function here

            object result = Node.Eval(tree, null);

            // clean up the stack
            tree.Context.PopScope();

            return result;
        }
        public DynamicFunction(string name, ParseNode node, Variables args, int minParameters = 0, int maxParameters = 0, string helpText = "", bool shouldPushPopScope = true)
        {
            Node = node;
            Arguments = args;
            MinParameters = minParameters;
            MaxParameters = maxParameters;
            ShouldPushPopScope = shouldPushPopScope;
            HelpText = helpText;
            
        }
    }

    public class StaticFunction : Function
    {
        /// <summary>
        /// the actual function implementation
        /// </summary>
        public FunctionDelegate FunctionDelegate { get; private set; }
        
        public override object Eval(object[] parameters, ParseTreeEvaluator tree)
        {
            
            if (ShouldPushPopScope)
                tree.Context.PushScope(null);
            object result = FunctionDelegate(parameters);
            if (ShouldPushPopScope)
                tree.Context.PopScope();
            return result;
        }

        public override object Eval(Lazy<object>[] parameters, ParseTreeEvaluator tree)
        {
            object[] parms = new object[parameters.Length];
            int index = 0;
            foreach (Lazy<object> om in parameters)
                parms[index++] = om.Value;
            return Eval(parms, tree);
            
        }

        public StaticFunction(string name, FunctionDelegate function, int minParameters = 0, int maxParameters = 0, string helpText = "", bool shouldPushPopScope = true)
        {
            Name = name;
            FunctionDelegate = function;
            MinParameters = minParameters;
            MaxParameters = maxParameters;
            HelpText = helpText;
            ShouldPushPopScope = shouldPushPopScope;
            Arguments = new Variables();            
        }
        
    }


    public class LazyStaticFunction : Function
    {
        /// <summary>
        /// the actual function implementation
        /// </summary>
        public LazyFunctionDelegate LazyFunctionDelegate { get; private set; }

        public override object Eval(object[] parameters, ParseTreeEvaluator tree)
        {
            
                Lazy<object>[] parms = new Lazy<object>[parameters.Length];
                int index = 0;
                foreach (object om in parameters)
                    parms[index++] = new Lazy<object>(() => om);
                return Eval(parms, tree);
            
        }

        public override object Eval(Lazy<object>[] parameters, ParseTreeEvaluator tree)
        {
            
            if (ShouldPushPopScope)
                tree.Context.PushScope(null);
            object result = LazyFunctionDelegate(parameters);
            if (ShouldPushPopScope)
                tree.Context.PopScope();
            return result;
        }


        public LazyStaticFunction(string name, LazyFunctionDelegate function, int minParameters = 0, int maxParameters = 0, string helpText = "", bool shouldPushPopScope = true)
        {
            Name = name;
            LazyFunctionDelegate = function;
            MinParameters = minParameters;
            MaxParameters = maxParameters;
            HelpText = helpText;
            ShouldPushPopScope = shouldPushPopScope;
            Arguments = new Variables();
        }
    }

}
