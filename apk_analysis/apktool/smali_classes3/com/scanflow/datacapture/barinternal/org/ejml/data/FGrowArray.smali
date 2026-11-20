.class public Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;
.super Ljava/lang/Object;
.source "FGrowArray.java"


# instance fields
.field public data:[F

.field public length:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    .line 37
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 1

    .line 31
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    new-array v0, p1, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->data:[F

    .line 33
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->length:I

    return-void
.end method


# virtual methods
.method public reshape(I)Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;
    .locals 1

    .line 52
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->data:[F

    array-length v0, v0

    if-ge v0, p1, :cond_0

    .line 53
    new-array v0, p1, [F

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->data:[F

    .line 55
    :cond_0
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ejml/data/FGrowArray;->length:I

    return-object p0
.end method
