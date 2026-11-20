.class public abstract Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;
.super Ljava/lang/Object;
.source "CaretString.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/model/CaretString;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "CaretGravity"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;,
        Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;
    }
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 22
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 22
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;-><init>()V

    return-void
.end method


# virtual methods
.method public final getAutocomplete()Z
    .locals 1

    .line 28
    instance-of v0, p0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    if-eqz v0, :cond_0

    move-object v0, p0

    check-cast v0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;->getAutocompleteValue()Z

    move-result v0

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method public final getAutoskip()Z
    .locals 1

    .line 34
    instance-of v0, p0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;

    if-eqz v0, :cond_0

    move-object v0, p0

    check-cast v0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;->getAutoskipValue()Z

    move-result v0

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
