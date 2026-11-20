using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.Collections.Immutable")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyMetadata("IsAotCompatible", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("This package provides collections that are thread safe and guaranteed to never change their contents, also known as immutable collections. Like strings, any methods that perform modifications will not change the existing instance but instead return a new instance. For efficiency reasons, the implementation uses a sharing mechanism to ensure that newly created instances share as much data as possible with the previous instance while ensuring that operations have a predictable time complexity.\n\nThe System.Collections.Immutable library is built-in as part of the shared framework in .NET Runtime. The package can be installed when you need to use it in other target frameworks.")]
[assembly: AssemblyFileVersion("10.0.1226.42308")]
[assembly: AssemblyInformationalVersion("10.0.12+95017c711e6afc1085133d440e42b4bd78155701")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Collections.Immutable")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/dotnet")]
[assembly: AssemblyVersion("10.0.0.0")]
[module: RefSafetyRules(11)]
[module: NullablePublicOnly(false)]
[module: SkipLocalsInit]
