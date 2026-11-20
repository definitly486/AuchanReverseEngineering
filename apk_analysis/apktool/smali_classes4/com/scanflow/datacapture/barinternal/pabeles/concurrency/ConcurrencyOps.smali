.class public abstract Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;
.super Ljava/lang/Object;
.source "ConcurrencyOps.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;,
        Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;
    }
.end annotation


# static fields
.field private static pool:Ljava/util/concurrent/ForkJoinPool;


# direct methods
.method public static synthetic $r8$lambda$T3BV64CUsKgeCqCyhPX6VYPYRtg(IILjava/util/function/IntConsumer;)V
    .locals 0

    .line 63
    invoke-static {p0, p1}, Ljava/util/stream/IntStream;->range(II)Ljava/util/stream/IntStream;

    move-result-object p0

    invoke-interface {p0}, Ljava/util/stream/IntStream;->parallel()Ljava/util/stream/IntStream;

    move-result-object p0

    invoke-interface {p0, p2}, Ljava/util/stream/IntStream;->forEach(Ljava/util/function/IntConsumer;)V

    return-void
.end method

.method static constructor <clinit>()V
    .locals 1

    .line 36
    new-instance v0, Ljava/util/concurrent/ForkJoinPool;

    invoke-direct {v0}, Ljava/util/concurrent/ForkJoinPool;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    return-void
.end method

.method public static loopBlocks(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V
    .locals 6

    .line 222
    sget-object v4, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    .line 223
    invoke-virtual {v4}, Ljava/util/concurrent/ForkJoinPool;->getParallelism()I

    move-result v0

    sub-int v1, p1, p0

    if-nez v1, :cond_0

    return-void

    :cond_0
    if-ltz v1, :cond_1

    .line 231
    invoke-static {v1, p2, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->selectBlockSize(III)I

    move-result v5

    move v0, p0

    move v1, p1

    move-object v2, p3

    move-object v3, p4

    .line 233
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->runLoopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;Ljava/util/concurrent/ForkJoinPool;I)V

    return-void

    :cond_1
    move v0, p0

    move v1, p1

    .line 229
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string p2, "end must be more than start. "

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, " -> "

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V
    .locals 6

    .line 195
    sget-object v4, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    .line 196
    invoke-virtual {v4}, Ljava/util/concurrent/ForkJoinPool;->getParallelism()I

    move-result v0

    sub-int v1, p1, p0

    if-nez v1, :cond_0

    return-void

    :cond_0
    if-ltz v1, :cond_1

    const/4 v2, 0x1

    .line 206
    div-int/2addr v1, v0

    invoke-static {v2, v1}, Ljava/lang/Math;->max(II)I

    move-result v5

    move v0, p0

    move v1, p1

    move-object v2, p2

    move-object v3, p3

    .line 208
    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->runLoopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;Ljava/util/concurrent/ForkJoinPool;I)V

    return-void

    :cond_1
    move v0, p0

    move v1, p1

    .line 202
    new-instance p0, Ljava/lang/IllegalArgumentException;

    new-instance p1, Ljava/lang/StringBuilder;

    invoke-direct {p1}, Ljava/lang/StringBuilder;-><init>()V

    const-string p2, "end must be more than start. "

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p2, " -> "

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p1, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static loopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V
    .locals 4

    .line 166
    sget-object v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    .line 167
    invoke-virtual {v0}, Ljava/util/concurrent/ForkJoinPool;->getParallelism()I

    move-result v1

    sub-int v2, p1, p0

    if-nez v2, :cond_0

    return-void

    :cond_0
    if-ltz v2, :cond_1

    const/4 v3, 0x1

    .line 177
    div-int/2addr v2, v1

    invoke-static {v3, v2}, Ljava/lang/Math;->max(II)I

    move-result v1

    .line 180
    :try_start_0
    new-instance v2, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeTask;

    invoke-direct {v2, p0, p1, v1, p2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeTask;-><init>(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeConsumer;)V

    invoke-virtual {v0, v2}, Ljava/util/concurrent/ForkJoinPool;->submit(Ljava/util/concurrent/ForkJoinTask;)Ljava/util/concurrent/ForkJoinTask;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/concurrent/ForkJoinTask;->get()Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p0

    .line 182
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw p1

    .line 173
    :cond_1
    new-instance p2, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "end must be more than start. "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p0, " -> "

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p2, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p2
.end method

.method public static loopFor(IILjava/util/function/IntConsumer;)V
    .locals 2

    .line 63
    :try_start_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$$ExternalSyntheticLambda0;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$$ExternalSyntheticLambda0;-><init>(IILjava/util/function/IntConsumer;)V

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ForkJoinPool;->submit(Ljava/lang/Runnable;)Ljava/util/concurrent/ForkJoinTask;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/concurrent/ForkJoinTask;->get()Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p0

    .line 65
    invoke-virtual {p0}, Ljava/lang/Throwable;->printStackTrace()V

    return-void
.end method

.method public static max(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Ljava/lang/Number;
    .locals 2

    .line 274
    :try_start_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Max;

    invoke-direct {v1, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Max;-><init>(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)V

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ForkJoinPool;->submit(Ljava/util/concurrent/ForkJoinTask;)Ljava/util/concurrent/ForkJoinTask;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/concurrent/ForkJoinTask;->get()Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Ljava/lang/Number;
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-object p0

    :catch_0
    move-exception p0

    .line 276
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw p1
.end method

.method public static min(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Ljava/lang/Number;
    .locals 2

    .line 291
    :try_start_0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps;->pool:Ljava/util/concurrent/ForkJoinPool;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Min;

    invoke-direct {v1, p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Min;-><init>(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)V

    invoke-virtual {v0, v1}, Ljava/util/concurrent/ForkJoinPool;->submit(Ljava/util/concurrent/ForkJoinTask;)Ljava/util/concurrent/ForkJoinTask;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/concurrent/ForkJoinTask;->get()Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Ljava/lang/Number;
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-object p0

    :catch_0
    move-exception p0

    .line 293
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw p1
.end method

.method private static runLoopBlocks(IILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;Ljava/util/concurrent/ForkJoinPool;I)V
    .locals 6

    .line 238
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->reset()V

    .line 240
    :try_start_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectTask;

    move v1, p0

    move v2, p1

    move-object v4, p2

    move-object v5, p3

    move v3, p5

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectTask;-><init>(IIILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntRangeObjectConsumer;)V

    invoke-virtual {p4, v0}, Ljava/util/concurrent/ForkJoinPool;->submit(Ljava/util/concurrent/ForkJoinTask;)Ljava/util/concurrent/ForkJoinTask;

    move-result-object p0

    invoke-virtual {p0}, Ljava/util/concurrent/ForkJoinTask;->get()Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/util/concurrent/ExecutionException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    move-object p0, v0

    .line 242
    new-instance p1, Ljava/lang/RuntimeException;

    invoke-direct {p1, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw p1
.end method

.method static selectBlockSize(III)I
    .locals 0

    .line 151
    div-int p2, p0, p2

    invoke-static {p1, p2}, Ljava/lang/Math;->max(II)I

    move-result p1

    const/4 p2, 0x1

    .line 153
    div-int p1, p0, p1

    invoke-static {p2, p1}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 154
    div-int/2addr p0, p1

    return p0
.end method
