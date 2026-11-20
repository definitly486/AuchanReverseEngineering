using System;

namespace Android.Runtime;

public class AnnotationAttribute : Attribute
{
	public string JavaName { get; private set; }

	public AnnotationAttribute(string javaName)
	{
		JavaName = javaName;
	}
}
