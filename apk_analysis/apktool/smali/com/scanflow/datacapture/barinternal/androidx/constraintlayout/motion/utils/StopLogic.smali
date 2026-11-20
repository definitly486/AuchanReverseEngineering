.class public Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;
.super Landroidx/constraintlayout/motion/widget/MotionInterpolator;
.source "StopLogic.java"


# instance fields
.field private mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

.field private mSpringStopEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;

.field private mStopLogicEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 32
    invoke-direct {p0}, Landroidx/constraintlayout/motion/widget/MotionInterpolator;-><init>()V

    .line 33
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mStopLogicEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;

    .line 35
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    return-void
.end method


# virtual methods
.method public config(FFFFFF)V
    .locals 7

    .line 69
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mStopLogicEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    move v1, p1

    move v2, p2

    move v3, p3

    move v4, p4

    move v5, p5

    move v6, p6

    .line 70
    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopLogicEngine;->config(FFFFFF)V

    return-void
.end method

.method public getInterpolation(F)F
    .locals 1

    .line 105
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;->getInterpolation(F)F

    move-result p1

    return p1
.end method

.method public getVelocity()F
    .locals 1

    .line 110
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;->getVelocity()F

    move-result v0

    return v0
.end method

.method public isStopped()Z
    .locals 1

    .line 114
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;->isStopped()Z

    move-result v0

    return v0
.end method

.method public springConfig(FFFFFFFI)V
    .locals 10

    .line 95
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mSpringStopEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;

    if-nez v0, :cond_0

    .line 96
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mSpringStopEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;

    .line 98
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mSpringStopEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/motion/utils/StopLogic;->mEngine:Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/StopEngine;

    move v2, p1

    move v3, p2

    move v4, p3

    move v5, p4

    move v6, p5

    move/from16 v7, p6

    move/from16 v8, p7

    move/from16 v9, p8

    .line 99
    invoke-virtual/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/androidx/constraintlayout/core/motion/utils/SpringStopEngine;->springConfig(FFFFFFFI)V

    return-void
.end method
