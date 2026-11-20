.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;
.super Ljava/lang/Object;
.source "ConvolveImageUnrolled_SB_U8_I8_Div.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)Z
    .locals 4

    .line 57
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    div-int/lit8 v2, v1, 0x2

    const/4 v3, 0x0

    if-ne v0, v2, :cond_6

    rem-int/lit8 v0, v1, 0x2

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    const/4 v0, 0x3

    if-eq v1, v0, :cond_5

    const/4 v0, 0x5

    if-eq v1, v0, :cond_4

    const/4 v0, 0x7

    if-eq v1, v0, :cond_3

    const/16 v0, 0x9

    if-eq v1, v0, :cond_2

    const/16 v0, 0xb

    if-eq v1, v0, :cond_1

    return v3

    .line 65
    :cond_1
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 64
    :cond_2
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 63
    :cond_3
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 62
    :cond_4
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    goto :goto_0

    .line 61
    :cond_5
    invoke-static {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 24

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 261
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 262
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 264
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 265
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 266
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 267
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 268
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 269
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 270
    aget v13, v5, v13

    const/4 v14, 0x7

    .line 271
    aget v14, v5, v14

    const/16 v15, 0x8

    .line 272
    aget v15, v5, v15

    const/16 v16, 0x9

    .line 273
    aget v16, v5, v16

    const/16 v17, 0xa

    .line 274
    aget v5, v5, v17

    .line 276
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 278
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v17

    .line 279
    div-int/lit8 v18, p3, 0x2

    move-object/from16 v19, v2

    .line 282
    :goto_0
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v2, :cond_1

    .line 283
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v6

    add-int v2, p0, v2

    add-int/2addr v2, v4

    .line 284
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int v1, p0, v1

    sub-int/2addr v1, v4

    add-int v20, v1, v17

    sub-int v0, v20, v4

    add-int/2addr v1, v4

    :goto_1
    if-ge v1, v0, :cond_0

    add-int/lit8 v20, v1, 0x1

    move/from16 p0, v0

    .line 289
    aget-byte v0, v19, v1

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int/lit8 v21, v1, 0x2

    move/from16 v22, v0

    .line 290
    aget-byte v0, v19, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, v22, v0

    add-int/lit8 v22, v1, 0x3

    move/from16 v23, v0

    .line 291
    aget-byte v0, v19, v21

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, v23, v0

    add-int/lit8 v21, v1, 0x4

    move/from16 v23, v0

    .line 292
    aget-byte v0, v19, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, v23, v0

    add-int/lit8 v22, v1, 0x5

    move/from16 v23, v0

    .line 293
    aget-byte v0, v19, v21

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, v23, v0

    add-int/lit8 v21, v1, 0x6

    move/from16 v23, v0

    .line 294
    aget-byte v0, v19, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v12

    add-int v0, v23, v0

    add-int/lit8 v22, v1, 0x7

    move/from16 v23, v0

    .line 295
    aget-byte v0, v19, v21

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v13

    add-int v0, v23, v0

    add-int/lit8 v21, v1, 0x8

    move/from16 v23, v0

    .line 296
    aget-byte v0, v19, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v14

    add-int v0, v23, v0

    add-int/lit8 v22, v1, 0x9

    move/from16 v23, v0

    .line 297
    aget-byte v0, v19, v21

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v15

    add-int v0, v23, v0

    add-int/lit8 v1, v1, 0xa

    move/from16 v21, v0

    .line 298
    aget-byte v0, v19, v22

    and-int/lit16 v0, v0, 0xff

    mul-int v0, v0, v16

    add-int v0, v21, v0

    .line 299
    aget-byte v1, v19, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v2, 0x1

    add-int v0, v0, v18

    .line 301
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v2

    move/from16 v0, p0

    move v2, v1

    move/from16 v1, v20

    goto/16 :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 16

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 109
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 110
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 112
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 113
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 114
    aget v5, v5, v9

    .line 116
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 118
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v9

    .line 119
    div-int/lit8 v10, p3, 0x2

    .line 122
    :goto_0
    iget v11, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v11, :cond_1

    .line 123
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v6

    add-int/2addr v11, v12

    add-int/2addr v11, v4

    .line 124
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v6

    add-int/2addr v12, v13

    sub-int/2addr v12, v4

    add-int v13, v12, v9

    sub-int/2addr v13, v4

    add-int/2addr v12, v4

    :goto_1
    if-ge v12, v13, :cond_0

    add-int/lit8 v14, v12, 0x1

    .line 129
    aget-byte v15, v2, v12

    and-int/lit16 v15, v15, 0xff

    mul-int/2addr v15, v7

    add-int/lit8 v12, v12, 0x2

    .line 130
    aget-byte v0, v2, v14

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int/2addr v15, v0

    .line 131
    aget-byte v0, v2, v12

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v5

    add-int/2addr v15, v0

    add-int/lit8 v0, v11, 0x1

    add-int/2addr v15, v10

    .line 133
    div-int v15, v15, p3

    int-to-byte v12, v15

    aput-byte v12, v3, v11

    move v11, v0

    move v12, v14

    move-object/from16 v0, p1

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 141
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 142
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 144
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 145
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 146
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 147
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 148
    aget v5, v5, v11

    .line 150
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 152
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v11

    .line 153
    div-int/lit8 v12, p3, 0x2

    .line 156
    :goto_0
    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v13, :cond_1

    .line 157
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v6

    add-int/2addr v13, v14

    add-int/2addr v13, v4

    .line 158
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v6

    add-int/2addr v14, v15

    sub-int/2addr v14, v4

    add-int v15, v14, v11

    sub-int/2addr v15, v4

    add-int/2addr v14, v4

    :goto_1
    if-ge v14, v15, :cond_0

    add-int/lit8 v16, v14, 0x1

    .line 163
    aget-byte v0, v2, v14

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int/lit8 v17, v14, 0x2

    move/from16 p0, v0

    .line 164
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, p0, v0

    add-int/lit8 v18, v14, 0x3

    move/from16 p0, v0

    .line 165
    aget-byte v0, v2, v17

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, p0, v0

    add-int/lit8 v14, v14, 0x4

    move/from16 p0, v0

    .line 166
    aget-byte v0, v2, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, p0, v0

    .line 167
    aget-byte v14, v2, v14

    and-int/lit16 v14, v14, 0xff

    mul-int/2addr v14, v5

    add-int/2addr v0, v14

    add-int/lit8 v14, v13, 0x1

    add-int/2addr v0, v12

    .line 169
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v13

    move-object/from16 v0, p1

    move v13, v14

    move/from16 v14, v16

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 20

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 177
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 178
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 180
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 181
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 182
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 183
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 184
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 185
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 186
    aget v5, v5, v13

    .line 188
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 190
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v13

    .line 191
    div-int/lit8 v14, p3, 0x2

    .line 194
    :goto_0
    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v15, :cond_1

    .line 195
    iget v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move-object/from16 v16, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v6

    add-int/2addr v15, v2

    add-int/2addr v15, v4

    .line 196
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int/2addr v2, v1

    sub-int/2addr v2, v4

    add-int v1, v2, v13

    sub-int/2addr v1, v4

    add-int/2addr v2, v4

    :goto_1
    if-ge v2, v1, :cond_0

    add-int/lit8 v17, v2, 0x1

    .line 201
    aget-byte v0, v16, v2

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int/lit8 v18, v2, 0x2

    move/from16 p0, v0

    .line 202
    aget-byte v0, v16, v17

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, p0, v0

    add-int/lit8 v19, v2, 0x3

    move/from16 p0, v0

    .line 203
    aget-byte v0, v16, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, p0, v0

    add-int/lit8 v18, v2, 0x4

    move/from16 p0, v0

    .line 204
    aget-byte v0, v16, v19

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, p0, v0

    add-int/lit8 v19, v2, 0x5

    move/from16 p0, v0

    .line 205
    aget-byte v0, v16, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, p0, v0

    add-int/lit8 v2, v2, 0x6

    move/from16 p0, v0

    .line 206
    aget-byte v0, v16, v19

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v12

    add-int v0, p0, v0

    .line 207
    aget-byte v2, v16, v2

    and-int/lit16 v2, v2, 0xff

    mul-int/2addr v2, v5

    add-int/2addr v0, v2

    add-int/lit8 v2, v15, 0x1

    add-int/2addr v0, v14

    .line 209
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v15

    move-object/from16 v0, p1

    move v15, v2

    move/from16 v2, v17

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move-object/from16 v2, v16

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;I)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 217
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 218
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 220
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 221
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 222
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 223
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 224
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 225
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 226
    aget v13, v5, v13

    const/4 v14, 0x7

    .line 227
    aget v14, v5, v14

    const/16 v15, 0x8

    .line 228
    aget v5, v5, v15

    .line 230
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 232
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v15

    .line 233
    div-int/lit8 v16, p3, 0x2

    move-object/from16 v17, v2

    .line 236
    :goto_0
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v2, :cond_1

    .line 237
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v6

    add-int v2, p0, v2

    add-int/2addr v2, v4

    .line 238
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int v1, p0, v1

    sub-int/2addr v1, v4

    add-int v18, v1, v15

    sub-int v0, v18, v4

    add-int/2addr v1, v4

    :goto_1
    if-ge v1, v0, :cond_0

    add-int/lit8 v18, v1, 0x1

    move/from16 p0, v0

    .line 243
    aget-byte v0, v17, v1

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int/lit8 v19, v1, 0x2

    move/from16 v20, v0

    .line 244
    aget-byte v0, v17, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, v20, v0

    add-int/lit8 v20, v1, 0x3

    move/from16 v21, v0

    .line 245
    aget-byte v0, v17, v19

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, v21, v0

    add-int/lit8 v19, v1, 0x4

    move/from16 v21, v0

    .line 246
    aget-byte v0, v17, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, v21, v0

    add-int/lit8 v20, v1, 0x5

    move/from16 v21, v0

    .line 247
    aget-byte v0, v17, v19

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, v21, v0

    add-int/lit8 v19, v1, 0x6

    move/from16 v21, v0

    .line 248
    aget-byte v0, v17, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v12

    add-int v0, v21, v0

    add-int/lit8 v20, v1, 0x7

    move/from16 v21, v0

    .line 249
    aget-byte v0, v17, v19

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v13

    add-int v0, v21, v0

    add-int/lit8 v1, v1, 0x8

    move/from16 v19, v0

    .line 250
    aget-byte v0, v17, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v14

    add-int v0, v19, v0

    .line 251
    aget-byte v1, v17, v1

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v2, 0x1

    add-int v0, v0, v16

    .line 253
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v2

    move/from16 v0, p0

    move v2, v1

    move/from16 v1, v18

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)Z
    .locals 4

    .line 75
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    div-int/lit8 v2, v1, 0x2

    const/4 v3, 0x0

    if-ne v0, v2, :cond_6

    rem-int/lit8 v0, v1, 0x2

    if-nez v0, :cond_0

    goto :goto_1

    :cond_0
    const/4 v0, 0x3

    if-eq v1, v0, :cond_5

    const/4 v0, 0x5

    if-eq v1, v0, :cond_4

    const/4 v0, 0x7

    if-eq v1, v0, :cond_3

    const/16 v0, 0x9

    if-eq v1, v0, :cond_2

    const/16 v0, 0xb

    if-eq v1, v0, :cond_1

    return v3

    .line 83
    :cond_1
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 82
    :cond_2
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 81
    :cond_3
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 80
    :cond_4
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    goto :goto_0

    .line 79
    :cond_5
    invoke-static {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_U8_I8_Div;->vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 24

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 497
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 498
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 500
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 501
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 502
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 503
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 504
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 505
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 506
    aget v12, v5, v12

    const/4 v13, 0x7

    .line 507
    aget v13, v5, v13

    const/16 v14, 0x8

    .line 508
    aget v14, v5, v14

    const/16 v15, 0x9

    .line 509
    aget v15, v5, v15

    const/16 v16, 0xa

    .line 510
    aget v5, v5, v16

    .line 512
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 514
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v16

    .line 515
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v17

    .line 516
    div-int/lit8 v18, p3, 0x2

    move-object/from16 p4, v2

    sub-int v2, v17, v4

    move-object/from16 v17, v3

    move v3, v4

    :goto_0
    if-ge v3, v2, :cond_1

    move/from16 p0, v2

    .line 522
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 v19, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v3

    add-int v2, v19, v2

    .line 523
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v19, v3, v4

    move/from16 v20, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v19, v19, v1

    add-int v1, v20, v19

    move/from16 v19, v1

    add-int v1, v19, v16

    move/from16 v23, v19

    move/from16 v19, v2

    move/from16 v2, v23

    :goto_1
    if-ge v2, v1, :cond_0

    move/from16 v20, v1

    .line 529
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v6

    move/from16 v21, v1

    .line 530
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v22, v2, v1

    .line 531
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 533
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 535
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 537
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 539
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 541
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v12

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 543
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v13

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 545
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v14

    add-int v0, v21, v0

    add-int v22, v22, v1

    move/from16 v21, v0

    .line 547
    aget-byte v0, p4, v22

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v15

    add-int v0, v21, v0

    add-int v22, v22, v1

    .line 549
    aget-byte v1, p4, v22

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v19, 0x1

    add-int v0, v0, v18

    .line 551
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v17, v19

    add-int/lit8 v2, v2, 0x1

    move-object/from16 v0, p1

    move/from16 v19, v1

    move/from16 v1, v20

    goto/16 :goto_1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    move/from16 v2, p0

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 17

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 309
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 310
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 312
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 313
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 314
    aget v5, v5, v8

    .line 316
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 318
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    .line 319
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v9

    .line 320
    div-int/lit8 v10, p3, 0x2

    sub-int/2addr v9, v4

    move v11, v4

    :goto_0
    if-ge v11, v9, :cond_1

    .line 326
    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v11

    add-int/2addr v12, v13

    .line 327
    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v14, v11, v4

    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v15

    add-int/2addr v13, v14

    add-int v14, v13, v8

    :goto_1
    if-ge v13, v14, :cond_0

    .line 333
    aget-byte v15, v2, v13

    and-int/lit16 v15, v15, 0xff

    mul-int/2addr v15, v6

    .line 334
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v16, v13, v1

    .line 335
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int/2addr v15, v0

    add-int v16, v16, v1

    .line 337
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v5

    add-int/2addr v15, v0

    add-int/lit8 v0, v12, 0x1

    add-int/2addr v15, v10

    .line 339
    div-int v15, v15, p3

    int-to-byte v1, v15

    aput-byte v1, v3, v12

    add-int/lit8 v13, v13, 0x1

    move-object/from16 v1, p2

    move v12, v0

    move-object/from16 v0, p1

    goto :goto_1

    :cond_0
    add-int/lit8 v11, v11, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 17

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 347
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 348
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 350
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 351
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 352
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 353
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 354
    aget v5, v5, v10

    .line 356
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 358
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v10

    .line 359
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v11

    .line 360
    div-int/lit8 v12, p3, 0x2

    sub-int/2addr v11, v4

    move v13, v4

    :goto_0
    if-ge v13, v11, :cond_1

    .line 366
    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v13

    add-int/2addr v14, v15

    .line 367
    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v16, v13, v4

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v16, v16, v1

    add-int v15, v15, v16

    add-int v1, v15, v10

    :goto_1
    if-ge v15, v1, :cond_0

    move/from16 p0, v1

    .line 373
    aget-byte v1, v2, v15

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v6

    move/from16 p4, v1

    .line 374
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v16, v15, v1

    .line 375
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int v0, p4, v0

    add-int v16, v16, v1

    move/from16 p4, v0

    .line 377
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, p4, v0

    add-int v16, v16, v1

    move/from16 p4, v0

    .line 379
    aget-byte v0, v2, v16

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, p4, v0

    add-int v16, v16, v1

    .line 381
    aget-byte v1, v2, v16

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v14, 0x1

    add-int/2addr v0, v12

    .line 383
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v14

    add-int/lit8 v15, v15, 0x1

    move-object/from16 v0, p1

    move v14, v1

    move/from16 v1, p0

    goto :goto_1

    :cond_0
    add-int/lit8 v13, v13, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 391
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 392
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 394
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 395
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 396
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 397
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 398
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 399
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 400
    aget v5, v5, v12

    .line 402
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 404
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v12

    .line 405
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v13

    .line 406
    div-int/lit8 v14, p3, 0x2

    sub-int/2addr v13, v4

    move v15, v4

    :goto_0
    if-ge v15, v13, :cond_1

    move-object/from16 p4, v2

    .line 412
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v15

    add-int v2, p0, v2

    .line 413
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v16, v15, v4

    move/from16 p0, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v16, v16, v1

    add-int v1, p0, v16

    move/from16 p0, v1

    add-int v1, p0, v12

    move/from16 v16, v2

    move/from16 v2, p0

    :goto_1
    if-ge v2, v1, :cond_0

    move/from16 p0, v1

    .line 419
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v6

    move/from16 v17, v1

    .line 420
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v18, v2, v1

    .line 421
    aget-byte v0, p4, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int v0, v17, v0

    add-int v18, v18, v1

    move/from16 v17, v0

    .line 423
    aget-byte v0, p4, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, v17, v0

    add-int v18, v18, v1

    move/from16 v17, v0

    .line 425
    aget-byte v0, p4, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, v17, v0

    add-int v18, v18, v1

    move/from16 v17, v0

    .line 427
    aget-byte v0, p4, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, v17, v0

    add-int v18, v18, v1

    move/from16 v17, v0

    .line 429
    aget-byte v0, p4, v18

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, v17, v0

    add-int v18, v18, v1

    .line 431
    aget-byte v1, p4, v18

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v16, 0x1

    add-int/2addr v0, v14

    .line 433
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v16

    add-int/lit8 v2, v2, 0x1

    move-object/from16 v0, p1

    move/from16 v16, v1

    move/from16 v1, p0

    goto :goto_1

    :cond_0
    add-int/lit8 v15, v15, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    move-object/from16 v2, p4

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;ILcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;)V
    .locals 22

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 441
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    .line 442
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    move-object/from16 v4, p0

    .line 444
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 445
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 446
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 447
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 448
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 449
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 450
    aget v12, v5, v12

    const/4 v13, 0x7

    .line 451
    aget v13, v5, v13

    const/16 v14, 0x8

    .line 452
    aget v5, v5, v14

    .line 454
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 456
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v14

    .line 457
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v15

    .line 458
    div-int/lit8 v16, p3, 0x2

    sub-int/2addr v15, v4

    move-object/from16 p4, v2

    move v2, v4

    :goto_0
    if-ge v2, v15, :cond_1

    move/from16 p0, v2

    .line 464
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 v17, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v2, v2, p0

    add-int v2, v17, v2

    .line 465
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v17, p0, v4

    move/from16 v18, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v17, v17, v1

    add-int v1, v18, v17

    move/from16 v17, v1

    add-int v1, v17, v14

    move/from16 v21, v17

    move/from16 v17, v2

    move/from16 v2, v21

    :goto_1
    if-ge v2, v1, :cond_0

    move/from16 v18, v1

    .line 471
    aget-byte v1, p4, v2

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v6

    move/from16 v19, v1

    .line 472
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v20, v2, v1

    .line 473
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v7

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 475
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v8

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 477
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v9

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 479
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v10

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 481
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v11

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 483
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v12

    add-int v0, v19, v0

    add-int v20, v20, v1

    move/from16 v19, v0

    .line 485
    aget-byte v0, p4, v20

    and-int/lit16 v0, v0, 0xff

    mul-int/2addr v0, v13

    add-int v0, v19, v0

    add-int v20, v20, v1

    .line 487
    aget-byte v1, p4, v20

    and-int/lit16 v1, v1, 0xff

    mul-int/2addr v1, v5

    add-int/2addr v0, v1

    add-int/lit8 v1, v17, 0x1

    add-int v0, v0, v16

    .line 489
    div-int v0, v0, p3

    int-to-byte v0, v0

    aput-byte v0, v3, v17

    add-int/lit8 v2, v2, 0x1

    move-object/from16 v0, p1

    move/from16 v17, v1

    move/from16 v1, v18

    goto :goto_1

    :cond_0
    add-int/lit8 v2, p0, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method
