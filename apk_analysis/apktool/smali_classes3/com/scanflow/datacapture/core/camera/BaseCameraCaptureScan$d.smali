.class public final Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/datacapture/core/camera/analyze/Analyzer$OnAnalyzeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->c()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field public final synthetic a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan<",
            "TT;>;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final OnOneTouchCallbackCompleted()V
    .locals 1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;

    if-eqz v0, :cond_0

    .line 2
    invoke-interface {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;->onCompleted()V

    :cond_0
    return-void
.end method

.method public final OnOneTouchCallbackDisable()V
    .locals 2

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    sget v1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->E0:I

    .line 1
    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 2
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 v1, 0x0

    .line 3
    iput-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->S:Z

    return-void
.end method

.method public final OnOneTouchCallbackStarted()V
    .locals 1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->o:Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;

    if-eqz v0, :cond_0

    .line 2
    invoke-interface {v0}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$OnOneTouchCallback;->onStarted()V

    :cond_0
    return-void
.end method

.method public final onFailure()V
    .locals 2

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q:Landroidx/lifecycle/MutableLiveData;

    if-eqz v0, :cond_0

    const/4 v1, 0x0

    .line 2
    invoke-virtual {v0, v1}, Landroidx/lifecycle/MutableLiveData;->postValue(Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public final onLicenseFailed(Ljava/lang/String;)V
    .locals 1

    const-string v0, "message"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q:Landroidx/lifecycle/MutableLiveData;

    if-eqz v0, :cond_0

    .line 2
    invoke-virtual {v0, p1}, Landroidx/lifecycle/MutableLiveData;->postValue(Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public final onPerformCaptureScan()V
    .locals 2

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 v1, 0x0

    .line 1
    iput-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->H:Z

    return-void
.end method

.method public final onSuccess(Ljava/lang/String;)V
    .locals 1

    const-string v0, "message"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    .line 1
    iget-object v0, v0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->q:Landroidx/lifecycle/MutableLiveData;

    if-eqz v0, :cond_0

    .line 2
    invoke-virtual {v0, p1}, Landroidx/lifecycle/MutableLiveData;->postValue(Ljava/lang/Object;)V

    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan$d;->a:Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;

    const/4 v0, 0x0

    .line 3
    iput-boolean v0, p1, Lcom/scanflow/datacapture/core/camera/BaseCameraCaptureScan;->H:Z

    return-void
.end method
