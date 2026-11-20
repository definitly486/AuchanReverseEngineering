.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeLinkedListHead;
.source "JobSupport.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Incomplete;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 1501
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeLinkedListHead;-><init>()V

    return-void
.end method


# virtual methods
.method public getList()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NodeList;
    .locals 0

    .line 1503
    return-object p0
.end method

.method public isActive()Z
    .locals 1

    .line 1502
    const/4 v0, 0x1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 1520
    invoke-super {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeLinkedListNode;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
