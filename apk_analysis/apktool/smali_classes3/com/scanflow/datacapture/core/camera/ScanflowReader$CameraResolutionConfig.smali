.class public final enum Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/core/camera/ScanflowReader;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "CameraResolutionConfig"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $ENTRIES:Lkotlin/enums/EnumEntries;

.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

.field public static final enum FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

.field public static final enum HD_720P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

.field public static final enum SD_480P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

.field public static final enum UHD_4K:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;


# instance fields
.field private final size:Landroid/util/Size;


# direct methods
.method private static final synthetic $values()[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;
    .locals 4

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->SD_480P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    sget-object v1, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->HD_720P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    sget-object v2, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    sget-object v3, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->UHD_4K:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    filled-new-array {v0, v1, v2, v3}, [Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 4

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v1, Landroid/util/Size;

    const/16 v2, 0x1e0

    const/16 v3, 0x280

    invoke-direct {v1, v2, v3}, Landroid/util/Size;-><init>(II)V

    const-string v2, "SD_480P"

    const/4 v3, 0x0

    invoke-direct {v0, v2, v3, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;-><init>(Ljava/lang/String;ILandroid/util/Size;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->SD_480P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v1, Landroid/util/Size;

    const/16 v2, 0x2d0

    const/16 v3, 0x500

    invoke-direct {v1, v2, v3}, Landroid/util/Size;-><init>(II)V

    const-string v2, "HD_720P"

    const/4 v3, 0x1

    invoke-direct {v0, v2, v3, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;-><init>(Ljava/lang/String;ILandroid/util/Size;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->HD_720P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v1, Landroid/util/Size;

    const/16 v2, 0x438

    const/16 v3, 0x780

    invoke-direct {v1, v2, v3}, Landroid/util/Size;-><init>(II)V

    const-string v2, "FULL_HD_1080P"

    const/4 v3, 0x2

    invoke-direct {v0, v2, v3, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;-><init>(Ljava/lang/String;ILandroid/util/Size;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->FULL_HD_1080P:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    new-instance v1, Landroid/util/Size;

    const/16 v2, 0x870

    const/16 v3, 0xf00

    invoke-direct {v1, v2, v3}, Landroid/util/Size;-><init>(II)V

    const-string v2, "UHD_4K"

    const/4 v3, 0x3

    invoke-direct {v0, v2, v3, v1}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;-><init>(Ljava/lang/String;ILandroid/util/Size;)V

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->UHD_4K:Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-static {}, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->$values()[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->$VALUES:[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;ILandroid/util/Size;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/util/Size;",
            ")V"
        }
    .end annotation

    .line 0
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    iput-object p3, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->size:Landroid/util/Size;

    return-void
.end method

.method public static getEntries()Lkotlin/enums/EnumEntries;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lkotlin/enums/EnumEntries<",
            "Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;",
            ">;"
        }
    .end annotation

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->$ENTRIES:Lkotlin/enums/EnumEntries;

    return-object v0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->$VALUES:[Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;

    return-object v0
.end method


# virtual methods
.method public final getSize()Landroid/util/Size;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/camera/ScanflowReader$CameraResolutionConfig;->size:Landroid/util/Size;

    return-object v0
.end method
