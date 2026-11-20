.class public final Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;
.super Ljava/lang/Object;
.source "RTLMask.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/helper/RTLMask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Factory"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 13
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;-><init>()V

    return-void
.end method


# virtual methods
.method public final getOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/RTLMask;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)",
            "Lcom/redmadrobot/inputmask/helper/RTLMask;"
        }
    .end annotation

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 17
    invoke-static {}, Lcom/redmadrobot/inputmask/helper/RTLMask;->access$getCache$cp()Ljava/util/Map;

    move-result-object v0

    invoke-static {p1}, Lcom/redmadrobot/inputmask/helper/RTLMaskKt;->access$reversedFormat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/redmadrobot/inputmask/helper/RTLMask;

    if-nez v0, :cond_0

    .line 19
    new-instance v0, Lcom/redmadrobot/inputmask/helper/RTLMask;

    invoke-direct {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/RTLMask;-><init>(Ljava/lang/String;Ljava/util/List;)V

    .line 20
    invoke-static {}, Lcom/redmadrobot/inputmask/helper/RTLMask;->access$getCache$cp()Ljava/util/Map;

    move-result-object p2

    invoke-static {p1}, Lcom/redmadrobot/inputmask/helper/RTLMaskKt;->access$reversedFormat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    invoke-interface {p2, p1, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    :cond_0
    return-object v0
.end method
