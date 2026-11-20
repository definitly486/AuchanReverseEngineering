.class public abstract Lcom/scanflow/datacapture/model/session/SFDocumentReader;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract getCapturedDocumentList()Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/io/File;",
            ">;"
        }
    .end annotation
.end method

.method public abstract setOnActivityResultLauncher(Landroidx/activity/result/ActivityResultLauncher;)Lcom/scanflow/datacapture/model/session/SFDocumentReader;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/activity/result/ActivityResultLauncher<",
            "Landroid/content/Intent;",
            ">;)",
            "Lcom/scanflow/datacapture/model/session/SFDocumentReader;"
        }
    .end annotation
.end method

.method public abstract startDocumentCapture(Lcom/scanflow/datacapture/config/DocumentCaptureConfig;)Lcom/scanflow/datacapture/model/session/SFDocumentReader;
.end method
