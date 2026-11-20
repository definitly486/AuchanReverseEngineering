.class public final enum Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
.super Ljava/lang/Enum;
.source "RegionOfInterestProto.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "FocusRegionCase"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

.field public static final enum FOCUSREGION_NOT_SET:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

.field public static final enum KEYPOINT:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

.field public static final enum SCRIBBLE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;


# instance fields
.field private final value:I


# direct methods
.method private static synthetic $values()[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
    .locals 3

    .line 855
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->KEYPOINT:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    sget-object v1, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->SCRIBBLE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    sget-object v2, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->FOCUSREGION_NOT_SET:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    filled-new-array {v0, v1, v2}, [Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 5

    .line 856
    new-instance v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    const-string v1, "KEYPOINT"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->KEYPOINT:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    .line 857
    new-instance v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    const-string v1, "SCRIBBLE"

    const/4 v4, 0x2

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->SCRIBBLE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    .line 858
    new-instance v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    const-string v1, "FOCUSREGION_NOT_SET"

    invoke-direct {v0, v1, v4, v2}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->FOCUSREGION_NOT_SET:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    .line 855
    invoke-static {}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->$values()[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->$VALUES:[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .line 860
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 861
    iput p3, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->value:I

    return-void
.end method

.method public static forNumber(I)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
    .locals 1

    if-eqz p0, :cond_2

    const/4 v0, 0x1

    if-eq p0, v0, :cond_1

    const/4 v0, 0x2

    if-eq p0, v0, :cond_0

    const/4 p0, 0x0

    return-object p0

    .line 874
    :cond_0
    sget-object p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->SCRIBBLE:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-object p0

    .line 873
    :cond_1
    sget-object p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->KEYPOINT:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-object p0

    .line 875
    :cond_2
    sget-object p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->FOCUSREGION_NOT_SET:Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-object p0
.end method

.method public static valueOf(I)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
    .locals 0
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 868
    invoke-static {p0}, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->forNumber(I)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    move-result-object p0

    return-object p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
    .locals 1

    .line 855
    const-class v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-object p0
.end method

.method public static values()[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;
    .locals 1

    .line 855
    sget-object v0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->$VALUES:[Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    invoke-virtual {v0}, [Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;

    return-object v0
.end method


# virtual methods
.method public getNumber()I
    .locals 1

    .line 880
    iget v0, p0, Lcom/google/mediapipe/tasks/vision/interactivesegmenter/proto/RegionOfInterestProto$RegionOfInterest$FocusRegionCase;->value:I

    return v0
.end method
