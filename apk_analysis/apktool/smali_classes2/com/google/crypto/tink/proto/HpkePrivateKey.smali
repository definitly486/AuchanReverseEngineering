.class public final Lcom/google/crypto/tink/proto/HpkePrivateKey;
.super Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;
.source "HpkePrivateKey.java"

# interfaces
.implements Lcom/google/crypto/tink/proto/HpkePrivateKeyOrBuilder;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite<",
        "Lcom/google/crypto/tink/proto/HpkePrivateKey;",
        "Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;",
        ">;",
        "Lcom/google/crypto/tink/proto/HpkePrivateKeyOrBuilder;"
    }
.end annotation


# static fields
.field private static final DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

.field private static volatile PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/crypto/tink/shaded/protobuf/Parser<",
            "Lcom/google/crypto/tink/proto/HpkePrivateKey;",
            ">;"
        }
    .end annotation
.end field

.field public static final PRIVATE_KEY_FIELD_NUMBER:I = 0x3

.field public static final PUBLIC_KEY_FIELD_NUMBER:I = 0x2

.field public static final VERSION_FIELD_NUMBER:I = 0x1


# instance fields
.field private bitField0_:I

.field private privateKey_:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

.field private publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

.field private version_:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 408
    new-instance v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-direct {v0}, Lcom/google/crypto/tink/proto/HpkePrivateKey;-><init>()V

    .line 411
    sput-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    .line 412
    const-class v1, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v1, v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->registerDefaultInstance(Ljava/lang/Class;Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 16
    invoke-direct {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;-><init>()V

    .line 17
    sget-object v0, Lcom/google/crypto/tink/shaded/protobuf/ByteString;->EMPTY:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    iput-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->privateKey_:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    return-void
.end method

.method static synthetic access$000()Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 11
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object v0
.end method

.method static synthetic access$100(Lcom/google/crypto/tink/proto/HpkePrivateKey;I)V
    .locals 0

    .line 11
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->setVersion(I)V

    return-void
.end method

.method static synthetic access$200(Lcom/google/crypto/tink/proto/HpkePrivateKey;)V
    .locals 0

    .line 11
    invoke-direct {p0}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->clearVersion()V

    return-void
.end method

.method static synthetic access$300(Lcom/google/crypto/tink/proto/HpkePrivateKey;Lcom/google/crypto/tink/proto/HpkePublicKey;)V
    .locals 0

    .line 11
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->setPublicKey(Lcom/google/crypto/tink/proto/HpkePublicKey;)V

    return-void
.end method

.method static synthetic access$400(Lcom/google/crypto/tink/proto/HpkePrivateKey;Lcom/google/crypto/tink/proto/HpkePublicKey;)V
    .locals 0

    .line 11
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->mergePublicKey(Lcom/google/crypto/tink/proto/HpkePublicKey;)V

    return-void
.end method

.method static synthetic access$500(Lcom/google/crypto/tink/proto/HpkePrivateKey;)V
    .locals 0

    .line 11
    invoke-direct {p0}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->clearPublicKey()V

    return-void
.end method

.method static synthetic access$600(Lcom/google/crypto/tink/proto/HpkePrivateKey;Lcom/google/crypto/tink/shaded/protobuf/ByteString;)V
    .locals 0

    .line 11
    invoke-direct {p0, p1}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->setPrivateKey(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)V

    return-void
.end method

.method static synthetic access$700(Lcom/google/crypto/tink/proto/HpkePrivateKey;)V
    .locals 0

    .line 11
    invoke-direct {p0}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->clearPrivateKey()V

    return-void
.end method

.method private clearPrivateKey()V
    .locals 1

    .line 131
    invoke-static {}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->getDefaultInstance()Lcom/google/crypto/tink/proto/HpkePrivateKey;

    move-result-object v0

    invoke-virtual {v0}, Lcom/google/crypto/tink/proto/HpkePrivateKey;->getPrivateKey()Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    move-result-object v0

    iput-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->privateKey_:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    return-void
.end method

.method private clearPublicKey()V
    .locals 1

    const/4 v0, 0x0

    .line 88
    iput-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    .line 89
    iget v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    and-int/lit8 v0, v0, -0x2

    iput v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    return-void
.end method

.method private clearVersion()V
    .locals 1

    const/4 v0, 0x0

    .line 43
    iput v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->version_:I

    return-void
.end method

.method public static getDefaultInstance()Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 417
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object v0
.end method

.method private mergePublicKey(Lcom/google/crypto/tink/proto/HpkePublicKey;)V
    .locals 2

    .line 75
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 76
    iget-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    if-eqz v0, :cond_0

    .line 77
    invoke-static {}, Lcom/google/crypto/tink/proto/HpkePublicKey;->getDefaultInstance()Lcom/google/crypto/tink/proto/HpkePublicKey;

    move-result-object v1

    if-eq v0, v1, :cond_0

    .line 78
    iget-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    .line 79
    invoke-static {v0}, Lcom/google/crypto/tink/proto/HpkePublicKey;->newBuilder(Lcom/google/crypto/tink/proto/HpkePublicKey;)Lcom/google/crypto/tink/proto/HpkePublicKey$Builder;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->mergeFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/proto/HpkePublicKey$Builder;

    invoke-virtual {p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;->buildPartial()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p1

    check-cast p1, Lcom/google/crypto/tink/proto/HpkePublicKey;

    iput-object p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    goto :goto_0

    .line 81
    :cond_0
    iput-object p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    .line 83
    :goto_0
    iget p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    return-void
.end method

.method public static newBuilder()Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;
    .locals 1

    .line 211
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->createBuilder()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    check-cast v0, Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;

    return-object v0
.end method

.method public static newBuilder(Lcom/google/crypto/tink/proto/HpkePrivateKey;)Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;
    .locals 1

    .line 214
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-virtual {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->createBuilder(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 187
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseDelimitedFrom(Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 194
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseDelimitedFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 150
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/ByteString;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/ByteString;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 157
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/ByteString;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 199
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 206
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Lcom/google/crypto/tink/shaded/protobuf/CodedInputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 174
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 181
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/io/InputStream;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 137
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom(Ljava/nio/ByteBuffer;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 144
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;Ljava/nio/ByteBuffer;Lcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom([B)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 162
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;[B)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parseFrom([BLcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/proto/HpkePrivateKey;
    .locals 1

    .line 169
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {v0, p0, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->parseFrom(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;[BLcom/google/crypto/tink/shaded/protobuf/ExtensionRegistryLite;)Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object p0

    check-cast p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p0
.end method

.method public static parser()Lcom/google/crypto/tink/shaded/protobuf/Parser;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Lcom/google/crypto/tink/shaded/protobuf/Parser<",
            "Lcom/google/crypto/tink/proto/HpkePrivateKey;",
            ">;"
        }
    .end annotation

    .line 423
    sget-object v0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-virtual {v0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->getParserForType()Lcom/google/crypto/tink/shaded/protobuf/Parser;

    move-result-object v0

    return-object v0
.end method

.method private setPrivateKey(Lcom/google/crypto/tink/shaded/protobuf/ByteString;)V
    .locals 0

    .line 117
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 119
    iput-object p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->privateKey_:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    return-void
.end method

.method private setPublicKey(Lcom/google/crypto/tink/proto/HpkePublicKey;)V
    .locals 0

    .line 66
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    .line 67
    iput-object p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    .line 68
    iget p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    or-int/lit8 p1, p1, 0x1

    iput p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

    return-void
.end method

.method private setVersion(I)V
    .locals 0

    .line 36
    iput p1, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->version_:I

    return-void
.end method


# virtual methods
.method protected final dynamicMethod(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$MethodToInvoke;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 356
    sget-object p2, Lcom/google/crypto/tink/proto/HpkePrivateKey$1;->$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p1, p2, p1

    const/4 p2, 0x0

    packed-switch p1, :pswitch_data_0

    .line 401
    new-instance p1, Ljava/lang/UnsupportedOperationException;

    invoke-direct {p1}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw p1

    :pswitch_0
    return-object p2

    :pswitch_1
    const/4 p1, 0x1

    .line 395
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1

    .line 380
    :pswitch_2
    sget-object p1, Lcom/google/crypto/tink/proto/HpkePrivateKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    if-nez p1, :cond_1

    .line 382
    const-class p2, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    monitor-enter p2

    .line 383
    :try_start_0
    sget-object p1, Lcom/google/crypto/tink/proto/HpkePrivateKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    if-nez p1, :cond_0

    .line 385
    new-instance p1, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;

    sget-object p3, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-direct {p1, p3}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$DefaultInstanceBasedParser;-><init>(Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;)V

    .line 388
    sput-object p1, Lcom/google/crypto/tink/proto/HpkePrivateKey;->PARSER:Lcom/google/crypto/tink/shaded/protobuf/Parser;

    goto :goto_0

    :catchall_0
    move-exception p1

    goto :goto_1

    .line 390
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

    .line 377
    :pswitch_3
    sget-object p1, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    return-object p1

    .line 364
    :pswitch_4
    const-string p1, "bitField0_"

    const-string p2, "version_"

    const-string p3, "publicKey_"

    const-string v0, "privateKey_"

    filled-new-array {p1, p2, p3, v0}, [Ljava/lang/Object;

    move-result-object p1

    .line 370
    const-string p2, "\u0000\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u000b\u0002\u1009\u0000\u0003\n"

    .line 373
    sget-object p3, Lcom/google/crypto/tink/proto/HpkePrivateKey;->DEFAULT_INSTANCE:Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-static {p3, p2, p1}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->newMessageInfo(Lcom/google/crypto/tink/shaded/protobuf/MessageLite;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    .line 361
    :pswitch_5
    new-instance p1, Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;

    invoke-direct {p1, p2}, Lcom/google/crypto/tink/proto/HpkePrivateKey$Builder;-><init>(Lcom/google/crypto/tink/proto/HpkePrivateKey$1;)V

    return-object p1

    .line 358
    :pswitch_6
    new-instance p1, Lcom/google/crypto/tink/proto/HpkePrivateKey;

    invoke-direct {p1}, Lcom/google/crypto/tink/proto/HpkePrivateKey;-><init>()V

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

    .line 11
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->getDefaultInstanceForType()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;

    move-result-object v0

    return-object v0
.end method

.method public getPrivateKey()Lcom/google/crypto/tink/shaded/protobuf/ByteString;
    .locals 1

    .line 105
    iget-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->privateKey_:Lcom/google/crypto/tink/shaded/protobuf/ByteString;

    return-object v0
.end method

.method public getPublicKey()Lcom/google/crypto/tink/proto/HpkePublicKey;
    .locals 1

    .line 60
    iget-object v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->publicKey_:Lcom/google/crypto/tink/proto/HpkePublicKey;

    if-nez v0, :cond_0

    invoke-static {}, Lcom/google/crypto/tink/proto/HpkePublicKey;->getDefaultInstance()Lcom/google/crypto/tink/proto/HpkePublicKey;

    move-result-object v0

    :cond_0
    return-object v0
.end method

.method public getVersion()I
    .locals 1

    .line 28
    iget v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->version_:I

    return v0
.end method

.method public hasPublicKey()Z
    .locals 2

    .line 53
    iget v0, p0, Lcom/google/crypto/tink/proto/HpkePrivateKey;->bitField0_:I

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

    .line 11
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->newBuilderForType()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic toBuilder()Lcom/google/crypto/tink/shaded/protobuf/MessageLite$Builder;
    .locals 1

    .line 11
    invoke-super {p0}, Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite;->toBuilder()Lcom/google/crypto/tink/shaded/protobuf/GeneratedMessageLite$Builder;

    move-result-object v0

    return-object v0
.end method
