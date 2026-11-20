.class public final Lio/appmetrica/analytics/impl/a3;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lio/appmetrica/analytics/coreapi/internal/backport/BiConsumer;


# instance fields
.field public final synthetic a:Lio/appmetrica/analytics/impl/b3;


# direct methods
.method public constructor <init>(Lio/appmetrica/analytics/impl/b3;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/impl/a3;->a:Lio/appmetrica/analytics/impl/b3;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final consume(Ljava/lang/Object;Ljava/lang/Object;)V
    .locals 4

    .line 1
    check-cast p1, Landroid/content/Context;

    check-cast p2, Landroid/content/Intent;

    .line 2
    iget-object p1, p0, Lio/appmetrica/analytics/impl/a3;->a:Lio/appmetrica/analytics/impl/b3;

    monitor-enter p1

    .line 3
    :try_start_0
    iget-object v0, p0, Lio/appmetrica/analytics/impl/a3;->a:Lio/appmetrica/analytics/impl/b3;

    .line 4
    iput-object p2, v0, Lio/appmetrica/analytics/impl/b3;->b:Landroid/content/Intent;

    .line 5
    iget-object v0, v0, Lio/appmetrica/analytics/impl/b3;->a:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v2, 0x0

    :goto_0
    if-ge v2, v1, :cond_0

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    add-int/lit8 v2, v2, 0x1

    check-cast v3, Lio/appmetrica/analytics/coreapi/internal/backport/Consumer;

    .line 6
    invoke-interface {v3, p2}, Lio/appmetrica/analytics/coreapi/internal/backport/Consumer;->consume(Ljava/lang/Object;)V

    goto :goto_0

    :catchall_0
    move-exception p2

    goto :goto_1

    .line 7
    :cond_0
    monitor-exit p1

    return-void

    :goto_1
    monitor-exit p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p2
.end method
