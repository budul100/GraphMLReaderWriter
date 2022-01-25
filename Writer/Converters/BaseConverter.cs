using System.Collections.Generic;

namespace GraphMLRW.Converters
{
    internal abstract class BaseConverter
    {
        #region Protected Fields

        protected static HashSet<string> ids;

        #endregion Protected Fields

        #region Public Methods

        public static void Initialize()
        {
            ids = new HashSet<string>();
        }

        #endregion Public Methods
    }
}