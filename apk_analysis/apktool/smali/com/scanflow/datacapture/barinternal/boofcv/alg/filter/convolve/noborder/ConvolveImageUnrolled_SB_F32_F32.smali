.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;
.super Ljava/lang/Object;
.source "ConvolveImageUnrolled_SB_F32_F32.java"


# direct methods
.method public static horizontal(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z
    .locals 4

    .line 52
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

    .line 60
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 59
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 58
    :cond_3
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 57
    :cond_4
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 56
    :cond_5
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static horizontal11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 23

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 252
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 253
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 255
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 256
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 257
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 258
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 259
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 260
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 261
    aget v13, v5, v13

    const/4 v14, 0x7

    .line 262
    aget v14, v5, v14

    const/16 v15, 0x8

    .line 263
    aget v15, v5, v15

    const/16 v16, 0x9

    .line 264
    aget v16, v5, v16

    const/16 v17, 0xa

    .line 265
    aget v5, v5, v17

    .line 267
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 269
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v17

    move-object/from16 v18, v2

    .line 272
    :goto_0
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v2, :cond_1

    .line 273
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v6

    add-int v2, p0, v2

    add-int/2addr v2, v4

    .line 274
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int v1, p0, v1

    sub-int/2addr v1, v4

    add-int v19, v1, v17

    sub-int v0, v19, v4

    add-int/2addr v1, v4

    :goto_1
    if-ge v1, v0, :cond_0

    add-int/lit8 v19, v1, 0x1

    .line 279
    aget v20, v18, v1

    mul-float v20, v20, v7

    add-int/lit8 v21, v1, 0x2

    .line 280
    aget v22, v18, v19

    mul-float v22, v22, v8

    add-float v20, v20, v22

    add-int/lit8 v22, v1, 0x3

    .line 281
    aget v21, v18, v21

    mul-float v21, v21, v9

    add-float v20, v20, v21

    add-int/lit8 v21, v1, 0x4

    .line 282
    aget v22, v18, v22

    mul-float v22, v22, v10

    add-float v20, v20, v22

    add-int/lit8 v22, v1, 0x5

    .line 283
    aget v21, v18, v21

    mul-float v21, v21, v11

    add-float v20, v20, v21

    add-int/lit8 v21, v1, 0x6

    .line 284
    aget v22, v18, v22

    mul-float v22, v22, v12

    add-float v20, v20, v22

    add-int/lit8 v22, v1, 0x7

    .line 285
    aget v21, v18, v21

    mul-float v21, v21, v13

    add-float v20, v20, v21

    add-int/lit8 v21, v1, 0x8

    .line 286
    aget v22, v18, v22

    mul-float v22, v22, v14

    add-float v20, v20, v22

    add-int/lit8 v22, v1, 0x9

    .line 287
    aget v21, v18, v21

    mul-float v21, v21, v15

    add-float v20, v20, v21

    add-int/lit8 v1, v1, 0xa

    .line 288
    aget v21, v18, v22

    mul-float v21, v21, v16

    add-float v20, v20, v21

    .line 289
    aget v1, v18, v1

    mul-float/2addr v1, v5

    add-float v20, v20, v1

    add-int/lit8 v1, v2, 0x1

    .line 291
    aput v20, v3, v2

    move v2, v1

    move/from16 v1, v19

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 13

    .line 104
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 105
    iget-object v1, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 107
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v3, 0x0

    aget v4, v2, v3

    const/4 v5, 0x1

    .line 108
    aget v5, v2, v5

    const/4 v6, 0x2

    .line 109
    aget v2, v2, v6

    .line 111
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result p0

    .line 113
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v6

    .line 116
    :goto_0
    iget v7, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v3, v7, :cond_1

    .line 117
    iget v7, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v8, p2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v8, v3

    add-int/2addr v7, v8

    add-int/2addr v7, p0

    .line 118
    iget v8, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v9, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v9, v3

    add-int/2addr v8, v9

    sub-int/2addr v8, p0

    add-int v9, v8, v6

    sub-int/2addr v9, p0

    add-int/2addr v8, p0

    :goto_1
    if-ge v8, v9, :cond_0

    add-int/lit8 v10, v8, 0x1

    .line 123
    aget v11, v0, v8

    mul-float/2addr v11, v4

    add-int/lit8 v8, v8, 0x2

    .line 124
    aget v12, v0, v10

    mul-float/2addr v12, v5

    add-float/2addr v11, v12

    .line 125
    aget v8, v0, v8

    mul-float/2addr v8, v2

    add-float/2addr v11, v8

    add-int/lit8 v8, v7, 0x1

    .line 127
    aput v11, v1, v7

    move v7, v8

    move v8, v10

    goto :goto_1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 19

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 135
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 136
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 138
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 139
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 140
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 141
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 142
    aget v5, v5, v11

    .line 144
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 146
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v11

    .line 149
    :goto_0
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v12, :cond_1

    .line 150
    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v6

    add-int/2addr v12, v13

    add-int/2addr v12, v4

    .line 151
    iget v13, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v6

    add-int/2addr v13, v14

    sub-int/2addr v13, v4

    add-int v14, v13, v11

    sub-int/2addr v14, v4

    add-int/2addr v13, v4

    :goto_1
    if-ge v13, v14, :cond_0

    add-int/lit8 v15, v13, 0x1

    .line 156
    aget v16, v2, v13

    mul-float v16, v16, v7

    add-int/lit8 v17, v13, 0x2

    .line 157
    aget v18, v2, v15

    mul-float v18, v18, v8

    add-float v16, v16, v18

    add-int/lit8 v18, v13, 0x3

    .line 158
    aget v17, v2, v17

    mul-float v17, v17, v9

    add-float v16, v16, v17

    add-int/lit8 v13, v13, 0x4

    .line 159
    aget v17, v2, v18

    mul-float v17, v17, v10

    add-float v16, v16, v17

    .line 160
    aget v13, v2, v13

    mul-float/2addr v13, v5

    add-float v16, v16, v13

    add-int/lit8 v13, v12, 0x1

    .line 162
    aput v16, v3, v12

    move v12, v13

    move v13, v15

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 20

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 170
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 171
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 173
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 174
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 175
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 176
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 177
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 178
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 179
    aget v5, v5, v13

    .line 181
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 183
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v13

    .line 186
    :goto_0
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v14, :cond_1

    .line 187
    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v6

    add-int/2addr v14, v15

    add-int/2addr v14, v4

    .line 188
    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int/2addr v15, v1

    sub-int/2addr v15, v4

    add-int v1, v15, v13

    sub-int/2addr v1, v4

    add-int/2addr v15, v4

    :goto_1
    if-ge v15, v1, :cond_0

    add-int/lit8 v16, v15, 0x1

    .line 193
    aget v17, v2, v15

    mul-float v17, v17, v7

    add-int/lit8 v18, v15, 0x2

    .line 194
    aget v19, v2, v16

    mul-float v19, v19, v8

    add-float v17, v17, v19

    add-int/lit8 v19, v15, 0x3

    .line 195
    aget v18, v2, v18

    mul-float v18, v18, v9

    add-float v17, v17, v18

    add-int/lit8 v18, v15, 0x4

    .line 196
    aget v19, v2, v19

    mul-float v19, v19, v10

    add-float v17, v17, v19

    add-int/lit8 v19, v15, 0x5

    .line 197
    aget v18, v2, v18

    mul-float v18, v18, v11

    add-float v17, v17, v18

    add-int/lit8 v15, v15, 0x6

    .line 198
    aget v18, v2, v19

    mul-float v18, v18, v12

    add-float v17, v17, v18

    .line 199
    aget v15, v2, v15

    mul-float/2addr v15, v5

    add-float v17, v17, v15

    add-int/lit8 v15, v14, 0x1

    .line 201
    aput v17, v3, v14

    move v14, v15

    move/from16 v15, v16

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static horizontal9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 21

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 209
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 210
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 212
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v7, v5, v6

    const/4 v8, 0x1

    .line 213
    aget v8, v5, v8

    const/4 v9, 0x2

    .line 214
    aget v9, v5, v9

    const/4 v10, 0x3

    .line 215
    aget v10, v5, v10

    const/4 v11, 0x4

    .line 216
    aget v11, v5, v11

    const/4 v12, 0x5

    .line 217
    aget v12, v5, v12

    const/4 v13, 0x6

    .line 218
    aget v13, v5, v13

    const/4 v14, 0x7

    .line 219
    aget v14, v5, v14

    const/16 v15, 0x8

    .line 220
    aget v5, v5, v15

    .line 222
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 224
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v15

    move-object/from16 v16, v2

    .line 227
    :goto_0
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->height:I

    if-ge v6, v2, :cond_1

    .line 228
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v6

    add-int v2, p0, v2

    add-int/2addr v2, v4

    .line 229
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 p0, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v1, v6

    add-int v1, p0, v1

    sub-int/2addr v1, v4

    add-int v17, v1, v15

    sub-int v0, v17, v4

    add-int/2addr v1, v4

    :goto_1
    if-ge v1, v0, :cond_0

    add-int/lit8 v17, v1, 0x1

    .line 234
    aget v18, v16, v1

    mul-float v18, v18, v7

    add-int/lit8 v19, v1, 0x2

    .line 235
    aget v20, v16, v17

    mul-float v20, v20, v8

    add-float v18, v18, v20

    add-int/lit8 v20, v1, 0x3

    .line 236
    aget v19, v16, v19

    mul-float v19, v19, v9

    add-float v18, v18, v19

    add-int/lit8 v19, v1, 0x4

    .line 237
    aget v20, v16, v20

    mul-float v20, v20, v10

    add-float v18, v18, v20

    add-int/lit8 v20, v1, 0x5

    .line 238
    aget v19, v16, v19

    mul-float v19, v19, v11

    add-float v18, v18, v19

    add-int/lit8 v19, v1, 0x6

    .line 239
    aget v20, v16, v20

    mul-float v20, v20, v12

    add-float v18, v18, v20

    add-int/lit8 v20, v1, 0x7

    .line 240
    aget v19, v16, v19

    mul-float v19, v19, v13

    add-float v18, v18, v19

    add-int/lit8 v1, v1, 0x8

    .line 241
    aget v19, v16, v20

    mul-float v19, v19, v14

    add-float v18, v18, v19

    .line 242
    aget v1, v16, v1

    mul-float/2addr v1, v5

    add-float v18, v18, v1

    add-int/lit8 v1, v2, 0x1

    .line 244
    aput v18, v3, v2

    move v2, v1

    move/from16 v1, v17

    goto :goto_1

    :cond_0
    add-int/lit8 v6, v6, 0x1

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)Z
    .locals 4

    .line 70
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

    .line 78
    :cond_1
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 77
    :cond_2
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 76
    :cond_3
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 75
    :cond_4
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    goto :goto_0

    .line 74
    :cond_5
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/convolve/noborder/ConvolveImageUnrolled_SB_F32_F32;->vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V

    :goto_0
    const/4 p0, 0x1

    return p0

    :cond_6
    :goto_1
    return v3
.end method

.method public static vertical11(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 25

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 483
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 484
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 486
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 487
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 488
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 489
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 490
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 491
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 492
    aget v12, v5, v12

    const/4 v13, 0x7

    .line 493
    aget v13, v5, v13

    const/16 v14, 0x8

    .line 494
    aget v14, v5, v14

    const/16 v15, 0x9

    .line 495
    aget v15, v5, v15

    const/16 v16, 0xa

    .line 496
    aget v5, v5, v16

    .line 498
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 500
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v16

    .line 501
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v17

    move-object/from16 v18, v2

    sub-int v2, v17, v4

    move-object/from16 v17, v3

    move v3, v4

    :goto_0
    if-ge v3, v2, :cond_1

    move/from16 p0, v2

    .line 507
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 v19, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v3

    add-int v2, v19, v2

    .line 508
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v19, v3, v4

    move/from16 v20, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v19, v19, v1

    add-int v1, v20, v19

    move/from16 v19, v1

    add-int v1, v19, v16

    move/from16 v24, v19

    move/from16 v19, v2

    move/from16 v2, v24

    :goto_1
    if-ge v2, v1, :cond_0

    .line 514
    aget v20, v18, v2

    mul-float v20, v20, v6

    move/from16 v21, v1

    .line 515
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v22, v2, v1

    .line 516
    aget v23, v18, v22

    mul-float v23, v23, v7

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 518
    aget v23, v18, v22

    mul-float v23, v23, v8

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 520
    aget v23, v18, v22

    mul-float v23, v23, v9

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 522
    aget v23, v18, v22

    mul-float v23, v23, v10

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 524
    aget v23, v18, v22

    mul-float v23, v23, v11

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 526
    aget v23, v18, v22

    mul-float v23, v23, v12

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 528
    aget v23, v18, v22

    mul-float v23, v23, v13

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 530
    aget v23, v18, v22

    mul-float v23, v23, v14

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 532
    aget v23, v18, v22

    mul-float v23, v23, v15

    add-float v20, v20, v23

    add-int v22, v22, v1

    .line 534
    aget v1, v18, v22

    mul-float/2addr v1, v5

    add-float v20, v20, v1

    add-int/lit8 v1, v19, 0x1

    .line 536
    aput v20, v17, v19

    add-int/lit8 v2, v2, 0x1

    move/from16 v19, v1

    move/from16 v1, v21

    goto :goto_1

    :cond_0
    add-int/lit8 v3, v3, 0x1

    move/from16 v2, p0

    move-object/from16 v1, p2

    goto/16 :goto_0

    :cond_1
    return-void
.end method

.method public static vertical3(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 18

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 299
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 300
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 302
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 303
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 304
    aget v5, v5, v8

    .line 306
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 308
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v8

    .line 309
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v9

    sub-int/2addr v9, v4

    move v10, v4

    :goto_0
    if-ge v10, v9, :cond_1

    .line 315
    iget v11, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v12, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v12, v10

    add-int/2addr v11, v12

    .line 316
    iget v12, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v13, v10, v4

    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v13, v14

    add-int/2addr v12, v13

    add-int v13, v12, v8

    :goto_1
    if-ge v12, v13, :cond_0

    .line 322
    aget v14, v2, v12

    mul-float/2addr v14, v6

    .line 323
    iget v15, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v16, v12, v15

    .line 324
    aget v17, v2, v16

    mul-float v17, v17, v7

    add-float v14, v14, v17

    add-int v16, v16, v15

    .line 326
    aget v15, v2, v16

    mul-float/2addr v15, v5

    add-float/2addr v14, v15

    add-int/lit8 v15, v11, 0x1

    .line 328
    aput v14, v3, v11

    add-int/lit8 v12, v12, 0x1

    move v11, v15

    goto :goto_1

    :cond_0
    add-int/lit8 v10, v10, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical5(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 18

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 336
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 337
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 339
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 340
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 341
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 342
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 343
    aget v5, v5, v10

    .line 345
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 347
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v10

    .line 348
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v11

    sub-int/2addr v11, v4

    move v12, v4

    :goto_0
    if-ge v12, v11, :cond_1

    .line 354
    iget v13, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    iget v14, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v14, v12

    add-int/2addr v13, v14

    .line 355
    iget v14, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v15, v12, v4

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v15, v1

    add-int/2addr v14, v15

    add-int v1, v14, v10

    :goto_1
    if-ge v14, v1, :cond_0

    .line 361
    aget v15, v2, v14

    mul-float/2addr v15, v6

    move/from16 p0, v1

    .line 362
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v16, v14, v1

    .line 363
    aget v17, v2, v16

    mul-float v17, v17, v7

    add-float v15, v15, v17

    add-int v16, v16, v1

    .line 365
    aget v17, v2, v16

    mul-float v17, v17, v8

    add-float v15, v15, v17

    add-int v16, v16, v1

    .line 367
    aget v17, v2, v16

    mul-float v17, v17, v9

    add-float v15, v15, v17

    add-int v16, v16, v1

    .line 369
    aget v1, v2, v16

    mul-float/2addr v1, v5

    add-float/2addr v15, v1

    add-int/lit8 v1, v13, 0x1

    .line 371
    aput v15, v3, v13

    add-int/lit8 v14, v14, 0x1

    move v13, v1

    move/from16 v1, p0

    goto :goto_1

    :cond_0
    add-int/lit8 v12, v12, 0x1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical7(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 20

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 379
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 380
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 382
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 383
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 384
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 385
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 386
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 387
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 388
    aget v5, v5, v12

    .line 390
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 392
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v12

    .line 393
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v13

    sub-int/2addr v13, v4

    move v14, v4

    :goto_0
    if-ge v14, v13, :cond_1

    .line 399
    iget v15, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move-object/from16 v16, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int/2addr v2, v14

    add-int/2addr v15, v2

    .line 400
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v17, v14, v4

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v17, v17, v1

    add-int v2, v2, v17

    add-int v1, v2, v12

    :goto_1
    if-ge v2, v1, :cond_0

    .line 406
    aget v17, v16, v2

    mul-float v17, v17, v6

    move/from16 p0, v1

    .line 407
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v18, v2, v1

    .line 408
    aget v19, v16, v18

    mul-float v19, v19, v7

    add-float v17, v17, v19

    add-int v18, v18, v1

    .line 410
    aget v19, v16, v18

    mul-float v19, v19, v8

    add-float v17, v17, v19

    add-int v18, v18, v1

    .line 412
    aget v19, v16, v18

    mul-float v19, v19, v9

    add-float v17, v17, v19

    add-int v18, v18, v1

    .line 414
    aget v19, v16, v18

    mul-float v19, v19, v10

    add-float v17, v17, v19

    add-int v18, v18, v1

    .line 416
    aget v19, v16, v18

    mul-float v19, v19, v11

    add-float v17, v17, v19

    add-int v18, v18, v1

    .line 418
    aget v1, v16, v18

    mul-float/2addr v1, v5

    add-float v17, v17, v1

    add-int/lit8 v1, v15, 0x1

    .line 420
    aput v17, v3, v15

    add-int/lit8 v2, v2, 0x1

    move v15, v1

    move/from16 v1, p0

    goto :goto_1

    :cond_0
    add-int/lit8 v14, v14, 0x1

    move-object/from16 v1, p2

    move-object/from16 v2, v16

    goto :goto_0

    :cond_1
    return-void
.end method

.method public static vertical9(Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;)V
    .locals 23

    move-object/from16 v0, p1

    move-object/from16 v1, p2

    .line 428
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    .line 429
    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;->data:[F

    move-object/from16 v4, p0

    .line 431
    iget-object v5, v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    const/4 v6, 0x0

    aget v6, v5, v6

    const/4 v7, 0x1

    .line 432
    aget v7, v5, v7

    const/4 v8, 0x2

    .line 433
    aget v8, v5, v8

    const/4 v9, 0x3

    .line 434
    aget v9, v5, v9

    const/4 v10, 0x4

    .line 435
    aget v10, v5, v10

    const/4 v11, 0x5

    .line 436
    aget v11, v5, v11

    const/4 v12, 0x6

    .line 437
    aget v12, v5, v12

    const/4 v13, 0x7

    .line 438
    aget v13, v5, v13

    const/16 v14, 0x8

    .line 439
    aget v5, v5, v14

    .line 441
    invoke-virtual {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->getRadius()I

    move-result v4

    .line 443
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getWidth()I

    move-result v14

    .line 444
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getHeight()I

    move-result v15

    sub-int/2addr v15, v4

    move-object/from16 v16, v2

    move v2, v4

    :goto_0
    if-ge v2, v15, :cond_1

    move/from16 p0, v2

    .line 450
    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    move/from16 v17, v2

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v2, v2, p0

    add-int v2, v17, v2

    .line 451
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->startIndex:I

    sub-int v17, p0, v4

    move/from16 v18, v1

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    mul-int v17, v17, v1

    add-int v1, v18, v17

    move/from16 v17, v1

    add-int v1, v17, v14

    move/from16 v22, v17

    move/from16 v17, v2

    move/from16 v2, v22

    :goto_1
    if-ge v2, v1, :cond_0

    .line 457
    aget v18, v16, v2

    mul-float v18, v18, v6

    move/from16 v19, v1

    .line 458
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->stride:I

    add-int v20, v2, v1

    .line 459
    aget v21, v16, v20

    mul-float v21, v21, v7

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 461
    aget v21, v16, v20

    mul-float v21, v21, v8

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 463
    aget v21, v16, v20

    mul-float v21, v21, v9

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 465
    aget v21, v16, v20

    mul-float v21, v21, v10

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 467
    aget v21, v16, v20

    mul-float v21, v21, v11

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 469
    aget v21, v16, v20

    mul-float v21, v21, v12

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 471
    aget v21, v16, v20

    mul-float v21, v21, v13

    add-float v18, v18, v21

    add-int v20, v20, v1

    .line 473
    aget v1, v16, v20

    mul-float/2addr v1, v5

    add-float v18, v18, v1

    add-int/lit8 v1, v17, 0x1

    .line 475
    aput v18, v3, v17

    add-int/lit8 v2, v2, 0x1

    move/from16 v17, v1

    move/from16 v1, v19

    goto :goto_1

    :cond_0
    add-int/lit8 v2, p0, 0x1

    move-object/from16 v1, p2

    goto :goto_0

    :cond_1
    return-void
.end method
