.class public final Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;
.super Ljava/lang/Object;
.source "QueryInterceptorDatabase.android.kt"

# interfaces
.implements Landroidx/sqlite/db/SupportSQLiteDatabase;


# instance fields
.field private final delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

.field private final queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

.field private final queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;


# direct methods
.method public constructor <init>(Landroidx/sqlite/db/SupportSQLiteDatabase;Lkotlinx/coroutines/CoroutineScope;Landroidx/room/RoomDatabase$QueryCallback;)V
    .locals 1

    const-string v0, "delegate"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallbackScope"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallback"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    .line 32
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    .line 33
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    return-void
.end method

.method public static final synthetic access$getQueryCallback$p(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;)Landroidx/room/RoomDatabase$QueryCallback;
    .locals 0

    .line 30
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    return-object p0
.end method


# virtual methods
.method public beginTransaction()V
    .locals 6

    .line 46
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$beginTransaction$1;

    const/4 v1, 0x0

    invoke-direct {v3, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$beginTransaction$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Lkotlin/coroutines/Continuation;)V

    const/4 v4, 0x3

    const/4 v5, 0x0

    const/4 v2, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->beginTransaction()V

    return-void
.end method

.method public beginTransactionNonExclusive()V
    .locals 6

    .line 53
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$beginTransactionNonExclusive$1;

    const/4 v1, 0x0

    invoke-direct {v3, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$beginTransactionNonExclusive$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Lkotlin/coroutines/Continuation;)V

    const/4 v4, 0x3

    const/4 v5, 0x0

    const/4 v2, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->beginTransactionNonExclusive()V

    return-void
.end method

.method public beginTransactionReadOnly()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->beginTransactionReadOnly()V

    return-void
.end method

.method public close()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Ljava/io/Closeable;->close()V

    return-void
.end method

.method public compileStatement(Ljava/lang/String;)Landroidx/sqlite/db/SupportSQLiteStatement;
    .locals 4

    const-string v0, "sql"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 37
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;

    .line 38
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v1, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->compileStatement(Ljava/lang/String;)Landroidx/sqlite/db/SupportSQLiteStatement;

    move-result-object v1

    .line 40
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    .line 41
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    .line 37
    invoke-direct {v0, v1, p1, v2, v3}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;-><init>(Landroidx/sqlite/db/SupportSQLiteStatement;Ljava/lang/String;Lkotlinx/coroutines/CoroutineScope;Landroidx/room/RoomDatabase$QueryCallback;)V

    return-object v0
.end method

.method public endTransaction()V
    .locals 6

    .line 76
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$endTransaction$1;

    const/4 v1, 0x0

    invoke-direct {v3, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$endTransaction$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Lkotlin/coroutines/Continuation;)V

    const/4 v4, 0x3

    const/4 v5, 0x0

    const/4 v2, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->endTransaction()V

    return-void
.end method

.method public execSQL(Ljava/lang/String;)V
    .locals 7

    const-string v0, "sql"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 115
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$execSQL$1;

    const/4 v0, 0x0

    invoke-direct {v4, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$execSQL$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Ljava/lang/String;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 116
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->execSQL(Ljava/lang/String;)V

    return-void
.end method

.method public execSQL(Ljava/lang/String;[Ljava/lang/Object;)V
    .locals 7

    const-string v0, "sql"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "bindArgs"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 120
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->toList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    .line 121
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$execSQL$2;

    const/4 v2, 0x0

    invoke-direct {v4, p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$execSQL$2;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Ljava/lang/String;Ljava/util/List;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 122
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0, p1, p2}, Landroidx/sqlite/db/SupportSQLiteDatabase;->execSQL(Ljava/lang/String;[Ljava/lang/Object;)V

    return-void
.end method

.method public getAttachedDbs()Ljava/util/List;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->getAttachedDbs()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getPath()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->getPath()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public inTransaction()Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->inTransaction()Z

    move-result v0

    return v0
.end method

.method public isOpen()Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->isOpen()Z

    move-result v0

    return v0
.end method

.method public isWriteAheadLoggingEnabled()Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->isWriteAheadLoggingEnabled()Z

    move-result v0

    return v0
.end method

.method public query(Landroidx/sqlite/db/SupportSQLiteQuery;)Landroid/database/Cursor;
    .locals 7

    const-string v0, "query"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 97
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;-><init>()V

    .line 98
    invoke-interface {p1, v0}, Landroidx/sqlite/db/SupportSQLiteQuery;->bindTo(Landroidx/sqlite/db/SupportSQLiteProgram;)V

    .line 99
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$3;

    const/4 v2, 0x0

    invoke-direct {v4, p0, p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$3;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Landroidx/sqlite/db/SupportSQLiteQuery;Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 102
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->query(Landroidx/sqlite/db/SupportSQLiteQuery;)Landroid/database/Cursor;

    move-result-object p1

    return-object p1
.end method

.method public query(Landroidx/sqlite/db/SupportSQLiteQuery;Landroid/os/CancellationSignal;)Landroid/database/Cursor;
    .locals 6

    const-string p2, "query"

    invoke-static {p1, p2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 106
    new-instance p2, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;

    invoke-direct {p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;-><init>()V

    .line 107
    invoke-interface {p1, p2}, Landroidx/sqlite/db/SupportSQLiteQuery;->bindTo(Landroidx/sqlite/db/SupportSQLiteProgram;)V

    .line 108
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;

    const/4 v1, 0x0

    invoke-direct {v3, p0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$4;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Landroidx/sqlite/db/SupportSQLiteQuery;Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorProgram;Lkotlin/coroutines/Continuation;)V

    const/4 v4, 0x3

    const/4 v5, 0x0

    const/4 v2, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 111
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {p2, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->query(Landroidx/sqlite/db/SupportSQLiteQuery;)Landroid/database/Cursor;

    move-result-object p1

    return-object p1
.end method

.method public query(Ljava/lang/String;)Landroid/database/Cursor;
    .locals 7

    const-string v0, "query"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 86
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$1;

    const/4 v0, 0x0

    invoke-direct {v4, p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$query$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Ljava/lang/String;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 87
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->query(Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object p1

    return-object p1
.end method

.method public setTransactionSuccessful()V
    .locals 6

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$setTransactionSuccessful$1;

    const/4 v1, 0x0

    invoke-direct {v3, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase$setTransactionSuccessful$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;Lkotlin/coroutines/Continuation;)V

    const/4 v4, 0x3

    const/4 v5, 0x0

    const/4 v2, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteDatabase;->setTransactionSuccessful()V

    return-void
.end method

.method public setVersion(I)V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    invoke-interface {v0, p1}, Landroidx/sqlite/db/SupportSQLiteDatabase;->setVersion(I)V

    return-void
.end method

.method public update(Ljava/lang/String;ILandroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/Object;)I
    .locals 7

    .line 0
    const-string v0, "table"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "values"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorDatabase;->delegate:Landroidx/sqlite/db/SupportSQLiteDatabase;

    move-object v2, p1

    move v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    invoke-interface/range {v1 .. v6}, Landroidx/sqlite/db/SupportSQLiteDatabase;->update(Ljava/lang/String;ILandroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/Object;)I

    move-result p1

    return p1
.end method
