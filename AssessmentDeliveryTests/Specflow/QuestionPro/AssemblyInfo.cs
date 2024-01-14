using NUnit.Framework;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]