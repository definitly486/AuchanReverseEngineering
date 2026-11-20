using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;
using Google.Android.Material.CheckBox;

namespace Auchan.Android.DynamicFeedback.Controls;

public class SendButtonView : LinearLayoutWidgetBase
{
	public SendButtonView(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		View view = View.Inflate(context, 2131493191, this);
		MaterialCheckBox userAgreementCheckbox = view.RequireViewById<MaterialCheckBox>(2131298351);
		TextView textView = view.RequireViewById<TextView>(2131296770);
		Button sendButton = view.RequireViewById<Button>(2131298350);
		sendButton.SetText(dynamicFeedbackViewModel.SendBtnText, TextView.BufferType.Normal);
		textView.AddLinkedText(dynamicFeedbackViewModel.AcceptanceText);
		dynamicFeedbackViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				sendButton.Enabled = dynamicFeedbackViewModel.IsUserAgreed;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsUserAgreed")),
			(delegate
			{
				userAgreementCheckbox.Checked = dynamicFeedbackViewModel.IsUserAgreed;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsUserAgreed"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		dynamicFeedbackViewModel.BindEvents(sendButton.OnClick(dynamicFeedbackViewModel.OnSendClicked), ((View)userAgreementCheckbox).OnClick((Action)delegate
		{
			dynamicFeedbackViewModel.IsUserAgreed = userAgreementCheckbox.Checked;
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
