.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;
.super Ljava/lang/Object;
.source "PolylineSplitMerge.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Corner"
.end annotation


# instance fields
.field public index:I

.field public sideError:D

.field public splitError0:D

.field public splitError1:D

.field public splitLocation:I

.field public splitable:Z


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 856
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public reset()V
    .locals 3

    const/4 v0, -0x1

    .line 868
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->index:I

    const-wide/high16 v1, -0x4010000000000000L    # -1.0

    .line 869
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->sideError:D

    .line 870
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitLocation:I

    .line 871
    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError1:D

    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitError0:D

    const/4 v0, 0x1

    .line 872
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$Corner;->splitable:Z

    return-void
.end method
