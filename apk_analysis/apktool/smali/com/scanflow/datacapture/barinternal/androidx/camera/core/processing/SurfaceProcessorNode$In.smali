.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorNode$In;
.super Ljava/lang/Object;
.source "SurfaceProcessorNode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorNode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "In"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 310
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static of(Landroidx/camera/core/processing/SurfaceEdge;Ljava/util/List;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorNode$In;
    .locals 1

    .line 335
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/AutoValue_SurfaceProcessorNode_In;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/AutoValue_SurfaceProcessorNode_In;-><init>(Landroidx/camera/core/processing/SurfaceEdge;Ljava/util/List;)V

    return-object v0
.end method


# virtual methods
.method public abstract getOutConfigs()Ljava/util/List;
.end method

.method public abstract getSurfaceEdge()Landroidx/camera/core/processing/SurfaceEdge;
.end method
