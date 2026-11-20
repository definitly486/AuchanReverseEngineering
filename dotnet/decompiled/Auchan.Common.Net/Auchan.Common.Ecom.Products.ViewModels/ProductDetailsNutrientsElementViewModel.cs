using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class ProductDetailsNutrientsElementViewModel : ElementViewModel
{
	public class Parameter
	{
		public EnergyValue? EnergyValue { get; }

		public Parameter(EnergyValue? energyValue)
		{
			EnergyValue = energyValue;
		}
	}

	private readonly Parameter _parameter;

	[CompilerGenerated]
	private bool _003CIsVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CProteinsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CFatsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCarbsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCaloriesAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProteins_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFats_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCarbs_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCalories_003Ek__BackingField;

	public bool IsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsVisible_003Ek__BackingField != value)
			{
				_003CIsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsVisible");
			}
		}
	}

	public string Title { get; } = "Пищевая ценность на 100г продукта";

	public bool ProteinsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CProteinsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CProteinsAvailable_003Ek__BackingField != value)
			{
				_003CProteinsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("ProteinsAvailable");
			}
		}
	}

	public bool FatsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CFatsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CFatsAvailable_003Ek__BackingField != value)
			{
				_003CFatsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("FatsAvailable");
			}
		}
	}

	public bool CarbsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCarbsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCarbsAvailable_003Ek__BackingField != value)
			{
				_003CCarbsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CarbsAvailable");
			}
		}
	}

	public bool CaloriesAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCaloriesAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCaloriesAvailable_003Ek__BackingField != value)
			{
				_003CCaloriesAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CaloriesAvailable");
			}
		}
	}

	public string ProteinsTitle { get; } = "белки";

	public string FatsTitle { get; } = "жиры";

	public string CarbsTitle { get; } = "углеводы";

	public string CaloriesTitle { get; } = "калорийность";

	public string Proteins
	{
		[CompilerGenerated]
		get
		{
			return _003CProteins_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CProteins_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProteins_003Ek__BackingField = value;
				RaisePropertyChanged("Proteins");
			}
		}
	} = "";

	public string Fats
	{
		[CompilerGenerated]
		get
		{
			return _003CFats_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CFats_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CFats_003Ek__BackingField = value;
				RaisePropertyChanged("Fats");
			}
		}
	} = "";

	public string Carbs
	{
		[CompilerGenerated]
		get
		{
			return _003CCarbs_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCarbs_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCarbs_003Ek__BackingField = value;
				RaisePropertyChanged("Carbs");
			}
		}
	} = "";

	public string Calories
	{
		[CompilerGenerated]
		get
		{
			return _003CCalories_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCalories_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCalories_003Ek__BackingField = value;
				RaisePropertyChanged("Calories");
			}
		}
	} = "";

	public ProductDetailsNutrientsElementViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}

	public override async Task Start()
	{
		await base.Start();
		CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
		Proteins = _parameter?.EnergyValue?.Proteins?.ToString("####0.##", cultureInfo) ?? string.Empty;
		Fats = _parameter?.EnergyValue?.Fats?.ToString("####0.##", cultureInfo) ?? string.Empty;
		Carbs = _parameter?.EnergyValue?.Carbs?.ToString("####0.##", cultureInfo) ?? string.Empty;
		Calories = _parameter?.EnergyValue?.Calories?.ToString("####0.##", cultureInfo) ?? string.Empty;
		ProteinsAvailable = !string.IsNullOrWhiteSpace(Proteins);
		FatsAvailable = !string.IsNullOrWhiteSpace(Fats);
		CarbsAvailable = !string.IsNullOrWhiteSpace(Carbs);
		CaloriesAvailable = !string.IsNullOrWhiteSpace(Calories);
		IsVisible = _parameter.EnergyValue != null;
	}
}
