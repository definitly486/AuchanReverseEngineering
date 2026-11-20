.class public abstract Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;
.super Ljava/util/concurrent/ForkJoinTask;
.source "IntOperatorTask.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Min;,
        Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask$Max;
    }
.end annotation


# instance fields
.field final consumer:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;

.field master:Z

.field final max:I

.field next:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

.field primitiveType:Ljava/lang/Class;

.field result:Ljava/lang/Number;

.field final value:I


# direct methods
.method protected constructor <init>(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)V
    .locals 1

    .line 44
    invoke-direct {p0}, Ljava/util/concurrent/ForkJoinTask;-><init>()V

    const/4 v0, 0x1

    .line 36
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->master:Z

    const/4 v0, 0x0

    .line 40
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->next:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

    .line 45
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->value:I

    .line 46
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->max:I

    .line 47
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->primitiveType:Ljava/lang/Class;

    .line 48
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->consumer:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;

    return-void
.end method


# virtual methods
.method protected exec()Z
    .locals 8

    .line 65
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->master:Z

    const/4 v1, 0x0

    if-eqz v0, :cond_2

    .line 67
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->value:I

    move-object v2, v1

    move-object v3, v2

    :goto_0
    add-int/lit8 v4, v0, 0x1

    .line 68
    iget v5, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->max:I

    if-ge v4, v5, :cond_1

    .line 69
    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->primitiveType:Ljava/lang/Class;

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->consumer:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;

    invoke-virtual {p0, v0, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->newInstance(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

    move-result-object v0

    const/4 v5, 0x0

    .line 70
    iput-boolean v5, v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->master:Z

    if-nez v2, :cond_0

    move-object v2, v0

    goto :goto_1

    .line 75
    :cond_0
    invoke-static {v3}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    iput-object v0, v3, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->next:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

    .line 78
    :goto_1
    invoke-virtual {v0}, Ljava/util/concurrent/ForkJoinTask;->fork()Ljava/util/concurrent/ForkJoinTask;

    move-object v3, v0

    move v0, v4

    goto :goto_0

    .line 82
    :cond_1
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->consumer:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;

    invoke-interface {v3, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;->accept(I)Ljava/lang/Number;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->result:Ljava/lang/Number;

    goto :goto_2

    .line 84
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->consumer:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->value:I

    invoke-interface {v0, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;->accept(I)Ljava/lang/Number;

    move-result-object v0

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->result:Ljava/lang/Number;

    move-object v2, v1

    :goto_2
    if-eqz v2, :cond_3

    .line 90
    invoke-virtual {v2}, Ljava/util/concurrent/ForkJoinTask;->join()Ljava/lang/Object;

    .line 91
    iget-object v0, v2, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->result:Ljava/lang/Number;

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->operator(Ljava/lang/Number;)V

    .line 92
    iget-object v0, v2, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->next:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

    .line 93
    iput-object v1, v2, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->next:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;

    move-object v2, v0

    goto :goto_2

    :cond_3
    const/4 v0, 0x1

    return v0
.end method

.method public getRawResult()Ljava/lang/Number;
    .locals 1

    .line 52
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->result:Ljava/lang/Number;

    return-object v0
.end method

.method protected abstract newInstance(IILjava/lang/Class;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntProducerNumber;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;
.end method

.method protected abstract operator(Ljava/lang/Number;)V
.end method

.method protected setRawResult(Ljava/lang/Number;)V
    .locals 0

    .line 56
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/IntOperatorTask;->result:Ljava/lang/Number;

    return-void
.end method
