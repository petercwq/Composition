// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Reflection;
using Microsoft.Internal;

namespace Microsoft.Composition.Diagnostics
{
    internal static class CompositionTrace
    {
        internal static void Registration_ConstructorConventionOverridden(Type type)
        {
            Assumes.NotNull(type);

            if (CompositionTraceSource.CanWriteInformation)
            {
                CompositionTraceSource.WriteInformation(CompositionTraceId.Registration_ConstructorConventionOverridden, System.Composition.Properties.Resources.Registration_ConstructorConventionOverridden,
                    type.FullName);
            }
        }

        internal static void Registration_TypeExportConventionOverridden(Type type)
        {
            Assumes.NotNull(type);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_TypeExportConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_TypeExportConventionOverridden,
                                                    type.FullName);
            }
        }

        internal static void Registration_MemberExportConventionOverridden(Type type, MemberInfo member)
        {
            Assumes.NotNull(type, member);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberExportConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_MemberExportConventionOverridden,
                                                    member.Name, type.FullName);
            }
        }

        internal static void Registration_MemberImportConventionOverridden(Type type, MemberInfo member)
        {
            Assumes.NotNull(type, member);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberImportConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_MemberImportConventionOverridden,
                                                    member.Name, type.FullName);
            }
        }

        internal static void Registration_OnSatisfiedImportNotificationOverridden(Type type, MemberInfo member)
        {
            Assumes.NotNull(type, member);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_OnSatisfiedImportNotificationOverridden, System.Composition.Properties.Resources.Registration_OnSatisfiedImportNotificationOverridden,
                                                    member.Name, type.FullName);
            }
        }

        internal static void Registration_PartCreationConventionOverridden(Type type)
        {
            Assumes.NotNull(type);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_PartCreationConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_PartCreationConventionOverridden,
                                                    type.FullName);
            }
        }

        internal static void Registration_MemberImportConventionMatchedTwice(Type type, MemberInfo member)
        {
            Assumes.NotNull(type, member);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberImportConventionMatchedTwice,
                                                    System.Composition.Properties.Resources.Registration_MemberImportConventionMatchedTwice,
                                                    member.Name, type.FullName);
            }
        }

        internal static void Registration_PartMetadataConventionOverridden(Type type)
        {
            Assumes.NotNull(type);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_PartMetadataConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_PartMetadataConventionOverridden,
                                                    type.FullName);
            }
        }

        internal static void Registration_ParameterImportConventionOverridden(ParameterInfo parameter, ConstructorInfo constructor)
        {
            Assumes.NotNull(parameter, constructor);

            if (CompositionTraceSource.CanWriteWarning)
            {
                CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_ParameterImportConventionOverridden,
                                                    System.Composition.Properties.Resources.Registration_ParameterImportConventionOverridden,
                                                    parameter.Name, constructor.Name);
            }
        }
    }
}
