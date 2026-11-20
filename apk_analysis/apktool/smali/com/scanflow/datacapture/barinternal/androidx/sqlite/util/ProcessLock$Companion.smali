.class final Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock$Companion;
.super Ljava/lang/Object;
.source "ProcessLock.android.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 86
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock$Companion;-><init>()V

    return-void
.end method

.method public static final synthetic access$getThreadLock(Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock$Companion;Ljava/lang/String;)Ljava/util/concurrent/locks/Lock;
    .locals 0

    .line 86
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock$Companion;->getThreadLock(Ljava/lang/String;)Ljava/util/concurrent/locks/Lock;

    move-result-object p0

    return-object p0
.end method

.method private final getThreadLock(Ljava/lang/String;)Ljava/util/concurrent/locks/Lock;
    .locals 3

    .line 92
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock;->access$getThreadLocksMap$cp()Ljava/util/Map;

    move-result-object v0

    monitor-enter v0

    .line 93
    :try_start_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/util/ProcessLock;->access$getThreadLocksMap$cp()Ljava/util/Map;

    move-result-object v1

    .line 98
    invoke-interface {v1, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    if-nez v2, :cond_0

    .line 93
    new-instance v2, Ljava/util/concurrent/locks/ReentrantLock;

    invoke-direct {v2}, Ljava/util/concurrent/locks/ReentrantLock;-><init>()V

    .line 101
    invoke-interface {v1, p1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 99
    :cond_0
    :goto_0
    check-cast v2, Ljava/util/concurrent/locks/Lock;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 93
    monitor-exit v0

    return-object v2

    :goto_1
    monitor-exit v0

    throw p1
.end method
