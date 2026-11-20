.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D;
.source "Kernel2D_S32.java"


# instance fields
.field public data:[I


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 60
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D;-><init>(I)V

    mul-int/2addr p1, p1

    .line 62
    new-array p1, p1, [I

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/convolve/Kernel2D_S32;->data:[I

    return-void
.end method
