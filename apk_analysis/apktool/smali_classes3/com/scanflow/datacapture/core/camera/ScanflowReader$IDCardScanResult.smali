.class public final Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "IDCardScanResult"
.end annotation


# instance fields
.field private address:Ljava/lang/String;

.field private backImage:Landroid/graphics/Bitmap;

.field private bloodGroup:Ljava/lang/String;

.field private dateOfIssue:Ljava/lang/String;

.field private dob:Ljava/lang/String;

.field private fathername:Ljava/lang/String;

.field private frontImage:Landroid/graphics/Bitmap;

.field private name:Ljava/lang/String;

.field private profileImage:Landroid/graphics/Bitmap;

.field private sex:Ljava/lang/String;

.field private uniqueId:Ljava/lang/String;

.field private validTill:Ljava/lang/String;

.field private year:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 16

    const/16 v14, 0x1fff

    const/4 v15, 0x0

    const/4 v1, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v10, 0x0

    const/4 v11, 0x0

    const/4 v12, 0x0

    const/4 v13, 0x0

    move-object/from16 v0, p0

    .line 1
    invoke-direct/range {v0 .. v15}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0

    .line 2
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    iput-object p4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    iput-object p5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    iput-object p6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    iput-object p7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    iput-object p8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    iput-object p9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    iput-object p10, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    iput-object p11, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    iput-object p12, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    iput-object p13, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    return-void
.end method

.method public synthetic constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 13

    move/from16 v0, p14

    and-int/lit8 v1, v0, 0x1

    const/4 v2, 0x0

    if-eqz v1, :cond_0

    move-object p1, v2

    :cond_0
    and-int/lit8 v1, v0, 0x2

    if-eqz v1, :cond_1

    move-object v1, v2

    goto :goto_0

    :cond_1
    move-object v1, p2

    :goto_0
    and-int/lit8 v3, v0, 0x4

    if-eqz v3, :cond_2

    move-object v3, v2

    goto :goto_1

    :cond_2
    move-object/from16 v3, p3

    :goto_1
    and-int/lit8 v4, v0, 0x8

    if-eqz v4, :cond_3

    move-object v4, v2

    goto :goto_2

    :cond_3
    move-object/from16 v4, p4

    :goto_2
    and-int/lit8 v5, v0, 0x10

    if-eqz v5, :cond_4

    move-object v5, v2

    goto :goto_3

    :cond_4
    move-object/from16 v5, p5

    :goto_3
    and-int/lit8 v6, v0, 0x20

    if-eqz v6, :cond_5

    move-object v6, v2

    goto :goto_4

    :cond_5
    move-object/from16 v6, p6

    :goto_4
    and-int/lit8 v7, v0, 0x40

    if-eqz v7, :cond_6

    move-object v7, v2

    goto :goto_5

    :cond_6
    move-object/from16 v7, p7

    :goto_5
    and-int/lit16 v8, v0, 0x80

    if-eqz v8, :cond_7

    move-object v8, v2

    goto :goto_6

    :cond_7
    move-object/from16 v8, p8

    :goto_6
    and-int/lit16 v9, v0, 0x100

    if-eqz v9, :cond_8

    move-object v9, v2

    goto :goto_7

    :cond_8
    move-object/from16 v9, p9

    :goto_7
    and-int/lit16 v10, v0, 0x200

    if-eqz v10, :cond_9

    move-object v10, v2

    goto :goto_8

    :cond_9
    move-object/from16 v10, p10

    :goto_8
    and-int/lit16 v11, v0, 0x400

    if-eqz v11, :cond_a

    move-object v11, v2

    goto :goto_9

    :cond_a
    move-object/from16 v11, p11

    :goto_9
    and-int/lit16 v12, v0, 0x800

    if-eqz v12, :cond_b

    move-object v12, v2

    goto :goto_a

    :cond_b
    move-object/from16 v12, p12

    :goto_a
    and-int/lit16 v0, v0, 0x1000

    if-eqz v0, :cond_c

    move-object/from16 p14, v2

    :goto_b
    move-object p2, p1

    move-object/from16 p3, v1

    move-object/from16 p4, v3

    move-object/from16 p5, v4

    move-object/from16 p6, v5

    move-object/from16 p7, v6

    move-object/from16 p8, v7

    move-object/from16 p9, v8

    move-object/from16 p10, v9

    move-object/from16 p11, v10

    move-object/from16 p12, v11

    move-object/from16 p13, v12

    move-object p1, p0

    goto :goto_c

    :cond_c
    move-object/from16 p14, p13

    goto :goto_b

    .line 3
    :goto_c
    invoke-direct/range {p1 .. p14}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/Object;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;
    .locals 12

    .line 0
    move/from16 v0, p14

    and-int/lit8 v1, v0, 0x1

    if-eqz v1, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    :cond_0
    and-int/lit8 v1, v0, 0x2

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    goto :goto_0

    :cond_1
    move-object v1, p2

    :goto_0
    and-int/lit8 v2, v0, 0x4

    if-eqz v2, :cond_2

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    goto :goto_1

    :cond_2
    move-object v2, p3

    :goto_1
    and-int/lit8 v3, v0, 0x8

    if-eqz v3, :cond_3

    iget-object v3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    goto :goto_2

    :cond_3
    move-object/from16 v3, p4

    :goto_2
    and-int/lit8 v4, v0, 0x10

    if-eqz v4, :cond_4

    iget-object v4, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    goto :goto_3

    :cond_4
    move-object/from16 v4, p5

    :goto_3
    and-int/lit8 v5, v0, 0x20

    if-eqz v5, :cond_5

    iget-object v5, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    goto :goto_4

    :cond_5
    move-object/from16 v5, p6

    :goto_4
    and-int/lit8 v6, v0, 0x40

    if-eqz v6, :cond_6

    iget-object v6, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    goto :goto_5

    :cond_6
    move-object/from16 v6, p7

    :goto_5
    and-int/lit16 v7, v0, 0x80

    if-eqz v7, :cond_7

    iget-object v7, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    goto :goto_6

    :cond_7
    move-object/from16 v7, p8

    :goto_6
    and-int/lit16 v8, v0, 0x100

    if-eqz v8, :cond_8

    iget-object v8, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    goto :goto_7

    :cond_8
    move-object/from16 v8, p9

    :goto_7
    and-int/lit16 v9, v0, 0x200

    if-eqz v9, :cond_9

    iget-object v9, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    goto :goto_8

    :cond_9
    move-object/from16 v9, p10

    :goto_8
    and-int/lit16 v10, v0, 0x400

    if-eqz v10, :cond_a

    iget-object v10, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    goto :goto_9

    :cond_a
    move-object/from16 v10, p11

    :goto_9
    and-int/lit16 v11, v0, 0x800

    if-eqz v11, :cond_b

    iget-object v11, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    goto :goto_a

    :cond_b
    move-object/from16 v11, p12

    :goto_a
    and-int/lit16 v0, v0, 0x1000

    if-eqz v0, :cond_c

    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    move-object/from16 p15, v0

    :goto_b
    move-object p2, p0

    move-object p3, p1

    move-object/from16 p4, v1

    move-object/from16 p5, v2

    move-object/from16 p6, v3

    move-object/from16 p7, v4

    move-object/from16 p8, v5

    move-object/from16 p9, v6

    move-object/from16 p10, v7

    move-object/from16 p11, v8

    move-object/from16 p12, v9

    move-object/from16 p13, v10

    move-object/from16 p14, v11

    goto :goto_c

    :cond_c
    move-object/from16 p15, p13

    goto :goto_b

    :goto_c
    invoke-virtual/range {p2 .. p15}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->copy(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    return-object v0
.end method

.method public final component10()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    return-object v0
.end method

.method public final component11()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    return-object v0
.end method

.method public final component12()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    return-object v0
.end method

.method public final component13()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    return-object v0
.end method

.method public final component2()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    return-object v0
.end method

.method public final component3()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    return-object v0
.end method

.method public final component4()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    return-object v0
.end method

.method public final component5()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    return-object v0
.end method

.method public final component6()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    return-object v0
.end method

.method public final component7()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final component8()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final component9()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final copy(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;
    .locals 14

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;

    move-object v1, p1

    move-object/from16 v2, p2

    move-object/from16 v3, p3

    move-object/from16 v4, p4

    move-object/from16 v5, p5

    move-object/from16 v6, p6

    move-object/from16 v7, p7

    move-object/from16 v8, p8

    move-object/from16 v9, p9

    move-object/from16 v10, p10

    move-object/from16 v11, p11

    move-object/from16 v12, p12

    move-object/from16 v13, p13

    invoke-direct/range {v0 .. v13}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;

    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_7

    return v2

    :cond_7
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_8

    return v2

    :cond_8
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_9

    return v2

    :cond_9
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_a

    return v2

    :cond_a
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_b

    return v2

    :cond_b
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_c

    return v2

    :cond_c
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_d

    return v2

    :cond_d
    iget-object v1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    iget-object p1, p1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_e

    return v2

    :cond_e
    return v0
.end method

.method public final getAddress()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    return-object v0
.end method

.method public final getBackImage()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final getBloodGroup()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    return-object v0
.end method

.method public final getDateOfIssue()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    return-object v0
.end method

.method public final getDob()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    return-object v0
.end method

.method public final getFathername()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    return-object v0
.end method

.method public final getFrontImage()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final getName()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    return-object v0
.end method

.method public final getProfileImage()Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    return-object v0
.end method

.method public final getSex()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    return-object v0
.end method

.method public final getUniqueId()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    return-object v0
.end method

.method public final getValidTill()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    return-object v0
.end method

.method public final getYear()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    move v0, v1

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    :goto_0
    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    if-nez v2, :cond_1

    move v2, v1

    goto :goto_1

    :cond_1
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_1
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    if-nez v2, :cond_2

    move v2, v1

    goto :goto_2

    :cond_2
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_2
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    if-nez v2, :cond_3

    move v2, v1

    goto :goto_3

    :cond_3
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_3
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    if-nez v2, :cond_4

    move v2, v1

    goto :goto_4

    :cond_4
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_4
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    if-nez v2, :cond_5

    move v2, v1

    goto :goto_5

    :cond_5
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_5
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    if-nez v2, :cond_6

    move v2, v1

    goto :goto_6

    :cond_6
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_6
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    if-nez v2, :cond_7

    move v2, v1

    goto :goto_7

    :cond_7
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_7
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    if-nez v2, :cond_8

    move v2, v1

    goto :goto_8

    :cond_8
    invoke-virtual {v2}, Ljava/lang/Object;->hashCode()I

    move-result v2

    :goto_8
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    if-nez v2, :cond_9

    move v2, v1

    goto :goto_9

    :cond_9
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_9
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    if-nez v2, :cond_a

    move v2, v1

    goto :goto_a

    :cond_a
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_a
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    if-nez v2, :cond_b

    move v2, v1

    goto :goto_b

    :cond_b
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_b
    add-int/2addr v0, v2

    mul-int/lit8 v0, v0, 0x1f

    iget-object v2, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    if-nez v2, :cond_c

    goto :goto_c

    :cond_c
    invoke-virtual {v2}, Ljava/lang/String;->hashCode()I

    move-result v1

    :goto_c
    add-int/2addr v0, v1

    return v0
.end method

.method public final setAddress(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->address:Ljava/lang/String;

    return-void
.end method

.method public final setBackImage(Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->backImage:Landroid/graphics/Bitmap;

    return-void
.end method

.method public final setBloodGroup(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->bloodGroup:Ljava/lang/String;

    return-void
.end method

.method public final setDateOfIssue(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dateOfIssue:Ljava/lang/String;

    return-void
.end method

.method public final setDob(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->dob:Ljava/lang/String;

    return-void
.end method

.method public final setFathername(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->fathername:Ljava/lang/String;

    return-void
.end method

.method public final setFrontImage(Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->frontImage:Landroid/graphics/Bitmap;

    return-void
.end method

.method public final setName(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->name:Ljava/lang/String;

    return-void
.end method

.method public final setProfileImage(Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->profileImage:Landroid/graphics/Bitmap;

    return-void
.end method

.method public final setSex(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->sex:Ljava/lang/String;

    return-void
.end method

.method public final setUniqueId(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->uniqueId:Ljava/lang/String;

    return-void
.end method

.method public final setValidTill(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->validTill:Ljava/lang/String;

    return-void
.end method

.method public final setYear(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$IDCardScanResult;->year:Ljava/lang/String;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 0
    invoke-super {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
