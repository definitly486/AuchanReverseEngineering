.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "VinPlateFullScanResult"
.end annotation


# instance fields
.field private final axle1:Ljava/lang/String;

.field private final axle2:Ljava/lang/String;

.field private final axle3:Ljava/lang/String;

.field private final axle4:Ljava/lang/String;

.field private final axle5:Ljava/lang/String;

.field private final gcw:Ljava/lang/String;

.field private final gvm:Ljava/lang/String;

.field private final suggestedTypResults:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private final suggestedVinResults:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private final typ:Ljava/lang/String;

.field private final vin:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .line 0
    const-string v0, "typ"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "vin"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "gvm"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "suggestedTypResults"

    invoke-static {p10, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "suggestedVinResults"

    invoke-static {p11, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    iput-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    iput-object p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    iput-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    iput-object p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    iput-object p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    iput-object p10, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    iput-object p11, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;ILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;
    .locals 0

    .line 0
    and-int/lit8 p13, p12, 0x1

    if-eqz p13, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    :cond_0
    and-int/lit8 p13, p12, 0x2

    if-eqz p13, :cond_1

    iget-object p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    :cond_1
    and-int/lit8 p13, p12, 0x4

    if-eqz p13, :cond_2

    iget-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    :cond_2
    and-int/lit8 p13, p12, 0x8

    if-eqz p13, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    :cond_3
    and-int/lit8 p13, p12, 0x10

    if-eqz p13, :cond_4

    iget-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    :cond_4
    and-int/lit8 p13, p12, 0x20

    if-eqz p13, :cond_5

    iget-object p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    :cond_5
    and-int/lit8 p13, p12, 0x40

    if-eqz p13, :cond_6

    iget-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    :cond_6
    and-int/lit16 p13, p12, 0x80

    if-eqz p13, :cond_7

    iget-object p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    :cond_7
    and-int/lit16 p13, p12, 0x100

    if-eqz p13, :cond_8

    iget-object p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    :cond_8
    and-int/lit16 p13, p12, 0x200

    if-eqz p13, :cond_9

    iget-object p10, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    :cond_9
    and-int/lit16 p12, p12, 0x400

    if-eqz p12, :cond_a

    iget-object p11, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    :cond_a
    move-object p12, p10

    move-object p13, p11

    move-object p10, p8

    move-object p11, p9

    move-object p8, p6

    move-object p9, p7

    move-object p6, p4

    move-object p7, p5

    move-object p4, p2

    move-object p5, p3

    move-object p2, p0

    move-object p3, p1

    invoke-virtual/range {p2 .. p13}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->copy(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    return-object v0
.end method

.method public final component10()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final component11()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final component2()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    return-object v0
.end method

.method public final component3()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    return-object v0
.end method

.method public final component4()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    return-object v0
.end method

.method public final component5()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    return-object v0
.end method

.method public final component6()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    return-object v0
.end method

.method public final component7()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    return-object v0
.end method

.method public final component8()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    return-object v0
.end method

.method public final component9()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    return-object v0
.end method

.method public final copy(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;
    .locals 13
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;"
        }
    .end annotation

    .line 0
    const-string v0, "typ"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "vin"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "gvm"

    move-object/from16 v4, p3

    invoke-static {v4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "suggestedTypResults"

    move-object/from16 v11, p10

    invoke-static {v11, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "suggestedVinResults"

    move-object/from16 v12, p11

    invoke-static {v12, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;

    move-object v2, p1

    move-object v3, p2

    move-object/from16 v5, p4

    move-object/from16 v6, p5

    move-object/from16 v7, p6

    move-object/from16 v8, p7

    move-object/from16 v9, p8

    move-object/from16 v10, p9

    invoke-direct/range {v1 .. v12}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/ArrayList;Ljava/util/ArrayList;)V

    return-object v1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_7

    return v2

    :cond_7
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_8

    return v2

    :cond_8
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_9

    return v2

    :cond_9
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_a

    return v2

    :cond_a
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_b

    return v2

    :cond_b
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    iget-object p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_c

    return v2

    :cond_c
    return v0
.end method

.method public final getAxle1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    return-object v0
.end method

.method public final getAxle2()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    return-object v0
.end method

.method public final getAxle3()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    return-object v0
.end method

.method public final getAxle4()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    return-object v0
.end method

.method public final getAxle5()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    return-object v0
.end method

.method public final getGcw()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    return-object v0
.end method

.method public final getGvm()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    return-object v0
.end method

.method public final getSuggestedTypResults()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final getSuggestedVinResults()Ljava/util/ArrayList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/ArrayList<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    return-object v0
.end method

.method public final getTyp()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    return-object v0
.end method

.method public final getVin()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    const/4 v2, 0x0

    if-nez v1, :cond_0

    move v1, v2

    goto :goto_0

    :cond_0
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_0
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    if-nez v1, :cond_1

    move v1, v2

    goto :goto_1

    :cond_1
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_1
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    if-nez v1, :cond_2

    move v1, v2

    goto :goto_2

    :cond_2
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_2
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    if-nez v1, :cond_3

    move v1, v2

    goto :goto_3

    :cond_3
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_3
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    if-nez v1, :cond_4

    move v1, v2

    goto :goto_4

    :cond_4
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_4
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    if-nez v1, :cond_5

    goto :goto_5

    :cond_5
    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_5
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->hashCode()I

    move-result v0

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "VinPlateFullScanResult(typ="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->typ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", vin="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->vin:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", gvm="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gvm:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", gcw="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->gcw:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", axle1="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle1:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", axle2="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle2:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", axle3="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle3:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", axle4="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle4:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", axle5="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->axle5:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", suggestedTypResults="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedTypResults:Ljava/util/ArrayList;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", suggestedVinResults="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$VinPlateFullScanResult;->suggestedVinResults:Ljava/util/ArrayList;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
