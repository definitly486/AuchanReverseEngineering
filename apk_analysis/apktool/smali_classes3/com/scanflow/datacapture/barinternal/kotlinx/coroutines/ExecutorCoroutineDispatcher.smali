.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;
.source "Executors.kt"

# interfaces
.implements Ljava/io/Closeable;
.implements Ljava/lang/AutoCloseable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher$Key;
    }
.end annotation


# static fields
.field public static final Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher$Key;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher$Key;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher$Key;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ExecutorCoroutineDispatcher$Key;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 16
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineDispatcher;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract getExecutor()Ljava/util/concurrent/Executor;
.end method
