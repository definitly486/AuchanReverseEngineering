.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/core/util/Consumer;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

.field public final synthetic f$1:Landroidx/camera/core/SurfaceOutput;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;Landroidx/camera/core/SurfaceOutput;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda5;->f$1:Landroidx/camera/core/SurfaceOutput;

    return-void
.end method


# virtual methods
.method public final accept(Ljava/lang/Object;)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda5;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor$$ExternalSyntheticLambda5;->f$1:Landroidx/camera/core/SurfaceOutput;

    check-cast p1, Landroidx/camera/core/SurfaceOutput$Event;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;->$r8$lambda$SSJVT35FEA6PJGDsDjTufRx-9_M(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/concurrent/DualSurfaceProcessor;Landroidx/camera/core/SurfaceOutput;Landroidx/camera/core/SurfaceOutput$Event;)V

    return-void
.end method
