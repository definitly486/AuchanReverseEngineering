.class public abstract Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/FactoryNearestNeighbor;
.super Ljava/lang/Object;
.source "FactoryNearestNeighbor.java"


# direct methods
.method public static kdtree(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/NearestNeighbor;
    .locals 1

    .line 76
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/wrap/KdTreeNearestNeighbor;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTreeDistance;)V

    return-object v0
.end method
