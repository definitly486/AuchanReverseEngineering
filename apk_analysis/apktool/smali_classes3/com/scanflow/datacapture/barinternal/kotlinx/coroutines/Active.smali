.class final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;
.super Ljava/lang/Object;
.source "CancellableContinuationImpl.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/NotCompleted;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Active;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 628
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 1

    .line 629
    const-string v0, "Active"

    return-object v0
.end method
