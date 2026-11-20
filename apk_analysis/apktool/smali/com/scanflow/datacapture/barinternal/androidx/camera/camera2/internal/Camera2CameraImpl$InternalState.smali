.class final enum Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;
.super Ljava/lang/Enum;
.source "Camera2CameraImpl.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4018
    name = "InternalState"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum CLOSING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum CONFIGURED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum PENDING_OPEN:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum REOPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

.field public static final enum REOPENING_QUIRK:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;
    .locals 10

    .line 1835
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->PENDING_OPEN:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->CLOSING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->REOPENING_QUIRK:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->REOPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v8, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v9, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->CONFIGURED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    filled-new-array/range {v0 .. v9}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 1842
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "RELEASED"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1848
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "RELEASING"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1859
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "INITIALIZED"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1868
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "PENDING_OPEN"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->PENDING_OPEN:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1874
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "CLOSING"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->CLOSING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1885
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "REOPENING_QUIRK"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->REOPENING_QUIRK:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1895
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "REOPENING"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->REOPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1902
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "OPENING"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1909
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "OPENED"

    const/16 v2, 0x8

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1916
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    const-string v1, "CONFIGURED"

    const/16 v2, 0x9

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->CONFIGURED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    .line 1835
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->$values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 1835
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;
    .locals 1

    .line 1835
    const-class v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;
    .locals 1

    .line 1835
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    return-object v0
.end method
