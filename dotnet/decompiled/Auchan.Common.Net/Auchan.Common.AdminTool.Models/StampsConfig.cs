using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Models;

namespace Auchan.Common.AdminTool.Models;

public class StampsConfig : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _003CExpirationInformerText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CExpirationInformerLink_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CStampsLimitInformer_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CActive_003Ek__BackingField;

	[CompilerGenerated]
	private DateTime _003CStartDate_003Ek__BackingField;

	[CompilerGenerated]
	private DateTime _003CEndDate_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowStampsToCurrentUser_003Ek__BackingField;

	private readonly string _segmentCode = string.Empty;

	private readonly bool? _isForEmployees;

	private readonly bool? _isForSegment;

	private readonly bool _showStampsBalanceCfg;

	private readonly bool _showStampsInHistoryCfg;

	private readonly bool _allowStampsTransferCfg;

	private readonly string? _productStampsInformer;

	public string ExpirationInformerText
	{
		[CompilerGenerated]
		get
		{
			return _003CExpirationInformerText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CExpirationInformerText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CExpirationInformerText_003Ek__BackingField = value;
				OnPropertyChanged("ExpirationInformerText");
			}
		}
	}

	public string ExpirationInformerLink
	{
		[CompilerGenerated]
		get
		{
			return _003CExpirationInformerLink_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CExpirationInformerLink_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CExpirationInformerLink_003Ek__BackingField = value;
				OnPropertyChanged("ExpirationInformerLink");
			}
		}
	}

	public string StampsLimitInformer
	{
		[CompilerGenerated]
		get
		{
			return _003CStampsLimitInformer_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStampsLimitInformer_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStampsLimitInformer_003Ek__BackingField = value;
				OnPropertyChanged("StampsLimitInformer");
			}
		}
	}

	public bool Active
	{
		[CompilerGenerated]
		get
		{
			return _003CActive_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CActive_003Ek__BackingField != value)
			{
				_003CActive_003Ek__BackingField = value;
				OnPropertyChanged("Active");
			}
		}
	}

	public DateTime StartDate
	{
		[CompilerGenerated]
		get
		{
			return _003CStartDate_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!DateTime.Equals(_003CStartDate_003Ek__BackingField, value))
			{
				_003CStartDate_003Ek__BackingField = value;
				OnPropertyChanged("StartDate");
			}
		}
	}

	public DateTime EndDate
	{
		[CompilerGenerated]
		get
		{
			return _003CEndDate_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!DateTime.Equals(_003CEndDate_003Ek__BackingField, value))
			{
				_003CEndDate_003Ek__BackingField = value;
				OnPropertyChanged("EndDate");
			}
		}
	}

	public bool ShowStampsBalance
	{
		get
		{
			if (_showStampsBalanceCfg)
			{
				return ShowStampsToCurrentUser;
			}
			return false;
		}
	}

	public bool ShowStampsInHistory
	{
		get
		{
			if (_showStampsInHistoryCfg)
			{
				return ShowStampsToCurrentUser;
			}
			return false;
		}
	}

	public bool AllowStampsTransfer
	{
		get
		{
			if (_allowStampsTransferCfg && _showStampsBalanceCfg)
			{
				return ShowStampsToCurrentUser;
			}
			return false;
		}
	}

	public bool ShowStampsToCurrentUser
	{
		[CompilerGenerated]
		get
		{
			return _003CShowStampsToCurrentUser_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CShowStampsToCurrentUser_003Ek__BackingField != value)
			{
				_003CShowStampsToCurrentUser_003Ek__BackingField = value;
				OnPropertyChanged("ShowStampsBalance");
				OnPropertyChanged("ShowStampsInHistory");
				OnPropertyChanged("AllowStampsTransfer");
				OnPropertyChanged("ShowStampsToCurrentUser");
			}
		}
	}

	public bool ProductDetailsInformerAvailable => !string.IsNullOrWhiteSpace(_productStampsInformer);

	public event PropertyChangedEventHandler? PropertyChanged;

	public StampsConfig(string? productStampsInformer, string stampsLimitInformer, string expirationInformerText, string expirationInformerLink, string segmentCode, bool active, bool? isForEmployees, bool? isForSegment, DateTime startDate, DateTime endDate, bool showStampsAtHomeScreen, bool showStampsInHistory, bool allowStampsTransfer)
	{
		_productStampsInformer = productStampsInformer;
		StampsLimitInformer = stampsLimitInformer.Replace("<br />", "\n");
		ExpirationInformerText = $"{expirationInformerText} {endDate:dd.MM}";
		ExpirationInformerLink = expirationInformerLink;
		_segmentCode = segmentCode;
		Active = active;
		_isForEmployees = isForEmployees;
		_isForSegment = isForSegment;
		StartDate = startDate;
		EndDate = endDate;
		_showStampsBalanceCfg = showStampsAtHomeScreen && active;
		_showStampsInHistoryCfg = showStampsInHistory && active;
		_allowStampsTransferCfg = allowStampsTransfer && active;
	}

	public void SetSocialStatus(IEnumerable<string> segments, bool isEmployee)
	{
		bool flag = _isForEmployees.HasValue && (_isForEmployees != true || isEmployee);
		bool flag2 = _isForSegment.HasValue && (_isForSegment != true || segments.Any((string s) => s.Equals(_segmentCode)));
		ShowStampsToCurrentUser = flag && flag2 && Active;
		OnPropertyChanged("ShowStampsToCurrentUser");
		OnPropertyChanged("ShowStampsBalance");
		OnPropertyChanged("ShowStampsInHistory");
		OnPropertyChanged("AllowStampsTransfer");
	}

	public void SetSocialStatus(LoyaltyProgramSocialStatusResponse status)
	{
		SetSocialStatus(status.Segments.Select((LoyaltyProgramSocialStatusSegment s) => s.Code), status.IsEmployee);
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public LinkedText? ProductDetailsInformerLinkedText(Action<string> linkAction)
	{
		if (string.IsNullOrEmpty(_productStampsInformer))
		{
			return null;
		}
		string productStampsInformer = _productStampsInformer;
		string[] array = new Regex("<a\\s[^>]*href\\s*=\\s*\"([^\"]*)\"[^>]*>([^<]*)[^>]*>", RegexOptions.None, TimeSpan.FromSeconds(60L)).Split(productStampsInformer);
		string text = "";
		List<string> list = new List<string>();
		List<Action> list2 = new List<Action>();
		for (int i = 0; i < array.Count(); i += 3)
		{
			text += array[i];
			if (i + 2 < array.Count())
			{
				text += array[i + 2];
				list.Add(array[i + 2]);
			}
			if (i + 1 < array.Count())
			{
				string url = array[i + 1];
				list2.Add(delegate
				{
					linkAction(url);
				});
			}
		}
		return new LinkedText(text, list.ToArray(), list2.ToArray());
	}
}
