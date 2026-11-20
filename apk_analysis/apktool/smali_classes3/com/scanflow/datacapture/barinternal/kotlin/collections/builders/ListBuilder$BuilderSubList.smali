.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableList;
.source "ListBuilder.kt"

# interfaces
.implements Ljava/util/List;
.implements Ljava/util/RandomAccess;
.implements Ljava/io/Serializable;
.implements Lcom/scanflow/datacapture/barinternal/kotlin/jvm/internal/markers/KMutableList;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "BuilderSubList"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;
    }
.end annotation


# instance fields
.field private backing:[Ljava/lang/Object;

.field private length:I

.field private final offset:I

.field private final parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

.field private final root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;


# direct methods
.method public constructor <init>([Ljava/lang/Object;IILcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)V
    .locals 1

    const-string v0, "backing"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "root"

    invoke-static {p5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 308
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractMutableList;-><init>()V

    .line 309
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    .line 310
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    .line 311
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    .line 312
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    .line 313
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    .line 316
    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result p1

    iput p1, p0, Ljava/util/AbstractList;->modCount:I

    return-void
.end method

.method public static final synthetic access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)[Ljava/lang/Object;
    .locals 0

    .line 308
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    return-object p0
.end method

.method public static final synthetic access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I
    .locals 0

    .line 308
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return p0
.end method

.method public static final synthetic access$getModCount$p$s1462993667(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I
    .locals 0

    .line 308
    iget p0, p0, Ljava/util/AbstractList;->modCount:I

    return p0
.end method

.method public static final synthetic access$getOffset$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)I
    .locals 0

    .line 308
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    return p0
.end method

.method public static final synthetic access$getRoot$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;)Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;
    .locals 0

    .line 308
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    return-object p0
.end method

.method private final addAllInternal(ILjava/util/Collection;I)V
    .locals 1

    .line 520
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->registerModification()V

    .line 521
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    if-eqz v0, :cond_0

    .line 522
    invoke-direct {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAllInternal(ILjava/util/Collection;I)V

    goto :goto_0

    .line 524
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$addAllInternal(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;ILjava/util/Collection;I)V

    .line 526
    :goto_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)[Ljava/lang/Object;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    .line 527
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/2addr p1, p3

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return-void
.end method

.method private final addAtInternal(ILjava/lang/Object;)V
    .locals 1

    .line 509
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->registerModification()V

    .line 510
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    if-eqz v0, :cond_0

    .line 511
    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAtInternal(ILjava/lang/Object;)V

    goto :goto_0

    .line 513
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$addAtInternal(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;ILjava/lang/Object;)V

    .line 515
    :goto_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getBacking$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)[Ljava/lang/Object;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    .line 516
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return-void
.end method

.method private final checkForComodification()V
    .locals 2

    .line 493
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$getModCount$p$s-2084097795(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)I

    move-result v0

    iget v1, p0, Ljava/util/AbstractList;->modCount:I

    if-ne v0, v1, :cond_0

    return-void

    .line 494
    :cond_0
    new-instance v0, Ljava/util/ConcurrentModificationException;

    invoke-direct {v0}, Ljava/util/ConcurrentModificationException;-><init>()V

    throw v0
.end method

.method private final checkIsMutable()V
    .locals 1

    .line 498
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->isReadOnly()Z

    move-result v0

    if-nez v0, :cond_0

    return-void

    :cond_0
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0
.end method

.method private final contentEquals(Ljava/util/List;)Z
    .locals 3

    .line 505
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-static {v0, v1, v2, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilderKt;->access$subarrayContentEquals([Ljava/lang/Object;IILjava/util/List;)Z

    move-result p1

    return p1
.end method

.method private final isReadOnly()Z
    .locals 1

    .line 502
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$isReadOnly$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)Z

    move-result v0

    return v0
.end method

.method private final registerModification()V
    .locals 1

    .line 489
    iget v0, p0, Ljava/util/AbstractList;->modCount:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Ljava/util/AbstractList;->modCount:I

    return-void
.end method

.method private final removeAtInternal(I)Ljava/lang/Object;
    .locals 1

    .line 531
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->registerModification()V

    .line 532
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    if-eqz v0, :cond_0

    .line 533
    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeAtInternal(I)Ljava/lang/Object;

    move-result-object p1

    goto :goto_0

    .line 535
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$removeAtInternal(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;I)Ljava/lang/Object;

    move-result-object p1

    .line 537
    :goto_0
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/lit8 v0, v0, -0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return-object p1
.end method

.method private final removeRangeInternal(II)V
    .locals 1

    if-lez p2, :cond_0

    .line 542
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->registerModification()V

    .line 543
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    if-eqz v0, :cond_1

    .line 544
    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeRangeInternal(II)V

    goto :goto_0

    .line 546
    :cond_1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$removeRangeInternal(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;II)V

    .line 548
    :goto_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    sub-int/2addr p1, p2

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return-void
.end method

.method private final retainOrRemoveAllInternal(IILjava/util/Collection;Z)I
    .locals 1

    .line 554
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->parent:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    if-eqz v0, :cond_0

    .line 555
    invoke-direct {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->retainOrRemoveAllInternal(IILjava/util/Collection;Z)I

    move-result p1

    goto :goto_0

    .line 557
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    invoke-static {v0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;->access$retainOrRemoveAllInternal(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;IILjava/util/Collection;Z)I

    move-result p1

    :goto_0
    if-lez p1, :cond_1

    .line 559
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->registerModification()V

    .line 560
    :cond_1
    iget p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    sub-int/2addr p2, p1

    iput p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return p1
.end method


# virtual methods
.method public add(ILjava/lang/Object;)V
    .locals 2

    .line 390
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 391
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 392
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkPositionIndex$kotlin_stdlib(II)V

    .line 393
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v0, p1

    invoke-direct {p0, v0, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAtInternal(ILjava/lang/Object;)V

    return-void
.end method

.method public add(Ljava/lang/Object;)Z
    .locals 2

    .line 383
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 384
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 385
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/2addr v0, v1

    invoke-direct {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAtInternal(ILjava/lang/Object;)V

    const/4 p1, 0x1

    return p1
.end method

.method public addAll(ILjava/util/Collection;)Z
    .locals 2

    const-string v0, "elements"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 405
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 406
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 407
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkPositionIndex$kotlin_stdlib(II)V

    .line 408
    invoke-interface {p2}, Ljava/util/Collection;->size()I

    move-result v0

    .line 409
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v1, p1

    invoke-direct {p0, v1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAllInternal(ILjava/util/Collection;I)V

    if-lez v0, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 3

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 397
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 398
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 399
    invoke-interface {p1}, Ljava/util/Collection;->size()I

    move-result v0

    .line 400
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/2addr v1, v2

    invoke-direct {p0, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->addAllInternal(ILjava/util/Collection;I)V

    if-lez v0, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public clear()V
    .locals 2

    .line 414
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 415
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 416
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeRangeInternal(II)V

    return-void
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 1

    .line 471
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    if-eq p1, p0, :cond_1

    .line 473
    instance-of v0, p1, Ljava/util/List;

    if-eqz v0, :cond_0

    check-cast p1, Ljava/util/List;

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->contentEquals(Ljava/util/List;)Z

    move-result p1

    if-eqz p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public get(I)Ljava/lang/Object;
    .locals 2

    .line 339
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 340
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkElementIndex$kotlin_stdlib(II)V

    .line 341
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v1, p1

    aget-object p1, v0, v1

    return-object p1
.end method

.method public getSize()I
    .locals 1

    .line 329
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 330
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    return v0
.end method

.method public hashCode()I
    .locals 3

    .line 477
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 478
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilderKt;->access$subarrayContentHashCode([Ljava/lang/Object;II)I

    move-result v0

    return v0
.end method

.method public indexOf(Ljava/lang/Object;)I
    .locals 3

    .line 354
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    const/4 v0, 0x0

    .line 356
    :goto_0
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    if-ge v0, v1, :cond_1

    .line 357
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v2, v0

    aget-object v1, v1, v2

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v0

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public isEmpty()Z
    .locals 1

    .line 334
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 335
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    if-nez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    const/4 v0, 0x0

    .line 373
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->listIterator(I)Ljava/util/ListIterator;

    move-result-object v0

    return-object v0
.end method

.method public lastIndexOf(Ljava/lang/Object;)I
    .locals 3

    .line 364
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 365
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/lit8 v0, v0, -0x1

    :goto_0
    if-ltz v0, :cond_1

    .line 367
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v2, v0

    aget-object v1, v1, v2

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v0

    :cond_0
    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public listIterator()Ljava/util/ListIterator;
    .locals 1

    const/4 v0, 0x0

    .line 374
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->listIterator(I)Ljava/util/ListIterator;

    move-result-object v0

    return-object v0
.end method

.method public listIterator(I)Ljava/util/ListIterator;
    .locals 2

    .line 377
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 378
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkPositionIndex$kotlin_stdlib(II)V

    .line 379
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList$Itr;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;I)V

    return-object v0
.end method

.method public remove(Ljava/lang/Object;)Z
    .locals 0

    .line 428
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 429
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 430
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->indexOf(Ljava/lang/Object;)I

    move-result p1

    if-ltz p1, :cond_0

    .line 431
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeAt(I)Ljava/lang/Object;

    :cond_0
    if-ltz p1, :cond_1

    const/4 p1, 0x1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 3

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 436
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 437
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 438
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    const/4 v2, 0x0

    invoke-direct {p0, v0, v1, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->retainOrRemoveAllInternal(IILjava/util/Collection;Z)I

    move-result p1

    if-lez p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    return v2
.end method

.method public removeAt(I)Ljava/lang/Object;
    .locals 2

    .line 421
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 422
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 423
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkElementIndex$kotlin_stdlib(II)V

    .line 424
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v0, p1

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->removeAtInternal(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 3

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 442
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 443
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 444
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    const/4 v2, 0x1

    invoke-direct {p0, v0, v1, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->retainOrRemoveAllInternal(IILjava/util/Collection;Z)I

    move-result p1

    if-lez p1, :cond_0

    return v2

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public set(ILjava/lang/Object;)Ljava/lang/Object;
    .locals 3

    .line 345
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkIsMutable()V

    .line 346
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 347
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkElementIndex$kotlin_stdlib(II)V

    .line 348
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int v2, v1, p1

    aget-object v2, v0, v2

    add-int/2addr v1, p1

    .line 349
    aput-object p2, v0, v1

    return-object v2
.end method

.method public subList(II)Ljava/util/List;
    .locals 8

    .line 448
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-virtual {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/AbstractList$Companion;->checkRangeIndexes$kotlin_stdlib(III)V

    .line 449
    new-instance v2, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int v4, v0, p1

    sub-int v5, p2, p1

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->root:Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;

    move-object v6, p0

    invoke-direct/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;-><init>([Ljava/lang/Object;IILcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder;)V

    return-object v2
.end method

.method public toArray()[Ljava/lang/Object;
    .locals 3

    .line 465
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 467
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    add-int/2addr v2, v1

    invoke-static {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyOfRange([Ljava/lang/Object;II)[Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public toArray([Ljava/lang/Object;)[Ljava/lang/Object;
    .locals 4

    const-string v0, "array"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 454
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 455
    array-length v0, p1

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    if-ge v0, v1, :cond_0

    .line 456
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v1, v2

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-static {v0, v2, v1, p1}, Ljava/util/Arrays;->copyOfRange([Ljava/lang/Object;IILjava/lang/Class;)[Ljava/lang/Object;

    move-result-object p1

    const-string v0, "copyOfRange(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1

    .line 459
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    add-int/2addr v1, v2

    const/4 v3, 0x0

    invoke-static {v0, p1, v3, v2, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([Ljava/lang/Object;[Ljava/lang/Object;III)[Ljava/lang/Object;

    .line 461
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->terminateCollectionToArray(I[Ljava/lang/Object;)[Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 482
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->checkForComodification()V

    .line 483
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->backing:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->offset:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilder$BuilderSubList;->length:I

    invoke-static {v0, v1, v2, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/ListBuilderKt;->access$subarrayContentToString([Ljava/lang/Object;IILjava/util/Collection;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
