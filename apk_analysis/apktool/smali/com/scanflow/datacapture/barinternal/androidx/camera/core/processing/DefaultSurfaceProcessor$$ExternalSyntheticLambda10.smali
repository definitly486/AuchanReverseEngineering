.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda10;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/SurfaceRequest$TransformationInfoListener;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

.field public final synthetic f$1:Landroidx/camera/core/SurfaceRequest;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;Landroidx/camera/core/SurfaceRequest;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda10;->f$1:Landroidx/camera/core/SurfaceRequest;

    return-void
.end method


# virtual methods
.method public final onTransformationInfoUpdate(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda10;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda10;->f$1:Landroidx/camera/core/SurfaceRequest;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;->$r8$lambda$Q1rrgC8aoiGLiHQv9mIX_otuWf4(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;Landroidx/camera/core/SurfaceRequest;Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V

    return-void
.end method
