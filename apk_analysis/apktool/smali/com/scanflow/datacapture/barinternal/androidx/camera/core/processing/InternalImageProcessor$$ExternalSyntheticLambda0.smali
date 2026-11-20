.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

.field public final synthetic f$1:Landroidx/camera/core/ImageProcessor$Request;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;->f$1:Landroidx/camera/core/ImageProcessor$Request;

    return-void
.end method


# virtual methods
.method public final attachCompleter(Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;->f$1:Landroidx/camera/core/ImageProcessor$Request;

    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->$r8$lambda$dnn5neapX62HLhFqfn3q4wACZ_Q(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
