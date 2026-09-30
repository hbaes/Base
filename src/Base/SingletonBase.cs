using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    /// <summary>
    /// This class provide a generic and thread-safe interface for Singleton classes.
    /// </summary>
    /// <typeparam name="T">The specialized singleton which is derived
    /// from SingletonBase&lt;T&gt;</typeparam>
    public abstract class SingletonBase<T> where T : SingletonBase<T>
    {

        #region Fields

        #region Private

        /* logging */
        private static readonly ILogger log = ApplicationLogging.CreateLogger("SingletonBase");

        /* the lock object */
        private static object _lock = new object();

        /* the static instance */
        private static volatile T _instance = null;

        #endregion

        #endregion

        #region Properties

        #region Public

        /// <summary>
        /// Get the unique instance of <typeparamref name="T"/>.
        /// This property is thread-safe!
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            log.LogDebug($"Create new Sigleton instance of type '{typeof(T).Name}'");
                            /* Create a object without to use new (where you need a public ctor) */
                            object obj = FormatterServices.GetUninitializedObject(typeof(T));
                            if (obj != null)  // just 4 safety, but i think obj == null shouldn't be possible
                            {
                                /* an extra test of the correct type is redundant,
                                 * because we have an uninitialised object of type == typeof(T) */
                                _instance = obj as T;
                                _instance.Init(); // now the singleton will be initialized
                            }
                        }
                    }
                }
                else
                {
                    _instance.Refresh();  // has only effect if overridden in sub class
                }
                return _instance;
            }
        }

        #endregion

        #endregion

        #region Constructor / Destructor

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            if (_instance != null)
            {
                lock (_lock)
                {
                    if (_instance != null)
                    {
                        log.LogDebug($"Reset Singleton instance of type '{typeof(T).Name}");
                        _instance = null;
                    }
                }
            }
        }

        #endregion

        #region Protected Virtual

        /// <summary>
        /// Called while instantiation of singleton sub-class.
        /// This could be used to set some default stuff in the singleton.
        /// </summary>
        protected virtual void Init()
        { }

        /// <summary>
        /// If overridden this will called on every request of the Instance but
        /// the instance was already created. Refresh will not called during
        /// the first instantiation, for this will call Init.
        /// </summary>
        protected virtual void Refresh()
        { }

        #endregion

        #endregion
    }
}

