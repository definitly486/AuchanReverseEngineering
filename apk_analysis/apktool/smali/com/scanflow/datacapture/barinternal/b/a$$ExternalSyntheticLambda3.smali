.class public final synthetic Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/b/a;

.field public final synthetic f$1:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/b/a;Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/b/a;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;->f$1:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;->f$0:Lcom/scanflow/datacapture/barinternal/b/a;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/b/a$$ExternalSyntheticLambda3;->f$1:Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/b/a;->a(Lcom/scanflow/datacapture/barinternal/b/a;Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;)V

    return-void
.end method
