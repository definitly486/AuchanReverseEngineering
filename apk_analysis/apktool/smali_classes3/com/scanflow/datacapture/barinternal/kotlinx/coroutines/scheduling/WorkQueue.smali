.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;
.super Ljava/lang/Object;
.source "WorkQueue.kt"


# static fields
.field private static final synthetic blockingTasksInBuffer$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

.field private static final synthetic consumerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

.field private static final synthetic lastScheduledTask$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

.field private static final synthetic producerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;


# instance fields
.field private volatile synthetic blockingTasksInBuffer$volatile:I

.field private final buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

.field private volatile synthetic consumerIndex$volatile:I

.field private volatile synthetic lastScheduledTask$volatile:Ljava/lang/Object;

.field private volatile synthetic producerIndex$volatile:I


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 0
    const-class v0, Ljava/lang/Object;

    const-string v1, "lastScheduledTask$volatile"

    const-class v2, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;

    invoke-static {v2, v0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->lastScheduledTask$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    const-string v0, "producerIndex$volatile"

    invoke-static {v2, v0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->producerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    const-string v0, "consumerIndex$volatile"

    invoke-static {v2, v0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->consumerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    const-string v0, "blockingTasksInBuffer$volatile"

    invoke-static {v2, v0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->newUpdater(Ljava/lang/Class;Ljava/lang/String;)Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->blockingTasksInBuffer$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .line 42
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 61
    new-instance v0, Ljava/util/concurrent/atomic/AtomicReferenceArray;

    const/16 v1, 0x80

    invoke-direct {v0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceArray;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    return-void
.end method

.method private final addLast(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 2

    .line 90
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBufferSize()I

    move-result v0

    const/16 v1, 0x7f

    if-ne v0, v1, :cond_0

    return-object p1

    .line 252
    :cond_0
    iget-boolean v0, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->taskContext:Z

    if-eqz v0, :cond_1

    .line 91
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->incrementAndGet(Ljava/lang/Object;)I

    .line 92
    :cond_1
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    and-int/2addr v0, v1

    .line 101
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    invoke-virtual {v1, v0}, Ljava/util/concurrent/atomic/AtomicReferenceArray;->get(I)Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_2

    .line 102
    invoke-static {}, Ljava/lang/Thread;->yield()V

    goto :goto_0

    .line 104
    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    invoke-virtual {v1, v0, p1}, Ljava/util/concurrent/atomic/AtomicReferenceArray;->lazySet(ILjava/lang/Object;)V

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object p1

    .line 105
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->incrementAndGet(Ljava/lang/Object;)I

    const/4 p1, 0x0

    return-object p1
.end method

.method private final decrementIfBlocking(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;)V
    .locals 0

    if-eqz p1, :cond_0

    .line 258
    iget-boolean p1, p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->taskContext:Z

    if-eqz p1, :cond_0

    .line 245
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object p1

    .line 246
    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->decrementAndGet(Ljava/lang/Object;)I

    :cond_0
    return-void
.end method

.method private static final synthetic getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->blockingTasksInBuffer$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-object v0
.end method

.method private final getBufferSize()I
    .locals 2

    .line 59
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    sub-int/2addr v0, v1

    return v0
.end method

.method private static final synthetic getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->consumerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->lastScheduledTask$volatile$FU:Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    return-object v0
.end method

.method private static final synthetic getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->producerIndex$volatile$FU:Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    return-object v0
.end method

.method private final pollBuffer()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 5

    .line 231
    :cond_0
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 232
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    .line 233
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    sub-int v1, v0, v1

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return-object v2

    :cond_1
    and-int/lit8 v1, v0, 0x7f

    .line 235
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v3

    add-int/lit8 v4, v0, 0x1

    invoke-virtual {v3, p0, v0, v4}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->compareAndSet(Ljava/lang/Object;II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 237
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    invoke-virtual {v0, v1, v2}, Ljava/util/concurrent/atomic/AtomicReferenceArray;->getAndSet(ILjava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    if-nez v0, :cond_2

    goto :goto_0

    .line 238
    :cond_2
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->decrementIfBlocking(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;)V

    return-object v0
.end method

.method private final pollTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/GlobalQueue;)Z
    .locals 1

    .line 225
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->pollBuffer()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 226
    :cond_0
    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueue;->addLast(Ljava/lang/Object;)Z

    const/4 p1, 0x1

    return p1
.end method

.method private final pollWithExclusiveMode(Z)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 4

    .line 157
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    const/4 v1, 0x0

    if-nez v0, :cond_1

    goto :goto_0

    .line 253
    :cond_1
    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->taskContext:Z

    if-ne v2, p1, :cond_2

    .line 159
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v2

    invoke-static {v2, p0, v0, v1}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return-object v0

    .line 160
    :cond_2
    :goto_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 165
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v2

    .line 166
    invoke-virtual {v2, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v2

    :cond_3
    if-eq v0, v2, :cond_5

    if-eqz p1, :cond_4

    .line 169
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v3

    invoke-virtual {v3, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v3

    if-nez v3, :cond_4

    return-object v1

    :cond_4
    add-int/lit8 v2, v2, -0x1

    .line 170
    invoke-direct {p0, v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->tryExtractFromTheMiddle(IZ)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v3

    if-eqz v3, :cond_3

    return-object v3

    :cond_5
    return-object v1
.end method

.method private final stealWithExclusiveMode(I)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 4

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getConsumerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v0

    .line 135
    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v0

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getProducerIndex$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v1

    .line 136
    invoke-virtual {v1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v1

    const/4 v2, 0x1

    if-ne p1, v2, :cond_0

    goto :goto_0

    :cond_0
    const/4 v2, 0x0

    :goto_0
    const/4 p1, 0x0

    if-eq v0, v1, :cond_3

    if-eqz v2, :cond_1

    .line 140
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object v3

    invoke-virtual {v3, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->get(Ljava/lang/Object;)I

    move-result v3

    if-nez v3, :cond_1

    return-object p1

    :cond_1
    add-int/lit8 p1, v0, 0x1

    .line 141
    invoke-direct {p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->tryExtractFromTheMiddle(IZ)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    if-nez v0, :cond_2

    move v0, p1

    goto :goto_0

    :cond_2
    return-object v0

    :cond_3
    return-object p1
.end method

.method private final tryExtractFromTheMiddle(IZ)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 3

    and-int/lit8 p1, p1, 0x7f

    .line 180
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    invoke-virtual {v0, p1}, Ljava/util/concurrent/atomic/AtomicReferenceArray;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    const/4 v1, 0x0

    if-eqz v0, :cond_1

    .line 254
    iget-boolean v2, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->taskContext:Z

    if-ne v2, p2, :cond_1

    .line 181
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->buffer:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    invoke-static {v2, p1, v0, v1}, Lcom/google/common/util/concurrent/Striped$SmallLazyStriped$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceArray;ILjava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_1

    if-eqz p2, :cond_0

    .line 182
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBlockingTasksInBuffer$volatile$FU()Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;

    move-result-object p1

    invoke-virtual {p1, p0}, Ljava/util/concurrent/atomic/AtomicIntegerFieldUpdater;->decrementAndGet(Ljava/lang/Object;)I

    :cond_0
    return-object v0

    :cond_1
    return-object v1
.end method

.method private final tryStealLastScheduled(ILkotlin/jvm/internal/Ref$ObjectRef;)J
    .locals 6

    .line 200
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    const-wide/16 v1, -0x2

    if-nez v0, :cond_1

    return-wide v1

    .line 257
    :cond_1
    iget-boolean v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->taskContext:Z

    if-eqz v3, :cond_2

    const/4 v3, 0x1

    goto :goto_0

    :cond_2
    const/4 v3, 0x2

    :goto_0
    and-int/2addr v3, p1

    if-nez v3, :cond_3

    return-wide v1

    .line 206
    :cond_3
    sget-object v1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->schedulerTimeSource:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerTimeSource;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/SchedulerTimeSource;->nanoTime()J

    move-result-wide v1

    .line 207
    iget-wide v3, v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;->submissionTime:J

    sub-long/2addr v1, v3

    .line 208
    sget-wide v3, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/TasksKt;->WORK_STEALING_TIME_RESOLUTION_NS:J

    cmp-long v5, v1, v3

    if-gez v5, :cond_4

    sub-long/2addr v3, v1

    return-wide v3

    .line 216
    :cond_4
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v1

    const/4 v2, 0x0

    invoke-static {v1, p0, v0, v2}, Landroidx/concurrent/futures/AbstractResolvableFuture$SafeAtomicHelper$$ExternalSyntheticBackportWithForwarding0;->m(Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 217
    iput-object v0, p2, Lkotlin/jvm/internal/Ref$ObjectRef;->element:Ljava/lang/Object;

    const-wide/16 p1, -0x1

    return-wide p1
.end method


# virtual methods
.method public final add(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;Z)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 0

    if-eqz p2, :cond_0

    .line 80
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->addLast(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object p1

    return-object p1

    .line 81
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object p2

    invoke-virtual {p2, p0, p1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->getAndSet(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    if-nez p1, :cond_1

    const/4 p1, 0x0

    return-object p1

    .line 82
    :cond_1
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->addLast(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object p1

    return-object p1
.end method

.method public final getSize$kotlinx_coroutines_core()I
    .locals 1

    .line 60
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBufferSize()I

    move-result v0

    add-int/lit8 v0, v0, 0x1

    return v0

    :cond_0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getBufferSize()I

    move-result v0

    return v0
.end method

.method public final offloadAllWorkTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/GlobalQueue;)V
    .locals 2

    .line 189
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->getAndSet(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    if-eqz v0, :cond_0

    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueue;->addLast(Ljava/lang/Object;)Z

    .line 190
    :cond_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->pollTo(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/GlobalQueue;)Z

    move-result v0

    if-nez v0, :cond_0

    return-void
.end method

.method public final poll()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 2

    .line 73
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->getLastScheduledTask$volatile$FU()Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;

    move-result-object v0

    const/4 v1, 0x0

    invoke-virtual {v0, p0, v1}, Ljava/util/concurrent/atomic/AtomicReferenceFieldUpdater;->getAndSet(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    if-nez v0, :cond_0

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->pollBuffer()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public final pollBlocking()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;
    .locals 1

    const/4 v0, 0x1

    .line 149
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->pollWithExclusiveMode(Z)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    return-object v0
.end method

.method public final trySteal(ILkotlin/jvm/internal/Ref$ObjectRef;)J
    .locals 1

    const/4 v0, 0x3

    if-ne p1, v0, :cond_0

    .line 122
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->pollBuffer()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    goto :goto_0

    .line 123
    :cond_0
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->stealWithExclusiveMode(I)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/Task;

    move-result-object v0

    :goto_0
    if-eqz v0, :cond_1

    .line 127
    iput-object v0, p2, Lkotlin/jvm/internal/Ref$ObjectRef;->element:Ljava/lang/Object;

    const-wide/16 p1, -0x1

    return-wide p1

    .line 130
    :cond_1
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/scheduling/WorkQueue;->tryStealLastScheduled(ILkotlin/jvm/internal/Ref$ObjectRef;)J

    move-result-wide p1

    return-wide p1
.end method
