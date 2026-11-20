using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.State;
using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.ConstraintLayout.Core.Widgets;

[Register("androidx/constraintlayout/core/widgets/ConstraintWidget", DoNotGenerateAcw = true)]
public class ConstraintWidget : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour", DoNotGenerateAcw = true)]
	public sealed class DimensionBehaviour : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour", typeof(DimensionBehaviour));

		[Register("FIXED")]
		public static DimensionBehaviour? Fixed => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("FIXED.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MATCH_CONSTRAINT")]
		public static DimensionBehaviour? MatchConstraint => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("MATCH_CONSTRAINT.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MATCH_PARENT")]
		public static DimensionBehaviour? MatchParent => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("MATCH_PARENT.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("WRAP_CONTENT")]
		public static DimensionBehaviour? WrapContent => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("WRAP_CONTENT.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DimensionBehaviour(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", "")]
		public unsafe static DimensionBehaviour? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", "")]
		public unsafe static DimensionBehaviour[]? Values()
		{
			return (DimensionBehaviour[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DimensionBehaviour));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/ConstraintWidget", typeof(ConstraintWidget));

	private static Delegate? cb_getAnchors_GetAnchors_Ljava_util_ArrayList_;

	private static Delegate? cb_isAnimated_IsAnimated_Z;

	private static Delegate? cb_setAnimated_SetAnimated_Z_V;

	private static Delegate? cb_getBaselineDistance_GetBaselineDistance_I;

	private static Delegate? cb_setBaselineDistance_SetBaselineDistance_I_V;

	private static Delegate? cb_getBottom_GetBottom_I;

	private static Delegate? cb_getCompanionWidget_GetCompanionWidget_Ljava_lang_Object_;

	private static Delegate? cb_setCompanionWidget_SetCompanionWidget_Ljava_lang_Object__V;

	private static Delegate? cb_getContainerItemSkip_GetContainerItemSkip_I;

	private static Delegate? cb_setContainerItemSkip_SetContainerItemSkip_I_V;

	private static Delegate? cb_getDebugName_GetDebugName_Ljava_lang_String_;

	private static Delegate? cb_setDebugName_SetDebugName_Ljava_lang_String__V;

	private static Delegate? cb_getDimensionRatio_GetDimensionRatio_F;

	private static Delegate? cb_getDimensionRatioSide_GetDimensionRatioSide_I;

	private static Delegate? cb_hasBaseline_HasBaseline_Z;

	private static Delegate? cb_setHasBaseline_SetHasBaseline_Z_V;

	private static Delegate? cb_hasDependencies_HasDependencies_Z;

	private static Delegate? cb_hasDimensionOverride_HasDimensionOverride_Z;

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_setHeight_SetHeight_I_V;

	private static Delegate? cb_isHeightWrapContent_IsHeightWrapContent_Z;

	private static Delegate? cb_setHeightWrapContent_SetHeightWrapContent_Z_V;

	private static Delegate? cb_getHorizontalBiasPercent_GetHorizontalBiasPercent_F;

	private static Delegate? cb_setHorizontalBiasPercent_SetHorizontalBiasPercent_F_V;

	private static Delegate? cb_getHorizontalChainControlWidget_GetHorizontalChainControlWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_getHorizontalChainStyle_GetHorizontalChainStyle_I;

	private static Delegate? cb_setHorizontalChainStyle_SetHorizontalChainStyle_I_V;

	private static Delegate? cb_getHorizontalDimensionBehaviour_GetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_;

	private static Delegate? cb_setHorizontalDimensionBehaviour_SetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour__V;

	private static Delegate? cb_getHorizontalMargin_GetHorizontalMargin_I;

	private static Delegate? cb_isInPlaceholder_IsInPlaceholder_Z;

	private static Delegate? cb_setInPlaceholder_SetInPlaceholder_Z_V;

	private static Delegate? cb_isInVirtualLayout_IsInVirtualLayout_Z;

	private static Delegate? cb_setInVirtualLayout_SetInVirtualLayout_Z_V;

	private static Delegate? cb_isHorizontalSolvingPassDone_IsHorizontalSolvingPassDone_Z;

	private static Delegate? cb_isInHorizontalChain_IsInHorizontalChain_Z;

	private static Delegate? cb_isInVerticalChain_IsInVerticalChain_Z;

	private static Delegate? cb_isResolvedHorizontally_IsResolvedHorizontally_Z;

	private static Delegate? cb_isResolvedVertically_IsResolvedVertically_Z;

	private static Delegate? cb_isRoot_IsRoot_Z;

	private static Delegate? cb_isSpreadHeight_IsSpreadHeight_Z;

	private static Delegate? cb_isSpreadWidth_IsSpreadWidth_Z;

	private static Delegate? cb_isVerticalSolvingPassDone_IsVerticalSolvingPassDone_Z;

	private static Delegate? cb_getLastHorizontalMeasureSpec_GetLastHorizontalMeasureSpec_I;

	private static Delegate? cb_getLastVerticalMeasureSpec_GetLastVerticalMeasureSpec_I;

	private static Delegate? cb_getLeft_GetLeft_I;

	private static Delegate? cb_getMaxHeight_GetMaxHeight_I;

	private static Delegate? cb_setMaxHeight_SetMaxHeight_I_V;

	private static Delegate? cb_getMaxWidth_GetMaxWidth_I;

	private static Delegate? cb_setMaxWidth_SetMaxWidth_I_V;

	private static Delegate? cb_isMeasureRequested_IsMeasureRequested_Z;

	private static Delegate? cb_setMeasureRequested_SetMeasureRequested_Z_V;

	private static Delegate? cb_getMinHeight_GetMinHeight_I;

	private static Delegate? cb_setMinHeight_SetMinHeight_I_V;

	private static Delegate? cb_getMinWidth_GetMinWidth_I;

	private static Delegate? cb_setMinWidth_SetMinWidth_I_V;

	private static Delegate? cb_getOptimizerWrapHeight_GetOptimizerWrapHeight_I;

	private static Delegate? cb_getOptimizerWrapWidth_GetOptimizerWrapWidth_I;

	private static Delegate? cb_getParent_GetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_setParent_SetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget__V;

	private static Delegate? cb_getRight_GetRight_I;

	private static Delegate? cb_getRootX_GetRootX_I;

	private static Delegate? cb_getRootY_GetRootY_I;

	private static Delegate? cb_getTop_GetTop_I;

	private static Delegate? cb_getType_GetType_Ljava_lang_String_;

	private static Delegate? cb_setType_SetType_Ljava_lang_String__V;

	private static Delegate? cb_getVerticalBiasPercent_GetVerticalBiasPercent_F;

	private static Delegate? cb_setVerticalBiasPercent_SetVerticalBiasPercent_F_V;

	private static Delegate? cb_getVerticalChainControlWidget_GetVerticalChainControlWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_getVerticalChainStyle_GetVerticalChainStyle_I;

	private static Delegate? cb_setVerticalChainStyle_SetVerticalChainStyle_I_V;

	private static Delegate? cb_getVerticalDimensionBehaviour_GetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_;

	private static Delegate? cb_setVerticalDimensionBehaviour_SetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour__V;

	private static Delegate? cb_getVerticalMargin_GetVerticalMargin_I;

	private static Delegate? cb_getVisibility_GetVisibility_I;

	private static Delegate? cb_setVisibility_SetVisibility_I_V;

	private static Delegate? cb_getWidth_GetWidth_I;

	private static Delegate? cb_setWidth_SetWidth_I_V;

	private static Delegate? cb_isWidthWrapContent_IsWidthWrapContent_Z;

	private static Delegate? cb_setWidthWrapContent_SetWidthWrapContent_Z_V;

	private static Delegate? cb_getWrapBehaviorInParent_GetWrapBehaviorInParent_I;

	private static Delegate? cb_setWrapBehaviorInParent_SetWrapBehaviorInParent_I_V;

	private static Delegate? cb_addChildrenToSolverByDependency_AddChildrenToSolverByDependency_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_LinearSystem_Ljava_util_HashSet_IZ_V;

	private static Delegate? cb_addToSolver_AddToSolver_Landroidx_constraintlayout_core_LinearSystem_Z_V;

	private static Delegate? cb_allowedInBarrier_AllowedInBarrier_Z;

	private static Delegate? cb_connect_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I_V;

	private static Delegate? cb_connect_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type__V;

	private static Delegate? cb_connect_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I_V;

	private static Delegate? cb_connectCircularConstraint_ConnectCircularConstraint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI_V;

	private static Delegate? cb_copy_Copy_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Ljava_util_HashMap__V;

	private static Delegate? cb_createObjectVariables_CreateObjectVariables_Landroidx_constraintlayout_core_LinearSystem__V;

	private static Delegate? cb_ensureMeasureRequested_EnsureMeasureRequested_V;

	private static Delegate? cb_ensureWidgetRuns_EnsureWidgetRuns_V;

	private static Delegate? cb_getAnchor_GetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type__Landroidx_constraintlayout_core_widgets_ConstraintAnchor_;

	private static Delegate? cb_getBiasPercent_GetBiasPercent_I_F;

	private static Delegate? cb_getDimensionBehaviour_GetDimensionBehaviour_I_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_;

	private static Delegate? cb_getLength_GetLength_I_I;

	private static Delegate? cb_getNextChainMember_GetNextChainMember_I_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_getPreviousChainMember_GetPreviousChainMember_I_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

	private static Delegate? cb_getRun_GetRun_I_Landroidx_constraintlayout_core_widgets_analyzer_WidgetRun_;

	private static Delegate? cb_getSceneString_GetSceneString_Ljava_lang_StringBuilder__V;

	private static Delegate? cb_getX_GetX_I;

	private static Delegate? cb_getY_GetY_I;

	private static Delegate? cb_getHasBaseline_GetHasBaseline_Z;

	private static Delegate? cb_hasDanglingDimension_HasDanglingDimension_I_Z;

	private static Delegate? cb_hasResolvedTargets_HasResolvedTargets_II_Z;

	private static Delegate? cb_immediateConnect_ImmediateConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_II_V;

	private static Delegate? cb_isInBarrier_IsInBarrier_I_Z;

	private static Delegate? cb_markHorizontalSolvingPassDone_MarkHorizontalSolvingPassDone_V;

	private static Delegate? cb_markVerticalSolvingPassDone_MarkVerticalSolvingPassDone_V;

	private static Delegate? cb_oppositeDimensionDependsOn_OppositeDimensionDependsOn_I_Z;

	private static Delegate? cb_oppositeDimensionsTied_OppositeDimensionsTied_Z;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_resetAllConstraints_ResetAllConstraints_V;

	private static Delegate? cb_resetAnchor_ResetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor__V;

	private static Delegate? cb_resetAnchors_ResetAnchors_V;

	private static Delegate? cb_resetFinalResolution_ResetFinalResolution_V;

	private static Delegate? cb_resetSolverVariables_ResetSolverVariables_Landroidx_constraintlayout_core_Cache__V;

	private static Delegate? cb_resetSolvingPassFlag_ResetSolvingPassFlag_V;

	private static Delegate? cb_serialize_Serialize_Ljava_lang_StringBuilder__Ljava_lang_StringBuilder_;

	private static Delegate? cb_setDebugSolverName_SetDebugSolverName_Landroidx_constraintlayout_core_LinearSystem_Ljava_lang_String__V;

	private static Delegate? cb_setDimension_SetDimension_II_V;

	private static Delegate? cb_setDimensionRatio_SetDimensionRatio_FI_V;

	private static Delegate? cb_setDimensionRatio_SetDimensionRatio_Ljava_lang_String__V;

	private static Delegate? cb_setFinalBaseline_SetFinalBaseline_I_V;

	private static Delegate? cb_setFinalFrame_SetFinalFrame_IIIIII_V;

	private static Delegate? cb_setFinalHorizontal_SetFinalHorizontal_II_V;

	private static Delegate? cb_setFinalLeft_SetFinalLeft_I_V;

	private static Delegate? cb_setFinalTop_SetFinalTop_I_V;

	private static Delegate? cb_setFinalVertical_SetFinalVertical_II_V;

	private static Delegate? cb_setFrame_SetFrame_III_V;

	private static Delegate? cb_setFrame_SetFrame_IIII_V;

	private static Delegate? cb_setGoneMargin_SetGoneMargin_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I_V;

	private static Delegate? cb_setHorizontalDimension_SetHorizontalDimension_II_V;

	private static Delegate? cb_setHorizontalMatchStyle_SetHorizontalMatchStyle_IIIF_V;

	private static Delegate? cb_setHorizontalWeight_SetHorizontalWeight_F_V;

	private static Delegate? cb_setInBarrier_SetInBarrier_IZ_V;

	private static Delegate? cb_setLastMeasureSpec_SetLastMeasureSpec_II_V;

	private static Delegate? cb_setLength_SetLength_II_V;

	private static Delegate? cb_setOffset_SetOffset_II_V;

	private static Delegate? cb_setOrigin_SetOrigin_II_V;

	private static Delegate? cb_setVerticalDimension_SetVerticalDimension_II_V;

	private static Delegate? cb_setVerticalMatchStyle_SetVerticalMatchStyle_IIIF_V;

	private static Delegate? cb_setVerticalWeight_SetVerticalWeight_F_V;

	private static Delegate? cb_setX_SetX_I_V;

	private static Delegate? cb_setY_SetY_I_V;

	private static Delegate? cb_setupDimensionRatio_SetupDimensionRatio_ZZZZ_V;

	private static Delegate? cb_updateFromRuns_UpdateFromRuns_ZZ_V;

	private static Delegate? cb_updateFromSolver_UpdateFromSolver_Landroidx_constraintlayout_core_LinearSystem_Z_V;

	[Register("DEFAULT_BIAS")]
	public static float DefaultBias
	{
		get
		{
			return _members.StaticFields.GetSingleValue("DEFAULT_BIAS.F");
		}
		set
		{
			_members.StaticFields.SetValue("DEFAULT_BIAS.F", value);
		}
	}

	[Register("frame")]
	public WidgetFrame? Frame
	{
		get
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceFields.GetObjectValue("frame.Landroidx/constraintlayout/core/state/WidgetFrame;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("frame.Landroidx/constraintlayout/core/state/WidgetFrame;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("horizontalChainRun")]
	public ChainRun? HorizontalChainRun
	{
		get
		{
			return Java.Lang.Object.GetObject<ChainRun>(_members.InstanceFields.GetObjectValue("horizontalChainRun.Landroidx/constraintlayout/core/widgets/analyzer/ChainRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("horizontalChainRun.Landroidx/constraintlayout/core/widgets/analyzer/ChainRun;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("horizontalGroup")]
	public int HorizontalGroup
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("horizontalGroup.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("horizontalGroup.I", this, value);
		}
	}

	[Register("isTerminalWidget")]
	public IList<bool>? IsTerminalWidget
	{
		get
		{
			return Android.Runtime.JavaArray<bool>.FromJniHandle(_members.InstanceFields.GetObjectValue("isTerminalWidget.[Z", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<bool>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("isTerminalWidget.[Z", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mAnchors")]
	protected System.Collections.IList? MAnchors
	{
		get
		{
			return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("mAnchors.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mAnchors.Ljava/util/ArrayList;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mBaseline")]
	public ConstraintAnchor? MBaseline
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mBaseline.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mBaseline.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mBottom")]
	public ConstraintAnchor? MBottom
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mBottom.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mBottom.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mCenter")]
	public ConstraintAnchor? MCenter
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mCenter.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mCenter.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mCircleConstraintAngle")]
	public float MCircleConstraintAngle
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mCircleConstraintAngle.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mCircleConstraintAngle.F", this, value);
		}
	}

	[Register("mDimensionRatio")]
	public float MDimensionRatio
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mDimensionRatio.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mDimensionRatio.F", this, value);
		}
	}

	[Register("mDimensionRatioSide")]
	protected int MDimensionRatioSide
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mDimensionRatioSide.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mDimensionRatioSide.I", this, value);
		}
	}

	[Register("measured")]
	public bool Measured
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("measured.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("measured.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mHorizontalResolution")]
	public int MHorizontalResolution
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mHorizontalResolution.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mHorizontalResolution.I", this, value);
		}
	}

	[Register("mHorizontalRun")]
	public HorizontalWidgetRun? MHorizontalRun
	{
		get
		{
			return Java.Lang.Object.GetObject<HorizontalWidgetRun>(_members.InstanceFields.GetObjectValue("mHorizontalRun.Landroidx/constraintlayout/core/widgets/analyzer/HorizontalWidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mHorizontalRun.Landroidx/constraintlayout/core/widgets/analyzer/HorizontalWidgetRun;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mIsHeightWrapContent")]
	public bool MIsHeightWrapContent
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mIsHeightWrapContent.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mIsHeightWrapContent.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mIsWidthWrapContent")]
	public bool MIsWidthWrapContent
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mIsWidthWrapContent.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mIsWidthWrapContent.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mLeft")]
	public ConstraintAnchor? MLeft
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mLeft.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mLeft.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mListAnchors")]
	public IList<ConstraintAnchor>? MListAnchors
	{
		get
		{
			return Android.Runtime.JavaArray<ConstraintAnchor>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListAnchors.[Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<ConstraintAnchor>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mListAnchors.[Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mListDimensionBehaviors")]
	public IList<DimensionBehaviour>? MListDimensionBehaviors
	{
		get
		{
			return Android.Runtime.JavaArray<DimensionBehaviour>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListDimensionBehaviors.[Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<DimensionBehaviour>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mListDimensionBehaviors.[Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mListNextMatchConstraintsWidget")]
	protected IList<ConstraintWidget>? MListNextMatchConstraintsWidget
	{
		get
		{
			return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListNextMatchConstraintsWidget.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mListNextMatchConstraintsWidget.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mMatchConstraintDefaultHeight")]
	public int MMatchConstraintDefaultHeight
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintDefaultHeight.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintDefaultHeight.I", this, value);
		}
	}

	[Register("mMatchConstraintDefaultWidth")]
	public int MMatchConstraintDefaultWidth
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintDefaultWidth.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintDefaultWidth.I", this, value);
		}
	}

	[Register("mMatchConstraintMaxHeight")]
	public int MMatchConstraintMaxHeight
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintMaxHeight.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintMaxHeight.I", this, value);
		}
	}

	[Register("mMatchConstraintMaxWidth")]
	public int MMatchConstraintMaxWidth
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintMaxWidth.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintMaxWidth.I", this, value);
		}
	}

	[Register("mMatchConstraintMinHeight")]
	public int MMatchConstraintMinHeight
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintMinHeight.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintMinHeight.I", this, value);
		}
	}

	[Register("mMatchConstraintMinWidth")]
	public int MMatchConstraintMinWidth
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMatchConstraintMinWidth.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintMinWidth.I", this, value);
		}
	}

	[Register("mMatchConstraintPercentHeight")]
	public float MMatchConstraintPercentHeight
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mMatchConstraintPercentHeight.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintPercentHeight.F", this, value);
		}
	}

	[Register("mMatchConstraintPercentWidth")]
	public float MMatchConstraintPercentWidth
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("mMatchConstraintPercentWidth.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMatchConstraintPercentWidth.F", this, value);
		}
	}

	[Register("mMinHeight")]
	protected int MMinHeight
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMinHeight.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMinHeight.I", this, value);
		}
	}

	[Register("mMinWidth")]
	protected int MMinWidth
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mMinWidth.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mMinWidth.I", this, value);
		}
	}

	[Register("mNextChainWidget")]
	protected IList<ConstraintWidget>? MNextChainWidget
	{
		get
		{
			return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mNextChainWidget.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mNextChainWidget.[Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mOffsetX")]
	protected int MOffsetX
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mOffsetX.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mOffsetX.I", this, value);
		}
	}

	[Register("mOffsetY")]
	protected int MOffsetY
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mOffsetY.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mOffsetY.I", this, value);
		}
	}

	[Register("mParent")]
	public ConstraintWidget? MParent
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceFields.GetObjectValue("mParent.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mParent.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mResolvedMatchConstraintDefault")]
	public IList<int>? MResolvedMatchConstraintDefault
	{
		get
		{
			return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mResolvedMatchConstraintDefault.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mResolvedMatchConstraintDefault.[I", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mRight")]
	public ConstraintAnchor? MRight
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mRight.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mRight.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mTop")]
	public ConstraintAnchor? MTop
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mTop.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mTop.Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mVerticalResolution")]
	public int MVerticalResolution
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mVerticalResolution.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mVerticalResolution.I", this, value);
		}
	}

	[Register("mVerticalRun")]
	public VerticalWidgetRun? MVerticalRun
	{
		get
		{
			return Java.Lang.Object.GetObject<VerticalWidgetRun>(_members.InstanceFields.GetObjectValue("mVerticalRun.Landroidx/constraintlayout/core/widgets/analyzer/VerticalWidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mVerticalRun.Landroidx/constraintlayout/core/widgets/analyzer/VerticalWidgetRun;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mWeight")]
	public IList<float>? MWeight
	{
		get
		{
			return Android.Runtime.JavaArray<float>.FromJniHandle(_members.InstanceFields.GetObjectValue("mWeight.[F", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<float>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mWeight.[F", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mX")]
	protected int MX
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mX.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mX.I", this, value);
		}
	}

	[Register("mY")]
	protected int MY
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mY.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mY.I", this, value);
		}
	}

	[Register("run")]
	public IList<WidgetRun>? Run
	{
		get
		{
			return Android.Runtime.JavaArray<WidgetRun>.FromJniHandle(_members.InstanceFields.GetObjectValue("run.[Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<WidgetRun>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("run.[Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("stringId")]
	public string? StringId
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("stringId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("stringId.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("verticalChainRun")]
	public ChainRun? VerticalChainRun
	{
		get
		{
			return Java.Lang.Object.GetObject<ChainRun>(_members.InstanceFields.GetObjectValue("verticalChainRun.Landroidx/constraintlayout/core/widgets/analyzer/ChainRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("verticalChainRun.Landroidx/constraintlayout/core/widgets/analyzer/ChainRun;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("verticalGroup")]
	public int VerticalGroup
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("verticalGroup.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("verticalGroup.I", this, value);
		}
	}

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual IList<ConstraintAnchor>? Anchors
	{
		[Register("getAnchors", "()Ljava/util/ArrayList;", "GetGetAnchorsHandler")]
		get
		{
			return JavaList<ConstraintAnchor>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchors.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool Animated
	{
		[Register("isAnimated", "()Z", "GetIsAnimatedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAnimated.()Z", this, null);
		}
		[Register("setAnimated", "(Z)V", "GetSetAnimated_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAnimated.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int BaselineDistance
	{
		[Register("getBaselineDistance", "()I", "GetGetBaselineDistanceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBaselineDistance.()I", this, null);
		}
		[Register("setBaselineDistance", "(I)V", "GetSetBaselineDistance_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBaselineDistance.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Bottom
	{
		[Register("getBottom", "()I", "GetGetBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBottom.()I", this, null);
		}
	}

	public unsafe virtual Java.Lang.Object? CompanionWidget
	{
		[Register("getCompanionWidget", "()Ljava/lang/Object;", "GetGetCompanionWidgetHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCompanionWidget.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCompanionWidget", "(Ljava/lang/Object;)V", "GetSetCompanionWidget_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCompanionWidget.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ContainerItemSkip
	{
		[Register("getContainerItemSkip", "()I", "GetGetContainerItemSkipHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContainerItemSkip.()I", this, null);
		}
		[Register("setContainerItemSkip", "(I)V", "GetSetContainerItemSkip_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContainerItemSkip.(I)V", this, ptr);
		}
	}

	public unsafe virtual string? DebugName
	{
		[Register("getDebugName", "()Ljava/lang/String;", "GetGetDebugNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDebugName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDebugName", "(Ljava/lang/String;)V", "GetSetDebugName_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugName.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual float DimensionRatio
	{
		[Register("getDimensionRatio", "()F", "GetGetDimensionRatioHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getDimensionRatio.()F", this, null);
		}
	}

	public unsafe virtual int DimensionRatioSide
	{
		[Register("getDimensionRatioSide", "()I", "GetGetDimensionRatioSideHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDimensionRatioSide.()I", this, null);
		}
	}

	public unsafe virtual bool HasBaseline
	{
		[Register("hasBaseline", "()Z", "GetHasBaselineHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasBaseline.()Z", this, null);
		}
		[Register("setHasBaseline", "(Z)V", "GetSetHasBaseline_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHasBaseline.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasDependencies
	{
		[Register("hasDependencies", "()Z", "GetHasDependenciesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDependencies.()Z", this, null);
		}
	}

	public unsafe virtual bool HasDimensionOverride
	{
		[Register("hasDimensionOverride", "()Z", "GetHasDimensionOverrideHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDimensionOverride.()Z", this, null);
		}
	}

	public unsafe virtual int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
		}
		[Register("setHeight", "(I)V", "GetSetHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool HeightWrapContent
	{
		[Register("isHeightWrapContent", "()Z", "GetIsHeightWrapContentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeightWrapContent.()Z", this, null);
		}
		[Register("setHeightWrapContent", "(Z)V", "GetSetHeightWrapContent_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHeightWrapContent.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float HorizontalBiasPercent
	{
		[Register("getHorizontalBiasPercent", "()F", "GetGetHorizontalBiasPercentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getHorizontalBiasPercent.()F", this, null);
		}
		[Register("setHorizontalBiasPercent", "(F)V", "GetSetHorizontalBiasPercent_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalBiasPercent.(F)V", this, ptr);
		}
	}

	public unsafe virtual ConstraintWidget? HorizontalChainControlWidget
	{
		[Register("getHorizontalChainControlWidget", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetHorizontalChainControlWidgetHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalChainControlWidget.()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int HorizontalChainStyle
	{
		[Register("getHorizontalChainStyle", "()I", "GetGetHorizontalChainStyleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalChainStyle.()I", this, null);
		}
		[Register("setHorizontalChainStyle", "(I)V", "GetSetHorizontalChainStyle_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalChainStyle.(I)V", this, ptr);
		}
	}

	public unsafe virtual DimensionBehaviour? HorizontalDimensionBehaviour
	{
		[Register("getHorizontalDimensionBehaviour", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetHorizontalDimensionBehaviourHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalDimensionBehaviour.()Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHorizontalDimensionBehaviour", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetSetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalDimensionBehaviour.(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int HorizontalMargin
	{
		[Register("getHorizontalMargin", "()I", "GetGetHorizontalMarginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalMargin.()I", this, null);
		}
	}

	public unsafe virtual bool InPlaceholder
	{
		[Register("isInPlaceholder", "()Z", "GetIsInPlaceholderHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInPlaceholder.()Z", this, null);
		}
		[Register("setInPlaceholder", "(Z)V", "GetSetInPlaceholder_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInPlaceholder.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool InVirtualLayout
	{
		[Register("isInVirtualLayout", "()Z", "GetIsInVirtualLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInVirtualLayout.()Z", this, null);
		}
		[Register("setInVirtualLayout", "(Z)V", "GetSetInVirtualLayout_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInVirtualLayout.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool IsHorizontalSolvingPassDone
	{
		[Register("isHorizontalSolvingPassDone", "()Z", "GetIsHorizontalSolvingPassDoneHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHorizontalSolvingPassDone.()Z", this, null);
		}
	}

	public unsafe virtual bool IsInHorizontalChain
	{
		[Register("isInHorizontalChain", "()Z", "GetIsInHorizontalChainHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInHorizontalChain.()Z", this, null);
		}
	}

	public unsafe virtual bool IsInVerticalChain
	{
		[Register("isInVerticalChain", "()Z", "GetIsInVerticalChainHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInVerticalChain.()Z", this, null);
		}
	}

	public unsafe virtual bool IsResolvedHorizontally
	{
		[Register("isResolvedHorizontally", "()Z", "GetIsResolvedHorizontallyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolvedHorizontally.()Z", this, null);
		}
	}

	public unsafe virtual bool IsResolvedVertically
	{
		[Register("isResolvedVertically", "()Z", "GetIsResolvedVerticallyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolvedVertically.()Z", this, null);
		}
	}

	public unsafe virtual bool IsRoot
	{
		[Register("isRoot", "()Z", "GetIsRootHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRoot.()Z", this, null);
		}
	}

	public unsafe virtual bool IsSpreadHeight
	{
		[Register("isSpreadHeight", "()Z", "GetIsSpreadHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpreadHeight.()Z", this, null);
		}
	}

	public unsafe virtual bool IsSpreadWidth
	{
		[Register("isSpreadWidth", "()Z", "GetIsSpreadWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpreadWidth.()Z", this, null);
		}
	}

	public unsafe virtual bool IsVerticalSolvingPassDone
	{
		[Register("isVerticalSolvingPassDone", "()Z", "GetIsVerticalSolvingPassDoneHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVerticalSolvingPassDone.()Z", this, null);
		}
	}

	public unsafe virtual int LastHorizontalMeasureSpec
	{
		[Register("getLastHorizontalMeasureSpec", "()I", "GetGetLastHorizontalMeasureSpecHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLastHorizontalMeasureSpec.()I", this, null);
		}
	}

	public unsafe virtual int LastVerticalMeasureSpec
	{
		[Register("getLastVerticalMeasureSpec", "()I", "GetGetLastVerticalMeasureSpecHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLastVerticalMeasureSpec.()I", this, null);
		}
	}

	public unsafe virtual int Left
	{
		[Register("getLeft", "()I", "GetGetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLeft.()I", this, null);
		}
	}

	public unsafe virtual int MaxHeight
	{
		[Register("getMaxHeight", "()I", "GetGetMaxHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxHeight.()I", this, null);
		}
		[Register("setMaxHeight", "(I)V", "GetSetMaxHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxWidth
	{
		[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
		}
		[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool MeasureRequested
	{
		[Register("isMeasureRequested", "()Z", "GetIsMeasureRequestedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasureRequested.()Z", this, null);
		}
		[Register("setMeasureRequested", "(Z)V", "GetSetMeasureRequested_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasureRequested.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int MinHeight
	{
		[Register("getMinHeight", "()I", "GetGetMinHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinHeight.()I", this, null);
		}
		[Register("setMinHeight", "(I)V", "GetSetMinHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MinWidth
	{
		[Register("getMinWidth", "()I", "GetGetMinWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinWidth.()I", this, null);
		}
		[Register("setMinWidth", "(I)V", "GetSetMinWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int OptimizerWrapHeight
	{
		[Register("getOptimizerWrapHeight", "()I", "GetGetOptimizerWrapHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizerWrapHeight.()I", this, null);
		}
	}

	public unsafe virtual int OptimizerWrapWidth
	{
		[Register("getOptimizerWrapWidth", "()I", "GetGetOptimizerWrapWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizerWrapWidth.()I", this, null);
		}
	}

	public unsafe virtual ConstraintWidget? Parent
	{
		[Register("getParent", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetParentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setParent", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "GetSetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setParent.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int Right
	{
		[Register("getRight", "()I", "GetGetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRight.()I", this, null);
		}
	}

	protected unsafe virtual int RootX
	{
		[Register("getRootX", "()I", "GetGetRootXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRootX.()I", this, null);
		}
	}

	protected unsafe virtual int RootY
	{
		[Register("getRootY", "()I", "GetGetRootYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRootY.()I", this, null);
		}
	}

	public unsafe virtual int Top
	{
		[Register("getTop", "()I", "GetGetTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTop.()I", this, null);
		}
	}

	public unsafe virtual string? Type
	{
		[Register("getType", "()Ljava/lang/String;", "GetGetTypeHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setType", "(Ljava/lang/String;)V", "GetSetType_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual float VerticalBiasPercent
	{
		[Register("getVerticalBiasPercent", "()F", "GetGetVerticalBiasPercentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getVerticalBiasPercent.()F", this, null);
		}
		[Register("setVerticalBiasPercent", "(F)V", "GetSetVerticalBiasPercent_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalBiasPercent.(F)V", this, ptr);
		}
	}

	public unsafe virtual ConstraintWidget? VerticalChainControlWidget
	{
		[Register("getVerticalChainControlWidget", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetVerticalChainControlWidgetHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalChainControlWidget.()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int VerticalChainStyle
	{
		[Register("getVerticalChainStyle", "()I", "GetGetVerticalChainStyleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalChainStyle.()I", this, null);
		}
		[Register("setVerticalChainStyle", "(I)V", "GetSetVerticalChainStyle_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalChainStyle.(I)V", this, ptr);
		}
	}

	public unsafe virtual DimensionBehaviour? VerticalDimensionBehaviour
	{
		[Register("getVerticalDimensionBehaviour", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetVerticalDimensionBehaviourHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalDimensionBehaviour.()Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setVerticalDimensionBehaviour", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetSetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalDimensionBehaviour.(Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int VerticalMargin
	{
		[Register("getVerticalMargin", "()I", "GetGetVerticalMarginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalMargin.()I", this, null);
		}
	}

	public unsafe virtual int Visibility
	{
		[Register("getVisibility", "()I", "GetGetVisibilityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.()I", this, null);
		}
		[Register("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
		}
		[Register("setWidth", "(I)V", "GetSetWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool WidthWrapContent
	{
		[Register("isWidthWrapContent", "()Z", "GetIsWidthWrapContentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isWidthWrapContent.()Z", this, null);
		}
		[Register("setWidthWrapContent", "(Z)V", "GetSetWidthWrapContent_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWidthWrapContent.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int WrapBehaviorInParent
	{
		[Register("getWrapBehaviorInParent", "()I", "GetGetWrapBehaviorInParentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWrapBehaviorInParent.()I", this, null);
		}
		[Register("setWrapBehaviorInParent", "(I)V", "GetSetWrapBehaviorInParent_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWrapBehaviorInParent.(I)V", this, ptr);
		}
	}

	protected ConstraintWidget(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ConstraintWidget()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe ConstraintWidget(int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	[Register(".ctor", "(IIII)V", "")]
	public unsafe ConstraintWidget(int x, int y, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(width);
			ptr[3] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe ConstraintWidget(string? debugName)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(debugName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;II)V", "")]
	public unsafe ConstraintWidget(string? debugName, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(debugName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(width);
			ptr[2] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;IIII)V", "")]
	public unsafe ConstraintWidget(string? debugName, int x, int y, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(debugName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			ptr[3] = new JniArgumentValue(width);
			ptr[4] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IIII)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetAnchorsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnchors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnchors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<ConstraintAnchor>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Anchors);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsAnimatedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAnimated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAnimated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Animated ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetAnimated_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAnimated_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAnimated_Z(nint jnienv, nint native__this, sbyte native_animated)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool animated = native_animated != 0;
			constraintWidget.Animated = animated;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBaselineDistanceHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBaselineDistance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBaselineDistance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineDistance;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetBaselineDistance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBaselineDistance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBaselineDistance_I(nint jnienv, nint native__this, int baseline)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineDistance = baseline;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bottom;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetCompanionWidgetHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCompanionWidget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCompanionWidget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompanionWidget);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetCompanionWidget_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCompanionWidget_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompanionWidget_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_companion)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object companionWidget = Java.Lang.Object.GetObject<Java.Lang.Object>(native_companion, JniHandleOwnership.DoNotTransfer);
			constraintWidget.CompanionWidget = companionWidget;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetContainerItemSkipHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContainerItemSkip);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContainerItemSkip(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerItemSkip;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetContainerItemSkip_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContainerItemSkip_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContainerItemSkip_I(nint jnienv, nint native__this, int skip)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerItemSkip = skip;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetDebugNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDebugName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDebugName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DebugName);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetDebugName_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDebugName_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDebugName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string debugName = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			constraintWidget.DebugName = debugName;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetDimensionRatioHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetDimensionRatio);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDimensionRatio(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DimensionRatio;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetDimensionRatioSideHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDimensionRatioSide);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDimensionRatioSide(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DimensionRatioSide;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasBaselineHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasBaseline);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasBaseline(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBaseline ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHasBaseline_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHasBaseline_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHasBaseline_Z(nint jnienv, nint native__this, sbyte native_hasBaseline)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hasBaseline = native_hasBaseline != 0;
			constraintWidget.HasBaseline = hasBaseline;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasDependenciesHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasDependencies);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasDependencies(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDependencies ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasDimensionOverrideHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasDimensionOverride);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasDimensionOverride(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDimensionOverride ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHeight_I(nint jnienv, nint native__this, int h)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height = h;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsHeightWrapContentHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHeightWrapContent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHeightWrapContent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeightWrapContent ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHeightWrapContent_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHeightWrapContent_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHeightWrapContent_Z(nint jnienv, nint native__this, sbyte native_heightWrapContent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool heightWrapContent = native_heightWrapContent != 0;
			constraintWidget.HeightWrapContent = heightWrapContent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHorizontalBiasPercentHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetHorizontalBiasPercent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetHorizontalBiasPercent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalBiasPercent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHorizontalBiasPercent_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetHorizontalBiasPercent_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalBiasPercent_F(nint jnienv, nint native__this, float horizontalBiasPercent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalBiasPercent = horizontalBiasPercent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHorizontalChainControlWidgetHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHorizontalChainControlWidget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHorizontalChainControlWidget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainControlWidget);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHorizontalChainStyleHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalChainStyle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalChainStyle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainStyle;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHorizontalChainStyle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalChainStyle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalChainStyle_I(nint jnienv, nint native__this, int horizontalChainStyle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainStyle = horizontalChainStyle;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHorizontalDimensionBehaviourHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHorizontalDimensionBehaviour);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHorizontalDimensionBehaviour(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalDimensionBehaviour);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_(nint jnienv, nint native__this, nint native_behaviour)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DimensionBehaviour horizontalDimensionBehaviour = Java.Lang.Object.GetObject<DimensionBehaviour>(native_behaviour, JniHandleOwnership.DoNotTransfer);
			constraintWidget.HorizontalDimensionBehaviour = horizontalDimensionBehaviour;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetHorizontalMarginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalMargin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalMargin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalMargin;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInPlaceholderHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInPlaceholder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInPlaceholder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InPlaceholder ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetInPlaceholder_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetInPlaceholder_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInPlaceholder_Z(nint jnienv, nint native__this, sbyte native_inPlaceholder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool inPlaceholder = native_inPlaceholder != 0;
			constraintWidget.InPlaceholder = inPlaceholder;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInVirtualLayoutHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInVirtualLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInVirtualLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InVirtualLayout ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetInVirtualLayout_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetInVirtualLayout_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInVirtualLayout_Z(nint jnienv, nint native__this, sbyte native_inVirtualLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool inVirtualLayout = native_inVirtualLayout != 0;
			constraintWidget.InVirtualLayout = inVirtualLayout;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsHorizontalSolvingPassDoneHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHorizontalSolvingPassDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHorizontalSolvingPassDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHorizontalSolvingPassDone ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInHorizontalChainHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInHorizontalChain);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInHorizontalChain(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInHorizontalChain ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInVerticalChainHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInVerticalChain);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInVerticalChain(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInVerticalChain ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsResolvedHorizontallyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsResolvedHorizontally);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsResolvedHorizontally(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolvedHorizontally ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsResolvedVerticallyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsResolvedVertically);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsResolvedVertically(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolvedVertically ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsRootHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRoot);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRoot(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRoot ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsSpreadHeightHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSpreadHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSpreadHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSpreadHeight ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsSpreadWidthHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSpreadWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSpreadWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSpreadWidth ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsVerticalSolvingPassDoneHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsVerticalSolvingPassDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVerticalSolvingPassDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVerticalSolvingPassDone ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetLastHorizontalMeasureSpecHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLastHorizontalMeasureSpec);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLastHorizontalMeasureSpec(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastHorizontalMeasureSpec;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetLastVerticalMeasureSpecHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLastVerticalMeasureSpec);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLastVerticalMeasureSpec(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastVerticalMeasureSpec;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Left;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMaxHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMaxHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxHeight_I(nint jnienv, nint native__this, int maxHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight = maxHeight;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMaxWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMaxWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidth_I(nint jnienv, nint native__this, int maxWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = maxWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsMeasureRequestedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsMeasureRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMeasureRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureRequested ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMeasureRequested_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetMeasureRequested_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMeasureRequested_Z(nint jnienv, nint native__this, sbyte native_measureRequested)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool measureRequested = native_measureRequested != 0;
			constraintWidget.MeasureRequested = measureRequested;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMinHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMinHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinHeight_I(nint jnienv, nint native__this, int h)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight = h;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMinWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetMinWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinWidth_I(nint jnienv, nint native__this, int w)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth = w;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetOptimizerWrapHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOptimizerWrapHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOptimizerWrapHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizerWrapHeight;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetOptimizerWrapWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOptimizerWrapWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOptimizerWrapWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizerWrapWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetParentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetParent_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget parent = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Parent = parent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Right;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRootXHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRootX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRootX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootX;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRootYHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRootY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRootY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootY;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Top;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetType_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetType_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Type = type;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalBiasPercentHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetVerticalBiasPercent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetVerticalBiasPercent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalBiasPercent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetVerticalBiasPercent_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetVerticalBiasPercent_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalBiasPercent_F(nint jnienv, nint native__this, float verticalBiasPercent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalBiasPercent = verticalBiasPercent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalChainControlWidgetHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVerticalChainControlWidget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVerticalChainControlWidget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainControlWidget);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalChainStyleHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalChainStyle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalChainStyle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainStyle;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetVerticalChainStyle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalChainStyle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalChainStyle_I(nint jnienv, nint native__this, int verticalChainStyle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainStyle = verticalChainStyle;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalDimensionBehaviourHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVerticalDimensionBehaviour);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVerticalDimensionBehaviour(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalDimensionBehaviour);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidget_DimensionBehaviour_(nint jnienv, nint native__this, nint native_behaviour)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DimensionBehaviour verticalDimensionBehaviour = Java.Lang.Object.GetObject<DimensionBehaviour>(native_behaviour, JniHandleOwnership.DoNotTransfer);
			constraintWidget.VerticalDimensionBehaviour = verticalDimensionBehaviour;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVerticalMarginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalMargin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalMargin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalMargin;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVisibilityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibility_I(nint jnienv, nint native__this, int visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility = visibility;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWidth_I(nint jnienv, nint native__this, int w)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width = w;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsWidthWrapContentHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsWidthWrapContent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsWidthWrapContent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidthWrapContent ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetWidthWrapContent_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetWidthWrapContent_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWidthWrapContent_Z(nint jnienv, nint native__this, sbyte native_widthWrapContent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool widthWrapContent = native_widthWrapContent != 0;
			constraintWidget.WidthWrapContent = widthWrapContent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetWrapBehaviorInParentHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWrapBehaviorInParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWrapBehaviorInParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapBehaviorInParent;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetWrapBehaviorInParent_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetWrapBehaviorInParent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWrapBehaviorInParent_I(nint jnienv, nint native__this, int behavior)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapBehaviorInParent = behavior;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetAddChildrenToSolverByDependency_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_LinearSystem_Ljava_util_HashSet_IZHandler()
	{
		return new _JniMarshal_PPLLLIB_V(n_AddChildrenToSolverByDependency_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_LinearSystem_Ljava_util_HashSet_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddChildrenToSolverByDependency_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_LinearSystem_Ljava_util_HashSet_IZ(nint jnienv, nint native__this, nint native_container, nint native_system, nint native_widgets, int orientation, sbyte native_addSelf)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			HashSet widgets = Java.Lang.Object.GetObject<HashSet>(native_widgets, JniHandleOwnership.DoNotTransfer);
			bool addSelf = native_addSelf != 0;
			constraintWidget.AddChildrenToSolverByDependency(container, system, widgets, orientation, addSelf);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addChildrenToSolverByDependency", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/core/LinearSystem;Ljava/util/HashSet;IZ)V", "GetAddChildrenToSolverByDependency_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_LinearSystem_Ljava_util_HashSet_IZHandler")]
	public unsafe virtual void AddChildrenToSolverByDependency(ConstraintWidgetContainer? container, LinearSystem? system, HashSet? widgets, int orientation, bool addSelf)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(widgets?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(orientation);
			ptr[4] = new JniArgumentValue(addSelf ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addChildrenToSolverByDependency.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/core/LinearSystem;Ljava/util/HashSet;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(system);
			GC.KeepAlive(widgets);
		}
	}

	private static Delegate GetAddToSolver_Landroidx_constraintlayout_core_LinearSystem_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_AddToSolver_Landroidx_constraintlayout_core_LinearSystem_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddToSolver_Landroidx_constraintlayout_core_LinearSystem_Z(nint jnienv, nint native__this, nint native_system, sbyte native_optimize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool optimize = native_optimize != 0;
			constraintWidget.AddToSolver(system, optimize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addToSolver", "(Landroidx/constraintlayout/core/LinearSystem;Z)V", "GetAddToSolver_Landroidx_constraintlayout_core_LinearSystem_ZHandler")]
	public unsafe virtual void AddToSolver(LinearSystem? system, bool optimize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(optimize ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addToSolver.(Landroidx/constraintlayout/core/LinearSystem;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetAllowedInBarrierHandler()
	{
		return new global::_JniMarshal_PP_B(n_AllowedInBarrier);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AllowedInBarrier(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowedInBarrier() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("allowedInBarrier", "()Z", "GetAllowedInBarrierHandler")]
	public unsafe virtual bool AllowedInBarrier()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("allowedInBarrier.()Z", this, null);
	}

	private static Delegate GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_I(nint jnienv, nint native__this, nint native_from, nint native_to, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_from, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor to = Java.Lang.Object.GetObject<ConstraintAnchor>(native_to, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintAnchor, to, margin);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("connect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)V", "GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_IHandler")]
	public unsafe virtual void Connect(ConstraintAnchor? from, ConstraintAnchor? to, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;Landroidx/constraintlayout/core/widgets/ConstraintAnchor;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(from);
			GC.KeepAlive(to);
		}
	}

	private static Delegate GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_(nint jnienv, nint native__this, nint native_constraintFrom, nint native_target, nint native_constraintTo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintFrom = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintFrom, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintTo = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintTo, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintFrom, target, constraintTo);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("connect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)V", "GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Handler")]
	public unsafe virtual void Connect(ConstraintAnchor.Type? constraintFrom, ConstraintWidget? target, ConstraintAnchor.Type? constraintTo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(constraintFrom?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(constraintTo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintFrom);
			GC.KeepAlive(target);
			GC.KeepAlive(constraintTo);
		}
	}

	private static Delegate GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IHandler()
	{
		return new _JniMarshal_PPLLLI_V(n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I(nint jnienv, nint native__this, nint native_constraintFrom, nint native_target, nint native_constraintTo, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintFrom = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintFrom, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintTo = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintTo, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintFrom, target, constraintTo, margin);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("connect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;I)V", "GetConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IHandler")]
	public unsafe virtual void Connect(ConstraintAnchor.Type? constraintFrom, ConstraintWidget? target, ConstraintAnchor.Type? constraintTo, int margin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(constraintFrom?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(constraintTo?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintFrom);
			GC.KeepAlive(target);
			GC.KeepAlive(constraintTo);
		}
	}

	private static Delegate GetConnectCircularConstraint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FIHandler()
	{
		return new _JniMarshal_PPLFI_V(n_ConnectCircularConstraint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConnectCircularConstraint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FI(nint jnienv, nint native__this, nint native_target, float angle, int radius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ConnectCircularConstraint(target, angle, radius);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("connectCircularConstraint", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;FI)V", "GetConnectCircularConstraint_Landroidx_constraintlayout_core_widgets_ConstraintWidget_FIHandler")]
	public unsafe virtual void ConnectCircularConstraint(ConstraintWidget? target, float angle, int radius)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(angle);
			ptr[2] = new JniArgumentValue(radius);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connectCircularConstraint.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;FI)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetCopy_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Ljava_util_HashMap_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Copy_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Ljava_util_HashMap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Copy_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Ljava_util_HashMap_(nint jnienv, nint native__this, nint native_src, nint native_map)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget src = Java.Lang.Object.GetObject<ConstraintWidget>(native_src, JniHandleOwnership.DoNotTransfer);
			IDictionary<ConstraintWidget, ConstraintWidget> map = JavaDictionary<ConstraintWidget, ConstraintWidget>.FromJniHandle(native_map, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Copy(src, map);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("copy", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Ljava/util/HashMap;)V", "GetCopy_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Ljava_util_HashMap_Handler")]
	public unsafe virtual void Copy(ConstraintWidget? src, IDictionary<ConstraintWidget, ConstraintWidget>? map)
	{
		nint num = JavaDictionary<ConstraintWidget, ConstraintWidget>.ToLocalJniHandle(map);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("copy.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Ljava/util/HashMap;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(src);
			GC.KeepAlive(map);
		}
	}

	private static Delegate GetCreateObjectVariables_Landroidx_constraintlayout_core_LinearSystem_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_CreateObjectVariables_Landroidx_constraintlayout_core_LinearSystem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateObjectVariables_Landroidx_constraintlayout_core_LinearSystem_(nint jnienv, nint native__this, nint native_system)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			constraintWidget.CreateObjectVariables(system);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("createObjectVariables", "(Landroidx/constraintlayout/core/LinearSystem;)V", "GetCreateObjectVariables_Landroidx_constraintlayout_core_LinearSystem_Handler")]
	public unsafe virtual void CreateObjectVariables(LinearSystem? system)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createObjectVariables.(Landroidx/constraintlayout/core/LinearSystem;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetEnsureMeasureRequestedHandler()
	{
		return new global::_JniMarshal_PP_V(n_EnsureMeasureRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EnsureMeasureRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnsureMeasureRequested();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("ensureMeasureRequested", "()V", "GetEnsureMeasureRequestedHandler")]
	public unsafe virtual void EnsureMeasureRequested()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("ensureMeasureRequested.()V", this, null);
	}

	private static Delegate GetEnsureWidgetRunsHandler()
	{
		return new global::_JniMarshal_PP_V(n_EnsureWidgetRuns);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EnsureWidgetRuns(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnsureWidgetRuns();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("ensureWidgetRuns", "()V", "GetEnsureWidgetRunsHandler")]
	public unsafe virtual void EnsureWidgetRuns()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("ensureWidgetRuns.()V", this, null);
	}

	private static Delegate GetGetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_(nint jnienv, nint native__this, nint native_anchorType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type anchorType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_anchorType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(constraintWidget.GetAnchor(anchorType));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getAnchor", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", "GetGetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Handler")]
	public unsafe virtual ConstraintAnchor? GetAnchor(ConstraintAnchor.Type? anchorType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchorType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchor.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;)Landroidx/constraintlayout/core/widgets/ConstraintAnchor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchorType);
		}
	}

	private static Delegate GetGetBiasPercent_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetBiasPercent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBiasPercent_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBiasPercent(orientation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getBiasPercent", "(I)F", "GetGetBiasPercent_IHandler")]
	public unsafe virtual float GetBiasPercent(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getBiasPercent.(I)F", this, ptr);
	}

	private static Delegate GetGetDimensionBehaviour_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetDimensionBehaviour_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDimensionBehaviour_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimensionBehaviour(orientation));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getDimensionBehaviour", "(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetDimensionBehaviour_IHandler")]
	public unsafe virtual DimensionBehaviour? GetDimensionBehaviour(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDimensionBehaviour.(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLength_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetLength_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLength_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLength(orientation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getLength", "(I)I", "GetGetLength_IHandler")]
	public unsafe virtual int GetLength(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getLength.(I)I", this, ptr);
	}

	private static Delegate GetGetNextChainMember_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetNextChainMember_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNextChainMember_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNextChainMember(orientation));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getNextChainMember", "(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetNextChainMember_IHandler")]
	public unsafe virtual ConstraintWidget? GetNextChainMember(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNextChainMember.(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetPreviousChainMember_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetPreviousChainMember_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPreviousChainMember_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPreviousChainMember(orientation));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getPreviousChainMember", "(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetPreviousChainMember_IHandler")]
	public unsafe virtual ConstraintWidget? GetPreviousChainMember(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviousChainMember.(I)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetRun_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetRun_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRun_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRun(orientation));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getRun", "(I)Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;", "GetGetRun_IHandler")]
	public unsafe virtual WidgetRun? GetRun(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return Java.Lang.Object.GetObject<WidgetRun>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRun.(I)Landroidx/constraintlayout/core/widgets/analyzer/WidgetRun;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetSceneString_Ljava_lang_StringBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetSceneString_Ljava_lang_StringBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetSceneString_Ljava_lang_StringBuilder_(nint jnienv, nint native__this, nint native_ret)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder ret = Java.Lang.Object.GetObject<StringBuilder>(native_ret, JniHandleOwnership.DoNotTransfer);
			constraintWidget.GetSceneString(ret);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSceneString", "(Ljava/lang/StringBuilder;)V", "GetGetSceneString_Ljava_lang_StringBuilder_Handler")]
	public unsafe virtual void GetSceneString(StringBuilder? ret)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ret?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getSceneString.(Ljava/lang/StringBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ret);
		}
	}

	private static Delegate GetGetXHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getX", "()I", "GetGetXHandler")]
	public unsafe virtual int GetX()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getX.()I", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getY", "()I", "GetGetYHandler")]
	public unsafe virtual int GetY()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getY.()I", this, null);
	}

	private static Delegate GetGetHasBaselineHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetHasBaseline);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetHasBaseline(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHasBaseline() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getHasBaseline", "()Z", "GetGetHasBaselineHandler")]
	public unsafe virtual bool GetHasBaseline()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("getHasBaseline.()Z", this, null);
	}

	private static Delegate GetHasDanglingDimension_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasDanglingDimension_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasDanglingDimension_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDanglingDimension(orientation) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("hasDanglingDimension", "(I)Z", "GetHasDanglingDimension_IHandler")]
	public unsafe virtual bool HasDanglingDimension(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDanglingDimension.(I)Z", this, ptr);
	}

	private static Delegate GetHasResolvedTargets_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_HasResolvedTargets_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasResolvedTargets_II(nint jnienv, nint native__this, int orientation, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasResolvedTargets(orientation, size) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("hasResolvedTargets", "(II)Z", "GetHasResolvedTargets_IIHandler")]
	public unsafe virtual bool HasResolvedTargets(int orientation, int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(orientation);
		ptr[1] = new JniArgumentValue(size);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasResolvedTargets.(II)Z", this, ptr);
	}

	private static Delegate GetImmediateConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IIHandler()
	{
		return new _JniMarshal_PPLLLII_V(n_ImmediateConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ImmediateConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_II(nint jnienv, nint native__this, nint native_startType, nint native_target, nint native_endType, int margin, int goneMargin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type startType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_startType, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type endType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_endType, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ImmediateConnect(startType, target, endType, margin, goneMargin);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("immediateConnect", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;II)V", "GetImmediateConnect_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IIHandler")]
	public unsafe virtual void ImmediateConnect(ConstraintAnchor.Type? startType, ConstraintWidget? target, ConstraintAnchor.Type? endType, int margin, int goneMargin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(startType?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(endType?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(margin);
			ptr[4] = new JniArgumentValue(goneMargin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("immediateConnect.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(startType);
			GC.KeepAlive(target);
			GC.KeepAlive(endType);
		}
	}

	private static Delegate GetIsInBarrier_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsInBarrier_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInBarrier_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInBarrier(orientation) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("isInBarrier", "(I)Z", "GetIsInBarrier_IHandler")]
	public unsafe virtual bool IsInBarrier(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInBarrier.(I)Z", this, ptr);
	}

	private static Delegate GetMarkHorizontalSolvingPassDoneHandler()
	{
		return new global::_JniMarshal_PP_V(n_MarkHorizontalSolvingPassDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MarkHorizontalSolvingPassDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarkHorizontalSolvingPassDone();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("markHorizontalSolvingPassDone", "()V", "GetMarkHorizontalSolvingPassDoneHandler")]
	public unsafe virtual void MarkHorizontalSolvingPassDone()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("markHorizontalSolvingPassDone.()V", this, null);
	}

	private static Delegate GetMarkVerticalSolvingPassDoneHandler()
	{
		return new global::_JniMarshal_PP_V(n_MarkVerticalSolvingPassDone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MarkVerticalSolvingPassDone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarkVerticalSolvingPassDone();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("markVerticalSolvingPassDone", "()V", "GetMarkVerticalSolvingPassDoneHandler")]
	public unsafe virtual void MarkVerticalSolvingPassDone()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("markVerticalSolvingPassDone.()V", this, null);
	}

	private static Delegate GetOppositeDimensionDependsOn_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_OppositeDimensionDependsOn_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OppositeDimensionDependsOn_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OppositeDimensionDependsOn(orientation) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("oppositeDimensionDependsOn", "(I)Z", "GetOppositeDimensionDependsOn_IHandler")]
	public unsafe virtual bool OppositeDimensionDependsOn(int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(orientation);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("oppositeDimensionDependsOn.(I)Z", this, ptr);
	}

	private static Delegate GetOppositeDimensionsTiedHandler()
	{
		return new global::_JniMarshal_PP_B(n_OppositeDimensionsTied);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OppositeDimensionsTied(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OppositeDimensionsTied() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("oppositeDimensionsTied", "()Z", "GetOppositeDimensionsTiedHandler")]
	public unsafe virtual bool OppositeDimensionsTied()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("oppositeDimensionsTied.()Z", this, null);
	}

	private static Delegate GetResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetResetAllConstraintsHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResetAllConstraints);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetAllConstraints(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetAllConstraints();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetAllConstraints", "()V", "GetResetAllConstraintsHandler")]
	public unsafe virtual void ResetAllConstraints()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resetAllConstraints.()V", this, null);
	}

	private static Delegate GetResetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ResetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_(nint jnienv, nint native__this, nint native_anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ResetAnchor(anchor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetAnchor", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", "GetResetAnchor_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Handler")]
	public unsafe virtual void ResetAnchor(ConstraintAnchor? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetAnchor.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetResetAnchorsHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResetAnchors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetAnchors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetAnchors();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetAnchors", "()V", "GetResetAnchorsHandler")]
	public unsafe virtual void ResetAnchors()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resetAnchors.()V", this, null);
	}

	private static Delegate GetResetFinalResolutionHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResetFinalResolution);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetFinalResolution(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetFinalResolution();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetFinalResolution", "()V", "GetResetFinalResolutionHandler")]
	public unsafe virtual void ResetFinalResolution()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resetFinalResolution.()V", this, null);
	}

	private static Delegate GetResetSolverVariables_Landroidx_constraintlayout_core_Cache_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ResetSolverVariables_Landroidx_constraintlayout_core_Cache_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetSolverVariables_Landroidx_constraintlayout_core_Cache_(nint jnienv, nint native__this, nint native_cache)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Cache cache = Java.Lang.Object.GetObject<Cache>(native_cache, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ResetSolverVariables(cache);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetSolverVariables", "(Landroidx/constraintlayout/core/Cache;)V", "GetResetSolverVariables_Landroidx_constraintlayout_core_Cache_Handler")]
	public unsafe virtual void ResetSolverVariables(Cache? cache)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetSolverVariables.(Landroidx/constraintlayout/core/Cache;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cache);
		}
	}

	private static Delegate GetResetSolvingPassFlagHandler()
	{
		return new global::_JniMarshal_PP_V(n_ResetSolvingPassFlag);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResetSolvingPassFlag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetSolvingPassFlag();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("resetSolvingPassFlag", "()V", "GetResetSolvingPassFlagHandler")]
	public unsafe virtual void ResetSolvingPassFlag()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("resetSolvingPassFlag.()V", this, null);
	}

	private static Delegate GetSerialize_Ljava_lang_StringBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Serialize_Ljava_lang_StringBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Serialize_Ljava_lang_StringBuilder_(nint jnienv, nint native__this, nint native_ret)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder ret = Java.Lang.Object.GetObject<StringBuilder>(native_ret, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(constraintWidget.Serialize(ret));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("serialize", "(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;", "GetSerialize_Ljava_lang_StringBuilder_Handler")]
	public unsafe virtual StringBuilder? Serialize(StringBuilder? ret)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ret?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<StringBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("serialize.(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(ret);
		}
	}

	private static Delegate GetSetDebugSolverName_Landroidx_constraintlayout_core_LinearSystem_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetDebugSolverName_Landroidx_constraintlayout_core_LinearSystem_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDebugSolverName_Landroidx_constraintlayout_core_LinearSystem_Ljava_lang_String_(nint jnienv, nint native__this, nint native_system, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetDebugSolverName(system, name);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setDebugSolverName", "(Landroidx/constraintlayout/core/LinearSystem;Ljava/lang/String;)V", "GetSetDebugSolverName_Landroidx_constraintlayout_core_LinearSystem_Ljava_lang_String_Handler")]
	public unsafe virtual void SetDebugSolverName(LinearSystem? system, string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugSolverName.(Landroidx/constraintlayout/core/LinearSystem;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(system);
		}
	}

	private static Delegate GetSetDimension_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetDimension_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDimension_II(nint jnienv, nint native__this, int w, int h)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDimension(w, h);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setDimension", "(II)V", "GetSetDimension_IIHandler")]
	public unsafe virtual void SetDimension(int w, int h)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(w);
		ptr[1] = new JniArgumentValue(h);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDimension.(II)V", this, ptr);
	}

	private static Delegate GetSetDimensionRatio_FIHandler()
	{
		return new _JniMarshal_PPFI_V(n_SetDimensionRatio_FI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDimensionRatio_FI(nint jnienv, nint native__this, float ratio, int dimensionRatioSide)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDimensionRatio(ratio, dimensionRatioSide);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setDimensionRatio", "(FI)V", "GetSetDimensionRatio_FIHandler")]
	public unsafe virtual void SetDimensionRatio(float ratio, int dimensionRatioSide)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(ratio);
		ptr[1] = new JniArgumentValue(dimensionRatioSide);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(FI)V", this, ptr);
	}

	private static Delegate GetSetDimensionRatio_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDimensionRatio_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDimensionRatio_Ljava_lang_String_(nint jnienv, nint native__this, nint native_ratio)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string dimensionRatio = JNIEnv.GetString(native_ratio, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetDimensionRatio(dimensionRatio);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setDimensionRatio", "(Ljava/lang/String;)V", "GetSetDimensionRatio_Ljava_lang_String_Handler")]
	public unsafe virtual void SetDimensionRatio(string? ratio)
	{
		nint num = JNIEnv.NewString(ratio);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetFinalBaseline_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFinalBaseline_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalBaseline_I(nint jnienv, nint native__this, int baselineValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalBaseline(baselineValue);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalBaseline", "(I)V", "GetSetFinalBaseline_IHandler")]
	public unsafe virtual void SetFinalBaseline(int baselineValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(baselineValue);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalBaseline.(I)V", this, ptr);
	}

	private static Delegate GetSetFinalFrame_IIIIIIHandler()
	{
		return new global::_JniMarshal_PPIIIIII_V(n_SetFinalFrame_IIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalFrame_IIIIII(nint jnienv, nint native__this, int left, int top, int right, int bottom, int baseline, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalFrame(left, top, right, bottom, baseline, orientation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalFrame", "(IIIIII)V", "GetSetFinalFrame_IIIIIIHandler")]
	public unsafe virtual void SetFinalFrame(int left, int top, int right, int bottom, int baseline, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		ptr[4] = new JniArgumentValue(baseline);
		ptr[5] = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalFrame.(IIIIII)V", this, ptr);
	}

	private static Delegate GetSetFinalHorizontal_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetFinalHorizontal_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalHorizontal_II(nint jnienv, nint native__this, int x1, int x2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalHorizontal(x1, x2);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalHorizontal", "(II)V", "GetSetFinalHorizontal_IIHandler")]
	public unsafe virtual void SetFinalHorizontal(int x1, int x2)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x1);
		ptr[1] = new JniArgumentValue(x2);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalHorizontal.(II)V", this, ptr);
	}

	private static Delegate GetSetFinalLeft_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFinalLeft_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalLeft_I(nint jnienv, nint native__this, int x1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalLeft(x1);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalLeft", "(I)V", "GetSetFinalLeft_IHandler")]
	public unsafe virtual void SetFinalLeft(int x1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(x1);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalLeft.(I)V", this, ptr);
	}

	private static Delegate GetSetFinalTop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFinalTop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalTop_I(nint jnienv, nint native__this, int y1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalTop(y1);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalTop", "(I)V", "GetSetFinalTop_IHandler")]
	public unsafe virtual void SetFinalTop(int y1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(y1);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalTop.(I)V", this, ptr);
	}

	private static Delegate GetSetFinalVertical_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetFinalVertical_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFinalVertical_II(nint jnienv, nint native__this, int y1, int y2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalVertical(y1, y2);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFinalVertical", "(II)V", "GetSetFinalVertical_IIHandler")]
	public unsafe virtual void SetFinalVertical(int y1, int y2)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(y1);
		ptr[1] = new JniArgumentValue(y2);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalVertical.(II)V", this, ptr);
	}

	private static Delegate GetSetFrame_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_SetFrame_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFrame_III(nint jnienv, nint native__this, int start, int end, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFrame(start, end, orientation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFrame", "(III)V", "GetSetFrame_IIIHandler")]
	public unsafe virtual void SetFrame(int start, int end, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		ptr[2] = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFrame.(III)V", this, ptr);
	}

	private static Delegate GetSetFrame_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetFrame_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFrame_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFrame(left, top, right, bottom);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setFrame", "(IIII)V", "GetSetFrame_IIIIHandler")]
	public unsafe virtual void SetFrame(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFrame.(IIII)V", this, ptr);
	}

	private static Delegate GetSetGoneMargin_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetGoneMargin_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGoneMargin_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_I(nint jnienv, nint native__this, nint native_type, int goneMargin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type type = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_type, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetGoneMargin(type, goneMargin);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setGoneMargin", "(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;I)V", "GetSetGoneMargin_Landroidx_constraintlayout_core_widgets_ConstraintAnchor_Type_IHandler")]
	public unsafe virtual void SetGoneMargin(ConstraintAnchor.Type? type, int goneMargin)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(goneMargin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(Landroidx/constraintlayout/core/widgets/ConstraintAnchor$Type;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetSetHorizontalDimension_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetHorizontalDimension_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalDimension_II(nint jnienv, nint native__this, int left, int right)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalDimension(left, right);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setHorizontalDimension", "(II)V", "GetSetHorizontalDimension_IIHandler")]
	public unsafe virtual void SetHorizontalDimension(int left, int right)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(right);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalDimension.(II)V", this, ptr);
	}

	private static Delegate GetSetHorizontalMatchStyle_IIIFHandler()
	{
		return new _JniMarshal_PPIIIF_V(n_SetHorizontalMatchStyle_IIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalMatchStyle_IIIF(nint jnienv, nint native__this, int horizontalMatchStyle, int min, int max, float percent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalMatchStyle(horizontalMatchStyle, min, max, percent);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setHorizontalMatchStyle", "(IIIF)V", "GetSetHorizontalMatchStyle_IIIFHandler")]
	public unsafe virtual void SetHorizontalMatchStyle(int horizontalMatchStyle, int min, int max, float percent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(horizontalMatchStyle);
		ptr[1] = new JniArgumentValue(min);
		ptr[2] = new JniArgumentValue(max);
		ptr[3] = new JniArgumentValue(percent);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalMatchStyle.(IIIF)V", this, ptr);
	}

	private static Delegate GetSetHorizontalWeight_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetHorizontalWeight_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalWeight_F(nint jnienv, nint native__this, float horizontalWeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalWeight(horizontalWeight);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setHorizontalWeight", "(F)V", "GetSetHorizontalWeight_FHandler")]
	public unsafe virtual void SetHorizontalWeight(float horizontalWeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(horizontalWeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalWeight.(F)V", this, ptr);
	}

	private static Delegate GetSetInBarrier_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_SetInBarrier_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInBarrier_IZ(nint jnienv, nint native__this, int orientation, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			constraintWidget.SetInBarrier(orientation, value);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setInBarrier", "(IZ)V", "GetSetInBarrier_IZHandler")]
	protected unsafe virtual void SetInBarrier(int orientation, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(orientation);
		ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setInBarrier.(IZ)V", this, ptr);
	}

	private static Delegate GetSetLastMeasureSpec_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetLastMeasureSpec_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLastMeasureSpec_II(nint jnienv, nint native__this, int horizontal, int vertical)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLastMeasureSpec(horizontal, vertical);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setLastMeasureSpec", "(II)V", "GetSetLastMeasureSpec_IIHandler")]
	public unsafe virtual void SetLastMeasureSpec(int horizontal, int vertical)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(horizontal);
		ptr[1] = new JniArgumentValue(vertical);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLastMeasureSpec.(II)V", this, ptr);
	}

	private static Delegate GetSetLength_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetLength_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLength_II(nint jnienv, nint native__this, int length, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLength(length, orientation);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setLength", "(II)V", "GetSetLength_IIHandler")]
	public unsafe virtual void SetLength(int length, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(length);
		ptr[1] = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLength.(II)V", this, ptr);
	}

	private static Delegate GetSetOffset_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetOffset_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOffset_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOffset(x, y);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setOffset", "(II)V", "GetSetOffset_IIHandler")]
	public unsafe virtual void SetOffset(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOffset.(II)V", this, ptr);
	}

	private static Delegate GetSetOrigin_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetOrigin_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOrigin_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOrigin(x, y);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setOrigin", "(II)V", "GetSetOrigin_IIHandler")]
	public unsafe virtual void SetOrigin(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOrigin.(II)V", this, ptr);
	}

	private static Delegate GetSetVerticalDimension_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetVerticalDimension_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalDimension_II(nint jnienv, nint native__this, int top, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalDimension(top, bottom);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setVerticalDimension", "(II)V", "GetSetVerticalDimension_IIHandler")]
	public unsafe virtual void SetVerticalDimension(int top, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(top);
		ptr[1] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalDimension.(II)V", this, ptr);
	}

	private static Delegate GetSetVerticalMatchStyle_IIIFHandler()
	{
		return new _JniMarshal_PPIIIF_V(n_SetVerticalMatchStyle_IIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalMatchStyle_IIIF(nint jnienv, nint native__this, int verticalMatchStyle, int min, int max, float percent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalMatchStyle(verticalMatchStyle, min, max, percent);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setVerticalMatchStyle", "(IIIF)V", "GetSetVerticalMatchStyle_IIIFHandler")]
	public unsafe virtual void SetVerticalMatchStyle(int verticalMatchStyle, int min, int max, float percent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(verticalMatchStyle);
		ptr[1] = new JniArgumentValue(min);
		ptr[2] = new JniArgumentValue(max);
		ptr[3] = new JniArgumentValue(percent);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalMatchStyle.(IIIF)V", this, ptr);
	}

	private static Delegate GetSetVerticalWeight_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetVerticalWeight_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalWeight_F(nint jnienv, nint native__this, float verticalWeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalWeight(verticalWeight);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setVerticalWeight", "(F)V", "GetSetVerticalWeight_FHandler")]
	public unsafe virtual void SetVerticalWeight(float verticalWeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(verticalWeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalWeight.(F)V", this, ptr);
	}

	private static Delegate GetSetX_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetX_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetX_I(nint jnienv, nint native__this, int x)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetX(x);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setX", "(I)V", "GetSetX_IHandler")]
	public unsafe virtual void SetX(int x)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(x);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setX.(I)V", this, ptr);
	}

	private static Delegate GetSetY_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetY_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetY_I(nint jnienv, nint native__this, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetY(y);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setY", "(I)V", "GetSetY_IHandler")]
	public unsafe virtual void SetY(int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setY.(I)V", this, ptr);
	}

	private static Delegate GetSetupDimensionRatio_ZZZZHandler()
	{
		return new global::_JniMarshal_PPBBBB_V(n_SetupDimensionRatio_ZZZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupDimensionRatio_ZZZZ(nint jnienv, nint native__this, sbyte native_hParentWrapContent, sbyte native_vParentWrapContent, sbyte native_horizontalDimensionFixed, sbyte native_verticalDimensionFixed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hParentWrapContent = native_hParentWrapContent != 0;
			bool vParentWrapContent = native_vParentWrapContent != 0;
			bool horizontalDimensionFixed = native_horizontalDimensionFixed != 0;
			bool verticalDimensionFixed = native_verticalDimensionFixed != 0;
			constraintWidget.SetupDimensionRatio(hParentWrapContent, vParentWrapContent, horizontalDimensionFixed, verticalDimensionFixed);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setupDimensionRatio", "(ZZZZ)V", "GetSetupDimensionRatio_ZZZZHandler")]
	public unsafe virtual void SetupDimensionRatio(bool hParentWrapContent, bool vParentWrapContent, bool horizontalDimensionFixed, bool verticalDimensionFixed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(hParentWrapContent ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(vParentWrapContent ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(horizontalDimensionFixed ? ((sbyte)1) : ((sbyte)0));
		ptr[3] = new JniArgumentValue(verticalDimensionFixed ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setupDimensionRatio.(ZZZZ)V", this, ptr);
	}

	private static Delegate GetUpdateFromRuns_ZZHandler()
	{
		return new _JniMarshal_PPBB_V(n_UpdateFromRuns_ZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromRuns_ZZ(nint jnienv, nint native__this, sbyte native_updateHorizontal, sbyte native_updateVertical)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool updateHorizontal = native_updateHorizontal != 0;
			bool updateVertical = native_updateVertical != 0;
			constraintWidget.UpdateFromRuns(updateHorizontal, updateVertical);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("updateFromRuns", "(ZZ)V", "GetUpdateFromRuns_ZZHandler")]
	public unsafe virtual void UpdateFromRuns(bool updateHorizontal, bool updateVertical)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(updateHorizontal ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(updateVertical ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromRuns.(ZZ)V", this, ptr);
	}

	private static Delegate GetUpdateFromSolver_Landroidx_constraintlayout_core_LinearSystem_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_UpdateFromSolver_Landroidx_constraintlayout_core_LinearSystem_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateFromSolver_Landroidx_constraintlayout_core_LinearSystem_Z(nint jnienv, nint native__this, nint native_system, sbyte native_optimize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintWidget? constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool optimize = native_optimize != 0;
			constraintWidget.UpdateFromSolver(system, optimize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("updateFromSolver", "(Landroidx/constraintlayout/core/LinearSystem;Z)V", "GetUpdateFromSolver_Landroidx_constraintlayout_core_LinearSystem_ZHandler")]
	public unsafe virtual void UpdateFromSolver(LinearSystem? system, bool optimize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(optimize ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSolver.(Landroidx/constraintlayout/core/LinearSystem;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(system);
		}
	}
}
