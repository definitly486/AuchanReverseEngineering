using System.ComponentModel;
using System.Runtime.Serialization;

namespace Auchan.Common.Logs;

public enum SystemType
{
	[EnumMember(Value = "mobileApp")]
	[Description("Mobile Application")]
	MobileApp,
	[EnumMember(Value = "ecom")]
	[Description("ECom")]
	ECom,
	[EnumMember(Value = "auchanPay")]
	[Description("Auchan Pay")]
	AuchanPay,
	[EnumMember(Value = "selfScanning")]
	[Description("Self Scanning")]
	SelfScanning,
	[EnumMember(Value = "personalAccount")]
	[Description("Personal Account (LKK)")]
	PersonalAccount,
	[EnumMember(Value = "admin")]
	[Description("Admin Panel")]
	AdminPanel,
	[EnumMember(Value = "transactionStorage")]
	[Description("Transaction Storage")]
	TransactionStorage,
	[EnumMember(Value = "shoppingList")]
	[Description("Shopping List")]
	ShoppingList,
	[EnumMember(Value = "cashbackBalance")]
	[Description("Cashback Balance")]
	CashbackBalance,
	[EnumMember(Value = "cashback")]
	[Description("Cashback")]
	Cashback,
	[EnumMember(Value = "staticImages")]
	[Description("Static Images")]
	StaticImages,
	[EnumMember(Value = "azure")]
	[Description("Microsoft Azure")]
	Azure,
	[EnumMember(Value = "rocketRetail")]
	[Description("Rocket Retail")]
	RocketRetail,
	[EnumMember(Value = "supportChat")]
	[Description("Support Chat")]
	SupportChat,
	[EnumMember(Value = "yandexAppMetrica")]
	[Description("Yandex AppMetrica")]
	YandexAppMetrica,
	[EnumMember(Value = "mapFrontend")]
	[Description("Map Frontend")]
	MapFrontend
}
