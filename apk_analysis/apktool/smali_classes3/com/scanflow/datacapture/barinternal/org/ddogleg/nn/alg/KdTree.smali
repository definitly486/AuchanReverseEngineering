.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;
.super Ljava/lang/Object;
.source "KdTree.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
    }
.end annotation


# instance fields
.field public N:I

.field public root:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 50
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 51
    iput p1, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;->N:I

    return-void
.end method
