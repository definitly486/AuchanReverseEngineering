.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;
.super Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;
.source "PositionPatternNode.java"


# instance fields
.field public grayThreshold:D


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 29
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;-><init>()V

    return-void
.end method


# virtual methods
.method public reset()V
    .locals 2

    .line 36
    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;->reset()V

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 37
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/PositionPatternNode;->grayThreshold:D

    return-void
.end method
