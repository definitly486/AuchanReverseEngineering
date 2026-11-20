.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;
.super Ljava/lang/Object;
.source "RecycleStack.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;
    }
.end annotation


# instance fields
.field factory:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;

.field list:Ljava/util/List;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;)V
    .locals 1

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 30
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->list:Ljava/util/List;

    .line 34
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->factory:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;

    return-void
.end method


# virtual methods
.method public declared-synchronized pop()Ljava/lang/Object;
    .locals 2

    monitor-enter p0

    .line 51
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->list:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 52
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->factory:Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack$Factory;->newInstance()Ljava/lang/Object;

    move-result-object v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    goto :goto_0

    .line 54
    :cond_0
    :try_start_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->list:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v1

    add-int/lit8 v1, v1, -0x1

    invoke-interface {v0, v1}, Ljava/util/List;->remove(I)Ljava/lang/Object;

    move-result-object v0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit p0

    return-object v0

    :goto_0
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0
.end method

.method public declared-synchronized recycle(Ljava/lang/Object;)V
    .locals 1

    monitor-enter p0

    .line 64
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/lists/RecycleStack;->list:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 65
    monitor-exit p0

    return-void

    :catchall_0
    move-exception p1

    :try_start_1
    monitor-exit p0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p1
.end method
