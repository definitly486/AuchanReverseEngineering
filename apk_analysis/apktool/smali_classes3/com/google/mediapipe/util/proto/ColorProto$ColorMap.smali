.class public final Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "ColorProto.java"

# interfaces
.implements Lcom/google/mediapipe/util/proto/ColorProto$ColorMapOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/mediapipe/util/proto/ColorProto;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "ColorMap"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;,
        Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$LabelToColorDefaultEntryHolder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;",
        "Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;",
        ">;",
        "Lcom/google/mediapipe/util/proto/ColorProto$ColorMapOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

.field public static final LABEL_TO_COLOR_FIELD_NUMBER:I = 0x1

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private labelToColor_:Lcom/google/protobuf/MapFieldLite;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/MapFieldLite<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 852
    new-instance v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-direct {v0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;-><init>()V

    .line 855
    sput-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    .line 856
    const-class v1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 498
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    .line 513
    invoke-static {}, Lcom/google/protobuf/MapFieldLite;->emptyMapField()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    return-void
.end method

.method static synthetic access$800()Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 493
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object v0
.end method

.method static synthetic access$900(Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;)Ljava/util/Map;
    .locals 0

    .line 493
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->getMutableLabelToColorMap()Ljava/util/Map;

    move-result-object p0

    return-object p0
.end method

.method public static getDefaultInstance()Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 861
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object v0
.end method

.method private getMutableLabelToColorMap()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .line 592
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetMutableLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    return-object v0
.end method

.method private internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/MapFieldLite<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .line 516
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    return-object v0
.end method

.method private internalGetMutableLabelToColor()Lcom/google/protobuf/MapFieldLite;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/MapFieldLite<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .line 520
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    invoke-virtual {v0}, Lcom/google/protobuf/MapFieldLite;->isMutable()Z

    move-result v0

    if-nez v0, :cond_0

    .line 521
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    invoke-virtual {v0}, Lcom/google/protobuf/MapFieldLite;->mutableCopy()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    iput-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    .line 523
    :cond_0
    iget-object v0, p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->labelToColor_:Lcom/google/protobuf/MapFieldLite;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;
    .locals 1

    .line 672
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;
    .locals 1

    .line 675
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 648
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 655
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 611
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 618
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 660
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 667
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 635
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 642
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 598
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 605
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 623
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;
    .locals 1

    .line 630
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;",
            ">;"
        }
    .end annotation

    .line 867
    sget-object v0, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public containsLabelToColor(Ljava/lang/String;)Z
    .locals 1

    .line 537
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 538
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/util/AbstractMap;->containsKey(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 803
    sget-object p2, Lcom/google/mediapipe/util/proto/ColorProto$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 845
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 839
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 824
    :pswitch_2
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 826
    const-class p2, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    monitor-enter p2

    .line 827
    :try_start_0
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 829
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 832
    sput-object p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 834
    :cond_0
    :goto_0
    monitor-exit p2

    return-object p1

    :goto_1
    monitor-exit p2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_1
    return-object p1

    .line 821
    :pswitch_3
    sget-object p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    return-object p1

    .line 811
    :pswitch_4
    const-string p1, "labelToColor_"

    sget-object p2, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$LabelToColorDefaultEntryHolder;->defaultEntry:Lcom/google/protobuf/MapEntryLite;

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    .line 815
    const-string p2, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u00012"

    .line 817
    sget-object p3, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->DEFAULT_INSTANCE:Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-static {p3, p2, p1}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 808
    :pswitch_5
    new-instance p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;

    invoke-direct {p1, p2}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap$Builder;-><init>(Lcom/google/mediapipe/util/proto/ColorProto$1;)V

    return-object p1

    .line 805
    :pswitch_6
    new-instance p1, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;

    invoke-direct {p1}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;-><init>()V

    return-object p1

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

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/protobuf/MessageLite;
    .locals 1

    .line 493
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getLabelToColor()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .line 546
    invoke-virtual {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->getLabelToColorMap()Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method public getLabelToColorCount()I
    .locals 1

    .line 528
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/AbstractMap;->size()I

    move-result v0

    return v0
.end method

.method public getLabelToColorMap()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/google/mediapipe/util/proto/ColorProto$Color;",
            ">;"
        }
    .end annotation

    .line 555
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    .line 554
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableMap(Ljava/util/Map;)Ljava/util/Map;

    move-result-object v0

    return-object v0
.end method

.method public getLabelToColorOrDefault(Ljava/lang/String;Lcom/google/mediapipe/util/proto/ColorProto$Color;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 2

    .line 567
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 569
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    .line 570
    invoke-interface {v0, p1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p1

    :cond_0
    return-object p2
.end method

.method public getLabelToColorOrThrow(Ljava/lang/String;)Lcom/google/mediapipe/util/proto/ColorProto$Color;
    .locals 2

    .line 579
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 581
    invoke-direct {p0}, Lcom/google/mediapipe/util/proto/ColorProto$ColorMap;->internalGetLabelToColor()Lcom/google/protobuf/MapFieldLite;

    move-result-object v0

    .line 582
    invoke-interface {v0, p1}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 585
    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/google/mediapipe/util/proto/ColorProto$Color;

    return-object p1

    .line 583
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    invoke-direct {p1}, Ljava/lang/IllegalArgumentException;-><init>()V

    throw p1
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 493
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/protobuf/MessageLite$Builder;
    .locals 1

    .line 493
    invoke-super {p0}, Lcom/google/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
