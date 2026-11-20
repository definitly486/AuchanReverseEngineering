.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;
.source "DMatrixRMaj.java"


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 138
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;-><init>()V

    .line 139
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    return-void
.end method

.method public constructor <init>(II)V
    .locals 0

    .line 116
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix1Row;-><init>()V

    .line 117
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    .line 118
    new-array p1, p1, [D

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V
    .locals 3

    .line 128
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    .line 129
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result p1

    const/4 v2, 0x0

    invoke-static {v0, v2, v1, v2, p1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    .line 321
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 53
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object v0

    return-object v0
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 1

    .line 362
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 53
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public get(II)D
    .locals 3

    if-ltz p2, :cond_0

    .line 247
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge p2, v0, :cond_0

    if-ltz p1, :cond_0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge p1, v1, :cond_0

    .line 251
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    mul-int/2addr p1, v0

    add-int/2addr p1, p2

    aget-wide p1, v1, p1

    return-wide p1

    .line 248
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Specified element is out of bounds: "

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

.method public getIndex(II)I
    .locals 1

    .line 259
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr p1, v0

    add-int/2addr p1, p2

    return p1
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 366
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public reshape(IIZ)V
    .locals 3

    .line 182
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v0

    .line 183
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->assignShape(II)V

    .line 184
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    array-length v2, v1

    mul-int/2addr p1, p2

    if-ge v2, p1, :cond_1

    .line 185
    new-array p1, p1, [D

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 188
    invoke-static {v1, p2, p1, p2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 191
    :cond_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    :cond_1
    return-void
.end method

.method public set(IID)V
    .locals 2

    if-ltz p2, :cond_0

    .line 208
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    if-ge p2, v0, :cond_0

    if-ltz p1, :cond_0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numRows:I

    if-ge p1, v1, :cond_0

    .line 212
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    mul-int/2addr p1, v0

    add-int/2addr p1, p2

    aput-wide p3, v1, p1

    return-void

    .line 209
    :cond_0
    new-instance p3, Ljava/lang/IllegalArgumentException;

    new-instance p4, Ljava/lang/StringBuilder;

    invoke-direct {p4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Specified element is out of bounds: ("

    invoke-virtual {p4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p4, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, " , "

    invoke-virtual {p4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p4, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, ")"

    invoke-virtual {p4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p3
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 351
    new-instance v0, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v0}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 352
    new-instance v1, Ljava/io/PrintStream;

    invoke-direct {v1, v0}, Ljava/io/PrintStream;-><init>(Ljava/io/OutputStream;)V

    invoke-static {v1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;)V

    .line 354
    invoke-static {}, Ljava/nio/charset/Charset;->defaultCharset()Ljava/nio/charset/Charset;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj$$ExternalSyntheticApiModelOutline0;->m(Ljava/io/ByteArrayOutputStream;Ljava/nio/charset/Charset;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public unsafe_get(II)D
    .locals 2

    .line 255
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aget-wide p1, v0, p1

    return-wide p1
.end method

.method public unsafe_set(IID)V
    .locals 2

    .line 216
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aput-wide p3, v0, p1

    return-void
.end method

.method public zero()V
    .locals 5

    .line 304
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixD1;->data:[D

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrix;->getNumElements()I

    move-result v1

    const-wide/16 v2, 0x0

    const/4 v4, 0x0

    invoke-static {v0, v4, v1, v2, v3}, Ljava/util/Arrays;->fill([DIID)V

    return-void
.end method
