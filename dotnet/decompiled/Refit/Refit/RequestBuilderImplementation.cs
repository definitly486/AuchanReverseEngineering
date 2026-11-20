using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Refit;

internal class RequestBuilderImplementation<TApi> : RequestBuilderImplementation, IRequestBuilder<TApi>, IRequestBuilder
{
	public RequestBuilderImplementation(RefitSettings? refitSettings = null)
		: base(typeof(TApi), refitSettings)
	{
	}
}
internal class RequestBuilderImplementation : IRequestBuilder
{
	private sealed class TaskToObservable<T> : IObservable<T?>
	{
		private readonly Func<CancellationToken, Task<T?>> taskFactory;

		public TaskToObservable(Func<CancellationToken, Task<T?>> taskFactory)
		{
			this.taskFactory = taskFactory;
		}

		public IDisposable Subscribe(IObserver<T?> observer)
		{
			CancellationTokenSource cts = new CancellationTokenSource();
			taskFactory(cts.Token).ContinueWith(delegate(Task<T?> t)
			{
				if (!cts.IsCancellationRequested)
				{
					ToObservableDone(t, observer);
				}
			}, TaskScheduler.Default);
			return new AnonymousDisposable(cts.Cancel);
		}

		private static void ToObservableDone<TResult>(Task<TResult?> task, IObserver<TResult?> subject)
		{
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				subject.OnNext(task.Result);
				subject.OnCompleted();
				break;
			case TaskStatus.Faulted:
				subject.OnError(task.Exception.InnerException);
				break;
			case TaskStatus.Canceled:
				subject.OnError(new TaskCanceledException(task));
				break;
			}
		}
	}

	private static readonly QueryAttribute DefaultQueryAttribute = new QueryAttribute();

	private static readonly Uri BaseUri = new Uri("http://api");

	private readonly Dictionary<string, List<RestMethodInfoInternal>> interfaceHttpMethods;

	private readonly ConcurrentDictionary<CloseGenericMethodKey, RestMethodInfoInternal> interfaceGenericHttpMethods;

	private readonly IHttpContentSerializer serializer;

	private readonly RefitSettings settings;

	public Type TargetType { get; }

	public RequestBuilderImplementation(Type refitInterfaceType, RefitSettings? refitSettings = null)
	{
		Type[] interfaces = refitInterfaceType.GetInterfaces();
		settings = refitSettings ?? new RefitSettings();
		serializer = settings.ContentSerializer;
		interfaceGenericHttpMethods = new ConcurrentDictionary<CloseGenericMethodKey, RestMethodInfoInternal>();
		if (refitInterfaceType == null || !refitInterfaceType.GetTypeInfo().IsInterface)
		{
			throw new ArgumentException("targetInterface must be an Interface");
		}
		TargetType = refitInterfaceType;
		Dictionary<string, List<RestMethodInfoInternal>> methods = new Dictionary<string, List<RestMethodInfoInternal>>();
		AddInterfaceHttpMethods(refitInterfaceType, methods);
		Type[] array = interfaces;
		foreach (Type interfaceType in array)
		{
			AddInterfaceHttpMethods(interfaceType, methods);
		}
		interfaceHttpMethods = methods;
	}

	private void AddInterfaceHttpMethods(Type interfaceType, Dictionary<string, List<RestMethodInfoInternal>> methods)
	{
		foreach (MethodInfo item2 in from i in interfaceType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where i.IsAbstract
			select i)
		{
			if (item2.GetCustomAttributes(inherit: true).OfType<HttpMethodAttribute>().Any())
			{
				if (!methods.TryGetValue(item2.Name, out List<RestMethodInfoInternal> value))
				{
					value = new List<RestMethodInfoInternal>();
					methods.Add(item2.Name, value);
				}
				RestMethodInfoInternal item = new RestMethodInfoInternal(interfaceType, item2, settings);
				value.Add(item);
			}
		}
	}

	private RestMethodInfoInternal FindMatchingRestMethodInfo(string key, Type[]? parameterTypes, Type[]? genericArgumentTypes)
	{
		if (!interfaceHttpMethods.TryGetValue(key, out List<RestMethodInfoInternal> value))
		{
			throw new ArgumentException("Method must be defined and have an HTTP Method attribute");
		}
		if (parameterTypes == null)
		{
			if (value.Count > 1)
			{
				throw new ArgumentException("MethodName exists more than once, 'parameterTypes' mut be defined");
			}
			return CloseGenericMethodIfNeeded(value[0], genericArgumentTypes);
		}
		Type[]? array = genericArgumentTypes;
		bool num = array != null && array.Length != 0;
		IEnumerable<RestMethodInfoInternal> source = value.Where((RestMethodInfoInternal method) => method.MethodInfo.GetParameters().Length == parameterTypes.Length);
		source = ((!num) ? source.Where((RestMethodInfoInternal method) => !method.MethodInfo.IsGenericMethod) : source.Where((RestMethodInfoInternal method) => method.MethodInfo.IsGenericMethod && method.MethodInfo.GetGenericArguments().Length == genericArgumentTypes.Length));
		RestMethodInfoInternal[] array2 = source.ToArray();
		if (array2.Length == 1)
		{
			return CloseGenericMethodIfNeeded(array2[0], genericArgumentTypes);
		}
		RestMethodInfoInternal[] array3 = array2;
		foreach (RestMethodInfoInternal restMethodInfoInternal in array3)
		{
			if ((from p in restMethodInfoInternal.MethodInfo.GetParameters()
				select p.ParameterType).SequenceEqual(parameterTypes))
			{
				return CloseGenericMethodIfNeeded(restMethodInfoInternal, genericArgumentTypes);
			}
		}
		throw new Exception("No suitable Method found...");
	}

	private RestMethodInfoInternal CloseGenericMethodIfNeeded(RestMethodInfoInternal restMethodInfo, Type[]? genericArgumentTypes)
	{
		if (genericArgumentTypes != null)
		{
			return interfaceGenericHttpMethods.GetOrAdd(new CloseGenericMethodKey(restMethodInfo.MethodInfo, genericArgumentTypes), (CloseGenericMethodKey _) => new RestMethodInfoInternal(restMethodInfo.Type, restMethodInfo.MethodInfo.MakeGenericMethod(genericArgumentTypes), restMethodInfo.RefitSettings));
		}
		return restMethodInfo;
	}

	public Func<HttpClient, object[], object?> BuildRestResultFuncForMethod(string methodName, Type[]? parameterTypes = null, Type[]? genericArgumentTypes = null)
	{
		if (!interfaceHttpMethods.ContainsKey(methodName))
		{
			throw new ArgumentException("Method must be defined and have an HTTP Method attribute");
		}
		RestMethodInfoInternal restMethodInfoInternal = FindMatchingRestMethodInfo(methodName, parameterTypes, genericArgumentTypes);
		if (restMethodInfoInternal.ReturnType == typeof(Task))
		{
			return BuildVoidTaskFuncForMethod(restMethodInfoInternal);
		}
		object[] parameters;
		if (restMethodInfoInternal.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
		{
			MethodInfo method = typeof(RequestBuilderImplementation).GetMethod("BuildTaskFuncForMethod", BindingFlags.Instance | BindingFlags.NonPublic);
			MethodInfo methodInfo = method.MakeGenericMethod(restMethodInfoInternal.ReturnResultType, restMethodInfoInternal.DeserializedResultType);
			parameters = new RestMethodInfoInternal[1] { restMethodInfoInternal };
			MulticastDelegate taskFunc = (MulticastDelegate)methodInfo.Invoke(this, parameters);
			return (HttpClient client, object[] args) => taskFunc.DynamicInvoke(client, args);
		}
		MethodInfo method2 = typeof(RequestBuilderImplementation).GetMethod("BuildRxFuncForMethod", BindingFlags.Instance | BindingFlags.NonPublic);
		MethodInfo methodInfo2 = method2.MakeGenericMethod(restMethodInfoInternal.ReturnResultType, restMethodInfoInternal.DeserializedResultType);
		parameters = new RestMethodInfoInternal[1] { restMethodInfoInternal };
		MulticastDelegate rxFunc = (MulticastDelegate)methodInfo2.Invoke(this, parameters);
		return (HttpClient client, object[] args) => rxFunc.DynamicInvoke(client, args);
	}

	private void AddMultipartItem(MultipartFormDataContent multiPartContent, string fileName, string parameterName, object itemValue)
	{
		if (itemValue is HttpContent content)
		{
			multiPartContent.Add(content);
			return;
		}
		if (itemValue is MultipartItem multipartItem)
		{
			HttpContent content2 = multipartItem.ToContent();
			multiPartContent.Add(content2, multipartItem.Name ?? parameterName, string.IsNullOrEmpty(multipartItem.FileName) ? fileName : multipartItem.FileName);
			return;
		}
		if (itemValue is Stream content3)
		{
			StreamContent content4 = new StreamContent(content3);
			multiPartContent.Add(content4, parameterName, fileName);
			return;
		}
		if (itemValue is string content5)
		{
			multiPartContent.Add(new StringContent(content5), parameterName);
			return;
		}
		if (itemValue is FileInfo fileInfo)
		{
			StreamContent content6 = new StreamContent(fileInfo.OpenRead());
			multiPartContent.Add(content6, parameterName, fileInfo.Name);
			return;
		}
		if (itemValue is byte[] content7)
		{
			ByteArrayContent content8 = new ByteArrayContent(content7);
			multiPartContent.Add(content8, parameterName, fileName);
			return;
		}
		Exception innerException;
		try
		{
			multiPartContent.Add(settings.ContentSerializer.ToHttpContent(itemValue), parameterName);
			return;
		}
		catch (Exception ex)
		{
			innerException = ex;
		}
		throw new ArgumentException($"Unexpected parameter type in a Multipart request. Parameter {fileName} is of type {itemValue.GetType().Name}, whereas allowed types are String, Stream, FileInfo, Byte array and anything that's JSON serializable", "itemValue", innerException);
	}

	private Func<HttpClient, CancellationToken, object[], Task<T?>> BuildCancellableTaskFuncForMethod<T, TBody>(RestMethodInfoInternal restMethod)
	{
		return async delegate(HttpClient client, CancellationToken ct, object[] paramList)
		{
			if (client.BaseAddress == null)
			{
				throw new InvalidOperationException("BaseAddress must be set on the HttpClient instance");
			}
			Func<object[], HttpRequestMessage> func = BuildRequestFactoryForMethod(restMethod, client.BaseAddress.AbsolutePath, restMethod.CancellationToken != null);
			HttpRequestMessage rq = func(paramList);
			HttpResponseMessage resp = null;
			HttpContent content = null;
			bool disposeResponse = true;
			try
			{
				if (IsBodyBuffered(restMethod, rq))
				{
					await rq.Content.LoadIntoBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				resp = await client.SendAsync(rq, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(continueOnCapturedContext: false);
				content = resp.Content ?? new StringContent(string.Empty);
				Exception e = null;
				disposeResponse = restMethod.ShouldDisposeResponse;
				if (typeof(T) != typeof(HttpResponseMessage))
				{
					e = await settings.ExceptionFactory(resp).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (restMethod.IsApiResponse)
				{
					TBody body = default(TBody);
					try
					{
						TBody val = ((e != null) ? default(TBody) : (await DeserializeContentAsync<TBody>(resp, content, ct).ConfigureAwait(continueOnCapturedContext: false)));
						body = val;
					}
					catch (Exception ex)
					{
						e = ((settings.DeserializationExceptionFactory == null) ? (await ApiException.Create("An error occured deserializing the response.", resp.RequestMessage, resp.RequestMessage.Method, resp, settings, ex)) : (await settings.DeserializationExceptionFactory(resp, ex).ConfigureAwait(continueOnCapturedContext: false)));
					}
					return ApiResponse.Create<T, TBody>(resp, body, settings, e as ApiException);
				}
				if (e != null)
				{
					disposeResponse = false;
					throw e;
				}
				try
				{
					return await DeserializeContentAsync<T>(resp, content, ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex2)
				{
					if (settings.DeserializationExceptionFactory != null)
					{
						Exception ex3 = await settings.DeserializationExceptionFactory(resp, ex2).ConfigureAwait(continueOnCapturedContext: false);
						if (ex3 != null)
						{
							throw ex3;
						}
						return default(T);
					}
					throw await ApiException.Create("An error occured deserializing the response.", resp.RequestMessage, resp.RequestMessage.Method, resp, settings, ex2);
				}
			}
			finally
			{
				rq.Dispose();
				if (disposeResponse)
				{
					resp?.Dispose();
					content?.Dispose();
				}
			}
		};
	}

	private async Task<T?> DeserializeContentAsync<T>(HttpResponseMessage resp, HttpContent content, CancellationToken cancellationToken)
	{
		T result;
		if (typeof(T) == typeof(HttpResponseMessage))
		{
			result = (T)(object)resp;
		}
		else if (typeof(T) == typeof(HttpContent))
		{
			result = (T)(object)content;
		}
		else if (typeof(T) == typeof(Stream))
		{
			result = (T)(object)(await content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		}
		else if (typeof(T) == typeof(string))
		{
			using Stream stream = await content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			using StreamReader reader = new StreamReader(stream);
			result = (T)(object)(await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false));
		}
		else
		{
			result = await serializer.FromHttpContentAsync<T>(content, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		return result;
	}

	private List<KeyValuePair<string, object?>> BuildQueryMap(object? @object, string? delimiter = null, RestMethodParameterInfo? parameterInfo = null)
	{
		if (@object is IDictionary dictionary)
		{
			return BuildQueryMap(dictionary, delimiter);
		}
		List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
		if (@object == null)
		{
			return list;
		}
		foreach (PropertyInfo propertyInfo in from p in @object.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.CanRead && (p.GetMethod?.IsPublic ?? false)
			select p)
		{
			object obj = propertyInfo.GetValue(@object);
			if (obj == null || (parameterInfo != null && parameterInfo.IsObjectPropertyParameter && parameterInfo.ParameterProperties.Any((RestMethodParameterProperty x) => x.PropertyInfo == propertyInfo)))
			{
				continue;
			}
			string name = propertyInfo.Name;
			name = propertyInfo.GetCustomAttribute<AliasAsAttribute>()?.Name ?? settings.UrlParameterKeyFormatter.Format(name);
			QueryAttribute customAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();
			if (customAttribute != null && customAttribute.Format != null)
			{
				obj = settings.FormUrlEncodedParameterFormatter.Format(obj, customAttribute.Format);
			}
			if (!(obj is string) && obj is IEnumerable paramValues && !(obj is IDictionary))
			{
				foreach (string item in ParseEnumerableQueryParameterValue(paramValues, propertyInfo, propertyInfo.PropertyType, customAttribute))
				{
					list.Add(new KeyValuePair<string, object>(name, item));
				}
				continue;
			}
			if (DoNotConvertToQueryMap(obj))
			{
				list.Add(new KeyValuePair<string, object>(name, obj));
				continue;
			}
			if (obj is IDictionary dictionary2)
			{
				foreach (KeyValuePair<string, object> item2 in BuildQueryMap(dictionary2, delimiter))
				{
					list.Add(new KeyValuePair<string, object>(name + delimiter + item2.Key, item2.Value));
				}
				continue;
			}
			foreach (KeyValuePair<string, object> item3 in BuildQueryMap(obj, delimiter))
			{
				list.Add(new KeyValuePair<string, object>(name + delimiter + item3.Key, item3.Value));
			}
		}
		return list;
	}

	private List<KeyValuePair<string, object?>> BuildQueryMap(IDictionary dictionary, string? delimiter = null)
	{
		List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
		foreach (object key in dictionary.Keys)
		{
			object obj = dictionary[key];
			if (obj == null)
			{
				continue;
			}
			Type type = key.GetType();
			string text = settings.UrlParameterFormatter.Format(key, type, type);
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			if (DoNotConvertToQueryMap(obj))
			{
				list.Add(new KeyValuePair<string, object>(text, obj));
				continue;
			}
			foreach (KeyValuePair<string, object> item in BuildQueryMap(obj, delimiter))
			{
				list.Add(new KeyValuePair<string, object>(text + delimiter + item.Key, item.Value));
			}
		}
		return list;
	}

	private Func<object[], HttpRequestMessage> BuildRequestFactoryForMethod(RestMethodInfoInternal restMethod, string basePath, bool paramsContainsCancellationToken)
	{
		return delegate(object[] paramList)
		{
			if (paramsContainsCancellationToken)
			{
				paramList = paramList.Where((object o) => o == null || o.GetType() != typeof(CancellationToken)).ToArray();
			}
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage
			{
				Method = restMethod.HttpMethod
			};
			MultipartFormDataContent multiPartContent = null;
			if (restMethod.IsMultipart)
			{
				multiPartContent = (MultipartFormDataContent)(httpRequestMessage.Content = new MultipartFormDataContent(restMethod.MultipartBoundary));
			}
			string text = ((basePath == "/") ? string.Empty : basePath) + restMethod.RelativePath;
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			Dictionary<string, string> dictionary = ((restMethod.Headers.Count > 0) ? new Dictionary<string, string>(restMethod.Headers) : null);
			RestMethodParameterInfo restMethodParameterInfo = null;
			for (int num = 0; num < paramList.Length; num++)
			{
				bool flag = false;
				object obj = paramList[num];
				if (restMethod.ParameterMap.TryGetValue(num, out RestMethodParameterInfo value))
				{
					restMethodParameterInfo = value;
					if (restMethodParameterInfo.IsObjectPropertyParameter)
					{
						text = AddObjectParametersToUrl(restMethodParameterInfo, obj, text);
					}
					else
					{
						text = AddValueParameterToUrl(restMethod, value, obj, num, text);
						flag = true;
					}
				}
				if (restMethod.BodyParameterInfo != null && restMethod.BodyParameterInfo.Item3 == num)
				{
					AddBodyToRequest(restMethod, obj, httpRequestMessage);
					flag = true;
				}
				if (restMethod.HeaderParameterMap.TryGetValue(num, out string value2))
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<string, string>();
					}
					dictionary[value2] = obj?.ToString();
					flag = true;
				}
				if (restMethod.HeaderCollectionAt(num))
				{
					if (obj is IDictionary<string, string> dictionary2)
					{
						foreach (KeyValuePair<string, string> item in dictionary2)
						{
							if (dictionary == null)
							{
								dictionary = new Dictionary<string, string>();
							}
							dictionary[item.Key] = item.Value;
						}
					}
					flag = true;
				}
				if (restMethod.AuthorizeParameterInfo != null && restMethod.AuthorizeParameterInfo.Item2 == num)
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<string, string>();
					}
					dictionary["Authorization"] = $"{restMethod.AuthorizeParameterInfo.Item1} {obj}";
					flag = true;
				}
				if (restMethod.PropertyParameterMap.ContainsKey(num))
				{
					flag = true;
				}
				if (!flag && obj != null)
				{
					QueryAttribute customAttribute = restMethod.ParameterInfoArray[num].GetCustomAttribute<QueryAttribute>();
					if (!restMethod.IsMultipart || (restMethod.ParameterMap.ContainsKey(num) && restMethod.ParameterMap[num].IsObjectPropertyParameter) || customAttribute != null)
					{
						AddQueryParameters(restMethod, customAttribute, obj, list, num, restMethodParameterInfo);
					}
					else
					{
						AddMultiPart(restMethod, num, obj, multiPartContent);
					}
				}
			}
			AddHeadersToRequest(dictionary, httpRequestMessage);
			AddPropertiesToRequest(restMethod, httpRequestMessage, paramList);
			AddVersionToRequest(httpRequestMessage);
			UriBuilder uriBuilder = new UriBuilder(new Uri(BaseUri, text));
			ParseExistingQueryString(uriBuilder, list);
			if (list.Count != 0)
			{
				uriBuilder.Query = CreateQueryString(list);
			}
			else
			{
				uriBuilder.Query = null;
			}
			httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.GetComponents(UriComponents.PathAndQuery, restMethod.QueryUriFormat), UriKind.Relative);
			return httpRequestMessage;
		};
	}

	private string AddObjectParametersToUrl(RestMethodParameterInfo parameterInfo, object param, string urlTarget)
	{
		foreach (RestMethodParameterProperty parameterProperty in parameterInfo.ParameterProperties)
		{
			object value = parameterProperty.PropertyInfo.GetValue(param);
			urlTarget = Regex.Replace(urlTarget, "{" + parameterProperty.Name + "}", Uri.EscapeDataString(settings.UrlParameterFormatter.Format(value, parameterProperty.PropertyInfo, parameterProperty.PropertyInfo.PropertyType) ?? string.Empty), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
		}
		return urlTarget;
	}

	private string AddValueParameterToUrl(RestMethodInfoInternal restMethod, RestMethodParameterInfo parameterMapValue, object param, int i, string urlTarget)
	{
		string pattern;
		string replacement;
		if (parameterMapValue.Type == ParameterType.RoundTripping)
		{
			pattern = "{\\*\\*" + parameterMapValue.Name + "}";
			string text = (string)param;
			replacement = string.Join("/", from s in text.Split('/')
				select Uri.EscapeDataString(settings.UrlParameterFormatter.Format(s, restMethod.ParameterInfoArray[i], restMethod.ParameterInfoArray[i].ParameterType) ?? string.Empty));
		}
		else
		{
			pattern = "{" + parameterMapValue.Name + "}";
			replacement = Uri.EscapeDataString(settings.UrlParameterFormatter.Format(param, restMethod.ParameterInfoArray[i], restMethod.ParameterInfoArray[i].ParameterType) ?? string.Empty);
		}
		urlTarget = Regex.Replace(urlTarget, pattern, replacement, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
		return urlTarget;
	}

	private void AddBodyToRequest(RestMethodInfoInternal restMethod, object param, HttpRequestMessage ret)
	{
		if (param is HttpContent content)
		{
			ret.Content = content;
			return;
		}
		if (param is Stream content2)
		{
			ret.Content = new StreamContent(content2);
			return;
		}
		if (restMethod.BodyParameterInfo.Item1 == BodySerializationMethod.Default && param is string content3)
		{
			ret.Content = new StringContent(content3);
			return;
		}
		switch (restMethod.BodyParameterInfo.Item1)
		{
		case BodySerializationMethod.UrlEncoded:
			ret.Content = ((param is string stringToEscape) ? ((ByteArrayContent)new StringContent(Uri.EscapeDataString(stringToEscape), Encoding.UTF8, "application/x-www-form-urlencoded")) : ((ByteArrayContent)new FormUrlEncodedContent(new FormValueMultimap(param, settings))));
			break;
		case BodySerializationMethod.Default:
		case BodySerializationMethod.Json:
		case BodySerializationMethod.Serialized:
		{
			HttpContent content4 = serializer.ToHttpContent(param);
			if (!restMethod.BodyParameterInfo.Item2)
			{
				ret.Content = new PushStreamContent(async delegate(Stream stream, HttpContent _, TransportContext? __)
				{
					using (stream)
					{
						await content4.CopyToAsync(stream).ConfigureAwait(continueOnCapturedContext: false);
					}
				}, content4.Headers.ContentType);
			}
			else
			{
				ret.Content = content4;
			}
			break;
		}
		}
	}

	private void AddQueryParameters(RestMethodInfoInternal restMethod, QueryAttribute? queryAttribute, object param, List<KeyValuePair<string, string?>> queryParamsToAdd, int i, RestMethodParameterInfo? parameterInfo)
	{
		QueryAttribute queryAttribute2 = queryAttribute ?? DefaultQueryAttribute;
		if (DoNotConvertToQueryMap(param))
		{
			queryParamsToAdd.AddRange(ParseQueryParameter(param, restMethod.ParameterInfoArray[i], restMethod.QueryParameterMap[i], queryAttribute2));
			return;
		}
		foreach (KeyValuePair<string, object> item in BuildQueryMap(param, queryAttribute2.Delimiter, parameterInfo))
		{
			string queryPath = ((!string.IsNullOrWhiteSpace(queryAttribute2.Prefix)) ? (queryAttribute2.Prefix + queryAttribute2.Delimiter + item.Key) : item.Key);
			queryParamsToAdd.AddRange(ParseQueryParameter(item.Value, restMethod.ParameterInfoArray[i], queryPath, queryAttribute2));
		}
	}

	private void AddMultiPart(RestMethodInfoInternal restMethod, int i, object param, MultipartFormDataContent? multiPartContent)
	{
		string text;
		string parameterName;
		if (!restMethod.AttachmentNameMap.TryGetValue(i, out Tuple<string, string> value))
		{
			text = restMethod.QueryParameterMap[i];
			parameterName = text;
		}
		else
		{
			text = value.Item1;
			parameterName = value.Item2;
		}
		if (param is IEnumerable<object> enumerable)
		{
			{
				foreach (object item in enumerable)
				{
					AddMultipartItem(multiPartContent, text, parameterName, item);
				}
				return;
			}
		}
		AddMultipartItem(multiPartContent, text, parameterName, param);
	}

	private static void AddHeadersToRequest(Dictionary<string, string?>? headersToAdd, HttpRequestMessage ret)
	{
		if (headersToAdd == null || headersToAdd.Count <= 0)
		{
			return;
		}
		if (ret.Content == null && !IsBodyless(ret.Method))
		{
			ret.Content = new ByteArrayContent(Array.Empty<byte>());
		}
		foreach (KeyValuePair<string, string> item in headersToAdd)
		{
			SetHeader(ret, item.Key, item.Value);
		}
	}

	private void AddPropertiesToRequest(RestMethodInfoInternal restMethod, HttpRequestMessage ret, object[] paramList)
	{
		if (settings.HttpRequestMessageOptions != null)
		{
			foreach (KeyValuePair<string, object> httpRequestMessageOption in settings.HttpRequestMessageOptions)
			{
				ret.Options.Set(new HttpRequestOptionsKey<object>(httpRequestMessageOption.Key), httpRequestMessageOption.Value);
			}
		}
		for (int i = 0; i < paramList.Length; i++)
		{
			if (restMethod.PropertyParameterMap.TryGetValue(i, out string value))
			{
				ret.Options.Set(new HttpRequestOptionsKey<object>(value), paramList[i]);
			}
		}
		ret.Options.Set(new HttpRequestOptionsKey<Type>(HttpRequestMessageOptions.InterfaceType), TargetType);
		ret.Options.Set(new HttpRequestOptionsKey<RestMethodInfo>(HttpRequestMessageOptions.RestMethodInfo), restMethod.ToRestMethodInfo());
	}

	private void AddVersionToRequest(HttpRequestMessage ret)
	{
		ret.Version = settings.Version;
		ret.VersionPolicy = settings.VersionPolicy;
	}

	private IEnumerable<KeyValuePair<string, string?>> ParseQueryParameter(object? param, ParameterInfo parameterInfo, string queryPath, QueryAttribute queryAttribute)
	{
		if (!(param is string) && param is IEnumerable paramValues)
		{
			foreach (string item in ParseEnumerableQueryParameterValue(paramValues, parameterInfo, parameterInfo.ParameterType, queryAttribute))
			{
				yield return new KeyValuePair<string, string>(queryPath, item);
			}
		}
		else
		{
			yield return new KeyValuePair<string, string>(queryPath, settings.UrlParameterFormatter.Format(param, parameterInfo, parameterInfo.ParameterType));
		}
	}

	private IEnumerable<string?> ParseEnumerableQueryParameterValue(IEnumerable paramValues, ICustomAttributeProvider customAttributeProvider, Type type, QueryAttribute? queryAttribute)
	{
		string text;
		switch ((queryAttribute != null && queryAttribute.IsCollectionFormatSpecified) ? queryAttribute.CollectionFormat : settings.CollectionFormat)
		{
		case CollectionFormat.Multi:
			foreach (object paramValue in paramValues)
			{
				yield return settings.UrlParameterFormatter.Format(paramValue, customAttributeProvider, type);
			}
			yield break;
		case CollectionFormat.Ssv:
			text = " ";
			break;
		case CollectionFormat.Tsv:
			text = "\t";
			break;
		case CollectionFormat.Pipes:
			text = "|";
			break;
		default:
			text = ",";
			break;
		}
		string separator = text;
		IEnumerable<string> values = from object v in paramValues
			select settings.UrlParameterFormatter.Format(v, customAttributeProvider, type);
		yield return string.Join(separator, values);
	}

	private static void ParseExistingQueryString(UriBuilder uri, List<KeyValuePair<string, string?>> queryParamsToAdd)
	{
		if (string.IsNullOrEmpty(uri.Query))
		{
			return;
		}
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uri.Query);
		int num = 0;
		string[] allKeys = nameValueCollection.AllKeys;
		foreach (string text in allKeys)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				queryParamsToAdd.Insert(num++, new KeyValuePair<string, string>(text, nameValueCollection[text]));
			}
		}
	}

	private static string CreateQueryString(List<KeyValuePair<string, string?>> queryParamsToAdd)
	{
		Span<char> initialBuffer = stackalloc char[512];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		bool flag = true;
		foreach (KeyValuePair<string, string> item in queryParamsToAdd)
		{
			if (item.Key != null && item.Value != null)
			{
				if (!flag)
				{
					valueStringBuilder.Append('&');
				}
				string text = Uri.EscapeDataString(item.Key);
				if (valueStringBuilder.Length == 0 && text.Length > 0 && text[0] != '?')
				{
					valueStringBuilder.Append('?');
				}
				valueStringBuilder.Append(text);
				valueStringBuilder.Append('=');
				valueStringBuilder.Append(Uri.EscapeDataString(item.Value ?? string.Empty));
				if (flag)
				{
					flag = false;
				}
			}
		}
		return valueStringBuilder.ToString();
	}

	private Func<HttpClient, object[], IObservable<T?>> BuildRxFuncForMethod<T, TBody>(RestMethodInfoInternal restMethod)
	{
		Func<HttpClient, CancellationToken, object[], Task<T?>> taskFunc = BuildCancellableTaskFuncForMethod<T, TBody>(restMethod);
		return (HttpClient client, object[] paramList) => new TaskToObservable<T>(delegate(CancellationToken ct)
		{
			CancellationToken token = CancellationToken.None;
			if (restMethod.CancellationToken != null)
			{
				token = paramList.OfType<CancellationToken>().FirstOrDefault();
			}
			CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, ct);
			return taskFunc(client, cancellationTokenSource.Token, paramList);
		});
	}

	private Func<HttpClient, object[], Task<T?>> BuildTaskFuncForMethod<T, TBody>(RestMethodInfoInternal restMethod)
	{
		Func<HttpClient, CancellationToken, object[], Task<T?>> ret = BuildCancellableTaskFuncForMethod<T, TBody>(restMethod);
		return (HttpClient client, object[] paramList) => (restMethod.CancellationToken != null) ? ret(client, paramList.OfType<CancellationToken>().FirstOrDefault(), paramList) : ret(client, CancellationToken.None, paramList);
	}

	private Func<HttpClient, object[], Task> BuildVoidTaskFuncForMethod(RestMethodInfoInternal restMethod)
	{
		return async delegate(HttpClient client, object[] paramList)
		{
			if (client.BaseAddress == null)
			{
				throw new InvalidOperationException("BaseAddress must be set on the HttpClient instance");
			}
			Func<object[], HttpRequestMessage> func = BuildRequestFactoryForMethod(restMethod, client.BaseAddress.AbsolutePath, restMethod.CancellationToken != null);
			HttpRequestMessage rq = func(paramList);
			CancellationToken ct = CancellationToken.None;
			if (restMethod.CancellationToken != null)
			{
				ct = paramList.OfType<CancellationToken>().FirstOrDefault();
			}
			if (IsBodyBuffered(restMethod, rq))
			{
				await rq.Content.LoadIntoBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			using HttpResponseMessage resp = await client.SendAsync(rq, ct).ConfigureAwait(continueOnCapturedContext: false);
			Exception ex = await settings.ExceptionFactory(resp).ConfigureAwait(continueOnCapturedContext: false);
			if (ex != null)
			{
				throw ex;
			}
		};
	}

	private static bool IsBodyBuffered(RestMethodInfoInternal restMethod, HttpRequestMessage? request)
	{
		Tuple<BodySerializationMethod, bool, int>? bodyParameterInfo = restMethod.BodyParameterInfo;
		if (bodyParameterInfo != null && bodyParameterInfo.Item2)
		{
			return request?.Content != null;
		}
		return false;
	}

	private static bool DoNotConvertToQueryMap(object? value)
	{
		if (value == null)
		{
			return false;
		}
		Type type = value.GetType();
		if (ShouldReturn(type))
		{
			return true;
		}
		if (!(value is IEnumerable))
		{
			return false;
		}
		Type ienu = typeof(IEnumerable<>);
		Type type2 = type.GetInterfaces().FirstOrDefault((Type i) => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == ienu);
		if (type2 == null)
		{
			return false;
		}
		type = type2.GetGenericArguments()[0];
		return ShouldReturn(type);
		static bool ShouldReturn(Type type3)
		{
			if (!(type3 == typeof(string)) && !(type3 == typeof(bool)) && !(type3 == typeof(char)) && !typeof(IFormattable).IsAssignableFrom(type3))
			{
				return type3 == typeof(Uri);
			}
			return true;
		}
	}

	private static void SetHeader(HttpRequestMessage request, string name, string? value)
	{
		if (request.Headers.Any<KeyValuePair<string, IEnumerable<string>>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key == name))
		{
			request.Headers.Remove(name);
		}
		if (request.Content != null && request.Content.Headers.Any<KeyValuePair<string, IEnumerable<string>>>((KeyValuePair<string, IEnumerable<string>> x) => x.Key == name))
		{
			request.Content.Headers.Remove(name);
		}
		if (value != null)
		{
			name = EnsureSafe(name);
			value = EnsureSafe(value);
			if (!request.Headers.TryAddWithoutValidation(name, value) && request.Content != null)
			{
				request.Content.Headers.TryAddWithoutValidation(name, value);
			}
		}
	}

	private static string EnsureSafe(string value)
	{
		return value.Replace("\r", string.Empty).Replace("\n", string.Empty);
	}

	private static bool IsBodyless(HttpMethod method)
	{
		if (!(method == HttpMethod.Get))
		{
			return method == HttpMethod.Head;
		}
		return true;
	}
}
