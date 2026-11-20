.class public final Lcom/google/crypto/tink/proto/KmsAeadKey;
.super Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;
.source "KmsAeadKey.java"

# interfaces
.implements Lcom/google/crypto/tink/proto/KmsAeadKeyOrBuilder;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite<",
        "Lcom/google/crypto/tink/proto/KmsAeadKey;",
        "Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;",
        ">;",
        "Lcom/google/crypto/tink/proto/KmsAeadKeyOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

.field public static final PARAMS_FIELD_NUMBER:I = 0x2

.field private static volatile PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/shaded/protobuf/Parser<",
            "Lcom/google/crypto/tink/proto/KmsAeadKey;",
            ">;"
        }
    .end annotation
.end field

.field public static final VERSION_FIELD_NUMBER:I = 0x1


# instance fields
.field private bitField0_:I

.field private params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

.field private version_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 373
    new-instance v0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-direct {v0}, Lcom/google/crypto/tink/proto/KmsAeadKey;-><init>()V

    .line 376
    sput-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    .line 377
    const-class v1, Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v1, v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 20
    invoke-direct {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;-><init>()V

    return-void
.end method

.method static synthetic access$000()Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 15
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/crypto/tink/proto/KmsAeadKey;I)V
    .locals 0

    .line 15
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/KmsAeadKey;->setVersion(I)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/crypto/tink/proto/KmsAeadKey;)V
    .locals 0

    .line 15
    invoke-direct {p0}, Lcom/google/crypto/tink/proto/KmsAeadKey;->clearVersion()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/crypto/tink/proto/KmsAeadKey;Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V
    .locals 0

    .line 15
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/KmsAeadKey;->setParams(Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/crypto/tink/proto/KmsAeadKey;Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V
    .locals 0

    .line 15
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/KmsAeadKey;->mergeParams(Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/crypto/tink/proto/KmsAeadKey;)V
    .locals 0

    .line 15
    invoke-direct {p0}, Lcom/google/crypto/tink/proto/KmsAeadKey;->clearParams()V

    return-void
.end method

.method private clearParams()V
    .locals 1

    const/4 v0, 0x0

    .line 111
    iput-object v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    .line 112
    iget v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    return-void
.end method

.method private clearVersion()V
    .locals 1

    const/4 v0, 0x0

    .line 46
    iput v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->version_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 382
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object v0
.end method

.method private mergeParams(Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V
    .locals 2

    .line 94
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 95
    iget-object v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    if-eqz v0, :cond_0

    .line 96
    invoke-static {}, Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;->getDefaultInstance()Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 97
    iget-object v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    .line 98
    invoke-static {v0}, Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;->newBuilder(Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)Lcom/google/crypto/tink/proto/KmsAeadKeyFormat$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/proto/KmsAeadKeyFormat$Builder;

    invoke-virtual {p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    iput-object p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    goto :goto_0

    .line 100
    :cond_0
    iput-object p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    .line 102
    :goto_0
    iget p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;
    .locals 1

    .line 192
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/crypto/tink/proto/KmsAeadKey;)Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;
    .locals 1

    .line 195
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 168
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 175
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 131
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/ByteString;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 138
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/ByteString;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 180
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 187
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 155
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 162
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 118
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 125
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 143
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;[B)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/KmsAeadKey;
    .locals 1

    .line 150
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;[BLcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p0
.end method

.method public static parser()Lcom/google/crypto/tink/shaded/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/crypto/tink/shaded/protobuf/Parser<",
            "Lcom/google/crypto/tink/proto/KmsAeadKey;",
            ">;"
        }
    .end annotation

    .line 388
    sget-object v0, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/crypto/tink/shaded/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setParams(Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;)V
    .locals 0

    .line 81
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 82
    iput-object p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    .line 83
    iget p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    return-void
.end method

.method private setVersion(I)V
    .locals 0

    .line 39
    iput p1, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->version_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 322
    sget-object p2, Lcom/google/crypto/tink/proto/KmsAeadKey$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 366
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 360
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 345
    :pswitch_2
    sget-object p1, Lcom/google/crypto/tink/proto/KmsAeadKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    if-nez p1, :cond_1

    .line 347
    const-class p2, Lcom/google/crypto/tink/proto/KmsAeadKey;

    monitor-enter p2

    .line 348
    :try_start_0
    sget-object p1, Lcom/google/crypto/tink/proto/KmsAeadKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    if-nez p1, :cond_0

    .line 350
    new-instance p1, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-direct {p1, p3}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)V

    .line 353
    sput-object p1, Lcom/google/crypto/tink/proto/KmsAeadKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 355
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

    .line 342
    :pswitch_3
    sget-object p1, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    return-object p1

    .line 330
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "version_"

    const-string p3, "params_"

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    .line 335
    const-string p2, "\u0000\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u000b\u0002\u1009\u0000"

    .line 338
    sget-object p3, Lcom/google/crypto/tink/proto/KmsAeadKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-static {p3, p2, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/crypto/tink/shaded/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 327
    :pswitch_5
    new-instance p1, Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;

    invoke-direct {p1, p2}, Lcom/google/crypto/tink/proto/KmsAeadKey$Builder;-><init>(Lcom/google/crypto/tink/proto/KmsAeadKey$1;)V

    return-object p1

    .line 324
    :pswitch_6
    new-instance p1, Lcom/google/crypto/tink/proto/KmsAeadKey;

    invoke-direct {p1}, Lcom/google/crypto/tink/proto/KmsAeadKey;-><init>()V

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

.method public bridge synthetic getDefaultInstanceForType()Lcom/google/crypto/tink/shaded/protobuf/MessageLite;
    .locals 1

    .line 15
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getParams()Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;
    .locals 1

    .line 71
    iget-object v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->params_:Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;->getDefaultInstance()Lcom/google/crypto/tink/proto/KmsAeadKeyFormat;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getVersion()I
    .locals 1

    .line 31
    iget v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->version_:I

    return v0
.end method

.method public hasParams()Z
    .locals 2

    .line 60
    iget v0, p0, Lcom/google/crypto/tink/proto/KmsAeadKey;->bitField0_:I

    const/4 v1, 0x1

    and-int/2addr v0, v1

    if-eqz v0, :cond_0

    return v1

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public bridge synthetic newBuilderForType()Lcom/google/crypto/tink/shaded/protobuf/MessageLite$Builder;
    .locals 1

    .line 15
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/crypto/tink/shaded/protobuf/MessageLite$Builder;
    .locals 1

    .line 15
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
