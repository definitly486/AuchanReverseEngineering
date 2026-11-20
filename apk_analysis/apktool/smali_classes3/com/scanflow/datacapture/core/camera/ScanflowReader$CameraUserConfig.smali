.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "CameraUserConfig"
.end annotation


# instance fields
.field private final autoZoom:Z

.field private final beepSoundResource:Ljava/lang/Integer;

.field private echanceTextCount:I

.field private final enableTireAngleDetection:Z

.field private final enableTirePreProcessing:Z

.field private final isContinuousScan:Z

.field private final isDataTracking:Z

.field private isEnhanceTextResult:Z

.field private final isNetworkAvailable:Z

.field private final isOneTouchZoomEnabled:Z

.field private final isPerformCaptureScan:Z

.field private latitudeObj:D

.field private final licenseInfo:Ljava/lang/String;

.field private longitudeObj:D

.field private final mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

.field private final playBeep:Z

.field private final selectedResolution:Landroid/util/Size;

.field private selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

.field private final switchCategory:Ljava/lang/String;

.field private final vibrate:Z


# direct methods
.method public constructor <init>(ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;)V
    .locals 3

    .line 0
    move-object/from16 v0, p21

    move-object/from16 v1, p22

    const-string v2, "selectedResolution"

    invoke-static {p5, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "licenseInfo"

    invoke-static {p8, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "selectedVinNumberColorConfig"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v2, "switchCategory"

    invoke-static {v1, v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    iput-boolean p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    iput-boolean p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    iput-boolean p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    iput-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    iput-boolean p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    iput-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iput-object p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    iput-object p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    iput-boolean p10, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    iput-boolean p11, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    iput-boolean p12, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    move/from16 p1, p13

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    move/from16 p1, p14

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    move-wide/from16 p1, p15

    iput-wide p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    move-wide/from16 p1, p17

    iput-wide p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    move/from16 p1, p19

    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    move/from16 p1, p20

    iput p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    iput-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iput-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;ILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;
    .locals 17

    .line 0
    move-object/from16 v0, p0

    move/from16 v1, p23

    and-int/lit8 v2, v1, 0x1

    if-eqz v2, :cond_0

    iget-boolean v2, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    goto :goto_0

    :cond_0
    move/from16 v2, p1

    :goto_0
    and-int/lit8 v3, v1, 0x2

    if-eqz v3, :cond_1

    iget-boolean v3, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    goto :goto_1

    :cond_1
    move/from16 v3, p2

    :goto_1
    and-int/lit8 v4, v1, 0x4

    if-eqz v4, :cond_2

    iget-boolean v4, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    goto :goto_2

    :cond_2
    move/from16 v4, p3

    :goto_2
    and-int/lit8 v5, v1, 0x8

    if-eqz v5, :cond_3

    iget-boolean v5, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    goto :goto_3

    :cond_3
    move/from16 v5, p4

    :goto_3
    and-int/lit8 v6, v1, 0x10

    if-eqz v6, :cond_4

    iget-object v6, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    goto :goto_4

    :cond_4
    move-object/from16 v6, p5

    :goto_4
    and-int/lit8 v7, v1, 0x20

    if-eqz v7, :cond_5

    iget-boolean v7, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    goto :goto_5

    :cond_5
    move/from16 v7, p6

    :goto_5
    and-int/lit8 v8, v1, 0x40

    if-eqz v8, :cond_6

    iget-object v8, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    goto :goto_6

    :cond_6
    move-object/from16 v8, p7

    :goto_6
    and-int/lit16 v9, v1, 0x80

    if-eqz v9, :cond_7

    iget-object v9, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    goto :goto_7

    :cond_7
    move-object/from16 v9, p8

    :goto_7
    and-int/lit16 v10, v1, 0x100

    if-eqz v10, :cond_8

    iget-object v10, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    goto :goto_8

    :cond_8
    move-object/from16 v10, p9

    :goto_8
    and-int/lit16 v11, v1, 0x200

    if-eqz v11, :cond_9

    iget-boolean v11, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    goto :goto_9

    :cond_9
    move/from16 v11, p10

    :goto_9
    and-int/lit16 v12, v1, 0x400

    if-eqz v12, :cond_a

    iget-boolean v12, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    goto :goto_a

    :cond_a
    move/from16 v12, p11

    :goto_a
    and-int/lit16 v13, v1, 0x800

    if-eqz v13, :cond_b

    iget-boolean v13, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    goto :goto_b

    :cond_b
    move/from16 v13, p12

    :goto_b
    and-int/lit16 v14, v1, 0x1000

    if-eqz v14, :cond_c

    iget-boolean v14, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    goto :goto_c

    :cond_c
    move/from16 v14, p13

    :goto_c
    and-int/lit16 v15, v1, 0x2000

    if-eqz v15, :cond_d

    iget-boolean v15, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    goto :goto_d

    :cond_d
    move/from16 v15, p14

    :goto_d
    move/from16 p1, v2

    and-int/lit16 v2, v1, 0x4000

    if-eqz v2, :cond_e

    iget-wide v1, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    goto :goto_e

    :cond_e
    move-wide/from16 v1, p15

    :goto_e
    const v16, 0x8000

    and-int v16, p23, v16

    move-wide/from16 p2, v1

    if-eqz v16, :cond_f

    iget-wide v1, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    goto :goto_f

    :cond_f
    move-wide/from16 v1, p17

    :goto_f
    const/high16 v16, 0x10000

    and-int v16, p23, v16

    move-wide/from16 p4, v1

    if-eqz v16, :cond_10

    iget-boolean v1, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    goto :goto_10

    :cond_10
    move/from16 v1, p19

    :goto_10
    const/high16 v2, 0x20000

    and-int v2, p23, v2

    if-eqz v2, :cond_11

    iget v2, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    goto :goto_11

    :cond_11
    move/from16 v2, p20

    :goto_11
    const/high16 v16, 0x40000

    and-int v16, p23, v16

    move/from16 p6, v1

    if-eqz v16, :cond_12

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    goto :goto_12

    :cond_12
    move-object/from16 v1, p21

    :goto_12
    const/high16 v16, 0x80000

    and-int v16, p23, v16

    if-eqz v16, :cond_13

    move-object/from16 p7, v1

    iget-object v1, v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    move-object/from16 p22, p7

    move-object/from16 p23, v1

    :goto_13
    move-wide/from16 p16, p2

    move-wide/from16 p18, p4

    move/from16 p20, p6

    move/from16 p21, v2

    move/from16 p3, v3

    move/from16 p4, v4

    move/from16 p5, v5

    move-object/from16 p6, v6

    move/from16 p7, v7

    move-object/from16 p8, v8

    move-object/from16 p9, v9

    move-object/from16 p10, v10

    move/from16 p11, v11

    move/from16 p12, v12

    move/from16 p13, v13

    move/from16 p14, v14

    move/from16 p15, v15

    move/from16 p2, p1

    move-object/from16 p1, v0

    goto :goto_14

    :cond_13
    move-object/from16 p23, p22

    move-object/from16 p22, v1

    goto :goto_13

    :goto_14
    invoke-virtual/range {p1 .. p23}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->copy(ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public final component1()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    return v0
.end method

.method public final component10()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    return v0
.end method

.method public final component11()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    return v0
.end method

.method public final component12()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    return v0
.end method

.method public final component13()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    return v0
.end method

.method public final component14()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    return v0
.end method

.method public final component15()D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    return-wide v0
.end method

.method public final component16()D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    return-wide v0
.end method

.method public final component17()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    return v0
.end method

.method public final component18()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    return v0
.end method

.method public final component19()Lcom/scanflow/datacapture/config/VinNumberColorConfig;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-object v0
.end method

.method public final component2()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    return v0
.end method

.method public final component20()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    return-object v0
.end method

.method public final component3()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    return v0
.end method

.method public final component4()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    return v0
.end method

.method public final component5()Landroid/util/Size;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    return-object v0
.end method

.method public final component6()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    return v0
.end method

.method public final component7()Lcom/scanflow/datacapture/core/camera/manager/BeepManager;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    return-object v0
.end method

.method public final component8()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    return-object v0
.end method

.method public final component9()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    return-object v0
.end method

.method public final copy(ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;
    .locals 24

    .line 0
    const-string v0, "selectedResolution"

    move-object/from16 v6, p5

    invoke-static {v6, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "licenseInfo"

    move-object/from16 v9, p8

    invoke-static {v9, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "selectedVinNumberColorConfig"

    move-object/from16 v1, p21

    invoke-static {v1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "switchCategory"

    move-object/from16 v2, p22

    invoke-static {v2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    move/from16 v3, p2

    move/from16 v4, p3

    move/from16 v5, p4

    move/from16 v7, p6

    move-object/from16 v8, p7

    move-object/from16 v10, p9

    move/from16 v11, p10

    move/from16 v12, p11

    move/from16 v13, p12

    move/from16 v14, p13

    move/from16 v15, p14

    move-wide/from16 v16, p15

    move-wide/from16 v18, p17

    move/from16 v20, p19

    move/from16 v21, p20

    move-object/from16 v22, p21

    move-object/from16 v23, v2

    move/from16 v2, p1

    invoke-direct/range {v1 .. v23}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;-><init>(ZZZZLandroid/util/Size;ZLcom/scanflow/datacapture/core/camera/manager/BeepManager;Ljava/lang/String;Ljava/lang/Integer;ZZZZZDDZILcom/scanflow/datacapture/config/VinNumberColorConfig;Ljava/lang/String;)V

    return-object v1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 7

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    if-eq v1, v3, :cond_2

    return v2

    :cond_2
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    if-eq v1, v3, :cond_3

    return v2

    :cond_3
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    if-eq v1, v3, :cond_4

    return v2

    :cond_4
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    if-eq v1, v3, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    if-eq v1, v3, :cond_7

    return v2

    :cond_7
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_8

    return v2

    :cond_8
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_9

    return v2

    :cond_9
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_a

    return v2

    :cond_a
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    if-eq v1, v3, :cond_b

    return v2

    :cond_b
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    if-eq v1, v3, :cond_c

    return v2

    :cond_c
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    if-eq v1, v3, :cond_d

    return v2

    :cond_d
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    if-eq v1, v3, :cond_e

    return v2

    :cond_e
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    if-eq v1, v3, :cond_f

    return v2

    :cond_f
    iget-wide v3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    invoke-static {v3, v4, v5, v6}, Ljava/lang/Double;->compare(DD)I

    move-result v1

    if-eqz v1, :cond_10

    return v2

    :cond_10
    iget-wide v3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    iget-wide v5, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    invoke-static {v3, v4, v5, v6}, Ljava/lang/Double;->compare(DD)I

    move-result v1

    if-eqz v1, :cond_11

    return v2

    :cond_11
    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    iget-boolean v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    if-eq v1, v3, :cond_12

    return v2

    :cond_12
    iget v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    iget v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    if-eq v1, v3, :cond_13

    return v2

    :cond_13
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    if-eq v1, v3, :cond_14

    return v2

    :cond_14
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    iget-object p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_15

    return v2

    :cond_15
    return v0
.end method

.method public final getAutoZoom()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    return v0
.end method

.method public final getBeepSoundResource()Ljava/lang/Integer;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    return-object v0
.end method

.method public final getEchanceTextCount()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    return v0
.end method

.method public final getEnableTireAngleDetection()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    return v0
.end method

.method public final getEnableTirePreProcessing()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    return v0
.end method

.method public final getLatitudeObj()D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    return-wide v0
.end method

.method public final getLicenseInfo()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    return-object v0
.end method

.method public final getLongitudeObj()D
    .locals 2

    .line 0
    iget-wide v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    return-wide v0
.end method

.method public final getMBeepManager()Lcom/scanflow/datacapture/core/camera/manager/BeepManager;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    return-object v0
.end method

.method public final getPlayBeep()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    return v0
.end method

.method public final getSelectedResolution()Landroid/util/Size;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    return-object v0
.end method

.method public final getSelectedVinNumberColorConfig()Lcom/scanflow/datacapture/config/VinNumberColorConfig;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-object v0
.end method

.method public final getSwitchCategory()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    return-object v0
.end method

.method public final getVibrate()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    return v0
.end method

.method public hashCode()I
    .locals 5

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    invoke-static {v0}, Ljava/lang/Boolean;->hashCode(Z)I

    move-result v0

    const/16 v1, 0x1f

    mul-int/2addr v0, v1

    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    .line 1
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 2
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    .line 3
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 4
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    .line 5
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 6
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    invoke-virtual {v2}, Landroid/util/Size;->hashCode()I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    .line 7
    invoke-static {v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 8
    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    const/4 v3, 0x0

    if-nez v2, :cond_0

    move v2, v3

    goto :goto_0

    :cond_0
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_0
    add-int/2addr v0, v2

    mul-int/2addr v0, v1

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    if-nez v0, :cond_1

    goto :goto_1

    :cond_1
    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v3

    :goto_1
    add-int/2addr v2, v3

    mul-int/2addr v2, v1

    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    .line 9
    invoke-static {v0, v2, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 10
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    .line 11
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 12
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    .line 13
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 14
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    .line 15
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 16
    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    .line 17
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 18
    iget-wide v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    invoke-static {v2, v3}, Ljava/lang/Double;->hashCode(D)I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-wide v3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    invoke-static {v3, v4}, Ljava/lang/Double;->hashCode(D)I

    move-result v0

    add-int/2addr v0, v2

    mul-int/2addr v0, v1

    iget-boolean v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    .line 19
    invoke-static {v2, v0, v1}, Lcom/scanflow/datacapture/barinternal/c/a;->a(ZII)I

    move-result v0

    .line 20
    iget v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    invoke-static {v2}, Ljava/lang/Integer;->hashCode(I)I

    move-result v2

    add-int/2addr v2, v0

    mul-int/2addr v2, v1

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    add-int/2addr v0, v2

    mul-int/2addr v0, v1

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    return v1
.end method

.method public final isContinuousScan()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    return v0
.end method

.method public final isDataTracking()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    return v0
.end method

.method public final isEnhanceTextResult()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    return v0
.end method

.method public final isNetworkAvailable()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    return v0
.end method

.method public final isOneTouchZoomEnabled()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    return v0
.end method

.method public final isPerformCaptureScan()Z
    .locals 1

    .line 0
    iget-boolean v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    return v0
.end method

.method public final setEchanceTextCount(I)V
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    return-void
.end method

.method public final setEnhanceTextResult(Z)V
    .locals 0

    .line 0
    iput-boolean p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    return-void
.end method

.method public final setLatitudeObj(D)V
    .locals 0

    .line 0
    iput-wide p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    return-void
.end method

.method public final setLongitudeObj(D)V
    .locals 0

    .line 0
    iput-wide p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    return-void
.end method

.method public final setSelectedVinNumberColorConfig(Lcom/scanflow/datacapture/config/VinNumberColorConfig;)V
    .locals 1

    .line 0
    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 3

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "CameraUserConfig(isContinuousScan="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isContinuousScan:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", isPerformCaptureScan="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isPerformCaptureScan:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", autoZoom="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->autoZoom:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", isOneTouchZoomEnabled="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isOneTouchZoomEnabled:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", selectedResolution="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedResolution:Landroid/util/Size;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", isNetworkAvailable="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isNetworkAvailable:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", mBeepManager="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->mBeepManager:Lcom/scanflow/datacapture/core/camera/manager/BeepManager;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", licenseInfo="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->licenseInfo:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", beepSoundResource="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->beepSoundResource:Ljava/lang/Integer;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", playBeep="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->playBeep:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", vibrate="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->vibrate:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", isDataTracking="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isDataTracking:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", enableTirePreProcessing="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTirePreProcessing:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", enableTireAngleDetection="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->enableTireAngleDetection:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", latitudeObj="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->latitudeObj:D

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v1, ", longitudeObj="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-wide v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->longitudeObj:D

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    const-string v1, ", isEnhanceTextResult="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-boolean v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->isEnhanceTextResult:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    const-string v1, ", echanceTextCount="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->echanceTextCount:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ", selectedVinNumberColorConfig="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->selectedVinNumberColorConfig:Lcom/scanflow/datacapture/config/VinNumberColorConfig;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", switchCategory="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraUserConfig;->switchCategory:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
