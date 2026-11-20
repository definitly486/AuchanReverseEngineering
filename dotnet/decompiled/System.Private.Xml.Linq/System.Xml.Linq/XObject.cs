namespace System.Xml.Linq;

public abstract class XObject : IXmlLineInfo
{
	internal XContainer parent;

	internal object annotations;

	public string BaseUri
	{
		get
		{
			XObject xObject = this;
			while (true)
			{
				if (xObject != null && xObject.annotations == null)
				{
					xObject = xObject.parent;
					continue;
				}
				if (xObject == null)
				{
					break;
				}
				BaseUriAnnotation baseUriAnnotation = xObject.Annotation<BaseUriAnnotation>();
				if (baseUriAnnotation != null)
				{
					return baseUriAnnotation.baseUri;
				}
				xObject = xObject.parent;
			}
			return string.Empty;
		}
	}

	public XDocument? Document
	{
		get
		{
			XObject xObject = this;
			while (xObject.parent != null)
			{
				xObject = xObject.parent;
			}
			return xObject as XDocument;
		}
	}

	public abstract XmlNodeType NodeType { get; }

	public XElement? Parent => parent as XElement;

	int IXmlLineInfo.LineNumber => Annotation<LineInfoAnnotation>()?.lineNumber ?? 0;

	int IXmlLineInfo.LinePosition => Annotation<LineInfoAnnotation>()?.linePosition ?? 0;

	internal bool HasBaseUri => Annotation<BaseUriAnnotation>() != null;

	internal XObject()
	{
	}

	public void AddAnnotation(object annotation)
	{
		ArgumentNullException.ThrowIfNull(annotation, "annotation");
		if (annotations == null)
		{
			annotations = ((!(annotation is object[])) ? annotation : new object[1] { annotation });
			return;
		}
		object[] array = annotations as object[];
		if (array == null)
		{
			annotations = new object[2] { annotations, annotation };
			return;
		}
		int i;
		for (i = 0; i < array.Length && array[i] != null; i++)
		{
		}
		if (i == array.Length)
		{
			Array.Resize(ref array, i * 2);
			annotations = array;
		}
		array[i] = annotation;
	}

	private object AnnotationForSealedType(Type type)
	{
		if (annotations != null)
		{
			if (!(annotations is object[] array))
			{
				if (annotations.GetType() == type)
				{
					return annotations;
				}
			}
			else
			{
				foreach (object obj in array)
				{
					if (obj == null)
					{
						break;
					}
					if (obj.GetType() == type)
					{
						return obj;
					}
				}
			}
		}
		return null;
	}

	public T? Annotation<T>() where T : class
	{
		if (annotations != null)
		{
			if (!(annotations is object[] array))
			{
				return annotations as T;
			}
			foreach (object obj in array)
			{
				if (obj == null)
				{
					break;
				}
				if (obj is T result)
				{
					return result;
				}
			}
		}
		return null;
	}

	bool IXmlLineInfo.HasLineInfo()
	{
		return Annotation<LineInfoAnnotation>() != null;
	}

	internal bool NotifyChanged(object sender, XObjectChangeEventArgs e)
	{
		bool result = false;
		XObject xObject = this;
		while (true)
		{
			if (xObject != null && xObject.annotations == null)
			{
				xObject = xObject.parent;
				continue;
			}
			if (xObject == null)
			{
				break;
			}
			XObjectChangeAnnotation xObjectChangeAnnotation = xObject.Annotation<XObjectChangeAnnotation>();
			if (xObjectChangeAnnotation != null)
			{
				result = true;
				xObjectChangeAnnotation.changed?.Invoke(sender, e);
			}
			xObject = xObject.parent;
		}
		return result;
	}

	internal bool NotifyChanging(object sender, XObjectChangeEventArgs e)
	{
		bool result = false;
		XObject xObject = this;
		while (true)
		{
			if (xObject != null && xObject.annotations == null)
			{
				xObject = xObject.parent;
				continue;
			}
			if (xObject == null)
			{
				break;
			}
			XObjectChangeAnnotation xObjectChangeAnnotation = xObject.Annotation<XObjectChangeAnnotation>();
			if (xObjectChangeAnnotation != null)
			{
				result = true;
				xObjectChangeAnnotation.changing?.Invoke(sender, e);
			}
			xObject = xObject.parent;
		}
		return result;
	}

	internal void SetBaseUri(string baseUri)
	{
		AddAnnotation(new BaseUriAnnotation(baseUri));
	}

	internal void SetLineInfo(int lineNumber, int linePosition)
	{
		AddAnnotation(new LineInfoAnnotation(lineNumber, linePosition));
	}

	internal bool SkipNotify()
	{
		XObject xObject = this;
		while (true)
		{
			if (xObject != null && xObject.annotations == null)
			{
				xObject = xObject.parent;
				continue;
			}
			if (xObject == null)
			{
				return true;
			}
			if (xObject.Annotation<XObjectChangeAnnotation>() != null)
			{
				break;
			}
			xObject = xObject.parent;
		}
		return false;
	}

	internal SaveOptions GetSaveOptionsFromAnnotations()
	{
		XObject xObject = this;
		object obj;
		while (true)
		{
			if (xObject != null && xObject.annotations == null)
			{
				xObject = xObject.parent;
				continue;
			}
			if (xObject == null)
			{
				return SaveOptions.None;
			}
			obj = xObject.AnnotationForSealedType(typeof(SaveOptions));
			if (obj != null)
			{
				break;
			}
			xObject = xObject.parent;
		}
		return (SaveOptions)obj;
	}
}
