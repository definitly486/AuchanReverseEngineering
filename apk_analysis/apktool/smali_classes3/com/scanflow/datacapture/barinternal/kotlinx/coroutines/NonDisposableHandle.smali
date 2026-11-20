.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;
.super Ljava/lang/Object;
.source "Job.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/DisposableHandle;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ChildHandle;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NonDisposableHandle;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 661
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public childCancelled(Ljava/lang/Throwable;)Z
    .locals 0

    .line 676
    const/4 p1, 0x0

    return p1
.end method

.method public dispose()V
    .locals 0

    .line 670
    return-void
.end method

.method public getParent()Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
    .locals 1

    .line 664
    const/4 v0, 0x0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 682
    const-string v0, "NonDisposableHandle"

    return-object v0
.end method
