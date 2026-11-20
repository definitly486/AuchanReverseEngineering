.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessorNode$In;
.super Ljava/lang/Object;
.source "DualSurfaceProcessorNode.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessorNode;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "In"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 278
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static of(Landroidx/camera/core/processing/SurfaceEdge;Landroidx/camera/core/processing/SurfaceEdge;Ljava/util/List;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessorNode$In;
    .locals 1

    .line 314
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/AutoValue_DualSurfaceProcessorNode_In;

    invoke-direct {v0, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/AutoValue_DualSurfaceProcessorNode_In;-><init>(Landroidx/camera/core/processing/SurfaceEdge;Landroidx/camera/core/processing/SurfaceEdge;Ljava/util/List;)V

    return-object v0
.end method


# virtual methods
.method public abstract getOutConfigs()Ljava/util/List;
.end method

.method public abstract getPrimarySurfaceEdge()Landroidx/camera/core/processing/SurfaceEdge;
.end method

.method public abstract getSecondarySurfaceEdge()Landroidx/camera/core/processing/SurfaceEdge;
.end method
