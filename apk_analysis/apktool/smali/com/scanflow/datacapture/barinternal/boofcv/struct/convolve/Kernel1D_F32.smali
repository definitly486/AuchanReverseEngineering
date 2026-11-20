.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;
.source "Kernel1D_F32.java"


# instance fields
.field public data:[F


# direct methods
.method public constructor <init>(I)V
    .locals 1

    .line 69
    div-int/lit8 v0, p1, 0x2

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;-><init>(II)V

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 79
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;-><init>(II)V

    .line 80
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    return-void
.end method


# virtual methods
.method public computeSum()F
    .locals 4

    const/4 v0, 0x0

    const/4 v1, 0x0

    .line 131
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    array-length v3, v2

    if-ge v1, v3, :cond_0

    .line 132
    aget v2, v2, v1

    add-float/2addr v0, v2

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_0
    return v0
.end method

.method public copy()Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;
    .locals 5

    .line 115
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->offset:I

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;-><init>(II)V

    .line 116
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/KernelBase;->width:I

    const/4 v4, 0x0

    invoke-static {v1, v4, v2, v4, v3}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object v0
.end method

.method public get(I)F
    .locals 1

    .line 126
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F32;->data:[F

    aget p1, v0, p1

    return p1
.end method
