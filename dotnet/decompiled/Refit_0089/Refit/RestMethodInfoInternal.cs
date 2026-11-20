using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Refit;

[DebuggerDisplay("{MethodInfo}")]
internal class RestMethodInfoInternal
{
	private static readonly Regex ParameterRegex = new Regex("{(.*?)}");

	private static readonly HttpMethod PatchMethod = new HttpMethod("PATCH");

	private int HeaderCollectionParameterIndex { get; set; }

	public string Name { get; set; }

	public Type Type { get; set; }

	public MethodInfo MethodInfo { get; set; }

	public HttpMethod HttpMethod { get; set; }

	public string RelativePath { get; set; }

	public bool IsMultipart { get; private set; }

	public string MultipartBoundary { get; private set; }

	public ParameterInfo? CancellationToken { get; set; }

	public UriFormat QueryUriFormat { get; set; }

	public Dictionary<string, string?> Headers { get; set; }

	public Dictionary<int, string> HeaderParameterMap { get; set; }

	public Dictionary<int, string> PropertyParameterMap { get; set; }

	public Tuple<BodySerializationMethod, bool, int>? BodyParameterInfo { get; set; }

	public Tuple<string, int>? AuthorizeParameterInfo { get; set; }

	public Dictionary<int, string> QueryParameterMap { get; set; }

	public Dictionary<int, Tuple<string, string>> AttachmentNameMap { get; set; }

	public ParameterInfo[] ParameterInfoArray { get; set; }

	public Dictionary<int, RestMethodParameterInfo> ParameterMap { get; set; }

	public Type ReturnType { get; set; }

	public Type ReturnResultType { get; set; }

	public Type DeserializedResultType { get; set; }

	public RefitSettings RefitSettings { get; set; }

	public bool IsApiResponse { get; }

	public bool ShouldDisposeResponse { get; private set; }

	public bool HasHeaderCollection => HeaderCollectionParameterIndex >= 0;

	public RestMethodInfoInternal(Type targetInterface, MethodInfo methodInfo, RefitSettings? refitSettings = null)
	{
		RefitSettings = refitSettings ?? new RefitSettings();
		Type = targetInterface ?? throw new ArgumentNullException("targetInterface");
		Name = methodInfo.Name;
		MethodInfo = methodInfo ?? throw new ArgumentNullException("methodInfo");
		HttpMethodAttribute httpMethodAttribute = methodInfo.GetCustomAttributes(inherit: true).OfType<HttpMethodAttribute>().First();
		HttpMethod = httpMethodAttribute.Method;
		RelativePath = httpMethodAttribute.Path;
		IsMultipart = methodInfo.GetCustomAttributes(inherit: true).OfType<MultipartAttribute>().Any();
		MultipartBoundary = ((!IsMultipart) ? string.Empty : (methodInfo.GetCustomAttribute<MultipartAttribute>(inherit: true)?.BoundaryText ?? new MultipartAttribute().BoundaryText));
		VerifyUrlPathIsSane(RelativePath);
		DetermineReturnTypeInfo(methodInfo);
		DetermineIfResponseMustBeDisposed();
		ParameterInfoArray = (from p in methodInfo.GetParameters()
			where p.ParameterType != typeof(CancellationToken)
			select p).ToArray();
		ParameterMap = BuildParameterMap(RelativePath, ParameterInfoArray);
		BodyParameterInfo = FindBodyParameter(ParameterInfoArray, IsMultipart, httpMethodAttribute.Method);
		AuthorizeParameterInfo = FindAuthorizationParameter(ParameterInfoArray);
		Headers = ParseHeaders(methodInfo);
		HeaderParameterMap = BuildHeaderParameterMap(ParameterInfoArray);
		HeaderCollectionParameterIndex = GetHeaderCollectionParameterIndex(ParameterInfoArray);
		PropertyParameterMap = BuildRequestPropertyMap(ParameterInfoArray);
		Dictionary<int, Tuple<string, string>> dictionary = null;
		if (IsMultipart)
		{
			for (int num = 0; num < ParameterInfoArray.Length; num++)
			{
				if (ParameterMap.ContainsKey(num) || HeaderParameterMap.ContainsKey(num) || PropertyParameterMap.ContainsKey(num) || HeaderCollectionAt(num))
				{
					continue;
				}
				string attachmentNameForParameter = GetAttachmentNameForParameter(ParameterInfoArray[num]);
				if (attachmentNameForParameter != null)
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<int, Tuple<string, string>>();
					}
					dictionary[num] = Tuple.Create(attachmentNameForParameter, GetUrlNameForParameter(ParameterInfoArray[num]));
				}
			}
		}
		AttachmentNameMap = dictionary ?? EmptyDictionary<int, Tuple<string, string>>.Get();
		Dictionary<int, string> dictionary2 = null;
		for (int num2 = 0; num2 < ParameterInfoArray.Length; num2++)
		{
			if (!ParameterMap.ContainsKey(num2) && !HeaderParameterMap.ContainsKey(num2) && !PropertyParameterMap.ContainsKey(num2) && !HeaderCollectionAt(num2) && (BodyParameterInfo == null || BodyParameterInfo.Item3 != num2) && (AuthorizeParameterInfo == null || AuthorizeParameterInfo.Item2 != num2))
			{
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<int, string>();
				}
				dictionary2.Add(num2, GetUrlNameForParameter(ParameterInfoArray[num2]));
			}
		}
		QueryParameterMap = dictionary2 ?? EmptyDictionary<int, string>.Get();
		if ((from p in methodInfo.GetParameters()
			where p.ParameterType == typeof(CancellationToken)
			select p).TryGetSingle(out ParameterInfo value) == EnumerablePeek.Many)
		{
			throw new ArgumentException("Argument list to method \"" + methodInfo.Name + "\" can only contain a single CancellationToken");
		}
		CancellationToken = value;
		QueryUriFormat = methodInfo.GetCustomAttribute<QueryUriFormatAttribute>()?.UriFormat ?? UriFormat.UriEscaped;
		IsApiResponse = (ReturnResultType.GetTypeInfo().IsGenericType && (ReturnResultType.GetGenericTypeDefinition() == typeof(ApiResponse<>) || ReturnResultType.GetGenericTypeDefinition() == typeof(IApiResponse<>))) || ReturnResultType == typeof(IApiResponse);
	}

	public bool HeaderCollectionAt(int index)
	{
		if (HeaderCollectionParameterIndex >= 0)
		{
			return HeaderCollectionParameterIndex == index;
		}
		return false;
	}

	private static int GetHeaderCollectionParameterIndex(ParameterInfo[] parameterArray)
	{
		int num = -1;
		for (int i = 0; i < parameterArray.Length; i++)
		{
			ParameterInfo parameterInfo = parameterArray[i];
			if (parameterInfo.GetCustomAttributes(inherit: true).OfType<HeaderCollectionAttribute>().FirstOrDefault() != null)
			{
				if (!parameterInfo.ParameterType.IsAssignableFrom(typeof(IDictionary<string, string>)))
				{
					throw new ArgumentException("HeaderCollection parameter of type " + parameterInfo.ParameterType.Name + " is not assignable from IDictionary<string, string>");
				}
				if (num >= 0)
				{
					throw new ArgumentException("Only one parameter can be a HeaderCollection parameter");
				}
				num = i;
			}
		}
		return num;
	}

	public RestMethodInfo ToRestMethodInfo()
	{
		return new RestMethodInfo(Name, Type, MethodInfo, RelativePath, ReturnType);
	}

	private static Dictionary<int, string> BuildRequestPropertyMap(ParameterInfo[] parameterArray)
	{
		Dictionary<int, string> dictionary = null;
		for (int i = 0; i < parameterArray.Length; i++)
		{
			ParameterInfo parameterInfo = parameterArray[i];
			PropertyAttribute propertyAttribute = parameterInfo.GetCustomAttributes(inherit: true).OfType<PropertyAttribute>().FirstOrDefault();
			if (propertyAttribute != null)
			{
				string value = ((!string.IsNullOrEmpty(propertyAttribute.Key)) ? propertyAttribute.Key : parameterInfo.Name);
				if (dictionary == null)
				{
					dictionary = new Dictionary<int, string>();
				}
				dictionary[i] = value;
			}
		}
		return dictionary ?? EmptyDictionary<int, string>.Get();
	}

	private static IEnumerable<PropertyInfo> GetParameterProperties(ParameterInfo parameter)
	{
		return from p in parameter.ParameterType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.CanRead && (p.GetMethod?.IsPublic ?? false)
			select p;
	}

	private static void VerifyUrlPathIsSane(string relativePath)
	{
		if (!string.IsNullOrEmpty(relativePath))
		{
			if (!relativePath.StartsWith("/"))
			{
				throw new ArgumentException("URL path " + relativePath + " must start with '/' and be of the form '/foo/bar/baz'");
			}
			if (relativePath.Contains('\r') || relativePath.Contains('\n'))
			{
				throw new ArgumentException("URL path " + relativePath + " must not contain CR or LF characters");
			}
		}
	}

	private static Dictionary<int, RestMethodParameterInfo> BuildParameterMap(string relativePath, ParameterInfo[] parameterInfo)
	{
		Dictionary<int, RestMethodParameterInfo> dictionary = new Dictionary<int, RestMethodParameterInfo>();
		List<Match> list = relativePath.Split('/', '?').SelectMany((string x) => ParameterRegex.Matches(x).Cast<Match>()).ToList();
		if (list.Count > 0)
		{
			Dictionary<string, ParameterInfo> dictionary2 = parameterInfo.ToDictionary((ParameterInfo k) => GetUrlNameForParameter(k).ToLowerInvariant(), (ParameterInfo v) => v);
			Dictionary<string, Tuple<ParameterInfo, PropertyInfo>> dictionary3 = (from i in parameterInfo.Where((ParameterInfo x) => x.ParameterType.GetTypeInfo().IsClass).SelectMany((ParameterInfo x) => from p in GetParameterProperties(x)
					select Tuple.Create(x, p))
				group i by (i.Item1.Name + "." + GetUrlNameForProperty(i.Item2)).ToLowerInvariant()).ToDictionary((IGrouping<string, Tuple<ParameterInfo, PropertyInfo>> k) => k.Key, (IGrouping<string, Tuple<ParameterInfo, PropertyInfo>> v) => v.First());
			foreach (Match item in list)
			{
				string text = item.Groups[1].Value.ToLowerInvariant();
				bool flag = text.StartsWith("**");
				string text2 = ((!flag) ? text : text.Substring(2));
				if (dictionary2.TryGetValue(text2, out var value))
				{
					Type parameterType = value.ParameterType;
					if (flag && parameterType != typeof(string))
					{
						throw new ArgumentException($"URL {relativePath} has round-tripping parameter {text}, but the type of matched method parameter is {parameterType.FullName}. It must be a string.");
					}
					ParameterType type = (flag ? ParameterType.RoundTripping : ParameterType.Normal);
					RestMethodParameterInfo restMethodParameterInfo = new RestMethodParameterInfo(text2, value)
					{
						Type = type
					};
					dictionary.TryAdd(Array.IndexOf(parameterInfo, restMethodParameterInfo.ParameterInfo), restMethodParameterInfo);
					continue;
				}
				if (dictionary3.TryGetValue(text2, out var value2) && !flag)
				{
					Tuple<ParameterInfo, PropertyInfo> tuple = value2;
					int key = Array.IndexOf(parameterInfo, tuple.Item1);
					if (dictionary.TryGetValue(key, out var value3))
					{
						if (!value3.IsObjectPropertyParameter)
						{
							throw new ArgumentException("Parameter " + tuple.Item1.Name + " matches both a parameter and nested parameter on a parameter object");
						}
						value3.ParameterProperties.Add(new RestMethodParameterProperty(text2, tuple.Item2));
					}
					else
					{
						RestMethodParameterInfo restMethodParameterInfo2 = new RestMethodParameterInfo(isObjectPropertyParameter: true, tuple.Item1);
						restMethodParameterInfo2.ParameterProperties.Add(new RestMethodParameterProperty(text2, tuple.Item2));
						dictionary.TryAdd(Array.IndexOf(parameterInfo, restMethodParameterInfo2.ParameterInfo), restMethodParameterInfo2);
					}
					continue;
				}
				throw new ArgumentException($"URL {relativePath} has parameter {text}, but no method parameter matches");
			}
		}
		return dictionary;
	}

	private static string GetUrlNameForParameter(ParameterInfo paramInfo)
	{
		AliasAsAttribute aliasAsAttribute = paramInfo.GetCustomAttributes(inherit: true).OfType<AliasAsAttribute>().FirstOrDefault();
		if (aliasAsAttribute == null)
		{
			return paramInfo.Name;
		}
		return aliasAsAttribute.Name;
	}

	private static string GetUrlNameForProperty(PropertyInfo propInfo)
	{
		AliasAsAttribute aliasAsAttribute = propInfo.GetCustomAttributes(inherit: true).OfType<AliasAsAttribute>().FirstOrDefault();
		if (aliasAsAttribute == null)
		{
			return propInfo.Name;
		}
		return aliasAsAttribute.Name;
	}

	private static string GetAttachmentNameForParameter(ParameterInfo paramInfo)
	{
		object obj = paramInfo.GetCustomAttributes<AttachmentNameAttribute>(inherit: true).FirstOrDefault()?.Name;
		if (obj == null)
		{
			AliasAsAttribute? aliasAsAttribute = paramInfo.GetCustomAttributes<AliasAsAttribute>(inherit: true).FirstOrDefault();
			if (aliasAsAttribute == null)
			{
				return null;
			}
			obj = aliasAsAttribute.Name;
		}
		return (string)obj;
	}

	private Tuple<BodySerializationMethod, bool, int>? FindBodyParameter(ParameterInfo[] parameterArray, bool isMultipart, HttpMethod method)
	{
		(ParameterInfo, BodyAttribute) value;
		EnumerablePeek enumerablePeek = (from x in parameterArray
			select (Parameter: x, BodyAttribute: x.GetCustomAttributes(inherit: true).OfType<BodyAttribute>().FirstOrDefault()) into x
			where x.BodyAttribute != null
			select x).TryGetSingle(out value);
		if (isMultipart)
		{
			if (enumerablePeek != EnumerablePeek.Empty)
			{
				throw new ArgumentException("Multipart requests may not contain a Body parameter");
			}
			return null;
		}
		switch (enumerablePeek)
		{
		case EnumerablePeek.Many:
			throw new ArgumentException("Only one parameter can be a Body parameter");
		case EnumerablePeek.Single:
			return Tuple.Create(value.Item2.SerializationMethod, value.Item2.Buffered ?? RefitSettings.Buffered, Array.IndexOf(parameterArray, value.Item1));
		default:
		{
			if (!method.Equals(System.Net.Http.HttpMethod.Post) && !method.Equals(System.Net.Http.HttpMethod.Put) && !method.Equals(PatchMethod))
			{
				return null;
			}
			ParameterInfo value2;
			return parameterArray.Where((ParameterInfo pi) => !pi.ParameterType.GetTypeInfo().IsValueType && pi.ParameterType != typeof(string) && pi.GetCustomAttribute<QueryAttribute>() == null && pi.GetCustomAttribute<HeaderCollectionAttribute>() == null && pi.GetCustomAttribute<PropertyAttribute>() == null).TryGetSingle(out value2) switch
			{
				EnumerablePeek.Many => throw new ArgumentException("Multiple complex types found. Specify one parameter as the body using BodyAttribute"), 
				EnumerablePeek.Single => Tuple.Create(BodySerializationMethod.Serialized, RefitSettings.Buffered, Array.IndexOf(parameterArray, value2)), 
				_ => null, 
			};
		}
		}
	}

	private static Tuple<string, int>? FindAuthorizationParameter(ParameterInfo[] parameterArray)
	{
		(ParameterInfo, AuthorizeAttribute) value;
		return (from x in parameterArray
			select (Parameter: x, AuthorizeAttribute: x.GetCustomAttributes(inherit: true).OfType<AuthorizeAttribute>().FirstOrDefault()) into x
			where x.AuthorizeAttribute != null
			select x).TryGetSingle(out value) switch
		{
			EnumerablePeek.Many => throw new ArgumentException("Only one parameter can be an Authorize parameter"), 
			EnumerablePeek.Single => Tuple.Create(value.Item2.Scheme, Array.IndexOf(parameterArray, value.Item1)), 
			_ => null, 
		};
	}

	private static Dictionary<string, string?> ParseHeaders(MethodInfo methodInfo)
	{
		IEnumerable<object> first;
		if (!(methodInfo.DeclaringType != null))
		{
			IEnumerable<object> enumerable = Array.Empty<object>();
			first = enumerable;
		}
		else
		{
			first = methodInfo.DeclaringType.GetInterfaces().SelectMany((Type i) => i.GetTypeInfo().GetCustomAttributes(inherit: true)).Reverse();
		}
		object[] second = ((methodInfo.DeclaringType != null) ? methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(inherit: true) : Array.Empty<object>());
		IEnumerable<string> enumerable2 = first.Concat(second).Concat(methodInfo.GetCustomAttributes(inherit: true)).OfType<HeadersAttribute>()
			.SelectMany((HeadersAttribute ha) => ha.Headers);
		Dictionary<string, string> dictionary = null;
		foreach (string item in enumerable2)
		{
			if (!string.IsNullOrWhiteSpace(item))
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<string, string>();
				}
				string[] array = item.Split(':');
				dictionary[array[0].Trim()] = ((array.Length > 1) ? string.Join(":", array.Skip(1)).Trim() : null);
			}
		}
		return dictionary ?? EmptyDictionary<string, string>.Get();
	}

	private static Dictionary<int, string> BuildHeaderParameterMap(ParameterInfo[] parameterArray)
	{
		Dictionary<int, string> dictionary = null;
		for (int i = 0; i < parameterArray.Length; i++)
		{
			string text = (from ha in parameterArray[i].GetCustomAttributes(inherit: true).OfType<HeaderAttribute>()
				select ha.Header).FirstOrDefault();
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<int, string>();
				}
				dictionary[i] = text.Trim();
			}
		}
		return dictionary ?? EmptyDictionary<int, string>.Get();
	}

	private void DetermineReturnTypeInfo(MethodInfo methodInfo)
	{
		Type returnType = methodInfo.ReturnType;
		if (returnType.IsGenericType && (methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>) || methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(ValueTask<>) || methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(IObservable<>)))
		{
			ReturnType = returnType;
			ReturnResultType = returnType.GetGenericArguments()[0];
			if (ReturnResultType.IsGenericType && (ReturnResultType.GetGenericTypeDefinition() == typeof(ApiResponse<>) || ReturnResultType.GetGenericTypeDefinition() == typeof(IApiResponse<>)))
			{
				DeserializedResultType = ReturnResultType.GetGenericArguments()[0];
			}
			else if (ReturnResultType == typeof(IApiResponse))
			{
				DeserializedResultType = typeof(HttpContent);
			}
			else
			{
				DeserializedResultType = ReturnResultType;
			}
		}
		else
		{
			if (!(returnType == typeof(Task)))
			{
				throw new ArgumentException("Method \"" + methodInfo.Name + "\" is invalid. All REST Methods must return either Task<T> or ValueTask<T> or IObservable<T>");
			}
			ReturnType = methodInfo.ReturnType;
			ReturnResultType = typeof(void);
			DeserializedResultType = typeof(void);
		}
	}

	private void DetermineIfResponseMustBeDisposed()
	{
		ShouldDisposeResponse = DeserializedResultType != typeof(HttpResponseMessage) && DeserializedResultType != typeof(HttpContent) && DeserializedResultType != typeof(Stream);
	}
}
