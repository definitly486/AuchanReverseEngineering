.class public final Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;
.super Ljava/lang/Object;
.source "QueryInterceptorStatement.android.kt"

# interfaces
.implements Landroidx/sqlite/db/SupportSQLiteStatement;


# instance fields
.field private final bindArgsCache:Ljava/util/List;

.field private final delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

.field private final queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

.field private final queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

.field private final sqlStatement:Ljava/lang/String;


# direct methods
.method public constructor <init>(Landroidx/sqlite/db/SupportSQLiteStatement;Ljava/lang/String;Lkotlinx/coroutines/CoroutineScope;Landroidx/room/RoomDatabase$QueryCallback;)V
    .locals 1

    const-string v0, "delegate"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sqlStatement"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallbackScope"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallback"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 26
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    .line 27
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->sqlStatement:Ljava/lang/String;

    .line 28
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    .line 29
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    .line 32
    new-instance p1, Ljava/util/ArrayList;

    invoke-direct {p1}, Ljava/util/ArrayList;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    return-void
.end method

.method public static final synthetic access$getQueryCallback$p(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;)Landroidx/room/RoomDatabase$QueryCallback;
    .locals 0

    .line 25
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    return-object p0
.end method

.method public static final synthetic access$getSqlStatement$p(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;)Ljava/lang/String;
    .locals 0

    .line 25
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->sqlStatement:Ljava/lang/String;

    return-object p0
.end method

.method private final saveArgsToCache(ILjava/lang/Object;)V
    .locals 4

    add-int/lit8 p1, p1, -0x1

    .line 96
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lt p1, v0, :cond_0

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    sub-int v0, p1, v0

    add-int/lit8 v0, v0, 0x1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    const/4 v3, 0x0

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 100
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    invoke-interface {v0, p1, p2}, Ljava/util/List;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public bindBlob(I[B)V
    .locals 1

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 85
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->saveArgsToCache(ILjava/lang/Object;)V

    .line 86
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0, p1, p2}, Landroidx/sqlite/db/SupportSQLiteProgram;->bindBlob(I[B)V

    return-void
.end method

.method public bindDouble(ID)V
    .locals 1

    .line 75
    invoke-static {p2, p3}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->saveArgsToCache(ILjava/lang/Object;)V

    .line 76
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0, p1, p2, p3}, Landroidx/sqlite/db/SupportSQLiteProgram;->bindDouble(ID)V

    return-void
.end method

.method public bindLong(IJ)V
    .locals 1

    .line 70
    invoke-static {p2, p3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->saveArgsToCache(ILjava/lang/Object;)V

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0, p1, p2, p3}, Landroidx/sqlite/db/SupportSQLiteProgram;->bindLong(IJ)V

    return-void
.end method

.method public bindNull(I)V
    .locals 1

    const/4 v0, 0x0

    .line 65
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->saveArgsToCache(ILjava/lang/Object;)V

    .line 66
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0, p1}, Landroidx/sqlite/db/SupportSQLiteProgram;->bindNull(I)V

    return-void
.end method

.method public bindString(ILjava/lang/String;)V
    .locals 1

    const-string v0, "value"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 80
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->saveArgsToCache(ILjava/lang/Object;)V

    .line 81
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0, p1, p2}, Landroidx/sqlite/db/SupportSQLiteProgram;->bindString(ILjava/lang/String;)V

    return-void
.end method

.method public clearBindings()V
    .locals 1

    .line 90
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    .line 91
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteProgram;->clearBindings()V

    return-void
.end method

.method public close()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0}, Ljava/io/Closeable;->close()V

    return-void
.end method

.method public execute()V
    .locals 7

    .line 35
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    check-cast v0, Ljava/lang/Iterable;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->toList(Ljava/lang/Iterable;)Ljava/util/List;

    move-result-object v0

    .line 36
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$execute$1;

    const/4 v2, 0x0

    invoke-direct {v4, p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$execute$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;Ljava/util/List;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 37
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteStatement;->execute()V

    return-void
.end method

.method public executeInsert()J
    .locals 7

    .line 47
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    check-cast v0, Ljava/lang/Iterable;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->toList(Ljava/lang/Iterable;)Ljava/util/List;

    move-result-object v0

    .line 48
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$executeInsert$1;

    const/4 v2, 0x0

    invoke-direct {v4, p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$executeInsert$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;Ljava/util/List;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteStatement;->executeInsert()J

    move-result-wide v0

    return-wide v0
.end method

.method public executeUpdateDelete()I
    .locals 7

    .line 41
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->bindArgsCache:Ljava/util/List;

    check-cast v0, Ljava/lang/Iterable;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->toList(Ljava/lang/Iterable;)Ljava/util/List;

    move-result-object v0

    .line 42
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    new-instance v4, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$executeUpdateDelete$1;

    const/4 v2, 0x0

    invoke-direct {v4, p0, v0, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement$executeUpdateDelete$1;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;Ljava/util/List;Lkotlin/coroutines/Continuation;)V

    const/4 v5, 0x3

    const/4 v6, 0x0

    const/4 v3, 0x0

    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/BuildersKt;->launch$default(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineStart;Lkotlin/jvm/functions/Function2;ILjava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;

    .line 43
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorStatement;->delegate:Landroidx/sqlite/db/SupportSQLiteStatement;

    invoke-interface {v0}, Landroidx/sqlite/db/SupportSQLiteStatement;->executeUpdateDelete()I

    move-result v0

    return v0
.end method
