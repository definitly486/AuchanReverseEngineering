.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;
.source "Kernel1D_F64.java"


# instance fields
.field public data:[D


# direct methods
.method public constructor <init>(I)V
    .locals 1

    .line 67
    div-int/lit8 v0, p1, 0x2

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;-><init>(II)V

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D;-><init>(II)V

    .line 78
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel1D_F64;->data:[D

    return-void
.end method
