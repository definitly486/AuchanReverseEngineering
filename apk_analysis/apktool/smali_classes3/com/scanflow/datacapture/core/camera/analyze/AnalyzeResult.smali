.class public final Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/lang/Object;"
    }
.end annotation


# instance fields
.field private bitmap:Landroid/graphics/Bitmap;

.field private result:Ljava/lang/Object;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "TT;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public constructor <init>(Landroid/graphics/Bitmap;Ljava/lang/Object;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/graphics/Bitmap;",
            "TT;)V"
        }
    .end annotation

    .line 2
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->bitmap:Landroid/graphics/Bitmap;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->result:Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public final getBitmap()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->bitmap:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final getResult()Ljava/lang/Object;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()TT;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->result:Ljava/lang/Object;

    return-object v0
.end method

.method public final setBitmap(Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->bitmap:Landroid/graphics/Bitmap;

    return-void
.end method

.method public final setResult(Ljava/lang/Object;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(TT;)V"
        }
    .end annotation

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/analyze/AnalyzeResult;->result:Ljava/lang/Object;

    return-void
.end method
