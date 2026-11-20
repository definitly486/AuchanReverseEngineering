.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;
.super Ljava/lang/Object;
.source "CoroutineExceptionHandler.kt"

# interfaces
.implements Lkotlin/coroutines/CoroutineContext$Element;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;
    }
.end annotation


# static fields
.field public static final Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;->$$INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler;->Key:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/CoroutineExceptionHandler$Key;

    return-void
.end method


# virtual methods
.method public abstract handleException(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V
.end method
