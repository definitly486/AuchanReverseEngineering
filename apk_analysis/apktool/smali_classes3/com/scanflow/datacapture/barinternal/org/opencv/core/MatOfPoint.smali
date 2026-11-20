.class public Lcom/scanflow/datacapture/barinternal/org/opencv/core/MatOfPoint;
.super Lorg/opencv/core/Mat;
.source "MatOfPoint.java"


# direct methods
.method public constructor <init>(Lorg/opencv/core/Mat;)V
    .locals 1

    .line 27
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;->all()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;

    move-result-object v0

    invoke-direct {p0, p1, v0}, Lorg/opencv/core/Mat;-><init>(Lorg/opencv/core/Mat;Lcom/scanflow/datacapture/barinternal/org/opencv/core/Range;)V

    .line 28
    invoke-virtual {p0}, Lorg/opencv/core/Mat;->empty()Z

    move-result p1

    if-nez p1, :cond_1

    const/4 p1, 0x2

    const/4 v0, 0x4

    invoke-virtual {p0, p1, v0}, Lorg/opencv/core/Mat;->checkVector(II)I

    move-result p1

    if-ltz p1, :cond_0

    goto :goto_0

    .line 29
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Incompatible Mat"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    :goto_0
    return-void
.end method
