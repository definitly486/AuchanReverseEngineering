.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;
.source "Kernel1D_S32.java"


# instance fields
.field public data:[I


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;-><init>(II)V

    .line 78
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    return-void
.end method


# virtual methods
.method public computeSum()I
    .locals 4

    const/4 v0, 0x0

    move v1, v0

    .line 129
    :goto_0
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    array-length v3, v2

    if-ge v0, v3, :cond_0

    .line 130
    aget v2, v2, v0

    add-int/2addr v1, v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return v1
.end method

.method public get(I)I
    .locals 1

    .line 124
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_S32;->data:[I

    aget p1, v0, p1

    return p1
.end method
