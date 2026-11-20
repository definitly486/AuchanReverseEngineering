.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;
.super Ljava/lang/Object;
.source "FastArrayList.java"

# interfaces
.implements Ljava/util/List;
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList$MyIterator;
    }
.end annotation


# instance fields
.field queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;)V
    .locals 0

    .line 35
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 36
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    return-void
.end method


# virtual methods
.method public add(ILjava/lang/Object;)V
    .locals 0

    .line 139
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Not all list operations are supposed."

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public add(Ljava/lang/Object;)Z
    .locals 1

    .line 76
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->add(Ljava/lang/Object;)V

    const/4 p1, 0x1

    return p1
.end method

.method public addAll(ILjava/util/Collection;)Z
    .locals 0

    .line 109
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Not all list operations are supposed."

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 3

    .line 96
    invoke-interface {p1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object p1

    .line 98
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    .line 100
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 101
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->add(Ljava/lang/Object;)V

    goto :goto_0

    :cond_0
    return v0
.end method

.method public clear()V
    .locals 1

    .line 124
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;->reset()V

    return-void
.end method

.method public contains(Ljava/lang/Object;)Z
    .locals 1

    .line 51
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->contains(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public containsAll(Ljava/util/Collection;)Z
    .locals 1

    .line 87
    invoke-interface {p1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    .line 88
    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->contains(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_1
    const/4 p1, 0x1

    return p1
.end method

.method public get(I)Ljava/lang/Object;
    .locals 1

    .line 129
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aget-object p1, v0, p1

    return-object p1
.end method

.method public indexOf(Ljava/lang/Object;)I
    .locals 1

    .line 149
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->indexOf(Ljava/lang/Object;)I

    move-result p1

    return p1
.end method

.method public isEmpty()Z
    .locals 1

    .line 46
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList$MyIterator;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList$MyIterator;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;)V

    return-object v0
.end method

.method public lastIndexOf(Ljava/lang/Object;)I
    .locals 2

    .line 154
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    add-int/lit8 v0, v0, -0x1

    :goto_0
    if-ltz v0, :cond_1

    .line 155
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aget-object v1, v1, v0

    invoke-virtual {v1, p1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    return v0

    :cond_0
    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public listIterator()Ljava/util/ListIterator;
    .locals 1

    .line 163
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList$MyIterator;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList$MyIterator;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;)V

    return-object v0
.end method

.method public listIterator(I)Ljava/util/ListIterator;
    .locals 1

    .line 168
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Not supported"

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public remove(I)Ljava/lang/Object;
    .locals 1

    .line 144
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Not all list operations are supposed."

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public remove(Ljava/lang/Object;)Z
    .locals 1

    .line 82
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Not all list operations are supposed."

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 1

    .line 114
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Not all list operations are supposed."

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 1

    .line 119
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Not all list operations are supposed."

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public set(ILjava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 134
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    aput-object p2, v0, p1

    return-object p2
.end method

.method public size()I
    .locals 1

    .line 41
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    return v0
.end method

.method public subList(II)Ljava/util/List;
    .locals 0

    .line 173
    new-instance p1, Ljava/lang/RuntimeException;

    const-string p2, "Not supported"

    invoke-direct {p1, p2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public toArray()[Ljava/lang/Object;
    .locals 4

    .line 61
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    new-array v2, v1, [Ljava/lang/Object;

    .line 63
    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    const/4 v3, 0x0

    invoke-static {v0, v3, v2, v3, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object v2
.end method

.method public toArray([Ljava/lang/Object;)[Ljava/lang/Object;
    .locals 3

    .line 70
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArrayList;->queue:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastArray;

    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    const/4 v2, 0x0

    iget v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    invoke-static {v1, v2, p1, v2, v0}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    return-object p1
.end method
