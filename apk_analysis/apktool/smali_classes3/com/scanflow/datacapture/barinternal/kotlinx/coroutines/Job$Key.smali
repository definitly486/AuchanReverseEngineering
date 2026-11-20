.class public final Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;
.super Ljava/lang/Object;
.source "Job.kt"

# interfaces
.implements Lkotlin/coroutines/CoroutineContext$Key;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Key"
.end annotation


# static fields
.field static final synthetic $$INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;->$$INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/Job$Key;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 124
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
