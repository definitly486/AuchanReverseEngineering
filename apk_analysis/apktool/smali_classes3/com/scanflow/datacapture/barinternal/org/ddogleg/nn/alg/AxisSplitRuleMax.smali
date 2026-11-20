.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRuleMax;
.super Ljava/lang/Object;
.source "AxisSplitRuleMax.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRule;


# instance fields
.field N:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public select([D)I
    .locals 7

    const/4 v0, -0x1

    const-wide/high16 v1, -0x4010000000000000L    # -1.0

    const/4 v3, 0x0

    .line 39
    :goto_0
    iget v4, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRuleMax;->N:I

    if-ge v3, v4, :cond_1

    .line 40
    aget-wide v4, p1, v3

    cmpl-double v6, v4, v1

    if-lez v6, :cond_0

    move v0, v3

    move-wide v1, v4

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return v0
.end method

.method public setDimension(I)V
    .locals 0

    .line 32
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/AxisSplitRuleMax;->N:I

    return-void
.end method
