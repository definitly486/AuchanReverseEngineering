.class public abstract Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;
.super Ljava/lang/Object;
.source "ValueState.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/model/state/ValueState;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "StateType"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Numeric;,
        Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Literal;,
        Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$AlphaNumeric;,
        Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Ellipsis;,
        Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 30
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;-><init>()V

    return-void
.end method
