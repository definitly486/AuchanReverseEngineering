using System;
using System.Reflection;

namespace DryIoc;

public delegate Func<ParameterInfo, ParameterServiceInfo> ParameterSelector(Request request);
