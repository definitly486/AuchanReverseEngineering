.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;
.super Ljava/lang/Object;
.source "ProcessingNode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x408
    name = "InputPacket"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 280
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static of(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageProxy;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingNode$InputPacket;
    .locals 1

    .line 290
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_ProcessingNode_InputPacket;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/AutoValue_ProcessingNode_InputPacket;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;Landroidx/camera/core/ImageProxy;)V

    return-object v0
.end method


# virtual methods
.method abstract getImageProxy()Landroidx/camera/core/ImageProxy;
.end method

.method abstract getProcessingRequest()Lcom/scanflow/datacapture/barinternal/androidx/camera/core/imagecapture/ProcessingRequest;
.end method
