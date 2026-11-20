.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;
.super Ljava/lang/Object;
.source "IGrowArray.java"


# instance fields
.field public data:[I

.field public length:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    .line 36
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    new-array v0, p1, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->data:[I

    .line 32
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->length:I

    return-void
.end method


# virtual methods
.method public reshape(I)V
    .locals 1

    .line 44
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->data:[I

    array-length v0, v0

    if-ge v0, p1, :cond_0

    .line 45
    new-array v0, p1, [I

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->data:[I

    .line 47
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/IGrowArray;->length:I

    return-void
.end method
