.class public final Landroidx/collection/MutableFloatIntMap;
.super Landroidx/collection/FloatIntMap;
.source "FloatIntMap.kt"


# instance fields
.field private growthLimit:I


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 0
    const/4 v0, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x0

    invoke-direct {p0, v2, v0, v1}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    const/4 v0, 0x0

    .line 634
    invoke-direct {p0, v0}, Landroidx/collection/FloatIntMap;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    if-ltz p1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    if-nez v0, :cond_1

    .line 639
    const-string v0, "Capacity must be a positive value."

    .line 61
    invoke-static {v0}, Landroidx/collection/internal/RuntimeHelpersKt;->throwIllegalArgumentException(Ljava/lang/String;)V

    .line 640
    :cond_1
    invoke-static {p1}, Landroidx/collection/ScatterMapKt;->unloadedCapacity(I)I

    move-result p1

    invoke-direct {p0, p1}, Landroidx/collection/MutableFloatIntMap;->initializeStorage(I)V

    return-void
.end method

.method public synthetic constructor <init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p2, p2, 0x1

    if-eqz p2, :cond_0

    const/4 p1, 0x6

    .line 634
    :cond_0
    invoke-direct {p0, p1}, Landroidx/collection/MutableFloatIntMap;-><init>(I)V

    return-void
.end method

.method private final findFirstAvailableSlot(I)I
    .locals 9

    .line 870
    iget v0, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    and-int/2addr p1, v0

    const/4 v1, 0x0

    .line 875
    :goto_0
    iget-object v2, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    shr-int/lit8 v3, p1, 0x3

    and-int/lit8 v4, p1, 0x7

    shl-int/lit8 v4, v4, 0x3

    .line 1374
    aget-wide v5, v2, v3

    ushr-long/2addr v5, v4

    add-int/lit8 v3, v3, 0x1

    aget-wide v7, v2, v3

    rsub-int/lit8 v2, v4, 0x40

    shl-long v2, v7, v2

    int-to-long v7, v4

    neg-long v7, v7

    const/16 v4, 0x3f

    shr-long/2addr v7, v4

    and-long/2addr v2, v7

    or-long/2addr v2, v5

    not-long v4, v2

    const/4 v6, 0x7

    shl-long/2addr v4, v6

    and-long/2addr v2, v4

    const-wide v4, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v2, v4

    const-wide/16 v4, 0x0

    cmp-long v4, v2, v4

    if-eqz v4, :cond_0

    .line 1297
    invoke-static {v2, v3}, Ljava/lang/Long;->numberOfTrailingZeros(J)I

    move-result v1

    shr-int/lit8 v1, v1, 0x3

    add-int/2addr p1, v1

    and-int/2addr p1, v0

    return p1

    :cond_0
    add-int/lit8 v1, v1, 0x8

    add-int/2addr p1, v1

    and-int/2addr p1, v0

    goto :goto_0
.end method

.method private final findInsertIndex(F)I
    .locals 19

    move-object/from16 v0, p0

    .line 882
    invoke-static/range {p1 .. p1}, Ljava/lang/Float;->hashCode(F)I

    move-result v1

    const v2, -0x3361d2af    # -8.2930312E7f

    mul-int/2addr v1, v2

    shl-int/lit8 v2, v1, 0x10

    xor-int/2addr v1, v2

    ushr-int/lit8 v2, v1, 0x7

    and-int/lit8 v1, v1, 0x7f

    .line 829
    iget v3, v0, Landroidx/collection/FloatIntMap;->_capacity:I

    and-int v4, v2, v3

    const/4 v6, 0x0

    .line 834
    :goto_0
    iget-object v7, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    shr-int/lit8 v8, v4, 0x3

    and-int/lit8 v9, v4, 0x7

    shl-int/lit8 v9, v9, 0x3

    .line 1374
    aget-wide v10, v7, v8

    ushr-long/2addr v10, v9

    const/4 v12, 0x1

    add-int/2addr v8, v12

    aget-wide v13, v7, v8

    rsub-int/lit8 v7, v9, 0x40

    shl-long v7, v13, v7

    int-to-long v13, v9

    neg-long v13, v13

    const/16 v9, 0x3f

    shr-long/2addr v13, v9

    and-long/2addr v7, v13

    or-long/2addr v7, v10

    int-to-long v9, v1

    const-wide v13, 0x101010101010101L

    mul-long v15, v9, v13

    move/from16 v17, v6

    xor-long v5, v7, v15

    sub-long v13, v5, v13

    not-long v5, v5

    and-long/2addr v5, v13

    const-wide v13, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v5, v13

    :goto_1
    const-wide/16 v15, 0x0

    cmp-long v18, v5, v15

    if-eqz v18, :cond_1

    .line 1297
    invoke-static {v5, v6}, Ljava/lang/Long;->numberOfTrailingZeros(J)I

    move-result v15

    shr-int/lit8 v15, v15, 0x3

    add-int/2addr v15, v4

    and-int/2addr v15, v3

    .line 838
    iget-object v11, v0, Landroidx/collection/FloatIntMap;->keys:[F

    aget v11, v11, v15

    cmpg-float v11, v11, p1

    if-nez v11, :cond_0

    return v15

    :cond_0
    const-wide/16 v15, 0x1

    sub-long v15, v5, v15

    and-long/2addr v5, v15

    goto :goto_1

    :cond_1
    not-long v5, v7

    const/4 v11, 0x6

    shl-long/2addr v5, v11

    and-long/2addr v5, v7

    and-long/2addr v5, v13

    cmp-long v5, v5, v15

    if-eqz v5, :cond_5

    .line 852
    invoke-direct {v0, v2}, Landroidx/collection/MutableFloatIntMap;->findFirstAvailableSlot(I)I

    move-result v1

    .line 853
    iget v3, v0, Landroidx/collection/MutableFloatIntMap;->growthLimit:I

    const-wide/16 v4, 0xff

    if-nez v3, :cond_3

    iget-object v3, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    shr-int/lit8 v6, v1, 0x3

    .line 1220
    aget-wide v6, v3, v6

    and-int/lit8 v3, v1, 0x7

    shl-int/lit8 v3, v3, 0x3

    shr-long/2addr v6, v3

    and-long/2addr v6, v4

    const-wide/16 v13, 0xfe

    cmp-long v3, v6, v13

    if-nez v3, :cond_2

    goto :goto_2

    .line 854
    :cond_2
    invoke-virtual {v0}, Landroidx/collection/MutableFloatIntMap;->adjustStorage$collection()V

    .line 855
    invoke-direct {v0, v2}, Landroidx/collection/MutableFloatIntMap;->findFirstAvailableSlot(I)I

    move-result v1

    .line 858
    :cond_3
    :goto_2
    iget v2, v0, Landroidx/collection/FloatIntMap;->_size:I

    add-int/2addr v2, v12

    iput v2, v0, Landroidx/collection/FloatIntMap;->_size:I

    .line 859
    iget v2, v0, Landroidx/collection/MutableFloatIntMap;->growthLimit:I

    iget-object v3, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    shr-int/lit8 v6, v1, 0x3

    .line 1220
    aget-wide v7, v3, v6

    and-int/lit8 v11, v1, 0x7

    shl-int/lit8 v11, v11, 0x3

    shr-long v13, v7, v11

    and-long/2addr v13, v4

    const-wide/16 v15, 0x80

    cmp-long v13, v13, v15

    if-nez v13, :cond_4

    move/from16 v18, v12

    goto :goto_3

    :cond_4
    const/16 v18, 0x0

    :goto_3
    sub-int v2, v2, v18

    .line 859
    iput v2, v0, Landroidx/collection/MutableFloatIntMap;->growthLimit:I

    .line 860
    iget v2, v0, Landroidx/collection/FloatIntMap;->_capacity:I

    shl-long/2addr v4, v11

    not-long v4, v4

    and-long/2addr v4, v7

    shl-long v7, v9, v11

    or-long/2addr v4, v7

    .line 1258
    aput-wide v4, v3, v6

    add-int/lit8 v6, v1, -0x7

    and-int/2addr v6, v2

    and-int/lit8 v2, v2, 0x7

    add-int/2addr v6, v2

    shr-int/lit8 v2, v6, 0x3

    .line 1243
    aput-wide v4, v3, v2

    not-int v1, v1

    return v1

    :cond_5
    add-int/lit8 v6, v17, 0x8

    add-int/2addr v4, v6

    and-int/2addr v4, v3

    goto/16 :goto_0
.end method

.method private final initializeGrowth()V
    .locals 2

    .line 672
    invoke-virtual {p0}, Landroidx/collection/FloatIntMap;->getCapacity()I

    move-result v0

    invoke-static {v0}, Landroidx/collection/ScatterMapKt;->loadedCapacity(I)I

    move-result v0

    iget v1, p0, Landroidx/collection/FloatIntMap;->_size:I

    sub-int/2addr v0, v1

    iput v0, p0, Landroidx/collection/MutableFloatIntMap;->growthLimit:I

    return-void
.end method

.method private final initializeMetadata(I)V
    .locals 8

    if-nez p1, :cond_0

    .line 661
    sget-object v0, Landroidx/collection/ScatterMapKt;->EmptyGroup:[J

    goto :goto_0

    :cond_0
    add-int/lit8 v0, p1, 0xf

    and-int/lit8 v0, v0, -0x8

    shr-int/lit8 v0, v0, 0x3

    .line 665
    new-array v1, v0, [J

    const/4 v6, 0x6

    const/4 v7, 0x0

    const-wide v2, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    const/4 v4, 0x0

    const/4 v5, 0x0

    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->fill$default([JJIIILjava/lang/Object;)V

    move-object v0, v1

    .line 659
    :goto_0
    iput-object v0, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    shr-int/lit8 v1, p1, 0x3

    and-int/lit8 p1, p1, 0x7

    shl-int/lit8 p1, p1, 0x3

    .line 1258
    aget-wide v2, v0, v1

    const-wide/16 v4, 0xff

    shl-long/2addr v4, p1

    not-long v6, v4

    and-long/2addr v2, v6

    or-long/2addr v2, v4

    aput-wide v2, v0, v1

    .line 668
    invoke-direct {p0}, Landroidx/collection/MutableFloatIntMap;->initializeGrowth()V

    return-void
.end method

.method private final initializeStorage(I)V
    .locals 1

    if-lez p1, :cond_0

    const/4 v0, 0x7

    .line 648
    invoke-static {p1}, Landroidx/collection/ScatterMapKt;->normalizeCapacity(I)I

    move-result p1

    invoke-static {v0, p1}, Ljava/lang/Math;->max(II)I

    move-result p1

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    .line 652
    :goto_0
    iput p1, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    .line 653
    invoke-direct {p0, p1}, Landroidx/collection/MutableFloatIntMap;->initializeMetadata(I)V

    .line 654
    new-array v0, p1, [F

    iput-object v0, p0, Landroidx/collection/FloatIntMap;->keys:[F

    .line 655
    new-array p1, p1, [I

    iput-object p1, p0, Landroidx/collection/FloatIntMap;->values:[I

    return-void
.end method


# virtual methods
.method public final adjustStorage$collection()V
    .locals 6

    .line 909
    iget v0, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    const/16 v1, 0x8

    if-le v0, v1, :cond_0

    iget v0, p0, Landroidx/collection/FloatIntMap;->_size:I

    int-to-long v0, v0

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v0

    const-wide/16 v2, 0x20

    mul-long/2addr v0, v2

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v0

    iget v2, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    int-to-long v2, v2

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v2

    const-wide/16 v4, 0x19

    mul-long/2addr v2, v4

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/ULong;->constructor-impl(J)J

    move-result-wide v2

    invoke-static {v0, v1, v2, v3}, Ljava/lang/Long;->compareUnsigned(JJ)I

    move-result v0

    if-gtz v0, :cond_0

    .line 910
    invoke-virtual {p0}, Landroidx/collection/MutableFloatIntMap;->dropDeletes$collection()V

    return-void

    .line 912
    :cond_0
    iget v0, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    invoke-static {v0}, Landroidx/collection/ScatterMapKt;->nextCapacity(I)I

    move-result v0

    invoke-virtual {p0, v0}, Landroidx/collection/MutableFloatIntMap;->resizeStorage$collection(I)V

    return-void
.end method

.method public final clear()V
    .locals 9

    const/4 v0, 0x0

    .line 810
    iput v0, p0, Landroidx/collection/FloatIntMap;->_size:I

    .line 811
    iget-object v1, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    sget-object v0, Landroidx/collection/ScatterMapKt;->EmptyGroup:[J

    if-eq v1, v0, :cond_0

    const/4 v6, 0x6

    const/4 v7, 0x0

    const-wide v2, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    const/4 v4, 0x0

    const/4 v5, 0x0

    .line 812
    invoke-static/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->fill$default([JJIIILjava/lang/Object;)V

    .line 813
    iget-object v0, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    iget v1, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    shr-int/lit8 v2, v1, 0x3

    and-int/lit8 v1, v1, 0x7

    shl-int/lit8 v1, v1, 0x3

    .line 1258
    aget-wide v3, v0, v2

    const-wide/16 v5, 0xff

    shl-long/2addr v5, v1

    not-long v7, v5

    and-long/2addr v3, v7

    or-long/2addr v3, v5

    aput-wide v3, v0, v2

    .line 815
    :cond_0
    invoke-direct {p0}, Landroidx/collection/MutableFloatIntMap;->initializeGrowth()V

    return-void
.end method

.method public final dropDeletes$collection()V
    .locals 28

    move-object/from16 v0, p0

    .line 918
    iget-object v1, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    .line 919
    iget v2, v0, Landroidx/collection/FloatIntMap;->_capacity:I

    .line 920
    iget-object v3, v0, Landroidx/collection/FloatIntMap;->keys:[F

    .line 921
    iget-object v4, v0, Landroidx/collection/FloatIntMap;->values:[I

    add-int/lit8 v5, v2, 0x7

    shr-int/lit8 v5, v5, 0x3

    const/4 v6, 0x0

    move v7, v6

    :goto_0
    if-ge v7, v5, :cond_0

    .line 1147
    aget-wide v8, v1, v7

    const-wide v10, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v8, v10

    not-long v10, v8

    const/4 v12, 0x7

    ushr-long/2addr v8, v12

    add-long/2addr v10, v8

    const-wide v8, -0x101010101010102L

    and-long/2addr v8, v10

    .line 1148
    aput-wide v8, v1, v7

    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    .line 1151
    :cond_0
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->getLastIndex([J)I

    move-result v5

    add-int/lit8 v7, v5, -0x1

    .line 1154
    aget-wide v8, v1, v7

    const-wide v10, 0xffffffffffffffL

    and-long/2addr v8, v10

    const-wide/high16 v12, -0x100000000000000L

    or-long/2addr v8, v12

    aput-wide v8, v1, v7

    .line 1156
    aget-wide v7, v1, v6

    aput-wide v7, v1, v5

    move v5, v6

    :goto_1
    if-eq v5, v2, :cond_5

    shr-int/lit8 v7, v5, 0x3

    .line 1220
    aget-wide v8, v1, v7

    and-int/lit8 v12, v5, 0x7

    shl-int/lit8 v12, v12, 0x3

    shr-long/2addr v8, v12

    const-wide/16 v13, 0xff

    and-long/2addr v8, v13

    const-wide/16 v15, 0x80

    cmp-long v17, v8, v15

    if-nez v17, :cond_1

    :goto_2
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :cond_1
    const-wide/16 v17, 0xfe

    cmp-long v8, v8, v17

    if-eqz v8, :cond_2

    goto :goto_2

    .line 944
    :cond_2
    aget v8, v3, v5

    .line 882
    invoke-static {v8}, Ljava/lang/Float;->hashCode(F)I

    move-result v8

    const v9, -0x3361d2af    # -8.2930312E7f

    mul-int/2addr v8, v9

    shl-int/lit8 v9, v8, 0x10

    xor-int/2addr v8, v9

    ushr-int/lit8 v9, v8, 0x7

    .line 946
    invoke-direct {v0, v9}, Landroidx/collection/MutableFloatIntMap;->findFirstAvailableSlot(I)I

    move-result v17

    and-int/2addr v9, v2

    sub-int v18, v17, v9

    and-int v18, v18, v2

    move/from16 v19, v6

    .line 952
    div-int/lit8 v6, v18, 0x8

    sub-int v9, v5, v9

    and-int/2addr v9, v2

    .line 953
    div-int/lit8 v9, v9, 0x8

    const-wide/high16 v20, -0x8000000000000000L

    if-ne v6, v9, :cond_3

    and-int/lit8 v6, v8, 0x7f

    int-to-long v8, v6

    .line 1258
    aget-wide v15, v1, v7

    shl-long/2addr v13, v12

    not-long v13, v13

    and-long/2addr v13, v15

    shl-long/2addr v8, v12

    or-long/2addr v8, v13

    aput-wide v8, v1, v7

    .line 960
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->getLastIndex([J)I

    move-result v6

    .line 961
    aget-wide v7, v1, v19

    and-long/2addr v7, v10

    or-long v7, v7, v20

    aput-wide v7, v1, v6

    add-int/lit8 v5, v5, 0x1

    move/from16 v6, v19

    goto :goto_1

    :cond_3
    shr-int/lit8 v6, v17, 0x3

    .line 1220
    aget-wide v22, v1, v6

    and-int/lit8 v9, v17, 0x7

    shl-int/lit8 v9, v9, 0x3

    shr-long v24, v22, v9

    and-long v24, v24, v13

    cmp-long v18, v24, v15

    if-nez v18, :cond_4

    and-int/lit8 v8, v8, 0x7f

    move-wide/from16 v24, v10

    int-to-long v10, v8

    move-wide/from16 v26, v13

    shl-long v13, v26, v9

    not-long v13, v13

    and-long v13, v22, v13

    shl-long v8, v10, v9

    or-long/2addr v8, v13

    .line 1258
    aput-wide v8, v1, v6

    .line 1258
    aget-wide v8, v1, v7

    shl-long v10, v26, v12

    not-long v10, v10

    and-long/2addr v8, v10

    shl-long v10, v15, v12

    or-long/2addr v8, v10

    aput-wide v8, v1, v7

    .line 974
    aget v6, v3, v5

    aput v6, v3, v17

    const/4 v6, 0x0

    .line 975
    aput v6, v3, v5

    .line 977
    aget v6, v4, v5

    aput v6, v4, v17

    .line 978
    aput v19, v4, v5

    goto :goto_3

    :cond_4
    move-wide/from16 v24, v10

    move-wide/from16 v26, v13

    and-int/lit8 v7, v8, 0x7f

    int-to-long v7, v7

    shl-long v10, v26, v9

    not-long v10, v10

    and-long v10, v22, v10

    shl-long/2addr v7, v9

    or-long/2addr v7, v10

    .line 1258
    aput-wide v7, v1, v6

    .line 985
    aget v6, v3, v17

    .line 986
    aget v7, v3, v5

    aput v7, v3, v17

    .line 987
    aput v6, v3, v5

    .line 989
    aget v6, v4, v17

    .line 990
    aget v7, v4, v5

    aput v7, v4, v17

    .line 991
    aput v6, v4, v5

    add-int/lit8 v5, v5, -0x1

    .line 999
    :goto_3
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->getLastIndex([J)I

    move-result v6

    aget-wide v7, v1, v19

    and-long v7, v7, v24

    or-long v7, v7, v20

    aput-wide v7, v1, v6

    add-int/lit8 v5, v5, 0x1

    move/from16 v6, v19

    move-wide/from16 v10, v24

    goto/16 :goto_1

    .line 1004
    :cond_5
    invoke-direct {v0}, Landroidx/collection/MutableFloatIntMap;->initializeGrowth()V

    return-void
.end method

.method public final getOrPut(FLkotlin/jvm/functions/Function0;)I
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(F",
            "Lkotlin/jvm/functions/Function0<",
            "Ljava/lang/Integer;",
            ">;)I"
        }
    .end annotation

    const-string v0, "defaultValue"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 681
    invoke-virtual {p0, p1}, Landroidx/collection/FloatIntMap;->findKeyIndex(F)I

    move-result v0

    if-gez v0, :cond_0

    .line 683
    invoke-interface {p2}, Lkotlin/jvm/functions/Function0;->invoke()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Ljava/lang/Number;

    invoke-virtual {p2}, Ljava/lang/Number;->intValue()I

    move-result p2

    .line 684
    invoke-virtual {p0, p1, p2}, Landroidx/collection/MutableFloatIntMap;->put(FI)V

    return p2

    .line 687
    :cond_0
    iget-object p1, p0, Landroidx/collection/FloatIntMap;->values:[I

    aget p1, p1, v0

    return p1
.end method

.method public final minusAssign(F)V
    .locals 0

    .line 779
    invoke-virtual {p0, p1}, Landroidx/collection/MutableFloatIntMap;->remove(F)V

    return-void
.end method

.method public final minusAssign(Landroidx/collection/FloatList;)V
    .locals 3

    const-string v0, "keys"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 238
    iget-object v0, p1, Landroidx/collection/FloatList;->content:[F

    .line 239
    iget p1, p1, Landroidx/collection/FloatList;->_size:I

    const/4 v1, 0x0

    :goto_0
    if-ge v1, p1, :cond_0

    .line 240
    aget v2, v0, v1

    .line 796
    invoke-virtual {p0, v2}, Landroidx/collection/MutableFloatIntMap;->remove(F)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final minusAssign(Landroidx/collection/FloatSet;)V
    .locals 13

    const-string v0, "keys"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 258
    iget-object v0, p1, Landroidx/collection/FloatSet;->elements:[F

    .line 228
    iget-object p1, p1, Landroidx/collection/FloatSet;->metadata:[J

    .line 229
    array-length v1, p1

    add-int/lit8 v1, v1, -0x2

    if-ltz v1, :cond_3

    const/4 v2, 0x0

    move v3, v2

    .line 232
    :goto_0
    aget-wide v4, p1, v3

    not-long v6, v4

    const/4 v8, 0x7

    shl-long/2addr v6, v8

    and-long/2addr v6, v4

    const-wide v8, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v6, v8

    cmp-long v6, v6, v8

    if-eqz v6, :cond_2

    sub-int v6, v3, v1

    not-int v6, v6

    ushr-int/lit8 v6, v6, 0x1f

    const/16 v7, 0x8

    rsub-int/lit8 v6, v6, 0x8

    move v8, v2

    :goto_1
    if-ge v8, v6, :cond_1

    const-wide/16 v9, 0xff

    and-long/2addr v9, v4

    const-wide/16 v11, 0x80

    cmp-long v9, v9, v11

    if-gez v9, :cond_0

    shl-int/lit8 v9, v3, 0x3

    add-int/2addr v9, v8

    .line 260
    aget v9, v0, v9

    .line 791
    invoke-virtual {p0, v9}, Landroidx/collection/MutableFloatIntMap;->remove(F)V

    :cond_0
    shr-long/2addr v4, v7

    add-int/lit8 v8, v8, 0x1

    goto :goto_1

    :cond_1
    if-ne v6, v7, :cond_3

    :cond_2
    if-eq v3, v1, :cond_3

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public final minusAssign([F)V
    .locals 3

    const-string v0, "keys"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 784
    array-length v0, p1

    const/4 v1, 0x0

    :goto_0
    if-ge v1, v0, :cond_0

    aget v2, p1, v1

    .line 785
    invoke-virtual {p0, v2}, Landroidx/collection/MutableFloatIntMap;->remove(F)V

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public final plusAssign(Landroidx/collection/FloatIntMap;)V
    .locals 1

    const-string v0, "from"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 743
    invoke-virtual {p0, p1}, Landroidx/collection/MutableFloatIntMap;->putAll(Landroidx/collection/FloatIntMap;)V

    return-void
.end method

.method public final put(FII)I
    .locals 2

    .line 724
    invoke-direct {p0, p1}, Landroidx/collection/MutableFloatIntMap;->findInsertIndex(F)I

    move-result v0

    if-gez v0, :cond_0

    not-int v0, v0

    goto :goto_0

    .line 729
    :cond_0
    iget-object p3, p0, Landroidx/collection/FloatIntMap;->values:[I

    aget p3, p3, v0

    .line 731
    :goto_0
    iget-object v1, p0, Landroidx/collection/FloatIntMap;->keys:[F

    aput p1, v1, v0

    .line 732
    iget-object p1, p0, Landroidx/collection/FloatIntMap;->values:[I

    aput p2, p1, v0

    return p3
.end method

.method public final put(FI)V
    .locals 0

    .line 712
    invoke-virtual {p0, p1, p2}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-void
.end method

.method public final putAll(Landroidx/collection/FloatIntMap;)V
    .locals 14

    const-string v0, "from"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 387
    iget-object v0, p1, Landroidx/collection/FloatIntMap;->keys:[F

    .line 388
    iget-object v1, p1, Landroidx/collection/FloatIntMap;->values:[I

    .line 359
    iget-object p1, p1, Landroidx/collection/FloatIntMap;->metadata:[J

    .line 360
    array-length v2, p1

    add-int/lit8 v2, v2, -0x2

    if-ltz v2, :cond_3

    const/4 v3, 0x0

    move v4, v3

    .line 363
    :goto_0
    aget-wide v5, p1, v4

    not-long v7, v5

    const/4 v9, 0x7

    shl-long/2addr v7, v9

    and-long/2addr v7, v5

    const-wide v9, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v7, v9

    cmp-long v7, v7, v9

    if-eqz v7, :cond_2

    sub-int v7, v4, v2

    not-int v7, v7

    ushr-int/lit8 v7, v7, 0x1f

    const/16 v8, 0x8

    rsub-int/lit8 v7, v7, 0x8

    move v9, v3

    :goto_1
    if-ge v9, v7, :cond_1

    const-wide/16 v10, 0xff

    and-long/2addr v10, v5

    const-wide/16 v12, 0x80

    cmp-long v10, v10, v12

    if-gez v10, :cond_0

    shl-int/lit8 v10, v4, 0x3

    add-int/2addr v10, v9

    .line 390
    aget v11, v0, v10

    aget v10, v1, v10

    .line 739
    invoke-virtual {p0, v11, v10}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    :cond_0
    shr-long/2addr v5, v8

    add-int/lit8 v9, v9, 0x1

    goto :goto_1

    :cond_1
    if-ne v7, v8, :cond_3

    :cond_2
    if-eq v4, v2, :cond_3

    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public final remove(F)V
    .locals 0

    .line 747
    invoke-virtual {p0, p1}, Landroidx/collection/FloatIntMap;->findKeyIndex(F)I

    move-result p1

    if-ltz p1, :cond_0

    .line 749
    invoke-virtual {p0, p1}, Landroidx/collection/MutableFloatIntMap;->removeValueAt(I)V

    :cond_0
    return-void
.end method

.method public final remove(FI)Z
    .locals 1

    .line 758
    invoke-virtual {p0, p1}, Landroidx/collection/FloatIntMap;->findKeyIndex(F)I

    move-result p1

    if-ltz p1, :cond_0

    .line 760
    iget-object v0, p0, Landroidx/collection/FloatIntMap;->values:[I

    aget v0, v0, p1

    if-ne v0, p2, :cond_0

    .line 761
    invoke-virtual {p0, p1}, Landroidx/collection/MutableFloatIntMap;->removeValueAt(I)V

    const/4 p1, 0x1

    return p1

    :cond_0
    const/4 p1, 0x0

    return p1
.end method

.method public final removeIf(Lkotlin/jvm/functions/Function2;)V
    .locals 13
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function2<",
            "-",
            "Ljava/lang/Float;",
            "-",
            "Ljava/lang/Integer;",
            "Ljava/lang/Boolean;",
            ">;)V"
        }
    .end annotation

    const-string v0, "predicate"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 359
    iget-object v0, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    .line 360
    array-length v1, v0

    add-int/lit8 v1, v1, -0x2

    if-ltz v1, :cond_3

    const/4 v2, 0x0

    move v3, v2

    .line 363
    :goto_0
    aget-wide v4, v0, v3

    not-long v6, v4

    const/4 v8, 0x7

    shl-long/2addr v6, v8

    and-long/2addr v6, v4

    const-wide v8, -0x7f7f7f7f7f7f7f80L    # -2.937446524422997E-306

    and-long/2addr v6, v8

    cmp-long v6, v6, v8

    if-eqz v6, :cond_2

    sub-int v6, v3, v1

    not-int v6, v6

    ushr-int/lit8 v6, v6, 0x1f

    const/16 v7, 0x8

    rsub-int/lit8 v6, v6, 0x8

    move v8, v2

    :goto_1
    if-ge v8, v6, :cond_1

    const-wide/16 v9, 0xff

    and-long/2addr v9, v4

    const-wide/16 v11, 0x80

    cmp-long v9, v9, v11

    if-gez v9, :cond_0

    shl-int/lit8 v9, v3, 0x3

    add-int/2addr v9, v8

    .line 771
    iget-object v10, p0, Landroidx/collection/FloatIntMap;->keys:[F

    aget v10, v10, v9

    invoke-static {v10}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v10

    iget-object v11, p0, Landroidx/collection/FloatIntMap;->values:[I

    aget v11, v11, v9

    invoke-static {v11}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    invoke-interface {p1, v10, v11}, Lkotlin/jvm/functions/Function2;->invoke(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/lang/Boolean;

    invoke-virtual {v10}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v10

    if-eqz v10, :cond_0

    .line 772
    invoke-virtual {p0, v9}, Landroidx/collection/MutableFloatIntMap;->removeValueAt(I)V

    :cond_0
    shr-long/2addr v4, v7

    add-int/lit8 v8, v8, 0x1

    goto :goto_1

    :cond_1
    if-ne v6, v7, :cond_3

    :cond_2
    if-eq v3, v1, :cond_3

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_3
    return-void
.end method

.method public final removeValueAt(I)V
    .locals 8

    .line 801
    iget v0, p0, Landroidx/collection/FloatIntMap;->_size:I

    add-int/lit8 v0, v0, -0x1

    iput v0, p0, Landroidx/collection/FloatIntMap;->_size:I

    .line 805
    iget-object v0, p0, Landroidx/collection/FloatIntMap;->metadata:[J

    iget v1, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    shr-int/lit8 v2, p1, 0x3

    and-int/lit8 v3, p1, 0x7

    shl-int/lit8 v3, v3, 0x3

    .line 1258
    aget-wide v4, v0, v2

    const-wide/16 v6, 0xff

    shl-long/2addr v6, v3

    not-long v6, v6

    and-long/2addr v4, v6

    const-wide/16 v6, 0xfe

    shl-long/2addr v6, v3

    or-long v3, v4, v6

    aput-wide v3, v0, v2

    add-int/lit8 p1, p1, -0x7

    and-int/2addr p1, v1

    and-int/lit8 v1, v1, 0x7

    add-int/2addr p1, v1

    shr-int/lit8 p1, p1, 0x3

    .line 1243
    aput-wide v3, v0, p1

    return-void
.end method

.method public final resizeStorage$collection(I)V
    .locals 21

    move-object/from16 v0, p0

    .line 1009
    iget-object v1, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    .line 1010
    iget-object v2, v0, Landroidx/collection/FloatIntMap;->keys:[F

    .line 1011
    iget-object v3, v0, Landroidx/collection/FloatIntMap;->values:[I

    .line 1012
    iget v4, v0, Landroidx/collection/FloatIntMap;->_capacity:I

    .line 1014
    invoke-direct/range {p0 .. p1}, Landroidx/collection/MutableFloatIntMap;->initializeStorage(I)V

    .line 1016
    iget-object v5, v0, Landroidx/collection/FloatIntMap;->metadata:[J

    .line 1017
    iget-object v6, v0, Landroidx/collection/FloatIntMap;->keys:[F

    .line 1018
    iget-object v7, v0, Landroidx/collection/FloatIntMap;->values:[I

    .line 1019
    iget v8, v0, Landroidx/collection/FloatIntMap;->_capacity:I

    const/4 v9, 0x0

    :goto_0
    if-ge v9, v4, :cond_1

    shr-int/lit8 v10, v9, 0x3

    .line 1220
    aget-wide v10, v1, v10

    and-int/lit8 v12, v9, 0x7

    shl-int/lit8 v12, v12, 0x3

    shr-long/2addr v10, v12

    const-wide/16 v12, 0xff

    and-long/2addr v10, v12

    const-wide/16 v14, 0x80

    cmp-long v10, v10, v14

    if-gez v10, :cond_0

    .line 1023
    aget v10, v2, v9

    .line 882
    invoke-static {v10}, Ljava/lang/Float;->hashCode(F)I

    move-result v11

    const v14, -0x3361d2af    # -8.2930312E7f

    mul-int/2addr v11, v14

    shl-int/lit8 v14, v11, 0x10

    xor-int/2addr v11, v14

    ushr-int/lit8 v14, v11, 0x7

    .line 1025
    invoke-direct {v0, v14}, Landroidx/collection/MutableFloatIntMap;->findFirstAvailableSlot(I)I

    move-result v14

    and-int/lit8 v11, v11, 0x7f

    move-wide v15, v12

    int-to-long v12, v11

    shr-int/lit8 v11, v14, 0x3

    and-int/lit8 v17, v14, 0x7

    shl-int/lit8 v17, v17, 0x3

    .line 1258
    aget-wide v18, v5, v11

    move-object/from16 v20, v1

    shl-long v0, v15, v17

    not-long v0, v0

    and-long v0, v18, v0

    shl-long v12, v12, v17

    or-long/2addr v0, v12

    aput-wide v0, v5, v11

    add-int/lit8 v11, v14, -0x7

    and-int/2addr v11, v8

    and-int/lit8 v12, v8, 0x7

    add-int/2addr v11, v12

    shr-int/lit8 v11, v11, 0x3

    .line 1243
    aput-wide v0, v5, v11

    .line 1028
    aput v10, v6, v14

    .line 1029
    aget v0, v3, v9

    aput v0, v7, v14

    goto :goto_1

    :cond_0
    move-object/from16 v20, v1

    :goto_1
    add-int/lit8 v9, v9, 0x1

    move-object/from16 v0, p0

    move-object/from16 v1, v20

    goto :goto_0

    :cond_1
    return-void
.end method

.method public final set(FI)V
    .locals 2

    .line 698
    invoke-direct {p0, p1}, Landroidx/collection/MutableFloatIntMap;->findInsertIndex(F)I

    move-result v0

    if-gez v0, :cond_0

    not-int v0, v0

    .line 700
    :cond_0
    iget-object v1, p0, Landroidx/collection/FloatIntMap;->keys:[F

    aput p1, v1, v0

    .line 701
    iget-object p1, p0, Landroidx/collection/FloatIntMap;->values:[I

    aput p2, p1, v0

    return-void
.end method

.method public final trim()I
    .locals 2

    .line 893
    iget v0, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    .line 894
    iget v1, p0, Landroidx/collection/FloatIntMap;->_size:I

    invoke-static {v1}, Landroidx/collection/ScatterMapKt;->unloadedCapacity(I)I

    move-result v1

    invoke-static {v1}, Landroidx/collection/ScatterMapKt;->normalizeCapacity(I)I

    move-result v1

    if-ge v1, v0, :cond_0

    .line 896
    invoke-virtual {p0, v1}, Landroidx/collection/MutableFloatIntMap;->resizeStorage$collection(I)V

    .line 897
    iget v1, p0, Landroidx/collection/FloatIntMap;->_capacity:I

    sub-int/2addr v0, v1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
