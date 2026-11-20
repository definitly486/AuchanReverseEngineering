.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;
.super Ljava/lang/Object;
.source "PolylineSplitMerge.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "CandidatePolyline"
.end annotation


# instance fields
.field public maxSideError:D

.field public score:D

.field public sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

.field public splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 876
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 877
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 880
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    return-void
.end method


# virtual methods
.method public reset()V
    .locals 2

    .line 883
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->splits:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    .line 884
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->sideErrors:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F64;

    const-wide/high16 v0, 0x7ff8000000000000L    # Double.NaN

    .line 885
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->score:D

    .line 886
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polyline/splitmerge/PolylineSplitMerge$CandidatePolyline;->maxSideError:D

    return-void
.end method
