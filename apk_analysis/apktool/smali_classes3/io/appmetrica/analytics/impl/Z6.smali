.class public final Lio/appmetrica/analytics/impl/Z6;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field public final a:Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;


# direct methods
.method public constructor <init>(Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 2
    iput-object p1, p0, Lio/appmetrica/analytics/impl/Z6;->a:Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;

    return-void
.end method


# virtual methods
.method public final a(Landroid/database/sqlite/SQLiteDatabase;Ljava/lang/String;[Ljava/lang/String;ILjava/lang/String;Z)Lio/appmetrica/analytics/impl/X6;
    .locals 14

    move-object/from16 v1, p5

    const-string v3, "events"

    const/4 v10, 0x0

    .line 1
    :try_start_0
    const-string v0, "global_number"

    const-string v2, "type"

    const-string v4, "event_description"

    filled-new-array {v0, v2, v4}, [Ljava/lang/String;

    move-result-object v4

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v7, 0x0

    move-object v2, p1

    move-object/from16 v5, p2

    move-object/from16 v6, p3

    invoke-virtual/range {v2 .. v9}, Landroid/database/sqlite/SQLiteDatabase;->query(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v4
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    if-eqz v4, :cond_0

    .line 2
    :try_start_1
    invoke-interface {v4}, Landroid/database/Cursor;->getCount()I

    move-result v0

    if-lez v0, :cond_0

    .line 3
    new-instance v0, Ljava/util/ArrayList;

    invoke-interface {v4}, Landroid/database/Cursor;->getCount()I

    move-result v2

    invoke-direct {v0, v2}, Ljava/util/ArrayList;-><init>(I)V

    .line 4
    :goto_0
    invoke-interface {v4}, Landroid/database/Cursor;->moveToNext()Z

    move-result v2

    if-eqz v2, :cond_1

    .line 5
    new-instance v2, Landroid/content/ContentValues;

    invoke-direct {v2}, Landroid/content/ContentValues;-><init>()V

    .line 6
    invoke-static {v4, v2}, Landroid/database/DatabaseUtils;->cursorRowToContentValues(Landroid/database/Cursor;Landroid/content/ContentValues;)V

    .line 7
    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    :cond_0
    move-object v0, v10

    .line 8
    :cond_1
    invoke-static {v4}, Lio/appmetrica/analytics/impl/Do;->a(Landroid/database/Cursor;)V

    goto :goto_2

    :catchall_1
    move-exception v0

    move-object v4, v10

    .line 9
    :goto_1
    :try_start_2
    sget-object v2, Lio/appmetrica/analytics/impl/Dj;->a:Lio/appmetrica/analytics/impl/fk;

    .line 10
    const-string v5, "select_rows_to_delete_exception"

    invoke-virtual {v2}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 11
    new-instance v6, Lio/appmetrica/analytics/impl/Ej;

    invoke-direct {v6, v5, v0}, Lio/appmetrica/analytics/impl/Ej;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    invoke-virtual {v2, v6}, Lio/appmetrica/analytics/impl/fk;->a(Lio/appmetrica/analytics/impl/lb;)V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_6

    .line 12
    invoke-static {v4}, Lio/appmetrica/analytics/impl/Do;->a(Landroid/database/Cursor;)V

    move-object v0, v10

    :goto_2
    const/4 v2, 0x0

    move-object/from16 v5, p2

    move-object/from16 v6, p3

    .line 13
    :try_start_3
    invoke-virtual {p1, v3, v5, v6}, Landroid/database/sqlite/SQLiteDatabase;->delete(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)I

    move-result v3
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_2

    goto :goto_3

    :catchall_2
    move v3, v2

    :goto_3
    if-eqz v0, :cond_7

    .line 14
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v4

    if-eqz v4, :cond_7

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v4

    if-eq v3, v4, :cond_2

    goto/16 :goto_9

    :cond_2
    if-eqz p6, :cond_7

    .line 15
    sget-object v4, Lio/appmetrica/analytics/impl/Ka;->I:Lio/appmetrica/analytics/impl/Ka;

    .line 16
    iget-object v4, v4, Lio/appmetrica/analytics/impl/Ka;->f:Lio/appmetrica/analytics/impl/Bj;

    if-eqz v1, :cond_7

    if-eqz v4, :cond_7

    .line 17
    iget-object v6, p0, Lio/appmetrica/analytics/impl/Z6;->a:Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;

    .line 18
    monitor-enter v4

    .line 19
    :try_start_4
    iget-object v7, v4, Lio/appmetrica/analytics/impl/Bj;->c:Ljava/util/HashMap;

    invoke-virtual {v7, v1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lio/appmetrica/analytics/impl/zj;

    if-nez v7, :cond_3

    .line 21
    new-instance v7, Lio/appmetrica/analytics/impl/zj;

    iget-object v8, v4, Lio/appmetrica/analytics/impl/Bj;->b:Landroid/content/Context;

    iget-object v9, v4, Lio/appmetrica/analytics/impl/Bj;->a:Lio/appmetrica/analytics/impl/Cj;

    invoke-direct {v7, v1, v8, v6, v9}, Lio/appmetrica/analytics/impl/zj;-><init>(Ljava/lang/String;Landroid/content/Context;Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;Lio/appmetrica/analytics/impl/Cj;)V

    .line 27
    iget-object v6, v4, Lio/appmetrica/analytics/impl/Bj;->c:Ljava/util/HashMap;

    invoke-virtual {v6, v1, v7}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_3

    goto :goto_4

    :catchall_3
    move-exception v0

    goto/16 :goto_8

    .line 28
    :cond_3
    :goto_4
    monitor-exit v4

    .line 29
    :try_start_5
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4}, Lorg/json/JSONObject;-><init>()V

    .line 30
    new-instance v6, Lorg/json/JSONArray;

    invoke-direct {v6}, Lorg/json/JSONArray;-><init>()V

    .line 31
    new-instance v8, Lorg/json/JSONArray;

    invoke-direct {v8}, Lorg/json/JSONArray;-><init>()V

    .line 32
    invoke-virtual {v0}, Ljava/util/ArrayList;->size()I

    move-result v9

    :cond_4
    :goto_5
    if-ge v2, v9, :cond_6

    invoke-virtual {v0, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v11

    add-int/lit8 v2, v2, 0x1

    check-cast v11, Landroid/content/ContentValues;

    .line 33
    const-string v12, "global_number"

    .line 34
    invoke-virtual {v11, v12}, Landroid/content/ContentValues;->getAsInteger(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v12

    .line 35
    const-string v13, "type"

    .line 36
    invoke-virtual {v11, v13}, Landroid/content/ContentValues;->getAsInteger(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v11

    if-eqz v12, :cond_4

    if-eqz v11, :cond_4

    .line 38
    invoke-virtual {v6, v12}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    .line 40
    invoke-virtual {v11}, Ljava/lang/Integer;->intValue()I

    move-result v11

    invoke-static {v11}, Lio/appmetrica/analytics/impl/xb;->a(I)Lio/appmetrica/analytics/impl/xb;

    move-result-object v11

    if-nez v11, :cond_5

    .line 41
    sget-object v11, Lio/appmetrica/analytics/impl/kg;->a:Ljava/util/Map;

    move-object v11, v10

    goto :goto_6

    .line 42
    :cond_5
    sget-object v12, Lio/appmetrica/analytics/impl/kg;->c:Ljava/util/Map;

    invoke-interface {v12, v11}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Ljava/lang/Integer;

    .line 43
    :goto_6
    invoke-virtual {v8, v11}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    goto :goto_5

    .line 56
    :cond_6
    const-string v2, "global_number"

    invoke-virtual {v4, v2, v6}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    move-result-object v2

    const-string v6, "event_type"

    .line 57
    invoke-virtual {v2, v6, v8}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 58
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2}, Lorg/json/JSONObject;-><init>()V

    const-string v6, "reason"

    .line 59
    invoke-static/range {p4 .. p4}, Lio/appmetrica/analytics/impl/Y6;->a(I)Ljava/lang/String;

    move-result-object v8

    .line 60
    invoke-virtual {v2, v6, v8}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    move-result-object v2

    const-string v6, "cleared"

    .line 61
    invoke-virtual {v2, v6, v4}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    move-result-object v2

    const-string v4, "actual_deleted_number"

    .line 62
    invoke-virtual {v2, v4, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;I)Lorg/json/JSONObject;

    move-result-object v2

    .line 63
    new-instance v4, Lorg/json/JSONObject;

    invoke-direct {v4}, Lorg/json/JSONObject;-><init>()V

    const-string v6, "details"

    invoke-virtual {v4, v6, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    move-result-object v2

    .line 64
    invoke-static {v1}, Lio/appmetrica/analytics/coreutils/internal/logger/LoggerStorage;->getOrCreatePublicLogger(Ljava/lang/String;)Lio/appmetrica/analytics/logger/appmetrica/internal/PublicLogger;

    move-result-object v1

    .line 65
    invoke-virtual {v2}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v2

    sget-object v4, Lio/appmetrica/analytics/impl/Q9;->a:Ljava/util/Set;

    .line 66
    new-instance v4, Lio/appmetrica/analytics/impl/d4;

    const-string v6, ""

    sget-object v8, Lio/appmetrica/analytics/impl/xb;->c:Lio/appmetrica/analytics/impl/xb;

    const/16 v8, 0x3002

    const/4 v9, 0x0

    move-object/from16 p6, v1

    move-object/from16 p2, v2

    move-object p1, v4

    move-object/from16 p3, v6

    move/from16 p4, v8

    move/from16 p5, v9

    .line 67
    invoke-direct/range {p1 .. p6}, Lio/appmetrica/analytics/impl/d4;-><init>(Ljava/lang/String;Ljava/lang/String;IILio/appmetrica/analytics/logger/appmetrica/internal/PublicLogger;)V
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_4

    goto :goto_7

    :catchall_4
    move-object v4, v10

    :goto_7
    if-eqz v4, :cond_7

    .line 68
    iget-object v1, v7, Lio/appmetrica/analytics/impl/zj;->c:Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;

    if-eqz v1, :cond_7

    .line 70
    :try_start_6
    new-instance v1, Lio/appmetrica/analytics/internal/CounterConfiguration;

    iget-object v2, v7, Lio/appmetrica/analytics/impl/zj;->a:Ljava/lang/String;

    invoke-direct {v1, v2}, Lio/appmetrica/analytics/internal/CounterConfiguration;-><init>(Ljava/lang/String;)V

    .line 71
    iget-object v2, v7, Lio/appmetrica/analytics/impl/zj;->c:Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;

    invoke-virtual {v1, v2}, Lio/appmetrica/analytics/internal/CounterConfiguration;->setReporterType(Lio/appmetrica/analytics/internal/CounterConfigurationReporterType;)V

    .line 72
    iget-object v2, v7, Lio/appmetrica/analytics/impl/zj;->d:Lio/appmetrica/analytics/impl/Cj;

    new-instance v6, Lio/appmetrica/analytics/impl/Sh;

    new-instance v8, Lio/appmetrica/analytics/impl/Wf;

    iget-object v9, v7, Lio/appmetrica/analytics/impl/zj;->b:Landroid/content/Context;

    invoke-direct {v8, v9, v10}, Lio/appmetrica/analytics/impl/Wf;-><init>(Landroid/content/Context;Landroid/os/ResultReceiver;)V

    new-instance v9, Lio/appmetrica/analytics/impl/W8;

    new-instance v11, Lio/appmetrica/analytics/impl/Ll;

    iget-object v7, v7, Lio/appmetrica/analytics/impl/zj;->a:Ljava/lang/String;

    .line 80
    invoke-static {v7}, Lio/appmetrica/analytics/coreutils/internal/logger/LoggerStorage;->getOrCreatePublicLogger(Ljava/lang/String;)Lio/appmetrica/analytics/logger/appmetrica/internal/PublicLogger;

    move-result-object v7

    const-string v12, "Crash Environment"

    invoke-direct {v11, v7, v12}, Lio/appmetrica/analytics/impl/Ll;-><init>(Lio/appmetrica/analytics/logger/appmetrica/internal/PublicLogger;Ljava/lang/String;)V

    invoke-direct {v9, v11}, Lio/appmetrica/analytics/impl/W8;-><init>(Lio/appmetrica/analytics/impl/Ll;)V

    invoke-direct {v6, v8, v1, v9, v10}, Lio/appmetrica/analytics/impl/Sh;-><init>(Lio/appmetrica/analytics/impl/Wf;Lio/appmetrica/analytics/internal/CounterConfiguration;Lio/appmetrica/analytics/impl/W8;Ljava/lang/String;)V

    .line 85
    invoke-virtual {v6}, Lio/appmetrica/analytics/impl/Sh;->c()Landroid/os/Bundle;

    move-result-object v1

    .line 86
    invoke-virtual {v4, v1}, Lio/appmetrica/analytics/impl/f6;->d(Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v1

    .line 87
    iget-object v2, v2, Lio/appmetrica/analytics/impl/Cj;->a:Lio/appmetrica/analytics/impl/C1;

    const/4 v4, 0x1

    .line 88
    invoke-interface {v2, v4, v1}, Lio/appmetrica/analytics/impl/C1;->reportData(ILandroid/os/Bundle;)V
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_5

    goto :goto_9

    .line 89
    :goto_8
    monitor-exit v4

    throw v0

    .line 90
    :catchall_5
    :cond_7
    :goto_9
    new-instance v1, Lio/appmetrica/analytics/impl/X6;

    invoke-direct {v1, v0, v3}, Lio/appmetrica/analytics/impl/X6;-><init>(Ljava/util/ArrayList;I)V

    return-object v1

    :catchall_6
    move-exception v0

    .line 91
    invoke-static {v4}, Lio/appmetrica/analytics/impl/Do;->a(Landroid/database/Cursor;)V

    .line 92
    throw v0
.end method
