.class public Lcom/scanflow/ui/ar/ArObjectTracker;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;
    }
.end annotation


# instance fields
.field private pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

.field private final trackingListeners:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    return-void
.end method


# virtual methods
.method public final addTrackingListener(Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;)Lcom/scanflow/ui/ar/ArObjectTracker;
    .locals 1

    .line 1
    const-string v0, "listener"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-object p0
.end method

.method public final addTrackingListener(Lkotlin/jvm/functions/Function1;)Lcom/scanflow/ui/ar/ArObjectTracker;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Lcom/scanflow/ui/ar/ArObject;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Lcom/scanflow/ui/ar/ArObjectTracker;"
        }
    .end annotation

    .line 2
    const-string v0, "listener"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/ui/ar/ArObjectTracker$addTrackingListener$1;

    invoke-direct {v0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker$addTrackingListener$1;-><init>(Lkotlin/jvm/functions/Function1;)V

    invoke-virtual {p0, v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->addTrackingListener(Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;)Lcom/scanflow/ui/ar/ArObjectTracker;

    return-object p0
.end method

.method public final clearListenersAndPipe()V
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/scanflow/ui/ar/ArObjectTracker;->clearListenersAndPipe()V

    :cond_0
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

    return-void
.end method

.method public final pipe(Lcom/scanflow/ui/ar/ArObjectTracker;)Lcom/scanflow/ui/ar/ArObjectTracker;
    .locals 1

    .line 0
    const-string v0, "otherTracker"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

    return-object p1
.end method

.method public processObject(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 0

    .line 1
    invoke-virtual {p0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker;->publish(Lcom/scanflow/ui/ar/ArObject;)V

    return-void
.end method

.method public processObject(Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;)V"
        }
    .end annotation

    .line 2
    const-string v0, "arObject"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker;->publish(Ljava/util/ArrayList;)V

    return-void
.end method

.method public final publish(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 2

    .line 1
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Lcom/scanflow/ui/ar/ArObject;)V

    :cond_0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    invoke-interface {v0}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;

    invoke-interface {v1, p1}, Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;->onObjectTracked(Lcom/scanflow/ui/ar/ArObject;)V

    goto :goto_0

    :cond_1
    return-void
.end method

.method public final publish(Ljava/util/ArrayList;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;)V"
        }
    .end annotation

    .line 2
    const-string v0, "arObject"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->pipedTracked:Lcom/scanflow/ui/ar/ArObjectTracker;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1}, Lcom/scanflow/ui/ar/ArObjectTracker;->processObject(Ljava/util/ArrayList;)V

    :cond_0
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    invoke-interface {v0}, Ljava/lang/Iterable;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;

    invoke-interface {v1, p1}, Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;->onObjectTracked(Ljava/util/ArrayList;)V

    goto :goto_0

    :cond_1
    return-void
.end method

.method public final removeTrackingListener(Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;)Z
    .locals 1

    .line 0
    const-string v0, "listener"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker;->trackingListeners:Ljava/util/List;

    invoke-interface {v0, p1}, Ljava/util/List;->remove(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method
