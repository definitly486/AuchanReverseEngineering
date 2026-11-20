.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;
.source "GrayI16.java"


# instance fields
.field public data:[S


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 37
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [S

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    return-void
.end method

.method protected constructor <init>(II)V
    .locals 0

    .line 34
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;-><init>(II)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 80
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    return-object v0
.end method

.method public _setData(Ljava/lang/Object;)V
    .locals 0

    .line 84
    check-cast p1, [S

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    return-void
.end method

.method public set(III)V
    .locals 2

    .line 48
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 51
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;->data:[S

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    int-to-short p2, p3

    aput-short p2, v0, p1

    return-void

    .line 49
    :cond_0
    new-instance p3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Requested pixel is out of bounds: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageAccessException;-><init>(Ljava/lang/String;)V

    throw p3
.end method
