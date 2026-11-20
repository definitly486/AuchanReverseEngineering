.class public final Lcom/redmadrobot/inputmask/model/state/EOLState;
.super Lcom/redmadrobot/inputmask/model/State;
.source "EOLState.kt"


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    .line 16
    invoke-direct {p0, v0}, Lcom/redmadrobot/inputmask/model/State;-><init>(Lcom/redmadrobot/inputmask/model/State;)V

    return-void
.end method


# virtual methods
.method public accept(C)Lcom/redmadrobot/inputmask/model/Next;
    .locals 0

    .line 0
    const/4 p1, 0x0

    return-object p1
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 22
    const-string v0, "EOL"

    return-object v0
.end method
