.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

.field public final synthetic f$1:Landroidx/camera/core/SurfaceOutput;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;Landroidx/camera/core/SurfaceOutput;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda3;->f$1:Landroidx/camera/core/SurfaceOutput;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda3;->f$1:Landroidx/camera/core/SurfaceOutput;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;->$r8$lambda$XjKCBi0iSlQAHK-EbAfakln9aNU(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;Landroidx/camera/core/SurfaceOutput;)V

    return-void
.end method
