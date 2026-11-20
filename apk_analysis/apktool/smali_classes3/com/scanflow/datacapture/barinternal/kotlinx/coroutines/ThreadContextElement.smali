.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement;
.super Ljava/lang/Object;
.source "ThreadContextElement.kt"

# interfaces
.implements Lkotlin/coroutines/CoroutineContext$Element;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/ThreadContextElement$DefaultImpls;
    }
.end annotation


# virtual methods
.method public abstract restoreThreadContext(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V
.end method

.method public abstract updateThreadContext(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/Object;
.end method
