.class public final Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;
.super Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbub;
.source "com.google.mlkit:text-recognition-bundled-common@@17.0.0"

# interfaces
.implements Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbvn;


# static fields
.field private static final zbd:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;


# instance fields
.field private zbe:I

.field private zbf:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbact;

.field private zbg:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

.field private zbh:F

.field private zbi:F

.field private zbj:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

.field private zbk:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbtc;

.field private zbl:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbact;

.field private zbm:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacl;

.field private zbn:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

.field private zbo:B


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1
    new-instance v0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    invoke-direct {v0}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;-><init>()V

    sput-object v0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbd:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    const-class v1, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    .line 2
    invoke-static {v1, v0}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;->zbD(Ljava/lang/Class;Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;)V

    return-void
.end method

.method private constructor <init>()V
    .locals 1

    .line 1
    invoke-direct {p0}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbub;-><init>()V

    const/4 v0, 0x2

    iput-byte v0, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbo:B

    .line 2
    invoke-static {}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;->zby()Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbg:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    .line 3
    invoke-static {}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;->zby()Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbj:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    .line 4
    sget-object v0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbtc;->zbb:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbtc;

    iput-object v0, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbk:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbtc;

    .line 5
    invoke-static {}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;->zby()Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    move-result-object v0

    iput-object v0, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbn:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbun;

    return-void
.end method

.method static synthetic zbc()Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;
    .locals 1

    .line 0
    sget-object v0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbd:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    return-object v0
.end method


# virtual methods
.method protected final zbb(ILjava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    .locals 13

    add-int/lit8 p1, p1, -0x1

    if-eqz p1, :cond_5

    const/4 v0, 0x2

    if-eq p1, v0, :cond_4

    const/4 v0, 0x3

    if-eq p1, v0, :cond_3

    const/4 v0, 0x4

    const/4 v1, 0x0

    if-eq p1, v0, :cond_2

    const/4 v0, 0x5

    if-eq p1, v0, :cond_1

    if-nez p2, :cond_0

    const/4 p1, 0x0

    goto :goto_0

    :cond_0
    const/4 p1, 0x1

    .line 2
    :goto_0
    iput-byte p1, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbo:B

    return-object v1

    .line 1
    :cond_1
    sget-object p1, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbd:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    return-object p1

    :cond_2
    new-instance p1, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacu;

    .line 3
    invoke-direct {p1, v1}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacu;-><init>(Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacp;)V

    return-object p1

    :cond_3
    new-instance p1, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    .line 4
    invoke-direct {p1}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;-><init>()V

    return-object p1

    .line 2
    :cond_4
    const-string v11, "zbl"

    const-string v12, "zbi"

    const-string v0, "zbe"

    const-string v1, "zbf"

    const-string v2, "zbg"

    const-class v3, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbada;

    const-string v4, "zbh"

    const-string v5, "zbj"

    const-class v6, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacw;

    const-string v7, "zbm"

    const-string v8, "zbn"

    const-class v9, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbacr;

    const-string v10, "zbk"

    filled-new-array/range {v0 .. v12}, [Ljava/lang/Object;

    move-result-object p1

    sget-object v0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbd:Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;

    const-string v1, "\u0001\t\u0000\u0001\u0001\t\t\u0000\u0003\u0001\u0001\u1009\u0000\u0002\u001b\u0003\u1001\u0001\u0004\u001b\u0005\u1409\u0005\u0006\u001b\u0007\u100a\u0003\u0008\u1009\u0004\t\u1001\u0002"

    invoke-static {v0, v1, p1}, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbuf;->zbA(Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbvm;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1

    :cond_5
    iget-byte p1, p0, Lcom/google/android/gms/internal/mlkit_vision_text_bundled_common/zbadb;->zbo:B

    .line 1
    invoke-static {p1}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object p1

    return-object p1
.end method
