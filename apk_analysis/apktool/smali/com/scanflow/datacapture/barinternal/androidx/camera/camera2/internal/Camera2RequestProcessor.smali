.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;
.super Ljava/lang/Object;
.source "Camera2RequestProcessor.java"

# interfaces
.implements Landroidx/camera/core/impl/RequestProcessor;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor$Camera2CallbackWrapper;
    }
.end annotation


# instance fields
.field private mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

.field private volatile mIsClosed:Z

.field private final mLock:Ljava/lang/Object;

.field private mProcessorSurfaces:Ljava/util/List;

.field private volatile mSessionConfig:Landroidx/camera/core/impl/SessionConfig;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;Ljava/util/List;)V
    .locals 3

    .line 78
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 64
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    const/4 v0, 0x0

    .line 71
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    .line 79
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    if-ne v1, v2, :cond_0

    const/4 v0, 0x1

    :cond_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "CaptureSession state must be OPENED. Current state:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkArgument(ZLjava/lang/Object;)V

    .line 81
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    .line 82
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1, p2}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    invoke-static {p1}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mProcessorSurfaces:Ljava/util/List;

    return-void
.end method

.method private areRequestsValid(Ljava/util/List;)Z
    .locals 1

    .line 108
    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroidx/camera/core/impl/RequestProcessor$Request;

    .line 109
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->isRequestValid(Landroidx/camera/core/impl/RequestProcessor$Request;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_1
    const/4 p1, 0x1

    return p1
.end method

.method private findSurface(I)Landroidx/camera/core/impl/DeferrableSurface;
    .locals 3

    .line 322
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter p1

    .line 323
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mProcessorSurfaces:Ljava/util/List;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    .line 324
    monitor-exit p1

    return-object v1

    :catchall_0
    move-exception v0

    goto :goto_0

    .line 326
    :cond_0
    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-nez v2, :cond_1

    .line 331
    monitor-exit p1

    return-object v1

    .line 326
    :cond_1
    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    .line 327
    throw v1

    .line 332
    :goto_0
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method private isRequestValid(Landroidx/camera/core/impl/RequestProcessor$Request;)Z
    .locals 4

    .line 117
    invoke-interface {p1}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTargetOutputConfigIds()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    const/4 v1, 0x0

    const-string v2, "Camera2RequestProcessor"

    if-eqz v0, :cond_0

    .line 118
    const-string p1, "Unable to submit the RequestProcessor.Request: empty targetOutputConfigIds"

    invoke-static {v2, p1}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    return v1

    .line 122
    :cond_0
    invoke-interface {p1}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTargetOutputConfigIds()Ljava/util/List;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_1
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    .line 123
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v3

    invoke-direct {p0, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->findSurface(I)Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v3

    if-nez v3, :cond_1

    .line 124
    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unable to submit the RequestProcessor.Request: targetOutputConfigId("

    invoke-virtual {p1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ") is not a valid id"

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v2, p1}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    return v1

    :cond_2
    const/4 p1, 0x1

    return p1
.end method


# virtual methods
.method public abortCaptures()V
    .locals 2

    .line 212
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 213
    :try_start_0
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    if-nez v1, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    if-nez v1, :cond_0

    goto :goto_0

    .line 216
    :cond_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->abortCaptures()V

    .line 217
    monitor-exit v0

    return-void

    :catchall_0
    move-exception v1

    goto :goto_1

    .line 214
    :cond_1
    :goto_0
    monitor-exit v0

    return-void

    .line 217
    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1
.end method

.method public close()V
    .locals 2

    .line 89
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    const/4 v1, 0x1

    .line 90
    :try_start_0
    iput-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    const/4 v1, 0x0

    .line 91
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    .line 92
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    .line 93
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mProcessorSurfaces:Ljava/util/List;

    .line 94
    monitor-exit v0

    return-void

    :catchall_0
    move-exception v1

    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1
.end method

.method findOutputConfigId(Landroid/view/Surface;)I
    .locals 3

    .line 301
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter p1

    .line 302
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mProcessorSurfaces:Ljava/util/List;

    const/4 v1, -0x1

    if-nez v0, :cond_0

    .line 303
    monitor-exit p1

    return v1

    :catchall_0
    move-exception v0

    goto :goto_0

    .line 305
    :cond_0
    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-nez v2, :cond_1

    .line 316
    monitor-exit p1

    return v1

    .line 305
    :cond_1
    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/a/a$$ExternalSyntheticThrowCCEIfNotNull0;->m(Ljava/lang/Object;)V

    const/4 v0, 0x0

    .line 307
    throw v0

    .line 317
    :goto_0
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public setRepeating(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I
    .locals 5

    .line 176
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 177
    :try_start_0
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    if-nez v1, :cond_4

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->isRequestValid(Landroidx/camera/core/impl/RequestProcessor$Request;)Z

    move-result v1

    if-eqz v1, :cond_4

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    if-nez v1, :cond_0

    goto/16 :goto_3

    .line 181
    :cond_0
    new-instance v1, Landroidx/camera/core/impl/SessionConfig$Builder;

    invoke-direct {v1}, Landroidx/camera/core/impl/SessionConfig$Builder;-><init>()V

    .line 182
    invoke-interface {p1}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTemplateId()I

    move-result v2

    invoke-virtual {v1, v2}, Landroidx/camera/core/impl/SessionConfig$Builder;->setTemplateType(I)Landroidx/camera/core/impl/SessionConfig$Builder;

    .line 183
    invoke-interface {p1}, Landroidx/camera/core/impl/RequestProcessor$Request;->getParameters()Landroidx/camera/core/impl/Config;

    move-result-object v2

    invoke-virtual {v1, v2}, Landroidx/camera/core/impl/SessionConfig$Builder;->setImplementationOptions(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/SessionConfig$Builder;

    .line 184
    new-instance v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor$Camera2CallbackWrapper;

    const/4 v3, 0x1

    invoke-direct {v2, p0, p1, p2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor$Camera2CallbackWrapper;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;Z)V

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureCallbackContainer;->create(Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureCallbackContainer;

    move-result-object p2

    invoke-virtual {v1, p2}, Landroidx/camera/core/impl/SessionConfig$Builder;->addCameraCaptureCallback(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;

    .line 187
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    if-eqz p2, :cond_2

    .line 191
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    invoke-virtual {p2}, Landroidx/camera/core/impl/SessionConfig;->getRepeatingCameraCaptureCallbacks()Ljava/util/List;

    move-result-object p2

    invoke-interface {p2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p2

    :goto_0
    invoke-interface {p2}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-interface {p2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroidx/camera/core/impl/CameraCaptureCallback;

    .line 192
    invoke-virtual {v1, v2}, Landroidx/camera/core/impl/SessionConfig$Builder;->addCameraCaptureCallback(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_4

    .line 196
    :cond_1
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    invoke-virtual {p2}, Landroidx/camera/core/impl/SessionConfig;->getRepeatingCaptureConfig()Landroidx/camera/core/impl/CaptureConfig;

    move-result-object p2

    invoke-virtual {p2}, Landroidx/camera/core/impl/CaptureConfig;->getTagBundle()Landroidx/camera/core/impl/TagBundle;

    move-result-object p2

    .line 197
    invoke-virtual {p2}, Landroidx/camera/core/impl/TagBundle;->listKeys()Ljava/util/Set;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_1
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_2

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 198
    invoke-virtual {p2, v3}, Landroidx/camera/core/impl/TagBundle;->getTag(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v1, v3, v4}, Landroidx/camera/core/impl/SessionConfig$Builder;->addTag(Ljava/lang/String;Ljava/lang/Object;)Landroidx/camera/core/impl/SessionConfig$Builder;

    goto :goto_1

    .line 202
    :cond_2
    invoke-interface {p1}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTargetOutputConfigIds()Ljava/util/List;

    move-result-object p1

    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :goto_2
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result p2

    if-eqz p2, :cond_3

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Ljava/lang/Integer;

    .line 203
    invoke-virtual {p2}, Ljava/lang/Integer;->intValue()I

    move-result p2

    invoke-direct {p0, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->findSurface(I)Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object p2

    invoke-virtual {v1, p2}, Landroidx/camera/core/impl/SessionConfig$Builder;->addSurface(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;

    goto :goto_2

    .line 206
    :cond_3
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-virtual {v1}, Landroidx/camera/core/impl/SessionConfig$Builder;->build()Landroidx/camera/core/impl/SessionConfig;

    move-result-object p2

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->issueRepeatingCaptureRequests(Landroidx/camera/core/impl/SessionConfig;)I

    move-result p1

    monitor-exit v0

    return p1

    :cond_4
    :goto_3
    const/4 p1, -0x1

    .line 178
    monitor-exit v0

    return p1

    .line 207
    :goto_4
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method public stopRepeating()V
    .locals 2

    .line 222
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 223
    :try_start_0
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    if-nez v1, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    if-nez v1, :cond_0

    goto :goto_0

    .line 226
    :cond_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->stopRepeating()V

    .line 227
    monitor-exit v0

    return-void

    :catchall_0
    move-exception v1

    goto :goto_1

    .line 224
    :cond_1
    :goto_0
    monitor-exit v0

    return-void

    .line 227
    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1
.end method

.method public submit(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I
    .locals 2

    const/4 v0, 0x1

    .line 137
    new-array v0, v0, [Landroidx/camera/core/impl/RequestProcessor$Request;

    const/4 v1, 0x0

    aput-object p1, v0, v1

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object p1

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->submit(Ljava/util/List;Landroidx/camera/core/impl/RequestProcessor$Callback;)I

    move-result p1

    return p1
.end method

.method public submit(Ljava/util/List;Landroidx/camera/core/impl/RequestProcessor$Callback;)I
    .locals 6

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 145
    :try_start_0
    iget-boolean v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mIsClosed:Z

    if-nez v1, :cond_3

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->areRequestsValid(Ljava/util/List;)Z

    move-result v1

    if-eqz v1, :cond_3

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    if-nez v1, :cond_0

    goto :goto_2

    .line 149
    :cond_0
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 151
    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    const/4 v2, 0x1

    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_2

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroidx/camera/core/impl/RequestProcessor$Request;

    .line 152
    new-instance v4, Landroidx/camera/core/impl/CaptureConfig$Builder;

    invoke-direct {v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;-><init>()V

    .line 153
    invoke-interface {v3}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTemplateId()I

    move-result v5

    invoke-virtual {v4, v5}, Landroidx/camera/core/impl/CaptureConfig$Builder;->setTemplateType(I)V

    .line 154
    invoke-interface {v3}, Landroidx/camera/core/impl/RequestProcessor$Request;->getParameters()Landroidx/camera/core/impl/Config;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroidx/camera/core/impl/CaptureConfig$Builder;->setImplementationOptions(Landroidx/camera/core/impl/Config;)V

    .line 155
    new-instance v5, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor$Camera2CallbackWrapper;

    invoke-direct {v5, p0, v3, p2, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor$Camera2CallbackWrapper;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;Z)V

    .line 156
    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureCallbackContainer;->create(Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureCallbackContainer;

    move-result-object v2

    .line 155
    invoke-virtual {v4, v2}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addCameraCaptureCallback(Landroidx/camera/core/impl/CameraCaptureCallback;)V

    .line 163
    invoke-interface {v3}, Landroidx/camera/core/impl/RequestProcessor$Request;->getTargetOutputConfigIds()Ljava/util/List;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_1
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/Integer;

    .line 164
    invoke-virtual {v3}, Ljava/lang/Integer;->intValue()I

    move-result v3

    invoke-direct {p0, v3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->findSurface(I)Landroidx/camera/core/impl/DeferrableSurface;

    move-result-object v3

    invoke-virtual {v4, v3}, Landroidx/camera/core/impl/CaptureConfig$Builder;->addSurface(Landroidx/camera/core/impl/DeferrableSurface;)V

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_3

    .line 166
    :cond_1
    invoke-virtual {v4}, Landroidx/camera/core/impl/CaptureConfig$Builder;->build()Landroidx/camera/core/impl/CaptureConfig;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    const/4 v2, 0x0

    goto :goto_0

    .line 168
    :cond_2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->issueBurstCaptureRequest(Ljava/util/List;)I

    move-result p1

    monitor-exit v0

    return p1

    :cond_3
    :goto_2
    const/4 p1, -0x1

    .line 146
    monitor-exit v0

    return p1

    .line 169
    :goto_3
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method public updateSessionConfig(Landroidx/camera/core/impl/SessionConfig;)V
    .locals 1

    .line 102
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mLock:Ljava/lang/Object;

    monitor-enter v0

    .line 103
    :try_start_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2RequestProcessor;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    .line 104
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p1

    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method
