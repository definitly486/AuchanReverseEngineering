.class Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;
.super Ljava/lang/Object;
.source "Tags.java"

# interfaces
.implements Ljava/util/Iterator;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;->iterator()Ljava/util/Iterator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Object;",
        "Ljava/util/Iterator<",
        "TT;>;"
    }
.end annotation


# instance fields
.field private n:I

.field final synthetic this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;


# direct methods
.method constructor <init>(Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;)V
    .locals 0

    .line 715
    iput-object p1, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 p1, 0x0

    .line 716
    iput p1, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->n:I

    return-void
.end method


# virtual methods
.method public hasNext()Z
    .locals 2

    .line 720
    iget v0, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->n:I

    iget-object v1, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;

    invoke-virtual {v1}, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public next()Ljava/lang/Object;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TT;"
        }
    .end annotation

    .line 729
    iget v0, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->n:I

    .line 730
    iget-object v1, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;

    invoke-virtual {v1}, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;->size()I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 732
    iget-object v1, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;

    iget-object v1, v1, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;->this$0:Lcom/google/common/flogger/context/Tags$LightweightTagMap;

    invoke-static {v1}, Lcom/google/common/flogger/context/Tags$LightweightTagMap;->access$900(Lcom/google/common/flogger/context/Tags$LightweightTagMap;)[Ljava/lang/Object;

    move-result-object v1

    iget-object v2, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->this$1:Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;

    invoke-virtual {v2}, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet;->getStart()I

    move-result v2

    add-int/2addr v2, v0

    aget-object v1, v1, v2

    add-int/lit8 v0, v0, 0x1

    .line 734
    iput v0, p0, Lcom/google/common/flogger/context/Tags$LightweightTagMap$SortedArraySet$1;->n:I

    return-object v1

    .line 737
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method

.method public remove()V
    .locals 1

    .line 742
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0
.end method
