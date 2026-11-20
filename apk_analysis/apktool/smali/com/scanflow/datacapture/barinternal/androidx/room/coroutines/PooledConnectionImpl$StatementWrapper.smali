.class final Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;
.super Ljava/lang/Object;
.source "ConnectionPoolImpl.kt"

# interfaces
.implements Landroidx/sqlite/SQLiteStatement;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "StatementWrapper"
.end annotation


# instance fields
.field private final delegate:Landroidx/sqlite/SQLiteStatement;

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

.field private final threadId:J


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;Landroidx/sqlite/SQLiteStatement;)V
    .locals 1

    const-string v0, "delegate"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 494
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 495
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    .line 498
    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide p1

    iput-wide p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    return-void
.end method


# virtual methods
.method public bindBlob(I[B)V
    .locals 6

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 557
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 560
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 501
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1, p2}, Landroidx/sqlite/SQLiteStatement;->bindBlob(I[B)V

    return-void

    .line 563
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 561
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 558
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public bindDouble(ID)V
    .locals 6

    .line 567
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 570
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 505
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1, p2, p3}, Landroidx/sqlite/SQLiteStatement;->bindDouble(ID)V

    return-void

    .line 573
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 571
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 568
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public bindLong(IJ)V
    .locals 6

    .line 577
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 580
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 509
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1, p2, p3}, Landroidx/sqlite/SQLiteStatement;->bindLong(IJ)V

    return-void

    .line 583
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 581
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 578
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public bindNull(I)V
    .locals 6

    .line 597
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 600
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 516
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/SQLiteStatement;->bindNull(I)V

    return-void

    .line 603
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 601
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 598
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public bindText(ILjava/lang/String;)V
    .locals 6

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 587
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 590
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 513
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1, p2}, Landroidx/sqlite/SQLiteStatement;->bindText(ILjava/lang/String;)V

    return-void

    .line 593
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 591
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 588
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public close()V
    .locals 6

    .line 717
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 720
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 540
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/SQLiteStatement;->close()V

    return-void

    .line 723
    :cond_0
    const-string v0, "Attempted to use statement on a different thread"

    .line 721
    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0

    .line 718
    :cond_1
    const-string v0, "Statement is recycled"

    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0
.end method

.method public getColumnCount()I
    .locals 6

    .line 657
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 660
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 528
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/SQLiteStatement;->getColumnCount()I

    move-result v0

    return v0

    .line 663
    :cond_0
    const-string v0, "Attempted to use statement on a different thread"

    .line 661
    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0

    .line 658
    :cond_1
    const-string v0, "Statement is recycled"

    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0
.end method

.method public getColumnName(I)Ljava/lang/String;
    .locals 6

    .line 667
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 670
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 530
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/SQLiteStatement;->getColumnName(I)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 673
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 671
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 668
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public getLong(I)J
    .locals 6

    .line 627
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 630
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 522
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/SQLiteStatement;->getLong(I)J

    move-result-wide v0

    return-wide v0

    .line 633
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 631
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 628
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public getText(I)Ljava/lang/String;
    .locals 6

    .line 637
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 640
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 524
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/SQLiteStatement;->getText(I)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 643
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 641
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 638
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public isNull(I)Z
    .locals 6

    .line 647
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 650
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 526
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/SQLiteStatement;->isNull(I)Z

    move-result p1

    return p1

    .line 653
    :cond_0
    const-string p1, "Attempted to use statement on a different thread"

    .line 651
    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1

    .line 648
    :cond_1
    const-string p1, "Statement is recycled"

    invoke-static {v1, p1}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p1
.end method

.method public reset()V
    .locals 6

    .line 697
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 700
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 536
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/SQLiteStatement;->reset()V

    return-void

    .line 703
    :cond_0
    const-string v0, "Attempted to use statement on a different thread"

    .line 701
    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0

    .line 698
    :cond_1
    const-string v0, "Statement is recycled"

    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0
.end method

.method public step()Z
    .locals 6

    .line 687
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->access$isRecycled(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)Z

    move-result v0

    const/16 v1, 0x15

    if-nez v0, :cond_1

    .line 690
    iget-wide v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->threadId:J

    invoke-static {}, Landroidx/room/concurrent/ThreadLocal_jvmAndroidKt;->currentThreadId()J

    move-result-wide v4

    cmp-long v0, v2, v4

    if-nez v0, :cond_0

    .line 534
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$StatementWrapper;->delegate:Landroidx/sqlite/SQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/SQLiteStatement;->step()Z

    move-result v0

    return v0

    .line 693
    :cond_0
    const-string v0, "Attempted to use statement on a different thread"

    .line 691
    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0

    .line 688
    :cond_1
    const-string v0, "Statement is recycled"

    invoke-static {v1, v0}, Landroidx/sqlite/SQLite;->throwSQLiteException(ILjava/lang/String;)Ljava/lang/Void;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw v0
.end method
