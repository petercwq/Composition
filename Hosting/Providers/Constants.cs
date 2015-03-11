// -----------------------------------------------------------------------
// Copyright © Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------

namespace System.Composition.Hosting.Providers
{
    /// <summary>
    /// Metadata keys used to tie programming model entities into their back-end hosting implementations.
    /// </summary>
    static class Constants
    {
        /// <summary>
        /// The sharing boundary implemented by an import.
        /// </summary>
        public const string SharingBoundaryImportMetadataConstraintName = "SharingBoundaryNames";

        /// <summary>
        /// Marks an import as "many".
        /// </summary>
        public const string ImportManyImportMetadataConstraintName = "IsImportMany";
    }
}
