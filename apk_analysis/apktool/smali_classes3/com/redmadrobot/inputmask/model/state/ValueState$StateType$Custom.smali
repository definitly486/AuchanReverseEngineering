.class public final Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;
.super Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;
.source "ValueState.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Custom"
.end annotation


# instance fields
.field private final character:C

.field private final characterSet:Ljava/lang/String;


# direct methods
.method public constructor <init>(CLjava/lang/String;)V
    .locals 1

    const-string v0, "characterSet"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 35
    invoke-direct {p0, v0}, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    iput-char p1, p0, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;->character:C

    iput-object p2, p0, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;->characterSet:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public final getCharacter()C
    .locals 1

    .line 35
    iget-char v0, p0, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;->character:C

    return v0
.end method

.method public final getCharacterSet()Ljava/lang/String;
    .locals 1

    .line 35
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;->characterSet:Ljava/lang/String;

    return-object v0
.end method
