.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;
.super Ljava/lang/Object;
.source "SquareEdge.java"


# instance fields
.field public a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

.field public b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

.field public distance:D

.field public sideA:I

.field public sideB:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public destination(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;
    .locals 2

    .line 52
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    if-ne v0, p1, :cond_0

    .line 53
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    return-object p1

    .line 54
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    if-ne v1, p1, :cond_1

    return-object v0

    .line 57
    :cond_1
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "BUG! src is not a or b"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public isEndPoint(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;)Z
    .locals 1

    .line 70
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    if-eq v0, p1, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    if-ne v0, p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public reset()V
    .locals 2

    const/4 v0, 0x0

    .line 78
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->b:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->a:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareNode;

    const/4 v0, -0x1

    .line 79
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideB:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->sideA:I

    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    .line 80
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/calib/squares/SquareEdge;->distance:D

    return-void
.end method
