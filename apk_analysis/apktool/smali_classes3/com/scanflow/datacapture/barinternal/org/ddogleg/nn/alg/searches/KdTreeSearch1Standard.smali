.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;
.super Ljava/lang/Object;
.source "KdTreeSearch1Standard.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;


# instance fields
.field distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

.field private maxDistanceSq:D

.field private tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V
    .locals 2

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 45
    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;->maxDistanceSq:D

    .line 55
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    return-void
.end method


# virtual methods
.method public copy()Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeSearch1;
    .locals 2

    .line 100
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;->distance:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    return-object v0
.end method

.method public setTree(Ljava/lang/Object;)V
    .locals 0

    .line 60
    check-cast p1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/searches/KdTreeSearch1Standard;->tree:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;

    return-void
.end method
