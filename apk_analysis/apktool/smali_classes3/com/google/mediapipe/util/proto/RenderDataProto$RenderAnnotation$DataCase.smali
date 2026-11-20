.class public final enum Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
.super Ljava/lang/Enum;
.source "RenderDataProto.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "DataCase"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum ARROW:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum DATA_NOT_SET:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum FILLED_OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum FILLED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum FILLED_ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum GRADIENT_LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum POINT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum SCRIBBLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

.field public static final enum TEXT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;


# instance fields
.field private final value:I


# direct methods
.method private static synthetic $values()[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 13

    .line 8902
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v2, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v3, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v4, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->POINT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v5, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v6, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ARROW:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v7, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->TEXT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v8, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v9, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v10, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->GRADIENT_LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v11, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->SCRIBBLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    sget-object v12, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->DATA_NOT_SET:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    filled-new-array/range {v0 .. v12}, [Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 5

    .line 8903
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "RECTANGLE"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8904
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "FILLED_RECTANGLE"

    const/4 v4, 0x2

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8905
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "OVAL"

    const/4 v3, 0x3

    invoke-direct {v0, v1, v4, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8906
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "FILLED_OVAL"

    const/4 v4, 0x4

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8907
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "POINT"

    const/4 v3, 0x5

    invoke-direct {v0, v1, v4, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->POINT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8908
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "LINE"

    const/4 v4, 0x6

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8909
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "ARROW"

    const/4 v3, 0x7

    invoke-direct {v0, v1, v4, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ARROW:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8910
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "TEXT"

    const/16 v4, 0x8

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->TEXT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8911
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "ROUNDED_RECTANGLE"

    const/16 v3, 0x9

    invoke-direct {v0, v1, v4, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8912
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "FILLED_ROUNDED_RECTANGLE"

    const/16 v4, 0xa

    invoke-direct {v0, v1, v3, v4}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8913
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "GRADIENT_LINE"

    const/16 v3, 0xe

    invoke-direct {v0, v1, v4, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->GRADIENT_LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8914
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const/16 v1, 0xb

    const/16 v3, 0xf

    const-string v4, "SCRIBBLE"

    invoke-direct {v0, v4, v1, v3}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->SCRIBBLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8915
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    const-string v1, "DATA_NOT_SET"

    const/16 v3, 0xc

    invoke-direct {v0, v1, v3, v2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;-><init>(Ljava/lang/String;II)V

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->DATA_NOT_SET:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    .line 8902
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->$values()[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    move-result-object v0

    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->$VALUES:[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;II)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)V"
        }
    .end annotation

    .line 8917
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    .line 8918
    iput p3, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->value:I

    return-void
.end method

.method public static forNumber(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 1

    const/16 v0, 0xe

    if-eq p0, v0, :cond_1

    const/16 v0, 0xf

    if-eq p0, v0, :cond_0

    packed-switch p0, :pswitch_data_0

    const/4 p0, 0x0

    return-object p0

    .line 8939
    :pswitch_0
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8938
    :pswitch_1
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ROUNDED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8937
    :pswitch_2
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->TEXT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8936
    :pswitch_3
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->ARROW:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8935
    :pswitch_4
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8934
    :pswitch_5
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->POINT:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8933
    :pswitch_6
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8932
    :pswitch_7
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->OVAL:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8931
    :pswitch_8
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->FILLED_RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8930
    :pswitch_9
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->RECTANGLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8942
    :pswitch_a
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->DATA_NOT_SET:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8941
    :cond_0
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->SCRIBBLE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    .line 8940
    :cond_1
    sget-object p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->GRADIENT_LINE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_a
        :pswitch_9
        :pswitch_8
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static valueOf(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 0
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 8925
    invoke-static {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->forNumber(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    move-result-object p0

    return-object p0
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 1

    .line 8902
    const-class v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object p0
.end method

.method public static values()[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 1

    .line 8902
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->$VALUES:[Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    invoke-virtual {v0}, [Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    return-object v0
.end method


# virtual methods
.method public getNumber()I
    .locals 1

    .line 8947
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->value:I

    return v0
.end method
