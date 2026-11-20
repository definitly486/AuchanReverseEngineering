.class public final Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;
.super Ljava/lang/Object;
.source "QueryInterceptorOpenHelperFactory.android.kt"

# interfaces
.implements Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;


# instance fields
.field private final delegate:Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;

.field private final queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

.field private final queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;


# direct methods
.method public constructor <init>(Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;Lkotlinx/coroutines/CoroutineScope;Landroidx/room/RoomDatabase$QueryCallback;)V
    .locals 1

    const-string v0, "delegate"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallbackScope"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "queryCallback"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 24
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 25
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->delegate:Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;

    .line 26
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    .line 27
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    return-void
.end method


# virtual methods
.method public create(Landroidx/sqlite/db/SupportSQLiteOpenHelper$Configuration;)Landroidx/sqlite/db/SupportSQLiteOpenHelper;
    .locals 3

    const-string v0, "configuration"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 32
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelper;

    .line 33
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->delegate:Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;

    invoke-interface {v1, p1}, Landroidx/sqlite/db/SupportSQLiteOpenHelper$Factory;->create(Landroidx/sqlite/db/SupportSQLiteOpenHelper$Configuration;)Landroidx/sqlite/db/SupportSQLiteOpenHelper;

    move-result-object p1

    .line 34
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->queryCallbackScope:Lkotlinx/coroutines/CoroutineScope;

    .line 35
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelperFactory;->queryCallback:Landroidx/room/RoomDatabase$QueryCallback;

    .line 32
    invoke-direct {v0, p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/room/support/QueryInterceptorOpenHelper;-><init>(Landroidx/sqlite/db/SupportSQLiteOpenHelper;Lkotlinx/coroutines/CoroutineScope;Landroidx/room/RoomDatabase$QueryCallback;)V

    return-object v0
.end method
