.class public final synthetic Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/android/gms/tasks/OnCompleteListener;


# instance fields
.field public final synthetic f$0:Z

.field public final synthetic f$1:Landroid/graphics/Bitmap;

.field public final synthetic f$2:Lcom/scanflow/datacapture/barcode/b;

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/b;


# direct methods
.method public synthetic constructor <init>(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/b;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$0:Z

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$1:Landroid/graphics/Bitmap;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barcode/b;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/b;

    return-void
.end method


# virtual methods
.method public final onComplete(Lcom/google/android/gms/tasks/Task;)V
    .locals 4

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$0:Z

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$1:Landroid/graphics/Bitmap;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$2:Lcom/scanflow/datacapture/barcode/b;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/com/scanflow/datacapture/barcode/b$$ExternalSyntheticLambda0;->f$3:Lcom/scanflow/datacapture/barinternal/b;

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barcode/b;->a(ZLandroid/graphics/Bitmap;Lcom/scanflow/datacapture/barcode/b;Lcom/scanflow/datacapture/barinternal/b;Lcom/google/android/gms/tasks/Task;)V

    return-void
.end method
