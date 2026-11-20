using System;

namespace CsvHelper.Configuration.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class CommentAttribute : Attribute, IClassMapper
{
	public char Comment { get; private set; }

	public CommentAttribute(char comment)
	{
		Comment = comment;
	}

	public void ApplyTo(CsvConfiguration configuration)
	{
		configuration.Comment = Comment;
	}
}
