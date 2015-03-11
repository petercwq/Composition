﻿// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------

namespace System.Composition
{
    /// <summary>
    /// A handle allowing the graph of parts associated with an exported instance
    /// to be released.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Export<T> : IDisposable
    {
        private readonly T _value;
        private readonly Action _disposeAction;

        /// <summary>
        /// Construct an ExportLifetimContext.
        /// </summary>
        /// <param name="value">The value of the export.</param>
        /// <param name="disposeAction">An action that releases resources associated with the export.</param>
        public Export(T value, Action disposeAction)
        {
            this._value = value;
            this._disposeAction = disposeAction;
        }

        /// <summary>
        /// The exported value.
        /// </summary>
        public T Value
        {
            get
            {
                return this._value;
            }
        }

        /// <summary>
        /// Release the parts associated with the exported value.
        /// </summary>
        public void Dispose()
        {
            if (this._disposeAction != null)
            {
                this._disposeAction.Invoke();
            }
        }
    }
}

