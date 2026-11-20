.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;
.super Ljava/lang/Object;
.source "ContourPacked.java"


# instance fields
.field public externalIndex:I

.field public id:I

.field public internalIndexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ContourPacked;->internalIndexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;

    return-void
.end method
