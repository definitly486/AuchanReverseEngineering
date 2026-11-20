.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda7;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

.field public final synthetic f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda7;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda7;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda7;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda7;->f$1:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;->$r8$lambda$4v9kuebRQ65Gn_z3Sy8fp34KwCY(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$PendingSnapshot;)V

    return-void
.end method
