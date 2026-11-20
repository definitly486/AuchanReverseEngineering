.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InactiveNodeList;
.super Ljava/lang/Object;
.source "JobSupport.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;


# instance fields
.field private final list:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;)V
    .locals 0

    .line 1523
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 1524
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InactiveNodeList;->list:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;

    return-void
.end method


# virtual methods
.method public getList()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;
    .locals 1

    .line 1524
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/InactiveNodeList;->list:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;

    return-object v0
.end method

.method public isActive()Z
    .locals 1

    .line 1526
    const/4 v0, 0x0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 1527
    invoke-super {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
