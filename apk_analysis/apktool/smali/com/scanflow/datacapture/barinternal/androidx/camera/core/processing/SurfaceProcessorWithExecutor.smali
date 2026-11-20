.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;
.super Ljava/lang/Object;
.source "SurfaceProcessorWithExecutor.java"

# interfaces
.implements Landroidx/camera/core/processing/SurfaceProcessorInternal;


# instance fields
.field private final mErrorListener:Landroidx/core/util/Consumer;

.field private final mExecutor:Ljava/util/concurrent/Executor;

.field private final mSurfaceProcessor:Landroidx/camera/core/SurfaceProcessor;


# direct methods
.method public static synthetic $r8$lambda$Ohd3Itzyn3IMfjyOsSrFDWLx2z8(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;Landroidx/camera/core/SurfaceOutput;)V
    .locals 0

    .line 90
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mSurfaceProcessor:Landroidx/camera/core/SurfaceProcessor;

    invoke-interface {p0, p1}, Landroidx/camera/core/SurfaceProcessor;->onOutputSurface(Landroidx/camera/core/SurfaceOutput;)V

    return-void
.end method

.method public static synthetic $r8$lambda$gFq9ZjkYMu6QWJyE7oyeb6idSPU(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;Landroidx/camera/core/SurfaceRequest;)V
    .locals 0

    .line 78
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mSurfaceProcessor:Landroidx/camera/core/SurfaceProcessor;

    invoke-interface {p0, p1}, Landroidx/camera/core/SurfaceProcessor;->onInputSurface(Landroidx/camera/core/SurfaceRequest;)V

    return-void
.end method

.method public constructor <init>(Landroidx/camera/core/CameraEffect;)V
    .locals 1

    .line 56
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 57
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getSurfaceProcessor()Landroidx/camera/core/SurfaceProcessor;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    check-cast v0, Landroidx/camera/core/SurfaceProcessor;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mSurfaceProcessor:Landroidx/camera/core/SurfaceProcessor;

    .line 58
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getExecutor()Ljava/util/concurrent/Executor;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mExecutor:Ljava/util/concurrent/Executor;

    .line 59
    invoke-virtual {p1}, Landroidx/camera/core/CameraEffect;->getErrorListener()Landroidx/core/util/Consumer;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mErrorListener:Landroidx/core/util/Consumer;

    return-void
.end method


# virtual methods
.method public onInputSurface(Landroidx/camera/core/SurfaceRequest;)V
    .locals 2

    .line 76
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;Landroidx/camera/core/SurfaceRequest;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public onOutputSurface(Landroidx/camera/core/SurfaceOutput;)V
    .locals 2

    .line 88
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;->mExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor$$ExternalSyntheticLambda1;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/SurfaceProcessorWithExecutor;Landroidx/camera/core/SurfaceOutput;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public release()V
    .locals 0

    .line 110
    return-void
.end method

.method public snapshot(II)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 0

    .line 103
    new-instance p1, Ljava/lang/Exception;

    const-string p2, "Snapshot not supported by external SurfaceProcessor"

    invoke-direct {p1, p2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    invoke-static {p1}, Landroidx/camera/core/impl/utils/futures/Futures;->immediateFailedFuture(Ljava/lang/Throwable;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
