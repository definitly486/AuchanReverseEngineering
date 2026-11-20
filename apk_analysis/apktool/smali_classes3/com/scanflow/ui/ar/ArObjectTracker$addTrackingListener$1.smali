.class public final Lcom/scanflow/ui/ar/ArObjectTracker$addTrackingListener$1;
.super Ljava/lang/Object;
.source "SourceFile"

# interfaces
.implements Lcom/scanflow/ui/ar/ArObjectTracker$ArObjectTrackingListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/ui/ar/ArObjectTracker;->addTrackingListener(Lkotlin/jvm/functions/Function1;)Lcom/scanflow/ui/ar/ArObjectTracker;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation


# instance fields
.field final synthetic $listener:Lkotlin/jvm/functions/Function1;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lkotlin/jvm/functions/Function1<",
            "Lcom/scanflow/ui/ar/ArObject;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>(Lkotlin/jvm/functions/Function1;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Lcom/scanflow/ui/ar/ArObject;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ar/ArObjectTracker$addTrackingListener$1;->$listener:Lkotlin/jvm/functions/Function1;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onObjectTracked(Lcom/scanflow/ui/ar/ArObject;)V
    .locals 1

    .line 1
    iget-object v0, p0, Lcom/scanflow/ui/ar/ArObjectTracker$addTrackingListener$1;->$listener:Lkotlin/jvm/functions/Function1;

    invoke-interface {v0, p1}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method

.method public onObjectTracked(Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList<",
            "Lcom/scanflow/ui/ar/ArObject;",
            ">;)V"
        }
    .end annotation

    .line 2
    const-string v0, "arObject"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    return-void
.end method
