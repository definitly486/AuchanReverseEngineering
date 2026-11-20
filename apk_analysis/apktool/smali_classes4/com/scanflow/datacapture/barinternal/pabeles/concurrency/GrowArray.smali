.class public Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;
.super Ljava/lang/Object;
.source "GrowArray.java"


# instance fields
.field array:[Ljava/lang/Object;

.field elementType:Ljava/lang/Class;

.field factory:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;

.field reset:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;

.field size:I


# direct methods
.method public static synthetic $r8$lambda$FLfXhh3lXI40rx0huoJhu6Ic5VM(Ljava/lang/Object;)V
    .locals 0

    .line 0
    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;)V
    .locals 1

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray$$ExternalSyntheticLambda0;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;)V
    .locals 1

    .line 43
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;->newInstance()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-direct {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;-><init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;Ljava/lang/Class;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;Ljava/lang/Class;)V
    .locals 0

    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 50
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->factory:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;

    .line 51
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->reset:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;

    .line 52
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->elementType:Ljava/lang/Class;

    const/4 p1, 0x0

    .line 53
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->createArray(I)[Ljava/lang/Object;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    .line 54
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    return-void
.end method

.method private createArray(I)[Ljava/lang/Object;
    .locals 1

    .line 59
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->elementType:Ljava/lang/Class;

    invoke-static {v0, p1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/Object;

    return-object p1
.end method


# virtual methods
.method public get(I)Ljava/lang/Object;
    .locals 1

    .line 112
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    aget-object p1, v0, p1

    return-object p1
.end method

.method public grow()Ljava/lang/Object;
    .locals 4

    .line 89
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v1, v1

    if-ne v0, v1, :cond_2

    const/16 v1, 0x3e8

    if-ge v0, v1, :cond_0

    mul-int/lit8 v0, v0, 0x2

    goto :goto_0

    :cond_0
    mul-int/lit8 v0, v0, 0x5

    .line 90
    div-int/lit8 v0, v0, 0x3

    :goto_0
    const/16 v1, 0xa

    invoke-static {v1, v0}, Ljava/lang/Math;->max(II)I

    move-result v0

    .line 91
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->createArray(I)[Ljava/lang/Object;

    move-result-object v0

    .line 92
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v2, v1

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 93
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v1, v1

    :goto_1
    array-length v2, v0

    if-ge v1, v2, :cond_1

    .line 94
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->factory:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;->newInstance()Ljava/lang/Object;

    move-result-object v2

    aput-object v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 96
    :cond_1
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    .line 98
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    aget-object v0, v0, v1

    .line 99
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->reset:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;

    invoke-interface {v1, v0}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;->reset(Ljava/lang/Object;)V

    return-object v0
.end method

.method public reset()V
    .locals 1

    const/4 v0, 0x0

    .line 63
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    return-void
.end method

.method public resize(I)V
    .locals 4

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v0, v0

    if-lt p1, v0, :cond_1

    .line 72
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->createArray(I)[Ljava/lang/Object;

    move-result-object v0

    .line 73
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v2, v1

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 74
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    array-length v1, v1

    :goto_0
    array-length v2, v0

    if-ge v1, v2, :cond_0

    .line 75
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->factory:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;

    invoke-interface {v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;->newInstance()Ljava/lang/Object;

    move-result-object v2

    aput-object v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 77
    :cond_0
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    .line 79
    :cond_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    :goto_1
    if-ge v0, p1, :cond_2

    .line 80
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->reset:Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->array:[Ljava/lang/Object;

    aget-object v2, v2, v0

    invoke-interface {v1, v2}, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$Reset;->reset(Ljava/lang/Object;)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 82
    :cond_2
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    return-void
.end method

.method public size()I
    .locals 1

    .line 116
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/GrowArray;->size:I

    return v0
.end method
