.class public final Lcom/scanflow/datacapture/barinternal/f/a;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final a:Lcom/scanflow/datacapture/barinternal/f/a;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/f/a;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/f/a;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/f/a;->a:Lcom/scanflow/datacapture/barinternal/f/a;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final declared-synchronized a(Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/model/LowLightResponse;
    .locals 12

    monitor-enter p0

    :try_start_0
    const-string v0, "cropBitmap"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "frameBitmap"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 1
    const-string v0, "bitmap"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lorg/opencv/core/Mat;

    invoke-direct {v0}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {p2, v0}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    const/16 p2, 0x34

    invoke-static {v0, v0, p2}, Lorg/opencv/imgproc/Imgproc;->cvtColor(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;I)V

    invoke-static {v0}, Lorg/opencv/core/Core;->mean(Lorg/opencv/core/Mat;)Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;

    move-result-object p2

    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;->val:[D

    const/4 v0, 0x1

    aget-wide v1, p2, v0

    double-to-int p2, v1

    .line 2
    sget-object v1, Lcom/scanflow/datacapture/utils/ScanflowLog;->INSTANCE:Lcom/scanflow/datacapture/utils/ScanflowLog;

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Is Low light Image : Brightness : "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "DarkEnvironmentUtils"

    invoke-virtual {v1, v3, v2}, Lcom/scanflow/datacapture/utils/ScanflowLog;->v(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/16 v1, 0xf

    if-gt p2, v1, :cond_0

    monitor-exit p0

    const/4 p1, 0x0

    return-object p1

    :cond_0
    const/16 v1, 0x50

    const/4 v2, 0x0

    if-ge p2, v1, :cond_1

    move p2, v0

    goto :goto_0

    :cond_1
    move p2, v2

    :goto_0
    if-eqz p2, :cond_3

    .line 3
    :try_start_1
    const-string v1, "<this>"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lorg/opencv/core/Mat;

    invoke-direct {v1}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v3, Lorg/opencv/core/Mat;

    invoke-direct {v3}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {p1, v1}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance p1, Lorg/opencv/core/Mat;

    const/16 v4, 0x100

    invoke-direct {p1, v0, v4, v2}, Lorg/opencv/core/Mat;-><init>(III)V

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->total()J

    move-result-wide v4

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->channels()I

    move-result v0

    int-to-long v6, v0

    mul-long/2addr v4, v6

    long-to-int v0, v4

    new-array v0, v0, [B

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->cols()I

    move-result v4

    move v5, v2

    :goto_1
    if-ge v5, v4, :cond_2

    int-to-double v6, v5

    const-wide v8, 0x406fe00000000000L    # 255.0

    div-double/2addr v6, v8

    const-wide v10, 0x3fd999999999999aL    # 0.4

    invoke-static {v6, v7, v10, v11}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v6

    mul-double/2addr v6, v8

    double-to-int v6, v6

    int-to-byte v6, v6

    aput-byte v6, v0, v5

    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    :cond_2
    invoke-virtual {p1, v2, v2, v0}, Lorg/opencv/core/Mat;->put(II[B)I

    invoke-static {v1, p1, v3}, Lorg/opencv/core/Core;->LUT(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    invoke-virtual {v3}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object p1

    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->width:D

    double-to-int p1, v0

    invoke-virtual {v3}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v0

    iget-wide v0, v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->height:D

    double-to-int v0, v0

    sget-object v1, Landroid/graphics/Bitmap$Config;->RGB_565:Landroid/graphics/Bitmap$Config;

    invoke-static {p1, v0, v1}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object p1

    const-string v0, "createBitmap(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v3, p1}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    .line 4
    :cond_3
    new-instance v0, Lcom/scanflow/datacapture/model/LowLightResponse;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/model/LowLightResponse;-><init>(Landroid/graphics/Bitmap;Z)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit p0

    return-object v0

    :goto_2
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw p1
.end method
