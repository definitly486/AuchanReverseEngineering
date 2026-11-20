.class public Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;
.super Ljava/lang/Object;
.source "AutomaticSimpleMatrixConvert.java"


# instance fields
.field commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public convert(Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;
    .locals 4

    .line 59
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    if-ne v0, v1, :cond_0

    return-object p1

    .line 62
    :cond_0
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v0

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->isDense()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->isDense()Z

    move-result v0

    if-eqz v0, :cond_1

    .line 63
    sget-object v0, Ljava/lang/System;->err:Ljava/io/PrintStream;

    const-string v1, "\n***** WARNING *****\n"

    invoke-virtual {v0, v1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 64
    sget-object v0, Ljava/lang/System;->err:Ljava/io/PrintStream;

    const-string v1, "Converting a sparse to dense matrix automatically."

    invoke-virtual {v0, v1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 65
    sget-object v0, Ljava/lang/System;->err:Ljava/io/PrintStream;

    const-string v1, "Current auto convert code isn\'t that smart and this might have been available"

    invoke-virtual {v0, v1}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 68
    :cond_1
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->mat:Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ejml/ops/ConvertMatrixType;->convert(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;)Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;

    move-result-object v0

    if-eqz v0, :cond_2

    .line 72
    invoke-virtual {p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->wrapMatrix(Lcom/scanflow/datacapture/barinternal/org/ejml/data/Matrix;)Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;

    move-result-object p1

    return-object p1

    .line 70
    :cond_2
    new-instance v0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/SimpleBase;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Conversion from "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string p1, " to "

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string p1, " not possible"

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public varargs specify([Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;)V
    .locals 9

    .line 45
    array-length v0, p1

    const/4 v1, 0x0

    const/4 v2, 0x1

    const/16 v3, 0x20

    move v4, v1

    move v5, v4

    move v6, v2

    :goto_0
    if-ge v4, v0, :cond_3

    aget-object v7, p1, v4

    .line 46
    invoke-interface {v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ConstMatrix;->getType()Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object v7

    .line 47
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->isDense()Z

    move-result v8

    if-eqz v8, :cond_0

    move v5, v2

    .line 49
    :cond_0
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->isReal()Z

    move-result v8

    if-nez v8, :cond_1

    move v6, v1

    .line 51
    :cond_1
    invoke-virtual {v7}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->getBits()I

    move-result v7

    const/16 v8, 0x40

    if-ne v7, v8, :cond_2

    move v3, v8

    :cond_2
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 55
    :cond_3
    invoke-static {v5, v6, v3}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;->lookup(ZZI)Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/simple/AutomaticSimpleMatrixConvert;->commonType:Lcom/scanflow/datacapture/barinternal/org/ejml/data/MatrixType;

    return-void
.end method
