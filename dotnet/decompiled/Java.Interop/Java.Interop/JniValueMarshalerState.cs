using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

public struct JniValueMarshalerState : IEquatable<JniValueMarshalerState>
{
	public JniArgumentValue JniArgumentValue { get; private set; }

	public JniObjectReference ReferenceValue { get; private set; }

	public IJavaPeerable? PeerableValue { get; private set; }

	public object? Extra { get; private set; }

	public JniValueMarshalerState(JniArgumentValue jniArgumentValue, object? extra = null)
	{
		JniArgumentValue = jniArgumentValue;
		ReferenceValue = default(JniObjectReference);
		PeerableValue = null;
		Extra = extra;
	}

	public JniValueMarshalerState(JniObjectReference referenceValue, object? extra = null)
	{
		JniArgumentValue = new JniArgumentValue(referenceValue);
		ReferenceValue = referenceValue;
		PeerableValue = null;
		Extra = extra;
	}

	public JniValueMarshalerState(IJavaPeerable? peerableValue, object? extra = null)
	{
		PeerableValue = peerableValue;
		ReferenceValue = peerableValue?.PeerReference ?? default(JniObjectReference);
		JniArgumentValue = new JniArgumentValue(ReferenceValue);
		Extra = extra;
	}

	internal JniValueMarshalerState(JniValueMarshalerState copy, object? extra = null)
	{
		JniArgumentValue = copy.JniArgumentValue;
		ReferenceValue = copy.ReferenceValue;
		PeerableValue = copy.PeerableValue;
		Extra = extra ?? copy.Extra;
	}

	public override int GetHashCode()
	{
		return JniArgumentValue.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		JniValueMarshalerState? jniValueMarshalerState = obj as JniValueMarshalerState?;
		if (!jniValueMarshalerState.HasValue)
		{
			return false;
		}
		return Equals(jniValueMarshalerState.Value);
	}

	public bool Equals(JniValueMarshalerState other)
	{
		if (JniArgumentValue.Equals(other.JniArgumentValue) && ReferenceValue.Equals(other.ReferenceValue) && PeerableValue == other.PeerableValue)
		{
			return Extra == other.Extra;
		}
		return false;
	}

	public static bool operator ==(JniValueMarshalerState a, JniValueMarshalerState b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(JniValueMarshalerState a, JniValueMarshalerState b)
	{
		return !a.Equals(b);
	}

	public override string ToString()
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = JniArgumentValue.ToString();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = ReferenceValue.ToString();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = RuntimeHelpers.GetHashCode(PeerableValue).ToString("x");
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = Extra;
		return string.Format("JniValueMarshalerState({0}, ReferenceValue={1}, PeerableValue=0x{2}, Extra={3})", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}
}
