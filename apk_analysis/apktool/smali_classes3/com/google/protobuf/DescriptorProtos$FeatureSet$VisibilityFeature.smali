.class public final Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
.super Lcom/google/protobuf/GeneratedMessageLite;
.source "DescriptorProtos.java"

# interfaces
.implements Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeatureOrBuilder;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/protobuf/DescriptorProtos$FeatureSet;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "VisibilityFeature"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;,
        Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$DefaultSymbolVisibility;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/protobuf/GeneratedMessageLite<",
        "Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;",
        "Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;",
        ">;",
        "Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeatureOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

.field private static volatile PARSER:Lcom/google/protobuf/Parser;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 26144
    new-instance v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-direct {v0}, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;-><init>()V

    .line 26147
    sput-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    .line 26148
    const-class v1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v1, v0}, Lcom/google/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 25880
    invoke-direct {p0}, Lcom/google/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$53000()Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 25875
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object v0
.end method

.method public static getDefaultInstance()Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26153
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object v0
.end method

.method public static newBuilder()Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;
    .locals 1

    .line 26071
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;
    .locals 1

    .line 26074
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-virtual {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/protobuf/GeneratedMessageLite;)Lcom/google/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26047
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26054
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26010
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26017
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/ByteString;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26059
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26066
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Lcom/google/protobuf/CodedInputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26034
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26041
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 25997
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26004
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26022
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[B)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;
    .locals 1

    .line 26029
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {v0, p0, p1}, Lcom/google/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/protobuf/GeneratedMessageLite;[BLcom/google/protobuf/ExtensionRegistryLite;)Lcom/google/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p0
.end method

.method public static parser()Lcom/google/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/protobuf/Parser<",
            "Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;",
            ">;"
        }
    .end annotation

    .line 26159
    sget-object v0, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-virtual {v0}, Lcom/google/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 26098
    sget-object p2, Lcom/google/protobuf/DescriptorProtos$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 26137
    throw p2

    :pswitch_0
    const/4 p1, 0x1

    .line 26130
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 26115
    :pswitch_1
    sget-object p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_1

    .line 26117
    const-class p2, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    monitor-enter p2

    .line 26118
    :try_start_0
    sget-object p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->PARSER:Lcom/google/protobuf/Parser;

    if-nez p1, :cond_0

    .line 26120
    new-instance p1, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-direct {p1, p3}, Lcom/google/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/protobuf/GeneratedMessageLite;)V

    .line 26123
    sput-object p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->PARSER:Lcom/google/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 26125
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

    .line 26112
    :pswitch_2
    sget-object p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    return-object p1

    .line 26107
    :pswitch_3
    const-string p1, "\u0001\u0000"

    .line 26109
    sget-object p3, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;->DEFAULT_INSTANCE:Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-static {p3, p1, p2}, Lcom/google/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 26103
    :pswitch_4
    new-instance p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;

    invoke-direct {p1, p2}, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature$Builder;-><init>(Lcom/google/protobuf/DescriptorProtos$1;)V

    return-object p1

    .line 26100
    :pswitch_5
    new-instance p1, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;

    invoke-direct {p1}, Lcom/google/protobuf/DescriptorProtos$FeatureSet$VisibilityFeature;-><init>()V

    return-object p1

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method
