.class public final Lio/appmetrica/analytics/impl/y1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic a:Landroid/content/Context;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 0

    .line 1
    iput-object p1, p0, Lio/appmetrica/analytics/impl/y1;->a:Landroid/content/Context;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 6

    .line 1
    sget-object v0, Lio/appmetrica/analytics/impl/Dj;->a:Lio/appmetrica/analytics/impl/fk;

    .line 2
    iget-object v1, p0, Lio/appmetrica/analytics/impl/y1;->a:Landroid/content/Context;

    monitor-enter v0

    .line 3
    :try_start_0
    iget-object v2, v0, Lio/appmetrica/analytics/impl/fk;->b:Lio/appmetrica/analytics/impl/ti;

    if-nez v2, :cond_1

    .line 4
    sget-object v2, Lio/appmetrica/analytics/impl/Ai;->a:Lio/appmetrica/analytics/impl/Bi;

    .line 5
    const-string v3, "20799a27-fa80-4b36-b2db-0f8141f24180"

    invoke-virtual {v2, v1, v3}, Lio/appmetrica/analytics/impl/Bi;->a(Landroid/content/Context;Ljava/lang/String;)Lio/appmetrica/analytics/impl/ti;

    move-result-object v1

    iput-object v1, v0, Lio/appmetrica/analytics/impl/fk;->b:Lio/appmetrica/analytics/impl/ti;

    .line 6
    iget-object v1, v0, Lio/appmetrica/analytics/impl/fk;->a:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v2

    const/4 v3, 0x0

    :goto_0
    if-ge v3, v2, :cond_0

    invoke-virtual {v1, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v3, v3, 0x1

    check-cast v4, Lio/appmetrica/analytics/impl/lb;

    .line 7
    iget-object v5, v0, Lio/appmetrica/analytics/impl/fk;->b:Lio/appmetrica/analytics/impl/ti;

    invoke-interface {v4, v5}, Lio/appmetrica/analytics/impl/lb;->a(Lio/appmetrica/analytics/impl/mb;)V

    goto :goto_0

    :catchall_0
    move-exception v1

    goto :goto_1

    .line 9
    :cond_0
    iget-object v1, v0, Lio/appmetrica/analytics/impl/fk;->a:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->clear()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 10
    :cond_1
    monitor-exit v0

    return-void

    .line 11
    :goto_1
    monitor-exit v0

    throw v1
.end method
