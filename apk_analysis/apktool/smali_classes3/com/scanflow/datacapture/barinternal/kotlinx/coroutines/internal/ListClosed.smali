.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ListClosed;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeLinkedListNode;
.source "LockFreeLinkedList.kt"


# instance fields
.field public final forbiddenElementsBitmask:I


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 287
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeLinkedListNode;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/ListClosed;->forbiddenElementsBitmask:I

    return-void
.end method
