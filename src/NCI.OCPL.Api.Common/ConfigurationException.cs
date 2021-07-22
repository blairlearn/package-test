namespace NCI.OCPL.Api.Common
{
    /// <summary>
    /// Represents an Exception to be thrown when a configuration error occurs.
    /// </summary>
    public class ConfigurationException : System.Exception
  {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ConfigurationException() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message to include with the exception.</param>
        public ConfigurationException( string message ) : base( message ) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message to include with the exception.</param>
        /// <param name="inner">Inner exception.</param>
        public ConfigurationException( string message, System.Exception inner ) : base( message, inner ) { }
    }
}