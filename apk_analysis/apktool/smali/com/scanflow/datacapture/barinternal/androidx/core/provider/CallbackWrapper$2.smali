.class Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;
.super Ljava/lang/Object;
.source "CallbackWrapper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;->onTypefaceRequestFailed(I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;

.field final synthetic val$callback:Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;

.field final synthetic val$reason:I


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;I)V
    .locals 0

    .line 76
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;->val$callback:Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;->val$reason:I

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .line 79
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;->val$callback:Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper$2;->val$reason:I

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;->onTypefaceRequestFailed(I)V

    return-void
.end method
