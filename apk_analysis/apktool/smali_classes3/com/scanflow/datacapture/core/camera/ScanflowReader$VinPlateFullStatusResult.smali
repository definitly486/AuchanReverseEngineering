.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "VinPlateFullStatusResult"
.end annotation


# instance fields
.field private final axle1:Z

.field private final axle2:Z

.field private final axle3:Z

.field private final axle4:Z

.field private final axle5:Z

.field private final gcw:Z

.field private final gvm:Z

.field private final typ:Z

.field private final vin:Z


# direct methods
.method public constructor <init>(ZZZZZZZZZ)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    iput-boolean p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    iput-boolean p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    iput-boolean p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    iput-boolean p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    iput-boolean p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    iput-boolean p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    iput-boolean p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    iput-boolean p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;ZZZZZZZZZILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;
    .locals 0

    .line 0
    and-int/lit8 p11, p10, 0x1

    if-eqz p11, :cond_0

    iget-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    :cond_0
    and-int/lit8 p11, p10, 0x2

    if-eqz p11, :cond_1

    iget-boolean p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    :cond_1
    and-int/lit8 p11, p10, 0x4

    if-eqz p11, :cond_2

    iget-boolean p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    :cond_2
    and-int/lit8 p11, p10, 0x8

    if-eqz p11, :cond_3

    iget-boolean p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    :cond_3
    and-int/lit8 p11, p10, 0x10

    if-eqz p11, :cond_4

    iget-boolean p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    :cond_4
    and-int/lit8 p11, p10, 0x20

    if-eqz p11, :cond_5

    iget-boolean p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    :cond_5
    and-int/lit8 p11, p10, 0x40

    if-eqz p11, :cond_6

    iget-boolean p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    :cond_6
    and-int/lit16 p11, p10, 0x80

    if-eqz p11, :cond_7

    iget-boolean p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    :cond_7
    and-int/lit16 p10, p10, 0x100

    if-eqz p10, :cond_8

    iget-boolean p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    :cond_8
    move p10, p8

    move p11, p9

    move p8, p6

    move p9, p7

    move p6, p4

    move p7, p5

    move p4, p2

    move p5, p3

    move-object p2, p0

    move p3, p1

    invoke-virtual/range {p2 .. p11}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->copy(ZZZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    return v0
.end method

.method public final component2()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    return v0
.end method

.method public final component3()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    return v0
.end method

.method public final component4()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    return v0
.end method

.method public final component5()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    return v0
.end method

.method public final component6()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    return v0
.end method

.method public final component7()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    return v0
.end method

.method public final component8()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    return v0
.end method

.method public final component9()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    return v0
.end method

.method public final copy(ZZZZZZZZZ)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;
    .locals 10

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;

    move v1, p1

    move v2, p2

    move v3, p3

    move v4, p4

    move v5, p5

    move/from16 v6, p6

    move/from16 v7, p7

    move/from16 v8, p8

    move/from16 v9, p9

    invoke-direct/range {v0 .. v9}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;-><init>(ZZZZZZZZZ)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    if-eq v1, v3, :cond_2

    return v2

    :cond_2
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    if-eq v1, v3, :cond_3

    return v2

    :cond_3
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    if-eq v1, v3, :cond_4

    return v2

    :cond_4
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    if-eq v1, v3, :cond_5

    return v2

    :cond_5
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    if-eq v1, v3, :cond_6

    return v2

    :cond_6
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    if-eq v1, v3, :cond_7

    return v2

    :cond_7
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    if-eq v1, v3, :cond_8

    return v2

    :cond_8
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    if-eq v1, v3, :cond_9

    return v2

    :cond_9
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    iget-boolean p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    if-eq v1, p1, :cond_a

    return v2

    :cond_a
    return v0
.end method

.method public final getAxle1()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    return v0
.end method

.method public final getAxle2()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    return v0
.end method

.method public final getAxle3()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    return v0
.end method

.method public final getAxle4()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    return v0
.end method

.method public final getAxle5()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    return v0
.end method

.method public final getGcw()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    return v0
.end method

.method public final getGvm()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    return v0
.end method

.method public final getTyp()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    return v0
.end method

.method public final getVin()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    return v0
.end method

.method public hashCode()I
    .locals 3

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    invoke-static {v0}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v0

    const/16 v1, 0x1f

    mul-int/2addr v0, v1

    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    .line 1
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 2
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    .line 3
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 4
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    .line 5
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 6
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    .line 7
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 8
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    .line 9
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 10
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    .line 11
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 12
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    .line 13
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 14
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    invoke-static {v1}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "VinPlateFullStatusResult(typ="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->typ:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", vin="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->vin:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", gvm="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gvm:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", gcw="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->gcw:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axle1="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle1:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axle2="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle2:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axle3="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle3:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axle4="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle4:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", axle5="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullStatusResult;->axle5:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
