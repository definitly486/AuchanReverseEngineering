.class public final Landroidx/collection/MutableEntries$iterator$1;
.super Ljava/lang/Object;
.source "ScatterMap.kt"

# interfaces
.implements Ljava/util/Iterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/collection/MutableEntries;->iterator()Ljava/util/Iterator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field private current:I

.field private iterator:Ljava/util/Iterator;

.field final synthetic this$0:Landroidx/collection/MutableEntries;


# direct methods
.method constructor <init>(Landroidx/collection/MutableEntries;)V
    .locals 2

    iput-object p1, p0, Landroidx/collection/MutableEntries$iterator$1;->this$0:Landroidx/collection/MutableEntries;

    .line 1530
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, -0x1

    .line 1532
    iput v0, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    .line 1535
    new-instance v0, Landroidx/collection/MutableEntries$iterator$1$1;

    const/4 v1, 0x0

    invoke-direct {v0, p1, p0, v1}, Landroidx/collection/MutableEntries$iterator$1$1;-><init>(Landroidx/collection/MutableEntries;Landroidx/collection/MutableEntries$iterator$1;Lkotlin/coroutines/Continuation;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt;->iterator(Lkotlin/jvm/functions/Function2;)Ljava/util/Iterator;

    move-result-object p1

    iput-object p1, p0, Landroidx/collection/MutableEntries$iterator$1;->iterator:Ljava/util/Iterator;

    return-void
.end method


# virtual methods
.method public final getCurrent()I
    .locals 1

    .line 1532
    iget v0, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    return v0
.end method

.method public hasNext()Z
    .locals 1

    .line 1543
    iget-object v0, p0, Landroidx/collection/MutableEntries$iterator$1;->iterator:Ljava/util/Iterator;

    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    return v0
.end method

.method public bridge synthetic next()Ljava/lang/Object;
    .locals 1

    .line 1530
    invoke-virtual {p0}, Landroidx/collection/MutableEntries$iterator$1;->next()Ljava/util/Map$Entry;

    move-result-object v0

    return-object v0
.end method

.method public next()Ljava/util/Map$Entry;
    .locals 1

    .line 1545
    iget-object v0, p0, Landroidx/collection/MutableEntries$iterator$1;->iterator:Ljava/util/Iterator;

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    return-object v0
.end method

.method public remove()V
    .locals 3

    .line 1548
    iget v0, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    .line 1549
    iget-object v0, p0, Landroidx/collection/MutableEntries$iterator$1;->this$0:Landroidx/collection/MutableEntries;

    invoke-static {v0}, Landroidx/collection/MutableEntries;->access$getParent$p(Landroidx/collection/MutableEntries;)Landroidx/collection/MutableScatterMap;

    move-result-object v0

    iget v2, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    invoke-virtual {v0, v2}, Landroidx/collection/MutableScatterMap;->removeValueAt(I)Ljava/lang/Object;

    .line 1550
    iput v1, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    :cond_0
    return-void
.end method

.method public final setCurrent(I)V
    .locals 0

    .line 1532
    iput p1, p0, Landroidx/collection/MutableEntries$iterator$1;->current:I

    return-void
.end method
