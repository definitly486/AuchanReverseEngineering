using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Preferences;

namespace Microsoft.Maui.Storage;

internal class PreferencesImplementation : IPreferences
{
	private readonly object locker = new object();

	public void Remove(string key, string sharedName)
	{
		lock (locker)
		{
			using ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName);
			using ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
			sharedPreferencesEditor.Remove(key).Apply();
		}
	}

	public void Clear(string sharedName)
	{
		lock (locker)
		{
			using ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName);
			using ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
			sharedPreferencesEditor.Clear().Apply();
		}
	}

	public void Set<T>(string key, T value, string sharedName)
	{
		Preferences.CheckIsSupportedType<T>();
		lock (locker)
		{
			using ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName);
			using ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
			if (value == null)
			{
				sharedPreferencesEditor.Remove(key);
			}
			else if (!(value is string value2))
			{
				if (!(value is int value3))
				{
					if (!(value is bool value4))
					{
						if (!(value is long value5))
						{
							if (!(value is double))
							{
								if (!(value is float value6))
								{
									if (!(value is DateTime dateTime))
									{
										if (value is DateTimeOffset dateTimeOffset)
										{
											sharedPreferencesEditor.PutString(key, dateTimeOffset.ToString("O"));
										}
									}
									else
									{
										sharedPreferencesEditor.PutLong(key, dateTime.ToBinary());
									}
								}
								else
								{
									sharedPreferencesEditor.PutFloat(key, value6);
								}
							}
							else
							{
								string value7 = Convert.ToString(value, CultureInfo.InvariantCulture);
								sharedPreferencesEditor.PutString(key, value7);
							}
						}
						else
						{
							sharedPreferencesEditor.PutLong(key, value5);
						}
					}
					else
					{
						sharedPreferencesEditor.PutBoolean(key, value4);
					}
				}
				else
				{
					sharedPreferencesEditor.PutInt(key, value3);
				}
			}
			else
			{
				sharedPreferencesEditor.PutString(key, value2);
			}
			sharedPreferencesEditor.Apply();
		}
	}

	public T Get<T>(string key, T defaultValue, string sharedName)
	{
		lock (locker)
		{
			object obj = null;
			using (ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName))
			{
				if (defaultValue == null)
				{
					obj = sharedPreferences.GetString(key, null);
				}
				else if (!(defaultValue is int defValue))
				{
					if (!(defaultValue is bool defValue2))
					{
						if (!(defaultValue is long defValue3))
						{
							if (!(defaultValue is double))
							{
								if (!(defaultValue is float defValue4))
								{
									if (!(defaultValue is string defValue5))
									{
										if (!(defaultValue is DateTime dateTime))
										{
											if (defaultValue is DateTimeOffset dateTimeOffset)
											{
												string input = sharedPreferences.GetString(key, dateTimeOffset.ToString("O"));
												if (DateTimeOffset.TryParse(input, out var result))
												{
													obj = result;
												}
											}
										}
										else
										{
											long dateData = sharedPreferences.GetLong(key, dateTime.ToBinary());
											obj = DateTime.FromBinary(dateData);
										}
									}
									else
									{
										obj = sharedPreferences.GetString(key, defValue5);
									}
								}
								else
								{
									obj = sharedPreferences.GetFloat(key, defValue4);
								}
							}
							else
							{
								string text = sharedPreferences.GetString(key, null);
								if (string.IsNullOrWhiteSpace(text))
								{
									obj = defaultValue;
								}
								else
								{
									if (!double.TryParse(text, NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out var result2))
									{
										string value = Convert.ToString(double.MaxValue, CultureInfo.InvariantCulture);
										result2 = (text.Equals(value, StringComparison.Ordinal) ? double.MaxValue : double.MinValue);
									}
									obj = result2;
								}
							}
						}
						else
						{
							obj = sharedPreferences.GetLong(key, defValue3);
						}
					}
					else
					{
						obj = sharedPreferences.GetBoolean(key, defValue2);
					}
				}
				else
				{
					obj = sharedPreferences.GetInt(key, defValue);
				}
			}
			return (T)obj;
		}
	}

	internal static ISharedPreferences GetSharedPreferences(string sharedName)
	{
		Context context = Application.Context;
		if (!string.IsNullOrWhiteSpace(sharedName))
		{
			return context.GetSharedPreferences(sharedName, FileCreationMode.Private);
		}
		return PreferenceManager.GetDefaultSharedPreferences(context);
	}
}
