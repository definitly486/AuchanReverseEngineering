#define DEBUG
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace System.Runtime.CompilerServices;

public static class ContractHelper
{
	[CompilerGenerated]
	private static EventHandler<ContractFailedEventArgs> InternalContractFailed;

	internal static event EventHandler<ContractFailedEventArgs>? InternalContractFailed;

	[DebuggerNonUserCode]
	public static string? RaiseContractFailedEvent(ContractFailureKind failureKind, string? userMessage, string? conditionText, Exception? innerException)
	{
		if (failureKind < ContractFailureKind.Precondition || failureKind > ContractFailureKind.Assume)
		{
			throw new ArgumentException(SR.Format("Arg_EnumIllegalVal", failureKind), "failureKind");
		}
		string text = "contract failed.";
		ContractFailedEventArgs e = null;
		string result;
		try
		{
			text = GetDisplayMessage(failureKind, userMessage, conditionText);
			EventHandler<ContractFailedEventArgs> internalContractFailed = ContractHelper.InternalContractFailed;
			if (internalContractFailed != null)
			{
				e = new ContractFailedEventArgs(failureKind, text, conditionText, innerException);
				Delegate[] invocationList = internalContractFailed.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					EventHandler<ContractFailedEventArgs> eventHandler = (EventHandler<ContractFailedEventArgs>)invocationList[i];
					try
					{
						eventHandler(null, e);
					}
					catch (Exception thrownDuringHandler)
					{
						e.thrownDuringHandler = thrownDuringHandler;
						e.SetUnwind();
					}
				}
				if (e.Unwind)
				{
					if (innerException == null)
					{
						innerException = e.thrownDuringHandler;
					}
					throw new ContractException(failureKind, text, userMessage, conditionText, innerException);
				}
			}
		}
		finally
		{
			result = ((e == null || !e.Handled) ? text : null);
		}
		return result;
	}

	[DebuggerNonUserCode]
	public static void TriggerFailure(ContractFailureKind kind, string? displayMessage, string? userMessage, string? conditionText, Exception? innerException)
	{
		if (string.IsNullOrEmpty(displayMessage))
		{
			displayMessage = GetDisplayMessage(kind, userMessage, conditionText);
		}
		Debug.ContractFailure(displayMessage, string.Empty, GetFailureMessage(kind, null));
	}

	private static string GetFailureMessage(ContractFailureKind failureKind, string conditionText)
	{
		bool flag = !string.IsNullOrEmpty(conditionText);
		switch (failureKind)
		{
		case ContractFailureKind.Assert:
			if (!flag)
			{
				return "AssertionFailed";
			}
			return SR.Format("AssertionFailed_Cnd", conditionText);
		case ContractFailureKind.Assume:
			if (!flag)
			{
				return "AssumptionFailed";
			}
			return SR.Format("AssumptionFailed_Cnd", conditionText);
		case ContractFailureKind.Precondition:
			if (!flag)
			{
				return "PreconditionFailed";
			}
			return SR.Format("PreconditionFailed_Cnd", conditionText);
		case ContractFailureKind.Postcondition:
			if (!flag)
			{
				return "PostconditionFailed";
			}
			return SR.Format("PostconditionFailed_Cnd", conditionText);
		case ContractFailureKind.Invariant:
			if (!flag)
			{
				return "InvariantFailed";
			}
			return SR.Format("InvariantFailed_Cnd", conditionText);
		case ContractFailureKind.PostconditionOnException:
			if (!flag)
			{
				return "PostconditionOnExceptionFailed";
			}
			return SR.Format("PostconditionOnExceptionFailed_Cnd", conditionText);
		default:
			Contract.Assume(condition: false, "Unreachable code");
			return "AssumptionFailed";
		}
	}

	private static string GetDisplayMessage(ContractFailureKind failureKind, string userMessage, string conditionText)
	{
		string text = (string.IsNullOrEmpty(conditionText) ? "" : GetFailureMessage(failureKind, conditionText));
		if (!string.IsNullOrEmpty(userMessage))
		{
			return text + "  " + userMessage;
		}
		return text;
	}
}
