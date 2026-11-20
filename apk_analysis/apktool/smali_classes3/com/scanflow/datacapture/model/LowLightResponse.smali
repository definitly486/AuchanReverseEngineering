.class public final Lcom/scanflow/datacapture/model/LowLightResponse;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final bitmap:Landroid/graphics/Bitmap;

.field private final isLowLight:Z


# direct methods
.method public constructor <init>(Landroid/graphics/Bitmap;Z)V
    .locals 1

    .line 0
    const-string v0, "bitmap"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    iput-boolean p2, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/model/LowLightResponse;Landroid/graphics/Bitmap;ZILjava/lang/Object;)Lcom/scanflow/datacapture/model/LowLightResponse;
    .locals 0

    .line 0
    and-int/lit8 p4, p3, 0x1

    if-eqz p4, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    :cond_0
    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_1

    iget-boolean p2, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    :cond_1
    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/model/LowLightResponse;->copy(Landroid/graphics/Bitmap;Z)Lcom/scanflow/datacapture/model/LowLightResponse;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final component2()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    return v0
.end method

.method public final copy(Landroid/graphics/Bitmap;Z)Lcom/scanflow/datacapture/model/LowLightResponse;
    .locals 1

    .line 0
    const-string v0, "bitmap"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/scanflow/datacapture/model/LowLightResponse;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/model/LowLightResponse;-><init>(Landroid/graphics/Bitmap;Z)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/model/LowLightResponse;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/model/LowLightResponse;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-boolean v1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    iget-boolean p1, p1, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    if-eq v1, p1, :cond_3

    return v2

    :cond_3
    return v0
.end method

.method public final getBitmap()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    iget-boolean v1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    invoke-static {v1}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public final isLowLight()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "LowLightResponse(bitmap="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->bitmap:Landroid/graphics/Bitmap;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", isLowLight="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/model/LowLightResponse;->isLowLight:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
