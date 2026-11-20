.class public final Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement$a;
.super Ljava/util/LinkedHashMap;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/source/super_resolution/Enhancement;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/util/LinkedHashMap<",
        "Ljava/lang/String;",
        "Lcom/scanflow/datacapture/core/source/super_resolution/a;",
        ">;"
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 4

    .line 0
    invoke-direct {p0}, Ljava/util/LinkedHashMap;-><init>()V

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/a;

    new-instance v1, Lcom/scanflow/datacapture/core/source/super_resolution/f;

    invoke-direct {v1}, Lcom/scanflow/datacapture/core/source/super_resolution/f;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/core/source/super_resolution/c;

    invoke-direct {v2}, Lcom/scanflow/datacapture/core/source/super_resolution/c;-><init>()V

    const-string v3, "Sensifai_Enhancement_TFLite.tflite"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/a;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/e;Lcom/scanflow/datacapture/core/source/super_resolution/b;)V

    const-string v1, "Enhancement"

    invoke-virtual {p0, v1, v0}, Ljava/util/AbstractMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/a;

    new-instance v1, Lcom/scanflow/datacapture/core/source/super_resolution/g;

    invoke-direct {v1}, Lcom/scanflow/datacapture/core/source/super_resolution/g;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/core/source/super_resolution/d;

    invoke-direct {v2}, Lcom/scanflow/datacapture/core/source/super_resolution/d;-><init>()V

    const-string v3, "Sensifai_SuperResolution_TFLite.tflite"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/a;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/e;Lcom/scanflow/datacapture/core/source/super_resolution/b;)V

    const-string v1, "SuperResolution"

    invoke-virtual {p0, v1, v0}, Ljava/util/AbstractMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/a;

    new-instance v1, Lcom/scanflow/datacapture/core/source/super_resolution/f;

    invoke-direct {v1}, Lcom/scanflow/datacapture/core/source/super_resolution/f;-><init>()V

    new-instance v2, Lcom/scanflow/datacapture/core/source/super_resolution/c;

    invoke-direct {v2}, Lcom/scanflow/datacapture/core/source/super_resolution/c;-><init>()V

    const-string v3, "Sensifai_Enhancement_TFLite_float16.tflite"

    invoke-direct {v0, v3, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/a;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/core/source/super_resolution/e;Lcom/scanflow/datacapture/core/source/super_resolution/b;)V

    const-string v1, "Enhancement16"

    invoke-virtual {p0, v1, v0}, Ljava/util/AbstractMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    return-void
.end method
