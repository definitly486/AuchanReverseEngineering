.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/core/os/ExecutorCompat;
.super Ljava/lang/Object;
.source "ExecutorCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/core/os/ExecutorCompat$HandlerExecutor;
    }
.end annotation


# direct methods
.method public static create(Landroid/os/Handler;)Ljava/util/concurrent/Executor;
    .locals 1

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/os/ExecutorCompat$HandlerExecutor;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/ExecutorCompat$HandlerExecutor;-><init>(Landroid/os/Handler;)V

    return-object v0
.end method
