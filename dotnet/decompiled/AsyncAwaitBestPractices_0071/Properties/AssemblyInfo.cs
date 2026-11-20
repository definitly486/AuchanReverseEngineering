using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Brandon Minnick, John Thiriet")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("©Copyright 2023 Brandon Minnick. All rights reserved.")]
[assembly: AssemblyDescription("\n      Extensions for System.Threading.Tasks\n\n      Includes extension methods to safely fire-and-forget a Task and/or a ValueTask\n      Includes WeakEventManger which avoids memory leaks when events are not unsubscribed\n    ")]
[assembly: AssemblyFileVersion("9.0.0")]
[assembly: AssemblyInformationalVersion("9.0.0+0b0772a621c2f1d7ded1a27b84ef0251b6aed2be")]
[assembly: AssemblyProduct("AsyncAwaitBestPractices (net9.0)")]
[assembly: AssemblyTitle("AsyncAwaitBestPractices")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/brminnick/AsyncAwaitBestPractices")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("9.0.0.0")]
[module: RefSafetyRules(11)]
