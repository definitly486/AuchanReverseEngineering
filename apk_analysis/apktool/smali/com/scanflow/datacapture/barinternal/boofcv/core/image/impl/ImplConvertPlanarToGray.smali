.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/impl/ImplConvertPlanarToGray;
.super Ljava/lang/Object;
.source "ImplConvertPlanarToGray.java"


# direct methods
.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 13

    .line 297
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 300
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_2

    .line 302
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    .line 303
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    const/4 v4, 0x2

    .line 304
    invoke-virtual {p0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    move v5, v1

    .line 307
    :goto_0
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v5, v6, :cond_5

    .line 308
    invoke-virtual {p0, v1, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v6

    .line 309
    invoke-virtual {p1, v1, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v7

    move v8, v1

    .line 311
    :goto_1
    iget v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v8, v9, :cond_1

    .line 312
    iget-object v9, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v9, v9, v6

    .line 313
    iget-object v10, v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v10, v10, v6

    add-float/2addr v9, v10

    .line 314
    iget-object v10, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v10, v10, v6

    add-float/2addr v9, v10

    .line 316
    iget-object v10, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v11, v7, 0x1

    const/high16 v12, 0x40400000    # 3.0f

    div-float/2addr v9, v12

    aput v9, v10, v7

    add-int/lit8 v8, v8, 0x1

    add-int/2addr v6, v2

    move v7, v11

    goto :goto_1

    :cond_1
    add-int/lit8 v5, v5, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 322
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 323
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 324
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v1

    .line 326
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_4

    const/4 v6, 0x0

    move v7, v1

    :goto_4
    if-ge v7, v0, :cond_3

    .line 329
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v8, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    aget-object v8, v8, v7

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    aget v8, v8, v3

    add-float/2addr v6, v8

    add-int/lit8 v7, v7, 0x1

    goto :goto_4

    .line 331
    :cond_3
    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    add-int/lit8 v8, v4, 0x1

    int-to-float v9, v0

    div-float/2addr v6, v9

    aput v6, v7, v4

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v3, v3, 0x1

    move v4, v8

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;)V
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 339
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v2

    const/4 v3, 0x0

    const/4 v4, 0x1

    if-ne v2, v4, :cond_0

    .line 342
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v5, 0x3

    if-ne v2, v5, :cond_2

    .line 344
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    .line 345
    invoke-virtual {v0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    const/4 v6, 0x2

    .line 346
    invoke-virtual {v0, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    move v7, v3

    .line 349
    :goto_0
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v7, v8, :cond_5

    .line 350
    invoke-virtual {v0, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    .line 351
    invoke-virtual {v1, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v9

    move v10, v3

    .line 353
    :goto_1
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v10, v11, :cond_1

    .line 354
    iget-object v11, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v12, v11, v8

    .line 355
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v14, v11, v8

    add-double/2addr v12, v14

    .line 356
    iget-object v11, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v14, v11, v8

    add-double/2addr v12, v14

    .line 358
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v14, v9, 0x1

    const-wide/high16 v15, 0x4008000000000000L    # 3.0

    div-double/2addr v12, v15

    aput-wide v12, v11, v9

    add-int/lit8 v10, v10, 0x1

    add-int/2addr v8, v4

    move v9, v14

    goto :goto_1

    :cond_1
    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    :cond_2
    move v4, v3

    .line 364
    :goto_2
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v4, v5, :cond_5

    .line 365
    invoke-virtual {v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    .line 366
    invoke-virtual {v1, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v6

    move v7, v3

    .line 368
    :goto_3
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v7, v8, :cond_4

    const-wide/16 v8, 0x0

    move v10, v3

    :goto_4
    if-ge v10, v2, :cond_3

    .line 371
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v11, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    aget-object v11, v11, v10

    iget-object v11, v11, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    aget-wide v12, v11, v5

    add-double/2addr v8, v12

    add-int/lit8 v10, v10, 0x1

    goto :goto_4

    .line 373
    :cond_3
    iget-object v10, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;->data:[D

    add-int/lit8 v11, v6, 0x1

    int-to-double v12, v2

    div-double/2addr v8, v12

    aput-wide v8, v10, v6

    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v5, v5, 0x1

    move v6, v11

    goto :goto_3

    :cond_4
    add-int/lit8 v4, v4, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;)V
    .locals 13

    .line 171
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 174
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_2

    .line 176
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    .line 177
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    const/4 v5, 0x2

    .line 178
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    move v6, v1

    .line 181
    :goto_0
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 182
    invoke-virtual {p0, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v7

    .line 183
    invoke-virtual {p1, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    move v9, v1

    .line 185
    :goto_1
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v9, v10, :cond_1

    .line 186
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v10, v10, v7

    .line 187
    iget-object v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v11, v11, v7

    add-int/2addr v10, v11

    .line 188
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v11, v11, v7

    add-int/2addr v10, v11

    .line 190
    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v12, v8, 0x1

    div-int/2addr v10, v3

    int-to-short v10, v10

    aput-short v10, v11, v8

    add-int/lit8 v9, v9, 0x1

    add-int/2addr v7, v2

    move v8, v12

    goto :goto_1

    :cond_1
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 196
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 197
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 198
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v1

    .line 200
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_4

    move v6, v1

    move v7, v6

    :goto_4
    if-ge v6, v0, :cond_3

    .line 203
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v8, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    aget-object v8, v8, v6

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v8, v8, v3

    add-int/2addr v7, v8

    add-int/lit8 v6, v6, 0x1

    goto :goto_4

    .line 205
    :cond_3
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-short v7, v7

    aput-short v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v3, v3, 0x1

    move v4, v8

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;)V
    .locals 13

    .line 213
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 216
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_2

    .line 218
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    .line 219
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    const/4 v5, 0x2

    .line 220
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    move v6, v1

    .line 223
    :goto_0
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 224
    invoke-virtual {p0, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v7

    .line 225
    invoke-virtual {p1, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    move v9, v1

    .line 227
    :goto_1
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v9, v10, :cond_1

    .line 228
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v10, v10, v7

    .line 229
    iget-object v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v11, v11, v7

    add-int/2addr v10, v11

    .line 230
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v11, v11, v7

    add-int/2addr v10, v11

    .line 232
    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v12, v8, 0x1

    div-int/2addr v10, v3

    aput v10, v11, v8

    add-int/lit8 v9, v9, 0x1

    add-int/2addr v7, v2

    move v8, v12

    goto :goto_1

    :cond_1
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 238
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 239
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 240
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v1

    .line 242
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_4

    move v6, v1

    move v7, v6

    :goto_4
    if-ge v6, v0, :cond_3

    .line 245
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v8, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    aget-object v8, v8, v6

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    aget v8, v8, v3

    add-int/2addr v7, v8

    add-int/lit8 v6, v6, 0x1

    goto :goto_4

    .line 247
    :cond_3
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;->data:[I

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    aput v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v3, v3, 0x1

    move v4, v8

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;)V
    .locals 17

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    .line 255
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v2

    const/4 v3, 0x0

    const/4 v4, 0x1

    if-ne v2, v4, :cond_0

    .line 258
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v5, 0x3

    if-ne v2, v5, :cond_2

    .line 260
    invoke-virtual {v0, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    .line 261
    invoke-virtual {v0, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    const/4 v6, 0x2

    .line 262
    invoke-virtual {v0, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    move v7, v3

    .line 265
    :goto_0
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v7, v8, :cond_5

    .line 266
    invoke-virtual {v0, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    .line 267
    invoke-virtual {v1, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v9

    move v10, v3

    .line 269
    :goto_1
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v10, v11, :cond_1

    .line 270
    iget-object v11, v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v12, v11, v8

    .line 271
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v14, v11, v8

    add-long/2addr v12, v14

    .line 272
    iget-object v11, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v14, v11, v8

    add-long/2addr v12, v14

    .line 274
    iget-object v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v14, v9, 0x1

    const-wide/16 v15, 0x3

    div-long/2addr v12, v15

    aput-wide v12, v11, v9

    add-int/lit8 v10, v10, 0x1

    add-int/2addr v8, v4

    move v9, v14

    goto :goto_1

    :cond_1
    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    :cond_2
    move v4, v3

    .line 280
    :goto_2
    iget v5, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v4, v5, :cond_5

    .line 281
    invoke-virtual {v0, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    .line 282
    invoke-virtual {v1, v3, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v6

    move v7, v3

    .line 284
    :goto_3
    iget v8, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v7, v8, :cond_4

    const-wide/16 v8, 0x0

    move v10, v3

    :goto_4
    if-ge v10, v2, :cond_3

    .line 287
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v11, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    aget-object v11, v11, v10

    iget-object v11, v11, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    aget-wide v12, v11, v5

    add-long/2addr v8, v12

    add-int/lit8 v10, v10, 0x1

    goto :goto_4

    .line 289
    :cond_3
    iget-object v10, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;->data:[J

    add-int/lit8 v11, v6, 0x1

    int-to-long v12, v2

    div-long/2addr v8, v12

    aput-wide v8, v10, v6

    add-int/lit8 v7, v7, 0x1

    add-int/lit8 v5, v5, 0x1

    move v6, v11

    goto :goto_3

    :cond_4
    add-int/lit8 v4, v4, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;)V
    .locals 13

    .line 87
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 90
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_2

    .line 92
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    .line 93
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    const/4 v5, 0x2

    .line 94
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    move v6, v1

    .line 97
    :goto_0
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 98
    invoke-virtual {p0, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v7

    .line 99
    invoke-virtual {p1, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    move v9, v1

    .line 101
    :goto_1
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v9, v10, :cond_1

    .line 102
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v10, v10, v7

    .line 103
    iget-object v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v11, v11, v7

    add-int/2addr v10, v11

    .line 104
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v11, v11, v7

    add-int/2addr v10, v11

    .line 106
    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v12, v8, 0x1

    div-int/2addr v10, v3

    int-to-byte v10, v10

    aput-byte v10, v11, v8

    add-int/lit8 v9, v9, 0x1

    add-int/2addr v7, v2

    move v8, v12

    goto :goto_1

    :cond_1
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 112
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 113
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 114
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v1

    .line 116
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_4

    move v6, v1

    move v7, v6

    :goto_4
    if-ge v6, v0, :cond_3

    .line 119
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v8, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    aget-object v8, v8, v6

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v8, v8, v3

    add-int/2addr v7, v8

    add-int/lit8 v6, v6, 0x1

    goto :goto_4

    .line 121
    :cond_3
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-byte v7, v7

    aput-byte v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v3, v3, 0x1

    move v4, v8

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;)V
    .locals 14

    .line 129
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 132
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    const v4, 0xffff

    if-ne v0, v3, :cond_2

    .line 134
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    .line 135
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    const/4 v6, 0x2

    .line 136
    invoke-virtual {p0, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v6

    check-cast v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    move v7, v1

    .line 139
    :goto_0
    iget v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v7, v8, :cond_5

    .line 140
    invoke-virtual {p0, v1, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    .line 141
    invoke-virtual {p1, v1, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v9

    move v10, v1

    .line 143
    :goto_1
    iget v11, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v10, v11, :cond_1

    .line 144
    iget-object v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v11, v11, v8

    and-int/2addr v11, v4

    .line 145
    iget-object v12, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v12, v12, v8

    and-int/2addr v12, v4

    add-int/2addr v11, v12

    .line 146
    iget-object v12, v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v12, v12, v8

    and-int/2addr v12, v4

    add-int/2addr v11, v12

    .line 148
    iget-object v12, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v13, v9, 0x1

    div-int/2addr v11, v3

    int-to-short v11, v11

    aput-short v11, v12, v9

    add-int/lit8 v10, v10, 0x1

    add-int/2addr v8, v2

    move v9, v13

    goto :goto_1

    :cond_1
    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 154
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 155
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 156
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v5

    move v6, v1

    .line 158
    :goto_3
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v6, v7, :cond_4

    move v7, v1

    move v8, v7

    :goto_4
    if-ge v7, v0, :cond_3

    .line 161
    iget-object v9, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v9, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    aget-object v9, v9, v7

    iget-object v9, v9, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    aget-short v9, v9, v3

    and-int/2addr v9, v4

    add-int/2addr v8, v9

    add-int/lit8 v7, v7, 0x1

    goto :goto_4

    .line 163
    :cond_3
    iget-object v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    add-int/lit8 v9, v5, 0x1

    div-int/2addr v8, v0

    int-to-short v8, v8

    aput-short v8, v7, v5

    add-int/lit8 v6, v6, 0x1

    add-int/lit8 v3, v3, 0x1

    move v5, v9

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method

.method public static average(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 13

    .line 45
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getNumBands()I

    move-result v0

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    .line 48
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-virtual {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    return-void

    :cond_0
    const/4 v3, 0x3

    if-ne v0, v3, :cond_2

    .line 50
    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    .line 51
    invoke-virtual {p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    const/4 v5, 0x2

    .line 52
    invoke-virtual {p0, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->getBand(I)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object v5

    check-cast v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    move v6, v1

    .line 55
    :goto_0
    iget v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v7, :cond_5

    .line 56
    invoke-virtual {p0, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v7

    .line 57
    invoke-virtual {p1, v1, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v8

    move v9, v1

    .line 59
    :goto_1
    iget v10, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v9, v10, :cond_1

    .line 60
    iget-object v10, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v10, v10, v7

    and-int/lit16 v10, v10, 0xff

    .line 61
    iget-object v11, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v11, v11, v7

    and-int/lit16 v11, v11, 0xff

    add-int/2addr v10, v11

    .line 62
    iget-object v11, v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v11, v11, v7

    and-int/lit16 v11, v11, 0xff

    add-int/2addr v10, v11

    .line 64
    iget-object v11, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v12, v8, 0x1

    div-int/2addr v10, v3

    int-to-byte v10, v10

    aput-byte v10, v11, v8

    add-int/lit8 v9, v9, 0x1

    add-int/2addr v7, v2

    move v8, v12

    goto :goto_1

    :cond_1
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_2
    move v2, v1

    .line 70
    :goto_2
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v2, v3, :cond_5

    .line 71
    invoke-virtual {p0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v3

    .line 72
    invoke-virtual {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result v4

    move v5, v1

    .line 74
    :goto_3
    iget v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->width:I

    if-ge v5, v6, :cond_4

    move v6, v1

    move v7, v6

    :goto_4
    if-ge v6, v0, :cond_3

    .line 77
    iget-object v8, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;->bands:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    check-cast v8, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    aget-object v8, v8, v6

    iget-object v8, v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    aget-byte v8, v8, v3

    and-int/lit16 v8, v8, 0xff

    add-int/2addr v7, v8

    add-int/lit8 v6, v6, 0x1

    goto :goto_4

    .line 79
    :cond_3
    iget-object v6, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    add-int/lit8 v8, v4, 0x1

    div-int/2addr v7, v0

    int-to-byte v7, v7

    aput-byte v7, v6, v4

    add-int/lit8 v5, v5, 0x1

    add-int/lit8 v3, v3, 0x1

    move v4, v8

    goto :goto_3

    :cond_4
    add-int/lit8 v2, v2, 0x1

    goto :goto_2

    :cond_5
    return-void
.end method
