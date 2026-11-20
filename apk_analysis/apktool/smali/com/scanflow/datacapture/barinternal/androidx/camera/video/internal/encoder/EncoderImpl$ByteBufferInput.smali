.class Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;
.super Ljava/lang/Object;
.source "EncoderImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$ByteBufferInput;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "ByteBufferInput"
.end annotation


# instance fields
.field private final mAcquisitionList:Ljava/util/List;

.field private mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

.field private final mStateObservers:Ljava/util/Map;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;


# direct methods
.method public static synthetic $r8$lambda$2XJ2BIyKsT4KBcGY3x7EMhH0NCY(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 0

    .line 1621
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    invoke-virtual {p1, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->set(Ljava/lang/Object;)Z

    return-void
.end method

.method public static synthetic $r8$lambda$8bEbSGDvPYsNmtQR0pi7Y389IvU(Ljava/util/Map$Entry;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V
    .locals 0

    .line 1705
    invoke-interface {p0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroidx/camera/core/impl/Observable$Observer;

    invoke-interface {p0, p1}, Landroidx/camera/core/impl/Observable$Observer;->onNewData(Ljava/lang/Object;)V

    return-void
.end method

.method public static synthetic $r8$lambda$CWn7npQsh0NJOk84IyXeWaDBVnw(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    .line 1621
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mEncoderExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda5;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda5;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 1622
    const-string p0, "fetchData"

    return-object p0
.end method

.method public static synthetic $r8$lambda$GP73q-yCV4qel6-diFS_1dlZqWg(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/camera/core/impl/Observable$Observer;Ljava/util/concurrent/Executor;)V
    .locals 3

    .line 1674
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mStateObservers:Ljava/util/Map;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroidx/camera/core/impl/Observable$Observer;

    .line 1675
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/concurrent/Executor;

    .line 1674
    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1676
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    .line 1677
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;

    invoke-direct {v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda6;-><init>(Landroidx/camera/core/impl/Observable$Observer;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V

    invoke-interface {p2, v0}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public static synthetic $r8$lambda$KCoKy14w-Y3vZPvGVYd7l0C5yVs(Landroidx/camera/core/impl/Observable$Observer;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V
    .locals 0

    .line 1677
    invoke-interface {p0, p1}, Landroidx/camera/core/impl/Observable$Observer;->onNewData(Ljava/lang/Object;)V

    return-void
.end method

.method public static synthetic $r8$lambda$WwmosOSehnhxkSVDya-2vTPcC7k(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/camera/core/impl/Observable$Observer;)V
    .locals 0

    .line 1685
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mStateObservers:Ljava/util/Map;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    invoke-interface {p0, p1}, Ljava/util/Map;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public static synthetic $r8$lambda$eE2yHod7lwXhu2z2U5g2wvrZAcQ(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Lcom/google/common/util/concurrent/ListenableFuture;)V
    .locals 0

    .line 1643
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mAcquisitionList:Ljava/util/List;

    invoke-interface {p0, p1}, Ljava/util/List;->remove(Ljava/lang/Object;)Z

    return-void
.end method

.method public static synthetic $r8$lambda$pJo8fbUmpfq_J7uv6_G8ExE4aVU(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)Ljava/lang/Object;
    .locals 2

    .line 1631
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mEncoderExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda7;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda7;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    .line 1653
    const-string p0, "acquireBuffer"

    return-object p0
.end method

.method public static synthetic $r8$lambda$q3eA5LqyMEAJZ1Z3r6tjvgTmsks(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V
    .locals 3

    .line 1632
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->ACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    if-ne v0, v1, :cond_0

    .line 1633
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->acquireInputBuffer()Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    .line 1634
    invoke-static {v0, p1}, Landroidx/camera/core/impl/utils/futures/Futures;->propagate(Lcom/google/common/util/concurrent/ListenableFuture;Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;)V

    .line 1636
    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda8;

    invoke-direct {v1, p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda8;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Lcom/google/common/util/concurrent/ListenableFuture;)V

    .line 1637
    invoke-static {}, Landroidx/camera/core/impl/utils/executor/CameraXExecutors;->directExecutor()Ljava/util/concurrent/Executor;

    move-result-object v2

    .line 1636
    invoke-virtual {p1, v1, v2}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->addCancellationListener(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V

    .line 1642
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mAcquisitionList:Ljava/util/List;

    invoke-interface {p1, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 1643
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda9;

    invoke-direct {p1, p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda9;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Lcom/google/common/util/concurrent/ListenableFuture;)V

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mEncoderExecutor:Ljava/util/concurrent/Executor;

    invoke-interface {v0, p1, p0}, Lcom/google/common/util/concurrent/ListenableFuture;->addListener(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V

    return-void

    .line 1644
    :cond_0
    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->INACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    if-ne v0, v1, :cond_1

    .line 1645
    new-instance p0, Ljava/lang/IllegalStateException;

    const-string v0, "BufferProvider is not active."

    invoke-direct {p0, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->setException(Ljava/lang/Throwable;)Z

    return-void

    .line 1648
    :cond_1
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown state: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter$Completer;->setException(Ljava/lang/Throwable;)Z

    return-void
.end method

.method public static synthetic $r8$lambda$ygB4clzug31QEfEjroCuE2lXDJs(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Lcom/google/common/util/concurrent/ListenableFuture;)V
    .locals 0

    .line 1636
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->cancelInputBuffer(Lcom/google/common/util/concurrent/ListenableFuture;)V

    return-void
.end method

.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;)V
    .locals 0

    .line 1607
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 1609
    new-instance p1, Ljava/util/LinkedHashMap;

    invoke-direct {p1}, Ljava/util/LinkedHashMap;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mStateObservers:Ljava/util/Map;

    .line 1612
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->INACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    .line 1614
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mAcquisitionList:Ljava/util/List;

    return-void
.end method

.method private cancelInputBuffer(Lcom/google/common/util/concurrent/ListenableFuture;)V
    .locals 3

    const/4 v0, 0x1

    .line 1658
    invoke-interface {p1, v0}, Ljava/util/concurrent/Future;->cancel(Z)Z

    move-result v0

    if-nez v0, :cond_0

    .line 1660
    invoke-interface {p1}, Ljava/util/concurrent/Future;->isDone()Z

    move-result v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkState(Z)V

    .line 1662
    :try_start_0
    invoke-interface {p1}, Ljava/util/concurrent/Future;->get()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/InputBuffer;

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/InputBuffer;->cancel()Z
    :try_end_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/util/concurrent/CancellationException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p1

    goto :goto_0

    :catch_1
    move-exception p1

    goto :goto_0

    :catch_2
    move-exception p1

    .line 1664
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mTag:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unable to cancel the input buffer: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Landroidx/camera/core/Logger;->w(Ljava/lang/String;Ljava/lang/String;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public acquireBuffer()Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 1

    .line 1630
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda4;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda4;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;)V

    invoke-static {v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter;->getFuture(Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    return-object v0
.end method

.method public addObserver(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/Observable$Observer;)V
    .locals 2

    .line 1673
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mEncoderExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/camera/core/impl/Observable$Observer;Ljava/util/concurrent/Executor;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method public fetchData()Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 1

    .line 1620
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;)V

    invoke-static {v0}, Landroidx/concurrent/futures/CallbackToFutureAdapter;->getFuture(Landroidx/concurrent/futures/CallbackToFutureAdapter$Resolver;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object v0

    return-object v0
.end method

.method public removeObserver(Landroidx/camera/core/impl/Observable$Observer;)V
    .locals 2

    .line 1684
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mEncoderExecutor:Ljava/util/concurrent/Executor;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda3;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;Landroidx/camera/core/impl/Observable$Observer;)V

    invoke-interface {v0, v1}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    return-void
.end method

.method setActive(Z)V
    .locals 4

    if-eqz p1, :cond_0

    .line 1690
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->ACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    goto :goto_0

    :cond_0
    sget-object p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->INACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    .line 1691
    :goto_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    if-ne v0, p1, :cond_1

    goto :goto_3

    .line 1694
    :cond_1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mBufferProviderState:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    .line 1696
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;->INACTIVE:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;

    if-ne p1, v0, :cond_3

    .line 1697
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mAcquisitionList:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_1
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/google/common/util/concurrent/ListenableFuture;

    const/4 v2, 0x1

    .line 1698
    invoke-interface {v1, v2}, Ljava/util/concurrent/Future;->cancel(Z)Z

    goto :goto_1

    .line 1700
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mAcquisitionList:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    .line 1703
    :cond_3
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->mStateObservers:Ljava/util/Map;

    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_2
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_4

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/Map$Entry;

    .line 1705
    :try_start_0
    invoke-interface {v1}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/concurrent/Executor;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda2;

    invoke-direct {v3, v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput$$ExternalSyntheticLambda2;-><init>(Ljava/util/Map$Entry;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/BufferProvider$State;)V

    invoke-interface {v2, v3}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V
    :try_end_0
    .catch Ljava/util/concurrent/RejectedExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_2

    :catch_0
    move-exception v1

    .line 1707
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl$ByteBufferInput;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;

    iget-object v2, v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderImpl;->mTag:Ljava/lang/String;

    const-string v3, "Unable to post to the supplied executor."

    invoke-static {v2, v3, v1}, Landroidx/camera/core/Logger;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_2

    :cond_4
    :goto_3
    return-void
.end method
