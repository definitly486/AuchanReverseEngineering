.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;
.super Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;
.source "FMatrixRMaj.java"


# direct methods
.method public constructor <init>(II)V
    .locals 0

    .line 118
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix1Row;-><init>()V

    .line 119
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->assignShape(II)V

    mul-int/2addr p1, p2

    .line 120
    new-array p1, p1, [F

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V
    .locals 3

    .line 130
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    iget v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    invoke-direct {p0, v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    .line 131
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result p1

    const/4 v2, 0x0

    invoke-static {v0, v2, v1, v2, p1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;
    .locals 1

    .line 323
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;)V

    return-object v0
.end method

.method public bridge synthetic copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 54
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;->copy()Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    move-result-object v0

    return-object v0
.end method

.method public create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;
    .locals 1

    .line 364
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;-><init>(II)V

    return-object v0
.end method

.method public bridge synthetic create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 0

    .line 54
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixRMaj;

    move-result-object p1

    return-object p1
.end method

.method public get(II)F
    .locals 3

    if-ltz p2, :cond_0

    .line 249
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    if-ge p2, v0, :cond_0

    if-ltz p1, :cond_0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numRows:I

    if-ge p1, v1, :cond_0

    .line 253
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    mul-int/2addr p1, v0

    add-int/2addr p1, p2

    aget p1, v1, p1

    return p1

    .line 250
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

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 368
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->FDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-object v0
.end method

.method public reshape(IIZ)V
    .locals 3

    .line 184
    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result v0

    .line 185
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->assignShape(II)V

    .line 186
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    array-length v2, v1

    mul-int/2addr p1, p2

    if-ge v2, p1, :cond_1

    .line 187
    new-array p1, p1, [F

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 190
    invoke-static {v1, p2, p1, p2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 193
    :cond_0
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    :cond_1
    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 353
    new-instance v0, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v0}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 354
    new-instance v1, Ljava/io/PrintStream;

    invoke-direct {v1, v0}, Ljava/io/PrintStream;-><init>(Ljava/io/OutputStream;)V

    invoke-static {v1, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;)V

    .line 356
    invoke-static {}, Ljava/nio/charset/Charset;->defaultCharset()Ljava/nio/charset/Charset;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj$$ExternalSyntheticApiModelOutline0;->m(Ljava/io/ByteArrayOutputStream;Ljava/nio/charset/Charset;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public unsafe_get(II)F
    .locals 2

    .line 257
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aget p1, v0, p1

    return p1
.end method

.method public unsafe_set(IIF)V
    .locals 2

    .line 218
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->numCols:I

    mul-int/2addr p1, v1

    add-int/2addr p1, p2

    aput p3, v0, p1

    return-void
.end method

.method public zero()V
    .locals 4

    .line 306
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrixD1;->data:[F

    invoke-interface {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FMatrix;->getNumElements()I

    move-result v1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-static {v0, v3, v1, v2}, Ljava/util/Arrays;->fill([FIIF)V

    return-void
.end method
