.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/misc/BoofMiscOps;
.super Ljava/lang/Object;
.source "BoofMiscOps.java"


# direct methods
.method static constructor <clinit>()V
    .locals 0

    .line 61
    return-void
.end method

.method public static checkDeclare(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;
    .locals 0

    if-nez p0, :cond_0

    .line 854
    new-instance p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V

    .line 855
    :cond_0
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->reset()V

    return-object p0
.end method

.method public static checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;IZ)[F
    .locals 0

    if-nez p0, :cond_0

    .line 836
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;-><init>(I)V

    .line 837
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;

    if-eqz p2, :cond_1

    const/4 p1, 0x0

    .line 839
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->fill(F)V

    .line 840
    :cond_1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_F32;->data:[F

    return-object p0
.end method

.method public static checkDeclare(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;IZ)[I
    .locals 0

    if-nez p0, :cond_0

    .line 827
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>(I)V

    .line 828
    :cond_0
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    if-eqz p2, :cond_1

    const/4 p1, 0x0

    .line 830
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->fill(I)V

    .line 831
    :cond_1
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->data:[I

    return-object p0
.end method

.method public static isInside(IIDD)Z
    .locals 4

    .line 508
    const-wide/16 v0, 0x0

    cmpl-double v2, p2, v0

    if-ltz v2, :cond_0

    int-to-double v2, p0

    cmpg-double p0, p2, v2

    if-gez p0, :cond_0

    cmpl-double p0, p4, v0

    if-ltz p0, :cond_0

    int-to-double p0, p1

    cmpg-double p0, p4, p0

    if-gez p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method
