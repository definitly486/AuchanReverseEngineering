.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;
.source "GrayI8.java"


# instance fields
.field public data:[B


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 43
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [B

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    return-void
.end method

.method protected constructor <init>(II)V
    .locals 0

    .line 40
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;-><init>(II)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    return-object v0
.end method

.method public _setData(Ljava/lang/Object;)V
    .locals 0

    .line 103
    check-cast p1, [B

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    return-void
.end method

.method public set(III)V
    .locals 2

    .line 74
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->isInBounds(II)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;->data:[B

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;->getIndex(II)I

    move-result p1

    int-to-byte p2, p3

    aput-byte p2, v0, p1

    return-void

    .line 75
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
