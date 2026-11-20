.class public final Landroidx/collection/MutableIntList;
.super Landroidx/collection/IntList;
.source "IntList.kt"


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 0
    const/4 v0, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {p0, v2, v0, v1}, Landroidx/collection/MutableIntList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    const/4 v0, 0x0

    .line 549
    invoke-direct {p0, p1, v0}, Landroidx/collection/IntList;-><init>(ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public synthetic constructor <init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p2, p2, 0x1

    if-eqz p2, :cond_0

    const/16 p1, 0x10

    .line 549
    :cond_0
    invoke-direct {p0, p1}, Landroidx/collection/MutableIntList;-><init>(I)V

    return-void
.end method


# virtual methods
.method public final add(II)V
    .locals 3

    if-ltz p1, :cond_0

    .line 573
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 574
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 576
    :goto_0
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    add-int/lit8 v0, v0, 0x1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableIntList;->ensureCapacity(I)V

    .line 577
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    .line 578
    iget v1, p0, Landroidx/collection/IntList;->_size:I

    if-eq p1, v1, :cond_1

    add-int/lit8 v2, p1, 0x1

    .line 579
    invoke-static {v0, v0, v2, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    .line 586
    :cond_1
    aput p2, v0, p1

    .line 587
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    add-int/lit8 p1, p1, 0x1

    iput p1, p0, Landroidx/collection/IntList;->_size:I

    return-void
.end method

.method public final add(I)Z
    .locals 3

    .line 560
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    const/4 v1, 0x1

    add-int/2addr v0, v1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableIntList;->ensureCapacity(I)V

    .line 561
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    iget v2, p0, Landroidx/collection/IntList;->_size:I

    aput p1, v0, v2

    add-int/2addr v2, v1

    .line 562
    iput v2, p0, Landroidx/collection/IntList;->_size:I

    return v1
.end method

.method public final addAll(ILandroidx/collection/IntList;)Z
    .locals 4

    const-string v0, "elements"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-ltz p1, :cond_0

    .line 625
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 626
    :cond_0
    const-string v0, ""

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 363
    :goto_0
    iget v0, p2, Landroidx/collection/IntList;->_size:I

    const/4 v1, 0x0

    if-nez v0, :cond_1

    return v1

    .line 629
    :cond_1
    iget v2, p0, Landroidx/collection/IntList;->_size:I

    add-int/2addr v2, v0

    invoke-virtual {p0, v2}, Landroidx/collection/MutableIntList;->ensureCapacity(I)V

    .line 630
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    .line 631
    iget v2, p0, Landroidx/collection/IntList;->_size:I

    if-eq p1, v2, :cond_2

    .line 634
    iget v3, p2, Landroidx/collection/IntList;->_size:I

    add-int/2addr v3, p1

    .line 632
    invoke-static {v0, v0, v3, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    .line 639
    :cond_2
    iget-object v2, p2, Landroidx/collection/IntList;->content:[I

    .line 643
    iget v3, p2, Landroidx/collection/IntList;->_size:I

    .line 639
    invoke-static {v2, v0, p1, v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    .line 645
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    iget p2, p2, Landroidx/collection/IntList;->_size:I

    add-int/2addr p1, p2

    iput p1, p0, Landroidx/collection/IntList;->_size:I

    const/4 p1, 0x1

    return p1
.end method

.method public final addAll(I[I)Z
    .locals 8

    const-string v0, "elements"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-ltz p1, :cond_0

    .line 598
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 599
    :cond_0
    const-string v0, ""

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 601
    :goto_0
    array-length v0, p2

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 602
    :cond_1
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    array-length v1, p2

    add-int/2addr v0, v1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableIntList;->ensureCapacity(I)V

    .line 603
    iget-object v2, p0, Landroidx/collection/IntList;->content:[I

    .line 604
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-eq p1, v0, :cond_2

    .line 607
    array-length v1, p2

    add-int/2addr v1, p1

    .line 605
    invoke-static {v2, v2, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    :cond_2
    const/16 v6, 0xc

    const/4 v7, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    move v3, p1

    move-object v1, p2

    .line 612
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto$default([I[IIIIILjava/lang/Object;)[I

    .line 613
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    array-length p2, v1

    add-int/2addr p1, p2

    iput p1, p0, Landroidx/collection/IntList;->_size:I

    const/4 p1, 0x1

    return p1
.end method

.method public final addAll(Landroidx/collection/IntList;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 654
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableIntList;->addAll(ILandroidx/collection/IntList;)Z

    move-result p1

    return p1
.end method

.method public final addAll([I)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 662
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableIntList;->addAll(I[I)Z

    move-result p1

    return p1
.end method

.method public final clear()V
    .locals 1

    const/4 v0, 0x0

    .line 681
    iput v0, p0, Landroidx/collection/IntList;->_size:I

    return-void
.end method

.method public final ensureCapacity(I)V
    .locals 2

    .line 703
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    .line 704
    array-length v1, v0

    if-ge v1, p1, :cond_0

    .line 705
    array-length v1, v0

    mul-int/lit8 v1, v1, 0x3

    div-int/lit8 v1, v1, 0x2

    invoke-static {p1, v1}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 706
    invoke-static {v0, p1}, Ljava/util/Arrays;->copyOf([II)[I

    move-result-object p1

    const-string v0, "copyOf(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Landroidx/collection/IntList;->content:[I

    :cond_0
    return-void
.end method

.method public final getCapacity()I
    .locals 1

    .line 556
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    array-length v0, v0

    return v0
.end method

.method public final minusAssign(I)V
    .locals 0

    .line 717
    invoke-virtual {p0, p1}, Landroidx/collection/MutableIntList;->remove(I)Z

    return-void
.end method

.method public final minusAssign(Landroidx/collection/IntList;)V
    .locals 3

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 238
    iget-object v0, p1, Landroidx/collection/IntList;->content:[I

    .line 239
    iget p1, p1, Landroidx/collection/IntList;->_size:I

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_0

    .line 240
    aget v2, v0, v1

    .line 762
    invoke-virtual {p0, v2}, Landroidx/collection/MutableIntList;->remove(I)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final minusAssign([I)V
    .locals 3

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 13330
    array-length v0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    aget v2, p1, v1

    .line 757
    invoke-virtual {p0, v2}, Landroidx/collection/MutableIntList;->remove(I)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final plusAssign(I)V
    .locals 0

    .line 712
    invoke-virtual {p0, p1}, Landroidx/collection/MutableIntList;->add(I)Z

    return-void
.end method

.method public final plusAssign(Landroidx/collection/IntList;)V
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 667
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableIntList;->addAll(ILandroidx/collection/IntList;)Z

    return-void
.end method

.method public final plusAssign([I)V
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 672
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableIntList;->addAll(I[I)Z

    return-void
.end method

.method public final remove(I)Z
    .locals 0

    .line 725
    invoke-virtual {p0, p1}, Landroidx/collection/IntList;->indexOf(I)I

    move-result p1

    if-ltz p1, :cond_0

    .line 727
    invoke-virtual {p0, p1}, Landroidx/collection/MutableIntList;->removeAt(I)I

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public final removeAll(Landroidx/collection/IntList;)Z
    .locals 6

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 748
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    .line 70
    iget v1, p1, Landroidx/collection/IntList;->_size:I

    const/4 v2, 0x1

    sub-int/2addr v1, v2

    const/4 v3, 0x0

    if-ltz v1, :cond_0

    move v4, v3

    .line 750
    :goto_0
    invoke-virtual {p1, v4}, Landroidx/collection/IntList;->get(I)I

    move-result v5

    invoke-virtual {p0, v5}, Landroidx/collection/MutableIntList;->remove(I)Z

    if-eq v4, v1, :cond_0

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 752
    :cond_0
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    if-eq v0, p1, :cond_1

    return v2

    :cond_1
    return v3
.end method

.method public final removeAll([I)Z
    .locals 5

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 737
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    .line 738
    array-length v1, p1

    const/4 v2, 0x0

    move v3, v2

    :goto_0
    if-ge v3, v1, :cond_0

    .line 739
    aget v4, p1, v3

    invoke-virtual {p0, v4}, Landroidx/collection/MutableIntList;->remove(I)Z

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 741
    :cond_0
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    if-eq v0, p1, :cond_1

    const/4 p1, 0x1

    return p1

    :cond_1
    return v2
.end method

.method public final removeAt(I)I
    .locals 4

    if-ltz p1, :cond_0

    .line 771
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-ge p1, v0, :cond_0

    goto :goto_0

    .line 772
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 774
    :goto_0
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    .line 775
    aget v1, v0, p1

    .line 70
    iget v2, p0, Landroidx/collection/IntList;->_size:I

    add-int/lit8 v3, v2, -0x1

    if-eq p1, v3, :cond_1

    add-int/lit8 v3, p1, 0x1

    .line 777
    invoke-static {v0, v0, p1, v3, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    .line 784
    :cond_1
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    add-int/lit8 p1, p1, -0x1

    iput p1, p0, Landroidx/collection/IntList;->_size:I

    return v1
.end method

.method public final removeRange(II)V
    .locals 2

    if-ltz p1, :cond_0

    .line 795
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-gt p1, v0, :cond_0

    if-ltz p2, :cond_0

    if-gt p2, v0, :cond_0

    goto :goto_0

    .line 796
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    :goto_0
    if-ge p2, p1, :cond_1

    .line 799
    const-string v0, "The end index must be < start index"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIllegalArgumentException(Ljava/lang/String;)V

    :cond_1
    if-eq p2, p1, :cond_3

    .line 802
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-ge p2, v0, :cond_2

    .line 803
    iget-object v1, p0, Landroidx/collection/IntList;->content:[I

    invoke-static {v1, v1, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([I[IIII)[I

    .line 810
    :cond_2
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    sub-int/2addr p2, p1

    sub-int/2addr v0, p2

    iput v0, p0, Landroidx/collection/IntList;->_size:I

    :cond_3
    return-void
.end method

.method public final retainAll(Landroidx/collection/IntList;)Z
    .locals 4

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 837
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    .line 838
    iget-object v1, p0, Landroidx/collection/IntList;->content:[I

    add-int/lit8 v2, v0, -0x1

    :goto_0
    const/4 v3, -0x1

    if-ge v3, v2, :cond_1

    .line 840
    aget v3, v1, v2

    .line 841
    invoke-virtual {p1, v3}, Landroidx/collection/IntList;->contains(I)Z

    move-result v3

    if-nez v3, :cond_0

    .line 842
    invoke-virtual {p0, v2}, Landroidx/collection/MutableIntList;->removeAt(I)I

    :cond_0
    add-int/lit8 v2, v2, -0x1

    goto :goto_0

    .line 845
    :cond_1
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    if-eq v0, p1, :cond_2

    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method public final retainAll([I)Z
    .locals 8

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 820
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    .line 821
    iget-object v1, p0, Landroidx/collection/IntList;->content:[I

    add-int/lit8 v2, v0, -0x1

    :goto_0
    const/4 v3, 0x0

    const/4 v4, -0x1

    if-ge v4, v2, :cond_3

    .line 823
    aget v5, v1, v2

    .line 982
    array-length v6, p1

    :goto_1
    if-ge v3, v6, :cond_1

    .line 1664
    aget v7, p1, v3

    if-ne v7, v5, :cond_0

    move v4, v3

    goto :goto_2

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_1
    :goto_2
    if-gez v4, :cond_2

    .line 825
    invoke-virtual {p0, v2}, Landroidx/collection/MutableIntList;->removeAt(I)I

    :cond_2
    add-int/lit8 v2, v2, -0x1

    goto :goto_0

    .line 828
    :cond_3
    iget p1, p0, Landroidx/collection/IntList;->_size:I

    if-eq v0, p1, :cond_4

    const/4 p1, 0x1

    return p1

    :cond_4
    return v3
.end method

.method public final set(II)I
    .locals 2

    if-ltz p1, :cond_0

    .line 855
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-ge p1, v0, :cond_0

    goto :goto_0

    .line 856
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 858
    :goto_0
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    .line 859
    aget v1, v0, p1

    .line 860
    aput p2, v0, p1

    return v1
.end method

.method public final sort()V
    .locals 3

    .line 867
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-nez v0, :cond_0

    return-void

    .line 868
    :cond_0
    iget-object v1, p0, Landroidx/collection/IntList;->content:[I

    const/4 v2, 0x0

    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sort([III)V

    return-void
.end method

.method public final sortDescending()V
    .locals 3

    .line 874
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    if-nez v0, :cond_0

    return-void

    .line 875
    :cond_0
    iget-object v1, p0, Landroidx/collection/IntList;->content:[I

    const/4 v2, 0x0

    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sortDescending([III)V

    return-void
.end method

.method public final trim(I)V
    .locals 2

    .line 691
    iget v0, p0, Landroidx/collection/IntList;->_size:I

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 556
    iget-object v0, p0, Landroidx/collection/IntList;->content:[I

    array-length v1, v0

    if-le v1, p1, :cond_0

    .line 693
    invoke-static {v0, p1}, Ljava/util/Arrays;->copyOf([II)[I

    move-result-object p1

    const-string v0, "copyOf(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Landroidx/collection/IntList;->content:[I

    :cond_0
    return-void
.end method
