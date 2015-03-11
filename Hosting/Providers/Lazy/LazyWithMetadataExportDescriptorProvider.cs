﻿// -----------------------------------------------------------------------
// Copyright © Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Providers.Metadata;
using System.Composition.Hosting.Util;
using System.Linq;
using System.Reflection;

namespace System.Composition.Hosting.Providers.Lazy
{
    class LazyWithMetadataExportDescriptorProvider : ExportDescriptorProvider
    {
        static readonly MethodInfo GetLazyDefinitionsMethod = typeof(LazyWithMetadataExportDescriptorProvider).GetTypeInfo().GetDeclaredMethod("GetLazyDefinitions");

        public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract exportKey, DependencyAccessor definitionAccessor)
        {
            if (!exportKey.ContractType.IsConstructedGenericType || exportKey.ContractType.GetGenericTypeDefinition() != typeof(Lazy<,>))
                return NoExportDescriptors;

            var ga = exportKey.ContractType.GenericTypeArguments;
            var gld = GetLazyDefinitionsMethod.MakeGenericMethod(ga[0], ga[1]);
            var gldm = gld.CreateStaticDelegate<Func<CompositionContract, DependencyAccessor, object>>();
            return (ExportDescriptorPromise[])gldm(exportKey, definitionAccessor);
        }

        static ExportDescriptorPromise[] GetLazyDefinitions<TValue, TMetadata>(CompositionContract lazyContract, DependencyAccessor definitionAccessor)
        {
            var metadataProvider = MetadataViewProvider.GetMetadataViewProvider<TMetadata>();

            return definitionAccessor.ResolveDependencies("value", lazyContract.ChangeType(typeof(TValue)), false)
                .Select(d => new ExportDescriptorPromise(
                    lazyContract,
                    Formatters.Format(typeof(Lazy<TValue, TMetadata>)),
                    false,
                    () => new[] { d },
                    _ =>
                    {
                        var dsc = d.Target.GetDescriptor();
                        var da = dsc.Activator;
                        return ExportDescriptor.Create((c, o) =>
                        {
                            return new Lazy<TValue, TMetadata>(() => (TValue)CompositionOperation.Run(c, da), metadataProvider(dsc.Metadata));
                        }, dsc.Metadata);
                    }))
                .ToArray();
        }
    }
}
