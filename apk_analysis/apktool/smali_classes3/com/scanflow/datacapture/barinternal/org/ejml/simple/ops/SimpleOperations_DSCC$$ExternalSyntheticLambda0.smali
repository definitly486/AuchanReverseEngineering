.class public final synthetic Lcom/scanflow/datacapture/barinternal/org/ejml/simple/ops/SimpleOperations_DSCC$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/pabeles/concurrency/ConcurrencyOps$NewInstance;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final newInstance()Ljava/lang/Object;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/org/ejml/sparse/csc/mult/Workspace_MT_DSCC;-><init>()V

    return-object v0
.end method
