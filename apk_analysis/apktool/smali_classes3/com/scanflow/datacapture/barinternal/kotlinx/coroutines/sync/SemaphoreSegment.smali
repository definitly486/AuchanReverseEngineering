.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;
.source "Semaphore.kt"


# instance fields
.field private final synthetic acquirers:Ljava/util/concurrent/atomic/AtomicReferenceArray;


# direct methods
.method public constructor <init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;I)V
    .locals 0

    .line 361
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;-><init>(JLcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;I)V

    new-instance p1, Ljava/util/concurrent/atomic/AtomicReferenceArray;

    .line 362
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->access$getSEGMENT_SIZE$p()I

    move-result p2

    invoke-direct {p1, p2}, Ljava/util/concurrent/atomic/AtomicReferenceArray;-><init>(I)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;->acquirers:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    return-void
.end method


# virtual methods
.method public final synthetic getAcquirers()Ljava/util/concurrent/atomic/AtomicReferenceArray;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;->acquirers:Ljava/util/concurrent/atomic/AtomicReferenceArray;

    return-object v0
.end method

.method public getNumberOfSlots()I
    .locals 1

    .line 363
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->access$getSEGMENT_SIZE$p()I

    move-result v0

    return v0
.end method

.method public onCancellation(ILjava/lang/Throwable;Lkotlin/coroutines/CoroutineContext;)V
    .locals 0

    .line 383
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreKt;->access$getCANCELLED$p()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    move-result-object p2

    .line 397
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/sync/SemaphoreSegment;->getAcquirers()Ljava/util/concurrent/atomic/AtomicReferenceArray;

    move-result-object p3

    invoke-virtual {p3, p1, p2}, Ljava/util/concurrent/atomic/AtomicReferenceArray;->set(ILjava/lang/Object;)V

    .line 385
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->onSlotCleaned()V

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 388
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "SemaphoreSegment[id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Segment;->id:J

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    const-string v1, ", hashCode="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const/16 v1, 0x5d

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
