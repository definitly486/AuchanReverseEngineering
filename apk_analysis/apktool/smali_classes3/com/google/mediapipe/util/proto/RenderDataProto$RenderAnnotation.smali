.class public final Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "RenderDataProto.java"

# interfaces
.implements Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotationOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/RenderDataProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "RenderAnnotation"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$TextOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$ArrowOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$ScribbleOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLineOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$LineOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$PointOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOvalOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$OvalOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangleOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangleOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangleOrBuilder;,
        Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RectangleOrBuilder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;",
        ">;",
        "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotationOrBuilder;"
    }
.end annotation


# static fields
.field public static final ARROW_FIELD_NUMBER:I = 0x7

.field public static final COLOR_FIELD_NUMBER:I = 0xc

.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

.field public static final FILLED_OVAL_FIELD_NUMBER:I = 0x4

.field public static final FILLED_RECTANGLE_FIELD_NUMBER:I = 0x2

.field public static final FILLED_ROUNDED_RECTANGLE_FIELD_NUMBER:I = 0xa

.field public static final GRADIENT_LINE_FIELD_NUMBER:I = 0xe

.field public static final LINE_FIELD_NUMBER:I = 0x6

.field public static final OVAL_FIELD_NUMBER:I = 0x3

.field private static volatile PARSER:Lcom/google/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
            ">;"
        }
    .end annotation
.end field

.field public static final POINT_FIELD_NUMBER:I = 0x5

.field public static final RECTANGLE_FIELD_NUMBER:I = 0x1

.field public static final ROUNDED_RECTANGLE_FIELD_NUMBER:I = 0x9

.field public static final SCENE_TAG_FIELD_NUMBER:I = 0xd

.field public static final SCRIBBLE_FIELD_NUMBER:I = 0xf

.field public static final TEXT_FIELD_NUMBER:I = 0x8

.field public static final THICKNESS_FIELD_NUMBER:I = 0xb


# instance fields
.field private bitField0_:I

.field private color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

.field private dataCase_:I

.field private data_:Ljava/lang/Object;

.field private sceneTag_:Ljava/lang/String;

.field private thickness_:D


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 10744
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;-><init>()V

    .line 10747
    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    .line 10748
    const-class v1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 2

    .line 1031
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    const/4 v0, 0x0

    .line 8900
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 1032
    iput-wide v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->thickness_:D

    .line 1033
    const-string v0, ""

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$15200()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 1026
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object v0
.end method

.method static synthetic access$15300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearData()V

    return-void
.end method

.method static synthetic access$15400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V

    return-void
.end method

.method static synthetic access$15500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V

    return-void
.end method

.method static synthetic access$15600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearRectangle()V

    return-void
.end method

.method static synthetic access$15700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setFilledRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V

    return-void
.end method

.method static synthetic access$15800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeFilledRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V

    return-void
.end method

.method static synthetic access$15900(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearFilledRectangle()V

    return-void
.end method

.method static synthetic access$16000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V

    return-void
.end method

.method static synthetic access$16100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V

    return-void
.end method

.method static synthetic access$16200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearOval()V

    return-void
.end method

.method static synthetic access$16300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setFilledOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V

    return-void
.end method

.method static synthetic access$16400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeFilledOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V

    return-void
.end method

.method static synthetic access$16500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearFilledOval()V

    return-void
.end method

.method static synthetic access$16600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setPoint(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V

    return-void
.end method

.method static synthetic access$16700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergePoint(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V

    return-void
.end method

.method static synthetic access$16800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearPoint()V

    return-void
.end method

.method static synthetic access$16900(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V

    return-void
.end method

.method static synthetic access$17000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V

    return-void
.end method

.method static synthetic access$17100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearLine()V

    return-void
.end method

.method static synthetic access$17200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setArrow(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V

    return-void
.end method

.method static synthetic access$17300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeArrow(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V

    return-void
.end method

.method static synthetic access$17400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearArrow()V

    return-void
.end method

.method static synthetic access$17500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setText(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V

    return-void
.end method

.method static synthetic access$17600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeText(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V

    return-void
.end method

.method static synthetic access$17700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearText()V

    return-void
.end method

.method static synthetic access$17800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V

    return-void
.end method

.method static synthetic access$17900(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V

    return-void
.end method

.method static synthetic access$18000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearRoundedRectangle()V

    return-void
.end method

.method static synthetic access$18100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setFilledRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V

    return-void
.end method

.method static synthetic access$18200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeFilledRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V

    return-void
.end method

.method static synthetic access$18300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearFilledRoundedRectangle()V

    return-void
.end method

.method static synthetic access$18400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setGradientLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V

    return-void
.end method

.method static synthetic access$18500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeGradientLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V

    return-void
.end method

.method static synthetic access$18600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearGradientLine()V

    return-void
.end method

.method static synthetic access$18700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setScribble(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V

    return-void
.end method

.method static synthetic access$18800(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeScribble(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V

    return-void
.end method

.method static synthetic access$18900(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearScribble()V

    return-void
.end method

.method static synthetic access$19000(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;D)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1, p2}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setThickness(D)V

    return-void
.end method

.method static synthetic access$19100(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearThickness()V

    return-void
.end method

.method static synthetic access$19200(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setColor(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V

    return-void
.end method

.method static synthetic access$19300(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->mergeColor(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V

    return-void
.end method

.method static synthetic access$19400(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearColor()V

    return-void
.end method

.method static synthetic access$19500(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Ljava/lang/String;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setSceneTag(Ljava/lang/String;)V

    return-void
.end method

.method static synthetic access$19600(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)V
    .locals 0

    .line 1026
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->clearSceneTag()V

    return-void
.end method

.method static synthetic access$19700(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 1026
    invoke-direct {p0, p1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->setSceneTagBytes(Lcom/google/protobuf/ByteString;)V

    return-void
.end method

.method private clearArrow()V
    .locals 2

    .line 9307
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x7

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9308
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9309
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearColor()V
    .locals 1

    const/4 v0, 0x0

    .line 9680
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    .line 9681
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    and-int/lit8 v0, v0, -0x3

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    return-void
.end method

.method private clearData()V
    .locals 1

    const/4 v0, 0x0

    .line 8959
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 8960
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    return-void
.end method

.method private clearFilledOval()V
    .locals 2

    .line 9157
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9158
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9159
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearFilledRectangle()V
    .locals 2

    .line 9057
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9058
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9059
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearFilledRoundedRectangle()V
    .locals 2

    .line 9457
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xa

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9458
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9459
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearGradientLine()V
    .locals 2

    .line 9507
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xe

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9508
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9509
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearLine()V
    .locals 2

    .line 9257
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x6

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9258
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9259
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearOval()V
    .locals 2

    .line 9107
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9108
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9109
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearPoint()V
    .locals 2

    .line 9207
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9208
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9209
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearRectangle()V
    .locals 2

    .line 9007
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9008
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9009
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearRoundedRectangle()V
    .locals 2

    .line 9407
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x9

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9408
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9409
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearSceneTag()V
    .locals 1

    .line 9750
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    and-int/lit8 v0, v0, -0x5

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    .line 9751
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->getSceneTag()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    return-void
.end method

.method private clearScribble()V
    .locals 2

    .line 9557
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xf

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9558
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9559
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearText()V
    .locals 2

    .line 9357
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x8

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 9358
    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v0, 0x0

    .line 9359
    iput-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    :cond_0
    return-void
.end method

.method private clearThickness()V
    .locals 2

    .line 9609
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    .line 9610
    iput-wide v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->thickness_:D

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 10753
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object v0
.end method

.method private mergeArrow(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V
    .locals 3

    .line 9293
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9294
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x7

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9295
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9296
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow$Builder;

    move-result-object v0

    .line 9297
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9299
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9301
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeColor(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 2

    .line 9662
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9663
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    if-eqz v0, :cond_0

    .line 9664
    invoke-static {}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->getDefaultInstance()Lcom/google/mediapipe/util/proto/ColorProto$Color;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 9665
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    .line 9666
    invoke-static {v0}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->newBuilder(Lcom/google/mediapipe/util/proto/ColorProto$Color;)Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/ColorProto$Color$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    goto :goto_0

    .line 9668
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    .line 9670
    :goto_0
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    return-void
.end method

.method private mergeFilledOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V
    .locals 3

    .line 9143
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9144
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9145
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9146
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval$Builder;

    move-result-object v0

    .line 9147
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9149
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9151
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeFilledRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V
    .locals 3

    .line 9043
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9044
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9045
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9046
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle$Builder;

    move-result-object v0

    .line 9047
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9049
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9051
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeFilledRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V
    .locals 3

    .line 9443
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9444
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xa

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9445
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9446
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle$Builder;

    move-result-object v0

    .line 9447
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9449
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9451
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeGradientLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V
    .locals 3

    .line 9493
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9494
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xe

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9495
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9496
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine$Builder;

    move-result-object v0

    .line 9497
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9499
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9501
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V
    .locals 3

    .line 9243
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9244
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x6

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9245
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9246
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line$Builder;

    move-result-object v0

    .line 9247
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9249
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9251
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V
    .locals 3

    .line 9093
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9094
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9095
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9096
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval$Builder;

    move-result-object v0

    .line 9097
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9099
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9101
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergePoint(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V
    .locals 3

    .line 9193
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9194
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9195
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9196
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point$Builder;

    move-result-object v0

    .line 9197
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9199
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9201
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V
    .locals 3

    .line 8993
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 8994
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 8995
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 8996
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle$Builder;

    move-result-object v0

    .line 8997
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 8999
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9001
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V
    .locals 3

    .line 9393
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9394
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x9

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9395
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9396
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle$Builder;

    move-result-object v0

    .line 9397
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9399
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9401
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeScribble(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V
    .locals 3

    .line 9543
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9544
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xf

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9545
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9546
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble$Builder;

    move-result-object v0

    .line 9547
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9549
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9551
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private mergeText(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V
    .locals 3

    .line 9343
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9344
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x8

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9345
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;

    move-result-object v2

    if-eq v0, v2, :cond_0

    .line 9346
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;->newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text$Builder;

    move-result-object v0

    .line 9347
    invoke-virtual {v0, p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text$Builder;

    invoke-virtual {p1}, Lcom/google/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    goto :goto_0

    .line 9349
    :cond_0
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    .line 9351
    :goto_0
    iput v1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;
    .locals 1

    .line 9845
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;
    .locals 1

    .line 9848
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9821
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9828
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9784
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9791
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9833
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9840
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9808
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9815
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9771
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9778
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9796
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;
    .locals 1

    .line 9803
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;",
            ">;"
        }
    .end annotation

    .line 10759
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setArrow(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;)V
    .locals 0

    .line 9285
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9286
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x7

    .line 9287
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setColor(Lcom/google/mediapipe/util/proto/ColorProto$Color;)V
    .locals 0

    .line 9648
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9649
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    .line 9650
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    or-int/lit8 p1, p1, 0x2

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    return-void
.end method

.method private setFilledOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;)V
    .locals 0

    .line 9135
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9136
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x4

    .line 9137
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setFilledRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;)V
    .locals 0

    .line 9035
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9036
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x2

    .line 9037
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setFilledRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;)V
    .locals 0

    .line 9435
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9436
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/16 p1, 0xa

    .line 9437
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setGradientLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;)V
    .locals 0

    .line 9485
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9486
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/16 p1, 0xe

    .line 9487
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setLine(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;)V
    .locals 0

    .line 9235
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9236
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x6

    .line 9237
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setOval(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;)V
    .locals 0

    .line 9085
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9086
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x3

    .line 9087
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setPoint(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;)V
    .locals 0

    .line 9185
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9186
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x5

    .line 9187
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;)V
    .locals 0

    .line 8985
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 8986
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/4 p1, 0x1

    .line 8987
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setRoundedRectangle(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;)V
    .locals 0

    .line 9385
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9386
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/16 p1, 0x9

    .line 9387
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setSceneTag(Ljava/lang/String;)V
    .locals 1

    .line 9737
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9738
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    or-int/lit8 v0, v0, 0x4

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    .line 9739
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    return-void
.end method

.method private setSceneTagBytes(Lcom/google/protobuf/ByteString;)V
    .locals 0

    .line 9764
    invoke-virtual {p1}, Lcom/google/protobuf/ByteString;->toStringUtf8()Ljava/lang/String;

    move-result-object p1

    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    .line 9765
    iget p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    or-int/lit8 p1, p1, 0x4

    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    return-void
.end method

.method private setScribble(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;)V
    .locals 0

    .line 9535
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9536
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/16 p1, 0xf

    .line 9537
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setText(Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;)V
    .locals 0

    .line 9335
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 9336
    iput-object p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    const/16 p1, 0x8

    .line 9337
    iput p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    return-void
.end method

.method private setThickness(D)V
    .locals 1

    .line 9598
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    or-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    .line 9599
    iput-wide p1, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->thickness_:D

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 20

    .line 10676
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual/range {p1 .. p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x0

    packed-switch v0, :pswitch_data_0

    .line 10737
    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0

    :pswitch_0
    return-object v1

    :pswitch_1
    const/4 v0, 0x1

    .line 10731
    invoke-static {v0}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    return-object v0

    .line 10716
    :pswitch_2
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_1

    .line 10718
    const-class v1, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    monitor-enter v1

    .line 10719
    :try_start_0
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->PARSER:Lcom/google/protobuf/Parser;

    if-nez v0, :cond_0

    .line 10721
    new-instance v0, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object v2, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-direct {v0, v2}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 10724
    sput-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception v0

    goto :goto_1

    .line 10726
    :cond_0
    :goto_0
    monitor-exit v1

    return-object v0

    :goto_1
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_1
    return-object v0

    .line 10713
    :pswitch_3
    sget-object v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    return-object v0

    .line 10684
    :pswitch_4
    const-string v2, "data_"

    const-string v3, "dataCase_"

    const-string v4, "bitField0_"

    const-class v5, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;

    const-class v6, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;

    const-class v7, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;

    const-class v8, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;

    const-class v9, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;

    const-class v10, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;

    const-class v11, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;

    const-class v12, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;

    const-class v13, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;

    const-class v14, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;

    const-string v15, "thickness_"

    const-string v16, "color_"

    const-string v17, "sceneTag_"

    const-class v18, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;

    const-class v19, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;

    filled-new-array/range {v2 .. v19}, [Ljava/lang/Object;

    move-result-object v0

    .line 10704
    const-string v1, "\u0001\u000f\u0001\u0001\u0001\u000f\u000f\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000\u0003<\u0000\u0004<\u0000\u0005<\u0000\u0006<\u0000\u0007<\u0000\u0008<\u0000\t<\u0000\n<\u0000\u000b\u1000\u0000\u000c\u1009\u0001\r\u1008\u0002\u000e<\u0000\u000f<\u0000"

    .line 10709
    sget-object v2, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-static {v2, v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    return-object v0

    .line 10681
    :pswitch_5
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;

    invoke-direct {v0, v1}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Builder;-><init>(Lcom/google/mediapipe/util/proto/RenderDataProto$1;)V

    return-object v0

    .line 10678
    :pswitch_6
    new-instance v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;-><init>()V

    return-object v0

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public getArrow()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;
    .locals 2

    .line 9276
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x7

    if-ne v0, v1, :cond_0

    .line 9277
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;

    return-object v0

    .line 9279
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Arrow;

    move-result-object v0

    return-object v0
.end method

.method public getColor()Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 1

    .line 9637
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->color_:Lcom/google/mediapipe/util/proto/ColorProto$Color;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/mediapipe/util/proto/ColorProto$Color;->getDefaultInstance()Lcom/google/mediapipe/util/proto/ColorProto$Color;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getDataCase()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;
    .locals 1

    .line 8954
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    invoke-static {v0}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;->forNumber(I)Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$DataCase;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 1026
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getFilledOval()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;
    .locals 2

    .line 9126
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    .line 9127
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;

    return-object v0

    .line 9129
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledOval;

    move-result-object v0

    return-object v0
.end method

.method public getFilledRectangle()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;
    .locals 2

    .line 9026
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    .line 9027
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;

    return-object v0

    .line 9029
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRectangle;

    move-result-object v0

    return-object v0
.end method

.method public getFilledRoundedRectangle()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;
    .locals 2

    .line 9426
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xa

    if-ne v0, v1, :cond_0

    .line 9427
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;

    return-object v0

    .line 9429
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$FilledRoundedRectangle;

    move-result-object v0

    return-object v0
.end method

.method public getGradientLine()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;
    .locals 2

    .line 9476
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xe

    if-ne v0, v1, :cond_0

    .line 9477
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;

    return-object v0

    .line 9479
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$GradientLine;

    move-result-object v0

    return-object v0
.end method

.method public getLine()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;
    .locals 2

    .line 9226
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x6

    if-ne v0, v1, :cond_0

    .line 9227
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;

    return-object v0

    .line 9229
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Line;

    move-result-object v0

    return-object v0
.end method

.method public getOval()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;
    .locals 2

    .line 9076
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    .line 9077
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;

    return-object v0

    .line 9079
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Oval;

    move-result-object v0

    return-object v0
.end method

.method public getPoint()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;
    .locals 2

    .line 9176
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    .line 9177
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;

    return-object v0

    .line 9179
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Point;

    move-result-object v0

    return-object v0
.end method

.method public getRectangle()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;
    .locals 2

    .line 8976
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 8977
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;

    return-object v0

    .line 8979
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Rectangle;

    move-result-object v0

    return-object v0
.end method

.method public getRoundedRectangle()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;
    .locals 2

    .line 9376
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x9

    if-ne v0, v1, :cond_0

    .line 9377
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;

    return-object v0

    .line 9379
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$RoundedRectangle;

    move-result-object v0

    return-object v0
.end method

.method public getSceneTag()Ljava/lang/String;
    .locals 1

    .line 9710
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    return-object v0
.end method

.method public getSceneTagBytes()Lcom/google/protobuf/ByteString;
    .locals 1

    .line 9724
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->sceneTag_:Ljava/lang/String;

    invoke-static {v0}, Lcom/google/protobuf/ByteString;->copyFromUtf8(Ljava/lang/String;)Lcom/google/protobuf/ByteString;

    move-result-object v0

    return-object v0
.end method

.method public getScribble()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;
    .locals 2

    .line 9526
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xf

    if-ne v0, v1, :cond_0

    .line 9527
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;

    return-object v0

    .line 9529
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Scribble;

    move-result-object v0

    return-object v0
.end method

.method public getText()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;
    .locals 2

    .line 9326
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x8

    if-ne v0, v1, :cond_0

    .line 9327
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->data_:Ljava/lang/Object;

    check-cast v0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;

    return-object v0

    .line 9329
    :cond_0
    invoke-static {}, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;->getDefaultInstance()Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation$Text;

    move-result-object v0

    return-object v0
.end method

.method public getThickness()D
    .locals 2

    .line 9587
    iget-wide v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->thickness_:D

    return-wide v0
.end method

.method public hasArrow()Z
    .locals 2

    .line 9269
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x7

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasColor()Z
    .locals 1

    .line 9625
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    and-int/lit8 v0, v0, 0x2

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFilledOval()Z
    .locals 2

    .line 9119
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x4

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFilledRectangle()Z
    .locals 2

    .line 9019
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasFilledRoundedRectangle()Z
    .locals 2

    .line 9419
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xa

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasGradientLine()Z
    .locals 2

    .line 9469
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xe

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasLine()Z
    .locals 2

    .line 9219
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x6

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasOval()Z
    .locals 2

    .line 9069
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasPoint()Z
    .locals 2

    .line 9169
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x5

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRectangle()Z
    .locals 2

    .line 8969
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasRoundedRectangle()Z
    .locals 2

    .line 9369
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x9

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasSceneTag()Z
    .locals 1

    .line 9697
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    and-int/lit8 v0, v0, 0x4

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasScribble()Z
    .locals 2

    .line 9519
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0xf

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasText()Z
    .locals 2

    .line 9319
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->dataCase_:I

    const/16 v1, 0x8

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public hasThickness()Z
    .locals 2

    .line 9575
    iget v0, p0, Lcom/google/mediapipe/util/proto/RenderDataProto$RenderAnnotation;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1026
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 1026
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
