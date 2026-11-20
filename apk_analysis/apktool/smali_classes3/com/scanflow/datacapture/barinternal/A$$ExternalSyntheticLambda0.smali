.class public final synthetic Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/android/gms/tasks/OnCompleteListener;


# instance fields
.field public final synthetic f$0:Ljava/util/ArrayList;

.field public final synthetic f$1:Ljava/util/ArrayList;

.field public final synthetic f$2:I

.field public final synthetic f$3:Lcom/scanflow/datacapture/barcode/b;

.field public final synthetic f$4:Lcom/scanflow/datacapture/barinternal/B;

.field public final synthetic f$5:Lkotlinx/coroutines/CoroutineScope;


# direct methods
.method public synthetic constructor <init>(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$0:Ljava/util/ArrayList;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$1:Ljava/util/ArrayList;

    iput p3, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$2:I

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barcode/b;

    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/B;

    iput-object p6, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$5:Lkotlinx/coroutines/CoroutineScope;

    return-void
.end method


# virtual methods
.method public final onComplete(Lcom/google/android/gms/tasks/Task;)V
    .locals 7

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$0:Ljava/util/ArrayList;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$1:Ljava/util/ArrayList;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$2:I

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barcode/b;

    iget-object v4, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$4:Lcom/scanflow/datacapture/barinternal/B;

    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/A$$ExternalSyntheticLambda0;->f$5:Lkotlinx/coroutines/CoroutineScope;

    move-object v6, p1

    invoke-static/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/A;->a(Ljava/util/ArrayList;Ljava/util/ArrayList;ILcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/B;Lkotlinx/coroutines/CoroutineScope;Lcom/google/android/gms/tasks/Task;)V

    return-void
.end method
