.class public final Landroidx/collection/MutableValues$iterator$1;
.super Ljava/lang/Object;
.source "ScatterMap.kt"

# interfaces
.implements Ljava/util/Iterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/collection/MutableValues;->iterator()Ljava/util/Iterator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field private current:I

.field private final iterator:Ljava/util/Iterator;

.field final synthetic this$0:Landroidx/collection/MutableValues;


# direct methods
.method constructor <init>(Landroidx/collection/MutableValues;)V
    .locals 2

    iput-object p1, p0, Landroidx/collection/MutableValues$iterator$1;->this$0:Landroidx/collection/MutableValues;

    .line 1695
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 1696
    new-instance v0, Landroidx/collection/MutableValues$iterator$1$iterator$1;

    const/4 v1, 0x0

    invoke-direct {v0, p1, v1}, Landroidx/collection/MutableValues$iterator$1$iterator$1;-><init>(Landroidx/collection/MutableValues;Lkotlin/coroutines/Continuation;)V

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/SequencesKt;->iterator(Lkotlin/jvm/functions/Function2;)Ljava/util/Iterator;

    move-result-object p1

    iput-object p1, p0, Landroidx/collection/MutableValues$iterator$1;->iterator:Ljava/util/Iterator;

    const/4 p1, -0x1

    .line 1697
    iput p1, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    return-void
.end method


# virtual methods
.method public hasNext()Z
    .locals 1

    .line 1699
    iget-object v0, p0, Landroidx/collection/MutableValues$iterator$1;->iterator:Ljava/util/Iterator;

    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 2

    .line 1702
    iget-object v0, p0, Landroidx/collection/MutableValues$iterator$1;->iterator:Ljava/util/Iterator;

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result v0

    iput v0, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    .line 1703
    iget-object v0, p0, Landroidx/collection/MutableValues$iterator$1;->this$0:Landroidx/collection/MutableValues;

    invoke-static {v0}, Landroidx/collection/MutableValues;->access$getParent$p(Landroidx/collection/MutableValues;)Landroidx/collection/MutableScatterMap;

    move-result-object v0

    iget-object v0, v0, Landroidx/collection/ScatterMap;->values:[Ljava/lang/Object;

    iget v1, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method public remove()V
    .locals 2

    .line 1707
    iget v0, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    if-ltz v0, :cond_0

    .line 1708
    iget-object v0, p0, Landroidx/collection/MutableValues$iterator$1;->this$0:Landroidx/collection/MutableValues;

    invoke-static {v0}, Landroidx/collection/MutableValues;->access$getParent$p(Landroidx/collection/MutableValues;)Landroidx/collection/MutableScatterMap;

    move-result-object v0

    iget v1, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    invoke-virtual {v0, v1}, Landroidx/collection/MutableScatterMap;->removeValueAt(I)Ljava/lang/Object;

    const/4 v0, -0x1

    .line 1709
    iput v0, p0, Landroidx/collection/MutableValues$iterator$1;->current:I

    :cond_0
    return-void
.end method
