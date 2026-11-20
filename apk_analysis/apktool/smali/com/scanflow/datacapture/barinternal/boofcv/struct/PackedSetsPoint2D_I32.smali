.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;
.super Ljava/lang/Object;
.source "PackedSetsPoint2D_I32.java"


# instance fields
.field final blockLength:I

.field final blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field final sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field tailBlockSize:I


# direct methods
.method public static synthetic $r8$lambda$EEm76jKBBsVFr6fPj1OH5D2KWJY(Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;)[I
    .locals 0

    .line 58
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    new-array p0, p0, [I

    return-object p0
.end method

.method public constructor <init>()V
    .locals 1

    const/16 v0, 0x7d0

    .line 63
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 2

    .line 53
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    const/4 v0, 0x2

    if-lt p1, v0, :cond_0

    .line 57
    rem-int/lit8 v0, p1, 0x2

    add-int/2addr p1, v0

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    .line 58
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32$$ExternalSyntheticLambda1;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32$$ExternalSyntheticLambda1;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;)V

    const-class v1, [I

    invoke-direct {p1, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Ljava/lang/Class;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 59
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    return-void

    .line 55
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Block length must be more than 2"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method


# virtual methods
.method public addPointToTail(II)V
    .locals 5

    .line 109
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-nez v0, :cond_0

    .line 110
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->grow()V

    .line 112
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->getTail()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;

    .line 113
    iget v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->start:I

    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    mul-int/lit8 v2, v2, 0x2

    add-int/2addr v1, v2

    .line 116
    iget v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;->block:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    div-int v3, v1, v3

    add-int/2addr v2, v3

    .line 117
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v4, v3, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ne v2, v4, :cond_1

    const/4 v2, 0x0

    .line 118
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    .line 119
    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, [I

    goto :goto_0

    .line 121
    :cond_1
    invoke-virtual {v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, [I

    .line 123
    :goto_0
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    add-int/lit8 v3, v3, 0x2

    iput v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    .line 124
    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    rem-int/2addr v1, v3

    .line 126
    aput p1, v2, v1

    add-int/lit8 v1, v1, 0x1

    .line 127
    aput p2, v2, v1

    .line 128
    iget p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    add-int/lit8 p1, p1, 0x1

    iput p1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    return-void
.end method

.method public getSet(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
    .locals 5

    .line 164
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 166
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;

    const/4 v0, 0x0

    .line 168
    :goto_0
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    if-ge v0, v1, :cond_0

    .line 169
    iget v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->start:I

    mul-int/lit8 v2, v0, 0x2

    add-int/2addr v1, v2

    .line 170
    iget v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;->block:I

    iget v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    div-int v4, v1, v3

    add-int/2addr v2, v4

    .line 171
    rem-int/2addr v1, v3

    .line 173
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v3, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, [I

    .line 174
    invoke-virtual {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    aget v4, v2, v1

    add-int/lit8 v1, v1, 0x1

    aget v1, v2, v1

    invoke-virtual {v3, v4, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;->setTo(II)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_0
    return-void
.end method

.method public grow()V
    .locals 3

    .line 80
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blockLength:I

    const/4 v2, 0x0

    if-lt v0, v1, :cond_0

    .line 81
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    .line 82
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    .line 85
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;

    .line 86
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/lit8 v1, v1, -0x1

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;->block:I

    .line 87
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    iput v1, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->start:I

    .line 88
    iput v2, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    return-void
.end method

.method public removeTail()V
    .locals 4

    .line 95
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->getTail()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;

    .line 96
    :goto_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v2, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/lit8 v2, v2, -0x1

    iget v3, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;->block:I

    if-eq v2, v3, :cond_0

    .line 97
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->removeTail()Ljava/lang/Object;

    goto :goto_0

    .line 98
    :cond_0
    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->start:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    .line 99
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->removeTail()Ljava/lang/Object;

    return-void
.end method

.method public reset()V
    .locals 1

    const/4 v0, 0x0

    .line 70
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->tailBlockSize:I

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->blocks:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    .line 73
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    return-void
.end method

.method public size()I
    .locals 1

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return v0
.end method

.method public sizeOfTail()I
    .locals 2

    .line 194
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/PackedSetsPoint2D_I32;->sets:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-nez v1, :cond_0

    const/4 v0, 0x0

    return v0

    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->getTail()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/BlockIndexLength;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/IndexLength;->length:I

    return v0
.end method
