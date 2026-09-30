using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Base
{
    /// <summary>
    /// Logging Helper class.
    /// </summary>
    /// <remarks>
    /// provides helper functionality to the logging functions 
    /// <see cref="ILog"/>.
    /// </remarks>
    /// <example>
    /// ILog extension
    /// <code>
    /// 
    /// // generate Instance of the ILog facade
    /// ILog logger = LogManager.GetCurrentClassLogger();
    /// 
    ///  
    /// // Do Something inside this function
    /// function string Something()
    /// {
    ///     // log the enter of the function
    ///     logger.LogEnter();
    ///     string result=@"Hallo Welt";
    ///     
    ///     return logger.LogLeave&gt;string&lt;(result);
    /// }
    /// 
    /// inside the Log-file the result would be:
    ///  -----&gt; 'Something()'
    ///  &lt;----- Result &lt;System.String&gt;: 'Hallo Welt'
    ///  &lt;----- 'Something()'
    /// 
    /// </code>
    /// 
    /// </example>
    /// 
    /// <remarks>
    /// <c>History:</c>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Date</term>
    ///     <term>User</term>
    ///     <term>Description</term>
    ///   </listheader>
    ///   <item>
    ///     <term>2013.02.20</term><term>hbaes</term><term>finished documentation.</term>
    ///   </item>
    /// </list>
    /// </remarks>
    public static partial class ILoggerExtensions
    {
        private const string Heading1 = "=======================================================================";
        private const string Heading2 = "-----------------------------------------------------------------------";
        private const string Heading3 = "";

        #region LogEnter

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log's entering of a method.
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> implementation.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <exception cref="System.ArgumentException">thrown when <paramref name="methodName"/> is Null or Empty</exception>
        /// 
        public static void LogEnter(this ILogger log, string methodName)
        {
            log.LogDebug($"-----> '{methodName}()'");
        }

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log's entering of a method and print method parameters.
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> implementation.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters given to the method.</param>
        /// <exception cref="System.ArgumentException">thrown when <paramref name="methodName"/> is Null or Empty</exception>
        ///
        public static void LogEnter(this ILogger log, string methodName, ParameterInfo[] parameters)
        {
            LogEnter(log, methodName);
            if (parameters.Count() > 0)
            {
                log.LogDebug(@"-----> Parameters:");
                foreach (ParameterInfo p in parameters)
                {
                    log.LogDebug($"-----> Parameter: Name='{p.Name}', Type={p.ParameterType}");
                }
            }
        }

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log's entering a method, fetch information by reflection
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> implementation.</param>
        public static void LogEnter(this ILogger log)
        {
            string methodName = string.Empty;
            MethodBase methodBase = new StackFrame(1, false).GetMethod();
            if (methodBase.IsConstructor == true)
            {
                methodName = string.Format($"new {methodBase.ReflectedType.Name}");
            }
            else
            {
                methodName = methodBase.Name;
            }
            LogEnter(log, methodName, methodBase.GetParameters());
        }

        #endregion

        #region LogLeave

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log's leaving of a method.
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> implementation.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <exception cref="System.ArgumentException">thrown when <paramref name="methodName"/> is Null or Empty</exception>
        /// 
        public static void LogLeave(this ILogger log, string methodName)
        {
            log.LogDebug(@"<----- '{0}()'", methodName);
        }

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log's leaving of a method fetch information by reflection.
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> implementation.</param>
        public static void LogLeave(this ILogger log)
        {
            if (true)//log.IsEnabled(LogLevel.Debug))
            {
                string methodName = string.Empty;
                MethodBase mb = new StackFrame(1, false).GetMethod();
                if (mb.IsConstructor == true)
                {
                    methodName = string.Format(@"new {0}", mb.ReflectedType.Name);
                }
                else
                {
                    methodName = mb.Name;
                }
                LogLeave(log, methodName);
            }
        }

        /// <summary>
        /// Extension method for the <see cref="ILogger"/> interface.
        /// Log's leaving of a method return return value
        /// </summary>
        /// <typeparam name="T">Type of the result of the function.</typeparam>
        /// <param name="log">The <see cref="ILogger"/> implementation.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="result">The result.</param>
        /// <returns>the result of the function.</returns>         
        /// <exception cref="System.ArgumentException">thrown when <paramref name="methodName"/> is Null or Empty</exception>
        /// 
        public static T LogLeave<T>(this ILogger log, string methodName, T result)
        {
            if (true) //(log.IsDebugEnabled)
            {
                string resultTypeName;
                string resultValue;
                if (result == null)
                {
                    resultTypeName = @"Null";
                    resultValue = result.ToString();
                }
                else
                {
                    resultTypeName = result.GetType().Name;
                    Type resultType = result.GetType();
                    if (resultType.ImplementsInterfaceEx<ILogReturnValue>())
                    {
                        ILogReturnValue dummy = result as ILogReturnValue;
                        resultValue = dummy.LogReturnValue();
                    }
                    else if(resultTypeName == "OkObjectResult")
                    {
                        OkObjectResult res = result as OkObjectResult;
                        resultValue = res.Value.ToString();
                    }
                    else
                    {
                        resultValue = result.ToString();
                    }
                }
                log.LogDebug(@"<----- '{0}()' Result <{1}>: '{2}'", methodName, resultTypeName, resultValue);
            }
            return result;
        }

        /// <summary>
        /// Extension method for the <see cref="ILog"/> interface.
        /// Log leaving, find method name by Reflection log result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x">The <see cref="ILog"/> implementation.</param>
        /// <param name="result">The result.</param>
        /// <returns>the result of the function.</returns>
        public static T LogLeave<T>(this ILogger x, T result)
        {
            string methodName = string.Empty;
            MethodBase mb = new StackFrame(1, false).GetMethod();
            if (mb.IsConstructor == true)
            {
                methodName = string.Format(@"new {0}", mb.ReflectedType.Name);
            }
            else
            {
                methodName = mb.Name;
            }
            return LogLeave<T>(x, methodName, result);
        }

        #endregion
    }
}
