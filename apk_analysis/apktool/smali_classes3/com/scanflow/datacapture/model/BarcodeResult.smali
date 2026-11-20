.class public final Lcom/scanflow/datacapture/model/BarcodeResult;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final ScanResultFailure:Lcom/scanflow/datacapture/barinternal/i/e;

.field private final batchScanResultSuccess:Lcom/scanflow/datacapture/barinternal/i/a;

.field private final oneOfManyCodeResult:Lcom/scanflow/datacapture/barinternal/i/b;

.field private final oneofManyCodeRemoved:Lcom/scanflow/datacapture/barinternal/i/c;

.field private final oneofManyCodeSelected:Lcom/scanflow/datacapture/barinternal/i/d;

.field private final scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;


# direct methods
.method public constructor <init>()V
    .locals 9

    const/16 v7, 0x3f

    const/4 v8, 0x0

    const/4 v1, 0x0

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    move-object v0, p0

    .line 1
    invoke-direct/range {v0 .. v8}, Lcom/scanflow/datacapture/model/BarcodeResult;-><init>(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;ILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;)V
    .locals 0

    .line 2
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    return-void
.end method

.method public synthetic constructor <init>(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;ILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 1

    and-int/lit8 p8, p7, 0x1

    const/4 v0, 0x0

    if-eqz p8, :cond_0

    move-object p1, v0

    :cond_0
    and-int/lit8 p8, p7, 0x2

    if-eqz p8, :cond_1

    move-object p2, v0

    :cond_1
    and-int/lit8 p8, p7, 0x4

    if-eqz p8, :cond_2

    move-object p3, v0

    :cond_2
    and-int/lit8 p8, p7, 0x8

    if-eqz p8, :cond_3

    move-object p4, v0

    :cond_3
    and-int/lit8 p8, p7, 0x10

    if-eqz p8, :cond_4

    move-object p5, v0

    :cond_4
    and-int/lit8 p7, p7, 0x20

    if-eqz p7, :cond_5

    move-object p7, v0

    :goto_0
    move-object p6, p5

    move-object p5, p4

    move-object p4, p3

    move-object p3, p2

    move-object p2, p1

    move-object p1, p0

    goto :goto_1

    :cond_5
    move-object p7, p6

    goto :goto_0

    .line 3
    :goto_1
    invoke-direct/range {p1 .. p7}, Lcom/scanflow/datacapture/model/BarcodeResult;-><init>(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;)V

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/model/BarcodeResult;Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;ILjava/lang/Object;)Lcom/scanflow/datacapture/model/BarcodeResult;
    .locals 1

    and-int/lit8 p8, p7, 0x1

    if-eqz p8, :cond_0

    .line 1
    iget-object p1, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    :cond_0
    and-int/lit8 p8, p7, 0x2

    const/4 v0, 0x0

    if-eqz p8, :cond_1

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-object p2, v0

    :cond_1
    and-int/lit8 p8, p7, 0x4

    if-eqz p8, :cond_2

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-object p3, v0

    :cond_2
    and-int/lit8 p8, p7, 0x8

    if-eqz p8, :cond_3

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-object p4, v0

    :cond_3
    and-int/lit8 p8, p7, 0x10

    if-eqz p8, :cond_4

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-object p5, v0

    :cond_4
    and-int/lit8 p7, p7, 0x20

    if-eqz p7, :cond_5

    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-object p8, v0

    move-object p6, p4

    move-object p7, p5

    move-object p4, p2

    move-object p5, p3

    move-object p2, p0

    move-object p3, p1

    goto :goto_0

    :cond_5
    move-object p8, p6

    move-object p7, p5

    move-object p5, p3

    move-object p6, p4

    move-object p3, p1

    move-object p4, p2

    move-object p2, p0

    :goto_0
    invoke-virtual/range {p2 .. p8}, Lcom/scanflow/datacapture/model/BarcodeResult;->copy(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;)Lcom/scanflow/datacapture/model/BarcodeResult;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Lcom/scanflow/datacapture/model/ScanResultSuccess;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    return-object v0
.end method

.method public final component2()Lcom/scanflow/datacapture/barinternal/i/a;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final component3()Lcom/scanflow/datacapture/barinternal/i/b;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final component4()Lcom/scanflow/datacapture/barinternal/i/d;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final component5()Lcom/scanflow/datacapture/barinternal/i/c;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final component6()Lcom/scanflow/datacapture/barinternal/i/e;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final copy(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;)Lcom/scanflow/datacapture/model/BarcodeResult;
    .locals 7

    .line 1
    new-instance v0, Lcom/scanflow/datacapture/model/BarcodeResult;

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move-object v6, p6

    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/model/BarcodeResult;-><init>(Lcom/scanflow/datacapture/model/ScanResultSuccess;Lcom/scanflow/datacapture/barinternal/i/a;Lcom/scanflow/datacapture/barinternal/i/b;Lcom/scanflow/datacapture/barinternal/i/d;Lcom/scanflow/datacapture/barinternal/i/c;Lcom/scanflow/datacapture/barinternal/i/e;)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 3

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/model/BarcodeResult;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/model/BarcodeResult;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    iget-object p1, p1, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_2

    return v2

    :cond_2
    const/4 p1, 0x0

    invoke-static {p1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    invoke-static {p1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    invoke-static {p1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    invoke-static {p1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_6

    return v2

    :cond_6
    invoke-static {p1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_7

    return v2

    :cond_7
    return v0
.end method

.method public final getBatchScanResultSuccess()Lcom/scanflow/datacapture/barinternal/i/a;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getOneOfManyCodeResult()Lcom/scanflow/datacapture/barinternal/i/b;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getOneofManyCodeRemoved()Lcom/scanflow/datacapture/barinternal/i/c;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getOneofManyCodeSelected()Lcom/scanflow/datacapture/barinternal/i/d;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getScanResultFailure()Lcom/scanflow/datacapture/barinternal/i/e;
    .locals 1

    .line 1
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getScanResultSuccess()Lcom/scanflow/datacapture/model/ScanResultSuccess;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/ScanResultSuccess;->hashCode()I

    move-result v0

    :goto_0
    const v1, 0x1b4d89f

    mul-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "BarcodeResult(scanResultSuccess="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/model/BarcodeResult;->scanResultSuccess:Lcom/scanflow/datacapture/model/ScanResultSuccess;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", batchScanResultSuccess=null, oneOfManyCodeResult=null, oneofManyCodeSelected=null, oneofManyCodeRemoved=null, ScanResultFailure=null)"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
