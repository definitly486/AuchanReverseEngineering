.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/NullSurrogateKt;
.super Ljava/lang/Object;
.source "NullSurrogate.kt"


# static fields
.field public static final DONE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field public static final NULL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

.field public static final UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 12
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "NULL"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/NullSurrogateKt;->NULL:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 19
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "UNINITIALIZED"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/NullSurrogateKt;->UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    .line 26
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "DONE"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/NullSurrogateKt;->DONE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-void
.end method
