.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;
.super Ljava/lang/Object;
.source "InternalImageProcessor.java"


# instance fields
.field private final mErrorListener:Landroidx/core/util/Consumer;

.field private final mExecutor:Ljava/util/concurrent/Executor;

.field private final mImageProcessor:Landroidx/camera/core/ImageProcessor;


# direct methods
.method public static synthetic $r8$lambda$dnn5neapX62HLhFqfn3q4wACZ_Q(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    .line 66
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->mExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 79
    new-instance p0, Ljava/lang/StringBuilder;

    invoke-direct {p0}, Ljava/lang/StringBuilder;-><init>()V

    const-string p2, "InternalImageProcessor#process "

    invoke-virtual {p0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/Object;->hashCode()I

    move-result p1

    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$lDXIVZB09XJac4eV7FXb_PY5gXU(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 0

    .line 69
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->mImageProcessor:Landroidx/camera/core/ImageProcessor;

    invoke-interface {p0, p1}, Landroidx/camera/core/ImageProcessor;->process(Landroidx/camera/core/ImageProcessor$Request;)Landroidx/camera/core/ImageProcessor$Response;

    move-result-object p0

    .line 77
    invoke-virtual {p2, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->set(Ljava/lang/Object;)Z

    return-void
.end method

.method public constructor <init>(Landroidx/camera/core/CameraEffect;)V
    .locals 2

    .line 50
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 51
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getTargets()I

    move-result v0

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(Z)V

    .line 52
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getExecutor()Ljava/util/concurrent/Executor;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->mExecutor:Ljava/util/concurrent/Executor;

    .line 53
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getImageProcessor()Landroidx/camera/core/ImageProcessor;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v0, Landroidx/camera/core/ImageProcessor;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->mImageProcessor:Landroidx/camera/core/ImageProcessor;

    .line 54
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getErrorListener()Landroidx/core/util/Consumer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;->mErrorListener:Landroidx/core/util/Consumer;

    return-void
.end method


# virtual methods
.method public safeProcess(Landroidx/camera/core/ImageProcessor$Request;)Landroidx/camera/core/ImageProcessor$Response;
    .locals 3

    .line 64
    :try_start_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/InternalImageProcessor;Landroidx/camera/core/ImageProcessor$Request;)V

    invoke-static {v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter;->getFuture(Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    .line 80
    invoke-interface {p1}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/camera/core/ImageProcessor$Response;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    return-object p1

    :catch_0
    move-exception p1

    .line 82
    invoke-virtual {p1}, Ljava/lang/Throwable;->getCause()Ljava/lang/Throwable;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Ljava/lang/Throwable;->getCause()Ljava/lang/Throwable;

    move-result-object p1

    .line 83
    :cond_0
    new-instance v0, Landroidx/camera/core/ImageCaptureException;

    const/4 v1, 0x0

    const-string v2, "Failed to invoke ImageProcessor."

    invoke-direct {v0, v1, v2, p1}, Landroidx/camera/core/ImageCaptureException;-><init>(ILjava/lang/String;Ljava/lang/Throwable;)V

    throw v0
.end method
