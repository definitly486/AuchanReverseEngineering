.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;
.super Ljava/lang/Object;
.source "DogArrayList.java"

# interfaces
.implements Ljava/util/ListIterator;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "MyIterator"
.end annotation


# instance fields
.field index:I

.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;)V
    .locals 0

    .line 167
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 p1, 0x0

    .line 169
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    return-void
.end method


# virtual methods
.method public add(Ljava/lang/Object;)V
    .locals 1

    .line 213
    new-instance p1, Ljava/lang/RuntimeException;

    const-string v0, "Add is not supported by FastQueue. Use FastArray instead"

    invoke-direct {p1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public hasNext()Z
    .locals 2

    .line 173
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;->array:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPrevious()Z
    .locals 1

    .line 183
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    if-lez v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 3

    .line 178
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;->array:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method public nextIndex()I
    .locals 1

    .line 193
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    return v0
.end method

.method public previous()Ljava/lang/Object;
    .locals 2

    .line 188
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;->array:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    add-int/lit8 v1, v1, -0x1

    iput v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    aget-object v0, v0, v1

    return-object v0
.end method

.method public previousIndex()I
    .locals 1

    .line 198
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    add-int/lit8 v0, v0, -0x1

    return v0
.end method

.method public remove()V
    .locals 2

    .line 203
    new-instance v0, Ljava/lang/RuntimeException;

    const-string v1, "Not all list operations are supposed."

    invoke-direct {v0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public set(Ljava/lang/Object;)V
    .locals 2

    .line 208
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->this$0:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList;->array:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->data:[Ljava/lang/Object;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArrayList$MyIterator;->index:I

    add-int/lit8 v1, v1, -0x1

    aput-object p1, v0, v1

    return-void
.end method
