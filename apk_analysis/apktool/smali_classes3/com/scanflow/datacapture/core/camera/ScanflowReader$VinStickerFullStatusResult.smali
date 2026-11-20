.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "VinStickerFullStatusResult"
.end annotation


# instance fields
.field private final axleOneByTwo:Z

.field private final axleThreeByFour:Z

.field private final category:Z

.field private final date:Z

.field private final gcw:Z

.field private final type:Z

.field private final vin:Z


# direct methods
.method public constructor <init>(ZZZZZZZ)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    iput-boolean p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    iput-boolean p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    iput-boolean p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    iput-boolean p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    iput-boolean p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    iput-boolean p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;ZZZZZZZILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;
    .locals 0

    .line 0
    and-int/lit8 p9, p8, 0x1

    if-eqz p9, :cond_0

    iget-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    :cond_0
    and-int/lit8 p9, p8, 0x2

    if-eqz p9, :cond_1

    iget-boolean p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    :cond_1
    and-int/lit8 p9, p8, 0x4

    if-eqz p9, :cond_2

    iget-boolean p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    :cond_2
    and-int/lit8 p9, p8, 0x8

    if-eqz p9, :cond_3

    iget-boolean p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    :cond_3
    and-int/lit8 p9, p8, 0x10

    if-eqz p9, :cond_4

    iget-boolean p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    :cond_4
    and-int/lit8 p9, p8, 0x20

    if-eqz p9, :cond_5

    iget-boolean p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    :cond_5
    and-int/lit8 p8, p8, 0x40

    if-eqz p8, :cond_6

    iget-boolean p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    :cond_6
    move p8, p6

    move p9, p7

    move p6, p4

    move p7, p5

    move p4, p2

    move p5, p3

    move-object p2, p0

    move p3, p1

    invoke-virtual/range {p2 .. p9}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->copy(ZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    return v0
.end method

.method public final component2()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    return v0
.end method

.method public final component3()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    return v0
.end method

.method public final component4()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    return v0
.end method

.method public final component5()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    return v0
.end method

.method public final component6()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    return v0
.end method

.method public final component7()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    return v0
.end method

.method public final copy(ZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;
    .locals 8

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;

    move v1, p1

    move v2, p2

    move v3, p3

    move v4, p4

    move v5, p5

    move v6, p6

    move v7, p7

    invoke-direct/range {v0 .. v7}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;-><init>(ZZZZZZZ)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    if-eq v1, v3, :cond_2

    return v2

    :cond_2
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    if-eq v1, v3, :cond_3

    return v2

    :cond_3
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    if-eq v1, v3, :cond_4

    return v2

    :cond_4
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    if-eq v1, v3, :cond_5

    return v2

    :cond_5
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    if-eq v1, v3, :cond_6

    return v2

    :cond_6
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    if-eq v1, v3, :cond_7

    return v2

    :cond_7
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    iget-boolean p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    if-eq v1, p1, :cond_8

    return v2

    :cond_8
    return v0
.end method

.method public final getAxleOneByTwo()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    return v0
.end method

.method public final getAxleThreeByFour()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    return v0
.end method

.method public final getCategory()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    return v0
.end method

.method public final getDate()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    return v0
.end method

.method public final getGcw()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    return v0
.end method

.method public final getType()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    return v0
.end method

.method public final getVin()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    return v0
.end method

.method public hashCode()I
    .locals 3

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    invoke-static {v0}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v0

    const/16 v1, 0x1f

    mul-int/2addr v0, v1

    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    .line 1
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 2
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    .line 3
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 4
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    .line 5
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 6
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    .line 7
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 8
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    .line 9
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 10
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    invoke-static {v1}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "VinStickerFullStatusResult(vin="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->vin:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", date="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->date:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", category="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->category:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", gcw="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->gcw:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axleOneByTwo="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleOneByTwo:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axleThreeByFour="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->axleThreeByFour:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", type="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinStickerFullStatusResult;->type:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
