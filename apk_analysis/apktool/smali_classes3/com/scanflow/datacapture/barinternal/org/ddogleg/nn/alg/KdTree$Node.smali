.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;
.super Ljava/lang/Object;
.source "KdTree.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Node"
.end annotation


# instance fields
.field public index:I

.field public left:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

.field public point:Ljava/lang/Object;

.field public right:Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;

.field public split:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 86
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, -0x1

    .line 70
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    return-void
.end method


# virtual methods
.method public isLeaf()Z
    .locals 2

    .line 93
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/nn/alg/KdTree$Node;->split:I

    const/4 v1, -0x1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
