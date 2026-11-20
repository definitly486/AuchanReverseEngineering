.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

.field public final synthetic f$1:I

.field public final synthetic f$2:I


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;II)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$1:I

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$2:I

    return-void
.end method


# virtual methods
.method public final attachCompleter(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$1:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor$$ExternalSyntheticLambda6;->f$2:I

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;->$r8$lambda$PIoZOGm3Jh4eEK7HaCwf3rrEVq4(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/DefaultSurfaceProcessor;IILandroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
