.class public interface abstract Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/ui/ar/ArObjectTracker;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "ArObjectTrackingListener"
.end annotation


# virtual methods
.method public abstract onObjectTracked(Lcom/scanflow/ui/ar/ArObject;)V
.end method

.method public abstract onObjectTracked(Ljava/util/ArrayList;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;)V"
        }
    .end annotation
.end method
