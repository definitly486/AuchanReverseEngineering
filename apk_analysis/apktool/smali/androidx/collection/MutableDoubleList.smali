.class public final Landroidx/collection/MutableDoubleList;
.super Landroidx/collection/DoubleList;
.source "DoubleList.kt"


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 0
    const/4 v0, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {p0, v2, v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    const/4 v0, 0x0

    .line 554
    invoke-direct {p0, p1, v0}, Landroidx/collection/DoubleList;-><init>(ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public synthetic constructor <init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p2, p2, 0x1

    if-eqz p2, :cond_0

    const/16 p1, 0x10

    .line 554
    :cond_0
    invoke-direct {p0, p1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    return-void
.end method


# virtual methods
.method public final add(ID)V
    .locals 3

    if-ltz p1, :cond_0

    .line 579
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 580
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 582
    :goto_0
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    add-int/lit8 v0, v0, 0x1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableDoubleList;->ensureCapacity(I)V

    .line 583
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    .line 584
    iget v1, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq p1, v1, :cond_1

    add-int/lit8 v2, p1, 0x1

    .line 585
    invoke-static {v0, v0, v2, p1, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    .line 592
    :cond_1
    aput-wide p2, v0, p1

    .line 593
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    add-int/lit8 p1, p1, 0x1

    iput p1, p0, Landroidx/collection/DoubleList;->_size:I

    return-void
.end method

.method public final add(D)Z
    .locals 3

    .line 566
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    const/4 v1, 0x1

    add-int/2addr v0, v1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableDoubleList;->ensureCapacity(I)V

    .line 567
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    iget v2, p0, Landroidx/collection/DoubleList;->_size:I

    aput-wide p1, v0, v2

    add-int/2addr v2, v1

    .line 568
    iput v2, p0, Landroidx/collection/DoubleList;->_size:I

    return v1
.end method

.method public final addAll(ILandroidx/collection/DoubleList;)Z
    .locals 4

    const-string v0, "elements"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-ltz p1, :cond_0

    .line 631
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 632
    :cond_0
    const-string v0, ""

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 367
    :goto_0
    iget v0, p2, Landroidx/collection/DoubleList;->_size:I

    const/4 v1, 0x0

    if-nez v0, :cond_1

    return v1

    .line 635
    :cond_1
    iget v2, p0, Landroidx/collection/DoubleList;->_size:I

    add-int/2addr v2, v0

    invoke-virtual {p0, v2}, Landroidx/collection/MutableDoubleList;->ensureCapacity(I)V

    .line 636
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    .line 637
    iget v2, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq p1, v2, :cond_2

    .line 640
    iget v3, p2, Landroidx/collection/DoubleList;->_size:I

    add-int/2addr v3, p1

    .line 638
    invoke-static {v0, v0, v3, p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    .line 645
    :cond_2
    iget-object v2, p2, Landroidx/collection/DoubleList;->content:[D

    .line 649
    iget v3, p2, Landroidx/collection/DoubleList;->_size:I

    .line 645
    invoke-static {v2, v0, p1, v1, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    .line 651
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    iget p2, p2, Landroidx/collection/DoubleList;->_size:I

    add-int/2addr p1, p2

    iput p1, p0, Landroidx/collection/DoubleList;->_size:I

    const/4 p1, 0x1

    return p1
.end method

.method public final addAll(I[D)Z
    .locals 8

    const-string v0, "elements"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    if-ltz p1, :cond_0

    .line 604
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-gt p1, v0, :cond_0

    goto :goto_0

    .line 605
    :cond_0
    const-string v0, ""

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 607
    :goto_0
    array-length v0, p2

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 608
    :cond_1
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    array-length v1, p2

    add-int/2addr v0, v1

    invoke-virtual {p0, v0}, Landroidx/collection/MutableDoubleList;->ensureCapacity(I)V

    .line 609
    iget-object v2, p0, Landroidx/collection/DoubleList;->content:[D

    .line 610
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq p1, v0, :cond_2

    .line 613
    array-length v1, p2

    add-int/2addr v1, p1

    .line 611
    invoke-static {v2, v2, v1, p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    :cond_2
    const/16 v6, 0xc

    const/4 v7, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    move v3, p1

    move-object v1, p2

    .line 618
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto$default([D[DIIIILjava/lang/Object;)[D

    .line 619
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    array-length p2, v1

    add-int/2addr p1, p2

    iput p1, p0, Landroidx/collection/DoubleList;->_size:I

    const/4 p1, 0x1

    return p1
.end method

.method public final addAll(Landroidx/collection/DoubleList;)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 660
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableDoubleList;->addAll(ILandroidx/collection/DoubleList;)Z

    move-result p1

    return p1
.end method

.method public final addAll([D)Z
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 668
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableDoubleList;->addAll(I[D)Z

    move-result p1

    return p1
.end method

.method public final clear()V
    .locals 1

    const/4 v0, 0x0

    .line 687
    iput v0, p0, Landroidx/collection/DoubleList;->_size:I

    return-void
.end method

.method public final ensureCapacity(I)V
    .locals 2

    .line 709
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    .line 710
    array-length v1, v0

    if-ge v1, p1, :cond_0

    .line 711
    array-length v1, v0

    mul-int/lit8 v1, v1, 0x3

    div-int/lit8 v1, v1, 0x2

    invoke-static {p1, v1}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 712
    invoke-static {v0, p1}, Ljava/util/Arrays;->copyOf([DI)[D

    move-result-object p1

    const-string v0, "copyOf(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Landroidx/collection/DoubleList;->content:[D

    :cond_0
    return-void
.end method

.method public final getCapacity()I
    .locals 1

    .line 562
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    array-length v0, v0

    return v0
.end method

.method public final minusAssign(D)V
    .locals 0

    .line 723
    invoke-virtual {p0, p1, p2}, Landroidx/collection/MutableDoubleList;->remove(D)Z

    return-void
.end method

.method public final minusAssign(Landroidx/collection/DoubleList;)V
    .locals 4

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 240
    iget-object v0, p1, Landroidx/collection/DoubleList;->content:[D

    .line 241
    iget p1, p1, Landroidx/collection/DoubleList;->_size:I

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_0

    .line 242
    aget-wide v2, v0, v1

    .line 771
    invoke-virtual {p0, v2, v3}, Landroidx/collection/MutableDoubleList;->remove(D)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final minusAssign([D)V
    .locals 4

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 987
    array-length v0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    aget-wide v2, p1, v1

    .line 766
    invoke-virtual {p0, v2, v3}, Landroidx/collection/MutableDoubleList;->remove(D)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final plusAssign(D)V
    .locals 0

    .line 718
    invoke-virtual {p0, p1, p2}, Landroidx/collection/MutableDoubleList;->add(D)Z

    return-void
.end method

.method public final plusAssign(Landroidx/collection/DoubleList;)V
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 673
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableDoubleList;->addAll(ILandroidx/collection/DoubleList;)Z

    return-void
.end method

.method public final plusAssign([D)V
    .locals 1

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 678
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {p0, v0, p1}, Landroidx/collection/MutableDoubleList;->addAll(I[D)Z

    return-void
.end method

.method public final remove(D)Z
    .locals 0

    .line 732
    invoke-virtual {p0, p1, p2}, Landroidx/collection/DoubleList;->indexOf(D)I

    move-result p1

    if-ltz p1, :cond_0

    .line 734
    invoke-virtual {p0, p1}, Landroidx/collection/MutableDoubleList;->removeAt(I)D

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public final removeAll(Landroidx/collection/DoubleList;)Z
    .locals 7

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 757
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    .line 72
    iget v1, p1, Landroidx/collection/DoubleList;->_size:I

    const/4 v2, 0x1

    sub-int/2addr v1, v2

    const/4 v3, 0x0

    if-ltz v1, :cond_0

    move v4, v3

    .line 759
    :goto_0
    invoke-virtual {p1, v4}, Landroidx/collection/DoubleList;->get(I)D

    move-result-wide v5

    invoke-virtual {p0, v5, v6}, Landroidx/collection/MutableDoubleList;->remove(D)Z

    if-eq v4, v1, :cond_0

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 761
    :cond_0
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq v0, p1, :cond_1

    return v2

    :cond_1
    return v3
.end method

.method public final removeAll([D)Z
    .locals 6

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 745
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    .line 746
    array-length v1, p1

    const/4 v2, 0x0

    move v3, v2

    :goto_0
    if-ge v3, v1, :cond_0

    .line 747
    aget-wide v4, p1, v3

    invoke-virtual {p0, v4, v5}, Landroidx/collection/MutableDoubleList;->remove(D)Z

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 749
    :cond_0
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq v0, p1, :cond_1

    const/4 p1, 0x1

    return p1

    :cond_1
    return v2
.end method

.method public final removeAt(I)D
    .locals 5

    if-ltz p1, :cond_0

    .line 780
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-ge p1, v0, :cond_0

    goto :goto_0

    .line 781
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 783
    :goto_0
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    .line 784
    aget-wide v1, v0, p1

    .line 72
    iget v3, p0, Landroidx/collection/DoubleList;->_size:I

    add-int/lit8 v4, v3, -0x1

    if-eq p1, v4, :cond_1

    add-int/lit8 v4, p1, 0x1

    .line 786
    invoke-static {v0, v0, p1, v4, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    .line 793
    :cond_1
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    add-int/lit8 p1, p1, -0x1

    iput p1, p0, Landroidx/collection/DoubleList;->_size:I

    return-wide v1
.end method

.method public final removeRange(II)V
    .locals 2

    if-ltz p1, :cond_0

    .line 804
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-gt p1, v0, :cond_0

    if-ltz p2, :cond_0

    if-gt p2, v0, :cond_0

    goto :goto_0

    .line 805
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    :goto_0
    if-ge p2, p1, :cond_1

    .line 808
    const-string v0, "The end index must be < start index"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIllegalArgumentException(Ljava/lang/String;)V

    :cond_1
    if-eq p2, p1, :cond_3

    .line 811
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-ge p2, v0, :cond_2

    .line 812
    iget-object v1, p0, Landroidx/collection/DoubleList;->content:[D

    invoke-static {v1, v1, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->copyInto([D[DIII)[D

    .line 819
    :cond_2
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    sub-int/2addr p2, p1

    sub-int/2addr v0, p2

    iput v0, p0, Landroidx/collection/DoubleList;->_size:I

    :cond_3
    return-void
.end method

.method public final retainAll(Landroidx/collection/DoubleList;)Z
    .locals 5

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 846
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    .line 847
    iget-object v1, p0, Landroidx/collection/DoubleList;->content:[D

    add-int/lit8 v2, v0, -0x1

    :goto_0
    const/4 v3, -0x1

    if-ge v3, v2, :cond_1

    .line 849
    aget-wide v3, v1, v2

    .line 850
    invoke-virtual {p1, v3, v4}, Landroidx/collection/DoubleList;->contains(D)Z

    move-result v3

    if-nez v3, :cond_0

    .line 851
    invoke-virtual {p0, v2}, Landroidx/collection/MutableDoubleList;->removeAt(I)D

    :cond_0
    add-int/lit8 v2, v2, -0x1

    goto :goto_0

    .line 854
    :cond_1
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq v0, p1, :cond_2

    const/4 p1, 0x1

    return p1

    :cond_2
    const/4 p1, 0x0

    return p1
.end method

.method public final retainAll([D)Z
    .locals 10

    const-string v0, "elements"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 829
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    .line 830
    iget-object v1, p0, Landroidx/collection/DoubleList;->content:[D

    add-int/lit8 v2, v0, -0x1

    :goto_0
    const/4 v3, 0x0

    const/4 v4, -0x1

    if-ge v4, v2, :cond_3

    .line 832
    aget-wide v5, v1, v2

    .line 997
    array-length v7, p1

    :goto_1
    if-ge v3, v7, :cond_1

    .line 998
    aget-wide v8, p1, v3

    cmpg-double v8, v8, v5

    if-nez v8, :cond_0

    move v4, v3

    goto :goto_2

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    :cond_1
    :goto_2
    if-gez v4, :cond_2

    .line 834
    invoke-virtual {p0, v2}, Landroidx/collection/MutableDoubleList;->removeAt(I)D

    :cond_2
    add-int/lit8 v2, v2, -0x1

    goto :goto_0

    .line 837
    :cond_3
    iget p1, p0, Landroidx/collection/DoubleList;->_size:I

    if-eq v0, p1, :cond_4

    const/4 p1, 0x1

    return p1

    :cond_4
    return v3
.end method

.method public final set(ID)D
    .locals 3

    if-ltz p1, :cond_0

    .line 864
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-ge p1, v0, :cond_0

    goto :goto_0

    .line 865
    :cond_0
    const-string v0, "Index must be between 0 and size"

    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIndexOutOfBoundsException(Ljava/lang/String;)V

    .line 867
    :goto_0
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    .line 868
    aget-wide v1, v0, p1

    .line 869
    aput-wide p2, v0, p1

    return-wide v1
.end method

.method public final sort()V
    .locals 3

    .line 876
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-nez v0, :cond_0

    return-void

    .line 877
    :cond_0
    iget-object v1, p0, Landroidx/collection/DoubleList;->content:[D

    const/4 v2, 0x0

    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sort([DII)V

    return-void
.end method

.method public final sortDescending()V
    .locals 3

    .line 883
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    if-nez v0, :cond_0

    return-void

    .line 884
    :cond_0
    iget-object v1, p0, Landroidx/collection/DoubleList;->content:[D

    const/4 v2, 0x0

    invoke-static {v1, v2, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sortDescending([DII)V

    return-void
.end method

.method public final trim(I)V
    .locals 2

    .line 697
    iget v0, p0, Landroidx/collection/DoubleList;->_size:I

    invoke-static {p1, v0}, Ljava/lang/Math;->max(II)I

    move-result p1

    .line 562
    iget-object v0, p0, Landroidx/collection/DoubleList;->content:[D

    array-length v1, v0

    if-le v1, p1, :cond_0

    .line 699
    invoke-static {v0, p1}, Ljava/util/Arrays;->copyOf([DI)[D

    move-result-object p1

    const-string v0, "copyOf(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Landroidx/collection/DoubleList;->content:[D

    :cond_0
    return-void
.end method
