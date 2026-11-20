.class public final Landroidx/camera/core/impl/LiveDataObservable;
.super Ljava/lang/Object;
.source "LiveDataObservable.java"

# interfaces
.implements Landroidx/camera/core/impl/Observable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/camera/core/impl/LiveDataObservable$Result;,
        Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;
    }
.end annotation


# instance fields
.field final mLiveData:Landroidx/lifecycle/MutableLiveData;

.field private final mObservers:Ljava/util/Map;


# direct methods
.method public static synthetic $r8$lambda$DTQl2TjsJw2q-1DsAXZ5y6fSWXY(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 85
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v0

    new-instance v1, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0, p1}, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda3;-><init>(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 98
    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string p0, " [fetch@"

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v0

    invoke-virtual {p1, v0, v1}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string p0, "]"

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic $r8$lambda$L1_O63Strz57IFbQMuk6c7_qs0c(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;)V
    .locals 0

    .line 131
    iget-object p0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    .line 131
    invoke-virtual {p0, p1}, Landroidx/lifecycle/LiveData;->removeObserver(Landroidx/lifecycle/Observer;)V

    return-void
.end method

.method public static synthetic $r8$lambda$sc5wmr8WXbqD092EUWP6jtN6OSA(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 1

    .line 86
    iget-object p0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    .line 86
    invoke-virtual {p0}, Landroidx/lifecycle/LiveData;->getValue()Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroidx/camera/core/impl/LiveDataObservable$Result;

    if-nez p0, :cond_0

    .line 88
    new-instance p0, Ljava/lang/IllegalStateException;

    const-string v0, "Observable has not yet been initialized with a value."

    invoke-direct {p0, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->setException(Ljava/lang/Throwable;)Z

    return-void

    .line 90
    :cond_0
    invoke-virtual {p0}, Landroidx/camera/core/impl/LiveDataObservable$Result;->completedSuccessfully()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 91
    invoke-virtual {p0}, Landroidx/camera/core/impl/LiveDataObservable$Result;->getValue()Ljava/lang/Object;

    move-result-object p0

    invoke-virtual {p1, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->set(Ljava/lang/Object;)Z

    return-void

    .line 93
    :cond_1
    invoke-virtual {p0}, Landroidx/camera/core/impl/LiveDataObservable$Result;->getError()Ljava/lang/Throwable;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 94
    invoke-virtual {p0}, Landroidx/camera/core/impl/LiveDataObservable$Result;->getError()Ljava/lang/Throwable;

    move-result-object p0

    invoke-virtual {p1, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->setException(Ljava/lang/Throwable;)Z

    return-void
.end method

.method public static synthetic $r8$lambda$wYXY5PQhuLafSvGd6glFwFsQmzA(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;)V
    .locals 1

    if-eqz p1, :cond_0

    .line 116
    iget-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    .line 116
    invoke-virtual {v0, p1}, Landroidx/lifecycle/LiveData;->removeObserver(Landroidx/lifecycle/Observer;)V

    .line 118
    :cond_0
    iget-object p0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    .line 118
    invoke-virtual {p0, p2}, Landroidx/lifecycle/LiveData;->observeForever(Landroidx/lifecycle/Observer;)V

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .line 50
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 53
    new-instance v0, Landroidx/lifecycle/MutableLiveData;

    invoke-direct {v0}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    iput-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    .line 55
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    iput-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    return-void
.end method


# virtual methods
.method public addObserver(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/Observable$Observer;)V
    .locals 3

    .line 104
    iget-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    monitor-enter v0

    .line 105
    :try_start_0
    iget-object v1, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    invoke-interface {v1, p2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;

    if-eqz v1, :cond_0

    .line 107
    invoke-virtual {v1}, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;->disable()V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 110
    :cond_0
    :goto_0
    new-instance v2, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;

    invoke-direct {v2, p1, p2}, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;-><init>(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/Observable$Observer;)V

    .line 112
    iget-object p1, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    invoke-interface {p1, p2, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 114
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object p1

    new-instance p2, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda1;

    invoke-direct {p2, p0, v1, v2}, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda1;-><init>(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;)V

    invoke-interface {p1, p2}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 120
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method

.method public fetchData()Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 1

    .line 84
    new-instance v0, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda2;

    invoke-direct {v0, p0}, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda2;-><init>(Landroidx/camera/core/impl/LiveDataObservable;)V

    invoke-static {v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter;->getFuture(Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    return-object v0
.end method

.method public postValue(Ljava/lang/Object;)V
    .locals 1

    .line 62
    iget-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mLiveData:Landroidx/lifecycle/MutableLiveData;

    invoke-static {p1}, Landroidx/camera/core/impl/LiveDataObservable$Result;->fromValue(Ljava/lang/Object;)Landroidx/camera/core/impl/LiveDataObservable$Result;

    move-result-object p1

    invoke-virtual {v0, p1}, Landroidx/lifecycle/MutableLiveData;->postValue(Ljava/lang/Object;)V

    return-void
.end method

.method public removeObserver(Landroidx/camera/core/impl/Observable$Observer;)V
    .locals 3

    .line 125
    iget-object v0, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    monitor-enter v0

    .line 126
    :try_start_0
    iget-object v1, p0, Landroidx/camera/core/impl/LiveDataObservable;->mObservers:Ljava/util/Map;

    invoke-interface {v1, p1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;

    if-eqz p1, :cond_0

    .line 129
    invoke-virtual {p1}, Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;->disable()V

    .line 130
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->mainThreadExecutor()Ljava/util/concurrent/ScheduledExecutorService;

    move-result-object v1

    new-instance v2, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda0;

    invoke-direct {v2, p0, p1}, Landroidx/camera/core/impl/LiveDataObservable$$ExternalSyntheticLambda0;-><init>(Landroidx/camera/core/impl/LiveDataObservable;Landroidx/camera/core/impl/LiveDataObservable$LiveDataObserverAdapter;)V

    invoke-interface {v1, v2}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 133
    :cond_0
    :goto_0
    monitor-exit v0

    return-void

    :goto_1
    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1
.end method
