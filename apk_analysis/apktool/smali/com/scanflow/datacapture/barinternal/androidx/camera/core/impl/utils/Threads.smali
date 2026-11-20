.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;
.super Ljava/lang/Object;
.source "Threads.java"


# direct methods
.method public static checkMainThread()V
    .locals 2

    .line 55
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->isMainThread()Z

    move-result v0

    const-string v1, "Not in application\'s main thread"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkState(ZLjava/lang/String;)V

    return-void
.end method

.method private static getMainHandler()Landroid/os/Handler;
    .locals 2

    .line 122
    new-instance v0, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    return-object v0
.end method

.method public static isMainThread()Z
    .locals 2

    .line 41
    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-virtual {v0}, Landroid/os/Looper;->getThread()Ljava/lang/Thread;

    move-result-object v0

    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public static runOnMain(Ljava/lang/Runnable;)V
    .locals 1

    .line 73
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->isMainThread()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 74
    invoke-interface {p0}, Ljava/lang/Runnable;->run()V

    return-void

    .line 77
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/impl/utils/Threads;->getMainHandler()Landroid/os/Handler;

    move-result-object v0

    invoke-virtual {v0, p0}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    move-result p0

    const-string v0, "Unable to post to main thread"

    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkState(ZLjava/lang/String;)V

    return-void
.end method
