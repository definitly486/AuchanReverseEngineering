.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;
.super Ljava/lang/Object;
.source "ProcessingNode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "In"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 298
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(II)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$In;
    .locals 3

    .line 325
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_ProcessingNode_In;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;-><init>()V

    invoke-direct {v0, v1, v2, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_ProcessingNode_In;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;II)V

    return-object v0
.end method


# virtual methods
.method abstract getEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;
.end method

.method abstract getInputFormat()I
.end method

.method abstract getOutputFormat()I
.end method

.method abstract getPostviewEdge()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/Edge;
.end method
