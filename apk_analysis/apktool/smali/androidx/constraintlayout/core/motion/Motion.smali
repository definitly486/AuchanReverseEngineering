.class public Landroidx/constraintlayout/core/motion/Motion;
.super Ljava/lang/Object;
.source "Motion.java"

# interfaces
.implements Landroidx/constraintlayout/core/motion/utils/TypedValues;


# instance fields
.field private mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

.field private mAttributeInterpolatorCount:[I

.field private mAttributeNames:[Ljava/lang/String;

.field private mAttributesMap:Ljava/util/HashMap;

.field mCurrentCenterX:F

.field mCurrentCenterY:F

.field private mCurveFitType:I

.field private mCycleMap:Ljava/util/HashMap;

.field private mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

.field private mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

.field public mId:Ljava/lang/String;

.field private mInterpolateData:[D

.field private mInterpolateVariables:[I

.field private mInterpolateVelocity:[D

.field private mKeyList:Ljava/util/ArrayList;

.field private mKeyTriggers:[Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyTrigger;

.field private mMaxDimension:I

.field private mMotionPaths:Ljava/util/ArrayList;

.field mMotionStagger:F

.field private mNoMovement:Z

.field private mPathMotionArc:I

.field private mQuantizeMotionInterpolator:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;

.field private mQuantizeMotionPhase:F

.field private mQuantizeMotionSteps:I

.field mRelativeMotion:Landroidx/constraintlayout/core/motion/Motion;

.field private mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

.field mStaggerOffset:F

.field mStaggerScale:F

.field private mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

.field private mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

.field mTempRect:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;

.field private mTimeCycleAttributesMap:Ljava/util/HashMap;

.field private mTransformPivotTarget:I

.field private mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

.field private mValuesBuff:[F

.field private mVelocity:[F

.field mView:Landroidx/constraintlayout/core/motion/MotionWidget;


# direct methods
.method public constructor <init>(Landroidx/constraintlayout/core/motion/MotionWidget;)V
    .locals 4

    .line 155
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 75
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;-><init>()V

    iput-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mTempRect:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;

    const/4 v0, 0x0

    .line 83
    iput v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    .line 84
    new-instance v1, Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-direct {v1}, Landroidx/constraintlayout/core/motion/MotionPaths;-><init>()V

    iput-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 85
    new-instance v1, Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-direct {v1}, Landroidx/constraintlayout/core/motion/MotionPaths;-><init>()V

    iput-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 87
    new-instance v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    invoke-direct {v1}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;-><init>()V

    iput-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    .line 88
    new-instance v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    invoke-direct {v1}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;-><init>()V

    iput-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    const/high16 v1, 0x7fc00000    # Float.NaN

    .line 93
    iput v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionStagger:F

    const/4 v2, 0x0

    .line 94
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerOffset:F

    const/high16 v2, 0x3f800000    # 1.0f

    .line 95
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerScale:F

    const/4 v2, 0x4

    .line 103
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mMaxDimension:I

    .line 104
    new-array v2, v2, [F

    iput-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mValuesBuff:[F

    .line 105
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    iput-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    const/4 v2, 0x1

    .line 106
    new-array v2, v2, [F

    iput-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mVelocity:[F

    .line 108
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    iput-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    const/4 v2, -0x1

    .line 117
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mPathMotionArc:I

    .line 120
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotTarget:I

    const/4 v3, 0x0

    .line 123
    iput-object v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    .line 124
    iput v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionSteps:I

    .line 125
    iput v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionPhase:F

    .line 126
    iput-object v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionInterpolator:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;

    .line 127
    iput-boolean v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mNoMovement:Z

    .line 156
    invoke-virtual {p0, p1}, Landroidx/constraintlayout/core/motion/Motion;->setView(Landroidx/constraintlayout/core/motion/MotionWidget;)V

    return-void
.end method

.method private getAdjustedPosition(F[F)F
    .locals 12

    const/4 v0, 0x0

    const/high16 v1, 0x3f800000    # 1.0f

    const/4 v2, 0x0

    if-eqz p2, :cond_0

    .line 1214
    aput v1, p2, v2

    goto :goto_0

    .line 1215
    :cond_0
    iget v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerScale:F

    float-to-double v4, v3

    const-wide/high16 v6, 0x3ff0000000000000L    # 1.0

    cmpl-double v4, v4, v6

    if-eqz v4, :cond_2

    .line 1216
    iget v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerOffset:F

    cmpg-float v5, p1, v4

    if-gez v5, :cond_1

    move p1, v0

    :cond_1
    cmpl-float v5, p1, v4

    if-lez v5, :cond_2

    float-to-double v8, p1

    cmpg-double v5, v8, v6

    if-gez v5, :cond_2

    sub-float/2addr p1, v4

    mul-float/2addr p1, v3

    .line 1222
    invoke-static {p1, v1}, Ljava/lang/Math;->min(FF)F

    move-result p1

    .line 1228
    :cond_2
    :goto_0
    iget-object v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v3, v3, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    .line 1231
    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v5

    const/high16 v6, 0x7fc00000    # Float.NaN

    move v7, v2

    :cond_3
    :goto_1
    if-ge v7, v5, :cond_5

    invoke-virtual {v4, v7}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    add-int/lit8 v7, v7, 0x1

    check-cast v8, Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 1232
    iget-object v9, v8, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    if-eqz v9, :cond_3

    .line 1233
    iget v10, v8, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    cmpg-float v11, v10, p1

    if-gez v11, :cond_4

    move-object v3, v9

    move v0, v10

    goto :goto_1

    .line 1237
    :cond_4
    invoke-static {v6}, Ljava/lang/Float;->isNaN(F)Z

    move-result v9

    if-eqz v9, :cond_3

    .line 1238
    iget v6, v8, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    goto :goto_1

    :cond_5
    if-eqz v3, :cond_7

    .line 1245
    invoke-static {v6}, Ljava/lang/Float;->isNaN(F)Z

    move-result v4

    if-eqz v4, :cond_6

    goto :goto_2

    :cond_6
    move v1, v6

    :goto_2
    sub-float/2addr p1, v0

    sub-float/2addr v1, v0

    div-float/2addr p1, v1

    float-to-double v4, p1

    .line 1249
    invoke-virtual {v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->get(D)D

    move-result-wide v6

    double-to-float p1, v6

    mul-float/2addr p1, v1

    add-float/2addr p1, v0

    if-eqz p2, :cond_7

    .line 1252
    invoke-virtual {v3, v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->getDiff(D)D

    move-result-wide v0

    double-to-float v0, v0

    aput v0, p2, v2

    :cond_7
    return p1
.end method

.method private static getInterpolator(ILjava/lang/String;I)Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;
    .locals 0

    const/4 p2, -0x1

    if-eq p0, p2, :cond_0

    const/4 p0, 0x0

    return-object p0

    .line 1160
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->getInterpolator(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    move-result-object p0

    .line 1161
    new-instance p1, Landroidx/constraintlayout/core/motion/Motion$1;

    invoke-direct {p1, p0}, Landroidx/constraintlayout/core/motion/Motion$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;)V

    return-object p1
.end method

.method private getPreCycleDistance()F
    .locals 23

    move-object/from16 v0, p0

    const/4 v1, 0x2

    .line 439
    new-array v7, v1, [F

    const/16 v1, 0x63

    int-to-float v1, v1

    const/high16 v9, 0x3f800000    # 1.0f

    div-float v1, v9, v1

    const-wide/16 v2, 0x0

    move-wide v12, v2

    move-wide v14, v12

    const/4 v2, 0x0

    const/16 v16, 0x0

    :goto_0
    const/16 v3, 0x64

    if-ge v2, v3, :cond_6

    int-to-float v3, v2

    mul-float/2addr v3, v1

    float-to-double v4, v3

    .line 448
    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v6, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    .line 451
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v8}, Ljava/util/ArrayList;->size()I

    move-result v9

    const/high16 v17, 0x7fc00000    # Float.NaN

    const/4 v10, 0x0

    const/16 v18, 0x0

    :goto_1
    if-ge v10, v9, :cond_2

    invoke-virtual {v8, v10}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v19

    add-int/lit8 v10, v10, 0x1

    const/16 v20, 0x0

    move-object/from16 v11, v19

    check-cast v11, Landroidx/constraintlayout/core/motion/MotionPaths;

    move/from16 v19, v1

    .line 452
    iget-object v1, v11, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    if-eqz v1, :cond_1

    move-object/from16 v21, v1

    .line 453
    iget v1, v11, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    cmpg-float v22, v1, v3

    if-gez v22, :cond_0

    move/from16 v18, v1

    move-object/from16 v6, v21

    goto :goto_2

    .line 457
    :cond_0
    invoke-static/range {v17 .. v17}, Ljava/lang/Float;->isNaN(F)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 458
    iget v1, v11, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    move/from16 v17, v1

    :cond_1
    :goto_2
    move/from16 v1, v19

    goto :goto_1

    :cond_2
    move/from16 v19, v1

    const/16 v20, 0x0

    if-eqz v6, :cond_4

    .line 465
    invoke-static/range {v17 .. v17}, Ljava/lang/Float;->isNaN(F)Z

    move-result v1

    if-eqz v1, :cond_3

    const/high16 v17, 0x3f800000    # 1.0f

    :cond_3
    sub-float v3, v3, v18

    sub-float v17, v17, v18

    div-float v3, v3, v17

    float-to-double v3, v3

    .line 469
    invoke-virtual {v6, v3, v4}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->get(D)D

    move-result-wide v3

    double-to-float v1, v3

    mul-float v1, v1, v17

    add-float v1, v1, v18

    float-to-double v4, v1

    :cond_4
    move-wide v3, v4

    .line 474
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v1, v1, v20

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v1, v3, v4, v5}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    move v11, v2

    .line 475
    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    const/4 v8, 0x0

    invoke-virtual/range {v2 .. v8}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[FI)V

    const/4 v1, 0x1

    if-lez v11, :cond_5

    .line 477
    aget v2, v7, v1

    float-to-double v2, v2

    sub-double/2addr v14, v2

    aget v2, v7, v20

    float-to-double v2, v2

    sub-double/2addr v12, v2

    invoke-static {v14, v15, v12, v13}, Ljava/lang/Math;->hypot(DD)D

    move-result-wide v2

    double-to-float v2, v2

    add-float v16, v16, v2

    .line 479
    :cond_5
    aget v2, v7, v20

    float-to-double v12, v2

    .line 480
    aget v1, v7, v1

    float-to-double v14, v1

    add-int/lit8 v2, v11, 0x1

    move/from16 v1, v19

    const/high16 v9, 0x3f800000    # 1.0f

    goto/16 :goto_0

    :cond_6
    return v16
.end method

.method private insertKey(Landroidx/constraintlayout/core/motion/MotionPaths;)V
    .locals 7

    .line 626
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v2, 0x0

    const/4 v3, 0x0

    :cond_0
    :goto_0
    if-ge v3, v1, :cond_1

    invoke-virtual {v0, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v3, v3, 0x1

    check-cast v4, Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 627
    iget v5, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    iget v6, v4, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    cmpl-float v5, v5, v6

    if-nez v5, :cond_0

    move-object v2, v4

    goto :goto_0

    :cond_1
    if-eqz v2, :cond_2

    .line 632
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->remove(Ljava/lang/Object;)Z

    .line 634
    :cond_2
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-static {v0, p1}, Ljava/util/Collections;->binarySearch(Ljava/util/List;Ljava/lang/Object;)I

    move-result v0

    if-nez v0, :cond_3

    .line 636
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, " KeyPath position \""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v2, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v2, "\" outside of range"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "MotionController"

    invoke-static {v2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Utils;->loge(Ljava/lang/String;Ljava/lang/String;)V

    .line 638
    :cond_3
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    neg-int v0, v0

    add-int/lit8 v0, v0, -0x1

    invoke-virtual {v1, v0, p1}, Ljava/util/ArrayList;->add(ILjava/lang/Object;)V

    return-void
.end method

.method private readView(Landroidx/constraintlayout/core/motion/MotionPaths;)V
    .locals 4

    .line 1014
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    invoke-virtual {v0}, Landroidx/constraintlayout/core/motion/MotionWidget;->getX()I

    move-result v0

    int-to-float v0, v0

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    invoke-virtual {v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getY()I

    move-result v1

    int-to-float v1, v1

    iget-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    .line 1015
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getWidth()I

    move-result v2

    int-to-float v2, v2

    iget-object v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    invoke-virtual {v3}, Landroidx/constraintlayout/core/motion/MotionWidget;->getHeight()I

    move-result v3

    int-to-float v3, v3

    .line 1014
    invoke-virtual {p1, v0, v1, v2, v3}, Landroidx/constraintlayout/core/motion/MotionPaths;->setBounds(FFFF)V

    return-void
.end method

.method private setupRelative()V
    .locals 3

    .line 252
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mRelativeMotion:Landroidx/constraintlayout/core/motion/Motion;

    if-nez v0, :cond_0

    return-void

    .line 255
    :cond_0
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-virtual {v1, v0, v2}, Landroidx/constraintlayout/core/motion/MotionPaths;->setupRelative(Landroidx/constraintlayout/core/motion/Motion;Landroidx/constraintlayout/core/motion/MotionPaths;)V

    .line 256
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mRelativeMotion:Landroidx/constraintlayout/core/motion/Motion;

    iget-object v2, v1, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-virtual {v0, v1, v2}, Landroidx/constraintlayout/core/motion/MotionPaths;->setupRelative(Landroidx/constraintlayout/core/motion/Motion;Landroidx/constraintlayout/core/motion/MotionPaths;)V

    return-void
.end method


# virtual methods
.method public addKey(Landroidx/constraintlayout/core/motion/key/MotionKey;)V
    .locals 1

    .line 652
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public buildKeyFrames([F[I[I)I
    .locals 9

    const/4 v0, 0x0

    if-eqz p1, :cond_3

    .line 511
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v1, v1, v0

    invoke-virtual {v1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getTimePoints()[D

    move-result-object v1

    if-eqz p2, :cond_0

    .line 513
    iget-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v2}, Ljava/util/ArrayList;->size()I

    move-result v3

    move v4, v0

    move v5, v4

    :goto_0
    if-ge v5, v3, :cond_0

    invoke-virtual {v2, v5}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v6

    add-int/lit8 v5, v5, 0x1

    check-cast v6, Landroidx/constraintlayout/core/motion/MotionPaths;

    add-int/lit8 v7, v4, 0x1

    .line 514
    iget v6, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mMode:I

    aput v6, p2, v4

    move v4, v7

    goto :goto_0

    :cond_0
    if-eqz p3, :cond_1

    .line 519
    iget-object p2, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {p2}, Ljava/util/ArrayList;->size()I

    move-result v2

    move v3, v0

    move v4, v3

    :goto_1
    if-ge v4, v2, :cond_1

    invoke-virtual {p2, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v5

    add-int/lit8 v4, v4, 0x1

    check-cast v5, Landroidx/constraintlayout/core/motion/MotionPaths;

    add-int/lit8 v6, v3, 0x1

    const/high16 v7, 0x42c80000    # 100.0f

    .line 520
    iget v5, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    mul-float/2addr v5, v7

    float-to-int v5, v5

    aput v5, p3, v3

    move v3, v6

    goto :goto_1

    :cond_1
    move p2, v0

    move v8, p2

    .line 524
    :goto_2
    array-length p3, v1

    if-ge p2, p3, :cond_2

    .line 525
    iget-object p3, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object p3, p3, v0

    aget-wide v2, v1, p2

    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {p3, v2, v3, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 526
    iget-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    aget-wide v3, v1, p2

    iget-object v5, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v6, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    move-object v7, p1

    invoke-virtual/range {v2 .. v8}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[FI)V

    add-int/lit8 v8, v8, 0x2

    add-int/lit8 p2, p2, 0x1

    goto :goto_2

    .line 530
    :cond_2
    div-int/lit8 v8, v8, 0x2

    return v8

    :cond_3
    return v0
.end method

.method public buildPath([FI)V
    .locals 27

    move-object/from16 v0, p0

    move/from16 v1, p2

    add-int/lit8 v2, v1, -0x1

    int-to-float v2, v2

    const/high16 v3, 0x3f800000    # 1.0f

    div-float v2, v3, v2

    .line 288
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    const-string v5, "translationX"

    const/4 v6, 0x0

    if-nez v4, :cond_0

    move-object v4, v6

    goto :goto_0

    :cond_0
    invoke-virtual {v4, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Landroidx/constraintlayout/core/motion/utils/SplineSet;

    .line 290
    :goto_0
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    const-string v8, "translationY"

    if-nez v7, :cond_1

    move-object v7, v6

    goto :goto_1

    :cond_1
    invoke-virtual {v7, v8}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Landroidx/constraintlayout/core/motion/utils/SplineSet;

    .line 292
    :goto_1
    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    if-nez v9, :cond_2

    move-object v5, v6

    goto :goto_2

    :cond_2
    invoke-virtual {v9, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;

    .line 294
    :goto_2
    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    if-nez v9, :cond_3

    goto :goto_3

    :cond_3
    invoke-virtual {v9, v8}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;

    :goto_3
    const/4 v9, 0x0

    :goto_4
    if-ge v9, v1, :cond_10

    int-to-float v10, v9

    mul-float/2addr v10, v2

    .line 298
    iget v11, v0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerScale:F

    cmpl-float v12, v11, v3

    const/4 v13, 0x0

    if-eqz v12, :cond_5

    .line 299
    iget v12, v0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerOffset:F

    cmpg-float v14, v10, v12

    if-gez v14, :cond_4

    move v10, v13

    :cond_4
    cmpl-float v14, v10, v12

    if-lez v14, :cond_5

    float-to-double v14, v10

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    cmpg-double v14, v14, v16

    if-gez v14, :cond_5

    sub-float/2addr v10, v12

    mul-float/2addr v10, v11

    .line 305
    invoke-static {v10, v3}, Ljava/lang/Math;->min(FF)F

    move-result v10

    :cond_5
    float-to-double v11, v10

    .line 310
    iget-object v14, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v14, v14, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    .line 313
    iget-object v15, v0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v15}, Ljava/util/ArrayList;->size()I

    move-result v3

    const/high16 v17, 0x7fc00000    # Float.NaN

    const/4 v8, 0x0

    const/16 v18, 0x0

    :goto_5
    if-ge v8, v3, :cond_8

    invoke-virtual {v15, v8}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v19

    add-int/lit8 v8, v8, 0x1

    move-object/from16 v1, v19

    check-cast v1, Landroidx/constraintlayout/core/motion/MotionPaths;

    move/from16 v19, v2

    .line 314
    iget-object v2, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mKeyFrameEasing:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;

    if-eqz v2, :cond_7

    move-object/from16 v20, v2

    .line 315
    iget v2, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    cmpg-float v21, v2, v10

    if-gez v21, :cond_6

    move v13, v2

    move-object/from16 v14, v20

    goto :goto_6

    .line 319
    :cond_6
    invoke-static/range {v17 .. v17}, Ljava/lang/Float;->isNaN(F)Z

    move-result v2

    if-eqz v2, :cond_7

    .line 320
    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    move/from16 v17, v1

    :cond_7
    :goto_6
    move/from16 v1, p2

    move/from16 v2, v19

    goto :goto_5

    :cond_8
    move/from16 v19, v2

    if-eqz v14, :cond_a

    .line 327
    invoke-static/range {v17 .. v17}, Ljava/lang/Float;->isNaN(F)Z

    move-result v1

    if-eqz v1, :cond_9

    const/high16 v17, 0x3f800000    # 1.0f

    :cond_9
    sub-float v1, v10, v13

    sub-float v17, v17, v13

    div-float v1, v1, v17

    float-to-double v1, v1

    .line 331
    invoke-virtual {v14, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Easing;->get(D)D

    move-result-wide v1

    double-to-float v1, v1

    mul-float v1, v1, v17

    add-float/2addr v1, v13

    float-to-double v11, v1

    .line 336
    :cond_a
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v1, v1, v18

    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v1, v11, v12, v2}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 337
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    if-eqz v1, :cond_b

    .line 338
    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    array-length v3, v2

    if-lez v3, :cond_b

    .line 339
    invoke-virtual {v1, v11, v12, v2}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 342
    :cond_b
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    mul-int/lit8 v26, v9, 0x2

    move-object/from16 v25, p1

    move-object/from16 v20, v1

    move-object/from16 v23, v2

    move-object/from16 v24, v3

    move-wide/from16 v21, v11

    invoke-virtual/range {v20 .. v26}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[FI)V

    if-eqz v5, :cond_c

    .line 345
    aget v1, p1, v26

    invoke-virtual {v5, v10}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->get(F)F

    move-result v2

    add-float/2addr v1, v2

    aput v1, p1, v26

    goto :goto_7

    :cond_c
    if-eqz v4, :cond_d

    .line 347
    aget v1, p1, v26

    invoke-virtual {v4, v10}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->get(F)F

    move-result v2

    add-float/2addr v1, v2

    aput v1, p1, v26

    :cond_d
    :goto_7
    if-eqz v6, :cond_e

    add-int/lit8 v26, v26, 0x1

    .line 350
    aget v1, p1, v26

    invoke-virtual {v6, v10}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->get(F)F

    move-result v2

    add-float/2addr v1, v2

    aput v1, p1, v26

    goto :goto_8

    :cond_e
    if-eqz v7, :cond_f

    add-int/lit8 v26, v26, 0x1

    .line 352
    aget v1, p1, v26

    invoke-virtual {v7, v10}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->get(F)F

    move-result v2

    add-float/2addr v1, v2

    aput v1, p1, v26

    :cond_f
    :goto_8
    add-int/lit8 v9, v9, 0x1

    move/from16 v1, p2

    move/from16 v2, v19

    const/high16 v3, 0x3f800000    # 1.0f

    goto/16 :goto_4

    :cond_10
    return-void
.end method

.method public buildRect(F[FI)V
    .locals 3

    const/4 v0, 0x0

    .line 573
    invoke-direct {p0, p1, v0}, Landroidx/constraintlayout/core/motion/Motion;->getAdjustedPosition(F[F)F

    move-result p1

    .line 574
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v1, 0x0

    aget-object v0, v0, v1

    float-to-double v1, p1

    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v0, v1, v2, p1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 575
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {p1, v0, v1, p2, p3}, Landroidx/constraintlayout/core/motion/MotionPaths;->getRect([I[D[FI)V

    return-void
.end method

.method public getAnimateRelativeTo()Ljava/lang/String;
    .locals 1

    .line 241
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mAnimateRelativeTo:Ljava/lang/String;

    return-object v0
.end method

.method public getCenter(D[F[F)V
    .locals 9

    const/4 v0, 0x4

    .line 269
    new-array v5, v0, [D

    .line 270
    new-array v7, v0, [D

    .line 271
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v1, 0x0

    aget-object v0, v0, v1

    invoke-virtual {v0, p1, p2, v5}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 272
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v0, v0, v1

    invoke-virtual {v0, p1, p2, v7}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getSlope(D[D)V

    const/4 v0, 0x0

    .line 273
    invoke-static {p4, v0}, Ljava/util/Arrays;->fill([FF)V

    .line 274
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    move-wide v2, p1

    move-object v6, p3

    move-object v8, p4

    invoke-virtual/range {v1 .. v8}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[F[D[F)V

    return-void
.end method

.method public getCenterX()F
    .locals 1

    .line 260
    iget v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mCurrentCenterX:F

    return v0
.end method

.method public getCenterY()F
    .locals 1

    .line 264
    iget v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mCurrentCenterY:F

    return v0
.end method

.method public getDpDt(FFF[F)V
    .locals 11

    .line 1451
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mVelocity:[F

    invoke-direct {p0, p1, v0}, Landroidx/constraintlayout/core/motion/Motion;->getAdjustedPosition(F[F)F

    move-result p1

    .line 1453
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v1, 0x0

    if-eqz v0, :cond_3

    .line 1454
    aget-object v0, v0, v1

    float-to-double v2, p1

    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    invoke-virtual {v0, v2, v3, p1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getSlope(D[D)V

    .line 1455
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object p1, p1, v1

    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {p1, v2, v3, v0}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1456
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mVelocity:[F

    aget p1, p1, v1

    .line 1457
    :goto_0
    iget-object v9, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    array-length v0, v9

    if-ge v1, v0, :cond_0

    .line 1458
    aget-wide v4, v9, v1

    float-to-double v6, p1

    mul-double/2addr v4, v6

    aput-wide v4, v9, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 1461
    :cond_0
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    if-eqz p1, :cond_2

    .line 1462
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    array-length v1, v0

    if-lez v1, :cond_1

    .line 1463
    invoke-virtual {p1, v2, v3, v0}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1464
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    invoke-virtual {p1, v2, v3, v0}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getSlope(D[D)V

    .line 1465
    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v8, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v9, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    iget-object v10, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    move v5, p2

    move v6, p3

    move-object v7, p4

    invoke-virtual/range {v4 .. v10}, Landroidx/constraintlayout/core/motion/MotionPaths;->setDpDt(FF[F[I[D[D)V

    :cond_1
    return-void

    :cond_2
    move v5, p2

    move v6, p3

    move-object v7, p4

    .line 1470
    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v8, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v10, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual/range {v4 .. v10}, Landroidx/constraintlayout/core/motion/MotionPaths;->setDpDt(FF[F[I[D[D)V

    return-void

    :cond_3
    move v5, p2

    move v6, p3

    move-object v7, p4

    .line 1475
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget p2, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    iget-object p3, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget p4, p3, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    sub-float/2addr p2, p4

    .line 1476
    iget p4, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    iget v0, p3, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    sub-float/2addr p4, v0

    .line 1477
    iget v0, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    iget v2, p3, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    sub-float/2addr v0, v2

    .line 1478
    iget p1, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    iget p3, p3, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    sub-float/2addr p1, p3

    add-float/2addr v0, p2

    add-float/2addr p1, p4

    const/high16 p3, 0x3f800000    # 1.0f

    sub-float v2, p3, v5

    mul-float/2addr p2, v2

    mul-float/2addr v0, v5

    add-float/2addr p2, v0

    .line 1481
    aput p2, v7, v1

    sub-float/2addr p3, v6

    mul-float/2addr p4, p3

    mul-float/2addr p1, v6

    add-float/2addr p4, p1

    const/4 p1, 0x1

    .line 1482
    aput p4, v7, p1

    return-void
.end method

.method public getDrawPath()I
    .locals 5

    .line 1579
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mDrawPath:I

    .line 1580
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v2

    const/4 v3, 0x0

    :goto_0
    if-ge v3, v2, :cond_0

    invoke-virtual {v1, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v3, v3, 0x1

    check-cast v4, Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 1581
    iget v4, v4, Landroidx/constraintlayout/core/motion/MotionPaths;->mDrawPath:I

    invoke-static {v0, v4}, Ljava/lang/Math;->max(II)I

    move-result v0

    goto :goto_0

    .line 1583
    :cond_0
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mDrawPath:I

    invoke-static {v0, v1}, Ljava/lang/Math;->max(II)I

    move-result v0

    return v0
.end method

.method public getFinalHeight()F
    .locals 1

    .line 230
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    return v0
.end method

.method public getFinalWidth()F
    .locals 1

    .line 221
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    return v0
.end method

.method public getFinalX()F
    .locals 1

    .line 184
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    return v0
.end method

.method public getFinalY()F
    .locals 1

    .line 194
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    return v0
.end method

.method public getId(Ljava/lang/String;)I
    .locals 0

    .line 0
    const/4 p1, 0x0

    return p1
.end method

.method public getKeyFrame(I)Landroidx/constraintlayout/core/motion/MotionPaths;
    .locals 1

    .line 152
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/constraintlayout/core/motion/MotionPaths;

    return-object p1
.end method

.method public getKeyFrameInfo(I[I)I
    .locals 16

    move-object/from16 v0, p0

    move/from16 v1, p1

    const/4 v2, 0x2

    .line 1655
    new-array v8, v2, [F

    .line 1657
    iget-object v2, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v2}, Ljava/util/ArrayList;->size()I

    move-result v10

    const/4 v11, 0x0

    move v3, v11

    move v12, v3

    move v13, v12

    :goto_0
    if-ge v3, v10, :cond_2

    invoke-virtual {v2, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v14, v3, 0x1

    move-object v15, v4

    check-cast v15, Landroidx/constraintlayout/core/motion/key/MotionKey;

    .line 1658
    iget v3, v15, Landroidx/constraintlayout/core/motion/key/MotionKey;->mType:I

    if-eq v3, v1, :cond_0

    const/4 v4, -0x1

    if-ne v1, v4, :cond_0

    :goto_1
    move v3, v14

    goto :goto_0

    .line 1662
    :cond_0
    aput v11, p2, v13

    add-int/lit8 v4, v13, 0x1

    .line 1664
    aput v3, p2, v4

    add-int/lit8 v3, v13, 0x2

    .line 1665
    iget v4, v15, Landroidx/constraintlayout/core/motion/key/MotionKey;->mFramePosition:I

    aput v4, p2, v3

    int-to-float v3, v4

    const/high16 v4, 0x42c80000    # 100.0f

    div-float/2addr v3, v4

    .line 1668
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v4, v4, v11

    float-to-double v5, v3

    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v4, v5, v6, v3}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1669
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    move-wide v4, v5

    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    const/4 v9, 0x0

    invoke-virtual/range {v3 .. v9}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[FI)V

    add-int/lit8 v3, v13, 0x3

    .line 1670
    aget v4, v8, v11

    invoke-static {v4}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v4

    aput v4, p2, v3

    add-int/lit8 v3, v13, 0x4

    const/4 v4, 0x1

    .line 1671
    aget v5, v8, v4

    invoke-static {v5}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v5

    aput v5, p2, v3

    .line 1672
    instance-of v5, v15, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;

    if-eqz v5, :cond_1

    .line 1673
    check-cast v15, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;

    add-int/lit8 v3, v13, 0x5

    .line 1674
    iget v5, v15, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;->mPositionType:I

    aput v5, p2, v3

    add-int/lit8 v3, v13, 0x6

    .line 1676
    iget v5, v15, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;->mPercentX:F

    invoke-static {v5}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v5

    aput v5, p2, v3

    add-int/lit8 v3, v13, 0x7

    .line 1677
    iget v5, v15, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;->mPercentY:F

    invoke-static {v5}, Ljava/lang/Float;->floatToIntBits(F)I

    move-result v5

    aput v5, p2, v3

    :cond_1
    add-int/2addr v3, v4

    sub-int v4, v3, v13

    .line 1680
    aput v4, p2, v13

    add-int/lit8 v12, v12, 0x1

    move v13, v3

    goto :goto_1

    :cond_2
    return v12
.end method

.method public getKeyFramePositions([I[F)I
    .locals 13

    .line 1626
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v2, 0x0

    move v3, v2

    move v4, v3

    move v10, v4

    :goto_0
    if-ge v4, v1, :cond_0

    invoke-virtual {v0, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v5

    add-int/lit8 v11, v4, 0x1

    check-cast v5, Landroidx/constraintlayout/core/motion/key/MotionKey;

    add-int/lit8 v12, v3, 0x1

    .line 1627
    iget v4, v5, Landroidx/constraintlayout/core/motion/key/MotionKey;->mFramePosition:I

    iget v5, v5, Landroidx/constraintlayout/core/motion/key/MotionKey;->mType:I

    mul-int/lit16 v5, v5, 0x3e8

    add-int/2addr v5, v4

    aput v5, p1, v3

    int-to-float v3, v4

    const/high16 v4, 0x42c80000    # 100.0f

    div-float/2addr v3, v4

    .line 1629
    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v4, v4, v2

    float-to-double v5, v3

    iget-object v3, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v4, v5, v6, v3}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1630
    iget-object v4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v7, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v8, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    move-object v9, p2

    invoke-virtual/range {v4 .. v10}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCenter(D[I[D[FI)V

    add-int/lit8 v10, v10, 0x2

    move v4, v11

    move v3, v12

    goto :goto_0

    :cond_0
    return v3
.end method

.method public getMotionStagger()F
    .locals 1

    .line 1765
    iget v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionStagger:F

    return v0
.end method

.method getPos(D)[D
    .locals 3

    .line 358
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v1, 0x0

    aget-object v0, v0, v1

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v0, p1, p2, v1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 359
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    if-eqz v0, :cond_0

    .line 360
    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    array-length v2, v1

    if-lez v2, :cond_0

    .line 361
    invoke-virtual {v0, p1, p2, v1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 364
    :cond_0
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    return-object p1
.end method

.method public getStartHeight()F
    .locals 1

    .line 212
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    return v0
.end method

.method public getStartWidth()F
    .locals 1

    .line 203
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    return v0
.end method

.method public getStartX()F
    .locals 1

    .line 165
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    return v0
.end method

.method public getStartY()F
    .locals 1

    .line 175
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v0, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    return v0
.end method

.method public getTransformPivotTarget()I
    .locals 1

    .line 135
    iget v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotTarget:I

    return v0
.end method

.method public getView()Landroidx/constraintlayout/core/motion/MotionWidget;
    .locals 1

    .line 1023
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    return-object v0
.end method

.method public interpolate(Landroidx/constraintlayout/core/motion/MotionWidget;FJLandroidx/constraintlayout/core/motion/utils/KeyCache;)Z
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v2, p1

    const/4 v8, 0x0

    move/from16 v1, p2

    .line 1283
    invoke-direct {v0, v1, v8}, Landroidx/constraintlayout/core/motion/Motion;->getAdjustedPosition(F[F)F

    move-result v1

    .line 1285
    iget v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionSteps:I

    const/4 v9, 0x0

    const/high16 v10, 0x3f800000    # 1.0f

    const/4 v11, -0x1

    if-eq v3, v11, :cond_3

    int-to-float v3, v3

    div-float v3, v10, v3

    div-float v4, v1, v3

    float-to-double v4, v4

    .line 1288
    invoke-static {v4, v5}, Ljava/lang/Math;->floor(D)D

    move-result-wide v4

    double-to-float v4, v4

    mul-float/2addr v4, v3

    rem-float/2addr v1, v3

    div-float/2addr v1, v3

    .line 1291
    iget v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionPhase:F

    invoke-static {v5}, Ljava/lang/Float;->isNaN(F)Z

    move-result v5

    if-nez v5, :cond_0

    .line 1292
    iget v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionPhase:F

    add-float/2addr v1, v5

    rem-float/2addr v1, v10

    .line 1294
    :cond_0
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionInterpolator:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;

    if-eqz v5, :cond_1

    .line 1295
    invoke-interface {v5, v1}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;->getInterpolation(F)F

    move-result v1

    goto :goto_0

    :cond_1
    float-to-double v5, v1

    const-wide/high16 v12, 0x3fe0000000000000L    # 0.5

    cmpl-double v1, v5, v12

    if-lez v1, :cond_2

    move v1, v10

    goto :goto_0

    :cond_2
    move v1, v9

    :goto_0
    mul-float/2addr v1, v3

    add-float/2addr v1, v4

    :cond_3
    move v3, v1

    .line 1302
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    if-eqz v1, :cond_4

    .line 1303
    invoke-virtual {v1}, Ljava/util/HashMap;->values()Ljava/util/Collection;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v4

    if-eqz v4, :cond_4

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Landroidx/constraintlayout/core/motion/utils/SplineSet;

    .line 1304
    invoke-virtual {v4, v2, v3}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->setProperty(Landroidx/constraintlayout/core/motion/utils/TypedValues;F)V

    goto :goto_1

    .line 1319
    :cond_4
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v12, 0x1

    const/4 v13, 0x0

    if-eqz v1, :cond_e

    .line 1320
    aget-object v1, v1, v13

    float-to-double v14, v3

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    invoke-virtual {v1, v14, v15, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1321
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    aget-object v1, v1, v13

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    invoke-virtual {v1, v14, v15, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getSlope(D[D)V

    .line 1322
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    if-eqz v1, :cond_5

    .line 1323
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    array-length v5, v4

    if-lez v5, :cond_5

    .line 1324
    invoke-virtual {v1, v14, v15, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[D)V

    .line 1325
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    invoke-virtual {v1, v14, v15, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getSlope(D[D)V

    .line 1329
    :cond_5
    iget-boolean v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mNoMovement:Z

    if-nez v1, :cond_6

    .line 1330
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    const/4 v7, 0x0

    move/from16 v16, v3

    move-object v3, v2

    move/from16 v2, v16

    invoke-virtual/range {v1 .. v7}, Landroidx/constraintlayout/core/motion/MotionPaths;->setView(FLandroidx/constraintlayout/core/motion/MotionWidget;[I[D[D[D)V

    move-object/from16 v16, v3

    move v3, v2

    move-object/from16 v2, v16

    .line 1333
    :cond_6
    iget v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotTarget:I

    if-eq v1, v11, :cond_8

    .line 1334
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    if-nez v1, :cond_7

    .line 1335
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getParent()Landroidx/constraintlayout/core/motion/MotionWidget;

    move-result-object v1

    .line 1336
    iget v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotTarget:I

    invoke-virtual {v1, v4}, Landroidx/constraintlayout/core/motion/MotionWidget;->findViewById(I)Landroidx/constraintlayout/core/motion/MotionWidget;

    move-result-object v1

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    .line 1338
    :cond_7
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    if-eqz v1, :cond_8

    .line 1340
    invoke-virtual {v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getTop()I

    move-result v1

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    invoke-virtual {v4}, Landroidx/constraintlayout/core/motion/MotionWidget;->getBottom()I

    move-result v4

    add-int/2addr v1, v4

    int-to-float v1, v1

    const/high16 v4, 0x40000000    # 2.0f

    div-float/2addr v1, v4

    .line 1341
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    .line 1342
    invoke-virtual {v5}, Landroidx/constraintlayout/core/motion/MotionWidget;->getLeft()I

    move-result v5

    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    invoke-virtual {v6}, Landroidx/constraintlayout/core/motion/MotionWidget;->getRight()I

    move-result v6

    add-int/2addr v5, v6

    int-to-float v5, v5

    div-float/2addr v5, v4

    .line 1343
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getRight()I

    move-result v4

    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getLeft()I

    move-result v6

    sub-int/2addr v4, v6

    if-lez v4, :cond_8

    .line 1344
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getBottom()I

    move-result v4

    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getTop()I

    move-result v6

    sub-int/2addr v4, v6

    if-lez v4, :cond_8

    .line 1345
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getLeft()I

    move-result v4

    int-to-float v4, v4

    sub-float/2addr v5, v4

    .line 1346
    invoke-virtual {v2}, Landroidx/constraintlayout/core/motion/MotionWidget;->getTop()I

    move-result v4

    int-to-float v4, v4

    sub-float/2addr v1, v4

    .line 1347
    invoke-virtual {v2, v5}, Landroidx/constraintlayout/core/motion/MotionWidget;->setPivotX(F)V

    .line 1348
    invoke-virtual {v2, v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->setPivotY(F)V

    :cond_8
    move v1, v12

    .line 1368
    :goto_2
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    array-length v5, v4

    if-ge v1, v5, :cond_9

    .line 1369
    aget-object v4, v4, v1

    .line 1370
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mValuesBuff:[F

    invoke-virtual {v4, v14, v15, v5}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getPos(D[F)V

    .line 1372
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v4, v4, Landroidx/constraintlayout/core/motion/MotionPaths;->mCustomAttributes:Ljava/util/HashMap;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    add-int/lit8 v6, v1, -0x1

    aget-object v5, v5, v6

    .line 1373
    invoke-virtual {v4, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Landroidx/constraintlayout/core/motion/CustomVariable;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mValuesBuff:[F

    .line 1374
    invoke-virtual {v4, v2, v5}, Landroidx/constraintlayout/core/motion/CustomVariable;->setInterpolatedValue(Landroidx/constraintlayout/core/motion/MotionWidget;[F)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_2

    .line 1376
    :cond_9
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget v4, v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->mVisibilityMode:I

    if-nez v4, :cond_c

    cmpg-float v4, v3, v9

    if-gtz v4, :cond_a

    .line 1378
    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->mVisibility:I

    invoke-virtual {v2, v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->setVisibility(I)V

    goto :goto_3

    :cond_a
    cmpl-float v4, v3, v10

    if-ltz v4, :cond_b

    .line 1380
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->mVisibility:I

    invoke-virtual {v2, v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->setVisibility(I)V

    goto :goto_3

    .line 1381
    :cond_b
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget v4, v4, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->mVisibility:I

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->mVisibility:I

    if-eq v4, v1, :cond_c

    const/4 v1, 0x4

    .line 1382
    invoke-virtual {v2, v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->setVisibility(I)V

    .line 1386
    :cond_c
    :goto_3
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyTriggers:[Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyTrigger;

    if-eqz v1, :cond_f

    .line 1387
    array-length v4, v1

    if-gtz v4, :cond_d

    goto :goto_4

    .line 1388
    :cond_d
    aget-object v1, v1, v13

    throw v8

    .line 1394
    :cond_e
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v4, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v6, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    sub-float/2addr v6, v4

    mul-float/2addr v6, v3

    add-float/2addr v4, v6

    .line 1396
    iget v6, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    iget v7, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    sub-float/2addr v7, v6

    mul-float/2addr v7, v3

    add-float/2addr v6, v7

    .line 1398
    iget v7, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    iget v8, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mWidth:F

    sub-float/2addr v8, v7

    mul-float/2addr v8, v3

    add-float/2addr v7, v8

    .line 1400
    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    iget v5, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mHeight:F

    sub-float/2addr v5, v1

    mul-float/2addr v5, v3

    add-float/2addr v1, v5

    const/high16 v5, 0x3f000000    # 0.5f

    add-float/2addr v4, v5

    float-to-int v8, v4

    add-float/2addr v6, v5

    float-to-int v5, v6

    add-float/2addr v4, v7

    float-to-int v4, v4

    add-float/2addr v6, v1

    float-to-int v1, v6

    .line 1422
    invoke-virtual {v2, v8, v5, v4, v1}, Landroidx/constraintlayout/core/motion/MotionWidget;->layout(IIII)V

    .line 1426
    :cond_f
    :goto_4
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    if-eqz v1, :cond_11

    .line 1427
    invoke-virtual {v1}, Ljava/util/HashMap;->values()Ljava/util/Collection;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v8

    :goto_5
    invoke-interface {v8}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_11

    invoke-interface {v8}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;

    .line 1428
    instance-of v4, v1, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator$PathRotateSet;

    if-eqz v4, :cond_10

    .line 1429
    check-cast v1, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator$PathRotateSet;

    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    aget-wide v5, v4, v13

    aget-wide v9, v4, v12

    move-wide v4, v5

    move-wide v6, v9

    invoke-virtual/range {v1 .. v7}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator$PathRotateSet;->setPathRotate(Landroidx/constraintlayout/core/motion/MotionWidget;FDD)V

    goto :goto_5

    .line 1432
    :cond_10
    invoke-virtual {v1, v2, v3}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->setProperty(Landroidx/constraintlayout/core/motion/MotionWidget;F)V

    goto :goto_5

    :cond_11
    return v13
.end method

.method public setDrawPath(I)V
    .locals 1

    .line 1588
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iput p1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mDrawPath:I

    return-void
.end method

.method public setEnd(Landroidx/constraintlayout/core/motion/MotionWidget;)V
    .locals 5

    .line 1041
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    const/high16 v1, 0x3f800000    # 1.0f

    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    .line 1042
    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    .line 1043
    invoke-direct {p0, v0}, Landroidx/constraintlayout/core/motion/Motion;->readView(Landroidx/constraintlayout/core/motion/MotionPaths;)V

    .line 1044
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getLeft()I

    move-result v1

    int-to-float v1, v1

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getTop()I

    move-result v2

    int-to-float v2, v2

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getWidth()I

    move-result v3

    int-to-float v3, v3

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getHeight()I

    move-result v4

    int-to-float v4, v4

    invoke-virtual {v0, v1, v2, v3, v4}, Landroidx/constraintlayout/core/motion/MotionPaths;->setBounds(FFFF)V

    .line 1045
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-virtual {v0, p1}, Landroidx/constraintlayout/core/motion/MotionPaths;->applyParameters(Landroidx/constraintlayout/core/motion/MotionWidget;)V

    .line 1046
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    invoke-virtual {v0, p1}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->setState(Landroidx/constraintlayout/core/motion/MotionWidget;)V

    return-void
.end method

.method public setIdString(Ljava/lang/String;)V
    .locals 1

    .line 1769
    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mId:Ljava/lang/String;

    .line 1770
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iput-object p1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mId:Ljava/lang/String;

    return-void
.end method

.method public setPathMotionArc(I)V
    .locals 0

    .line 659
    iput p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mPathMotionArc:I

    return-void
.end method

.method public setStaggerOffset(F)V
    .locals 0

    .line 1753
    iput p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerOffset:F

    return-void
.end method

.method public setStaggerScale(F)V
    .locals 0

    .line 1744
    iput p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStaggerScale:F

    return-void
.end method

.method public setStart(Landroidx/constraintlayout/core/motion/MotionWidget;)V
    .locals 5

    .line 1028
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    const/4 v1, 0x0

    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    .line 1029
    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    .line 1030
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getX()I

    move-result v1

    int-to-float v1, v1

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getY()I

    move-result v2

    int-to-float v2, v2

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getWidth()I

    move-result v3

    int-to-float v3, v3

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getHeight()I

    move-result v4

    int-to-float v4, v4

    invoke-virtual {v0, v1, v2, v3, v4}, Landroidx/constraintlayout/core/motion/MotionPaths;->setBounds(FFFF)V

    .line 1031
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    invoke-virtual {v0, p1}, Landroidx/constraintlayout/core/motion/MotionPaths;->applyParameters(Landroidx/constraintlayout/core/motion/MotionWidget;)V

    .line 1032
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    invoke-virtual {v0, p1}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->setState(Landroidx/constraintlayout/core/motion/MotionWidget;)V

    .line 1033
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/MotionWidget;->getWidgetFrame()Landroidx/constraintlayout/core/state/WidgetFrame;

    move-result-object p1

    invoke-virtual {p1}, Landroidx/constraintlayout/core/state/WidgetFrame;->getMotionProperties()Landroidx/constraintlayout/core/motion/utils/TypedBundle;

    move-result-object p1

    if-eqz p1, :cond_0

    .line 1035
    invoke-virtual {p1, p0}, Landroidx/constraintlayout/core/motion/utils/TypedBundle;->applyDelta(Landroidx/constraintlayout/core/motion/utils/TypedValues;)V

    :cond_0
    return-void
.end method

.method public setStartState(Landroidx/constraintlayout/core/motion/utils/ViewState;Landroidx/constraintlayout/core/motion/MotionWidget;III)V
    .locals 4

    .line 1055
    iget-object v0, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    const/4 v1, 0x0

    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    .line 1056
    iput v1, v0, Landroidx/constraintlayout/core/motion/MotionPaths;->mPosition:F

    .line 1058
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;-><init>()V

    const/4 v1, 0x1

    const/4 v2, 0x2

    if-eq p3, v1, :cond_1

    if-eq p3, v2, :cond_0

    goto :goto_0

    .line 1061
    :cond_0
    iget p4, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->left:I

    iget v1, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->right:I

    add-int/2addr p4, v1

    .line 1062
    iget v1, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->top:I

    iget v3, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->bottom:I

    add-int/2addr v1, v3

    .line 1063
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->width()I

    move-result v3

    add-int/2addr v1, v3

    div-int/2addr v1, v2

    sub-int/2addr p5, v1

    iput p5, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->left:I

    .line 1064
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->height()I

    move-result p5

    sub-int/2addr p4, p5

    div-int/2addr p4, v2

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->top:I

    .line 1065
    iget p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->left:I

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->width()I

    move-result p5

    add-int/2addr p4, p5

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->right:I

    .line 1066
    iget p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->top:I

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->height()I

    move-result p5

    add-int/2addr p4, p5

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->bottom:I

    goto :goto_0

    .line 1069
    :cond_1
    iget p5, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->left:I

    iget v1, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->right:I

    add-int/2addr p5, v1

    .line 1070
    iget v1, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->top:I

    iget v3, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->bottom:I

    add-int/2addr v1, v3

    .line 1071
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->width()I

    move-result v3

    sub-int/2addr v1, v3

    div-int/2addr v1, v2

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->left:I

    .line 1072
    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->height()I

    move-result v1

    add-int/2addr p5, v1

    div-int/2addr p5, v2

    sub-int/2addr p4, p5

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->top:I

    .line 1073
    iget p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->left:I

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->width()I

    move-result p5

    add-int/2addr p4, p5

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->right:I

    .line 1074
    iget p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->top:I

    invoke-virtual {p1}, Landroidx/constraintlayout/core/motion/utils/ViewState;->height()I

    move-result p5

    add-int/2addr p4, p5

    iput p4, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->bottom:I

    .line 1077
    :goto_0
    iget-object p4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget p5, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->left:I

    int-to-float p5, p5

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->top:I

    int-to-float v1, v1

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->width()I

    move-result v2

    int-to-float v2, v2

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;->height()I

    move-result v3

    int-to-float v3, v3

    invoke-virtual {p4, p5, v1, v2, v3}, Landroidx/constraintlayout/core/motion/MotionPaths;->setBounds(FFFF)V

    .line 1078
    iget-object p4, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget p1, p1, Landroidx/constraintlayout/core/motion/utils/ViewState;->rotation:F

    invoke-virtual {p4, v0, p2, p3, p1}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->setState(Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/Rect;Landroidx/constraintlayout/core/motion/MotionWidget;IF)V

    return-void
.end method

.method public setTransformPivotTarget(I)V
    .locals 0

    .line 144
    iput p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotTarget:I

    const/4 p1, 0x0

    .line 145
    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mTransformPivotView:Landroidx/constraintlayout/core/motion/MotionWidget;

    return-void
.end method

.method public setValue(IF)Z
    .locals 2

    const/16 v0, 0x25a

    const/4 v1, 0x1

    if-ne v0, p1, :cond_0

    .line 1706
    iput p2, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionPhase:F

    return v1

    :cond_0
    const/16 v0, 0x258

    if-ne v0, p1, :cond_1

    .line 1710
    iput p2, p0, Landroidx/constraintlayout/core/motion/Motion;->mMotionStagger:F

    return v1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public setValue(II)Z
    .locals 2

    const/16 v0, 0x1fd

    const/4 v1, 0x1

    if-eq p1, v0, :cond_2

    const/16 v0, 0x262

    if-eq p1, v0, :cond_1

    const/16 p2, 0x2c0

    if-eq p1, p2, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_0
    return v1

    .line 1694
    :cond_1
    iput p2, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionSteps:I

    return v1

    .line 1691
    :cond_2
    invoke-virtual {p0, p2}, Landroidx/constraintlayout/core/motion/Motion;->setPathMotionArc(I)V

    return v1
.end method

.method public setValue(ILjava/lang/String;)Z
    .locals 3

    const/16 v0, 0x2c1

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-eq v0, p1, :cond_2

    const/16 v0, 0x263

    if-ne v0, p1, :cond_0

    goto :goto_0

    :cond_0
    const/16 v0, 0x25d

    if-ne v0, p1, :cond_1

    .line 1724
    iget-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iput-object p2, p1, Landroidx/constraintlayout/core/motion/MotionPaths;->mAnimateRelativeTo:Ljava/lang/String;

    return v2

    :cond_1
    return v1

    :cond_2
    :goto_0
    const/4 p1, -0x1

    .line 1720
    invoke-static {p1, p2, v1}, Landroidx/constraintlayout/core/motion/Motion;->getInterpolator(ILjava/lang/String;I)Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;

    move-result-object p1

    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mQuantizeMotionInterpolator:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/DifferentialInterpolator;

    return v2
.end method

.method public setValue(IZ)Z
    .locals 0

    .line 0
    const/4 p1, 0x0

    return p1
.end method

.method public setView(Landroidx/constraintlayout/core/motion/MotionWidget;)V
    .locals 0

    .line 1019
    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mView:Landroidx/constraintlayout/core/motion/MotionWidget;

    return-void
.end method

.method public setup(IIFJ)V
    .locals 20

    move-object/from16 v0, p0

    move-wide/from16 v1, p4

    .line 671
    new-instance v3, Ljava/util/HashSet;

    invoke-direct {v3}, Ljava/util/HashSet;-><init>()V

    .line 673
    new-instance v3, Ljava/util/HashSet;

    invoke-direct {v3}, Ljava/util/HashSet;-><init>()V

    .line 674
    new-instance v4, Ljava/util/HashSet;

    invoke-direct {v4}, Ljava/util/HashSet;-><init>()V

    .line 675
    new-instance v5, Ljava/util/HashSet;

    invoke-direct {v5}, Ljava/util/HashSet;-><init>()V

    .line 676
    new-instance v6, Ljava/util/HashMap;

    invoke-direct {v6}, Ljava/util/HashMap;-><init>()V

    .line 679
    invoke-direct {v0}, Landroidx/constraintlayout/core/motion/Motion;->setupRelative()V

    .line 690
    iget v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mPathMotionArc:I

    const/4 v8, -0x1

    if-eq v7, v8, :cond_0

    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v10, v9, Landroidx/constraintlayout/core/motion/MotionPaths;->mPathMotionArc:I

    if-ne v10, v8, :cond_0

    .line 691
    iput v7, v9, Landroidx/constraintlayout/core/motion/MotionPaths;->mPathMotionArc:I

    .line 694
    :cond_0
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    invoke-virtual {v7, v9, v4}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->different(Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;Ljava/util/HashSet;)V

    .line 701
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    if-eqz v7, :cond_4

    .line 702
    invoke-virtual {v7}, Ljava/util/ArrayList;->size()I

    move-result v10

    const/4 v11, 0x0

    :cond_1
    :goto_0
    if-ge v11, v10, :cond_4

    invoke-virtual {v7, v11}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v12

    add-int/lit8 v11, v11, 0x1

    check-cast v12, Landroidx/constraintlayout/core/motion/key/MotionKey;

    .line 703
    instance-of v13, v12, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;

    if-eqz v13, :cond_2

    .line 704
    move-object/from16 v17, v12

    check-cast v17, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;

    .line 705
    new-instance v14, Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v12, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v13, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    move/from16 v15, p1

    move/from16 v16, p2

    move-object/from16 v18, v12

    move-object/from16 v19, v13

    invoke-direct/range {v14 .. v19}, Landroidx/constraintlayout/core/motion/MotionPaths;-><init>(IILandroidx/constraintlayout/core/motion/key/MotionKeyPosition;Landroidx/constraintlayout/core/motion/MotionPaths;Landroidx/constraintlayout/core/motion/MotionPaths;)V

    move-object/from16 v12, v17

    invoke-direct {v0, v14}, Landroidx/constraintlayout/core/motion/Motion;->insertKey(Landroidx/constraintlayout/core/motion/MotionPaths;)V

    .line 707
    iget v12, v12, Landroidx/constraintlayout/core/motion/key/MotionKeyPosition;->mCurveFit:I

    if-eq v12, v8, :cond_1

    .line 708
    iput v12, v0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    goto :goto_0

    .line 710
    :cond_2
    instance-of v13, v12, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyCycle;

    if-eqz v13, :cond_3

    .line 711
    invoke-virtual {v12, v5}, Landroidx/constraintlayout/core/motion/key/MotionKey;->getAttributeNames(Ljava/util/HashSet;)V

    goto :goto_0

    .line 720
    :cond_3
    invoke-virtual {v12, v6}, Landroidx/constraintlayout/core/motion/key/MotionKey;->setInterpolation(Ljava/util/HashMap;)V

    .line 721
    invoke-virtual {v12, v4}, Landroidx/constraintlayout/core/motion/key/MotionKey;->getAttributeNames(Ljava/util/HashSet;)V

    goto :goto_0

    .line 733
    :cond_4
    invoke-virtual {v4}, Ljava/util/HashSet;->isEmpty()Z

    move-result v7

    const-string v10, ","

    const-string v11, "CUSTOM,"

    const/4 v12, 0x1

    if-nez v7, :cond_f

    .line 734
    new-instance v7, Ljava/util/HashMap;

    invoke-direct {v7}, Ljava/util/HashMap;-><init>()V

    iput-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    .line 735
    invoke-virtual {v4}, Ljava/util/HashSet;->iterator()Ljava/util/Iterator;

    move-result-object v7

    :goto_1
    invoke-interface {v7}, Ljava/util/Iterator;->hasNext()Z

    move-result v13

    if-eqz v13, :cond_a

    invoke-interface {v7}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Ljava/lang/String;

    .line 737
    invoke-virtual {v13, v11}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v14

    if-eqz v14, :cond_8

    .line 738
    new-instance v14, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;

    invoke-direct {v14}, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;-><init>()V

    .line 739
    invoke-virtual {v13, v10}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v15

    aget-object v15, v15, v12

    move/from16 p1, v12

    .line 740
    iget-object v12, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v12}, Ljava/util/ArrayList;->size()I

    move-result v8

    const/4 v9, 0x0

    :goto_2
    if-ge v9, v8, :cond_7

    invoke-virtual {v12, v9}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v17

    add-int/lit8 v9, v9, 0x1

    move-object/from16 v18, v3

    move-object/from16 v3, v17

    check-cast v3, Landroidx/constraintlayout/core/motion/key/MotionKey;

    move-object/from16 v17, v5

    .line 741
    iget-object v5, v3, Landroidx/constraintlayout/core/motion/key/MotionKey;->mCustom:Ljava/util/HashMap;

    if-nez v5, :cond_6

    :cond_5
    :goto_3
    move-object/from16 v5, v17

    move-object/from16 v3, v18

    goto :goto_2

    .line 744
    :cond_6
    invoke-virtual {v5, v15}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Landroidx/constraintlayout/core/motion/CustomVariable;

    if-eqz v5, :cond_5

    .line 746
    iget v3, v3, Landroidx/constraintlayout/core/motion/key/MotionKey;->mFramePosition:I

    invoke-virtual {v14, v3, v5}, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;->append(ILandroidx/constraintlayout/core/motion/CustomVariable;)V

    goto :goto_3

    :cond_7
    move-object/from16 v18, v3

    move-object/from16 v17, v5

    .line 749
    invoke-static {v13, v14}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->makeCustomSplineSet(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;)Landroidx/constraintlayout/core/motion/utils/SplineSet;

    move-result-object v3

    goto :goto_4

    :cond_8
    move-object/from16 v18, v3

    move-object/from16 v17, v5

    move/from16 p1, v12

    .line 751
    invoke-static {v13, v1, v2}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->makeSpline(Ljava/lang/String;J)Landroidx/constraintlayout/core/motion/utils/SplineSet;

    move-result-object v3

    :goto_4
    if-nez v3, :cond_9

    :goto_5
    move/from16 v12, p1

    move-object/from16 v5, v17

    move-object/from16 v3, v18

    const/4 v8, -0x1

    goto :goto_1

    .line 756
    :cond_9
    invoke-virtual {v3, v13}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->setType(Ljava/lang/String;)V

    .line 757
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v5, v13, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_5

    :cond_a
    move-object/from16 v18, v3

    move-object/from16 v17, v5

    move/from16 p1, v12

    .line 759
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    if-eqz v3, :cond_c

    .line 760
    invoke-virtual {v3}, Ljava/util/ArrayList;->size()I

    move-result v5

    const/4 v7, 0x0

    :cond_b
    :goto_6
    if-ge v7, v5, :cond_c

    invoke-virtual {v3, v7}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    add-int/lit8 v7, v7, 0x1

    check-cast v8, Landroidx/constraintlayout/core/motion/key/MotionKey;

    .line 761
    instance-of v9, v8, Landroidx/constraintlayout/core/motion/key/MotionKeyAttributes;

    if-eqz v9, :cond_b

    .line 762
    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v8, v9}, Landroidx/constraintlayout/core/motion/key/MotionKey;->addValues(Ljava/util/HashMap;)V

    goto :goto_6

    .line 766
    :cond_c
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    const/4 v7, 0x0

    invoke-virtual {v3, v5, v7}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->addValues(Ljava/util/HashMap;I)V

    .line 767
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndPoint:Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    const/16 v7, 0x64

    invoke-virtual {v3, v5, v7}, Landroidx/constraintlayout/core/motion/MotionConstrainedPoint;->addValues(Ljava/util/HashMap;I)V

    .line 769
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v3}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v3

    invoke-interface {v3}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :cond_d
    :goto_7
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_10

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 771
    invoke-virtual {v6, v5}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_e

    .line 772
    invoke-virtual {v6, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Ljava/lang/Integer;

    if-eqz v7, :cond_e

    .line 774
    invoke-virtual {v7}, Ljava/lang/Integer;->intValue()I

    move-result v7

    goto :goto_8

    :cond_e
    const/4 v7, 0x0

    .line 777
    :goto_8
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v8, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Landroidx/constraintlayout/core/motion/utils/SplineSet;

    if-eqz v5, :cond_d

    .line 779
    invoke-virtual {v5, v7}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->setup(I)V

    goto :goto_7

    :cond_f
    move-object/from16 v18, v3

    move-object/from16 v17, v5

    move/from16 p1, v12

    .line 785
    :cond_10
    invoke-virtual/range {v18 .. v18}, Ljava/util/HashSet;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_1b

    .line 786
    iget-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mTimeCycleAttributesMap:Ljava/util/HashMap;

    if-nez v3, :cond_11

    .line 787
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    iput-object v3, v0, Landroidx/constraintlayout/core/motion/Motion;->mTimeCycleAttributesMap:Ljava/util/HashMap;

    .line 789
    :cond_11
    invoke-virtual/range {v18 .. v18}, Ljava/util/HashSet;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_9
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_18

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 790
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mTimeCycleAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v7, v5}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_12

    goto :goto_9

    .line 795
    :cond_12
    invoke-virtual {v5, v11}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_16

    .line 796
    new-instance v7, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;

    invoke-direct {v7}, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;-><init>()V

    .line 797
    invoke-virtual {v5, v10}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v8

    aget-object v8, v8, p1

    .line 798
    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v9}, Ljava/util/ArrayList;->size()I

    move-result v12

    const/4 v13, 0x0

    :cond_13
    :goto_a
    if-ge v13, v12, :cond_15

    invoke-virtual {v9, v13}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v14

    add-int/lit8 v13, v13, 0x1

    check-cast v14, Landroidx/constraintlayout/core/motion/key/MotionKey;

    .line 799
    iget-object v15, v14, Landroidx/constraintlayout/core/motion/key/MotionKey;->mCustom:Ljava/util/HashMap;

    if-nez v15, :cond_14

    goto :goto_a

    .line 802
    :cond_14
    invoke-virtual {v15, v8}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v15

    check-cast v15, Landroidx/constraintlayout/core/motion/CustomVariable;

    if-eqz v15, :cond_13

    .line 804
    iget v14, v14, Landroidx/constraintlayout/core/motion/key/MotionKey;->mFramePosition:I

    invoke-virtual {v7, v14, v15}, Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;->append(ILandroidx/constraintlayout/core/motion/CustomVariable;)V

    goto :goto_a

    .line 807
    :cond_15
    invoke-static {v5, v7}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->makeCustomSplineSet(Ljava/lang/String;Landroidx/constraintlayout/core/motion/utils/KeyFrameArray$CustomVar;)Landroidx/constraintlayout/core/motion/utils/SplineSet;

    move-result-object v7

    goto :goto_b

    .line 809
    :cond_16
    invoke-static {v5, v1, v2}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->makeSpline(Ljava/lang/String;J)Landroidx/constraintlayout/core/motion/utils/SplineSet;

    move-result-object v7

    :goto_b
    if-nez v7, :cond_17

    goto :goto_9

    .line 814
    :cond_17
    invoke-virtual {v7, v5}, Landroidx/constraintlayout/core/motion/utils/SplineSet;->setType(Ljava/lang/String;)V

    goto :goto_9

    .line 818
    :cond_18
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    if-eqz v1, :cond_19

    .line 819
    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v2

    const/4 v3, 0x0

    :goto_c
    if-ge v3, v2, :cond_19

    invoke-virtual {v1, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v5

    add-int/lit8 v3, v3, 0x1

    check-cast v5, Landroidx/constraintlayout/core/motion/key/MotionKey;

    goto :goto_c

    .line 826
    :cond_19
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mTimeCycleAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v1}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_d
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1b

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 828
    invoke-virtual {v6, v2}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1a

    .line 829
    invoke-virtual {v6, v2}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/Integer;

    invoke-virtual {v3}, Ljava/lang/Integer;->intValue()I

    move-result v3

    goto :goto_e

    :cond_1a
    const/4 v3, 0x0

    .line 831
    :goto_e
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mTimeCycleAttributesMap:Ljava/util/HashMap;

    invoke-virtual {v5, v2}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/TimeCycleSplineSet;

    invoke-virtual {v2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/TimeCycleSplineSet;->setup(I)V

    goto :goto_d

    .line 837
    :cond_1b
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    add-int/lit8 v2, v1, 0x2

    new-array v3, v2, [Landroidx/constraintlayout/core/motion/MotionPaths;

    .line 839
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    const/4 v7, 0x0

    aput-object v5, v3, v7

    add-int/lit8 v1, v1, 0x1

    .line 840
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    aput-object v5, v3, v1

    .line 841
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    if-lez v1, :cond_1c

    iget v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    sget v5, Landroidx/constraintlayout/core/motion/key/MotionKey;->UNSET:I

    if-ne v1, v5, :cond_1c

    .line 842
    iput v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    .line 844
    :cond_1c
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mMotionPaths:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v5

    move/from16 v7, p1

    const/4 v6, 0x0

    :goto_f
    if-ge v6, v5, :cond_1d

    invoke-virtual {v1, v6}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v8

    add-int/lit8 v6, v6, 0x1

    check-cast v8, Landroidx/constraintlayout/core/motion/MotionPaths;

    add-int/lit8 v9, v7, 0x1

    .line 845
    aput-object v8, v3, v7

    move v7, v9

    goto :goto_f

    .line 850
    :cond_1d
    new-instance v1, Ljava/util/HashSet;

    invoke-direct {v1}, Ljava/util/HashSet;-><init>()V

    .line 851
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v5, v5, Landroidx/constraintlayout/core/motion/MotionPaths;->mCustomAttributes:Ljava/util/HashMap;

    invoke-virtual {v5}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v5

    invoke-interface {v5}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v5

    :cond_1e
    :goto_10
    invoke-interface {v5}, Ljava/util/Iterator;->hasNext()Z

    move-result v6

    if-eqz v6, :cond_1f

    invoke-interface {v5}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 852
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget-object v7, v7, Landroidx/constraintlayout/core/motion/MotionPaths;->mCustomAttributes:Ljava/util/HashMap;

    invoke-virtual {v7, v6}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_1e

    .line 853
    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v7, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v7, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v4, v7}, Ljava/util/HashSet;->contains(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_1e

    .line 854
    invoke-virtual {v1, v6}, Ljava/util/HashSet;->add(Ljava/lang/Object;)Z

    goto :goto_10

    :cond_1f
    const/4 v7, 0x0

    .line 859
    new-array v4, v7, [Ljava/lang/String;

    invoke-virtual {v1, v4}, Ljava/util/HashSet;->toArray([Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object v1

    check-cast v1, [Ljava/lang/String;

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    .line 860
    array-length v1, v1

    new-array v1, v1, [I

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeInterpolatorCount:[I

    const/4 v1, 0x0

    .line 861
    :goto_11
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    array-length v5, v4

    if-ge v1, v5, :cond_22

    .line 862
    aget-object v4, v4, v1

    .line 863
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeInterpolatorCount:[I

    const/16 v16, 0x0

    aput v16, v5, v1

    const/4 v5, 0x0

    :goto_12
    if-ge v5, v2, :cond_21

    .line 865
    aget-object v6, v3, v5

    iget-object v6, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mCustomAttributes:Ljava/util/HashMap;

    invoke-virtual {v6, v4}, Ljava/util/HashMap;->containsKey(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_20

    .line 866
    aget-object v6, v3, v5

    iget-object v6, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mCustomAttributes:Ljava/util/HashMap;

    invoke-virtual {v6, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Landroidx/constraintlayout/core/motion/CustomVariable;

    if-eqz v6, :cond_20

    .line 868
    iget-object v4, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeInterpolatorCount:[I

    aget v5, v4, v1

    invoke-virtual {v6}, Landroidx/constraintlayout/core/motion/CustomVariable;->numberOfInterpolatedValues()I

    move-result v6

    add-int/2addr v5, v6

    aput v5, v4, v1

    goto :goto_13

    :cond_20
    add-int/lit8 v5, v5, 0x1

    goto :goto_12

    :cond_21
    :goto_13
    add-int/lit8 v1, v1, 0x1

    goto :goto_11

    :cond_22
    const/16 v16, 0x0

    .line 874
    aget-object v1, v3, v16

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mPathMotionArc:I

    const/4 v5, -0x1

    if-eq v1, v5, :cond_23

    move/from16 v1, p1

    goto :goto_14

    :cond_23
    const/4 v1, 0x0

    .line 875
    :goto_14
    array-length v4, v4

    const/16 v5, 0x12

    add-int/2addr v5, v4

    new-array v4, v5, [Z

    move/from16 v6, p1

    :goto_15
    if-ge v6, v2, :cond_24

    .line 877
    aget-object v7, v3, v6

    add-int/lit8 v8, v6, -0x1

    aget-object v8, v3, v8

    iget-object v9, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    invoke-virtual {v7, v8, v4, v9, v1}, Landroidx/constraintlayout/core/motion/MotionPaths;->different(Landroidx/constraintlayout/core/motion/MotionPaths;[Z[Ljava/lang/String;Z)V

    add-int/lit8 v6, v6, 0x1

    goto :goto_15

    :cond_24
    move/from16 v6, p1

    const/4 v1, 0x0

    :goto_16
    if-ge v6, v5, :cond_26

    .line 882
    aget-boolean v7, v4, v6

    if-eqz v7, :cond_25

    add-int/lit8 v1, v1, 0x1

    :cond_25
    add-int/lit8 v6, v6, 0x1

    goto :goto_16

    .line 887
    :cond_26
    new-array v6, v1, [I

    iput-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    const/4 v6, 0x2

    .line 888
    invoke-static {v6, v1}, Ljava/lang/Math;->max(II)I

    move-result v1

    .line 889
    new-array v7, v1, [D

    iput-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateData:[D

    .line 890
    new-array v1, v1, [D

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVelocity:[D

    move/from16 v7, p1

    const/4 v1, 0x0

    :goto_17
    if-ge v7, v5, :cond_28

    .line 894
    aget-boolean v8, v4, v7

    if-eqz v8, :cond_27

    .line 895
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    add-int/lit8 v9, v1, 0x1

    aput v7, v8, v1

    move v1, v9

    :cond_27
    add-int/lit8 v7, v7, 0x1

    goto :goto_17

    .line 899
    :cond_28
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    array-length v1, v1

    new-array v4, v6, [I

    aput v1, v4, p1

    const/16 v16, 0x0

    aput v2, v4, v16

    sget-object v1, Ljava/lang/Double;->TYPE:Ljava/lang/Class;

    invoke-static {v1, v4}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;[I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, [[D

    .line 900
    new-array v5, v2, [D

    const/4 v7, 0x0

    :goto_18
    if-ge v7, v2, :cond_29

    .line 903
    aget-object v8, v3, v7

    aget-object v9, v4, v7

    iget-object v10, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    invoke-virtual {v8, v9, v10}, Landroidx/constraintlayout/core/motion/MotionPaths;->fillStandard([D[I)V

    .line 904
    aget-object v8, v3, v7

    iget v8, v8, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    float-to-double v8, v8

    aput-wide v8, v5, v7

    add-int/lit8 v7, v7, 0x1

    goto :goto_18

    :cond_29
    const/4 v7, 0x0

    .line 907
    :goto_19
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    array-length v9, v8

    if-ge v7, v9, :cond_2b

    .line 908
    aget v8, v8, v7

    .line 909
    sget-object v9, Landroidx/constraintlayout/core/motion/MotionPaths;->sNames:[Ljava/lang/String;

    array-length v9, v9

    if-ge v8, v9, :cond_2a

    .line 910
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v9, Landroidx/constraintlayout/core/motion/MotionPaths;->sNames:[Ljava/lang/String;

    iget-object v10, v0, Landroidx/constraintlayout/core/motion/Motion;->mInterpolateVariables:[I

    aget v10, v10, v7

    aget-object v9, v9, v10

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v9, " ["

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    const/4 v9, 0x0

    :goto_1a
    if-ge v9, v2, :cond_2a

    .line 913
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    aget-object v8, v4, v9

    aget-wide v11, v8, v7

    invoke-virtual {v10, v11, v12}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    add-int/lit8 v9, v9, 0x1

    goto :goto_1a

    :cond_2a
    add-int/lit8 v7, v7, 0x1

    goto :goto_19

    .line 917
    :cond_2b
    iget-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    array-length v7, v7

    add-int/lit8 v7, v7, 0x1

    new-array v7, v7, [Landroidx/constraintlayout/core/motion/utils/CurveFit;

    iput-object v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    const/4 v7, 0x0

    .line 919
    :goto_1b
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mAttributeNames:[Ljava/lang/String;

    array-length v9, v8

    if-ge v7, v9, :cond_2f

    .line 923
    aget-object v8, v8, v7

    const/4 v9, 0x0

    move-object v10, v9

    const/4 v11, 0x0

    const/4 v12, 0x0

    :goto_1c
    if-ge v11, v2, :cond_2e

    .line 926
    aget-object v13, v3, v11

    invoke-virtual {v13, v8}, Landroidx/constraintlayout/core/motion/MotionPaths;->hasCustomData(Ljava/lang/String;)Z

    move-result v13

    if-eqz v13, :cond_2d

    if-nez v10, :cond_2c

    .line 928
    new-array v9, v2, [D

    .line 929
    aget-object v10, v3, v11

    .line 930
    invoke-virtual {v10, v8}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCustomDataCount(Ljava/lang/String;)I

    move-result v10

    new-array v13, v6, [I

    aput v10, v13, p1

    const/4 v14, 0x0

    aput v2, v13, v14

    invoke-static {v1, v13}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;[I)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, [[D

    goto :goto_1d

    :cond_2c
    const/4 v14, 0x0

    .line 932
    :goto_1d
    aget-object v13, v3, v11

    iget v15, v13, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    move/from16 v18, v7

    float-to-double v6, v15

    aput-wide v6, v9, v12

    .line 933
    aget-object v6, v10, v12

    invoke-virtual {v13, v8, v6, v14}, Landroidx/constraintlayout/core/motion/MotionPaths;->getCustomData(Ljava/lang/String;[DI)I

    add-int/lit8 v12, v12, 0x1

    goto :goto_1e

    :cond_2d
    move/from16 v18, v7

    :goto_1e
    add-int/lit8 v11, v11, 0x1

    move/from16 v7, v18

    const/4 v6, 0x2

    goto :goto_1c

    :cond_2e
    move/from16 v18, v7

    .line 937
    invoke-static {v9, v12}, Ljava/util/Arrays;->copyOf([DI)[D

    move-result-object v6

    .line 938
    invoke-static {v10, v12}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v7

    check-cast v7, [[D

    .line 939
    iget-object v8, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    add-int/lit8 v9, v18, 0x1

    iget v10, v0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    invoke-static {v10, v6, v7}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->get(I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;

    move-result-object v6

    aput-object v6, v8, v9

    move v7, v9

    const/4 v6, 0x2

    goto :goto_1b

    .line 943
    :cond_2f
    iget-object v6, v0, Landroidx/constraintlayout/core/motion/Motion;->mSpline:[Landroidx/constraintlayout/core/motion/utils/CurveFit;

    iget v7, v0, Landroidx/constraintlayout/core/motion/Motion;->mCurveFitType:I

    invoke-static {v7, v5, v4}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->get(I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;

    move-result-object v4

    const/16 v16, 0x0

    aput-object v4, v6, v16

    .line 945
    aget-object v4, v3, v16

    iget v4, v4, Landroidx/constraintlayout/core/motion/MotionPaths;->mPathMotionArc:I

    const/4 v5, -0x1

    if-eq v4, v5, :cond_31

    .line 947
    new-array v4, v2, [I

    .line 948
    new-array v5, v2, [D

    const/4 v6, 0x2

    .line 949
    new-array v7, v6, [I

    aput v6, v7, p1

    aput v2, v7, v16

    invoke-static {v1, v7}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;[I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, [[D

    const/4 v7, 0x0

    :goto_1f
    if-ge v7, v2, :cond_30

    .line 951
    aget-object v6, v3, v7

    iget v8, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mPathMotionArc:I

    aput v8, v4, v7

    .line 952
    iget v8, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mTime:F

    float-to-double v8, v8

    aput-wide v8, v5, v7

    .line 953
    aget-object v8, v1, v7

    iget v9, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    float-to-double v9, v9

    const/16 v16, 0x0

    aput-wide v9, v8, v16

    .line 954
    iget v6, v6, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    float-to-double v9, v6

    aput-wide v9, v8, p1

    add-int/lit8 v7, v7, 0x1

    goto :goto_1f

    :cond_30
    const/16 v16, 0x0

    .line 957
    invoke-static {v4, v5, v1}, Landroidx/constraintlayout/core/motion/utils/CurveFit;->getArc([I[D[[D)Landroidx/constraintlayout/core/motion/utils/CurveFit;

    move-result-object v1

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mArcSpline:Landroidx/constraintlayout/core/motion/utils/CurveFit;

    .line 962
    :cond_31
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    iput-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    .line 963
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    if-eqz v1, :cond_37

    .line 964
    invoke-virtual/range {v17 .. v17}, Ljava/util/HashSet;->iterator()Ljava/util/Iterator;

    move-result-object v1

    const/high16 v2, 0x7fc00000    # Float.NaN

    :goto_20
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_34

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 965
    invoke-static {v3}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->makeWidgetCycle(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;

    move-result-object v4

    if-nez v4, :cond_32

    goto :goto_20

    .line 970
    :cond_32
    invoke-virtual {v4}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->variesByPath()Z

    move-result v5

    if-eqz v5, :cond_33

    .line 971
    invoke-static {v2}, Ljava/lang/Float;->isNaN(F)Z

    move-result v5

    if-eqz v5, :cond_33

    .line 972
    invoke-direct {v0}, Landroidx/constraintlayout/core/motion/Motion;->getPreCycleDistance()F

    move-result v2

    .line 975
    :cond_33
    invoke-virtual {v4, v3}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->setType(Ljava/lang/String;)V

    .line 976
    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    invoke-virtual {v5, v3, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_20

    .line 978
    :cond_34
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mKeyList:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v3

    move/from16 v9, v16

    :cond_35
    :goto_21
    if-ge v9, v3, :cond_36

    invoke-virtual {v1, v9}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v9, v9, 0x1

    check-cast v4, Landroidx/constraintlayout/core/motion/key/MotionKey;

    .line 979
    instance-of v5, v4, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyCycle;

    if-eqz v5, :cond_35

    .line 980
    check-cast v4, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyCycle;

    iget-object v5, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    invoke-virtual {v4, v5}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/key/MotionKeyCycle;->addCycleValues(Ljava/util/HashMap;)V

    goto :goto_21

    .line 983
    :cond_36
    iget-object v1, v0, Landroidx/constraintlayout/core/motion/Motion;->mCycleMap:Ljava/util/HashMap;

    invoke-virtual {v1}, Ljava/util/HashMap;->values()Ljava/util/Collection;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_22
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_37

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;

    .line 984
    invoke-virtual {v3, v2}, Landroidx/constraintlayout/core/motion/utils/KeyCycleOscillator;->setup(F)V

    goto :goto_22

    :cond_37
    return-void
.end method

.method public setupRelative(Landroidx/constraintlayout/core/motion/Motion;)V
    .locals 0

    .line 248
    iput-object p1, p0, Landroidx/constraintlayout/core/motion/Motion;->mRelativeMotion:Landroidx/constraintlayout/core/motion/Motion;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 1009
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, " start: x: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v1, " y: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mStartMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v2, v2, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    const-string v2, " end: x: "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v2, v2, Landroidx/constraintlayout/core/motion/MotionPaths;->mX:F

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Landroidx/constraintlayout/core/motion/Motion;->mEndMotionPath:Landroidx/constraintlayout/core/motion/MotionPaths;

    iget v1, v1, Landroidx/constraintlayout/core/motion/MotionPaths;->mY:F

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(F)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
