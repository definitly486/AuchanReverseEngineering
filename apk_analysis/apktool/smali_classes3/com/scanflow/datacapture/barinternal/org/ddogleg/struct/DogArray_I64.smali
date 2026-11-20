.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I64;
.super Ljava/lang/Object;
.source "DogArray_I64.java"


# instance fields
.field public data:[J

.field public size:I


# direct methods
.method public constructor <init>()V
    .locals 1

    const/16 v0, 0xa

    .line 40
    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I64;-><init>(I)V

    return-void
.end method

.method public constructor <init>(I)V
    .locals 0

    .line 34
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 35
    new-array p1, p1, [J

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I64;->data:[J

    const/4 p1, 0x0

    .line 36
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I64;->size:I

    return-void
.end method
