.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;
.super Ljava/lang/Object;
.source "DMatrix3x3.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;


# instance fields
.field public a11:D

.field public a12:D

.field public a13:D

.field public a21:D

.field public a22:D

.field public a23:D

.field public a31:D

.field public a32:D

.field public a33:D


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;)V
    .locals 2

    .line 50
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 51
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    .line 52
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    .line 53
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 165
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;)V

    return-object v0
.end method

.method public get(II)D
    .locals 0

    .line 77
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->unsafe_get(II)D

    move-result-wide p1

    return-wide p1
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

.method public set(IID)V
    .locals 0

    .line 110
    invoke-virtual {p0, p1, p2, p3, p4}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->unsafe_set(IID)V

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 5

    .line 143
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v0

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v0

    if-ne v0, v1, :cond_0

    .line 145
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;

    const/4 v0, 0x0

    .line 147
    invoke-interface {p1, v0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v1

    iput-wide v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    const/4 v1, 0x1

    .line 148
    invoke-interface {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v2

    iput-wide v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    const/4 v2, 0x2

    .line 149
    invoke-interface {p1, v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    .line 150
    invoke-interface {p1, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    .line 151
    invoke-interface {p1, v1, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    .line 152
    invoke-interface {p1, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    .line 153
    invoke-interface {p1, v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v3

    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    .line 154
    invoke-interface {p1, v2, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    .line 155
    invoke-interface {p1, v2, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->get(II)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-void

    .line 144
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string v0, "Rows and/or columns do not match"

    invoke-direct {p1, v0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public unsafe_get(II)D
    .locals 3

    const/4 v0, 0x2

    const/4 v1, 0x1

    if-nez p1, :cond_2

    if-nez p2, :cond_0

    .line 83
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    return-wide p1

    :cond_0
    if-ne p2, v1, :cond_1

    .line 85
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    return-wide p1

    :cond_1
    if-ne p2, v0, :cond_8

    .line 87
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    return-wide p1

    :cond_2
    if-ne p1, v1, :cond_5

    if-nez p2, :cond_3

    .line 91
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    return-wide p1

    :cond_3
    if-ne p2, v1, :cond_4

    .line 93
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    return-wide p1

    :cond_4
    if-ne p2, v0, :cond_8

    .line 95
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    return-wide p1

    :cond_5
    if-ne p1, v0, :cond_8

    if-nez p2, :cond_6

    .line 99
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    return-wide p1

    :cond_6
    if-ne p2, v1, :cond_7

    .line 101
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    return-wide p1

    :cond_7
    if-ne p2, v0, :cond_8

    .line 103
    iget-wide p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-wide p1

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

.method public unsafe_set(IID)V
    .locals 2

    const/4 v0, 0x2

    const/4 v1, 0x1

    if-nez p1, :cond_2

    if-nez p2, :cond_0

    .line 116
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a11:D

    return-void

    :cond_0
    if-ne p2, v1, :cond_1

    .line 118
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a12:D

    return-void

    :cond_1
    if-ne p2, v0, :cond_8

    .line 120
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a13:D

    return-void

    :cond_2
    if-ne p1, v1, :cond_5

    if-nez p2, :cond_3

    .line 124
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a21:D

    return-void

    :cond_3
    if-ne p2, v1, :cond_4

    .line 126
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a22:D

    return-void

    :cond_4
    if-ne p2, v0, :cond_8

    .line 128
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a23:D

    return-void

    :cond_5
    if-ne p1, v0, :cond_8

    if-nez p2, :cond_6

    .line 132
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a31:D

    return-void

    :cond_6
    if-ne p2, v1, :cond_7

    .line 134
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a32:D

    return-void

    :cond_7
    if-ne p2, v0, :cond_8

    .line 136
    iput-wide p3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix3x3;->a33:D

    return-void

    .line 139
    :cond_8
    new-instance p3, Ljava/lang/IllegalArgumentException;

    new-instance p4, Ljava/lang/StringBuilder;

    invoke-direct {p4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Row and/or column out of range. "

    invoke-virtual {p4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p4, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " "

    invoke-virtual {p4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p4, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {p4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p3
.end method
