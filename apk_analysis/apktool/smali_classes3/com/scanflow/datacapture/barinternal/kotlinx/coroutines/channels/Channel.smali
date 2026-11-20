.class public interface abstract Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;
.super Ljava/lang/Object;
.source "Channel.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/SendChannel;
.implements Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/ReceiveChannel;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;
    }
.end annotation


# static fields
.field public static final Factory:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;->$$INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel;->Factory:Lcom/scanflow/datacapture/barinternal/kotlinx/coroutines/channels/Channel$Factory;

    return-void
.end method
