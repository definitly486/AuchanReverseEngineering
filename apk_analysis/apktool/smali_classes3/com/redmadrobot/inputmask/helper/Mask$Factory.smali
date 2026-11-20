.class public final Lcom/redmadrobot/inputmask/helper/Mask$Factory;
.super Ljava/lang/Object;
.source "Mask.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/helper/Mask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Factory"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 62
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 62
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/helper/Mask$Factory;-><init>()V

    return-void
.end method


# virtual methods
.method public final getOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)",
            "Lcom/redmadrobot/inputmask/helper/Mask;"
        }
    .end annotation

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 76
    invoke-static {}, Lcom/redmadrobot/inputmask/helper/Mask;->access$getCache$cp()Ljava/util/Map;

    move-result-object v0

    invoke-interface {v0, p1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/redmadrobot/inputmask/helper/Mask;

    if-nez v0, :cond_0

    .line 78
    new-instance v0, Lcom/redmadrobot/inputmask/helper/Mask;

    invoke-direct {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;-><init>(Ljava/lang/String;Ljava/util/List;)V

    .line 79
    invoke-static {}, Lcom/redmadrobot/inputmask/helper/Mask;->access$getCache$cp()Ljava/util/Map;

    move-result-object p2

    invoke-interface {p2, p1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_0
    return-object v0
.end method

.method public final isValid(Ljava/lang/String;Ljava/util/List;)Z
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)Z"
        }
    .end annotation

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 95
    :try_start_0
    new-instance v0, Lcom/redmadrobot/inputmask/helper/Mask;

    invoke-direct {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;-><init>(Ljava/lang/String;Ljava/util/List;)V
    :try_end_0
    .catch Lcom/redmadrobot/inputmask/helper/Compiler$FormatError; {:try_start_0 .. :try_end_0} :catch_0

    const/4 p1, 0x1

    return p1

    :catch_0
    const/4 p1, 0x0

    return p1
.end method
