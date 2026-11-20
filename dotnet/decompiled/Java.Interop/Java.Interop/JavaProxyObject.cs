using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Java.Interop;

[JniTypeSignature("net/dot/jni/internal/JavaProxyObject", GenerateJavaPeer = false)]
internal sealed class JavaProxyObject : JavaObject, IEquatable<JavaProxyObject>
{
	private static readonly JniPeerMembers _members = new JniPeerMembers("net/dot/jni/internal/JavaProxyObject", typeof(JavaProxyObject));

	private static readonly ConditionalWeakTable<object, JavaProxyObject> CachedValues = new ConditionalWeakTable<object, JavaProxyObject>();

	public override JniPeerMembers JniPeerMembers => _members;

	public object Value { get; private set; }

	private JavaProxyObject(object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		Value = value;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (obj is JavaProxyObject javaProxyObject)
		{
			return object.Equals(Value, javaProxyObject.Value);
		}
		return object.Equals(Value, obj);
	}

	public bool Equals(JavaProxyObject? other)
	{
		return object.Equals(Value, other?.Value);
	}

	public override string? ToString()
	{
		return Value.ToString();
	}

	[return: NotNullIfNotNull("object")]
	public static JavaProxyObject? GetProxy(object value)
	{
		if (value == null)
		{
			return null;
		}
		lock (CachedValues)
		{
			if (CachedValues.TryGetValue(value, out JavaProxyObject value2))
			{
				return value2;
			}
			value2 = new JavaProxyObject(value);
			CachedValues.Add(value, value2);
			return value2;
		}
	}
}
