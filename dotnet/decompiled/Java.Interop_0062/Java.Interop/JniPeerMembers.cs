using System;
using System.Collections.Generic;

namespace Java.Interop;

public class JniPeerMembers
{
	public sealed class JniInstanceFields
	{
		private readonly JniPeerMembers Members;

		private Dictionary<string, JniFieldInfo> InstanceFields = new Dictionary<string, JniFieldInfo>(StringComparer.Ordinal);

		public bool GetBooleanValue(string encodedMember, IJavaPeerable self)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			bool booleanField = JniEnvironment.InstanceFields.GetBooleanField(self.PeerReference, fieldInfo);
			GC.KeepAlive(self);
			return booleanField;
		}

		public void SetValue(string encodedMember, IJavaPeerable self, sbyte value)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.InstanceFields.SetByteField(self.PeerReference, fieldInfo, value);
			GC.KeepAlive(self);
		}

		public int GetInt32Value(string encodedMember, IJavaPeerable self)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			int intField = JniEnvironment.InstanceFields.GetIntField(self.PeerReference, fieldInfo);
			GC.KeepAlive(self);
			return intField;
		}

		public void SetValue(string encodedMember, IJavaPeerable self, int value)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.InstanceFields.SetIntField(self.PeerReference, fieldInfo, value);
			GC.KeepAlive(self);
		}

		public long GetInt64Value(string encodedMember, IJavaPeerable self)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			long longField = JniEnvironment.InstanceFields.GetLongField(self.PeerReference, fieldInfo);
			GC.KeepAlive(self);
			return longField;
		}

		public void SetValue(string encodedMember, IJavaPeerable self, long value)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.InstanceFields.SetLongField(self.PeerReference, fieldInfo, value);
			GC.KeepAlive(self);
		}

		public float GetSingleValue(string encodedMember, IJavaPeerable self)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			float floatField = JniEnvironment.InstanceFields.GetFloatField(self.PeerReference, fieldInfo);
			GC.KeepAlive(self);
			return floatField;
		}

		public void SetValue(string encodedMember, IJavaPeerable self, float value)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.InstanceFields.SetFloatField(self.PeerReference, fieldInfo, value);
			GC.KeepAlive(self);
		}

		public JniObjectReference GetObjectValue(string encodedMember, IJavaPeerable self)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniObjectReference objectField = JniEnvironment.InstanceFields.GetObjectField(self.PeerReference, fieldInfo);
			GC.KeepAlive(self);
			return objectField;
		}

		public void SetValue(string encodedMember, IJavaPeerable self, JniObjectReference value)
		{
			AssertSelf(self);
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.InstanceFields.SetObjectField(self.PeerReference, fieldInfo, value);
			GC.KeepAlive(self);
		}

		internal JniInstanceFields(JniPeerMembers members)
		{
			Members = members;
		}

		public JniFieldInfo GetFieldInfo(string encodedMember)
		{
			lock (InstanceFields)
			{
				if (!InstanceFields.TryGetValue(encodedMember, out JniFieldInfo value))
				{
					GetNameAndSignature(encodedMember, out string name, out string signature);
					value = Members.JniPeerType.GetInstanceField(name, signature);
					InstanceFields.Add(encodedMember, value);
				}
				return value;
			}
		}
	}

	public sealed class JniStaticFields
	{
		private readonly JniPeerMembers Members;

		private Dictionary<string, JniFieldInfo> StaticFields = new Dictionary<string, JniFieldInfo>(StringComparer.Ordinal);

		public bool GetBooleanValue(string encodedMember)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			return JniEnvironment.StaticFields.GetStaticBooleanField(Members.JniPeerType.PeerReference, fieldInfo);
		}

		public void SetValue(string encodedMember, sbyte value)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.StaticFields.SetStaticByteField(Members.JniPeerType.PeerReference, fieldInfo, value);
		}

		public int GetInt32Value(string encodedMember)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			return JniEnvironment.StaticFields.GetStaticIntField(Members.JniPeerType.PeerReference, fieldInfo);
		}

		public void SetValue(string encodedMember, int value)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.StaticFields.SetStaticIntField(Members.JniPeerType.PeerReference, fieldInfo, value);
		}

		public long GetInt64Value(string encodedMember)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			return JniEnvironment.StaticFields.GetStaticLongField(Members.JniPeerType.PeerReference, fieldInfo);
		}

		public void SetValue(string encodedMember, long value)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.StaticFields.SetStaticLongField(Members.JniPeerType.PeerReference, fieldInfo, value);
		}

		public float GetSingleValue(string encodedMember)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			return JniEnvironment.StaticFields.GetStaticFloatField(Members.JniPeerType.PeerReference, fieldInfo);
		}

		public void SetValue(string encodedMember, float value)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.StaticFields.SetStaticFloatField(Members.JniPeerType.PeerReference, fieldInfo, value);
		}

		public JniObjectReference GetObjectValue(string encodedMember)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			return JniEnvironment.StaticFields.GetStaticObjectField(Members.JniPeerType.PeerReference, fieldInfo);
		}

		public void SetValue(string encodedMember, JniObjectReference value)
		{
			JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
			JniEnvironment.StaticFields.SetStaticObjectField(Members.JniPeerType.PeerReference, fieldInfo, value);
		}

		internal JniStaticFields(JniPeerMembers members)
		{
			Members = members;
		}

		public JniFieldInfo GetFieldInfo(string encodedMember)
		{
			lock (StaticFields)
			{
				if (!StaticFields.TryGetValue(encodedMember, out JniFieldInfo value))
				{
					GetNameAndSignature(encodedMember, out string name, out string signature);
					value = Members.JniPeerType.GetStaticField(name, signature);
					StaticFields.Add(encodedMember, value);
				}
				return value;
			}
		}
	}

	public sealed class JniInstanceMethods
	{
		private JniPeerMembers? members;

		private JniType? jniPeerType;

		private readonly Type DeclaringType;

		private Dictionary<string, JniMethodInfo> InstanceMethods = new Dictionary<string, JniMethodInfo>(StringComparer.Ordinal);

		private Dictionary<Type, JniInstanceMethods> SubclassConstructors = new Dictionary<Type, JniInstanceMethods>();

		internal JniPeerMembers Members => members ?? throw new InvalidOperationException();

		internal JniType JniPeerType => jniPeerType ?? Members?.JniPeerType ?? throw new InvalidOperationException();

		internal JniInstanceMethods(JniPeerMembers members)
		{
			DeclaringType = members.ManagedPeerType;
			this.members = members;
		}

		private JniInstanceMethods(Type declaringType)
		{
			JniTypeSignature typeSignature = JniEnvironment.Runtime.TypeManager.GetTypeSignature(declaringType);
			if (typeSignature.SimpleReference == null)
			{
				throw new NotSupportedException($"Cannot create instance of type '{declaringType.FullName}': no Java peer type found.");
			}
			DeclaringType = declaringType;
			jniPeerType = new JniType(typeSignature.Name);
			jniPeerType.RegisterWithRuntime();
		}

		public JniMethodInfo GetConstructor(string signature)
		{
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			lock (InstanceMethods)
			{
				if (!InstanceMethods.TryGetValue(signature, out JniMethodInfo value))
				{
					value = JniPeerType.GetConstructor(signature);
					InstanceMethods.Add(signature, value);
				}
				return value;
			}
		}

		internal JniInstanceMethods GetConstructorsForType(Type declaringType)
		{
			if (declaringType == DeclaringType)
			{
				return this;
			}
			JniInstanceMethods value;
			lock (SubclassConstructors)
			{
				if (SubclassConstructors.TryGetValue(declaringType, out value))
				{
					return value;
				}
			}
			value = new JniInstanceMethods(declaringType);
			lock (SubclassConstructors)
			{
				if (SubclassConstructors.TryGetValue(declaringType, out JniInstanceMethods value2))
				{
					return value2;
				}
				SubclassConstructors.Add(declaringType, value);
				return value;
			}
		}

		public JniMethodInfo GetMethodInfo(string encodedMember)
		{
			lock (InstanceMethods)
			{
				if (InstanceMethods.TryGetValue(encodedMember, out JniMethodInfo value))
				{
					return value;
				}
			}
			GetNameAndSignature(encodedMember, out string name, out string signature);
			JniMethodInfo methodInfo = GetMethodInfo(name, signature);
			lock (InstanceMethods)
			{
				if (InstanceMethods.TryGetValue(encodedMember, out JniMethodInfo value2))
				{
					return value2;
				}
				InstanceMethods.Add(encodedMember, methodInfo);
				return methodInfo;
			}
		}

		private JniMethodInfo GetMethodInfo(string method, string signature)
		{
			JniMethodInfo method2 = null;
			JniRuntime.ReplacementMethodInfo? replacementMethodInfo = JniEnvironment.Runtime.TypeManager.GetReplacementMethodInfo(Members.JniPeerTypeName, method, signature);
			if (replacementMethodInfo.HasValue)
			{
				string text = replacementMethodInfo.Value.TargetJniType ?? Members.JniPeerTypeName;
				string text2 = replacementMethodInfo.Value.TargetJniMethodName ?? method;
				string text3 = replacementMethodInfo.Value.TargetJniMethodSignature ?? signature;
				using JniType jniType = new JniType(text);
				if (replacementMethodInfo.Value.TargetJniMethodInstanceToStatic && jniType.TryGetStaticMethod(text2, text3, out method2))
				{
					method2.ParameterCount = replacementMethodInfo.Value.TargetJniMethodParameterCount;
					method2.StaticRedirect = new JniType(text);
					return method2;
				}
				if (jniType.TryGetInstanceMethod(text2, text3, out method2))
				{
					return method2;
				}
				Console.Error.WriteLine($"warning: For declared method `{Members.JniPeerTypeName}.{method}.{signature}`, could not find requested method `{text}.{text2}.{text3}`!");
			}
			return JniPeerType.GetInstanceMethod(method, signature);
		}

		public unsafe JniObjectReference StartCreateInstance(string constructorSignature, Type declaringType, JniArgumentValue* parameters)
		{
			parameters = parameters;
			if (constructorSignature == null)
			{
				throw new ArgumentNullException("constructorSignature");
			}
			if (declaringType == null)
			{
				throw new ArgumentNullException("declaringType");
			}
			JniObjectReference result = GetConstructorsForType(declaringType).JniPeerType.AllocObject();
			result.Flags = JniObjectReferenceFlags.Alloc;
			return result;
		}

		public unsafe void FinishCreateInstance(string constructorSignature, IJavaPeerable self, JniArgumentValue* parameters)
		{
			if (constructorSignature == null)
			{
				throw new ArgumentNullException("constructorSignature");
			}
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			JniInstanceMethods constructorsForType = GetConstructorsForType(self.GetType());
			JniMethodInfo constructor = constructorsForType.GetConstructor(constructorSignature);
			JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, constructorsForType.JniPeerType.PeerReference, constructor, parameters);
		}

		private unsafe static bool TryInvokeVoidStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters)
		{
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			JniEnvironment.StaticMethods.CallStaticVoidMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe void InvokeAbstractVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
				{
					JniEnvironment.InstanceMethods.CallVoidMethod(self.PeerReference, methodInfo, parameters);
				}
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe void InvokeVirtualVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
					{
						JniEnvironment.InstanceMethods.CallVoidMethod(self.PeerReference, methodInfo, parameters);
					}
					return;
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (!TryInvokeVoidStaticRedirect(methodInfo2, self, parameters))
				{
					JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe void InvokeNonvirtualVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
				{
					JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeBooleanStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out bool r)
		{
			r = false;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticBooleanMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe bool InvokeAbstractBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallBooleanMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe bool InvokeVirtualBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallBooleanMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeBooleanStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualBooleanMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe bool InvokeNonvirtualBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualBooleanMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeSByteStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out sbyte r)
		{
			r = 0;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticByteMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe sbyte InvokeAbstractSByteMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeSByteStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallByteMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe sbyte InvokeVirtualSByteMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeSByteStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallByteMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeSByteStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualByteMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeCharStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out char r)
		{
			r = '\0';
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticCharMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe char InvokeAbstractCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallCharMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe char InvokeVirtualCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallCharMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeCharStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualCharMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe char InvokeNonvirtualCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualCharMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeInt16StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out short r)
		{
			r = 0;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticShortMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe short InvokeAbstractInt16Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeInt16StaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallShortMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe short InvokeVirtualInt16Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt16StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallShortMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeInt16StaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualShortMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeInt32StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out int r)
		{
			r = 0;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticIntMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe int InvokeAbstractInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallIntMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe int InvokeVirtualInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallIntMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeInt32StaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualIntMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe int InvokeNonvirtualInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualIntMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeInt64StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out long r)
		{
			r = 0L;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticLongMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe long InvokeAbstractInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallLongMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe long InvokeVirtualInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallLongMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeInt64StaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualLongMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe long InvokeNonvirtualInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualLongMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeSingleStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out float r)
		{
			r = 0f;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticFloatMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe float InvokeAbstractSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallFloatMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe float InvokeVirtualSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallFloatMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeSingleStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualFloatMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe float InvokeNonvirtualSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualFloatMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeDoubleStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out double r)
		{
			r = 0.0;
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticDoubleMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe double InvokeAbstractDoubleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeDoubleStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallDoubleMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe double InvokeVirtualDoubleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeDoubleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallDoubleMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeDoubleStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualDoubleMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		private unsafe static bool TryInvokeObjectStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out JniObjectReference r)
		{
			r = default(JniObjectReference);
			if (method.StaticRedirect == null || !method.ParameterCount.HasValue)
			{
				return false;
			}
			int value = method.ParameterCount.Value;
			JniArgumentValue* ptr = stackalloc JniArgumentValue[value];
			*ptr = new JniArgumentValue(self);
			for (int i = 0; i < value - 1; i++)
			{
				ptr[i + 1] = parameters[i];
			}
			r = JniEnvironment.StaticMethods.CallStaticObjectMethod(method.StaticRedirect.PeerReference, method, ptr);
			return true;
		}

		public unsafe JniObjectReference InvokeAbstractObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallObjectMethod(self.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe JniObjectReference InvokeVirtualObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			try
			{
				Type declaringType = DeclaringType;
				if (Members.UsesVirtualDispatch(self, declaringType))
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallObjectMethod(self.PeerReference, methodInfo, parameters);
				}
				JniPeerMembers peerMembers = Members.GetPeerMembers(self);
				JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
				if (TryInvokeObjectStaticRedirect(methodInfo2, self, parameters, out var r2))
				{
					return r2;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualObjectMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}

		public unsafe JniObjectReference InvokeNonvirtualObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
		{
			AssertSelf(self);
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			try
			{
				if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
				{
					return r;
				}
				return JniEnvironment.InstanceMethods.CallNonvirtualObjectMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
			}
			finally
			{
				GC.KeepAlive(self);
			}
		}
	}

	public sealed class JniStaticMethods
	{
		internal readonly JniPeerMembers Members;

		private Dictionary<string, JniMethodInfo> StaticMethods = new Dictionary<string, JniMethodInfo>(StringComparer.Ordinal);

		internal JniStaticMethods(JniPeerMembers members)
		{
			Members = members;
		}

		public JniMethodInfo GetMethodInfo(string encodedMember)
		{
			lock (StaticMethods)
			{
				if (StaticMethods.TryGetValue(encodedMember, out JniMethodInfo value))
				{
					return value;
				}
			}
			GetNameAndSignature(encodedMember, out string name, out string signature);
			JniMethodInfo methodInfo = GetMethodInfo(name, signature);
			lock (StaticMethods)
			{
				if (StaticMethods.TryGetValue(encodedMember, out JniMethodInfo value2))
				{
					return value2;
				}
				StaticMethods.Add(encodedMember, methodInfo);
				return methodInfo;
			}
		}

		private JniMethodInfo GetMethodInfo(string method, string signature)
		{
			JniMethodInfo method2 = null;
			JniRuntime.ReplacementMethodInfo? replacementMethodInfo = JniEnvironment.Runtime.TypeManager.GetReplacementMethodInfo(Members.JniPeerTypeName, method, signature);
			if (replacementMethodInfo.HasValue)
			{
				using JniType jniType = new JniType(replacementMethodInfo.Value.TargetJniType ?? Members.JniPeerTypeName);
				if (jniType.TryGetStaticMethod(replacementMethodInfo.Value.TargetJniMethodName ?? method, replacementMethodInfo.Value.TargetJniMethodSignature ?? signature, out method2))
				{
					return method2;
				}
			}
			if (Members.JniPeerType.TryGetStaticMethod(method, signature, out method2))
			{
				return method2;
			}
			method2 = FindInFallbackTypes(method, signature);
			if (method2 != null)
			{
				return method2;
			}
			return Members.JniPeerType.GetStaticMethod(method, signature);
		}

		private JniType GetMethodDeclaringType(JniMethodInfo method)
		{
			if (method.StaticRedirect != null)
			{
				return method.StaticRedirect;
			}
			return Members.JniPeerType;
		}

		private JniMethodInfo? FindInFallbackTypes(string method, string signature)
		{
			IReadOnlyList<string> staticMethodFallbackTypes = JniEnvironment.Runtime.TypeManager.GetStaticMethodFallbackTypes(Members.JniPeerTypeName);
			if (staticMethodFallbackTypes == null)
			{
				return null;
			}
			foreach (string item in staticMethodFallbackTypes)
			{
				JniType type = null;
				try
				{
					if (!JniType.TryParse(item, out type) || !type.TryGetStaticMethod(method, signature, out JniMethodInfo method2))
					{
						continue;
					}
					method2.StaticRedirect = type;
					type = null;
					return method2;
				}
				finally
				{
					type?.Dispose();
				}
			}
			return null;
		}

		public unsafe void InvokeVoidMethod(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			JniEnvironment.StaticMethods.CallStaticVoidMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}

		public unsafe bool InvokeBooleanMethod(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			return JniEnvironment.StaticMethods.CallStaticBooleanMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}

		public unsafe int InvokeInt32Method(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			return JniEnvironment.StaticMethods.CallStaticIntMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}

		public unsafe long InvokeInt64Method(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			return JniEnvironment.StaticMethods.CallStaticLongMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}

		public unsafe float InvokeSingleMethod(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			return JniEnvironment.StaticMethods.CallStaticFloatMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}

		public unsafe JniObjectReference InvokeObjectMethod(string encodedMember, JniArgumentValue* parameters)
		{
			JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
			return JniEnvironment.StaticMethods.CallStaticObjectMethod(GetMethodDeclaringType(methodInfo).PeerReference, methodInfo, parameters);
		}
	}

	private bool isInterface;

	private JniType? jniPeerType;

	private JniInstanceMethods instanceMethods;

	private JniInstanceFields instanceFields;

	private JniStaticMethods staticMethods;

	private JniStaticFields staticFields;

	public Type ManagedPeerType { get; private set; }

	public string JniPeerTypeName { get; private set; }

	public JniType JniPeerType
	{
		get
		{
			JniType cachedJniType = JniType.GetCachedJniType(ref jniPeerType, JniPeerTypeName);
			cachedJniType.RegisterWithRuntime();
			return cachedJniType;
		}
	}

	public JniInstanceMethods InstanceMethods => Assert(instanceMethods);

	public JniInstanceFields InstanceFields => Assert(instanceFields);

	public JniStaticMethods StaticMethods => Assert(staticMethods);

	public JniStaticFields StaticFields => Assert(staticFields);

	public JniPeerMembers(string jniPeerTypeName, Type managedPeerType, bool isInterface)
		: this(jniPeerTypeName = GetReplacementType(jniPeerTypeName), managedPeerType, checkManagedPeerType: true, isInterface)
	{
	}

	public JniPeerMembers(string jniPeerTypeName, Type managedPeerType)
		: this(jniPeerTypeName = GetReplacementType(jniPeerTypeName), managedPeerType, checkManagedPeerType: true, isInterface: false)
	{
	}

	private static string GetReplacementType(string jniPeerTypeName)
	{
		string replacementType = JniEnvironment.Runtime.TypeManager.GetReplacementType(jniPeerTypeName);
		if (replacementType != null)
		{
			return replacementType;
		}
		return jniPeerTypeName;
	}

	private JniPeerMembers(string jniPeerTypeName, Type managedPeerType, bool checkManagedPeerType, bool isInterface = false)
	{
		if (jniPeerTypeName == null)
		{
			throw new ArgumentNullException("jniPeerTypeName");
		}
		if (checkManagedPeerType)
		{
			if (managedPeerType == null)
			{
				throw new ArgumentNullException("managedPeerType");
			}
			if (!typeof(IJavaPeerable).IsAssignableFrom(managedPeerType))
			{
				throw new ArgumentException("'managedPeerType' must implement the IJavaPeerable interface.", "managedPeerType");
			}
		}
		JniPeerTypeName = jniPeerTypeName;
		ManagedPeerType = managedPeerType;
		this.isInterface = isInterface;
		instanceMethods = new JniInstanceMethods(this);
		instanceFields = new JniInstanceFields(this);
		staticMethods = new JniStaticMethods(this);
		staticFields = new JniStaticFields(this);
	}

	private static T Assert<T>(T value) where T : class
	{
		if (value == null)
		{
			throw new ObjectDisposedException("JniPeerMembers");
		}
		return value;
	}

	protected virtual bool UsesVirtualDispatch(IJavaPeerable value, Type? declaringType)
	{
		if (!(value.GetType() == declaringType) && !(declaringType == null))
		{
			return value.GetType() == value.JniPeerMembers.ManagedPeerType;
		}
		return true;
	}

	protected virtual JniPeerMembers GetPeerMembers(IJavaPeerable value)
	{
		if (!isInterface)
		{
			return value.JniPeerMembers;
		}
		return this;
	}

	internal static void AssertSelf(IJavaPeerable self)
	{
		if (self == null)
		{
			throw new ArgumentNullException("self");
		}
		if (!self.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(self);
		}
	}

	internal static int GetSignatureSeparatorIndex(string encodedMember)
	{
		if (encodedMember == null)
		{
			throw new ArgumentNullException("encodedMember");
		}
		int num = encodedMember.IndexOf(".", StringComparison.Ordinal);
		if (num < 0)
		{
			throw new ArgumentException("Invalid encoding; 'encodedMember' should be encoded as \"<NAME>.<SIGNATURE>\".", "encodedMember");
		}
		if (encodedMember.Length <= num + 1)
		{
			throw new ArgumentException("Invalid encoding; 'encodedMember' is missing a JNI signature, and should be in the format \"<NAME>.<SIGNATURE>\".", "encodedMember");
		}
		return num;
	}

	internal static void GetNameAndSignature(string encodedMember, out string name, out string signature)
	{
		int signatureSeparatorIndex = GetSignatureSeparatorIndex(encodedMember);
		name = encodedMember.Substring(0, signatureSeparatorIndex);
		signature = encodedMember.Substring(signatureSeparatorIndex + 1);
	}
}
