.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;
.super Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;
.source "DogArray.java"


# instance fields
.field private factory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;

.field private initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

.field private final list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

.field private reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;


# direct methods
.method public constructor <init>(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V
    .locals 1

    .line 97
    invoke-interface {p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;->newInstance()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;-><init>(Ljava/lang/Class;)V

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    .line 98
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->init(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V
    .locals 1

    .line 63
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;->newInstance()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;-><init>(Ljava/lang/Class;)V

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    const/16 v0, 0xa

    .line 64
    invoke-virtual {p0, v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->init(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;)V
    .locals 1

    .line 74
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;->newInstance()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;-><init>(Ljava/lang/Class;)V

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    .line 48
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    .line 75
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    const/16 p2, 0xa

    .line 76
    invoke-virtual {p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->init(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/Class;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V
    .locals 0

    .line 54
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;-><init>(Ljava/lang/Class;)V

    .line 45
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    .line 48
    new-instance p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    const/16 p1, 0xa

    .line 55
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->init(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    return-void
.end method


# virtual methods
.method protected createInstance()Ljava/lang/Object;
    .locals 2

    .line 408
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->factory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;->newInstance()Ljava/lang/Object;

    move-result-object v0

    .line 409
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->initialize:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    invoke-interface {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;->process(Ljava/lang/Object;)V

    .line 410
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    invoke-interface {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;->process(Ljava/lang/Object;)V

    return-object v0
.end method

.method public grow()Ljava/lang/Object;
    .locals 3

    .line 206
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v2, v1

    if-ge v0, v2, :cond_0

    add-int/lit8 v2, v0, 0x1

    .line 207
    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    aget-object v0, v1, v0

    .line 208
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    invoke-interface {v1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;->process(Ljava/lang/Object;)V

    return-object v0

    .line 211
    :cond_0
    array-length v0, v1

    add-int/lit8 v0, v0, 0x1

    mul-int/lit8 v0, v0, 0x2

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reserve(I)V

    .line 212
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method protected init(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V
    .locals 2

    const/4 v0, 0x0

    .line 105
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    .line 106
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->factory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;

    .line 107
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    if-nez v1, :cond_0

    .line 108
    new-instance v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess$DoNothing;-><init>()V

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    .line 110
    :cond_0
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->type:Ljava/lang/Class;

    invoke-static {v1, p1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, [Ljava/lang/Object;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    if-eqz p2, :cond_1

    :goto_0
    if-ge v0, p1, :cond_1

    .line 115
    :try_start_0
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->createInstance()Ljava/lang/Object;

    move-result-object v1

    aput-object v1, p2, v0
    :try_end_0
    .catch Ljava/lang/RuntimeException; {:try_start_0 .. :try_end_0} :catch_0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 117
    :catch_0
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "declareInstances is true, but createInstance() can\'t create a new instance.  Maybe override createInstance()?"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    return-void
.end method

.method public remove(I)Ljava/lang/Object;
    .locals 4

    .line 236
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aget-object v0, v0, p1

    :goto_0
    add-int/lit8 p1, p1, 0x1

    .line 237
    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge p1, v1, :cond_0

    .line 238
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    add-int/lit8 v2, p1, -0x1

    aget-object v3, v1, p1

    aput-object v3, v1, v2

    goto :goto_0

    .line 240
    :cond_0
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    add-int/lit8 v2, v1, -0x1

    aput-object v0, p1, v2

    add-int/lit8 v1, v1, -0x1

    .line 241
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return-object v0
.end method

.method public removeTail()Ljava/lang/Object;
    .locals 2

    .line 187
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-lez v0, :cond_0

    add-int/lit8 v0, v0, -0x1

    .line 188
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    .line 189
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aget-object v0, v1, v0

    return-object v0

    .line 191
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Size is already zero"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public reserve(I)V
    .locals 4

    .line 285
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v0, v0

    if-lt v0, p1, :cond_0

    return-void

    .line 288
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->type:Ljava/lang/Class;

    invoke-static {v0, p1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Ljava/lang/Object;

    .line 289
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v2, v1

    const/4 v3, 0x0

    invoke-static {v1, v3, v0, v3, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 291
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->factory:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;

    if-eqz v1, :cond_1

    .line 292
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v1, v1

    :goto_0
    if-ge v1, p1, :cond_1

    .line 293
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->createInstance()Ljava/lang/Object;

    move-result-object v2

    aput-object v2, v0, v1

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 296
    :cond_1
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    return-void
.end method

.method public reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;
    .locals 1

    const/4 v0, 0x0

    .line 195
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return-object p0
.end method

.method public resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;
    .locals 3

    .line 345
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reserve(I)V

    .line 346
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    :goto_0
    if-ge v0, p1, :cond_0

    .line 347
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aget-object v2, v2, v0

    invoke-interface {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DProcess;->process(Ljava/lang/Object;)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 349
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return-object p0
.end method

.method public toList()Ljava/util/List;
    .locals 1

    .line 134
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    return-object v0
.end method
