.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/FusibleFlow;
.super Ljava/lang/Object;
.source "ChannelFlow.kt"

# interfaces
.implements Lkotlinx/coroutines/flow/Flow;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/flow/internal/FusibleFlow$DefaultImpls;
    }
.end annotation


# virtual methods
.method public abstract fuse(Lkotlin/coroutines/CoroutineContext;ILcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;
.end method
