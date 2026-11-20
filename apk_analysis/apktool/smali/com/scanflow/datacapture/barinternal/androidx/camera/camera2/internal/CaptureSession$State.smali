.class final enum Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;
.super Ljava/lang/Enum;
.source "CaptureSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4018
    name = "State"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum CLOSED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum GET_SURFACE:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

.field public static final enum UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;
    .locals 8

    .line 902
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->GET_SURFACE:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v3, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v4, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v5, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->CLOSED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v6, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    sget-object v7, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    filled-new-array/range {v0 .. v7}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 904
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "UNINITIALIZED"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->UNINITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 909
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "INITIALIZED"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->INITIALIZED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 914
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "GET_SURFACE"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->GET_SURFACE:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 919
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "OPENING"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 925
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "OPENED"

    const/4 v2, 0x4

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 932
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "CLOSED"

    const/4 v2, 0x5

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->CLOSED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 934
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "RELEASING"

    const/4 v2, 0x6

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->RELEASING:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 939
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    const-string v1, "RELEASED"

    const/4 v2, 0x7

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->RELEASED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    .line 902
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->$values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 902
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;
    .locals 1

    .line 902
    const-class v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;
    .locals 1

    .line 902
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSession$State;

    return-object v0
.end method
