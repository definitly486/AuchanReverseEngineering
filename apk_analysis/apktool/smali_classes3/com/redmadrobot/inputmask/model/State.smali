.class public abstract Lcom/redmadrobot/inputmask/model/State;
.super Ljava/lang/Object;
.source "State.kt"


# instance fields
.field private final child:Lcom/redmadrobot/inputmask/model/State;


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/State;)V
    .locals 0

    .line 11
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/model/State;->child:Lcom/redmadrobot/inputmask/model/State;

    return-void
.end method


# virtual methods
.method public abstract accept(C)Lcom/redmadrobot/inputmask/model/Next;
.end method

.method public autocomplete()Lcom/redmadrobot/inputmask/model/Next;
    .locals 1

    .line 0
    const/4 v0, 0x0

    return-object v0
.end method

.method public final getChild()Lcom/redmadrobot/inputmask/model/State;
    .locals 1

    .line 11
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/State;->child:Lcom/redmadrobot/inputmask/model/State;

    return-object v0
.end method

.method public nextState()Lcom/redmadrobot/inputmask/model/State;
    .locals 1

    .line 47
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/State;->child:Lcom/redmadrobot/inputmask/model/State;

    if-nez v0, :cond_0

    invoke-static {}, Lkotlin/jvm/internal/Intrinsics;->throwNpe()V

    :cond_0
    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 51
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "BASE -> "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/redmadrobot/inputmask/model/State;->child:Lcom/redmadrobot/inputmask/model/State;

    if-eqz v1, :cond_0

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/State;->toString()Ljava/lang/String;

    move-result-object v1

    goto :goto_0

    :cond_0
    const-string v1, "null"

    :goto_0
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
