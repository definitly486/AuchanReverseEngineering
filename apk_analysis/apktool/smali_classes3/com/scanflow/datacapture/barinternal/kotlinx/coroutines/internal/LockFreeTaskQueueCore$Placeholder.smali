.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore$Placeholder;
.super Ljava/lang/Object;
.source "LockFreeTaskQueue.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Placeholder"
.end annotation


# instance fields
.field public final index:I


# direct methods
.method public constructor <init>(I)V
    .locals 0

    .line 264
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/LockFreeTaskQueueCore$Placeholder;->index:I

    return-void
.end method
