.class public final Landroidx/room/EntityUpsertAdapter;
.super Ljava/lang/Object;
.source "EntityUpsertAdapter.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/room/EntityUpsertAdapter$Companion;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# static fields
.field public static final Companion:Landroidx/room/EntityUpsertAdapter$Companion;


# instance fields
.field private final entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

.field private final updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Landroidx/room/EntityUpsertAdapter$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/room/EntityUpsertAdapter$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Landroidx/room/EntityUpsertAdapter;->Companion:Landroidx/room/EntityUpsertAdapter$Companion;

    return-void
.end method

.method public constructor <init>(Landroidx/room/EntityInsertAdapter;Landroidx/room/EntityDeleteOrUpdateAdapter;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/room/EntityInsertAdapter<",
            "TT;>;",
            "Landroidx/room/EntityDeleteOrUpdateAdapter<",
            "TT;>;)V"
        }
    .end annotation

    const-string v0, "entityInsertAdapter"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "updateAdapter"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 34
    iput-object p1, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    .line 35
    iput-object p2, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    return-void
.end method

.method private final checkUniquenessException(Landroid/database/SQLException;)V
    .locals 5

    .line 210
    invoke-virtual {p1}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_2

    .line 212
    const-string v1, "unique"

    const/4 v2, 0x1

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains(Ljava/lang/CharSequence;Ljava/lang/CharSequence;Z)Z

    move-result v1

    if-nez v1, :cond_1

    .line 213
    const-string v1, "2067"

    const/4 v2, 0x0

    const/4 v3, 0x2

    const/4 v4, 0x0

    invoke-static {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_1

    .line 214
    const-string v1, "1555"

    invoke-static {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    goto :goto_0

    .line 217
    :cond_0
    throw p1

    :cond_1
    :goto_0
    return-void

    .line 210
    :cond_2
    throw p1
.end method


# virtual methods
.method public final upsert(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Iterable;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "Ljava/lang/Iterable<",
            "+TT;>;)V"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-nez p2, :cond_0

    goto :goto_1

    .line 241
    :cond_0
    invoke-interface {p2}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object p2

    :goto_0
    invoke-interface {p2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {p2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    .line 75
    :try_start_0
    iget-object v1, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v1, p1, v0}, Landroidx/room/EntityInsertAdapter;->insert(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)V
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v1

    .line 77
    invoke-direct {p0, v1}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 78
    iget-object v1, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v1, p1, v0}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    goto :goto_0

    :cond_1
    :goto_1
    return-void
.end method

.method public final upsert(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "TT;)V"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 46
    :try_start_0
    iget-object v0, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v0, p1, p2}, Landroidx/room/EntityInsertAdapter;->insert(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)V
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception v0

    .line 48
    invoke-direct {p0, v0}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 49
    iget-object v0, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v0, p1, p2}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    return-void
.end method

.method public final upsert(Landroidx/sqlite/SQLiteConnection;[Ljava/lang/Object;)V
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "[TT;)V"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-nez p2, :cond_0

    goto :goto_2

    .line 239
    :cond_0
    array-length v0, p2

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_1

    aget-object v2, p2, v1

    .line 63
    :try_start_0
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v3, p1, v2}, Landroidx/room/EntityInsertAdapter;->insert(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)V
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v3

    .line 65
    invoke-direct {p0, v3}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 66
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v3, p1, v2}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    :goto_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_1
    :goto_2
    return-void
.end method

.method public final upsertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "TT;)J"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 92
    :try_start_0
    iget-object v0, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v0, p1, p2}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide p1
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    return-wide p1

    :catch_0
    move-exception v0

    .line 94
    invoke-direct {p0, v0}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 95
    iget-object v0, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v0, p1, p2}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 p1, -0x1

    return-wide p1
.end method

.method public final upsertAndReturnIdsArray(Landroidx/sqlite/SQLiteConnection;Ljava/util/Collection;)[J
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "Ljava/util/Collection<",
            "+TT;>;)[J"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    if-nez p2, :cond_0

    .line 124
    new-array p1, v0, [J

    return-object p1

    .line 125
    :cond_0
    invoke-interface {p2}, Ljava/util/Collection;->size()I

    move-result v1

    new-array v2, v1, [J

    :goto_0
    if-ge v0, v1, :cond_1

    .line 127
    :try_start_0
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    move-object v4, p2

    check-cast v4, Ljava/lang/Iterable;

    invoke-static {v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->elementAt(Ljava/lang/Iterable;I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v3
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v3

    .line 129
    invoke-direct {p0, v3}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 130
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    move-object v4, p2

    check-cast v4, Ljava/lang/Iterable;

    invoke-static {v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->elementAt(Ljava/lang/Iterable;I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v3, -0x1

    .line 131
    :goto_1
    aput-wide v3, v2, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-object v2
.end method

.method public final upsertAndReturnIdsArray(Landroidx/sqlite/SQLiteConnection;[Ljava/lang/Object;)[J
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "[TT;)[J"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    if-nez p2, :cond_0

    .line 108
    new-array p1, v0, [J

    return-object p1

    .line 109
    :cond_0
    array-length v1, p2

    new-array v2, v1, [J

    :goto_0
    if-ge v0, v1, :cond_1

    .line 111
    :try_start_0
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    aget-object v4, p2, v0

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v3
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v3

    .line 113
    invoke-direct {p0, v3}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 114
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    aget-object v4, p2, v0

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v3, -0x1

    .line 115
    :goto_1
    aput-wide v3, v2, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-object v2
.end method

.method public final upsertAndReturnIdsArrayBox(Landroidx/sqlite/SQLiteConnection;Ljava/util/Collection;)[Ljava/lang/Long;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "Ljava/util/Collection<",
            "+TT;>;)[",
            "Ljava/lang/Long;"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    if-nez p2, :cond_0

    .line 189
    new-array p1, v0, [Ljava/lang/Long;

    return-object p1

    .line 190
    :cond_0
    invoke-interface {p2}, Ljava/util/Collection;->size()I

    move-result v1

    new-array v2, v1, [Ljava/lang/Long;

    :goto_0
    if-ge v0, v1, :cond_1

    .line 192
    :try_start_0
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    move-object v4, p2

    check-cast v4, Ljava/lang/Iterable;

    invoke-static {v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->elementAt(Ljava/lang/Iterable;I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v3
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v3

    .line 194
    invoke-direct {p0, v3}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 195
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    move-object v4, p2

    check-cast v4, Ljava/lang/Iterable;

    invoke-static {v4, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->elementAt(Ljava/lang/Iterable;I)Ljava/lang/Object;

    move-result-object v4

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v3, -0x1

    .line 196
    :goto_1
    invoke-static {v3, v4}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    aput-object v3, v2, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-object v2
.end method

.method public final upsertAndReturnIdsArrayBox(Landroidx/sqlite/SQLiteConnection;[Ljava/lang/Object;)[Ljava/lang/Long;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "[TT;)[",
            "Ljava/lang/Long;"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    if-nez p2, :cond_0

    .line 173
    new-array p1, v0, [Ljava/lang/Long;

    return-object p1

    .line 174
    :cond_0
    array-length v1, p2

    new-array v2, v1, [Ljava/lang/Long;

    :goto_0
    if-ge v0, v1, :cond_1

    .line 176
    :try_start_0
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    aget-object v4, p2, v0

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v3
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v3

    .line 178
    invoke-direct {p0, v3}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 179
    iget-object v3, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    aget-object v4, p2, v0

    invoke-virtual {v3, p1, v4}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v3, -0x1

    .line 180
    :goto_1
    invoke-static {v3, v4}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    aput-object v3, v2, v0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-object v2
.end method

.method public final upsertAndReturnIdsList(Landroidx/sqlite/SQLiteConnection;Ljava/util/Collection;)Ljava/util/List;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "Ljava/util/Collection<",
            "+TT;>;)",
            "Ljava/util/List<",
            "Ljava/lang/Long;",
            ">;"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-nez p2, :cond_0

    .line 155
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p1

    return-object p1

    .line 156
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->createListBuilder()Ljava/util/List;

    move-result-object v0

    .line 157
    check-cast p2, Ljava/lang/Iterable;

    .line 245
    invoke-interface {p2}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object p2

    :goto_0
    invoke-interface {p2}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {p2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    .line 159
    :try_start_0
    iget-object v2, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v2, p1, v1}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v2

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v2

    .line 161
    invoke-direct {p0, v2}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 162
    iget-object v2, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v2, p1, v1}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v1, -0x1

    .line 163
    invoke-static {v1, v2}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 156
    :cond_1
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->build(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    return-object p1
.end method

.method public final upsertAndReturnIdsList(Landroidx/sqlite/SQLiteConnection;[Ljava/lang/Object;)Ljava/util/List;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/sqlite/SQLiteConnection;",
            "[TT;)",
            "Ljava/util/List<",
            "Ljava/lang/Long;",
            ">;"
        }
    .end annotation

    const-string v0, "connection"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-nez p2, :cond_0

    .line 137
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p1

    return-object p1

    .line 138
    :cond_0
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->createListBuilder()Ljava/util/List;

    move-result-object v0

    .line 243
    array-length v1, p2

    const/4 v2, 0x0

    :goto_0
    if-ge v2, v1, :cond_1

    aget-object v3, p2, v2

    .line 141
    :try_start_0
    iget-object v4, p0, Landroidx/room/EntityUpsertAdapter;->entityInsertAdapter:Landroidx/room/EntityInsertAdapter;

    invoke-virtual {v4, p1, v3}, Landroidx/room/EntityInsertAdapter;->insertAndReturnId(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    invoke-interface {v0, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catch Landroid/database/SQLException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    :catch_0
    move-exception v4

    .line 143
    invoke-direct {p0, v4}, Landroidx/room/EntityUpsertAdapter;->checkUniquenessException(Landroid/database/SQLException;)V

    .line 144
    iget-object v4, p0, Landroidx/room/EntityUpsertAdapter;->updateAdapter:Landroidx/room/EntityDeleteOrUpdateAdapter;

    invoke-virtual {v4, p1, v3}, Landroidx/room/EntityDeleteOrUpdateAdapter;->handle(Landroidx/sqlite/SQLiteConnection;Ljava/lang/Object;)I

    const-wide/16 v3, -0x1

    .line 145
    invoke-static {v3, v4}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    invoke-interface {v0, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :goto_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 138
    :cond_1
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->build(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    return-object p1
.end method
