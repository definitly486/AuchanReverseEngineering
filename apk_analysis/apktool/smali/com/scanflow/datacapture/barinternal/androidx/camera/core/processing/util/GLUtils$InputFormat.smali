.class public final enum Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;
.super Ljava/lang/Enum;
.source "GLUtils.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "InputFormat"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

.field public static final enum DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

.field public static final enum UNKNOWN:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

.field public static final enum YUV:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;
    .locals 3

    .line 203
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->YUV:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 212
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    const-string v1, "UNKNOWN"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    .line 220
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    const-string v1, "DEFAULT"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->DEFAULT:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    .line 227
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    const-string v1, "YUV"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->YUV:Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    .line 203
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->$values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 203
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;
    .locals 1

    .line 203
    const-class v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;
    .locals 1

    .line 203
    sget-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->$VALUES:[Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/androidx/camera/core/processing/util/GLUtils$InputFormat;

    return-object v0
.end method
