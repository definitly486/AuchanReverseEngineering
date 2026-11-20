.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideManager;
.super Ljava/lang/Object;
.source "BOverrideManager.java"


# static fields
.field public static final list:Ljava/util/List;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 31
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideManager;->list:Ljava/util/List;

    return-void
.end method

.method public static declared-synchronized register(Ljava/lang/Class;)V
    .locals 4

    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideManager;

    monitor-enter v0

    .line 34
    :try_start_0
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideClass;

    invoke-virtual {v1, p0}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 35
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideManager;->list:Ljava/util/List;

    invoke-interface {v1, p0}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 39
    monitor-exit v0

    return-void

    :catchall_0
    move-exception p0

    goto :goto_0

    .line 37
    :cond_0
    :try_start_1
    new-instance p0, Ljava/lang/RuntimeException;

    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/override/BOverrideClass;

    invoke-virtual {v1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object v1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Expected a class derived from "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    :goto_0
    monitor-exit v0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p0
.end method
