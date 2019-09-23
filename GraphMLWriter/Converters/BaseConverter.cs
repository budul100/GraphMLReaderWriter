using System.Collections.Generic;

namespace GraphMLWriter.Converters
{
    internal abstract class BaseConverter
    {
        #region Protected Fields

        protected static List<string> ids;

        #endregion Protected Fields

        #region Public Methods

        public static void Initialize()
        {
            ids = new List<string>();
        }

        #endregion Public Methods
    }
}