.class public final Lcom/scanflow/datacapture/barinternal/h;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final a:Lcom/scanflow/datacapture/barinternal/h;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/h;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/h;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/h;->a:Lcom/scanflow/datacapture/barinternal/h;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final declared-synchronized a(Landroid/graphics/Bitmap;)Lcom/scanflow/datacapture/model/LowLightResponse;
    .locals 13

    monitor-enter p0

    :try_start_0
    const-string v0, "bitmap"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 1
    const-string v0, "bitmap"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lorg/opencv/core/Mat;

    invoke-direct {v0}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {p1, v0}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    const/16 v1, 0x34

    invoke-static {v0, v0, v1}, Lorg/opencv/imgproc/Imgproc;->cvtColor(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;I)V

    invoke-static {v0}, Lorg/opencv/core/Core;->mean(Lorg/opencv/core/Mat;)Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;

    move-result-object v0

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Scalar;->val:[D

    const/4 v1, 0x1

    aget-wide v2, v0, v1

    double-to-int v0, v2

    .line 2
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Is Low light Image : Brightness : "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "DarkEnvironmentUtils"

    invoke-static {v3, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/16 v2, 0xf

    if-gt v0, v2, :cond_0

    monitor-exit p0

    const/4 p1, 0x0

    return-object p1

    :cond_0
    const/16 v2, 0x64

    const/4 v3, 0x0

    if-ge v0, v2, :cond_1

    move v0, v1

    goto :goto_0

    :cond_1
    move v0, v3

    :goto_0
    if-eqz v0, :cond_3

    .line 3
    :try_start_1
    const-string v2, "<this>"

    invoke-static {p1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v2, Lorg/opencv/core/Mat;

    invoke-direct {v2}, Lorg/opencv/core/Mat;-><init>()V

    new-instance v4, Lorg/opencv/core/Mat;

    invoke-direct {v4}, Lorg/opencv/core/Mat;-><init>()V

    invoke-static {p1, v2}, Lorg/opencv/android/Utils;->bitmapToMat(Landroid/graphics/Bitmap;Lorg/opencv/core/Mat;)V

    new-instance p1, Lorg/opencv/core/Mat;

    const/16 v5, 0x100

    invoke-direct {p1, v1, v5, v3}, Lorg/opencv/core/Mat;-><init>(III)V

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->total()J

    move-result-wide v5

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->channels()I

    move-result v1

    int-to-long v7, v1

    mul-long/2addr v5, v7

    long-to-int v1, v5

    new-array v1, v1, [B

    invoke-virtual {p1}, Lorg/opencv/core/Mat;->cols()I

    move-result v5

    move v6, v3

    :goto_1
    if-ge v6, v5, :cond_2

    int-to-double v7, v6

    const-wide v9, 0x406fe00000000000L    # 255.0

    div-double/2addr v7, v9

    const-wide v11, 0x3fd999999999999aL    # 0.4

    invoke-static {v7, v8, v11, v12}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v7

    mul-double/2addr v7, v9

    double-to-int v7, v7

    int-to-byte v7, v7

    aput-byte v7, v1, v6

    add-int/lit8 v6, v6, 0x1

    goto :goto_1

    :catchall_0
    move-exception p1

    goto :goto_2

    :cond_2
    invoke-virtual {p1, v3, v3, v1}, Lorg/opencv/core/Mat;->put(II[B)I

    invoke-static {v2, p1, v4}, Lorg/opencv/core/Core;->LUT(Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;Lorg/opencv/core/Mat;)V

    invoke-virtual {v4}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object p1

    iget-wide v1, p1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->width:D

    double-to-int p1, v1

    invoke-virtual {v4}, Lorg/opencv/core/Mat;->size()Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;

    move-result-object v1

    iget-wide v1, v1, Lcom/scanflow/datacapture/barinternal/org/opencv/core/Size;->height:D

    double-to-int v1, v1

    sget-object v2, Landroid/graphics/Bitmap$Config;->RGB_565:Landroid/graphics/Bitmap$Config;

    invoke-static {p1, v1, v2}, Landroid/graphics/Bitmap;->createBitmap(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;

    move-result-object p1

    const-string v1, "createBitmap(...)"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v4, p1}, Lorg/opencv/android/Utils;->matToBitmap(Lorg/opencv/core/Mat;Landroid/graphics/Bitmap;)V

    .line 4
    :cond_3
    new-instance v1, Lcom/scanflow/datacapture/model/LowLightResponse;

    invoke-direct {v1, p1, v0}, Lcom/scanflow/datacapture/model/LowLightResponse;-><init>(Landroid/graphics/Bitmap;Z)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit p0

    return-object v1

    :goto_2
    :try_start_2
    monitor-exit p0
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw p1
.end method
