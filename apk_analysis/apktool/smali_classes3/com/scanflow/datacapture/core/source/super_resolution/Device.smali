.class public final enum Lcom/scanflow/datacapture/core/source/super_resolution/Device;
.super Ljava/lang/Enum;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/scanflow/datacapture/core/source/super_resolution/Device;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/core/source/super_resolution/Device;

.field public static final enum CPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

.field public static final enum DSP:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

.field public static final enum GPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

.field public static final enum NNAPI:Lcom/scanflow/datacapture/core/source/super_resolution/Device;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/core/source/super_resolution/Device;
    .locals 4

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->CPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    sget-object v1, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->GPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    sget-object v2, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->DSP:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    sget-object v3, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->NNAPI:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    filled-new-array {v0, v1, v2, v3}, [Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const-string v1, "CPU"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/Device;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->CPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const-string v1, "GPU"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/Device;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->GPU:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const-string v1, "DSP"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/Device;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->DSP:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    new-instance v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    const-string v1, "NNAPI"

    const/4 v2, 0x3

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/core/source/super_resolution/Device;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->NNAPI:Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    invoke-static {}, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->$values()[Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->$VALUES:[Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 0
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/core/source/super_resolution/Device;
    .locals 1

    .line 0
    const-class v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/core/source/super_resolution/Device;
    .locals 1

    .line 0
    sget-object v0, Lcom/scanflow/datacapture/core/source/super_resolution/Device;->$VALUES:[Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/core/source/super_resolution/Device;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/core/source/super_resolution/Device;

    return-object v0
.end method
