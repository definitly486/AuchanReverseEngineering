.class final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;
.source "CaptureSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x10
    name = "StateCallback"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;)V
    .locals 0

    .line 947
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;-><init>()V

    return-void
.end method


# virtual methods
.method public onConfigureFailed(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 3

    .line 1012
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSessionLock:Ljava/lang/Object;

    monitor-enter p1

    .line 1013
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v0}, Ljava/lang/Enum;->ordinal()I

    move-result v0

    packed-switch v0, :pswitch_data_0

    goto :goto_0

    .line 1030
    :pswitch_0
    const-string v0, "CaptureSession"

    const-string v1, "ConfigureFailed callback after change to RELEASED state"

    invoke-static {v0, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    .line 1027
    :pswitch_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->finishClose()V

    .line 1033
    :goto_0
    const-string v0, "CaptureSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "CameraCaptureSession.onConfigureFailed() "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;)V

    .line 1034
    monitor-exit p1

    return-void

    .line 1018
    :pswitch_2
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onConfigureFailed() should not be possible in state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1034
    :goto_1
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    nop

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_2
        :pswitch_2
        :pswitch_2
        :pswitch_1
        :pswitch_2
        :pswitch_1
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public onConfigured(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 3

    .line 957
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSessionLock:Ljava/lang/Object;

    monitor-enter v0

    .line 958
    :try_start_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    packed-switch v1, :pswitch_data_0

    goto :goto_0

    .line 977
    :pswitch_0
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->close()V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 974
    :pswitch_1
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iput-object p1, v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSynchronizedCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;

    goto :goto_0

    .line 967
    :pswitch_2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    iput-object v2, v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 968
    iput-object p1, v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSynchronizedCaptureSession:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;

    .line 969
    const-string p1, "CaptureSession"

    const-string v1, "Attempting to send capture request onConfigured"

    invoke-static {p1, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 970
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSessionConfig:Landroidx/camera/core/impl/SessionConfig;

    invoke-virtual {p1, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->issueRepeatingCaptureRequests(Landroidx/camera/core/impl/SessionConfig;)I

    .line 971
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->issuePendingCaptureRequest()V

    .line 980
    :goto_0
    const-string p1, "CaptureSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "CameraCaptureSession.onConfigured() mState="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {p1, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 981
    monitor-exit v0

    return-void

    .line 964
    :pswitch_3
    new-instance p1, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onConfigured() should not be possible in state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p1, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 981
    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_3
        :pswitch_3
        :pswitch_3
        :pswitch_2
        :pswitch_3
        :pswitch_1
        :pswitch_0
        :pswitch_3
    .end packed-switch
.end method

.method public onReady(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 3

    .line 986
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSessionLock:Ljava/lang/Object;

    monitor-enter p1

    .line 987
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v0}, Ljava/lang/Enum;->ordinal()I

    move-result v0

    if-eqz v0, :cond_0

    .line 993
    const-string v0, "CaptureSession"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "CameraCaptureSession.onReady() "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 994
    monitor-exit p1

    return-void

    :catchall_0
    move-exception v0

    goto :goto_0

    .line 989
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onReady() should not be possible in state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 994
    :goto_0
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method

.method public onSessionFinished(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 3

    .line 999
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mSessionLock:Ljava/lang/Object;

    monitor-enter p1

    .line 1000
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    if-eq v0, v1, :cond_0

    .line 1004
    const-string v0, "CaptureSession"

    const-string v1, "onSessionFinished()"

    invoke-static {v0, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 1006
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->finishClose()V

    .line 1007
    monitor-exit p1

    return-void

    :catchall_0
    move-exception v0

    goto :goto_0

    .line 1001
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onSessionFinished() should not be possible in state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$StateCallback;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1007
    :goto_0
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0
.end method
