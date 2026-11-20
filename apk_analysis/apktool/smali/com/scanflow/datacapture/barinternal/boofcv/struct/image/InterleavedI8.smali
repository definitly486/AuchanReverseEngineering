.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;
.super Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedInteger;
.source "InterleavedI8.java"


# instance fields
.field public data:[B


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 46
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedInteger;-><init>()V

    const/4 v0, 0x0

    new-array v0, v0, [B

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    return-void
.end method

.method protected constructor <init>(III)V
    .locals 0

    .line 43
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedInteger;-><init>(III)V

    return-void
.end method


# virtual methods
.method protected _getData()Ljava/lang/Object;
    .locals 1

    .line 150
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    return-object v0
.end method

.method protected _setData(Ljava/lang/Object;)V
    .locals 0

    .line 160
    check-cast p1, [B

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    return-void
.end method

.method protected getPrimitiveDataType()Ljava/lang/Class;
    .locals 1

    .line 155
    sget-object v0, Ljava/lang/Byte;->TYPE:Ljava/lang/Class;

    return-object v0
.end method

.method public toString_element(I)Ljava/lang/String;
    .locals 1

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;->data:[B

    aget-byte p1, v0, p1

    and-int/lit16 p1, p1, 0xff

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p1

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v0, "%02x"

    invoke-static {v0, p1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
