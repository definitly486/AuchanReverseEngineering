.class public abstract Lcom/scanflow/datacapture/barinternal/org/ddogleg/sorting/QuickSelect;
.super Ljava/lang/Object;
.source "QuickSelect.java"


# direct methods
.method public static selectIndex([DII[I)I
    .locals 11

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    if-ge v1, p2, :cond_0

    .line 468
    aput v1, p3, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    add-int/lit8 p2, p2, -0x1

    :cond_1
    :goto_1
    add-int/lit8 v1, v0, 0x1

    if-gt p2, v1, :cond_3

    if-ne p2, v1, :cond_2

    .line 481
    aget v1, p3, p2

    aget-wide v2, p0, v1

    aget v4, p3, v0

    aget-wide v5, p0, v4

    cmpg-double p0, v2, v5

    if-gez p0, :cond_2

    .line 483
    aput v1, p3, v0

    .line 484
    aput v4, p3, p2

    .line 486
    :cond_2
    aget p0, p3, p1

    return p0

    :cond_3
    add-int v2, v0, p2

    shr-int/lit8 v2, v2, 0x1

    .line 491
    aget v3, p3, v2

    .line 492
    aget v4, p3, v1

    aput v4, p3, v2

    .line 493
    aput v3, p3, v1

    .line 495
    aget v2, p3, v0

    aget-wide v3, p0, v2

    aget v5, p3, p2

    aget-wide v6, p0, v5

    cmpl-double v3, v3, v6

    if-lez v3, :cond_4

    .line 497
    aput v5, p3, v0

    .line 498
    aput v2, p3, p2

    .line 501
    :cond_4
    aget v2, p3, v1

    aget-wide v3, p0, v2

    aget v5, p3, p2

    aget-wide v6, p0, v5

    cmpl-double v3, v3, v6

    if-lez v3, :cond_5

    .line 503
    aput v5, p3, v1

    .line 504
    aput v2, p3, p2

    .line 507
    :cond_5
    aget v2, p3, v0

    aget-wide v3, p0, v2

    aget v5, p3, v1

    aget-wide v6, p0, v5

    cmpl-double v3, v3, v6

    if-lez v3, :cond_6

    .line 509
    aput v2, p3, v1

    .line 510
    aput v5, p3, v0

    .line 515
    :cond_6
    aget v2, p3, v1

    move v4, p2

    move v3, v1

    :cond_7
    :goto_2
    add-int/lit8 v3, v3, 0x1

    .line 518
    aget v5, p3, v3

    aget-wide v5, p0, v5

    aget-wide v7, p0, v2

    cmpg-double v5, v5, v7

    if-ltz v5, :cond_7

    :goto_3
    add-int/lit8 v5, v4, -0x1

    .line 519
    aget v6, p3, v5

    aget-wide v7, p0, v6

    aget-wide v9, p0, v2

    cmpl-double v7, v7, v9

    if-gtz v7, :cond_a

    if-ge v5, v3, :cond_9

    .line 525
    aput v6, p3, v1

    .line 526
    aput v2, p3, v5

    if-lt v5, p1, :cond_8

    add-int/lit8 v4, v4, -0x2

    move p2, v4

    :cond_8
    if-gt v5, p1, :cond_1

    move v0, v3

    goto :goto_1

    .line 521
    :cond_9
    aget v4, p3, v3

    .line 522
    aput v6, p3, v3

    .line 523
    aput v4, p3, v5

    move v4, v5

    goto :goto_2

    :cond_a
    move v4, v5

    goto :goto_3
.end method
