.class public final Lcom/redmadrobot/inputmask/helper/RTLMask;
.super Lcom/redmadrobot/inputmask/helper/Mask;
.source "RTLMask.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;
    }
.end annotation


# static fields
.field public static final Factory:Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;

.field private static final cache:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/redmadrobot/inputmask/helper/RTLMask;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/redmadrobot/inputmask/helper/RTLMask;->Factory:Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;

    .line 14
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/redmadrobot/inputmask/helper/RTLMask;->cache:Ljava/util/Map;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)V"
        }
    .end annotation

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 12
    invoke-static {p1}, Lcom/redmadrobot/inputmask/helper/RTLMaskKt;->access$reversedFormat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;-><init>(Ljava/lang/String;Ljava/util/List;)V

    return-void
.end method

.method public static final synthetic access$getCache$cp()Ljava/util/Map;
    .locals 1

    .line 12
    sget-object v0, Lcom/redmadrobot/inputmask/helper/RTLMask;->cache:Ljava/util/Map;

    return-object v0
.end method


# virtual methods
.method public apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 1

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 27
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->reversed()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p1

    invoke-super {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->reversed()Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    return-object p1
.end method

.method public makeIterator(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/CaretStringIterator;
    .locals 1

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 31
    new-instance v0, Lcom/redmadrobot/inputmask/helper/RTLCaretStringIterator;

    invoke-direct {v0, p1}, Lcom/redmadrobot/inputmask/helper/RTLCaretStringIterator;-><init>(Lcom/redmadrobot/inputmask/model/CaretString;)V

    return-object v0
.end method
