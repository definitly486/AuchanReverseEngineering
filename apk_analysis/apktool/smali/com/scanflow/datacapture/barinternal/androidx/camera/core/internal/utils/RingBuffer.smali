.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/RingBuffer;
.super Ljava/lang/Object;
.source "RingBuffer.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/internal/utils/RingBuffer$OnRemoveCallback;
    }
.end annotation


# virtual methods
.method public abstract dequeue()Ljava/lang/Object;
.end method

.method public abstract enqueue(Ljava/lang/Object;)V
.end method

.method public abstract isEmpty()Z
.end method
