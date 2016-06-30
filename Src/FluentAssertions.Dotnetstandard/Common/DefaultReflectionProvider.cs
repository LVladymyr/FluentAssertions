using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Versioning;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

namespace FluentAssertions.Common
{
    internal class DefaultReflector : IReflector
    {
        public IEnumerable<Type> GetAllTypesFromAppDomain(Func<Assembly, bool> predicate)
        {
            //AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            //Type[] types = DependencyContext.Default.RuntimeLibraries
            //    .SelectMany(a => a.Assemblies)
            //    .Where(a => predicate(a) && !IsDynamic(a))
            //    .SelectMany(GetExportedTypes).ToArray();

            return null;// types;
        }

        private static bool IsDynamic(AssemblyName assemblyName)
        {
            return assemblyName.FullName != "System.Reflection.Emit.InternalAssemblyBuilder";
        }
        

        private static IEnumerable<Type> GetExportedTypes(RuntimeAssembly assembly)
        {
            try
            {
                return null; //assembly. .GetExportedTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types;
            }
            catch (FileLoadException)
            {
                return new Type[0];
            }
            catch (Exception)
            {
                return new Type[0];
            }
        }
    }
}