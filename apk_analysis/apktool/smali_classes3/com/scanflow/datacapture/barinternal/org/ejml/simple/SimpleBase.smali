.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
.super Ljava/lang/Object;
.source "SimpleBase.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;
.implements Ljava/io/Serializable;


# instance fields
.field protected transient convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

.field protected mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

.field protected ops:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;


# direct methods
.method protected constructor <init>()V
    .locals 1

    .line 63
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 57
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    return-void
.end method

.method protected static lookupOps(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;
    .locals 3

    .line 138
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase$1;->$SwitchMap$org$ejml$data$MatrixType:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_0

    .line 145
    new-instance v0, Ljava/lang/RuntimeException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown Matrix Type. "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {v0, p0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 144
    :pswitch_0
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FSCC;-><init>()V

    return-object p0

    .line 143
    :pswitch_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC;-><init>()V

    return-object p0

    .line 142
    :pswitch_2
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_CDRM;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_CDRM;-><init>()V

    return-object p0

    .line 141
    :pswitch_3
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_ZDRM;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_ZDRM;-><init>()V

    return-object p0

    .line 140
    :pswitch_4
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FDRM;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_FDRM;-><init>()V

    return-object p0

    .line 139
    :pswitch_5
    new-instance p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DDRM;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DDRM;-><init>()V

    return-object p0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method


# virtual methods
.method protected abstract createMatrix(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
.end method

.method varargs findAlternative(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/reflect/Method;
    .locals 7

    .line 1334
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->ops:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getMethods()[Ljava/lang/reflect/Method;

    move-result-object v0

    const/4 v1, 0x0

    move v2, v1

    .line 1335
    :goto_0
    array-length v3, v0

    if-ge v2, v3, :cond_5

    .line 1336
    aget-object v3, v0, v2

    invoke-virtual {v3}, Ljava/lang/reflect/Method;->getName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    goto :goto_2

    .line 1339
    :cond_0
    aget-object v3, v0, v2

    invoke-virtual {v3}, Ljava/lang/reflect/Method;->getParameterTypes()[Ljava/lang/Class;

    move-result-object v3

    .line 1340
    array-length v4, v3

    array-length v5, p2

    if-eq v4, v5, :cond_1

    goto :goto_2

    :cond_1
    move v4, v1

    .line 1345
    :goto_1
    array-length v5, v3

    if-ge v4, v5, :cond_4

    .line 1346
    aget-object v5, p2, v4

    instance-of v6, v5, Ljava/lang/Class;

    if-eqz v6, :cond_2

    .line 1347
    aget-object v6, v3, v4

    if-eq v6, v5, :cond_3

    goto :goto_2

    .line 1351
    :cond_2
    aget-object v6, v3, v4

    invoke-virtual {v5}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v5

    if-eq v6, v5, :cond_3

    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_3
    add-int/lit8 v4, v4, 0x1

    goto :goto_1

    .line 1357
    :cond_4
    aget-object p1, v0, v2

    return-object p1

    :cond_5
    const/4 p1, 0x0

    return-object p1
.end method

.method public getDDRM()Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;
    .locals 2

    .line 114
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    sget-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->DDRM:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    :goto_0
    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj;

    return-object v0

    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixType;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v0

    goto :goto_0
.end method

.method public getMatrix()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;
    .locals 1

    .line 110
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    return-object v0
.end method

.method public getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;
    .locals 1

    .line 1288
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    return-object v0
.end method

.method public varargs invoke(Ljava/lang/reflect/Method;[Ljava/lang/Object;)V
    .locals 1

    .line 1365
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->ops:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;

    invoke-virtual {p1, v0, p2}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/IllegalAccessException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p1

    goto :goto_0

    :catch_1
    move-exception p1

    .line 1367
    :goto_0
    new-instance p2, Ljava/lang/RuntimeException;

    invoke-direct {p2, p1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw p2
.end method

.method public mult(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
    .locals 4

    .line 175
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    .line 176
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    const/4 v1, 0x2

    new-array v1, v1, [Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;

    const/4 v2, 0x0

    aput-object p0, v1, v2

    const/4 v2, 0x1

    aput-object p1, v1, v2

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->specify([Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;)V

    .line 179
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 180
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    iget-object v3, v3, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-virtual {v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->getClassType()Ljava/lang/Class;

    move-result-object v3

    filled-new-array {v0, v1, v3}, [Ljava/lang/Object;

    move-result-object v0

    const-string v1, "mult"

    invoke-virtual {p0, v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->findAlternative(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/reflect/Method;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 182
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-virtual {v1, v2, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->create(II)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object v1

    .line 183
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    filled-new-array {v2, p1, v3}, [Ljava/lang/Object;

    move-result-object p1

    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->invoke(Ljava/lang/reflect/Method;[Ljava/lang/Object;)V

    return-object v1

    .line 189
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object v0

    .line 190
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->convertType:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;

    invoke-virtual {v1, p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object p1

    .line 192
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-interface {v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumRows()I

    move-result v1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getMatrix()Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v2

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getNumCols()I

    move-result v2

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v3

    invoke-virtual {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->createMatrix(IILcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object v1

    .line 194
    iget-object v2, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->ops:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object v3, v1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-interface {v2, v0, p1, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;->mult(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    return-object v1
.end method

.method protected setMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V
    .locals 0

    .line 1329
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    .line 1330
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->lookupOps(Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->ops:Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleOperations;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 791
    new-instance v0, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v0}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 792
    new-instance v1, Ljava/io/PrintStream;

    invoke-direct {v1, v0}, Ljava/io/PrintStream;-><init>(Ljava/io/OutputStream;)V

    .line 794
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    invoke-static {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/MatrixIO;->print(Ljava/io/PrintStream;Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)V

    .line 796
    sget-object v1, Ljava/nio/charset/StandardCharsets;->UTF_8:Ljava/nio/charset/Charset;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DMatrixRMaj$$ExternalSyntheticApiModelOutline0;->m(Ljava/io/ByteArrayOutputStream;Ljava/nio/charset/Charset;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method protected abstract wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
.end method
