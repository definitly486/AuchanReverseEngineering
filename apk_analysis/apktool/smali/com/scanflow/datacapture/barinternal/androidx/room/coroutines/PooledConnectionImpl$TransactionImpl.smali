.class final Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$TransactionImpl;
.super Ljava/lang/Object;
.source "ConnectionPoolImpl.kt"

# interfaces
.implements Landroidx/room/TransactionScope;
.implements Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/RawConnectionAccessor;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x12
    name = "TransactionImpl"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;)V
    .locals 0

    .line 459
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$TransactionImpl;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getRawConnection()Landroidx/sqlite/SQLiteConnection;
    .locals 1

    .line 462
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$TransactionImpl;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->getRawConnection()Landroidx/sqlite/SQLiteConnection;

    move-result-object v0

    return-object v0
.end method

.method public usePrepared(Ljava/lang/String;Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 1

    .line 465
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl$TransactionImpl;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;

    invoke-virtual {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/room/coroutines/PooledConnectionImpl;->usePrepared(Ljava/lang/String;Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
