.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;
.super Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;
.source "JobSupport.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "ChildCompletion"
.end annotation


# instance fields
.field private final child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

.field private final parent:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

.field private final proposedUpdate:Ljava/lang/Object;

.field private final state:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;Ljava/lang/Object;)V
    .locals 0

    .line 1265
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobNode;-><init>()V

    .line 1261
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->parent:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    .line 1262
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->state:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;

    .line 1263
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    .line 1264
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->proposedUpdate:Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public getOnCancelling()Z
    .locals 1

    .line 1266
    const/4 v0, 0x0

    return v0
.end method

.method public invoke(Ljava/lang/Throwable;)V
    .locals 3

    .line 1268
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->parent:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->state:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->child:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$ChildCompletion;->proposedUpdate:Ljava/lang/Object;

    invoke-static {p1, v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;->access$continueCompleting(Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/JobSupport$Finishing;Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandleNode;Ljava/lang/Object;)V

    return-void
.end method
