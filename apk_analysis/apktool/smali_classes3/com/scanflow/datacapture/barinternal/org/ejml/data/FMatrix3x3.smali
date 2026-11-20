.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;
.super Ljava/lang/Object;
.source "FMatrix3x3.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;


# instance fields
.field public a11:F

.field public a12:F

.field public a13:F

.field public a21:F

.field public a22:F

.field public a23:F

.field public a31:F

.field public a32:F

.field public a33:F


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public get(II)F
    .locals 0

    .line 77
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->unsafe_get(II)F

    move-result p1

    return p1
.end method

.method public getNumCols()I
    .locals 1

    .line 160
    const/4 v0, 0x3

    return v0
.end method

.method public getNumRows()I
    .locals 1

    .line 158
    const/4 v0, 0x3

    return v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 178
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->UNSPECIFIED:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public unsafe_get(II)F
    .locals 3

    const/4 v0, 0x2

    const/4 v1, 0x1

    if-nez p1, :cond_2

    if-nez p2, :cond_0

    .line 83
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    return p1

    :cond_0
    if-ne p2, v1, :cond_1

    .line 85
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    return p1

    :cond_1
    if-ne p2, v0, :cond_8

    .line 87
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    return p1

    :cond_2
    if-ne p1, v1, :cond_5

    if-nez p2, :cond_3

    .line 91
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    return p1

    :cond_3
    if-ne p2, v1, :cond_4

    .line 93
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    return p1

    :cond_4
    if-ne p2, v0, :cond_8

    .line 95
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    return p1

    :cond_5
    if-ne p1, v0, :cond_8

    if-nez p2, :cond_6

    .line 99
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    return p1

    :cond_6
    if-ne p2, v1, :cond_7

    .line 101
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    return p1

    :cond_7
    if-ne p2, v0, :cond_8

    .line 103
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    return p1

    .line 106
    :cond_8
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Row and/or column out of range. "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public unsafe_set(IIF)V
    .locals 2

    const/4 v0, 0x2

    const/4 v1, 0x1

    if-nez p1, :cond_2

    if-nez p2, :cond_0

    .line 116
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a11:F

    return-void

    :cond_0
    if-ne p2, v1, :cond_1

    .line 118
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a12:F

    return-void

    :cond_1
    if-ne p2, v0, :cond_8

    .line 120
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a13:F

    return-void

    :cond_2
    if-ne p1, v1, :cond_5

    if-nez p2, :cond_3

    .line 124
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a21:F

    return-void

    :cond_3
    if-ne p2, v1, :cond_4

    .line 126
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a22:F

    return-void

    :cond_4
    if-ne p2, v0, :cond_8

    .line 128
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a23:F

    return-void

    :cond_5
    if-ne p1, v0, :cond_8

    if-nez p2, :cond_6

    .line 132
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a31:F

    return-void

    :cond_6
    if-ne p2, v1, :cond_7

    .line 134
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a32:F

    return-void

    :cond_7
    if-ne p2, v0, :cond_8

    .line 136
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix3x3;->a33:F

    return-void

    .line 139
    :cond_8
    new-instance p3, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Row and/or column out of range. "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p3
.end method
