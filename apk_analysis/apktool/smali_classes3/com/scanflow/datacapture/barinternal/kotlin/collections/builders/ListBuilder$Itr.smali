.class final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;
.super Ljava/lang/Object;
.source "ListBuilder.kt"

# interfaces
.implements Ljava/util/ListIterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "Itr"
.end annotation


# instance fields
.field private expectedModCount:I

.field private index:I

.field private lastIndex:I

.field private final list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;I)V
    .locals 1

    const-string v0, "list"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 253
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 254
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    .line 255
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    const/4 p2, -0x1

    .line 257
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    .line 258
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->expectedModCount:I

    return-void
.end method

.method private final checkForComodification()V
    .locals 2

    .line 303
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->expectedModCount:I

    if-ne v0, v1, :cond_0

    return-void

    .line 304
    :cond_0
    new-instance v0, Ljava/util/ConcurrentModificationException;

    invoke-direct {v0}, Ljava/util/ConcurrentModificationException;-><init>()V

    throw v0
.end method


# virtual methods
.method public add(Ljava/lang/Object;)V
    .locals 3

    .line 287
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->checkForComodification()V

    .line 288
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    invoke-virtual {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->add(ILjava/lang/Object;)V

    const/4 p1, -0x1

    .line 289
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    .line 290
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result p1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->expectedModCount:I

    return-void
.end method

.method public hasNext()Z
    .locals 2

    .line 261
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPrevious()Z
    .locals 1

    .line 260
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    if-lez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 2

    .line 274
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->checkForComodification()V

    .line 275
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 276
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    add-int/lit8 v1, v0, 0x1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    .line 277
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)[Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    aget-object v0, v0, v1

    return-object v0

    .line 275
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public nextIndex()I
    .locals 1

    .line 264
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    return v0
.end method

.method public previous()Ljava/lang/Object;
    .locals 2

    .line 267
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->checkForComodification()V

    .line 268
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    if-lez v0, :cond_0

    add-int/lit8 v0, v0, -0x1

    .line 269
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    .line 270
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)[Ljava/lang/Object;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    aget-object v0, v0, v1

    return-object v0

    .line 268
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public previousIndex()I
    .locals 1

    .line 263
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    add-int/lit8 v0, v0, -0x1

    return v0
.end method

.method public remove()V
    .locals 3

    .line 294
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->checkForComodification()V

    .line 295
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    .line 296
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->removeAt(I)Ljava/lang/Object;

    .line 297
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->index:I

    .line 298
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    .line 299
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v0

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->expectedModCount:I

    return-void

    .line 295
    :cond_0
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Call next() or previous() before removing element from the iterator."

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public set(Ljava/lang/Object;)V
    .locals 2

    .line 281
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->checkForComodification()V

    .line 282
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->lastIndex:I

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    .line 283
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$Itr;->list:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-virtual {v1, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->set(ILjava/lang/Object;)Ljava/lang/Object;

    return-void

    .line 282
    :cond_0
    new-instance p1, Ljava/lang/IllegalStateException;

    const-string v0, "Call next() or previous() before replacing element from the iterator."

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method
