.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;
.super Ljava/lang/Object;
.source "DogLinkedList.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    }
.end annotation


# instance fields
.field protected final available:Ljava/util/ArrayDeque;

.field protected first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

.field protected last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

.field protected size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 34
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 43
    new-instance v0, Ljava/util/ArrayDeque;

    invoke-direct {v0}, Ljava/util/ArrayDeque;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->available:Ljava/util/ArrayDeque;

    return-void
.end method


# virtual methods
.method public getHead()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 350
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    return-object v0
.end method

.method public getTail()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 358
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    return-object v0
.end method

.method public insertAfter(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 153
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->requestNew()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 154
    iput-object p2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    .line 155
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 156
    iget-object p2, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iput-object p2, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-eqz p2, :cond_0

    .line 158
    iput-object v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_0

    .line 160
    :cond_0
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 162
    :goto_0
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 163
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    add-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    return-object v0
.end method

.method public pushTail(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 130
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->requestNew()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    move-result-object v0

    .line 131
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    .line 133
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez p1, :cond_0

    .line 134
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_0

    .line 136
    :cond_0
    iput-object p1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 137
    iput-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 138
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 140
    :goto_0
    iget p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    add-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    return-object v0
.end method

.method public remove(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;)V
    .locals 2

    .line 266
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez v0, :cond_0

    .line 267
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_0

    .line 269
    :cond_0
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iput-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 271
    :goto_0
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-nez v1, :cond_1

    .line 272
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    goto :goto_1

    .line 274
    :cond_1
    iput-object v0, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 276
    :goto_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    add-int/lit8 v0, v0, -0x1

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    .line 277
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->clear()V

    .line 278
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->available:Ljava/util/ArrayDeque;

    invoke-virtual {v0, p1}, Ljava/util/ArrayDeque;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method protected requestNew()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
    .locals 1

    .line 448
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->available:Ljava/util/ArrayDeque;

    invoke-virtual {v0}, Ljava/util/ArrayDeque;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 449
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;-><init>()V

    return-object v0

    .line 451
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->available:Ljava/util/ArrayDeque;

    invoke-virtual {v0}, Ljava/util/ArrayDeque;->pop()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    return-object v0
.end method

.method public reset()V
    .locals 3

    .line 49
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    :goto_0
    if-eqz v0, :cond_1

    .line 51
    iget-object v1, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 52
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->clear()V

    .line 53
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->available:Ljava/util/ArrayDeque;

    invoke-virtual {v2, v0}, Ljava/util/ArrayDeque;->add(Ljava/lang/Object;)Z

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    if-ne v1, v0, :cond_0

    goto :goto_1

    :cond_0
    move-object v0, v1

    goto :goto_0

    :cond_1
    :goto_1
    const/4 v0, 0x0

    .line 59
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->last:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->first:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    const/4 v0, 0x0

    .line 60
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    return-void
.end method

.method public size()I
    .locals 1

    .line 439
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;->size:I

    return v0
.end method
