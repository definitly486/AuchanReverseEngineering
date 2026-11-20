.class public final enum Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
.super Ljava/lang/Enum;
.source "MediaPipeLoggingEnumsProto.java"

# interfaces
.implements Lcom/google/protobuf/Internal$EnumLite;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "SolutionMode"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode$SolutionModeVerifier;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;",
        ">;",
        "Lcom/google/protobuf/Internal$EnumLite;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final enum MODE_STATIC_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_STATIC_IMAGE_VALUE:I = 0x2

.field public static final enum MODE_TASKS_AUDIO_CLIPS:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_AUDIO_CLIPS_VALUE:I = 0xe

.field public static final enum MODE_TASKS_AUDIO_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_AUDIO_STREAM_VALUE:I = 0xf

.field public static final enum MODE_TASKS_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_IMAGE_VALUE:I = 0xb

.field public static final enum MODE_TASKS_LIVE_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_LIVE_STREAM_VALUE:I = 0xd

.field public static final enum MODE_TASKS_UNSPECIFIED:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_UNSPECIFIED_VALUE:I = 0xa

.field public static final enum MODE_TASKS_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_TASKS_VIDEO_VALUE:I = 0xc

.field public static final enum MODE_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_UNKNOWN_VALUE:I = 0x0

.field public static final enum MODE_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

.field public static final MODE_VIDEO_VALUE:I = 0x1

.field private static final internalValueMap:Lcom/google/protobuf/Internal$EnumLiteMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$EnumLiteMap<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private final value:I


# direct methods
.method private static synthetic $values()[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 9

    .line 573
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v1, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v2, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_STATIC_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v3, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_UNSPECIFIED:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v4, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v5, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v6, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_LIVE_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v7, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_CLIPS:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    sget-object v8, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    filled-new-array/range {v0 .. v8}, [Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 4

    .line 578
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const-string v1, "MODE_UNKNOWN"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 586
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const-string v1, "MODE_VIDEO"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 594
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const-string v1, "MODE_STATIC_IMAGE"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_STATIC_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 602
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/4 v1, 0x3

    const/16 v2, 0xa

    const-string v3, "MODE_TASKS_UNSPECIFIED"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_UNSPECIFIED:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 606
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/4 v1, 0x4

    const/16 v2, 0xb

    const-string v3, "MODE_TASKS_IMAGE"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 610
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/4 v1, 0x5

    const/16 v2, 0xc

    const-string v3, "MODE_TASKS_VIDEO"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 614
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/4 v1, 0x6

    const/16 v2, 0xd

    const-string v3, "MODE_TASKS_LIVE_STREAM"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_LIVE_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 618
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/4 v1, 0x7

    const/16 v2, 0xe

    const-string v3, "MODE_TASKS_AUDIO_CLIPS"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_CLIPS:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 622
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    const/16 v1, 0x8

    const/16 v2, 0xf

    const-string v3, "MODE_TASKS_AUDIO_STREAM"

    invoke-direct {v0, v3, v1, v2}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 573
    invoke-static {}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->$values()[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->$VALUES:[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    .line 710
    new-instance v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode$1;

    invoke-direct {v0}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode$1;-><init>()V

    sput-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->internalValueMap:Lcom/google/protobuf/Internal$EnumLiteMap;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .line 734
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 735
    iput p3, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->value:I

    return-void
.end method

.method public static forNumber(I)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 1

    if-eqz p0, :cond_2

    const/4 v0, 0x1

    if-eq p0, v0, :cond_1

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    packed-switch p0, :pswitch_data_0

    const/4 p0, 0x0

    return-object p0

    .line 700
    :pswitch_0
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 699
    :pswitch_1
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_AUDIO_CLIPS:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 698
    :pswitch_2
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_LIVE_STREAM:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 697
    :pswitch_3
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 696
    :pswitch_4
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 695
    :pswitch_5
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_TASKS_UNSPECIFIED:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 694
    :cond_0
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_STATIC_IMAGE:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 693
    :cond_1
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_VIDEO:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    .line 692
    :cond_2
    sget-object p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->MODE_UNKNOWN:Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0

    :pswitch_data_0
    .packed-switch 0xa
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static internalGetValueMap()Lcom/google/protobuf/Internal$EnumLiteMap;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Internal$EnumLiteMap<",
            "Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;",
            ">;"
        }
    .end annotation

    .line 707
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->internalValueMap:Lcom/google/protobuf/Internal$EnumLiteMap;

    return-object v0
.end method

.method public static internalGetVerifier()Lcom/google/protobuf/Internal$EnumVerifier;
    .locals 1

    .line 720
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode$SolutionModeVerifier;->INSTANCE:Lcom/google/protobuf/Internal$EnumVerifier;

    return-object v0
.end method

.method public static valueOf(I)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 0
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 687
    invoke-static {p0}, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->forNumber(I)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    move-result-object p0

    return-object p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 1

    .line 573
    const-class v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object p0
.end method

.method public static values()[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;
    .locals 1

    .line 573
    sget-object v0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->$VALUES:[Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    invoke-virtual {v0}, [Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;

    return-object v0
.end method


# virtual methods
.method public final getNumber()I
    .locals 1

    .line 677
    iget v0, p0, Lcom/google/mediapipe/proto/MediaPipeLoggingEnumsProto$SolutionMode;->value:I

    return v0
.end method
