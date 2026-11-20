.class public final enum Lcom/google/mediapipe/framework/PacketCreator$SyncMode;
.super Ljava/lang/Enum;
.source "PacketCreator.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/framework/PacketCreator;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "SyncMode"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/google/mediapipe/framework/PacketCreator$SyncMode;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

.field public static final enum MAYBE_SYNC_OR_FINISH:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

.field public static final enum NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

.field public static final enum SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;


# instance fields
.field private final value:I


# direct methods
.method private static synthetic $values()[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;
    .locals 3

    .line 31
    sget-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    sget-object v1, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    sget-object v2, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->MAYBE_SYNC_OR_FINISH:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    filled-new-array {v0, v1, v2}, [Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 35
    new-instance v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    const-string v1, "NO_SYNC"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->NO_SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    .line 38
    new-instance v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    const-string v1, "SYNC"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->SYNC:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    .line 42
    new-instance v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    const-string v1, "MAYBE_SYNC_OR_FINISH"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->MAYBE_SYNC_OR_FINISH:Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    .line 31
    invoke-static {}, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->$values()[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->$VALUES:[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .line 46
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 47
    iput p3, p0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->value:I

    return-void
.end method

.method static synthetic access$000(Lcom/google/mediapipe/framework/PacketCreator$SyncMode;)I
    .locals 0

    .line 31
    iget p0, p0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->value:I

    return p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/google/mediapipe/framework/PacketCreator$SyncMode;
    .locals 1

    .line 31
    const-class v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    return-object p0
.end method

.method public static values()[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;
    .locals 1

    .line 31
    sget-object v0, Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->$VALUES:[Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    invoke-virtual {v0}, [Lcom/google/mediapipe/framework/PacketCreator$SyncMode;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/google/mediapipe/framework/PacketCreator$SyncMode;

    return-object v0
.end method
