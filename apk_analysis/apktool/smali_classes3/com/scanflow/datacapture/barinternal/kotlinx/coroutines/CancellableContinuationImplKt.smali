.class public abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImplKt;
.super Ljava/lang/Object;
.source "CancellableContinuationImpl.kt"


# static fields
.field public static final RESUME_TOKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 23
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    const-string v1, "RESUME_TOKEN"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;-><init>(Ljava/lang/String;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CancellableContinuationImplKt;->RESUME_TOKEN:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/internal/Symbol;

    return-void
.end method
