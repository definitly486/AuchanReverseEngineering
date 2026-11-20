.class final Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;
.super Lkotlin/coroutines/jvm/internal/SuspendLambda;
.source "QueryInterceptorDatabase.android.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function2;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->query(Landroidx/sqlite/db/SupportSQLiteQuery;Landroid/os/CancellationSignal;)Landroid/database/Cursor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# instance fields
.field final synthetic $query:Landroidx/sqlite/db/SupportSQLiteQuery;

.field final synthetic $queryInterceptorProgram:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

.field label:I

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Landroidx/sqlite/db/SupportSQLiteQuery;Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;Lkotlin/coroutines/Continuation;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$query:Landroidx/sqlite/db/SupportSQLiteQuery;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$queryInterceptorProgram:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

    const/4 p1, 0x2

    invoke-direct {p0, p1, p4}, Lkotlin/coroutines/jvm/internal/SuspendLambda;-><init>(ILkotlin/coroutines/Continuation;)V

    return-void
.end method


# virtual methods
.method public final create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;
    .locals 3

    .line 0
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$query:Landroidx/sqlite/db/SupportSQLiteQuery;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$queryInterceptorProgram:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

    invoke-direct {p1, v0, v1, v2, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Landroidx/sqlite/db/SupportSQLiteQuery;Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;Lkotlin/coroutines/Continuation;)V

    return-object p1
.end method

.method public bridge synthetic invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    check-cast p1, Lkotlinx/coroutines/CoroutineScope;

    check-cast p2, Lkotlin/coroutines/Continuation;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->invoke(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invoke(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;
    .locals 0

    .line 0
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->create(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;

    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-virtual {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public final invokeSuspend(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 2

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/coroutines/intrinsics/IntrinsicsKt;->getCOROUTINE_SUSPENDED()Ljava/lang/Object;

    .line 108
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->label:I

    if-nez v0, :cond_0

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/ResultKt;->throwOnFailure(Ljava/lang/Object;)V

    .line 109
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->access$getQueryCallback$p(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;)Landroidx/room/RoomDatabase$QueryCallback;

    move-result-object p1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$query:Landroidx/sqlite/db/SupportSQLiteQuery;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteQuery;->getSql()Ljava/lang/String;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;->$queryInterceptorProgram:Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;->getBindArgsCache$room_runtime_release()Ljava/util/List;

    move-result-object v1

    invoke-interface {p1, v0, v1}, Landroidx/room/RoomDatabase$QueryCallback;->onQuery(Ljava/lang/String;Ljava/util/List;)V

    .line 110
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-object p1

    .line 108
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "call to \'resume\' before \'invoke\' with coroutine"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
