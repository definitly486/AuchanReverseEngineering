using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text.Json;

[assembly: MetadataUpdateHandler(typeof(JsonSerializerOptionsUpdateHandler))]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.Text.Json")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyMetadata("IsAotCompatible", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides high-performance and low-allocating types that serialize objects to JavaScript Object Notation (JSON) text and deserialize JSON text to objects, with UTF-8 support built-in. Also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM), that is read-only, for random access of the JSON elements within a structured view of the data.\n\nThe System.Text.Json library is built-in as part of the shared framework in .NET Runtime. The package can be installed when you need to use it in other target frameworks.")]
[assembly: AssemblyFileVersion("10.0.1226.42308")]
[assembly: AssemblyInformationalVersion("10.0.12+95017c711e6afc1085133d440e42b4bd78155701")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Text.Json")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/dotnet")]
[assembly: AssemblyVersion("10.0.0.0")]
[module: RefSafetyRules(11)]
[module: NullablePublicOnly(false)]
[module: SkipLocalsInit]
