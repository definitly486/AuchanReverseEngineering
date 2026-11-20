.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;
.super Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;
.source "FastArray.java"


# instance fields
.field private final list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;


# direct methods
.method public constructor <init>(Ljava/lang/Class;)V
    .locals 1

    const/16 v0, 0xa

    .line 43
    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;-><init>(Ljava/lang/Class;I)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/Class;I)V
    .locals 1

    .line 37
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;-><init>(Ljava/lang/Class;)V

    .line 34
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->list:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;

    const/4 v0, 0x0

    .line 38
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    .line 39
    invoke-static {p1, p2}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/Object;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public add(Ljava/lang/Object;)V
    .locals 3

    .line 53
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v2, v1

    if-lt v0, v2, :cond_0

    .line 54
    array-length v0, v1

    add-int/lit8 v0, v0, 0x1

    mul-int/lit8 v0, v0, 0x2

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->reserve(I)V

    .line 56
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    aput-object p1, v0, v1

    return-void
.end method

.method public reserve(I)V
    .locals 1

    const/4 v0, 0x1

    .line 132
    invoke-virtual {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->reserve(IZ)V

    return-void
.end method

.method public reserve(IZ)V
    .locals 2

    .line 137
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    array-length v0, v0

    if-lt v0, p1, :cond_0

    return-void

    .line 140
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->type:Ljava/lang/Class;

    invoke-static {v0, p1}, Ljava/lang/reflect/Array;->newInstance(Ljava/lang/Class;I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/Object;

    if-eqz p2, :cond_1

    .line 142
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    const/4 v1, 0x0

    invoke-static {p2, v1, p1, v1, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 143
    :cond_1
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    return-void
.end method

.method public reset()V
    .locals 1

    const/4 v0, 0x0

    .line 107
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return-void
.end method
