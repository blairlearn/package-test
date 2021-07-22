// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//This was pulled from https://github.com/aspnet/Logging/blob/dev/src/Microsoft.Extensions.Logging.Testing/NullLogger.cs
//There is a GitRequest to publish the Microsoft.Extensions.Logging.Testing package to nuget --
//once that happens, this code should be removed and that package should be used.

using System;

namespace Microsoft.Extensions.Logging.Testing
{
    /// <summary>
    /// A mock logger to explicitly not do anything.
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        public static readonly NullLogger Instance = new NullLogger();

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return NullDisposable.Instance;
        }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        private class NullDisposable : IDisposable
        {
            public static readonly NullDisposable Instance = new NullDisposable();

            public void Dispose()
            {
                // intentionally does nothing
            }
        }
    }
}