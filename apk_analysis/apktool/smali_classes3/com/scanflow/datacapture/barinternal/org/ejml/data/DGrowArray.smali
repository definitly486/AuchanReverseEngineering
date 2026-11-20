.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;
.super Ljava/lang/Object;
.source "DGrowArray.java"


# instance fields
.field public data:[D

.field public length:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    .line 35
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    .line 29
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 30
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->data:[D

    .line 31
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->length:I

    return-void
.end method


# virtual methods
.method public reshape(I)Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;
    .locals 1

    .line 50
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->data:[D

    array-length v0, v0

    if-ge v0, p1, :cond_0

    .line 51
    new-array v0, p1, [D

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->data:[D

    .line 53
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/DGrowArray;->length:I

    return-object p0
.end method
